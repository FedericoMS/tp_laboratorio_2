using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    /// <summary>
    /// Clase pública Txt, que implementa la interfaz IArchivo
    /// </summary>
    public class Txt : IArchivo<string>
    {
        #region Métodos
        /// <summary>
        /// Método de instancia que guarda un archivo en formato txt.
        /// Implementación de archivos de texto (tema requerido por la consigna del TP Nº4)
        /// </summary>
        /// <param name="archivo"> un path, de tipo string </param>
        /// <param name="informacion"> un string </param>
        /// <returns> un bool </returns>
        public bool Guardar(string archivo, string informacion)
        {
            bool rta = false;
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo, true))  
                {
                    writer.WriteLine(informacion);
                    rta = true;
                }
            }
            catch (Exception Ex)
            {
                throw new ArchivosException("Error. No se pudo guardar el archivo.", Ex);
            }


            return rta;
        }

        /// <summary>
        /// Método de instancia que lee archivos de texto
        /// </summary>
        /// <param name="archivo">un path, de tipo string</param>
        /// <param name="informacion"> un string </param>
        /// <returns> un bool </returns>
        public bool Leer(string archivo, out string informacion)
        {
            bool rta = false;
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    informacion = reader.ReadToEnd();
                    rta = true;
                }
            }
            catch (Exception Ex)
            {
                informacion = null;
                throw new ArchivosException("Error. No se pudo leer el archivo", Ex);
            }

            return rta;
        }
        #endregion
    }
}

