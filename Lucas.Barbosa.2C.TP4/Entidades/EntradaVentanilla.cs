using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Esta clase no se puede derivar.
    /// </summary>
    public sealed class EntradaVentanilla: Entrada
    {
        #region "Atributos"

        private string nombreComprador;
        #endregion
        #region "Constructor"

        public EntradaVentanilla(string espectaculo, int sala, DateTime fecha, string butaca, string comprador, double precio) : base(espectaculo, sala, fecha, butaca, precio)
        {
            this.NombreComprador = comprador;
        }
        #endregion
        #region "Propiedades"

        /// <summary>
        /// Propiedad que maneja el atributo nombreComprador, si este es nulo, lanza una excepcion.
        /// </summary>
        public string NombreComprador
        {
            get
            {
                return this.nombreComprador;
            }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new EntradaException("Falta el nombre del comprador");
                }
                else
                {
                    this.nombreComprador = value;
                }
            }
        }
        #endregion
        #region "Metodos"

        public override string MostrarDatos()
        {
            StringBuilder datosVentanilla = new StringBuilder();

            datosVentanilla.Append(base.MostrarDatos());
            datosVentanilla.Append($"| Comprador: {this.NombreComprador}");

            return datosVentanilla.ToString();
        }
        #endregion
    }
}
