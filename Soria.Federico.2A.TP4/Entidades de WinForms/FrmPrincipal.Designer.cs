namespace Soria.Federico._2A.TP4
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridMedicamentos = new System.Windows.Forms.DataGridView();
            this.buttonCargarMedicamento = new System.Windows.Forms.Button();
            this.buttonEliminarMedicamento = new System.Windows.Forms.Button();
            this.SerializarStock = new System.Windows.Forms.Button();
            this.buttonModificarMedicamento = new System.Windows.Forms.Button();
            this.Sincronizar = new System.Windows.Forms.Button();
            this.buttonVender = new System.Windows.Forms.Button();
            this.labelFecha = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.dataGridSuplementos = new System.Windows.Forms.DataGridView();
            this.CargarSuplemento = new System.Windows.Forms.Button();
            this.EliminarSuplemento = new System.Windows.Forms.Button();
            this.ModificarSuplemento = new System.Windows.Forms.Button();
            this.labelMedicamentos = new System.Windows.Forms.Label();
            this.labelSuplementos = new System.Windows.Forms.Label();
            this.buttonDeserializar = new System.Windows.Forms.Button();
            this.labelContador = new System.Windows.Forms.Label();
            this.labelVentas = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMedicamentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSuplementos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridMedicamentos
            // 
            this.dataGridMedicamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMedicamentos.Location = new System.Drawing.Point(40, 36);
            this.dataGridMedicamentos.Name = "dataGridMedicamentos";
            this.dataGridMedicamentos.Size = new System.Drawing.Size(574, 151);
            this.dataGridMedicamentos.TabIndex = 10;
            // 
            // buttonCargarMedicamento
            // 
            this.buttonCargarMedicamento.BackgroundImage = global::Soria.Federico._2A.TP4.Properties.Resources.pharma;
            this.buttonCargarMedicamento.Location = new System.Drawing.Point(40, 382);
            this.buttonCargarMedicamento.Name = "buttonCargarMedicamento";
            this.buttonCargarMedicamento.Size = new System.Drawing.Size(130, 25);
            this.buttonCargarMedicamento.TabIndex = 12;
            this.buttonCargarMedicamento.Text = "Cargar medicamento";
            this.buttonCargarMedicamento.UseVisualStyleBackColor = true;
            this.buttonCargarMedicamento.Click += new System.EventHandler(this.buttonCargarMedicamento_Click);
            // 
            // buttonEliminarMedicamento
            // 
            this.buttonEliminarMedicamento.Location = new System.Drawing.Point(40, 413);
            this.buttonEliminarMedicamento.Name = "buttonEliminarMedicamento";
            this.buttonEliminarMedicamento.Size = new System.Drawing.Size(130, 25);
            this.buttonEliminarMedicamento.TabIndex = 13;
            this.buttonEliminarMedicamento.Text = "Eliminar medicamento";
            this.buttonEliminarMedicamento.UseVisualStyleBackColor = true;
            this.buttonEliminarMedicamento.Click += new System.EventHandler(this.buttonEliminarMedicamento_Click);
            // 
            // SerializarStock
            // 
            this.SerializarStock.Location = new System.Drawing.Point(344, 382);
            this.SerializarStock.Name = "SerializarStock";
            this.SerializarStock.Size = new System.Drawing.Size(130, 25);
            this.SerializarStock.TabIndex = 14;
            this.SerializarStock.Text = "Serializar stock XML";
            this.SerializarStock.UseVisualStyleBackColor = true;
            this.SerializarStock.Click += new System.EventHandler(this.buttonSerializarStock_Click);
            // 
            // buttonModificarMedicamento
            // 
            this.buttonModificarMedicamento.Location = new System.Drawing.Point(40, 445);
            this.buttonModificarMedicamento.Name = "buttonModificarMedicamento";
            this.buttonModificarMedicamento.Size = new System.Drawing.Size(130, 24);
            this.buttonModificarMedicamento.TabIndex = 15;
            this.buttonModificarMedicamento.Text = "Modificar medicamento";
            this.buttonModificarMedicamento.UseVisualStyleBackColor = true;
            this.buttonModificarMedicamento.Click += new System.EventHandler(this.buttonModificarMedicamento_Click);
            // 
            // Sincronizar
            // 
            this.Sincronizar.Location = new System.Drawing.Point(344, 445);
            this.Sincronizar.Name = "Sincronizar";
            this.Sincronizar.Size = new System.Drawing.Size(130, 25);
            this.Sincronizar.TabIndex = 16;
            this.Sincronizar.Text = "Sincronizar con BD";
            this.Sincronizar.UseVisualStyleBackColor = true;
            this.Sincronizar.Click += new System.EventHandler(this.buttonSincronizar_Click);
            // 
            // buttonVender
            // 
            this.buttonVender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonVender.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonVender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVender.Location = new System.Drawing.Point(496, 382);
            this.buttonVender.Name = "buttonVender";
            this.buttonVender.Size = new System.Drawing.Size(118, 56);
            this.buttonVender.TabIndex = 17;
            this.buttonVender.Text = "Ingresar a ventas";
            this.buttonVender.UseVisualStyleBackColor = false;
            this.buttonVender.Click += new System.EventHandler(this.buttonVender_Click);
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFecha.Location = new System.Drawing.Point(408, 9);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(54, 18);
            this.labelFecha.TabIndex = 18;
            this.labelFecha.Text = "Fecha";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.Location = new System.Drawing.Point(468, 11);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(16, 16);
            this.labelDate.TabIndex = 19;
            this.labelDate.Text = "_";
            // 
            // dataGridSuplementos
            // 
            this.dataGridSuplementos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSuplementos.Location = new System.Drawing.Point(40, 225);
            this.dataGridSuplementos.Name = "dataGridSuplementos";
            this.dataGridSuplementos.Size = new System.Drawing.Size(574, 151);
            this.dataGridSuplementos.TabIndex = 21;
            // 
            // CargarSuplemento
            // 
            this.CargarSuplemento.BackgroundImage = global::Soria.Federico._2A.TP4.Properties.Resources.pharma;
            this.CargarSuplemento.Location = new System.Drawing.Point(195, 382);
            this.CargarSuplemento.Name = "CargarSuplemento";
            this.CargarSuplemento.Size = new System.Drawing.Size(130, 25);
            this.CargarSuplemento.TabIndex = 22;
            this.CargarSuplemento.Text = "Cargar suplemento";
            this.CargarSuplemento.UseVisualStyleBackColor = true;
            this.CargarSuplemento.Click += new System.EventHandler(this.buttonCargarSuplemento_Click);
            // 
            // EliminarSuplemento
            // 
            this.EliminarSuplemento.BackgroundImage = global::Soria.Federico._2A.TP4.Properties.Resources.pharma;
            this.EliminarSuplemento.Location = new System.Drawing.Point(195, 413);
            this.EliminarSuplemento.Name = "EliminarSuplemento";
            this.EliminarSuplemento.Size = new System.Drawing.Size(130, 25);
            this.EliminarSuplemento.TabIndex = 23;
            this.EliminarSuplemento.Text = "Eliminar suplemento";
            this.EliminarSuplemento.UseVisualStyleBackColor = true;
            this.EliminarSuplemento.Click += new System.EventHandler(this.buttonEliminarSuplemento_Click);
            // 
            // ModificarSuplemento
            // 
            this.ModificarSuplemento.BackgroundImage = global::Soria.Federico._2A.TP4.Properties.Resources.pharma;
            this.ModificarSuplemento.Location = new System.Drawing.Point(195, 445);
            this.ModificarSuplemento.Name = "ModificarSuplemento";
            this.ModificarSuplemento.Size = new System.Drawing.Size(130, 25);
            this.ModificarSuplemento.TabIndex = 24;
            this.ModificarSuplemento.Text = "Modificar suplemento";
            this.ModificarSuplemento.UseVisualStyleBackColor = true;
            this.ModificarSuplemento.Click += new System.EventHandler(this.buttonModificarSuplemento_Click);
            // 
            // labelMedicamentos
            // 
            this.labelMedicamentos.AutoSize = true;
            this.labelMedicamentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMedicamentos.Location = new System.Drawing.Point(35, 8);
            this.labelMedicamentos.Name = "labelMedicamentos";
            this.labelMedicamentos.Size = new System.Drawing.Size(164, 25);
            this.labelMedicamentos.TabIndex = 25;
            this.labelMedicamentos.Text = "Medicamentos";
            // 
            // labelSuplementos
            // 
            this.labelSuplementos.AutoSize = true;
            this.labelSuplementos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSuplementos.Location = new System.Drawing.Point(35, 197);
            this.labelSuplementos.Name = "labelSuplementos";
            this.labelSuplementos.Size = new System.Drawing.Size(148, 25);
            this.labelSuplementos.TabIndex = 26;
            this.labelSuplementos.Text = "Suplementos";
            // 
            // buttonDeserializar
            // 
            this.buttonDeserializar.Location = new System.Drawing.Point(344, 413);
            this.buttonDeserializar.Name = "buttonDeserializar";
            this.buttonDeserializar.Size = new System.Drawing.Size(130, 25);
            this.buttonDeserializar.TabIndex = 27;
            this.buttonDeserializar.Text = "Deserializar stock";
            this.buttonDeserializar.UseVisualStyleBackColor = true;
            this.buttonDeserializar.Click += new System.EventHandler(this.buttonDeserializar_Click);
            // 
            // labelContador
            // 
            this.labelContador.AutoSize = true;
            this.labelContador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContador.Location = new System.Drawing.Point(624, 454);
            this.labelContador.Name = "labelContador";
            this.labelContador.Size = new System.Drawing.Size(16, 16);
            this.labelContador.TabIndex = 28;
            this.labelContador.Text = "0";
            // 
            // labelVentas
            // 
            this.labelVentas.AutoSize = true;
            this.labelVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVentas.Location = new System.Drawing.Point(493, 453);
            this.labelVentas.Name = "labelVentas";
            this.labelVentas.Size = new System.Drawing.Size(125, 15);
            this.labelVentas.TabIndex = 29;
            this.labelVentas.Text = "Ventas realizadas:";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Soria.Federico._2A.TP4.Properties.Resources.pharma;
            this.ClientSize = new System.Drawing.Size(659, 481);
            this.Controls.Add(this.labelVentas);
            this.Controls.Add(this.labelContador);
            this.Controls.Add(this.buttonDeserializar);
            this.Controls.Add(this.labelSuplementos);
            this.Controls.Add(this.labelMedicamentos);
            this.Controls.Add(this.ModificarSuplemento);
            this.Controls.Add(this.EliminarSuplemento);
            this.Controls.Add(this.CargarSuplemento);
            this.Controls.Add(this.dataGridSuplementos);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelFecha);
            this.Controls.Add(this.buttonVender);
            this.Controls.Add(this.Sincronizar);
            this.Controls.Add(this.buttonModificarMedicamento);
            this.Controls.Add(this.SerializarStock);
            this.Controls.Add(this.buttonEliminarMedicamento);
            this.Controls.Add(this.buttonCargarMedicamento);
            this.Controls.Add(this.dataGridMedicamentos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrincipal";
            this.Text = "Farmacia";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMedicamentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSuplementos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridMedicamentos;
        private System.Windows.Forms.Button buttonCargarMedicamento;
        private System.Windows.Forms.Button buttonEliminarMedicamento;
        private System.Windows.Forms.Button SerializarStock;
        private System.Windows.Forms.Button buttonModificarMedicamento;
        private System.Windows.Forms.Button Sincronizar;
        private System.Windows.Forms.Button buttonVender;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.DataGridView dataGridSuplementos;
        private System.Windows.Forms.Button CargarSuplemento;
        private System.Windows.Forms.Button EliminarSuplemento;
        private System.Windows.Forms.Button ModificarSuplemento;
        private System.Windows.Forms.Label labelMedicamentos;
        private System.Windows.Forms.Label labelSuplementos;
        private System.Windows.Forms.Button buttonDeserializar;
        private System.Windows.Forms.Label labelContador;
        private System.Windows.Forms.Label labelVentas;
    }
}

