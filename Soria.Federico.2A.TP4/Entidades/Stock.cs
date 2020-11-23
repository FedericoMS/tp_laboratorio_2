using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Archivos;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    /// <summary>
    /// Clase pública Stock
    /// </summary>
    public class Stock
    {
        #region Atributos

        protected List<Producto> deposito;

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de stock
        /// </summary>
        public Stock()
        {
            deposito = new List<Producto>();
        }

        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de lectura y escritura de Deposito
        /// </summary>
        public List<Producto> Deposito
        {
            get
            {
                return this.deposito;
            }
            set
            {
                this.deposito = value;
            }
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del operador + de Stock, permitiendo agregar un producto p a un Stock<T>
        /// </summary>
        /// <param name="dep"> de tipo Stock<T> </param>
        /// <param name="p"> de tipo Producto</param>
        /// <returns> un Stock<T> </returns>
        public static Stock operator +(Stock dep, Producto p)
        {
            dep.deposito.Add(p);
            return dep;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Sobreescritura del ToString(), que devuelve un string con los datos de los productos en el stock
        /// </summary>
        /// <returns> un string </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-----------------");
            sb.AppendLine("LISTA DE PRODUCTOS EN EL STOCK");
            sb.AppendLine("-----------------");
            foreach (Producto item in this.deposito)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("-----------------");
            return sb.ToString();
        }
       
        /// <summary>
        /// Método estático guardar, que guarda un archivo XML con los datos de Stock
        /// </summary>
        /// <param name="storage"> de tipo Stock </param>
        /// <returns> un booleano </returns>
        public static bool GuardarXml(Stock storage, string nombre)
        {
              bool rta = false;
              Xml<Stock> archive = new Xml<Stock>();
              rta = archive.Guardar(nombre, storage);

              return rta;
        }

        #endregion


    }
}
