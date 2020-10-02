using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase Suv heredada de Vehiculo
    /// </summary>
    public class Suv : Vehiculo
    {

        #region "Constructores"
        /// <summary>
        /// Constructor por defecto de Suv
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Suv(EMarca marca, string chasis, ConsoleColor color) : base(marca, chasis, color)
        {
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Las camionetas son grandes
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Override de Mostrar() para los datos de Suv
        /// </summary>
        /// <returns>retorna un string </returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio).AppendLine();
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
