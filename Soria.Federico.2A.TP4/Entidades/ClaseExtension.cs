using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Entidades
{
    /// <summary>
    /// Clase pública de extensión
    /// Implementación de Método de extensión (tema requerido por la consigna del TP Nº4)
    /// </summary>
    public static class ClaseExtension
    {
        #region Métodos
        /// <summary>
        /// Método de extensión que valida el ingreso de un string
        /// </summary>
        /// <param name="p"> de tipo Producto </param>
        /// <param name="dato"> de tipo string </param>
        /// <returns> un string </returns>
        public static string ValidarNombreProducto(this Producto p, string dato)
        {
            string strRegex = @"^[a-zA-Z,\s]+$";
            Match validador = Regex.Match(dato, strRegex);
            if (!validador.Success)
            {
                dato = "";
            }
            return dato;
        }
        #endregion
    }
}
