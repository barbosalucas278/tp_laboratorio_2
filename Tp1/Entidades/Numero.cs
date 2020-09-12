using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        public string SetNumero
        {
            set
            {
                double numeroValidado = ValidarNumero(value);
                this.numero = numeroValidado;
            }
        }
        private double ValidarNumero(string strNumero)
        {
            double numeroVerificado;
            if (strNumero.Contains("."))
            {
                string strNumeroSinPunto = strNumero.Substring(0, strNumero.LastIndexOf('.'));
                if(double.TryParse(strNumeroSinPunto, out numeroVerificado)){
                    return numeroVerificado;
                }
            }
            else
            {
                if (double.TryParse(strNumero, out numeroVerificado))
                {
                    return numeroVerificado;
                }
            }
            return 0;
        }
        private bool EsBinario(string binario)
        {
            if(!string.IsNullOrWhiteSpace(binario))
            {
                for(int i = 0; i < binario.Length; i++)
                {
                    if(binario[i] == '0' || binario[i] == '1')
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public string BinarioDecimal(string binario)
        {
            if (EsBinario(binario))
            {
                int numeroDecimal = 0;
                int cifra;
                int exponente = binario.Length;
                int j = binario.Length - 1;
                for (int i = 0; i < exponente; i++)
                {
                    if (binario[j].Equals('1'))
                    {
                        cifra = (int)Math.Pow(2, i);
                    }
                    else
                    {
                        cifra = 0;
                    }
                    j--;
                    numeroDecimal += cifra;
                }
                return numeroDecimal.ToString();
            }else{
                return "Valor inválido";
            }
        }

        public string DecimalBinario(double numero)
        {
            string numeroBinario = string.Empty;
            int enteroPositivo = (int)numero;
            if (numero >= 0)
            {
                if (enteroPositivo == 0)
                {
                    numeroBinario= "0" + numeroBinario;
                }
                else
                {
                    while (enteroPositivo > 0)
                    {
                        if (enteroPositivo % 2 == 0)
                        {
                            numeroBinario = "0" + numeroBinario;
                        }
                        else if (enteroPositivo % 2 == 1)
                        {
                            numeroBinario = "1" + numeroBinario;
                        }
                        enteroPositivo /= 2;
                    }
                }

                return numeroBinario.ToString();
            }
            return "Numero inválido";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(string numero)
        {
            double enteroPositivo;
            if(double.TryParse(numero,out enteroPositivo))
            {
                return this.DecimalBinario(enteroPositivo);
            }
            return "Número inválido";
        }

        /// <summary>
        /// Resta entre dos números, n2 sustrae a n1.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>La resta entre ambos.</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Multiplicación entre dos numeros
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>El resultado de la multiplicación</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n1.numero;
        }
        /// <summary>
        /// Suma dos números.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>La suma de ambos.</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        ///  Divide dos numeros.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>El cociente como resultado</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if(n2.numero != 0)
            {
                return Math.Round(n1.numero / n2.numero,2);
            }
            return double.MinValue;
        }
    }
}
