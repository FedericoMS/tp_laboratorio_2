using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using Archivos;
using Entidades;
using Excepciones;

namespace TestConsola
{
    /// <summary>
    /// Clase Program donde se testean funcionalidades utilizadas en esta solución.
    /// (tema requerido por la consigna del TP Nº4)
    /// </summary>
    class Program
    {

        static void Main(string[] args)
        {
            
            try
            {
                Medicamento med1 = new Medicamento(30, "3412983", "analgésico", 100, "bayer", "argentina");
            }
            catch (StringInvalidoException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                Medicamento med2 = new Medicamento(40, "Ibuprofeno", "analgésico", -10, "bayer", "argentina");
            }
            catch (PrecioInvalidoException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Medicamento med3 = new Medicamento(20, "Aspirina", "analgésico", 20, "gador", "argentina");
            Medicamento med4 = new Medicamento(20, "Paracetamol", "analgésico", 40, "raffo", "argentina");
            Medicamento med5 = new Medicamento(20, "Loratadina", "antihistamínico", 40, "isa", "argentina");

            Console.WriteLine(med3.ToString());

            Stock storage = new Stock();

            storage += med3;
            storage += med4;
            storage += med5;

            Suplemento sup1 = new Suplemento(50, "proteina", "suplemento", 5000, "polvo", "frasco");

            storage += sup1;

            Console.WriteLine(storage.ToString());

            SqlConnection cn = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;");
            try
            {
                cn.Open();
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                    Console.WriteLine("Conexión exitosa");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                bool rta = Stock.GuardarXml(storage, "PruebaStock.xml");
                if(rta)
                {
                    Console.WriteLine("Se ha guardado el archivo xml");
                }
            }
            catch(ArchivosException)
            {
                Console.WriteLine("No se pudo guardar el archivo xml");
            }
            Console.ReadKey();
            Console.Clear();

            try
            {
                Xml<Stock> file = new Xml<Stock>();
                bool rta = file.Leer("PruebaStock.xml", out storage);
                Console.WriteLine(storage.ToString());
            }
            catch (ArchivosException)
            {
                Console.WriteLine("No se pudo leer el archivo xml");
            }



            Console.ReadKey();
        }
    }
}
