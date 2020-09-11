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
        private static string ValidarOperador(string operador)
        {
            if (!string.IsNullOrWhiteSpace(operador))
            {
                if(operador == "+" || operador == "-" || operador == "/" || operador == "*")
                {
                    return operador;
                }
                else
                {
                    return "+";
                }
            }
            return "+";
        }
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
