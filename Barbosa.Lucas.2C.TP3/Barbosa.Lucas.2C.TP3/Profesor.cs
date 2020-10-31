using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Profesor : Universitario
    {
        #region "Atributos"

        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion
        #region "Constructores"

        static Profesor()
        {
            random = new Random();
        }
        public Profesor()
        {
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this.RandomClases(2);
        }
        #endregion
        #region "Métodos"

        protected override string MostrarDatos()
        {
            StringBuilder datosProfesor = new StringBuilder();

            datosProfesor.AppendLine(base.MostrarDatos());
            datosProfesor.AppendLine(this.ParticiparEnClase());

            return datosProfesor.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder datosClases = new StringBuilder();
            datosClases.AppendLine($"CLASES DEL DIA");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                datosClases.AppendLine($"{clase}");
            }
            return datosClases.ToString();
        }

        private void RandomClases(int cantidadDeClases)
        {
            int clase = random.Next(1, 4);
            while(this.clasesDelDia.Count < cantidadDeClases){
                switch (clase)
                {
                    case 1:
                        clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                        break;
                    case 2:
                        clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                        break;
                    case 3:
                        clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                        break;
                    case 4:
                        clasesDelDia.Enqueue(Universidad.EClases.SPD);
                        break;
                }
            }
        }
        #endregion
        #region "Operadores"

        public static bool operator ==(Profesor p, Universidad.EClases tipo)
        {
            foreach(Universidad.EClases clase in p.clasesDelDia)
            {
                if(clase == tipo)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Profesor p, Universidad.EClases tipo)
        {
            return !(p == tipo);
        }
        #endregion
    }
}
