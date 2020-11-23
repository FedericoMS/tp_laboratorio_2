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
using Archivos;
using Excepciones;

namespace Soria.Federico._2A.TP4
{
    /// <summary>
    /// Partial Class FrmSuplemento, derivada de Form
    /// </summary>
    public partial class FrmSuplemento : Form
    {
       
        #region Atributos

        private Suplemento suplemento;

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de FrmSuplemento
        /// </summary>
        public FrmSuplemento()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor parametrizado de FrmSuplemento
        /// </summary>
        /// <param name="sup"> de tipo Suplemento </param>
        public FrmSuplemento(Suplemento sup) : this()
        {
            this.suplemento = sup;
            this.txtNombreSup.Text = this.suplemento.Nombre;
            this.comboTipo.Text = this.suplemento.Tipo;
            this.txtPrecio.Text = this.suplemento.Precio.ToString();
            this.comboFormato.Text = this.suplemento.Formato;
            this.comboEmpaque.Text = this.suplemento.Empaque;
        }

        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de sólo lectura que retorna un suplemento
        /// </summary>
        public Suplemento SuplementoDelForm
        {
            get
            {
                return this.suplemento;
            }
        }

        #endregion

        #region Manejadores de eventos
        /// <summary>
        /// Botón de aceptar del Formulario
        /// </summary>
        /// <param name="sender"> de tipo object </param>
        /// <param name="e"> de tipo eventargs </param>
        private void buttonAceptar_Click_1(object sender, EventArgs e)
        {
            try
            {
                int idSup = 0;
                if (this.suplemento != null)
                {
                    idSup = this.suplemento.ID;
                }

                this.suplemento = new Suplemento(idSup, this.txtNombreSup.Text, this.comboTipo.Text, 
                                                 float.Parse(this.txtPrecio.Text), this.comboFormato.Text, this.comboEmpaque.Text);


            this.DialogResult = DialogResult.OK;
            }
            catch (Exception)
            {
                MessageBox.Show("Uno o más campos están vacíos");
            }

        }

        /// <summary>
        /// Botón cancelar del formulario
        /// </summary>
        /// <param name="sender"> de tipo object </param>
        /// <param name="e"> de tipo eventargs </param>
        private void buttonCancelar_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Al cargar el form, selecciona el primer elemento de cada combobox
        /// </summary>
        /// <param name="sender"> de tipo object </param>
        /// <param name="e"> de tipo eventargs </param>
        private void FrmSuplemento_Load(object sender, EventArgs e)
        {
            this.comboEmpaque.SelectedIndex = 0;
            this.comboFormato.SelectedIndex = 0;
            this.comboTipo.SelectedIndex = 0;
        }
        #endregion

    }
}
