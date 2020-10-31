using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region Enumerados
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por default de Persona
        /// </summary>
        public Persona() 
        {

        }

        /// <summary>
        /// Constructor parametrizado de Persona
        /// </summary>
        /// <param name="nombre"> de tipo string </param>
        /// <param name="apellido"> de tipo string </param>
        /// <param name="nacionalidad"> de tipo ENacionalidad </param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor parametrizado de Persona
        /// </summary>
        /// <param name="nombre"> de tipo string </param>
        /// <param name="apellido"> de tipo string </param>
        /// <param name="dni"> de tipo int </param>
        /// <param name="nacionalidad"> de tipo ENacionalidad </param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor parametrizado de Persona
        /// </summary>
        /// <param name="nombre"> de tipo string </param>
        /// <param name="apellido"> de tipo string </param>
        /// <param name="dni"> de tipo string </param>
        /// <param name="nacionalidad"> de tipo ENacionalidad </param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad getter y setter de apellido. En el set valida el dato ingresado
        /// </summary>
        public string Apellido 
        {
            get
            {
                return this.apellido;
            }

            set 
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad getter y setter de Nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }

            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Propiedad getter y setter de DNI. En el set valida que el dni ingresado sea válido
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }

            set
            {
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad setter que valida un dato recibido como cadena para DNI.
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }


        /// <summary>
        /// Propiedad getter y setter de Nombre. El set valida que el dato ingresado sea una cadena válida
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }

            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        #endregion

        /// <summary>
        /// Valida que "dato" sea un número válido para DNI. Caso contrario lanza una excepción
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns> Un entero </returns>
        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int resultado;
            if (nacionalidad == ENacionalidad.Argentino && (dato > 1 && dato < 89999999))
            {
                resultado = dato;
            }
            else
            {
                if(nacionalidad == ENacionalidad.Extranjero && (dato > 89999999 && dato < 99999999))
                {
                    resultado = dato;
                }
                else
                if(dato > 99999999 || dato < 1)
                {
                    throw new DniInvalidoException("El DNI ingresado es inválido");
                }
                else
                {
                    throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                }
            }

            return resultado;
        }

        /// <summary>
        /// Valida que el string dato sea un dato válido para pasárselo luego a ValidarDni
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns> Un entero </returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni = 0;
            if(dato.Length >= 1 && dato.Length <= 8)
            {
                try
                {
                    dni = int.Parse(dato);
                }
                catch(Exception e)
                {
                    throw new DniInvalidoException(e);
                }
            }

            return Persona.ValidarDni(nacionalidad, dni);
        }

        /// <summary>
        /// Valida que el string dato recibido esté entre los rangos del strRegex (a-z y A-Z)
        /// </summary>
        /// <param name="dato"></param>
        /// <returns> un string </returns>
        private static string ValidarNombreApellido(string dato)
        {
            string strRegex = @"[a-zA-Z]*";
            Match validador = Regex.Match(dato, strRegex);
            if(!validador.Success)
            {
                dato = "";
            }
            return dato;
        }

        /// <summary>
        /// Retorna un string con el nombre completo y la nacionalidad de persona
        /// </summary>
        /// <returns> un string </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"NOMBRE COMPLETO: {this.apellido}, {this.nombre}");
            sb.AppendLine($"NACIONALIDAD: {this.nacionalidad}");

            return sb.ToString();
        }





    }
}
