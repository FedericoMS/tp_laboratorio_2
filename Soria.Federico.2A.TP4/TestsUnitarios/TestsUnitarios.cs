using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivos;
using Entidades;
using Excepciones;

namespace TestsUnitarios
{
    /// <summary>
    /// Clase TestUnitarios, que aplica test unitarios a distintos métodos y excepciones
    /// Implementación de Test Unitarios (tema requerido por la consigna del TP Nº4)
    /// </summary>
    [TestClass]
    public class TestsUnitarios
    {
        /// <summary>
        /// Test que prueba el lanzamiento de la excepción PrecioInvalidoException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(PrecioInvalidoException))]
        public void VerificarPrecioInvalidoException()
        {
            Medicamento med = new Medicamento(20, "aspirina", "analgesico", -20, "bayer", "argentina");
        }

        /// <summary>
        /// Test que prueba el lanzamiento de la excepción StringInvalidoException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(StringInvalidoException))]
        public void VerificarStringInvalidoException()
        {
            Medicamento med = new Medicamento(20, "13212356", "analgesico", 100, "bayer", "argentina");
        }

        /// <summary>
        /// Test que prueba el operador + de Venta
        /// </summary>
        [TestMethod]
        public void VerificarOperadorSumaDeVenta()
        {
            Venta<Producto> venta = new Venta<Producto>();
            Medicamento med = new Medicamento(20, "loratadina", "antihistaminico", 20, "bayer", "argentina");
            venta += med;
            Assert.IsTrue(venta.listaDeCompras.Contains(med));
        }

        /// <summary>
        /// Test que prueba el operador + de Stock
        /// </summary>
        [TestMethod]
        public void VerificarOperadorSumaDeStock()
        {
            Stock storage = new Stock();
            Suplemento sup = new Suplemento(20, "proteina", "suplemento", 1000, "polvo", "frasco");
            storage += sup;
            Assert.IsTrue(storage.Deposito.Contains(sup));
        }
    }
}
