using Entidades;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class UniversidadUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void NoSeDeberiaAgregarUnaClaseSinUnProfesorQueDeEsaClase()
        {
            //Arrange
            Universidad universidad = new Universidad();

            //Act
            universidad += Universidad.EClases.Laboratorio;
        }

        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void NoDeberiaAgregarUnAlumnoSiEstaYaExiste()
        {
            //Arrange
            Universidad universidad = new Universidad();
            Alumno alumno = new Alumno(1, "Juan", "Lopez", "12234456",
             EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio,
             Alumno.EEstadoCuenta.Becado);
            Alumno alumno2 = new Alumno(1, "Juan", "Lopez", "12234456",
             EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio,
             Alumno.EEstadoCuenta.Becado);
            //Act
            universidad += alumno;
            universidad += alumno2;

        }

        [TestMethod]
        public void AtributoJornadasInstanciadoCorrectamente()
        {
            //Arrange
            Universidad uni = new Universidad();

            //Assert
            Assert.IsNotNull(uni.Jornadas);
        }
        [TestMethod]
        public void AtributoAlumnosInstanciadoCorrectamente()
        {
            //Arrange
            Universidad uni = new Universidad();

            //Assert
            Assert.IsNotNull(uni.Alumnos);
        }
        [TestMethod]
        public void AtributoProfesoresInstanciadoCorrectamente()
        {
            //Arrange
            Universidad uni = new Universidad();

            //Assert
            Assert.IsNotNull(uni.Profesores);
        }
    }
}
