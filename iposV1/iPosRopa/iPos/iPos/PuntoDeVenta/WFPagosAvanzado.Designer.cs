namespace iPos
{
    partial class WFPagosAvanzado
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
            this.components = new System.ComponentModel.Container();
            this.BTGuardar = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.TBReferencia = new System.Windows.Forms.TextBox();
            this.ComboBanco = new System.Windows.Forms.ComboBoxFB();
            this.label14 = new System.Windows.Forms.Label();
            this.PA_ABONOLabel = new System.Windows.Forms.Label();
            this.PA_ABONOTextBox = new System.Windows.Forms.NumericTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.FormaPagoComboBox = new System.Windows.Forms.ComboBox();
            this.BtnAvanzado = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dSPuntoDeVentaAux2 = new iPos.PuntoDeVenta.DSPuntoDeVentaAux2();
            this.pAGOSAVANZADOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pAGOSAVANZADODataGridView = new System.Windows.Forms.DataGridView();
            this.DGCONSECUTIVO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGMONTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGFORMAPAGOID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGFORMAPAGONOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGBANCONOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGBANCOID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGREFERENCIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGELIMINAR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoDeVentaAux2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAGOSAVANZADOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAGOSAVANZADODataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // BTGuardar
            // 
            this.BTGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.BTGuardar.ForeColor = System.Drawing.Color.White;
            this.BTGuardar.Location = new System.Drawing.Point(335, 407);
            this.BTGuardar.Name = "BTGuardar";
            this.BTGuardar.Size = new System.Drawing.Size(129, 26);
            this.BTGuardar.TabIndex = 85;
            this.BTGuardar.Text = "Aplicar pagos";
            this.BTGuardar.UseVisualStyleBackColor = false;
            this.BTGuardar.Click += new System.EventHandler(this.BTGuardar_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(349, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 16);
            this.label11.TabIndex = 55;
            this.label11.Text = "Banco:";
            // 
            // TBReferencia
            // 
            this.TBReferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBReferencia.Location = new System.Drawing.Point(492, 112);
            this.TBReferencia.Name = "TBReferencia";
            this.TBReferencia.Size = new System.Drawing.Size(202, 24);
            this.TBReferencia.TabIndex = 78;
            // 
            // ComboBanco
            // 
            this.ComboBanco.Condicion = null;
            this.ComboBanco.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ComboBanco.DisplayMember = "nombre";
            this.ComboBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBanco.FormattingEnabled = true;
            this.ComboBanco.IndiceCampoSelector = 0;
            this.ComboBanco.LabelDescription = null;
            this.ComboBanco.Location = new System.Drawing.Point(352, 112);
            this.ComboBanco.Name = "ComboBanco";
            this.ComboBanco.NombreCampoSelector = "id";
            this.ComboBanco.Query = "select id,nombre from bancos";
            this.ComboBanco.QueryDeSeleccion = "select id,nombre from bancos where   id = @id";
            this.ComboBanco.SelectedDataDisplaying = null;
            this.ComboBanco.SelectedDataValue = null;
            this.ComboBanco.Size = new System.Drawing.Size(134, 26);
            this.ComboBanco.TabIndex = 77;
            this.ComboBanco.ValueMember = "id";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(501, 93);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 16);
            this.label14.TabIndex = 56;
            this.label14.Text = "Referencia:";
            // 
            // PA_ABONOLabel
            // 
            this.PA_ABONOLabel.AutoSize = true;
            this.PA_ABONOLabel.BackColor = System.Drawing.Color.Transparent;
            this.PA_ABONOLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PA_ABONOLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PA_ABONOLabel.Location = new System.Drawing.Point(0, 96);
            this.PA_ABONOLabel.Name = "PA_ABONOLabel";
            this.PA_ABONOLabel.Size = new System.Drawing.Size(54, 16);
            this.PA_ABONOLabel.TabIndex = 80;
            this.PA_ABONOLabel.Text = "Monto:";
            // 
            // PA_ABONOTextBox
            // 
            this.PA_ABONOTextBox.AllowNegative = true;
            this.PA_ABONOTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PA_ABONOTextBox.Format_Expression = null;
            this.PA_ABONOTextBox.Location = new System.Drawing.Point(3, 114);
            this.PA_ABONOTextBox.Name = "PA_ABONOTextBox";
            this.PA_ABONOTextBox.NumericPrecision = 17;
            this.PA_ABONOTextBox.NumericScaleOnFocus = 2;
            this.PA_ABONOTextBox.NumericScaleOnLostFocus = 2;
            this.PA_ABONOTextBox.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PA_ABONOTextBox.Size = new System.Drawing.Size(115, 24);
            this.PA_ABONOTextBox.TabIndex = 83;
            this.PA_ABONOTextBox.Tag = 34;
            this.PA_ABONOTextBox.Text = "0.00";
            this.PA_ABONOTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PA_ABONOTextBox.ValidationExpression = null;
            this.PA_ABONOTextBox.ZeroIsValid = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label10.Location = new System.Drawing.Point(123, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 16);
            this.label10.TabIndex = 81;
            this.label10.Text = "Forma de pago:";
            // 
            // FormaPagoComboBox
            // 
            this.FormaPagoComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormaPagoComboBox.FormattingEnabled = true;
            this.FormaPagoComboBox.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta de credito",
            "Tarjeta de debito",
            "Tarjeta de servicio",
            "Cheque nominativo",
            "Vales de despensa",
            "Transferencia electronica de fondos",
            "Intercambio de mercancia",
            "Otros",
            "Deposito",
            "Deposito a terceros"});
            this.FormaPagoComboBox.Location = new System.Drawing.Point(126, 112);
            this.FormaPagoComboBox.Name = "FormaPagoComboBox";
            this.FormaPagoComboBox.Size = new System.Drawing.Size(220, 26);
            this.FormaPagoComboBox.TabIndex = 84;
            this.FormaPagoComboBox.SelectedIndexChanged += new System.EventHandler(this.FormaPagoComboBox_SelectedIndexChanged);
            // 
            // BtnAvanzado
            // 
            this.BtnAvanzado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BtnAvanzado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BtnAvanzado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAvanzado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAvanzado.ForeColor = System.Drawing.Color.White;
            this.BtnAvanzado.Location = new System.Drawing.Point(706, 97);
            this.BtnAvanzado.Name = "BtnAvanzado";
            this.BtnAvanzado.Size = new System.Drawing.Size(89, 46);
            this.BtnAvanzado.TabIndex = 94;
            this.BtnAvanzado.Text = "AGREGAR";
            this.BtnAvanzado.UseVisualStyleBackColor = false;
            this.BtnAvanzado.Click += new System.EventHandler(this.BtnAvanzado_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.TBReferencia);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ComboBanco);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.BtnAvanzado);
            this.panel1.Controls.Add(this.lblSaldo);
            this.panel1.Controls.Add(this.FormaPagoComboBox);
            this.panel1.Controls.Add(this.PA_ABONOTextBox);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.PA_ABONOLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 162);
            this.panel1.TabIndex = 95;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(572, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 97;
            this.label3.Text = "Faltante:";
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.BackColor = System.Drawing.Color.Transparent;
            this.lblSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblSaldo.Location = new System.Drawing.Point(659, 43);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(24, 20);
            this.lblSaldo.TabIndex = 98;
            this.lblSaldo.Text = "...";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(393, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 20);
            this.label8.TabIndex = 95;
            this.label8.Text = "Total:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTotal.Location = new System.Drawing.Point(453, 41);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(24, 20);
            this.lblTotal.TabIndex = 96;
            this.lblTotal.Text = "...";
            // 
            // dSPuntoDeVentaAux2
            // 
            this.dSPuntoDeVentaAux2.DataSetName = "DSPuntoDeVentaAux2";
            this.dSPuntoDeVentaAux2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pAGOSAVANZADOBindingSource
            // 
            this.pAGOSAVANZADOBindingSource.DataMember = "PAGOSAVANZADO";
            this.pAGOSAVANZADOBindingSource.DataSource = this.dSPuntoDeVentaAux2;
            // 
            // pAGOSAVANZADODataGridView
            // 
            this.pAGOSAVANZADODataGridView.AllowUserToAddRows = false;
            this.pAGOSAVANZADODataGridView.AutoGenerateColumns = false;
            this.pAGOSAVANZADODataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pAGOSAVANZADODataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGCONSECUTIVO,
            this.DGMONTO,
            this.DGFORMAPAGOID,
            this.DGFORMAPAGONOMBRE,
            this.DGBANCONOMBRE,
            this.DGBANCOID,
            this.DGREFERENCIA,
            this.DGELIMINAR});
            this.pAGOSAVANZADODataGridView.DataSource = this.pAGOSAVANZADOBindingSource;
            this.pAGOSAVANZADODataGridView.Location = new System.Drawing.Point(3, 168);
            this.pAGOSAVANZADODataGridView.Name = "pAGOSAVANZADODataGridView";
            this.pAGOSAVANZADODataGridView.RowHeadersVisible = false;
            this.pAGOSAVANZADODataGridView.Size = new System.Drawing.Size(778, 220);
            this.pAGOSAVANZADODataGridView.TabIndex = 97;
            this.pAGOSAVANZADODataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pAGOSAVANZADODataGridView_CellContentClick);
            // 
            // DGCONSECUTIVO
            // 
            this.DGCONSECUTIVO.DataPropertyName = "CONSECUTIVO";
            this.DGCONSECUTIVO.HeaderText = "CONSECUTIVO";
            this.DGCONSECUTIVO.Name = "DGCONSECUTIVO";
            this.DGCONSECUTIVO.Width = 40;
            // 
            // DGMONTO
            // 
            this.DGMONTO.DataPropertyName = "MONTO";
            this.DGMONTO.HeaderText = "MONTO";
            this.DGMONTO.Name = "DGMONTO";
            // 
            // DGFORMAPAGOID
            // 
            this.DGFORMAPAGOID.DataPropertyName = "FORMAPAGOID";
            this.DGFORMAPAGOID.HeaderText = "FORMAPAGOID";
            this.DGFORMAPAGOID.Name = "DGFORMAPAGOID";
            this.DGFORMAPAGOID.Visible = false;
            // 
            // DGFORMAPAGONOMBRE
            // 
            this.DGFORMAPAGONOMBRE.DataPropertyName = "FORMAPAGONOMBRE";
            this.DGFORMAPAGONOMBRE.HeaderText = "FORMA PAGO";
            this.DGFORMAPAGONOMBRE.Name = "DGFORMAPAGONOMBRE";
            this.DGFORMAPAGONOMBRE.Width = 150;
            // 
            // DGBANCONOMBRE
            // 
            this.DGBANCONOMBRE.DataPropertyName = "BANCONOMBRE";
            this.DGBANCONOMBRE.HeaderText = "BANCO";
            this.DGBANCONOMBRE.Name = "DGBANCONOMBRE";
            this.DGBANCONOMBRE.Width = 120;
            // 
            // DGBANCOID
            // 
            this.DGBANCOID.DataPropertyName = "BANCOID";
            this.DGBANCOID.HeaderText = "BANCOID";
            this.DGBANCOID.Name = "DGBANCOID";
            // 
            // DGREFERENCIA
            // 
            this.DGREFERENCIA.DataPropertyName = "REFERENCIA";
            this.DGREFERENCIA.HeaderText = "REFERENCIA";
            this.DGREFERENCIA.Name = "DGREFERENCIA";
            this.DGREFERENCIA.Width = 120;
            // 
            // DGELIMINAR
            // 
            this.DGELIMINAR.HeaderText = "";
            this.DGELIMINAR.Name = "DGELIMINAR";
            this.DGELIMINAR.Text = "Borrar";
            this.DGELIMINAR.UseColumnTextForButtonValue = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(633, 407);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(129, 26);
            this.btnCancelar.TabIndex = 98;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // WFPagosAvanzado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(804, 445);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pAGOSAVANZADODataGridView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BTGuardar);
            this.Name = "WFPagosAvanzado";
            this.Text = "Pagos avanzado";
            this.Load += new System.EventHandler(this.WFPagosAvanzado_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoDeVentaAux2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAGOSAVANZADOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAGOSAVANZADODataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTGuardar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TBReferencia;
        private System.Windows.Forms.ComboBoxFB ComboBanco;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label PA_ABONOLabel;
        private System.Windows.Forms.NumericTextBox PA_ABONOTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox FormaPagoComboBox;
        private System.Windows.Forms.Button BtnAvanzado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotal;
        private PuntoDeVenta.DSPuntoDeVentaAux2 dSPuntoDeVentaAux2;
        private System.Windows.Forms.BindingSource pAGOSAVANZADOBindingSource;
        private System.Windows.Forms.DataGridView pAGOSAVANZADODataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCONSECUTIVO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGMONTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGFORMAPAGOID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGFORMAPAGONOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGBANCONOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGBANCOID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGREFERENCIA;
        private System.Windows.Forms.DataGridViewButtonColumn DGELIMINAR;
        private System.Windows.Forms.Button btnCancelar;
    }
}