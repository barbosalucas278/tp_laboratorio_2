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
        public static bool operator !=(Universidad g, Alumno n)
        {
            return !(g == n);
        }

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

        public static bool operator !=(Universidad g, Profesor p)
        {
            return !(g == p);
        }

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
        public static Universidad operator +(Universidad g, Profesor p)
        {
            if (g != p)
            {
                g.Profesores.Add(p);
            }
            return g;
        }

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
