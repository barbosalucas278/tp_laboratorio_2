using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida que el operador ingresado sea correcto.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>Si el operador es válido, operador analizado. Si es inválido devuelve "+" como operador.</returns>
        private static string ValidarOperador(string operador)
        {
            if (!string.IsNullOrWhiteSpace(operador))
            {
                if(operador == "+" || operador == "-" || operador == "/" || operador == "*")
                {
                    return operador;
                }
                
            }
            return "+";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Numero numero1, Numero numero2, string operador)
        {
            string operadorValido = ValidarOperador(operador);

            switch (operadorValido)
            {
                case "+":
                    return numero1 + numero2;
                case "-":
                    return numero1 - numero2;
                case "/":
                    return numero1 / numero2;
                case "*":
                    return numero1 * numero2;
            }
            return -1;
        }

        
    }


}
