using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class EspectaculoException : Exception
    {
        public EspectaculoException(string message) : base(message)
        {
        }

        public EspectaculoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
