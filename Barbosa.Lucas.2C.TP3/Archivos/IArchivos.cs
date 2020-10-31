using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    interface IArchivos <T>
    {
        bool Guardar(string archivo, T obj);

        T Leer(string archivo, out T datos);
    }
}
