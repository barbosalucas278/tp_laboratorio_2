using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IArchivos<X> 
        where X : class
    {
        void Guardar(X info);
        X Leer();
    }
}
