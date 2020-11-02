using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
namespace Archivos
{
    /// <summary>
    /// Clase pública Texto para Archivos de texto, que implementa la interfaz IArchivo
    /// </summary>
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Método de instancia Guardar, para guardar un archivo de texto 
        /// </summary>
        /// <param name="archivo"> de tipo string </param>
        /// <param name="datos"> de tipo string </param>
        /// <returns> un bool </returns>
        public bool Guardar(string archivo, string datos)
        {
            bool rta = false;
            Encoding codificacion = Encoding.UTF8;
            try
            {
                using(StreamWriter sw = new StreamWriter(archivo, false, codificacion))
                {
                    sw.WriteLine(datos);
                    rta = true;
                }
            }

            catch(Exception e)
            {
                throw new ArchivosException(e);
            }

            return rta;
        }

        /// <summary>
        ///  Método de instancia Leer, para leer un archivo de texto
        /// </summary>
        /// <param name="archivo"> de tipo string </param>
        /// <param name="datos"> de tipo string </param>
        /// <returns> un bool </returns>
        public bool Leer(string archivo, out string datos)
        {
            bool rta = false;
            Encoding codificacion = Encoding.UTF8;
            try
            {
                using (StreamReader sr = new StreamReader(archivo, codificacion))
                {
                    datos = sr.ReadToEnd();
                    rta = true;
                }
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }

            return rta;
        }
    }
}
