using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Excepciones;

namespace Soria.Federico._2A.TP4
{
    /// <summary>
    /// Clase FrmMedicamento que deriva de Form
    /// </summary>
    public partial class FrmMedicamento : Form
    {
        
        #region Atributos
        private Medicamento medicamento;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de FrmMedicamento
        /// </summary>
        public FrmMedicamento()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor parametrizado de FrmMedicamento
        /// </summary>
        /// <param name="med"> un Medicamento </param>
        public FrmMedicamento(Medicamento med) : this()
        {
            this.medicamento = med;
            this.txtNombre.Text = this.medicamento.Nombre;
            this.comboTipo.Text = this.medicamento.Tipo;
            this.txtPrecio.Text = this.medicamento.Precio.ToString();
            this.comboMarca.Text = this.medicamento.Marca;
            this.comboOrigen.Text = this.medicamento.Origen;
        }

        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de sólo lectura de medicamento
        /// </summary>
        public Medicamento MedicamentoDelForm
        {
            get
            {
                return this.medicamento;
            }
        }

        #endregion

        #region Manejadores de eventos
        /// <summary>
        /// Botón aceptar, que acepta los cambios realizados en los campos del form
        /// </summary>
        /// <param name="sender"> de tipo object </param>
        /// <param name="e"> de tipo eventargs </param>
        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                int idMed = 0;
                if(this.medicamento != null)
                {
                    idMed = this.medicamento.ID;
                }

            this.medicamento = new Medicamento(idMed, this.txtNombre.Text, this.comboTipo.Text, 
                                              float.Parse(this.txtPrecio.Text), this.comboMarca.Text, this.comboOrigen.Text);

            this.DialogResult = DialogResult.OK;

            }
            catch(Exception)
            {
                MessageBox.Show("Uno o más campos están vacíos");
            }
        }

        /// <summary>
        /// Botón de cancelar que cierra el formulario sin efectuar ningún cambio
        /// </summary>
        /// <param name="sender"> de tipo object </param>
        /// <param name="e"> de tipo eventargs </param>
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Al cargar, selecciona automáticamente  el primer elemento de cada combobox 
        /// </summary>
        /// <param name="sender"> de tipo object </param>
        /// <param name="e"> de tipo eventargs </param>
        private void frmMedicamento_Load(object sender, EventArgs e)
        {
            comboTipo.SelectedIndex = 0;
            comboMarca.SelectedIndex = 0;
            comboOrigen.SelectedIndex = 0;
        }

        #endregion

    }
}
