using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MetodosDeExtension;
using Entidades;
using Excepciones;

namespace UnitTest
{
    [TestClass]
    public class TestUnitarios
    {
        [TestMethod]
        public void DoubleMetodoExtensionDeberiaRetornarElPrecioDelArticuloConElAumento()
        {
            double costo = 100;
            double ganancia = 30;
            double precio;

            precio = costo.CalcularPrecio(ganancia);

            Assert.AreEqual(precio, 130);
        }

        [TestMethod]
        [ExpectedException(typeof(EspectaculoException))]
        public void ElPrecioDeUnEspectaculoDebeSerMayorACero()
        {
            Espectaculo e = new Espectaculo("test", "test", new DateTime(2020, 12, 20, 10, 10, 10), 2, -1);

        }
    }
}
