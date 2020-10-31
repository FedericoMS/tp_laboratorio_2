using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public class Universidad
    {
        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Enumerados
        /// <summary>
        /// Enumerado público EClases
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de Universidad
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
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
        /// Propiedad getter y setter de List<Profesor>
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Propiedad getter y setter de List<Jornada>
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// Indexador de Jornada
        /// </summary>
        /// <param name="i"> de tipo int</param>
        public Jornada this[int i]
        {
            get
            {
                return jornada[i];
            }

            set
            {
                jornada[i] = value;
            }
        }


        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del == 
        /// </summary>
        /// <param name="g"> de tipo Universidad </param>
        /// <param name="a"> de tipo Alumno </param>
        /// <returns> un booleano </returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool rta = false;
            foreach(Alumno student in g.alumnos)
            {
                if(student.Equals(a))
                {
                    rta = true;
                    break;
                }
            }
            return rta;
        }

        /// <summary>
        /// Sobrecarga del !=
        /// </summary>
        /// <param name="g"> de tipo Universidad </param>
        /// <param name="a"> de tipo Alumno </param>
        /// <returns> un booleano </returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Sobrecarga del ==
        /// </summary>
        /// <param name="g"> de tipo Universidad </param>
        /// <param name="i"> de tipo Profesor </param>
        /// <returns> un bool </returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool rta = false;
            foreach (Profesor professor in g.Instructores)
            {
                if (professor.Equals(i))
                {
                    rta = true;
                    break;
                }
            }
            return rta;
        }

        /// <summary>
        /// Sobrecarga del !=
        /// </summary>
        /// <param name="g"> de tipo Universidad </param>
        /// <param name="i"> de tipo Profesor </param>
        /// <returns> un bool </returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }


        /// <summary>
        /// Sobrecarga del ==
        /// </summary>
        /// <param name="g"> de tipo Universidad </param>
        /// <param name="clase"> de tipo EClase </param>
        /// <returns> un bool </returns>
       public static Profesor operator ==(Universidad g, EClases clase)
        {
            bool rta = true;
            Profesor profe = new Profesor();
            foreach(Profesor professor in g.Instructores)
            {
                if(professor == clase)
                {
                    rta = false;
                    profe = professor;
                }
            }
            if(rta)
            {
                throw new SinProfesorException();
            }
            return profe;
        }

        /// <summary>
        /// Sobrecarga del !=
        /// </summary>
        /// <param name="g"> de tipo Universidad </param>
        /// <param name="clase"> de tipo EClase </param>
        /// <returns> un bool </returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            bool rta = true;
            Profesor profe = new Profesor();
            foreach (Profesor professor in g.Instructores)
            {
                if (professor != clase)
                {
                    rta = false;
                    profe = professor;
                }
            }
            if (rta)
            {
                throw new SinProfesorException();
            }
            return profe;
        }
      
         /// <summary>
         /// Sobrecarga del + 
         /// </summary>
         /// <param name="u"> de tipo Universidad </param>
         /// <param name="a"> de tipo Alumno </param>
         /// <returns> una Universidad </returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {

            if(u != a)
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }

        /// <summary>
        /// Sobrecarga del + 
        /// </summary>
        /// <param name="u"> de tipo Universidad </param>
        /// <param name="i"> de tipo Profesor </param>
        /// <returns> una Universidad </returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {

            if (u != i)
            {
                u.profesores.Add(i);
            }
            return u;
        }
        
        /// <summary>
        /// Sobrecarga del + 
        /// </summary>
        /// <param name="g"> de tipo Universidad </param>
        /// <param name="clase"> de tipo EClases </param>
        /// <returns> una Universidad </returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor professor = g == clase;
            Jornada workday = new Jornada(clase, professor);
            foreach(Alumno student in g.alumnos)
            {
                workday += student;
            }
            g.jornada.Add(workday);

            return g;

        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que muestra los datos de la universidad
        /// </summary>
        /// <param name="uni"> de tipo Universidad </param>
        /// <returns> un string </returns>
        private string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            foreach(Jornada workday in uni.jornada)
            {
                sb.AppendLine(workday.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Sobreescritura del toString()
        /// </summary>
        /// <returns> Un string </returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Método estático guardar, que guarda un archivo XML con los datos de Universidad
        /// </summary>
        /// <param name="uni"> de tipo Universidad </param>
        /// <returns> un booleano </returns>
        public static bool Guardar(Universidad uni)
        {
            bool rta = false;
            Xml<Universidad> archive = new Xml<Universidad>();
            rta = archive.Guardar("Universidad.xml", uni);
            
            return rta;
        }

        /// <summary>
        /// Método estático leer, que leer un archivo XML con los datos de Universidad
        /// </summary>
        /// <returns> Una Universidad </returns>
        public static Universidad Leer()
        {
            Xml<Universidad> archive = new Xml<Universidad>();
            Universidad uni = new Universidad();
            archive.Leer("Universidad.xml", out uni);
            
            return uni;
        }

        #endregion
    }
}
