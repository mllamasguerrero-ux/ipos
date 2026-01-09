namespace iPos.Abonos
{
    partial class WFMotivoCambioFecApl
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
            this.DTPFechaAplicado = new System.Windows.Forms.DateTimePicker();
            this.lblFechaAplicado = new System.Windows.Forms.Label();
            this.lblCuentaRecep = new System.Windows.Forms.Label();
            this.MOTIVOComboBox = new System.Windows.Forms.ComboBoxFB();
            this.BTContinuar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DTPFechaAplicado
            // 
            this.DTPFechaAplicado.CustomFormat = "dd/MM/yyyy";
            this.DTPFechaAplicado.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPFechaAplicado.Location = new System.Drawing.Point(163, 66);
            this.DTPFechaAplicado.Name = "DTPFechaAplicado";
            this.DTPFechaAplicado.Size = new System.Drawing.Size(99, 20);
            this.DTPFechaAplicado.TabIndex = 89;
            // 
            // lblFechaAplicado
            // 
            this.lblFechaAplicado.AutoSize = true;
            this.lblFechaAplicado.BackColor = System.Drawing.Color.Transparent;
            this.lblFechaAplicado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaAplicado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFechaAplicado.Location = new System.Drawing.Point(43, 70);
            this.lblFechaAplicado.Name = "lblFechaAplicado";
            this.lblFechaAplicado.Size = new System.Drawing.Size(91, 16);
            this.lblFechaAplicado.TabIndex = 88;
            this.lblFechaAplicado.Text = "F. Aplicado:";
            // 
            // lblCuentaRecep
            // 
            this.lblCuentaRecep.AutoSize = true;
            this.lblCuentaRecep.BackColor = System.Drawing.Color.Transparent;
            this.lblCuentaRecep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuentaRecep.ForeColor = System.Drawing.Color.White;
            this.lblCuentaRecep.Location = new System.Drawing.Point(43, 104);
            this.lblCuentaRecep.Name = "lblCuentaRecep";
            this.lblCuentaRecep.Size = new System.Drawing.Size(58, 16);
            this.lblCuentaRecep.TabIndex = 90;
            this.lblCuentaRecep.Text = "Motivo:";
            // 
            // MOTIVOComboBox
            // 
            this.MOTIVOComboBox.Condicion = null;
            this.MOTIVOComboBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.MOTIVOComboBox.DisplayMember = "descripcion";
            this.MOTIVOComboBox.FormattingEnabled = true;
            this.MOTIVOComboBox.IndiceCampoSelector = 0;
            this.MOTIVOComboBox.LabelDescription = null;
            this.MOTIVOComboBox.Location = new System.Drawing.Point(163, 103);
            this.MOTIVOComboBox.Name = "MOTIVOComboBox";
            this.MOTIVOComboBox.NombreCampoSelector = "id";
            this.MOTIVOComboBox.Query = "select id,descripcion from MOTIVO_CAMFEC";
            this.MOTIVOComboBox.QueryDeSeleccion = "select id,descripcion from MOTIVO_CAMFEC where   id = @id";
            this.MOTIVOComboBox.SelectedDataDisplaying = null;
            this.MOTIVOComboBox.SelectedDataValue = null;
            this.MOTIVOComboBox.Size = new System.Drawing.Size(272, 21);
            this.MOTIVOComboBox.TabIndex = 91;
            this.MOTIVOComboBox.ValueMember = "id";
            // 
            // BTContinuar
            // 
            this.BTContinuar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTContinuar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTContinuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.BTContinuar.ForeColor = System.Drawing.Color.White;
            this.BTContinuar.Location = new System.Drawing.Point(174, 153);
            this.BTContinuar.Name = "BTContinuar";
            this.BTContinuar.Size = new System.Drawing.Size(123, 27);
            this.BTContinuar.TabIndex = 92;
            this.BTContinuar.Text = "Continuar";
            this.BTContinuar.UseVisualStyleBackColor = false;
            this.BTContinuar.Click += new System.EventHandler(this.BTContinuar_Click);
            // 
            // WFMotivoCambioFecApl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(461, 261);
            this.Controls.Add(this.BTContinuar);
            this.Controls.Add(this.lblCuentaRecep);
            this.Controls.Add(this.MOTIVOComboBox);
            this.Controls.Add(this.DTPFechaAplicado);
            this.Controls.Add(this.lblFechaAplicado);
            this.Name = "WFMotivoCambioFecApl";
            this.Text = "Motivo de cambio de fecha de aplicacion";
            this.Load += new System.EventHandler(this.WFMotivoCambioFecApl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DTPFechaAplicado;
        private System.Windows.Forms.Label lblFechaAplicado;
        private System.Windows.Forms.Label lblCuentaRecep;
        private System.Windows.Forms.ComboBoxFB MOTIVOComboBox;
        private System.Windows.Forms.Button BTContinuar;
    }
}