using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Clase pública NacionalidadInvalidaException, que deriva de Exception
    /// </summary>
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Excepción NacionalidadInvalidaException
        /// </summary>
        public NacionalidadInvalidaException() : base("Ha ocurrido un error.")
        {

        }

        /// <summary>
        /// Excepción nacionalidadInvalidaException parametrizada
        /// </summary>
        /// <param name="message"> de tipo string </param>
        public NacionalidadInvalidaException(string message) : base(message)
        {

        }
    }
}
