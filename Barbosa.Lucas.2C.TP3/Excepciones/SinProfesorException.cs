using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        public SinProfesorException()
        {
            
        }

        public SinProfesorException(string message) : base(message)
        {
        }
    }
}
