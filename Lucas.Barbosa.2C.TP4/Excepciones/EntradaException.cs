using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class EntradaException : Exception
    {
        public EntradaException(string message) : base(message)
        {
        }

        public EntradaException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
