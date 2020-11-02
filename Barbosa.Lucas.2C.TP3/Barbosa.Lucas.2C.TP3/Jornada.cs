using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jornada
    {
        #region "Atributos"

        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion
        #region "Constructores"

        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion
        #region "propiedades"
        /// <summary>
        /// Obtiene el profesor de la jornada.
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        /// <summary>
        /// Obtiene la clase de la jornada.
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        /// <summary>
        /// Obtiene la lista de alumnos de la jornada.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        #endregion
        #region "Operadores"
        /// <summary>
        /// Jornada será igual a Alumno si éste se encuentra en la lista de alumnos de la jornada.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="n">Alumno</param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno n)
        {
            foreach(Alumno alumno in j.Alumnos)
            {
                if(alumno == n)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Jornada será distinto de Alumno si éste no se encuentra en la lista de alumnos de la jornada.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="n">Alumno</param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno n)
        {
            return !(j == n);
        }
        /// <summary>
        /// ALumno será agregadoa a lista de alumnos de jornada, si este no se encuentra en la lista.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno n)
        {
            if(j != n)
            {
                j.Alumnos.Add(n);
            }
            else
            {
                throw new AlumnoRepetidoException("Alumno repetido");
            }
            return j;
        }
        #endregion
        #region "Métodos"

        public override string ToString()
        {
            StringBuilder datosJornada = new StringBuilder();

            datosJornada.AppendLine($"CLASE DE {this.Clase}");
            datosJornada.AppendLine($"PROFESOR");
            datosJornada.AppendLine($"{this.Instructor.ToString()}");
            datosJornada.AppendLine($"ALUMNOS \n");
            foreach (Alumno alumno in this.Alumnos)
            {
                datosJornada.AppendLine($"{alumno}");
            }
            datosJornada.AppendLine("<------------------------------------------------>");
            return datosJornada.ToString();
        }
        /// <summary>
        /// Guardará los datos de una jornada en un archivo de texto, en el mismo directorio.
        /// </summary>
        /// <param name="jornada">Jornada</param>
        /// <returns>True si se puudo guardar, False si no s epudo guardar.</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto txt = new Texto();
            string nombre = "jornadas";
            try
            {
                if (txt.Guardar(nombre, jornada.ToString()))
                {
                    return true;
                }
            }
            catch (ArchivosException ex)
            {
                throw new ArchivosException(ex);
            }
            return false;
        }
        /// <summary>
        /// Lee un archivos de texto con datos de las jornadas.
        /// </summary>
        /// <returns>string con datos de las jornadas</returns>
        public static string Leer()
        {
            Texto txt = new Texto();
            string nombre = "jornadas";
            string salida = string.Empty;
            try
            {
                txt.Leer(nombre, out salida);
            }
            catch (ArchivosException ex)
            {
                throw new ArchivosException(ex);
            }

            return salida;
        }
        #endregion
    }
}
