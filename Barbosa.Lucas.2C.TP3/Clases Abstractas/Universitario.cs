using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region "Atributos"

        private int legajo;
        #endregion
        #region "Contructores"

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre,apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        public Universitario()
        {
        }
        #endregion
        #region "Métodos"

        protected virtual string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine($"Nombre: {base.Nombre}");
            datos.AppendLine($"Apellido: {base.Apellido}");
            datos.AppendLine($"Nacionalidad: {base.Nacionalidad}");
            datos.AppendLine($"DNI: {base.DNI}");
            datos.AppendLine($"Legajo: {this.legajo}");

            return datos.ToString();
        }

        protected abstract string ParticiparEnClase();

        public override bool Equals(object obj)
        {
            if(obj is Universitario)
            {
                return true;
            }
            return false;
        }
        #endregion
        #region "Operadores"
        /// <summary>
        /// Dos Universitarios son iguales si son la misma instancia y si su legajo o Dni son iguales.
        /// </summary>
        /// <param name="u1"></param>
        /// <param name="u2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario u1, Universitario u2)
        {
            if(u1.Equals(u2) && (u1.legajo == u2.legajo || u1.DNI == u2.DNI))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Dos Universitarios son distintos si son diferentes instancias y si su legajo o dni son diferentes.
        /// </summary>
        /// <param name="u1"></param>
        /// <param name="u2"></param>
        /// <returns></returns>
        public static bool operator != (Universitario u1, Universitario u2)
        {
            return !(u1 == u2);
        }
        #endregion
    }
}
