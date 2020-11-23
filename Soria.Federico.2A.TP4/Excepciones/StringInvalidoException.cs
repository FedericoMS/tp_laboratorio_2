using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Clase pública StringInvalidoException, que deriva de Exception
    /// Excepciones (tema requerido por la consigna del TP Nº4)
    /// </summary>
    public class StringInvalidoException : Exception
    {
        #region Constructores
        /// <summary>
        /// Constructor de StringInvalidoException, que recibe como parámetro un string
        /// </summary>
        /// <param name="message"> de tipo string </param>
        public StringInvalidoException(string message) : base(message)
        {

        }

        #endregion
    }
}
