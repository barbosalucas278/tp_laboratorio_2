using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosDeExtension
{
    public static class DoubleMetodoExtension
    {
        /// <summary>
        /// Calcula el precio de un articulo.
        /// </summary>
        /// <param name="costo">Costo del articulo</param>
        /// <param name="ganancia">Ganancia calculada.</param>
        /// <returns>Valor auemntado con la ganancia</returns>
        public static double CalcularPrecio(this double costo, double ganancia)
        {
            return costo + (costo * ganancia / 100);
        }
    }
}
