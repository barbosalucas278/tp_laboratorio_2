using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class EntradaElectronica: Entrada
    {
        private string email;

        public EntradaElectronica(string espectaculo, int sala, DateTime fecha, string butaca, double precio, string email) : base(espectaculo, sala, fecha, butaca, precio)
        {
            this.email = email;
        }
        
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
        public override string MostrarDatos()
        {
            StringBuilder datosVentanilla = new StringBuilder();

            datosVentanilla.Append(base.MostrarDatos());
            datosVentanilla.Append($" | Comprador: {this.Email}");

            return datosVentanilla.ToString();
        }
    }
}
