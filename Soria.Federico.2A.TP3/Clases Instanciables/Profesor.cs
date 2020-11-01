using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Clases_Instanciables.Universidad;
using EntidadesAbstractas;
namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {

        #region Atributos
        private Queue<EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor estático de profesor
        /// </summary>
        static Profesor() //ESTE SERÍA EL PRIVADO
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Constructor por defecto de Profesor
        /// </summary>
        public Profesor() 
         {
             this.clasesDelDia = new Queue<EClases>();
             this._randomClases();
             this._randomClases();
         }


        /// <summary>
        /// Constructor parametrizado de Profesor
        /// </summary>
        /// <param name="id"> de tipo int </param>
        /// <param name="nombre"> de tipo string </param>
        /// <param name="apellido"> de tipo string </param>
        /// <param name="dni"> de tipo string </param>
        /// <param name="nacionalidad"> de tipo ENacionalidad </param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
         {
             Profesor professor = new Profesor();
             this.clasesDelDia = professor.clasesDelDia;
         }
        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga del == 
        /// </summary>
        /// <param name="i"> de tipo Profesor </param>
        /// <param name="clase"> de tipo EClase </param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            bool rta = false;
            foreach(EClases claseDelProfesor in i.clasesDelDia)
            {
                if(claseDelProfesor == clase)
                {
                    rta = true;
                }
            }
            return rta;
        }

        /// <summary>
        /// Sobrecarga del != 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Método de instancia void que encola de forma aleatoria una clase 
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((EClases)Enum.Parse(typeof(EClases), random.Next(0, 4).ToString()));
        }

        /// <summary>
        /// Sobreescritura de Mostrardatos, que devuelve un string con los datos del Profesor
        /// </summary>
        /// <returns> un string </returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();

        }

        /// <summary>
        /// Sobreescritura de ParticiparEnClase() que devuelve un string con los datos de las clases del día
        /// </summary>
        /// <returns> un string </returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA:");
            foreach(EClases clase in this.clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Sobreescritura del ToString()
        /// </summary>
        /// <returns> un string con los datos de MostrarDatos </returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }


        #endregion


    }
}
