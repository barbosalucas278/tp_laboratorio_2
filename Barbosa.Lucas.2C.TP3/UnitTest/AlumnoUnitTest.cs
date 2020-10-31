using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class AlumnoUnitTest
    {
        [TestMethod]
        public void UnAlumnoSeraIgualAUnEClaseSiTomaEsaClaseYNoEsDeudor()
        {
            //Arrange
            Alumno alumno = new Alumno(1, "Juan", "Lopez", "12234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
            bool resultado;
            //Act
            resultado = alumno == Universidad.EClases.Programacion;
            //Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void AlumnodeberiaSerDistintoAEClaseSoloSiNoTomaEsaClase()
        {
            //Arrange
            Alumno a = new Alumno(1, "Juan", "Lopez", "12234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio,
            Alumno.EEstadoCuenta.Becado);
            bool resultado;
            //Act
            resultado = a != Universidad.EClases.Programacion;
            //Assert
            Assert.IsTrue(resultado);
        }
    }
}
