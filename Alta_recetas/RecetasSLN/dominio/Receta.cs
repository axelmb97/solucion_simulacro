using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
    internal class Receta
    {
        public Receta()
        {
            //RecetaNro = -1;
            Nombre = "";
            TipoReceta = -1;
            Cheff = "";
            Detalles = new List<DetalleReceta>();
        }
        public Receta(int recetaNro, string nombre, int tipoReceta, string cheff)
        {
            //RecetaNro = recetaNro;
            Nombre = nombre;
            TipoReceta = tipoReceta;
            Cheff = cheff;
            Detalles = new List<DetalleReceta>(); 
        }

        //public int RecetaNro { get; set; }
        public string Nombre { get; set; }
        public int TipoReceta { get; set; }
        public string Cheff { get; set; }
        public List<DetalleReceta> Detalles { get; set; }
        public void AgregarDetalle(DetalleReceta detalle) {
            Detalles.Add(detalle);
        }
        public void EliminarDetalle(int index) {
            Detalles.RemoveAt(index);
        }
        
    }
}
