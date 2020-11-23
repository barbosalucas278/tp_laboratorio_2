using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Universidad
    {
        #region "Atributos"

        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }
        private List<Alumno> alumnos;
        private List<Profesor> profesores;
        private List<Jornada> jornada;
        #endregion
        #region "Constructor"

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }
        #endregion
        #region "Propiedades"
        /// <summary>
        /// Obtiene mediante un índice la Jornada correspondiente a la lista de jornadas de la universidad.
        /// </summary>
        /// <param name="i"></param>
        /// <returns>Falta arreglar esto del indice del indexador</returns>
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }
        /// <summary>
        /// OBtiene la lista de Alumnos de Universidad.
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
        /// <summary>
        /// Obtiene la lista de Profesores de Universidad.
        /// </summary>
        public List<Profesor> Profesores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        /// <summary>
        /// Obtiene la lista de Jornadas de Universidad.
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        #endregion
        #region "Operadores"
        /// <summary>
        /// Universidad será igual a Alumno si éste se encuentra en la lista.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="n">Alumno</param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno n)
        {
            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == n)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Universidad será distinto de Alumno si éste no está en la lista.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="n">Alumno</param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno n)
        {
            return !(g == n);
        }
        /// <summary>
        /// Universidad será igual a Profesor si éste se encuentra en la lista de profesores.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="p">Profesor</param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor p)
        {
            foreach (Profesor profesor in g.Profesores)
            {
                if (profesor == p)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Universidad será diferente a Profesor si éste no está en la lista.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor p)
        {
            return !(g == p);
        }
        /// <summary>
        /// Universidad será igual a EClase si existe un profesor que dé esa clase.
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">EClase</param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor p in u.Profesores)
            {
                if (p == clase)
                {
                    return p;
                }
            }

            throw new SinProfesorException("No hay profesor para la clase");
        }
        /// <summary>
        /// Universidad será distinto que EClase si no hay profesores que den la clase.
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">EClase</param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor p in u.Profesores)
            {
                int i = 0;
                while (i < u.Profesores.Count)
                {
                    if (p != clase)
                    {
                        i++;
                    }
                }
                if (i == 2)
                {
                    return p;
                }
            }

            throw new SinProfesorException();
        }
        /// <summary>
        /// Se agregará un alumno a la universidad si éste no se encuentra en la lista.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException("Alumno repetido.");
            }
            return g;
        }
        /// <summary>
        /// Se agregará un profesor a la universidad si no se encuentra en la lista.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="p">Profesor</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor p)
        {
            if (g != p)
            {
                g.Profesores.Add(p);
            }
            return g;
        }
        /// <summary>
        /// Agrega una EClase a la universidad, asignando un profesor que pueda dar la clasae, los alumnos que tomen la clase a la jornada correspondiente.
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">EClase</param>
        /// <returns>Retorna la Universidad con la jornada agregada a la lista.</returns>
        public static Universidad operator +(Universidad u, EClases clase)
        {
            Profesor instructor = (u == clase);

            Jornada jornada = new Jornada(clase, instructor);
            foreach (Alumno a in u.Alumnos)
            {
                if (a == clase)
                {
                    if (jornada == a)
                    {
                        throw new AlumnoRepetidoException();
                    }
                    else
                    {
                        jornada.Alumnos.Add(a);
                    }
                }

            }

            u.Jornadas.Add(jornada);
            Jornada.Guardar(jornada);
            return u;
        }
        #endregion
        #region "Métodos"
        /// <summary>
        /// Muestra los datos de la universidad.
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns>Retorna string con los datos de la universidad</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder datosUniversidad = new StringBuilder();

            foreach(Jornada j in uni.Jornadas)
            {
                datosUniversidad.AppendLine(j.ToString());
            }
            return datosUniversidad.ToString();
        }

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        /// <summary>
        /// Guardará en el directorio donde se encuentra el ejecutable los datos de la universidad en un archivo de extencion .xml
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns>True si puedo guardar los datos, false si no lo consigue.</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            string nombre = "universidad";
            if (xml.Guardar(nombre,uni))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Lee los datos desde un archivo xml ubicado en el directorio del archivo ejecutable.
        /// </summary>
        /// <returns>Retorna un objeto del tipo Universidad con los datos del archivo deserializado</returns>
        public Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            Universidad uni;
            string nombre = "universidad";
            xml.Leer(nombre, out uni);
            return uni;
        }
        #endregion
    }

}
