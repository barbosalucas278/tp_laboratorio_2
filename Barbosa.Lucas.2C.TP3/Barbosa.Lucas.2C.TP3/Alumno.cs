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

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            return false;
        }

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
