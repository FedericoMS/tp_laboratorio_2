using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using static Clases_Instanciables.Universidad;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {

        #region Atributos
        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de Alumno
        /// </summary>
        public Alumno() : base()
        {

        }

        /// <summary>
        /// Constructor parametrizado de Alumno
        /// </summary>
        /// <param name="id"> de tipo int </param>
        /// <param name="nombre"> de tipo string </param>
        /// <param name="apellido"> de tipo string </param>
        /// <param name="dni"> de tipo string </param>
        /// <param name="nacionalidad"> de tipo ENacionalidad</param>
        /// <param name="claseQueToma"> de tipo EClases </param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor parametrizado de Alumno 
        /// </summary>
        /// <param name="id"> de tipo int </param>
        /// <param name="nombre"> de tipo string </param>
        /// <param name="apellido"> de tipo string </param>
        /// <param name="dni"> de tipo string </param>
        /// <param name="nacionalidad"> de tipo ENacionalidad </param>
        /// <param name="claseQueToma"> de tipo EClases </param>
        /// <param name="estadoCuenta"> de tipo EEstadoCuenta </param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Enumerados
        /// <summary>
        /// Enumerado EEstadoCuenta
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del == 
        /// </summary>
        /// <param name="a"> de tipo alumno </param>
        /// <param name="clase"> de tipo EClases </param>
        /// <returns> un booleano </returns>
        public static bool operator ==(Alumno a, EClases clase)
        {
            return a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor;
        }

        /// <summary>
        /// Sobrecarga del !=
        /// </summary>
        /// <param name="a"> de tipo Alumno </param>
        /// <param name="clase"> de tipo EClases </param>
        /// <returns> un booleano </returns>
        public static bool operator !=(Alumno a, EClases clase)
        {
            return a.claseQueToma != clase;
        }

        #endregion

        #region Métodos
        /// <summary>
        /// Sobreescritura de MostrarDatos que retorna un string con los datos completos del Alumno
        /// </summary>
        /// <returns> un string </returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta}");
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Sobreescritura de ParticiparEnClase que retorna la clase que toma el alumno
        /// </summary>
        /// <returns> un string </returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"TOMA CLASES DE {this.claseQueToma}");

            return sb.ToString();
        }

        /// <summary>
        /// Sobreescritura del método ToString()
        /// </summary>
        /// <returns> un string </returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

    }
}
