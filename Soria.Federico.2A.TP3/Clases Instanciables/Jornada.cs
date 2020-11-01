using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Clases_Instanciables.Universidad;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de Jornada
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor parametrizado de Jornada
        /// </summary>
        /// <param name="clase"> de tipo EClases </param>
        /// <param name="instructor"> de tipo Profesor </param>
        public Jornada(EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad getter y setter de List<Alumno>
        /// </summary>
        public List<Alumno> Alumnos
        {
            get 
            {
                return this.alumnos; 
            }

            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Propiedad getter y setter de EClases
        /// </summary>
        public EClases Clase
        {
            get
            {
                return this.clase;
            }

            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Propiedad getter y setter de Profesor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }

            set
            {
                this.instructor = value;
            }
        }


        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del ==
        /// </summary>
        /// <param name="j"> de tipo Jornada </param>
        /// <param name="a"> de tipo Alumno </param>
        /// <returns> un bool </returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return a == j.clase;
        }

        /// <summary>
        /// Sobrecarga del !=
        /// </summary>
        /// <param name="j"> de tipo Jornada </param>
        /// <param name="a"> de tipo Alumno </param>
        /// <returns> un bool </returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a la Jornada J si es que este ya no existe previamente
        /// </summary>
        /// <param name="j"> de tipo Jornada </param>
        /// <param name="a"> de tipo Alumno </param>
        /// <returns> una Jornada </returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            bool rta = true;
            foreach(Alumno student in j.alumnos)
            {
                if(student.Equals(a))
                {
                    rta = false;
                    break;
                }
            }
            if(rta)
            {
                j.alumnos.Add(a);
            }
            return j;
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Sobrescritura del ToString()
        /// </summary>
        /// <returns> un string </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");
            sb.AppendLine($"CLASE DE {this.clase} POR {this.instructor.ToString()}");
            sb.AppendLine($"ALUMNOS:");
            foreach(Alumno student in this.alumnos)
            {
                sb.AppendLine(student.ToString());
            }
            sb.AppendLine("<------------------------------>");
            return sb.ToString();
        }

        /// <summary>
        /// Método estático Guardar para guardar los datos de la jornada en un txt
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns> un booleano </returns>
        public static bool Guardar(Jornada jornada)
        {
            bool rta = false;
            Texto archive = new Texto();
            rta = archive.Guardar("Jornada.txt", jornada.ToString());

            return rta;

        }

        /// <summary>
        /// Método estático Leer para leer los datos de la Jornada guardados en un txt
        /// </summary>
        /// <returns> un string </returns>
        public static string Leer()
        {
            Texto archive = new Texto();
            string cadena;
            archive.Leer("Jornada.txt", out cadena);
            
            return cadena;
        }
        #endregion

    }






}
