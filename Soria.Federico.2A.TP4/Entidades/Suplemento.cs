using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Archivos;

namespace Entidades
{
    
    /// <summary>
    /// Clase pública Suplemento, derivada de Producto
    /// </summary>
    public class Suplemento : Producto
    {

        #region Atributos

        protected string tipo;
        protected string formato;
        protected string empaque;

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de Suplemento
        /// </summary>
        public Suplemento() : base()
        {

        }
        /// <summary>
        /// Constructor parametrizado de suplemento 
        /// </summary>
        /// <param name="id"> de tipo int </param>
        /// <param name="nombre"> de tipo string </param>
        /// <param name="tipo"> de tipo string </param>
        /// <param name="precio"> de tipo float </param>
        /// <param name="formato"> de tipo string </param>
        /// <param name="empaque"> de tipo string </param>
        public Suplemento(int id, string nombre, string tipo, float precio, string formato, string empaque) : base(id, nombre, precio)
        {
            this.tipo = tipo;
            this.formato = formato;
            this.empaque = empaque;
        }

        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de lectura y escritura de Tipo
        /// </summary>
        public string Tipo
        {
            get
            {
                return this.tipo;
            }

            set
            {
                this.tipo = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura de Empaque
        /// </summary>
        public string Empaque
        {
            get
            {
                return this.empaque;
            }

            set
            {
                this.empaque = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura de Formato
        /// </summary>
        public string Formato
        {
            get
            {
                return this.formato;
            }

            set
            {
                this.formato = value;
            }
        }

        #endregion

        #region Métodos
        /// <summary>
        /// Sobreescritura del método ToString(), que devuelve un string con los datos del suplemento
        /// </summary>
        /// <returns> un string </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Tipo de suplemento: {this.tipo}");
            sb.AppendLine($"El formato del suplemento es: {this.formato}");
            sb.AppendLine($"El empaque del suplemento es: {this.empaque}");

            return sb.ToString();
        }


        #endregion


    }
}
