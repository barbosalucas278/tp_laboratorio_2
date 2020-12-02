using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Salidas
    {
        #region "Atributos"

        private DateTime fechaFin;
        private DateTime fechaInicio;
        #endregion
        #region "Constructor"
        
        public Salidas()
        {
            this.fechaInicio = DateTime.Now;
        }
        #endregion
        #region "Propiedades"

        public DateTime FechaFin
        {
            get
            {
                return this.fechaFin;
            }
            set
            {
                this.fechaFin = value;
            }
        }
        public DateTime FechaInicio
        {
            get
            {
                return this.fechaInicio;
            }
            set
            {
                this.fechaInicio = value;
            }
        }
        public int TiempoTotal
        {
            get
            {
                return this.FechaInicio.DiferenciaEnMinutos(this.FechaFin);
            }
        }
        #endregion
        #region "Métodos"
        /// <summary>
        /// Coloca el horario de finalización en el atributo fechaFin.
        /// </summary>
        public void FinalizarSalida()
        {
            this.FechaFin = DateTime.Now;
        }

        #endregion
    }
}
