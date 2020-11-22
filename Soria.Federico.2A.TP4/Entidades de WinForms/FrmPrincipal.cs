using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.IO;
using Archivos;
using Entidades;
using Excepciones;

namespace Soria.Federico._2A.TP4
{
    /// <summary>
    /// Partial Class FrmPrincipal, derivada de Form
    /// </summary>
    public partial class FrmPrincipal : Form
    {

        #region Atributos

        protected SqlDataAdapter daMedicamentos;
        protected DataTable dtMedicamentos;
        protected SqlDataAdapter daSuplementos;
        protected DataTable dtSuplementos;
        protected SqlConnection cn = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;");
        Thread hiloFecha;
        public delegate void DelegadoBienvenida();
        public DelegadoBienvenida Bienvenida;
        public delegate void DelegadoVenta();
        public DelegadoVenta VentaFinalizada;
        private int ContadorDeVentas = 0;

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de FrmPrincipal
        /// </summary>
        public FrmPrincipal()
        {
            InitializeComponent();
            this.Bienvenida += MensajeBienvenida;
            this.VentaFinalizada += ActualizacionAutomaticaDataGrid;

            this.StartPosition = FormStartPosition.CenterScreen;
            if (!this.ConfigurarDataAdapter())
            {
                MessageBox.Show("Error al intentar configurar el Data Adapter.");
                this.Close();
            }

            this.ConfigurarColumnasDataTable();

            try
            {
                this.daMedicamentos.Fill(this.dtMedicamentos);
                this.daSuplementos.Fill(this.dtSuplementos);
                this.ConfigurarDataGrid();

                this.dataGridMedicamentos.DataSource = this.dtMedicamentos;
                this.dataGridSuplementos.DataSource = this.dtSuplementos;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de sólo lectura de la grilla de medicamentos
        /// </summary>
        public DataGridView GrillaMedicamentos
        {
            get
            {
                return this.dataGridMedicamentos;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del Data Table de medicamentos
        /// </summary>
        public DataTable TablaMedicamentos
        {
            get
            {
                return this.dtMedicamentos;
            }

            set
            {
                this.dtMedicamentos = value;
            }

        }

        /// <summary>
        /// Propiedad de lectura y escritura del Data Adapter de medicamentos
        /// </summary>
        public SqlDataAdapter SQLAdapterMedicamentos
        {
            get
            {
                return this.daMedicamentos;
            }

            set
            {
                this.daMedicamentos = value;
            }
        }

        /// <summary>
        /// Propiedad de sólo lectura de la grilla de suplementos
        /// </summary>
        public DataGridView GrillaSuplementos
        {
            get
            {
                return this.dataGridSuplementos;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritra del Data Table de suplementos
        /// </summary>
        public DataTable TablaSuplementos
        {
            get
            {
                return this.dtSuplementos;
            }

            set
            {
                this.dtSuplementos = value;
            }

        }

        /// <summary>
        /// Propiedad de lectura y escritura del Data Adapter de suplementos
        /// </summary>
        public SqlDataAdapter SQLAdapterSuplementos
        {
            get
            {
                return this.daSuplementos;
            }

            set
            {
                this.daSuplementos = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de la conexión SQLConnection
        /// </summary>
        public SqlConnection Conexion
        {
            get
            {
                return this.cn;
            }

            set
            {
                this.cn = value;
            }
        }



        #endregion

        #region Manejadores de eventos
        /// <summary>
        /// Realiza la carga del form principal, que a su vez contiene la invocación de los métodos del evento Bienvenida y da inicio a los hilos
        /// (tema requerido por la consigna del TP Nº4)
        /// </summary>
        /// <param name="sender"> de tipo object </param>
        /// <param name="e"> de tipo EventArgs </param>
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            Bienvenida.Invoke();
            try
            {
                this.hiloFecha = new Thread(this.MostrarFecha);
                if (!this.hiloFecha.IsAlive)
                {
                    this.hiloFecha.Start();
                }
                else
                {
                    this.hiloFecha.Abort();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Evento que genera un mensaje de advertencia y que aborta los hilos activos antes de cerrar el programa
        /// </summary>
        /// <param name="sender"> de tipo object </param>
        /// <param name="e"> de tipo EventArgs </param>
        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult result = MessageBox.Show("Se está por cerrar la plataforma de datos y ventas.\n ¿Está seguro de que quiere cerrar el programa?",
                                                  "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                if (this.hiloFecha.IsAlive)
                {
                    this.hiloFecha.Abort();
                }
            }
        }

        /// <summary>
        /// Realiza la sincronización y actualización de los datos entre la base de datos y el Data Table
        /// </summary>
        /// <param name="sender"> de tipo object </param>
        /// <param name="e"> de tipo EventArgs </param>
        private void buttonSincronizar_Click(object sender, EventArgs e)
        {
            try
            {
                this.daMedicamentos.Update(dtMedicamentos);
                this.daSuplementos.Update(dtSuplementos);
                MessageBox.Show("Se han sincronizado los datos\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se han podido sincronizar los datos\n" + ex.Message);
            }
        }


        /// <summary>
        /// Dispara el form para realizar la carga de un medicamento
        /// </summary>
        /// <param name="sender"> de tipo object </param>
        /// <param name="e"> de tipo EvenArgs </param>
        private void buttonCargarMedicamento_Click(object sender, EventArgs e)
        {
            FrmMedicamento frmMed = new FrmMedicamento();
            frmMed.StartPosition = FormStartPosition.CenterScreen;
            try
            {
                if (frmMed.ShowDialog() == DialogResult.OK)
                {
                    DataRow fila = this.dtMedicamentos.NewRow();

                    fila["nombre"] = frmMed.MedicamentoDelForm.Nombre;
                    fila["tipo"] = frmMed.MedicamentoDelForm.Tipo;
                    fila["precio"] = frmMed.MedicamentoDelForm.Precio;
                    fila["marca"] = frmMed.MedicamentoDelForm.Marca;
                    fila["origen"] = frmMed.MedicamentoDelForm.Origen;

                    this.dtMedicamentos.Rows.Add(fila);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Dispara el form para realizar la modificación de un medicamento
        /// </summary>
        /// <param name="sender"> de tipo object </param>
        /// <param name="e"> de tipo EventArgs </param>
        private void buttonModificarMedicamento_Click(object sender, EventArgs e)
        {

            if (this.dataGridMedicamentos.Rows.Count > 0)
            {
                int indice = this.dataGridMedicamentos.SelectedRows[0].Index;
                DataRow fila = this.dtMedicamentos.Rows[indice];
                Medicamento med = new Medicamento(int.Parse(fila[0].ToString()), fila["nombre"].ToString(),
                                                  fila["tipo"].ToString(), float.Parse(fila["precio"].ToString()),
                                                  fila["marca"].ToString(), fila["origen"].ToString());

                FrmMedicamento frmMed = new FrmMedicamento(med);
                frmMed.StartPosition = FormStartPosition.CenterScreen;
                try
                {
                    if (frmMed.ShowDialog() == DialogResult.OK)
                    {
                        fila["nombre"] = frmMed.MedicamentoDelForm.Nombre;
                        fila["tipo"] = frmMed.MedicamentoDelForm.Tipo;
                        fila["precio"] = frmMed.MedicamentoDelForm.Precio;
                        fila["marca"] = frmMed.MedicamentoDelForm.Marca;
                        fila["origen"] = frmMed.MedicamentoDelForm.Origen;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        /// <summary>
        /// Dispara el form para realizar la eliminación de un medicamento
        /// </summary>
        /// <param name="sender"> de tipo object </param>
        /// <param name="e"> de tipo EventArgs </param>
        private void buttonEliminarMedicamento_Click(object sender, EventArgs e)
        {
            if (this.dataGridMedicamentos.Rows.Count > 0)
            {
                int indice = this.dataGridMedicamentos.SelectedRows[0].Index;
                DataRow fila = this.dtMedicamentos.Rows[indice];
                Medicamento med = new Medicamento(int.Parse(fila[0].ToString()), fila["nombre"].ToString(),
                                                  fila["tipo"].ToString(), float.Parse(fila["precio"].ToString()),
                                                  fila["marca"].ToString(), fila["origen"].ToString());

                FrmMedicamento frm = new FrmMedicamento(med);
                frm.StartPosition = FormStartPosition.CenterScreen;
                if (frm.ShowDialog() == DialogResult.OK && fila.RowState != DataRowState.Deleted)
                {
                    fila.Delete();
                }
            }
        }

        /// <summary>
        /// Dispara el form para la carga de un suplemento
        /// </summary>
        /// <param name="sender"> de tipo object </param>
        /// <param name="e"> de tipo EventArgs </param>
        private void buttonCargarSuplemento_Click(object sender, EventArgs e)
        {
            FrmSuplemento frmSup = new FrmSuplemento();
            frmSup.StartPosition = FormStartPosition.CenterScreen;
            try
            {
                if (frmSup.ShowDialog() == DialogResult.OK)
                {
                    DataRow fila = this.dtSuplementos.NewRow();

                    fila["nombre"] = frmSup.SuplementoDelForm.Nombre;
                    fila["tipo"] = frmSup.SuplementoDelForm.Tipo;
                    fila["precio"] = frmSup.SuplementoDelForm.Precio;
                    fila["formato"] = frmSup.SuplementoDelForm.Formato;
                    fila["empaque"] = frmSup.SuplementoDelForm.Empaque;

                    this.dtSuplementos.Rows.Add(fila);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Dispara el form para la eliminación de un suplemento
        /// </summary>
        /// <param name="sender"> de tipo object </param>
        /// <param name="e"> de tipo EventArgs </param>
        private void buttonEliminarSuplemento_Click(object sender, EventArgs e)
        {
            if (this.dataGridSuplementos.Rows.Count > 0)
            {
                int indice = this.dataGridSuplementos.SelectedRows[0].Index;
                DataRow fila = this.dtSuplementos.Rows[indice];
                Suplemento sup = new Suplemento(int.Parse(fila[0].ToString()), fila["nombre"].ToString(),
                                                  fila["tipo"].ToString(), float.Parse(fila["precio"].ToString()),
                                                  fila["formato"].ToString(), fila["empaque"].ToString());

                FrmSuplemento frm = new FrmSuplemento(sup);
                frm.StartPosition = FormStartPosition.CenterScreen;
                if (frm.ShowDialog() == DialogResult.OK && fila.RowState != DataRowState.Deleted)
                {
                    fila.Delete();
                }
            }
        }

        /// <summary>
        /// Dispara el form para la modificación de un suplemento
        /// </summary>
        /// <param name="sender"> de tipo object </param>
        /// <param name="e"> de tipo EventArgs </param>
        private void buttonModificarSuplemento_Click(object sender, EventArgs e)
        {
            if (this.dataGridSuplementos.Rows.Count > 0)
            {
                int indice = this.dataGridSuplementos.SelectedRows[0].Index;
                DataRow fila = this.dtSuplementos.Rows[indice];
                Suplemento sup = new Suplemento(int.Parse(fila[0].ToString()), fila["nombre"].ToString(),
                                                  fila["tipo"].ToString(), float.Parse(fila["precio"].ToString()),
                                                  fila["formato"].ToString(), fila["empaque"].ToString());

                FrmSuplemento frm = new FrmSuplemento(sup);
                frm.StartPosition = FormStartPosition.CenterScreen;
                try
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        fila["nombre"] = frm.SuplementoDelForm.Nombre;
                        fila["tipo"] = frm.SuplementoDelForm.Tipo;
                        fila["precio"] = frm.SuplementoDelForm.Precio;
                        fila["formato"] = frm.SuplementoDelForm.Formato;
                        fila["empaque"] = frm.SuplementoDelForm.Empaque;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Dispara el form para realizar la venta de uno o mas productos
        /// Se utiliza el evento VentaFinalizada
        /// </summary>
        /// <param name="sender"> de tipo object </param>
        /// <param name="e"> de tipo EventArgs </param>
        private void buttonVender_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Para poder efectuar una venta, se necesita sincronizar previamente con la base de datos para " +
                                                  "obtener el catálogo actualizado. ¿Está seguro de que quiere actualizar la base de datos?", "Ventas",
                                                   MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                this.daMedicamentos.Update(dtMedicamentos);
                this.daSuplementos.Update(dtSuplementos);
                MessageBox.Show("Se han sincronizado los datos");

                FrmVender frmVenta = new FrmVender();
                frmVenta.ContarVentaEvent += ActualizarContadorVentas;
                frmVenta.ShowDialog();
                if (frmVenta.DialogResult == DialogResult.Cancel)
                {
                    this.VentaFinalizada.Invoke();
                }
            }
        }

        /// <summary>
        /// Realiza la serialización xml de los stocks de Medicamentos y Suplementos
        /// Serialización (Tema requerido por la consigna del TP Nº4)
        /// </summary>
        /// <param name="sender"> de tipo object </param>
        /// <param name="e"> de tipo EventArgs </param>
        private void buttonSerializarStock_Click(object sender, EventArgs e)
        {
            try
            {
                //Serialización desde la grilla de suplementos
                Stock listaDeSuplementos = new Stock();
                int index;
                if (this.dataGridSuplementos.Rows.Count > 0)
                {
                    for (index = 0; index < this.dataGridSuplementos.Rows.Count; index++)
                    {
                        Suplemento sup = new Suplemento(int.Parse(this.dataGridSuplementos[0, index].Value.ToString()), this.dataGridSuplementos[1, index].Value.ToString(),
                                  this.dataGridSuplementos[2, index].Value.ToString(), float.Parse(this.dataGridSuplementos[3, index].Value.ToString()),
                                  this.dataGridSuplementos[4, index].Value.ToString(), this.dataGridSuplementos[5, index].Value.ToString());
                        listaDeSuplementos += sup;
                    }
                    Stock.GuardarXml(listaDeSuplementos, "StockSuplementos.xml");
                    MessageBox.Show("Se ha serializado el stock de suplementos");

                }
                else
                {
                    MessageBox.Show("No se serializó el stock de suplementos");
                }

                //Serialización desde la grilla de medicamentos
                Stock listaDeMedicamentos = new Stock();
                if (this.dataGridMedicamentos.Rows.Count > 0)
                {
                    for (index = 0; index < this.dataGridMedicamentos.Rows.Count; index++)
                    {
                        Medicamento med = new Medicamento(int.Parse(this.dataGridMedicamentos[0, index].Value.ToString()), this.dataGridMedicamentos[1, index].Value.ToString(),
                                                          this.dataGridMedicamentos[2, index].Value.ToString(), float.Parse(this.dataGridMedicamentos[3, index].Value.ToString()),
                                                          this.dataGridMedicamentos[4, index].Value.ToString(), this.dataGridMedicamentos[5, index].Value.ToString());
                        listaDeMedicamentos += med;
                    }

                    Stock.GuardarXml(listaDeMedicamentos, "StockMedicamentos.xml");
                    MessageBox.Show("Se ha serializado el stock de medicamentos");
                }
                else
                {
                    MessageBox.Show("No se serializó el stock de medicamentos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Realiza la deserialización de los archivos xml de stock Medicamentos y Suplementos, mostrando los datos en ventanas.
        /// Deserialización (tema requerido por la consigna del TP Nº4)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeserializar_Click(object sender, EventArgs e)
        {
            bool rtaMeds;
            bool rtaSups;
            Xml<Stock> file = new Xml<Stock>();
            Stock listaDeMedicamentos = new Stock();
            Stock listaDeSuplementos = new Stock();
            try
            {
                rtaMeds = file.Leer("StockMedicamentos.xml", out listaDeMedicamentos);
                MessageBox.Show(listaDeMedicamentos.ToString());
            }
            catch (ArchivosException ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                rtaSups = file.Leer("StockSuplementos.xml", out listaDeSuplementos);
                MessageBox.Show(listaDeSuplementos.ToString());
            }
            catch (ArchivosException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Método de instancia void, que actualiza la hora del programa cada un segundo
        /// Hilos. Tema requerido por la consigna del TP Nº4
        /// </summary>
        public void MostrarFecha()
        {

            while (true)
            {
                if (this.labelDate.InvokeRequired)
                {
                    this.labelDate.BeginInvoke(
                        (MethodInvoker)delegate ()
                        {
                            this.labelDate.Text = DateTime.Now.ToString();
                        }
                    );
                }
                else
                {
                    this.labelDate.Text = DateTime.Now.ToString();
                }
                Thread.Sleep(1000);

            }
        }

        /// <summary>
        /// Método de instancia void que dispara un mensaje de bienvenida
        /// </summary>
        public void MensajeBienvenida()
        {
            MessageBox.Show("Bienvenido a la plataforma de datos y venta de la farmacia");
        }

        /// <summary>
        /// Método de instancia que realiza la configuración pertinente para los Data Adapter de Medicamentos y Suplementos, con sus respectivos comandos
        /// </summary>
        /// <returns> un bool </returns>
        private bool ConfigurarDataAdapter()
        {
            bool rta = false;
            try
            {
                this.daMedicamentos = new SqlDataAdapter();
                this.daSuplementos = new SqlDataAdapter();

                #region Comandos de medicamentos
                this.daMedicamentos.SelectCommand = new SqlCommand("SELECT id, nombre, tipo, precio, marca, origen FROM [storage_pharmacy].[dbo].[storage_meds]", cn);
                this.daMedicamentos.InsertCommand = new SqlCommand("INSERT INTO [storage_pharmacy].[dbo].[storage_meds] (nombre, tipo, precio, marca, origen) VALUES (@nombre, @tipo, @precio, @marca, @origen)", cn);
                this.daMedicamentos.UpdateCommand = new SqlCommand("UPDATE [storage_pharmacy].[dbo].[storage_meds] SET nombre=@nombre, tipo=@tipo, precio=@precio, marca=@marca, origen=@origen WHERE id=@id", cn);
                this.daMedicamentos.DeleteCommand = new SqlCommand("DELETE FROM [storage_pharmacy].[dbo].[storage_meds] WHERE id=@id", cn);

                this.daMedicamentos.InsertCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "nombre");
                this.daMedicamentos.InsertCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");
                this.daMedicamentos.InsertCommand.Parameters.Add("@precio", SqlDbType.Float, 10, "precio");
                this.daMedicamentos.InsertCommand.Parameters.Add("@marca", SqlDbType.VarChar, 50, "marca");
                this.daMedicamentos.InsertCommand.Parameters.Add("@origen", SqlDbType.VarChar, 50, "origen");

                this.daMedicamentos.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");
                this.daMedicamentos.UpdateCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "nombre");
                this.daMedicamentos.UpdateCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");
                this.daMedicamentos.UpdateCommand.Parameters.Add("@precio", SqlDbType.Float, 10, "precio");
                this.daMedicamentos.UpdateCommand.Parameters.Add("@marca", SqlDbType.VarChar, 50, "marca");
                this.daMedicamentos.UpdateCommand.Parameters.Add("@origen", SqlDbType.VarChar, 50, "origen");

                this.daMedicamentos.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");
                #endregion

                #region Comandos de suplementos
                this.daSuplementos.SelectCommand = new SqlCommand("SELECT id, nombre, tipo, precio, formato, empaque FROM [storage_pharmacy].[dbo].[storage_supplements]", cn);
                this.daSuplementos.InsertCommand = new SqlCommand("INSERT INTO [storage_pharmacy].[dbo].[storage_supplements] (nombre, tipo, precio, formato, empaque) VALUES (@nombre, @tipo, @precio, @formato, @empaque)", cn);
                this.daSuplementos.UpdateCommand = new SqlCommand("UPDATE [storage_pharmacy].[dbo].[storage_supplements] SET nombre=@nombre, tipo=@tipo, precio=@precio, formato=@formato, empaque=@empaque WHERE id=@id", cn);
                this.daSuplementos.DeleteCommand = new SqlCommand("DELETE FROM [storage_pharmacy].[dbo].[storage_supplements] WHERE id=@id", cn);

                this.daSuplementos.InsertCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "nombre");
                this.daSuplementos.InsertCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");
                this.daSuplementos.InsertCommand.Parameters.Add("@precio", SqlDbType.Float, 10, "precio");
                this.daSuplementos.InsertCommand.Parameters.Add("@formato", SqlDbType.VarChar, 50, "formato");
                this.daSuplementos.InsertCommand.Parameters.Add("@empaque", SqlDbType.VarChar, 50, "empaque");

                this.daSuplementos.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");
                this.daSuplementos.UpdateCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "nombre");
                this.daSuplementos.UpdateCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");
                this.daSuplementos.UpdateCommand.Parameters.Add("@precio", SqlDbType.Float, 10, "precio");
                this.daSuplementos.UpdateCommand.Parameters.Add("@formato", SqlDbType.VarChar, 50, "formato");
                this.daSuplementos.UpdateCommand.Parameters.Add("@empaque", SqlDbType.VarChar, 50, "empaque");

                this.daSuplementos.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");
                #endregion

                rta = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return rta;
        }

        /// <summary>
        /// Método de instancia void que realiza la configuración de las columnas de los Data Tables de medicamentos y suplementos
        /// </summary>
        private void ConfigurarColumnasDataTable()
        {
            //Columnas de medicamentos
            this.dtMedicamentos = new DataTable("Medicamentos");
            this.dtMedicamentos.Columns.Add("id", typeof(int));
            this.dtMedicamentos.Columns.Add("nombre", typeof(string));
            this.dtMedicamentos.Columns.Add("tipo", typeof(string));
            this.dtMedicamentos.Columns.Add("precio", typeof(float));
            this.dtMedicamentos.Columns.Add("marca", typeof(string));
            this.dtMedicamentos.Columns.Add("origen", typeof(string));

            this.dtMedicamentos.PrimaryKey = new DataColumn[] { this.dtMedicamentos.Columns[0] };

            this.dtMedicamentos.Columns["id"].AutoIncrement = true;
            this.dtMedicamentos.Columns["id"].AutoIncrementSeed = 1;
            this.dtMedicamentos.Columns["id"].AutoIncrementStep = 1;

            //Columnas de suplementos

            this.dtSuplementos = new DataTable("Suplementos");
            this.dtSuplementos.Columns.Add("id", typeof(int));
            this.dtSuplementos.Columns.Add("nombre", typeof(string));
            this.dtSuplementos.Columns.Add("tipo", typeof(string));
            this.dtSuplementos.Columns.Add("precio", typeof(float));
            this.dtSuplementos.Columns.Add("formato", typeof(string));
            this.dtSuplementos.Columns.Add("empaque", typeof(string));

            this.dtSuplementos.PrimaryKey = new DataColumn[] { this.dtSuplementos.Columns[0] };

            this.dtSuplementos.Columns["id"].AutoIncrement = true;
            this.dtSuplementos.Columns["id"].AutoIncrementSeed = 1;
            this.dtSuplementos.Columns["id"].AutoIncrementStep = 1;
        }

        /// <summary>
        /// Método de instancia void que realiza la configuración de los DataGridView de las grillas de Medicamentos y Suplementos
        /// </summary>
        public void ConfigurarDataGrid()
        {
            #region Configuración de la grilla de medicamentos
            this.dataGridMedicamentos.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            this.dataGridMedicamentos.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dataGridMedicamentos.BackgroundColor = Color.White;

            this.dataGridMedicamentos.RowsDefaultCellStyle.SelectionBackColor = Color.PaleVioletRed;
            this.dataGridMedicamentos.RowsDefaultCellStyle.SelectionForeColor = Color.White;
            this.dataGridMedicamentos.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.dataGridMedicamentos.RowHeadersVisible = false;
            this.dataGridMedicamentos.AllowUserToAddRows = false;
            this.dataGridMedicamentos.GridColor = Color.DarkCyan;
            this.dataGridMedicamentos.ReadOnly = false;
            this.dataGridMedicamentos.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridMedicamentos.Font, FontStyle.Bold);
            this.dataGridMedicamentos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridMedicamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridMedicamentos.MultiSelect = false;
            this.dataGridMedicamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            #endregion

            #region Configuración de la grilla de suplementos
            this.dataGridSuplementos.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            this.dataGridSuplementos.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dataGridSuplementos.GridColor = Color.DarkCyan;
            this.dataGridSuplementos.ReadOnly = false;
            this.dataGridSuplementos.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.dataGridSuplementos.RowHeadersVisible = false;
            this.dataGridSuplementos.AllowUserToAddRows = false;
            this.dataGridSuplementos.BackgroundColor = Color.White;
            this.dataGridSuplementos.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridMedicamentos.Font, FontStyle.Bold);
            this.dataGridSuplementos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridSuplementos.MultiSelect = false;
            this.dataGridSuplementos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridSuplementos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridSuplementos.RowsDefaultCellStyle.SelectionBackColor = Color.PaleVioletRed;
            this.dataGridSuplementos.RowsDefaultCellStyle.SelectionForeColor = Color.White;
            #endregion

        }

        /// <summary>
        /// Método de instancia void que realiza el refresh de las grillas del form principal
        /// </summary>
        private void ActualizacionAutomaticaDataGrid()
        {
            try
            {
                this.dataGridMedicamentos.DataSource = null;
                this.dataGridSuplementos.DataSource = null;
                this.ConfigurarColumnasDataTable();
                this.daMedicamentos.Fill(this.dtMedicamentos);
                this.daSuplementos.Fill(this.dtSuplementos);
                this.ConfigurarDataGrid();
                this.dataGridMedicamentos.DataSource = this.dtMedicamentos;
                this.dataGridSuplementos.DataSource = this.dtSuplementos;
                MessageBox.Show("Se actualizaron las grillas del stock principal", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Método de instancia void que suma 1 al contador de ventas del form principal
        /// </summary>
        private void ActualizarContadorVentas()
        {
            this.ContadorDeVentas++;
            labelContador.Text = (this.ContadorDeVentas).ToString();
        }

        #endregion

    }
}
