using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Clase pública PrecioInvalidoException, que deriva de Exception
    /// Excepciones (tema requerido por la consigna del TP Nº4)
    /// </summary>
    public class PrecioInvalidoException : Exception
    {
        /// <summary>
        /// Constructor de PrecioInvalidoException, que recibe como parámetro un string
        /// </summary>
        /// <param name="message"></param>
        public PrecioInvalidoException(string message) : base(message)
        {

        }
    }
}
