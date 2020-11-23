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
    public sealed class EntradaElectronica: Entrada
    {
        #region "Atributos"

        private string email;
        #endregion
        #region "Constructor"

        public EntradaElectronica(string espectaculo, int sala, DateTime fecha, string butaca, double precio, string email) : base(espectaculo, sala, fecha, butaca, precio)
        {
            this.email = email;
        }
        #endregion
        #region "Propiedades"
        /// <summary>
        /// Propiedad que maneja el atributo email.
        /// </summary>
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }
        #endregion
        #region "Metodos"

        public override string MostrarDatos()
        {
            StringBuilder datosVentanilla = new StringBuilder();

            datosVentanilla.Append(base.MostrarDatos());
            datosVentanilla.Append($" | Comprador: {this.Email}");

            return datosVentanilla.ToString();
        }
        #endregion
    }
}
