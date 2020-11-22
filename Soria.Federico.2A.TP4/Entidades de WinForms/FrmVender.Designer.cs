namespace Soria.Federico._2A.TP4
{
    partial class FrmVender
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridMedicamentos = new System.Windows.Forms.DataGridView();
            this.buttonVender = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridSuplementos = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMedicamentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSuplementos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Catálogo";
            // 
            // dataGridMedicamentos
            // 
            this.dataGridMedicamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMedicamentos.Location = new System.Drawing.Point(27, 48);
            this.dataGridMedicamentos.Name = "dataGridMedicamentos";
            this.dataGridMedicamentos.Size = new System.Drawing.Size(269, 135);
            this.dataGridMedicamentos.TabIndex = 1;
            // 
            // buttonVender
            // 
            this.buttonVender.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVender.Location = new System.Drawing.Point(434, 300);
            this.buttonVender.Name = "buttonVender";
            this.buttonVender.Size = new System.Drawing.Size(181, 48);
            this.buttonVender.TabIndex = 2;
            this.buttonVender.Text = "Vender";
            this.buttonVender.UseVisualStyleBackColor = true;
            this.buttonVender.Click += new System.EventHandler(this.buttonVender_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(302, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(387, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nota. Para seleccionar y deseleccionar más de un";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(302, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(406, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "producto, mantenga apretada la tecla \"Ctrl\" mientras ";
            // 
            // dataGridSuplementos
            // 
            this.dataGridSuplementos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSuplementos.Location = new System.Drawing.Point(27, 213);
            this.dataGridSuplementos.Name = "dataGridSuplementos";
            this.dataGridSuplementos.Size = new System.Drawing.Size(269, 135);
            this.dataGridSuplementos.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(302, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(272, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "selecciona los productos a vender.";
            // 
            // FrmVender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Soria.Federico._2A.TP4.Properties.Resources.Online_Pharmacy;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(701, 382);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridSuplementos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonVender);
            this.Controls.Add(this.dataGridMedicamentos);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVender";
            this.Text = "Plataforma de ventas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMedicamentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSuplementos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridMedicamentos;
        private System.Windows.Forms.Button buttonVender;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridSuplementos;
        private System.Windows.Forms.Label label4;
    }
}