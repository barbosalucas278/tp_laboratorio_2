using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException()
        {
        }

        public DniInvalidoException(Exception ex) : this("DNI invalido",ex)
        {
        }

        public DniInvalidoException(string message) : base(message)
        {
        }

        public DniInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
