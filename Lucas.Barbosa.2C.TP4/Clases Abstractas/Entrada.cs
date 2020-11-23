using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using MetodosDeExtension;

namespace Entidades
{
    public abstract class Entrada
    {
        private const double Ganancia = 30;
        private int id;
        private string espectaculo;
        private int sala;
        private DateTime fecha;
        private string butaca;
        private double costo;
        #region "Constructor"

        protected Entrada(string espectaculo, int sala, DateTime fecha, string butaca, double costo)
        {
            this.Id = -1;
            this.Espectaculo = espectaculo;
            this.Sala = sala;
            this.Fecha = fecha;
            this.Butaca = butaca;
            this.Precio = costo;
        }
        #endregion

        #region "Propiedades"
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        public string Espectaculo
        {
            get
            {
                return this.espectaculo;
            }
            set
            {
                this.espectaculo = value;
            }
        }
        public int Sala
        {
            get
            {
                return this.sala;
            }
            set
            {
                this.sala = value;
            }
        }
        public DateTime Fecha
        {
            get
            {
                return this.fecha;
            }
            set
            {
                this.fecha = value;
            }
        }
        public string Butaca
        {
            get
            {
                return this.butaca;
            }
            set
            {
                if (value.Contains("[..]"))
                {
                    throw new EntradaException("No eleigió butaca");
                }
                else
                {
                    this.butaca = value;
                }
            }
        }
        public double Precio
        {
            get
            {
                return this.costo;
            }
            set
            {
                this.costo = value.CalcularPrecio(Ganancia);
            }
        }
        #endregion
        #region "Métodos"

        public virtual string MostrarDatos()
        {
            StringBuilder datosEntrada = new StringBuilder();

            datosEntrada.AppendLine($" Espectaculo: {this.Espectaculo}");
            datosEntrada.Append($" | Sala: {this.Sala}");
            datosEntrada.Append($" | Día y horario: {this.Fecha}");
            datosEntrada.Append($" | Ubicacion: {this.Butaca}");
            datosEntrada.Append($" | ${this.Precio} |");

            return datosEntrada.ToString();
        }
        #endregion
        /// <summary>
        /// dos entradas son iguales si tienen el mismo id y butaca.
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator == (Entrada e1, Entrada e2)
        {
            if(e1.Butaca == e2.Butaca && e1.Espectaculo == e2.Espectaculo)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Dos entradas son diferentes si sus id son diferentes.
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static bool operator !=(Entrada e1, Entrada e2)
        {
            return !(e1 == e2);
        }
    }
}
