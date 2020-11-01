using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using EntidadesAbstractas;
using Archivos;
using Excepciones;

namespace Test_Unitarios_TP3
{
    [TestClass]
    public class Tests_TP3
    {
        #region Tests Unitarios
        /// <summary>
        /// Testea los atributos de tipo colección en Universidad
        /// </summary>
        [TestMethod]
        public void VerificarAtributoColeccionEnUniversidad_Ok()
        {
            Universidad college = new Universidad();

            Assert.IsNotNull(college.Jornadas);
            Assert.IsNotNull(college.Instructores);
            Assert.IsNotNull(college.Alumnos);

        }

        /// <summary>
        /// Testea el atributo de tipo colección que posee Jornada
        /// </summary>
        [TestMethod]
        public void VerificarAtributoColeccionEnJornada_Ok()
        {
            Jornada Workday = new Jornada(Universidad.EClases.Laboratorio, new Profesor());

            Assert.IsNotNull(Workday.Alumnos);
        }

        /// <summary>
        /// Verifica si se lanza la excepción de tipo DniInvalidoException cuando se intenta cargar un objeto Alumno con un dni no válido
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void VerificarExcepcionDNIInvalido()
        {
            Alumno a10 = new Alumno(123456, "Jorge", "Perez", "5942862489465", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
        }

        /// <summary>
        /// Verifica si se lanza la excepción de tipo AlumnoRepetidoException cuando se intentan agregar dos alumnos iguales a una universidad
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void VerificarAlumnoRepetidoException()
        {
            Universidad college = new Universidad();
            Alumno a1 = new Alumno(123456, "Jorge", "Perez", "33333333", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            Alumno a2 = new Alumno(123456, "Jorge", "Perez", "33333333", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            college += a1;
            college += a2;

        }

        /// <summary>
        /// Verifica si se lanza la excepcíón de tipo NacionalidadInvalidaException cuando se carga un Alumno con una Nacionalidad que no condice con su DNI
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void VerificarExcepcionNacionalidadInvalida()
        {
            Alumno a10 = new Alumno(123456, "Juan", "Perez", "98888888", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
        }

        #endregion
    }
}
