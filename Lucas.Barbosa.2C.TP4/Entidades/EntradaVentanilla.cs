using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public sealed class EntradaVentanilla: Entrada
    {
        private string nombreComprador;

        public EntradaVentanilla(string espectaculo, int sala, DateTime fecha, string butaca, string comprador, double precio) : base(espectaculo, sala, fecha, butaca, precio)
        {
            this.NombreComprador = comprador;
        }     
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

        public override string MostrarDatos()
        {
            StringBuilder datosVentanilla = new StringBuilder();

            datosVentanilla.Append(base.MostrarDatos());
            datosVentanilla.Append($"| Comprador: {this.NombreComprador}");

            return datosVentanilla.ToString();
        }


    }
}
