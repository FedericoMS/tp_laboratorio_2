using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Clase pública SinProfesorException, que deriva de Exception
    /// </summary>
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Excepción SinProfesorException()
        /// </summary>
        public SinProfesorException() : base("No hay profesor para la clase.")
        {

        }
    }
}
