﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    /// <summary>
    /// Interfaz IArchivo <T> genérica
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IArchivo <T>
    {
        /// <summary>
        /// Método abstracto Guardar
        /// </summary>
        /// <param name="archivo"> de tipo string </param>
        /// <param name="datos"> de tipo T genérico </param>
        /// <returns> un bool </returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Método abstracto Leer
        /// </summary>
        /// <param name="archivo"> de tipo string </param>
        /// <param name="datos"> de tipo out T genérico </param>
        /// <returns> un bool </returns>
        bool Leer(string archivo, out T datos);
    }
}
