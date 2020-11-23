using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Butaca
    {
        #region "Atributos"

        public enum TipoEstado { Ocupado, Libre }
        private string ubicacion;
        private TipoEstado estado;
        #endregion
        #region "Contructor"

        public Butaca(string ubicacion, TipoEstado estado)
        {
            this.ubicacion = ubicacion;
            this.estado = estado;
        }
        #endregion
        #region "Propiedades"

        public string Ubicacion
        {
            get
            {
                return this.ubicacion;
            }
        }
        public TipoEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }
        #endregion
        #region "Operadores"
        /// <summary>
        /// Operador que compara una butaca con una ubicacion para saver si esta ocupada o no.
        /// </summary>
        /// <param name="b1">butaca</param>
        /// <param name="ubicacion">ubicacion</param>
        /// <returns>retorna true si la butaca esta libre, false si esta ocupada</returns>
        public static bool operator ==(Butaca b1, string ubicacion)
        {
            if(b1.Ubicacion == ubicacion)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Butaca b1, string ubicacion)
        {
            return !(b1 == ubicacion);
        }
        #endregion
        #region "Metodos"
        /// <summary>
        /// Cambia el estado de una butaca de libre a ocupado.
        /// </summary>
        /// <returns></returns>
        public bool Ocupar()
        {
            if (this.Estado == TipoEstado.Libre)
            {
                this.Estado = TipoEstado.Ocupado;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Cambia el estado de una butaca de ocupado a libre.
        /// </summary>
        /// <returns></returns>
        public bool Liberar()
        {
            if (!this.Ocupar())
            {
                this.Estado = TipoEstado.Libre;
                return true;
            }
            return false;
        }
        #endregion
    }
}
