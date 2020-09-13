using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributos
        private double numero;

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor genérico de Numero
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor sobrecargado de Numero, que recibe como parámetro un double
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor sobrecargado de Número, que recibe como parámetro un string
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        #endregion

        #region Setters
        /// <summary>
        /// SetNumero permite setear un número validado previamente en el atributo numero
        /// </summary>
        public string SetNumero
        {
            set { numero = ValidarNumero(value); }
        }
        #endregion


        #region Métodos

        /// <summary>
        /// Valida si el valor recibido por argumento como string es un número
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns> Un Double </returns>
        private double ValidarNumero(string strNumero)
        {
            double nroDouble = 0;
            double.TryParse(strNumero, out nroDouble);
            
            return nroDouble;          
        }

        /// <summary>
        /// Comprueba si el valor String recibido como argumento es un número binario
        /// </summary>
        /// <param name="binario"></param>
        /// <returns> Un booleano </returns>
        private bool EsBinario (string binario)
        {
            bool respuesta = true;
            for(int i = 0; i<binario.Length; i++)
            {
                if(binario[i] != '1' && binario[i] != '0')
                {
                    respuesta = false;
                    break;
                }
            }
            return respuesta;
        }


        /// <summary>
        /// Convierte un número decimal a binario 
        /// </summary>
        /// <param name="numero"> de tipo Double </param>
        /// <returns> Un string </returns>
        public string DecimalBinario(double numero)
        {
            //EVALUAR SI QUITAR EL ABS O NO
            int nro = (int)Math.Abs(numero);
            int resultado;
            string resto = null;
            while (nro >= 2)
            {
                resultado = nro % 2;
                resto = resultado.ToString() + resto;
                nro = nro / 2;
            }
            resto = nro.ToString() + resto;

            return resto;
        }

        /// <summary>
        /// Le pasa un número de tipo string a la función DecimalBinario(double numero), haciendo la validación previamente, para convertirla en binario
        /// </summary>
        /// <param name="numero"> de tipo String </param>
        /// <returns> Un string </returns>
        public string DecimalBinario(string numero)
        {
            string retorno = "Valor inválido";
            if(numero[0] != 0)
            {
                retorno = this.DecimalBinario(double.Parse(numero));
            }
            return retorno;
        }

        /// <summary>
        /// Convierte un número binario recibido como argumento 
        /// </summary>
        /// <param name="binario"> de tipo string</param>
        /// <returns> Un String </returns>
        public string BinarioDecimal(string binario)
        {
            string retorno = "Valor inválido";
            if(this.EsBinario(binario))
            {
                double acumulador = 0;                
                double aux = binario.Length;
                for (int i = 0; i < binario.Length; i++)
                {
                    aux = aux - 1;
                    if (binario[i] == '1')
                    {
                        acumulador = acumulador + Math.Pow(2, aux);
                    }
                }

                retorno = acumulador.ToString();
            }
            return retorno;
        }

        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Sobrecarga del operador -
        /// </summary>
        /// <param name="n1"> De tipo Numero </param>
        /// <param name="n2"> De tipo Numero </param>
        /// <returns> Un Double </returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador +
        /// </summary>
        /// <param name="n1"> De tipo Numero </param>
        /// <param name="n2"> De tipo Numero </param>
        /// <returns> Un Double </returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador *
        /// </summary>
        /// <param name="n1"> De tipo Numero </param>
        /// <param name="n2"> De tipo Numero </param>
        /// <returns> Un Double </returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador /
        /// </summary>
        /// <param name="n1"> De tipo Numero </param>
        /// <param name="n2"> De tipo Numero </param>
        /// <returns> Un Double </returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double resultado = double.MinValue;
            if(n2.numero != 0)
            {
                resultado = n1.numero / n2.numero;
            }
            return resultado;
        }

        

        #endregion
    }
}
