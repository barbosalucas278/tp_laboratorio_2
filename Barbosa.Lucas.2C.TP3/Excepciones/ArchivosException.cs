using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        #region "Constructores"

        public ArchivosException(Exception innerException): base("Ha ocurrido un error con el archivo al que desea acceder",innerException)
        {

        }
        #endregion
    }
}
