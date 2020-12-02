using System;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void CuandoUnBomberoSeGuardaDeberiaSerElMismoCuandoSeLee()
        {
            //Arrange
            Bombero b = new Bombero("Lucas");
            Bombero b2 = null;
            //Act
            b.Guardar(b);
            b2 = b.Leer();

            //Assert
            Assert.IsInstanceOfType(b2, typeof(Bombero));     
        }

        [TestMethod]
        public void ElMetodoDeExtencionDiferenciaEnMinutosDeDateTimeDeberiaRetornarLaDiferenciaEntreLosHorarios()
        {
            DateTime inicio = DateTime.Now;
            DateTime fin = DateTime.Now.AddMinutes(20);

            Assert.AreEqual(inicio.DiferenciaEnMinutos(fin), 20);
        }
    }
}
