using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Clase pública ArchivosException, derivada de Exception
    /// Excepciones (tema requerido por la consigna del TP Nº4)
    /// </summary>
    public class ArchivosException : Exception
    {
        #region Constructores
        /// <summary>
        /// Constructor de ArchivosException, que recibe como parámetro un string 
        /// </summary>
        /// <param name="message"> de tipo string </param>
        public ArchivosException(string message) : base(message)
        {

        }

        /// <summary>
        /// Constructor de ArchivosException, que recibe como parámetros un string y una innerException
        /// </summary>
        /// <param name="message"> de tipo string </param>
        /// <param name="innerException"> de tipo innerException </param>
        public ArchivosException(string message, Exception innerException) : base(message, innerException)
        {

        }

        #endregion
    }
}
