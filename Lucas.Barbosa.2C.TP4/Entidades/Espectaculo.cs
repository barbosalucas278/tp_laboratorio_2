using Excepciones;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;
using MetodosDeExtension;
namespace Entidades
{
    public class Espectaculo
    {
        private string nombre;
        private string descripcion;
        private DateTime horario;
        private int sala;
        private double precio;
        public Espectaculo(string nombre, string descripcion, DateTime horario, int sala, double costo)
        {
            this.Costo = costo;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Dia = horario;
            this.Sala = sala;
        }
        #region "Propiedades"
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if(value == string.Empty)
                {
                    throw new EspectaculoException("Nombre vacio");
                }
                else
                {
                    this.nombre = value;
                }
            }
        }
        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                if(value == string.Empty)
                {
                    throw new EspectaculoException("Descripcion vacia");
                }
                else
                {
                    this.descripcion = value;
                }
            }
        }
        public DateTime Dia
        {
            get
            {
                return this.horario;
            }
            set
            {
                this.horario = value;
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
        public double Costo
        {
            get
            {
                return this.precio;
            }
            set
            {
                if(value < 0)
                {
                    throw new EspectaculoException("En valor de la entrada debe ser mayor o igual a 0");
                }
                else
                {
                    this.precio = value;
                }
            }
        }
        #endregion
        /// <summary>
        /// Un espectaculo es igual a una sala si la sala del espectaculo es igual al numero de sala.
        /// </summary>
        /// <param name="e">espectaculo</param>
        /// <param name="s">sala</param>
        /// <returns></returns>
        public static bool operator ==(Espectaculo e, Sala s)
        {
            if(e.Sala == s.NumeroDeSala)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Espectaculo e, Sala s)
        {
            return !(e == s);
        }
        /// <summary>
        /// Un espectaculo es igual a otro si tienen el mismo horario y misma sala.
        /// </summary>
        /// <param name="e1">Primer espectaculo como parametro</param>
        /// <param name="e2">Segundo espectaculo como parametro</param>
        /// <returns></returns>
        public static bool operator ==(Espectaculo e1, Espectaculo e2)
        {
            if(e1.Sala == e2.Sala && e1.Dia == e2.Dia)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Un espectaculo es distinto a otro si tienen el distinto horario y distinto sala.
        /// </summary>
        /// <param name="e1">Primer espectaculo como parametro</param>
        /// <param name="e2">Segundo espectaculo como parametro</param>
        /// <returns></returns>
        public static bool operator !=(Espectaculo e1, Espectaculo e2)
        {
            return !(e1 == e2);
        }
        /// <summary>
        /// Muestra todos los datos de un espectaculo.
        /// </summary>
        /// <returns>string con todos los datos.</returns>
        public string MostrarDatos()
        {
            StringBuilder datosEspectaculo = new StringBuilder();

            datosEspectaculo.AppendLine($"Nombre del espectaculo: {this.Nombre}");
            datosEspectaculo.AppendLine($"Sinopsis: {this.descripcion}");
            datosEspectaculo.AppendLine($"Horario: {this.Dia}");
            datosEspectaculo.AppendLine($"Sala: {this.Sala}");

            return datosEspectaculo.ToString();
        }

        public override string ToString()
        {
            return this.Nombre;
        }
    }
}