using RecetasSLN.datos;
using RecetasSLN.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Negocios
{
    internal class GestorRecetas
    {
        private RecetasDao datos;
        public GestorRecetas()
        {
            datos = new RecetasDao();
        }
        public DataTable ObtenerIngredientes() {
            return datos.ObtenerIngredientes();
        }
        public DataTable ObtenerTiposRecetas() {
            return datos.ObtenerTiposRecetas();
        }
        public int ObtenerCantidadRecetas() {
            return datos.CantidadRecetas();
        }
        public bool Confirmar(Receta receta) {
            return datos.InsertarReceta(receta);
        }
    }
}
