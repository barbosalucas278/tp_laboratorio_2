using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void SalasDelegate(Sala salaActualizada);
    /// <summary>
    /// Clase publica.
    /// </summary>
    public class Sala
    {
        #region "Atributos"

        public event SalasDelegate ActualizarSalasEvento;

        private const int CantidadDeButacasPorFila = 10;
        private const int CantidadDeFilas = 10;
        private const string NombreDeFilas = "ABCDEFGHIJ";
        private List<Butaca> butacas;
        private int numeroDeSala;
        #endregion
        #region "Constructor"

        public Sala(int numeroDeSala)
        {
            this.butacas = new List<Butaca>();
            this.ArmarSala();
            this.numeroDeSala = numeroDeSala;
        }
        #endregion
        #region "Propiedades"
        /// <summary>
        /// propiedad que maneja el atributo butacas.
        /// </summary>
        public List<Butaca> Butacas
        {
            get
            {
                return this.butacas;
            }
            set
            {
                this.butacas = value;
            }
        }
        /// <summary>
        /// Propiedad que maneja el atributo numeroDeSalas.
        /// </summary>
        public int NumeroDeSala
        {
            get
            {
                return this.numeroDeSala;
            }
        }
        #endregion
        #region "Metodos"

        /// <summary>
        /// Ocupa una butaca d ela sala
        /// </summary>
        /// <param name="ubicacion">Ubicacion</param>
        /// <returns></returns>
        public bool OcuparButaca(string ubicacion)
        {
            foreach(Butaca b in this.Butacas)
            {
                if(b == ubicacion && b.Estado == Butaca.TipoEstado.Libre)
                {
                    if (b.Ocupar())
                    {
                        this.ActualizarSalasEvento.Invoke(this);
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Libera una butaca de la sala en la ubicacion indicada.
        /// </summary>
        /// <param name="ubicacion">ubicacion</param>
        /// <returns>true si la pudo liberar, false y no la pudo liberar</returns>
        public bool LiberarButaca(string ubicacion)
        {
            foreach(Butaca b in this.Butacas)
            {
                if(b == ubicacion && b.Estado == Butaca.TipoEstado.Ocupado)
                {
                    b.Liberar();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Arma la numeraciOn y distribución de las butacas en la sala.
        /// </summary>
        private void ArmarSala()
        {
            for (int fila = 0; fila < CantidadDeFilas; fila++)
            {
                for (int butaca = 1; butaca <= CantidadDeButacasPorFila; butaca++)
                {
                    string ubicacion = NombreDeFilas.Substring(fila, 1) + butaca.ToString();
                    this.butacas.Add(new Butaca(ubicacion,Butaca.TipoEstado.Libre));
                }
            }
        }
        public override string ToString()
        {
            return this.NumeroDeSala.ToString();
        }
        #endregion
    }
}
