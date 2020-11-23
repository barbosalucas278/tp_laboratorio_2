using Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Espectaculo obra = new Espectaculo("Chicago", "Una onbra con mucho jazz", new DateTime(2020, 11, 22, 20, 30, 32), 1, 200.5);
            Sala sala1 = new Sala(1);
            List<Sala> salas = new List<Sala>();
            List<Espectaculo> espectaculos = new List<Espectaculo>();
            salas.Add(sala1);
            espectaculos.Add(obra);

            Boleteria<EntradaVentanilla> boleteria1 = new Boleteria<EntradaVentanilla>(salas,espectaculos);

            string butacaLibre = boleteria1.BuscarButacaLibre(boleteria1.Espectaculos[0]);

            Console.WriteLine($"La butaca libre es {butacaLibre}");
            Console.ReadKey();
        }
    }
}
