using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;
namespace Archivos
{   
    /// <summary>
    /// Clase pública Xml<T> genérica, que implementa la interfaz IArchivo
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Método de instancia Guardar, para guardar un archivo XML
        /// Implementación de Generics y Serialización (tema requerido por la consigna del TP Nº4)
        /// </summary>
        /// <param name="archivo"> un string </param>
        /// <param name="datos"> un tipo T genérico </param>
        /// <returns> un booleano </returns>
        public bool Guardar(string archivo, T datos)
        {
            bool rta = false;
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, System.Text.Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(writer, datos);
                    rta = true;
                }
            }
            catch (Exception Ex)
            {
                throw new ArchivosException("No se pudo guardar el archivo\n", Ex);
            }
            return rta;
        }

        /// <summary>
        /// Método de instancia Leer, para leer un archivo XML
        /// </summary>
        /// <param name="archivo"> de tipo string </param>
        /// <param name="datos"> de tipo T genérico </param>
        /// <returns> un bool </returns>
        public bool Leer(string archivo, out T datos)
        {
            bool rta = false;
            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    datos = (T)ser.Deserialize(reader);
                    rta = true;

                }
            }
            catch (Exception Ex)
            {
                throw new ArchivosException("No se pudo leer el archivo\n", Ex);
            }
            return rta;
        }
    }
}
