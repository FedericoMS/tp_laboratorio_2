using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(cmbOperador.Text) == false)
            {
                double resultado = FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text);
                this.lblResultado.Text = resultado.ToString();
            }
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();            
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero nro1 = new Numero();
            if (this.lblResultado.Text != "")
            {
                this.lblResultado.Text = nro1.BinarioDecimal(this.lblResultado.Text);
            }
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (this.lblResultado.Text != "")
            {
                Numero nro1 = new Numero();
                this.lblResultado.Text = nro1.DecimalBinario(this.lblResultado.Text);
            }
        }


        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.SelectedIndex = 0;
            this.lblResultado.Text = "";

        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);
            return Calculadora.Operar(n1, n2, operador);
            
            
        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
