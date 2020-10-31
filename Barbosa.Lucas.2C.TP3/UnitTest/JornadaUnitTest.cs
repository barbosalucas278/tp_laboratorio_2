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
    public class JornadaUnitTest
    {
        [TestMethod]
        public void JornadaDeberiaSerIgualAUnAlumnoSiEsteParticipaDeLaClase()
        {
            //Arrange
            Jornada jornada = new Jornada(Universidad.EClases.Laboratorio, new Profesor());
            Alumno alumno = new Alumno(1, "Juan", "Lopez", "12234456",
             EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio,
             Alumno.EEstadoCuenta.Becado);
            bool resultado;

            //Act
            jornada += alumno;
            resultado = jornada == alumno;

            //Assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void UnAlumnonoDeberiaAgregarseAUnaJornadaSiEstaYaExiste()
        {
            //Arrange
            Jornada jornada = new Jornada(Universidad.EClases.Laboratorio, new Profesor());
            Alumno alumno = new Alumno(1, "Juan", "Lopez", "12234456",
             EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio,
             Alumno.EEstadoCuenta.Becado);
            Alumno alumno2 = new Alumno(1, "Juan", "Lopez", "12234456",
             EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio,
             Alumno.EEstadoCuenta.Becado);

            //Act
            jornada += alumno;
            jornada += alumno2;

            //Assert
            Assert.AreEqual(jornada.Alumnos.Count, 1);
        }
    }
}
