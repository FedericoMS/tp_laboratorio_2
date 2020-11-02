using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    /// <summary>
    /// Clase abstracta Universitario, que deriva de Persona
    /// </summary>
    public abstract class Universitario : Persona
    {
        #region Atributos
        private int legajo;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de Universitario
        /// </summary>
        public Universitario() : base()
        {

        }

        /// <summary>
        /// Constructor parametrizado de Universitario
        /// </summary>
        /// <param name="legajo"> de tipo int </param>
        /// <param name="nombre"> de tipo string </param>
        /// <param name="apellido"> de tipo string </param>
        /// <param name="dni"> de tipo string </param>
        /// <param name="nacionalidad"> de tipo ENacionalidad </param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga del ==
        /// </summary>
        /// <param name="pg1"> de tipo Universitario </param>
        /// <param name="pg2"> de tipo Universitario </param>
        /// <returns> un bool </returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo;
        }

        /// <summary>
        /// Sobrecarga del !=
        /// </summary>
        /// <param name="pg1"> de tipo Universitario </param>
        /// <param name="pg2"> de tipo Universitario </param>
        /// <returns> un booleano </returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion

        #region Métodos
        /// <summary>
        /// Método virtual que retorna los datos completos del universitario
        /// </summary>
        /// <returns> un string </returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"LEGAJO NÚMERO: {this.legajo}");

            return sb.ToString();
        }
        /// <summary>
        /// Método abstracto 
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Sobreescritura del Equals
        /// </summary>
        /// <param name="obj"> de tipo object </param>
        /// <returns >un booleano </returns>
        public override bool Equals(object obj)
        {
            bool rta = false;
            if(obj is Universitario)
            {
                rta = this == (Universitario)obj;
            }
            return rta;
        }
        #endregion
    }
}
