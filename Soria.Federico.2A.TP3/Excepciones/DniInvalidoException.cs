using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Excepción DniInvalidoException()
        /// </summary>
        public DniInvalidoException() : base("Ha ocurrido un error.")
        {

        }

        /// <summary>
        /// Excepción DniInvalidoException() parametrizado
        /// </summary>
        /// <param name="e"> de tipo exception </param>
        public DniInvalidoException(Exception e) : base(e.Message)
        {

        }

        /// <summary>
        /// Excepción DniInvalidoException() parametrizado
        /// </summary>
        /// <param name="message"> de tipo string </param>
        public DniInvalidoException(string message) : base(message)
        {

        }

        /// <summary>
        /// Excepción DniInvalidoException() parametrizado
        /// </summary>
        /// <param name="message"> de tipo string </param>
        /// <param name="e"> de tipo Exception </param>
        public DniInvalidoException(string message, Exception e) : base(message, e)
        {

        }
    }
}
