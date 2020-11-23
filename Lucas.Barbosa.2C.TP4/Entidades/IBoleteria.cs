using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Cree una interfaz que establezca los métodos que tienen que tener una boletería sea del tipo que sea.
    /// </summary>
    /// <typeparam name="T">Tipo Entrada</typeparam>
    interface IBoleteria<T> where T : Entrada
    {
        string InformeEntradas();

        bool ConfirmarEntrada(T e);
        string ImprimirEntradaBreve(T e);
    }
}
