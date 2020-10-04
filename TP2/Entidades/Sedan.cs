using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        public enum ETipo { CuatroPuertas, CincoPuertas }
        private ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será Monovolumen
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }

        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo) : this(marca, chasis, color)
        {
            this.tipo = tipo;
        }
        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}TIPO : {this.tipo}\n");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
