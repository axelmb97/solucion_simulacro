using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
    internal class Parametro
    {
        public Parametro(string nombre, object value)
        {
            Nombre = nombre;
            Value = value;
        }

        public string Nombre { get; set; }
        public Object Value { get; set; }
    }
}
