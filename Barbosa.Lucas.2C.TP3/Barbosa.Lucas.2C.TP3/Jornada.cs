using Archivos;
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
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
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

        public static bool operator !=(Jornada j, Alumno n)
        {
            return !(j == n);
        }

        public static Jornada operator +(Jornada j, Alumno n)
        {
            if(j != n)
            {
                j.Alumnos.Add(n);
            }
            return j;
        }

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

        public static bool Guardar(Jornada jornada)
        {
            Texto txt = new Texto();
            string nombre = "jornadas";
            if (txt.Guardar(nombre, jornada.ToString()))
            {
                return true;
            }
            return false;
        }

        public static string Leer()
        {
            Texto txt = new Texto();
            string nombre = "jornadas";
            string salida = string.Empty;

            txt.Leer(nombre, out salida);

            return salida;
        }
    }
}
