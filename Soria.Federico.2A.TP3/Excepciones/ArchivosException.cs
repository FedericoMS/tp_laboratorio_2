using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Clase pública ArchivosException, que deriva de Exception
    /// </summary>
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Excepción ArchivosException
        /// </summary>
        /// <param name="innerException"> de tipo Exception </param>
        public ArchivosException(Exception innerException) : base(innerException.Message)
        {

        }

    }
}
