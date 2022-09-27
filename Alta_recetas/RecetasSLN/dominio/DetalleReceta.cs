using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
    internal class DetalleReceta
    {
        public DetalleReceta(Ingrediente ingredienteDet, int cantidad)
        {
            IngredienteDet = ingredienteDet;
            Cantidad = cantidad;
        }

        public Ingrediente IngredienteDet { get; set; }
        public int Cantidad { get; set; }
    }
}
