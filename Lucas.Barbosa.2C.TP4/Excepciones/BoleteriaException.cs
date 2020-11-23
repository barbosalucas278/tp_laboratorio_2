using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class BoleteriaException : Exception
    {
        public BoleteriaException(string message) : base(message)
        {
        }

        public BoleteriaException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
