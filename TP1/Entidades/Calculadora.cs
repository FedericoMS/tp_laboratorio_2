using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
      
        /// <summary>
        /// Valida el operador. Si el operador no es válido, retorna un +
        /// </summary>
        /// <param name="operador"> de tipo Char </param>
        /// <returns>Un string</returns>
        private static string ValidarOperador(char operador)
        {
            string respuesta = char.ToString('+');
            if(operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {
                respuesta = char.ToString(operador);
            }
            return respuesta;
        }

        /// <summary>
        /// Realiza la operación matemática solicitada (+, -, / o *)
        /// </summary>
        /// <param name="num1"> De tipo Numero </param>
        /// <param name="num2"> De tipo Numero </param>
        /// <param name="operador"> De tipo String </param>
        /// <returns> un Double</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            char op = char.Parse(operador);
            double resultado = 0;
            switch (char.Parse(ValidarOperador(op)))
            {
                case '+':
                    resultado = num1 + num2;
                    break;

                case '-':
                    resultado = num1 - num2;
                    break;

                case '*':
                    resultado = num1 * num2;
                    break;

                case '/':
                    resultado = num1 / num2;
                    break;
            }
            return resultado;
        }
    }
}