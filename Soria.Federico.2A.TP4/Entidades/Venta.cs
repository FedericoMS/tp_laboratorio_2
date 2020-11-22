using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Excepciones;
using Archivos;

namespace Entidades
{
    /// <summary>
    /// Clase pública y genérica Venta<T>, restringida para Productos o derivados 
    /// Implementación de Generics (tema requerido por la consigna del TP Nº4)
    /// </summary>
    /// <typeparam name="T"> de tipo Producto o derivados </typeparam>
    public class Venta<T> where T : Producto
    {
        #region Atributos

        public List<Producto> listaDeCompras;
        public float precioTotal;

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de Venta<T>
        /// </summary>
        public Venta()
        {
            listaDeCompras = new List<Producto>();
        }

        /// <summary>
        /// Constructor parametrizado de Venta<T>
        /// </summary>
        /// <param name="precioTotal"> de tipo float </param>
        public Venta(float precioTotal) : this()
        {
            this.precioTotal = precioTotal;
        }
        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad de sólo lectura que retorna el precio total de una compra
        /// </summary>
        public float PrecioTotal
        {
            get
            {
                float total = 0;
                foreach(Producto prod in listaDeCompras)
                {
                    total += prod.Precio;
                }
                return total;
            }
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del operador +, que permite agregar un producto a la venta
        /// </summary>
        /// <param name="ventas"> de tipo Venta<T> </param>
        /// <param name="p"> de tipo producto </param>
        /// <returns> una venta </returns>
        public static Venta<T> operator +(Venta<T> ventas, Producto p)
        {
            ventas.listaDeCompras.Add(p);
            return ventas;
        }

        /// <summary>
        /// Método estático Guardar, que guarda en un archivo de texto la venta realizada
        /// </summary>
        /// <param name="venta"> de tipo Venta<T> </param>
        /// <returns> un bool </returns>
        public static bool Guardar(Venta<T> venta)
        {
            Txt text = new Txt();
            return text.Guardar("ventas.txt", venta.ToString());
        }

        #endregion

        #region Métodos
        /// <summary>
        /// Sobreescritura del ToString(), que devuelve los datos de la venta efectuada 
        /// </summary>
        /// <returns> un string </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("********************");
            sb.AppendLine($"Fecha y hora de la venta: {DateTime.Now.ToString()}");
            sb.AppendLine("LISTA DE VENTAS");
            sb.AppendLine("********************");
            foreach (Producto item in this.listaDeCompras)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine($"Precio total de la venta: {this.PrecioTotal}");

            return sb.ToString();
        }

        #endregion
    }
}
