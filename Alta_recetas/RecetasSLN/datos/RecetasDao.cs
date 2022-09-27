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
    }
}
