using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Clase pública AlumnoRepetidoException, que deriva de Exception
    /// </summary>
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Excepción AlumnoRepetidoException
        /// </summary>
        public AlumnoRepetidoException() : base("Alumno repetido.")
        {

        }
    }
}
