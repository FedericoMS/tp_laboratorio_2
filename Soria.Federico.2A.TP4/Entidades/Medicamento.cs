using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Entidades
{
    /// <summary>
    /// Clase pública Medicamento, derivada de Producto
    /// </summary>
    public class Medicamento : Producto
    {
        #region Atributos

        protected string tipo;
        protected string marca;
        protected string origen;

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de Medicamento
        /// </summary>
        public Medicamento() : base()
        {

        }

        /// <summary>
        /// Constructor parametrizado de Medicamento 
        /// </summary>
        /// <param name="id"> de tipo int </param>
        /// <param name="nombre"> de tipo string </param>
        /// <param name="tipo"> de tipo string </param>
        /// <param name="precio"> de tipo float </param>
        public Medicamento(int id, string nombre,  string tipo, float precio, string marca, string origen) : base(id, nombre, precio)
        {
            this.tipo = tipo;
            this.marca = marca;
            this.origen = origen;
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
        /// Propiedad de lectura y escritura de Marca
        /// </summary>
        public string Marca
        {
            get
            {
                return this.marca;
            }

            set
            {
                this.marca = value;
            }
        }

        /// <summary>
        /// Propiedad de lecutra y escritura de Origen
        /// </summary>
        public string Origen
        {
            get
            {
                return this.origen;
            }

            set
            {
                this.origen = value;
            }
        }

        #endregion

        #region Métodos
        /// <summary>
        /// Sobreescritura del ToString(), que retorna un string con los datos del medicamento
        /// </summary>
        /// <returns> un string </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Tipo de medicamento: {this.tipo}");
            sb.AppendLine($"Marca de medicamento: {this.marca}");
            sb.AppendLine($"Origen del medicamento: {this.origen}");

            return sb.ToString();
        }


        #endregion


    }
}
