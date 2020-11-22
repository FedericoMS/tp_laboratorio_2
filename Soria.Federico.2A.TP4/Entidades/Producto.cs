using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
    [System.Xml.Serialization.XmlInclude(typeof(Suplemento))]
    [System.Xml.Serialization.XmlInclude(typeof(Medicamento))]
    /// <summary>
    /// Clase abstracta y pública Producto
    /// </summary>
    public abstract class Producto
    {

        #region Atributos
        protected int id;
        protected string nombre;
        protected float precio;
        #endregion

        #region Contructores
        /// <summary>
        /// Constructor por defecto de Producto
        /// </summary>
        public Producto()
        {

        }

        /// <summary>
        /// Constructor parametrizado de Producto
        /// </summary>
        /// <param name="id"> de tipo int </param>
        /// <param name="nombre"> de tipo string </param>
        /// <param name="precio"> de tipo float </param>
        public Producto(int id, string nombre, float precio)
        {
            this.id = id;
            this.Nombre = nombre;
            this.Precio = precio;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de escritura y lectura de ID
        /// </summary>
        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura de Nombre, que contiene una validación en su Set
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {

                if(this.ValidarNombreProducto(value) != "")
                {
                    this.nombre = value;
                }
                else
                {
                    throw new StringInvalidoException("Error. El string ingresado es inválido");
                }
                
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura de Precio, que establece una validación en su Set
        /// </summary>
        public float Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                if (value > 0)
                {
                    this.precio = value;
                }
                else
                {
                    throw new PrecioInvalidoException("Error. El precio cargado es menor a 0");
                }
            }
        }


        #endregion

        #region Métodos
        /// <summary>
        /// Sobreescritura del método ToString(), que devuelve un string con los datos del producto 
        /// </summary>
        /// <returns> un string </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID: {this.id}");
            sb.AppendLine($"Nombre: {this.nombre}");
            sb.AppendLine($"Precio: {this.precio}");

            return sb.ToString();
        }
        #endregion

    }
}
