using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    /// <summary>
    /// Clase Sedan heredada de Vehiculo
    /// </summary>
    public class Sedan : Vehiculo
    {
        
        #region "Atributos"
        ETipo tipo;
        #endregion

        #region "Enumerados"
        /// <summary>
        /// Enumerado Etipo que contiene "CuatroPuertas" y "CincoPuertas"
        /// </summary>
        public enum ETipo
        {
            CuatroPuertas,
            CincoPuertas
        }
        #endregion

        #region "Constructores"
        /// <summary>
        /// Por defecto, TIPO será Cuatropuertas
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color) : base(marca, chasis, color)
        {
            tipo = ETipo.CuatroPuertas;
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo) : base(marca, chasis, color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Override de Mostrar para los datos de Sedan
        /// </summary>
        /// <returns> Un String </returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine($"TIPO : {this.tipo}");
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion

    }
}
