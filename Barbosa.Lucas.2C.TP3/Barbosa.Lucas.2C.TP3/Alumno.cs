using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Alumno: Universitario
    {
        #region "Atributos"

        public enum EEstadoCuenta { AlDia,Deudor,Becado }
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion
        #region "Constructores"

        public Alumno()
        {
        }
        public Alumno(int id, string nombre, string apellido, string dni,ENacionalidad nacionalidad,Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta):this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion
        #region "Métodos"

        protected override string MostrarDatos()
        {
            StringBuilder datosAlumno = new StringBuilder();

            datosAlumno.AppendLine(base.MostrarDatos());
            datosAlumno.AppendLine($"Clase que toma: {this.claseQueToma}");
            datosAlumno.AppendLine($"Estado de la cuenta: {this.estadoCuenta}");

            return datosAlumno.ToString();
        }
        /// <summary>
        /// Clases en las que participa.
        /// </summary>
        /// <returns>Retorna un string con las clases que toma.</returns>
        protected override string ParticiparEnClase()
        {
            return $"TOMA CLASE DE {this.claseQueToma}";
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
        #region "Operadores"
        /// <summary>
        /// Alumno será igual a EClase si éste toma la clase y si el estado de su cuenta no es deudor.
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Alumno será distinto de EClase si éste no toma la clase y es deudor.
        /// </summary>
        /// <param name="a">Alumnos</param>
        /// <param name="clase">Clase</param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if(a.claseQueToma != clase)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
