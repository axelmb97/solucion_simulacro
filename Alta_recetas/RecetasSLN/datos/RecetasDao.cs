using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecetasSLN.dominio;
namespace RecetasSLN.datos
{
    internal class RecetasDao
    {
        public DataTable ObtenerIngredientes() {
            DataTable dt = ConexionDB.ObtenerInstancia().ConsultarSP("SP_CONSULTAR_INGREDIENTES");
            return dt;
        }
        public DataTable ObtenerTiposRecetas()
        {
            DataTable dt = ConexionDB.ObtenerInstancia().ConsultarSP("SP_CONSULTAR_TIPOS_RECETAS");
            return dt;
        }
        public int CantidadRecetas() {
            int total = Convert.ToInt32(ConexionDB.ObtenerInstancia().ConsultarSPOutput("SP_CANTIDAD_RECETAS", "@CantidadRecetas"));
            return total;
        }
        public bool InsertarReceta(Receta receta) {
            bool aux = ConexionDB.ObtenerInstancia().InsertarMaestroDetalle(receta,"SP_INSERTAR_RECETA","@UltimoId","SP_INSERTAR_DETALLES");
            return aux;
        }
        public DataTable ObtenerRecetas(int idTipo) {
            List<Parametro> param = new List<Parametro>();
            param.Add(new Parametro("@idTipo",idTipo));
            DataTable dt = ConexionDB.ObtenerInstancia().ConsultaSpConParametros("SP_CONSULTAR_RECETAS",param);
            return dt;
        }
        public DataTable ObtenerDetalles(int idReceta) {
            List<Parametro> param = new List<Parametro>();
            param.Add(new Parametro("@idReceta",idReceta));
            DataTable dt = ConexionDB.ObtenerInstancia().ConsultaSpConParametros("SP_CONSULTAR_DETALLES",param);
            return dt;
        }
        public bool Modificar(Receta receta) {
            List<Parametro> paramMaestro = new List<Parametro>();
            paramMaestro.Add(new Parametro("@idReceta",receta.RecetaNro));
            paramMaestro.Add(new Parametro("@nombre",receta.Nombre));
            paramMaestro.Add(new Parametro("@cheff",receta.Cheff));
            paramMaestro.Add(new Parametro("@tipo_receta",receta.TipoReceta));
           
            
            bool aux = ConexionDB.ObtenerInstancia().ModificarMaestroDetalle("SP_MODIFICAR_MAESTRO",receta,paramMaestro,"SP_INSERTAR_DETALLES");
            return aux;
        }
    }
}
