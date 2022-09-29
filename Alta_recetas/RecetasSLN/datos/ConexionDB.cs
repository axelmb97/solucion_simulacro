using RecetasSLN.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.datos
{
    internal class ConexionDB
    {
        private static ConexionDB instancia;
        private SqlConnection cnn;
        private ConexionDB()
        {
            cnn = new SqlConnection(Properties.Resources.cadenaConexion);
        }
        public static ConexionDB ObtenerInstancia() {
            if (instancia == null) { 
                instancia = new ConexionDB();
            }
            return instancia;
        }
        public DataTable ConsultarSP(string nombreSP) {
            cnn.Open();
            SqlCommand cmd = new SqlCommand(nombreSP,cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable tabla = new DataTable();
            tabla.Load(cmd.ExecuteReader());
            cnn.Close();
            return tabla;
        }
        public Object ConsultarSPOutput(string nombreSP,string parametroSalida) {
            int total = 0;
            cnn.Open();
            SqlCommand cmd = new SqlCommand(nombreSP, cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter(parametroSalida, SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();
            total = (int)param.Value;
            cnn.Close();
            return total;
        }
        public DataTable ConsultaSpConParametros(string nombreSP,List<Parametro> param) {
            DataTable dt = new DataTable();

            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(nombreSP,cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (Parametro p in param) {
                    cmd.Parameters.AddWithValue(p.Nombre,p.Value);
                }
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception)
            {
                dt = null;
            }
            finally {
                cnn.Close();
            }

            return dt;
        }
        public bool InsertarMaestroDetalle(Receta maestro,string spMaestro,string parametroSalida,string spDetalle) {
            bool aux = true;
            SqlTransaction t = null;
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                SqlCommand cmdMaestro = new SqlCommand(spMaestro,cnn,t);
                cmdMaestro.CommandType = CommandType.StoredProcedure;
                cmdMaestro.Parameters.AddWithValue("@tipo_receta", maestro.TipoReceta);
                cmdMaestro.Parameters.AddWithValue("@nombre",maestro.Nombre);
                cmdMaestro.Parameters.AddWithValue("@cheff",maestro.Cheff);
                SqlParameter param = new SqlParameter(parametroSalida,SqlDbType.Int);
                param.Direction= ParameterDirection.Output;
                cmdMaestro.Parameters.Add(param);
                cmdMaestro.ExecuteNonQuery();
                int idReceta = Convert.ToInt32(param.Value);
                foreach (DetalleReceta dr in maestro.Detalles) {
                    SqlCommand cmdDetReceta = new SqlCommand(spDetalle,cnn,t);
                    cmdDetReceta.CommandType = CommandType.StoredProcedure;
                    cmdDetReceta.Parameters.AddWithValue("@id_receta",idReceta);
                    cmdDetReceta.Parameters.AddWithValue("@id_ingrediente",dr.IngredienteDet.IngredienteId);
                    cmdDetReceta.Parameters.AddWithValue("@cantidad",dr.Cantidad);
                    cmdDetReceta.ExecuteNonQuery(); 

                }
                t.Commit();
            }
            catch (Exception ex)
            {
                if (t != null) { 
                    t.Rollback();
                }
                System.Windows.Forms.MessageBox.Show("Error",ex.Message);
                aux = false;
            }
            finally {
                if (cnn != null && cnn.State == ConnectionState.Open) cnn.Close();
            }
            return aux;
        }
        public bool ModificarMaestroDetalle(string nombreSpMaestro,Receta datos,List<Parametro> paramMaestro,string nombreSpDetalle) {
            bool aux = true;
            SqlTransaction t = null;
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                SqlCommand cmdMaestro = new SqlCommand(nombreSpMaestro, cnn, t);
                cmdMaestro.CommandType = CommandType.StoredProcedure;
                foreach (Parametro param in paramMaestro)
                {
                    cmdMaestro.Parameters.AddWithValue(param.Nombre, param.Value);
                }
                cmdMaestro.ExecuteNonQuery();

                foreach (DetalleReceta dr in datos.Detalles)
                {
                    SqlCommand cmdDetalle = new SqlCommand(nombreSpDetalle, cnn, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@id_receta", datos.RecetaNro);
                    cmdDetalle.Parameters.AddWithValue("@id_ingrediente", dr.IngredienteDet.IngredienteId);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", dr.Cantidad);
                    cmdDetalle.ExecuteNonQuery();
                }
                t.Commit();
            }
            catch (Exception)
            {

                t.Rollback();
                aux = false;
            }
            finally {
                if (cnn != null && cnn.State == ConnectionState.Open) {
                    cnn.Close();
                }
            }
            return aux;
        }
    }
}
