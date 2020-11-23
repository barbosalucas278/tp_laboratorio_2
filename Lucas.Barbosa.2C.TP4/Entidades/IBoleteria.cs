using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    interface IBoleteria<T> where T : Entrada
    {
        string InformeEntradas();

        bool ConfirmarEntrada(T e);
        string ImprimirEntradaBreve(T e);
    }
}
