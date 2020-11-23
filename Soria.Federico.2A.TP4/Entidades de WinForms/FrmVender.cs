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
using Entidades;

namespace Soria.Federico._2A.TP4
{
    /// <summary>
    /// Partial Class FrmVender, derivada de Form
    /// </summary>
    public partial class FrmVender : Form
    {
        #region Atributos

        protected SqlDataAdapter daVenta;
        protected DataTable dtVenta;
        protected SqlDataAdapter daVentaSuplementos;
        protected DataTable dtVentaSuplementos;
        protected SqlConnection cn = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;");
        protected Venta<Producto> listaDeVentas;

        public delegate void delegadoPasarDato();
        public event delegadoPasarDato ContarVentaEvent;

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de FrmVender
        /// </summary>
        public FrmVender()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            FrmPrincipal mainForm = new FrmPrincipal();
            this.daVenta = mainForm.SQLAdapterMedicamentos;
            this.daVentaSuplementos = mainForm.SQLAdapterSuplementos;
            this.listaDeVentas = new Venta<Producto>();

            try
            {
                this.dtVenta = mainForm.TablaMedicamentos;
                this.dtVentaSuplementos = mainForm.TablaSuplementos;
                this.daVenta.Fill(this.dtVenta);
                this.daVentaSuplementos.Fill(this.dtVentaSuplementos);
                this.ConfigurarDataGrid();
                this.dataGridMedicamentos.DataSource = this.dtVenta;
                this.dataGridSuplementos.DataSource = this.dtVentaSuplementos;
                this.dataGridMedicamentos.Columns["id"].Visible = false;
                this.dataGridMedicamentos.Columns["origen"].Visible = false;
                this.dataGridSuplementos.Columns["id"].Visible = false;
                this.dataGridSuplementos.Columns["empaque"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Manejadores de eventos

        /// <summary>
        /// Botón de Vender, que lleva a cabo la venta de los productos seleccionados. En caso de que no haya ningún producto seleccionado o no haya ningún producto
        /// en stock, no permite ejecutar la venta.
        /// En este manejador de eventos, se utiliza el evento ContarVentaEvent, que actualiza el contador de ventas en el FormPrincipal en
        /// tiempo real. (Delegados y eventos - Tema requerido por la consigna del TP Nº4)
        /// </summary>
        /// <param name="sender"> de tipo object </param>
        /// <param name="e"> de tipo eventargs </param>
        private void buttonVender_Click(object sender, EventArgs e)
        {
            
            if (dataGridMedicamentos.SelectedRows.Count == 0 && dataGridSuplementos.SelectedRows.Count == 0)
            {
                MessageBox.Show("No se puede efectuar la venta porque no se seleccionó ningún producto o no hay stock disponible");
            }
            else
            {
                FrmPrincipal mainForm = new FrmPrincipal();
                DialogResult result = MessageBox.Show("¿Está seguro de que quiere efectuar la venta de este producto?", "Ventas",
                                                       MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                int index;
                if (result == DialogResult.OK)
                {
                        foreach (DataGridViewRow row in dataGridMedicamentos.SelectedRows)
                        {
                            index = dataGridMedicamentos.CurrentRow.Index;
                            Medicamento med = new Medicamento(int.Parse(this.dataGridMedicamentos[0, index].Value.ToString()), this.dataGridMedicamentos[1, index].Value.ToString(),
                                                              this.dataGridMedicamentos[2, index].Value.ToString(), float.Parse(this.dataGridMedicamentos[3, index].Value.ToString()),
                                                              this.dataGridMedicamentos[4, index].Value.ToString(), this.dataGridMedicamentos[5, index].Value.ToString());
                            this.listaDeVentas += med;
                            dataGridMedicamentos.Rows.Remove(row);
                        }

                        foreach (DataGridViewRow row in dataGridSuplementos.SelectedRows)
                        {
                            index = dataGridSuplementos.CurrentRow.Index;
                            Suplemento sup = new Suplemento(int.Parse(this.dataGridSuplementos[0, index].Value.ToString()), this.dataGridSuplementos[1, index].Value.ToString(),
                                                            this.dataGridSuplementos[2, index].Value.ToString(), float.Parse(this.dataGridSuplementos[3, index].Value.ToString()),
                                                            this.dataGridSuplementos[4, index].Value.ToString(), this.dataGridSuplementos[5, index].Value.ToString());
                            this.listaDeVentas += sup;
                            dataGridSuplementos.Rows.Remove(row);
                        }

                        try
                        {
                            mainForm.SQLAdapterMedicamentos.Update(dtVenta);
                            mainForm.SQLAdapterSuplementos.Update(dtVentaSuplementos);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        this.GenerarTicket();
                        ContarVentaEvent();
                
                }
            }

        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método privado que configura las grillas de los productos
        /// </summary>
        private void ConfigurarDataGrid()
        {
            #region Configuración de la grilla de medicamentos
            this.dataGridMedicamentos.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            this.dataGridMedicamentos.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dataGridMedicamentos.BackgroundColor = Color.White;
            this.dataGridMedicamentos.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridMedicamentos.Font, FontStyle.Bold);
            this.dataGridMedicamentos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridMedicamentos.GridColor = Color.DarkCyan;
            this.dataGridMedicamentos.ReadOnly = false;
            this.dataGridMedicamentos.MultiSelect = true;
            this.dataGridMedicamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridMedicamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridMedicamentos.RowsDefaultCellStyle.SelectionBackColor = Color.PaleVioletRed;
            this.dataGridMedicamentos.RowsDefaultCellStyle.SelectionForeColor = Color.White;
            this.dataGridMedicamentos.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.dataGridMedicamentos.RowHeadersVisible = false;
            this.dataGridMedicamentos.AllowUserToAddRows = false;

            #endregion

            #region Configuración de la grilla de suplementos
            this.dataGridSuplementos.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            this.dataGridSuplementos.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            this.dataGridSuplementos.BackgroundColor = Color.White;
            this.dataGridSuplementos.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridSuplementos.Font, FontStyle.Bold);
            this.dataGridSuplementos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridSuplementos.GridColor = Color.DarkCyan;
            this.dataGridSuplementos.ReadOnly = false;
            this.dataGridSuplementos.MultiSelect = true;
            this.dataGridSuplementos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridSuplementos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridSuplementos.RowsDefaultCellStyle.SelectionBackColor = Color.PaleVioletRed;
            this.dataGridSuplementos.RowsDefaultCellStyle.SelectionForeColor = Color.White;
            this.dataGridSuplementos.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.dataGridSuplementos.RowHeadersVisible = false;
            this.dataGridSuplementos.AllowUserToAddRows = false;
            #endregion

        }
        
        /// <summary>
        /// Método de instancia que genera un ticket de la venta en forma de txt
        /// </summary>
        private void GenerarTicket()
        {
            Venta<Producto>.Guardar(this.listaDeVentas);
            MessageBox.Show("Se generó un ticket con la venta realizada! El mismo se guarda en la ruta predeterminada((...)Entidades de WinForms\\bin\\Debug)");
        }

        #endregion

    }
}
