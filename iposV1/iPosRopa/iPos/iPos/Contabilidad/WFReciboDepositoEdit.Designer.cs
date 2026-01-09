namespace iPos
{
    partial class WFReciboDepositoEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFReciboDepositoEdit));
            this.dSContabilidad = new iPos.Contabilidad.DSContabilidad();
            this.tableAdapterManager = new iPos.Contabilidad.DSContabilidadTableAdapters.TableAdapterManager();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.TBMonto = new System.Windows.Forms.NumericTextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.pnlCorteSeleccion = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.CBCorteActual = new System.Windows.Forms.CheckBox();
            this.LBFolio = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DTPFecha = new System.Windows.Forms.DateTimePicker();
            this.CBCajero = new System.Windows.Forms.ComboBoxFB();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TBNotas = new System.Windows.Forms.TextBox();
            this.dEPOSITOSIMPRESIONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dEPOSITOSIMPRESIONTableAdapter = new iPos.Contabilidad.DSContabilidadTableAdapters.DEPOSITOSIMPRESIONTableAdapter();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.pnlEdicion = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dSContabilidad)).BeginInit();
            this.pnlCorteSeleccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dEPOSITOSIMPRESIONBindingSource)).BeginInit();
            this.pnlEdicion.SuspendLayout();
            this.SuspendLayout();
            // 
            // dSContabilidad
            // 
            this.dSContabilidad.DataSetName = "DSContabilidad";
            this.dSContabilidad.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Contabilidad.DSContabilidadTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(447, 240);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(108, 30);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = global::iPos.Properties.Resources.saveNoBack_J;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(142, 240);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(109, 32);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // TBMonto
            // 
            this.TBMonto.AllowNegative = true;
            this.TBMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBMonto.Format_Expression = null;
            this.TBMonto.Location = new System.Drawing.Point(88, 153);
            this.TBMonto.Name = "TBMonto";
            this.TBMonto.NumericPrecision = 12;
            this.TBMonto.NumericScaleOnFocus = 2;
            this.TBMonto.NumericScaleOnLostFocus = 2;
            this.TBMonto.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TBMonto.Size = new System.Drawing.Size(120, 24);
            this.TBMonto.TabIndex = 6;
            this.TBMonto.Tag = 34;
            this.TBMonto.Text = "0.00";
            this.TBMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBMonto.ValidationExpression = null;
            this.TBMonto.ZeroIsValid = true;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.BackColor = System.Drawing.Color.Transparent;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblCantidad.Location = new System.Drawing.Point(36, 159);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(46, 13);
            this.lblCantidad.TabIndex = 162;
            this.lblCantidad.Text = "Monto:";
            // 
            // pnlCorteSeleccion
            // 
            this.pnlCorteSeleccion.BackColor = System.Drawing.Color.Transparent;
            this.pnlCorteSeleccion.Controls.Add(this.label4);
            this.pnlCorteSeleccion.Controls.Add(this.CBCorteActual);
            this.pnlCorteSeleccion.Location = new System.Drawing.Point(406, 41);
            this.pnlCorteSeleccion.Name = "pnlCorteSeleccion";
            this.pnlCorteSeleccion.Size = new System.Drawing.Size(123, 25);
            this.pnlCorteSeleccion.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Corte Actual:";
            // 
            // CBCorteActual
            // 
            this.CBCorteActual.AutoSize = true;
            this.CBCorteActual.Checked = true;
            this.CBCorteActual.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBCorteActual.Location = new System.Drawing.Point(90, 6);
            this.CBCorteActual.Name = "CBCorteActual";
            this.CBCorteActual.Size = new System.Drawing.Size(15, 14);
            this.CBCorteActual.TabIndex = 3;
            this.CBCorteActual.UseVisualStyleBackColor = true;
            // 
            // LBFolio
            // 
            this.LBFolio.AutoSize = true;
            this.LBFolio.BackColor = System.Drawing.Color.Transparent;
            this.LBFolio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LBFolio.Location = new System.Drawing.Point(85, 9);
            this.LBFolio.Name = "LBFolio";
            this.LBFolio.Size = new System.Drawing.Size(16, 13);
            this.LBFolio.TabIndex = 23;
            this.LBFolio.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(44, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Folio:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(3, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Fecha corte:";
            // 
            // DTPFecha
            // 
            this.DTPFecha.AccessibleDescription = "resizeforscreen";
            this.DTPFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPFecha.Location = new System.Drawing.Point(88, 40);
            this.DTPFecha.Name = "DTPFecha";
            this.DTPFecha.Size = new System.Drawing.Size(273, 20);
            this.DTPFecha.TabIndex = 1;
            this.DTPFecha.Validating += new System.ComponentModel.CancelEventHandler(this.DTPFecha_Validating);
            // 
            // CBCajero
            // 
            this.CBCajero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.CBCajero.Condicion = null;
            this.CBCajero.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.CBCajero.DisplayMember = "NOMBRE";
            this.CBCajero.FormattingEnabled = true;
            this.CBCajero.IndiceCampoSelector = 0;
            this.CBCajero.LabelDescription = null;
            this.CBCajero.Location = new System.Drawing.Point(478, 4);
            this.CBCajero.Name = "CBCajero";
            this.CBCajero.NombreCampoSelector = null;
            this.CBCajero.Query = "select ID,USERNAME as NOMBRE from persona where ACTIVO = \'S\' and username is not " +
    "null";
            this.CBCajero.QueryDeSeleccion = null;
            this.CBCajero.SelectedDataDisplaying = null;
            this.CBCajero.SelectedDataValue = null;
            this.CBCajero.Size = new System.Drawing.Size(182, 21);
            this.CBCajero.TabIndex = 164;
            this.CBCajero.ValueMember = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(409, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 163;
            this.label3.Text = "Cajero:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(38, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 165;
            this.label2.Text = "Notas:";
            // 
            // TBNotas
            // 
            this.TBNotas.Location = new System.Drawing.Point(88, 90);
            this.TBNotas.MaxLength = 255;
            this.TBNotas.Multiline = true;
            this.TBNotas.Name = "TBNotas";
            this.TBNotas.Size = new System.Drawing.Size(273, 48);
            this.TBNotas.TabIndex = 166;
            // 
            // dEPOSITOSIMPRESIONBindingSource
            // 
            this.dEPOSITOSIMPRESIONBindingSource.DataMember = "DEPOSITOSIMPRESION";
            this.dEPOSITOSIMPRESIONBindingSource.DataSource = this.dSContabilidad;
            // 
            // dEPOSITOSIMPRESIONTableAdapter
            // 
            this.dEPOSITOSIMPRESIONTableAdapter.ClearBeforeFill = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(301, 240);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(108, 30);
            this.btnImprimir.TabIndex = 167;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Visible = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // pnlEdicion
            // 
            this.pnlEdicion.BackColor = System.Drawing.Color.Transparent;
            this.pnlEdicion.Controls.Add(this.label1);
            this.pnlEdicion.Controls.Add(this.DTPFecha);
            this.pnlEdicion.Controls.Add(this.label2);
            this.pnlEdicion.Controls.Add(this.label5);
            this.pnlEdicion.Controls.Add(this.TBNotas);
            this.pnlEdicion.Controls.Add(this.LBFolio);
            this.pnlEdicion.Controls.Add(this.CBCajero);
            this.pnlEdicion.Controls.Add(this.pnlCorteSeleccion);
            this.pnlEdicion.Controls.Add(this.label3);
            this.pnlEdicion.Controls.Add(this.lblCantidad);
            this.pnlEdicion.Controls.Add(this.TBMonto);
            this.pnlEdicion.Location = new System.Drawing.Point(2, 6);
            this.pnlEdicion.Name = "pnlEdicion";
            this.pnlEdicion.Size = new System.Drawing.Size(689, 222);
            this.pnlEdicion.TabIndex = 168;
            // 
            // WFReciboDepositoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(694, 284);
            this.Controls.Add(this.pnlEdicion);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFReciboDepositoEdit";
            this.Text = "Deposito";
            this.Load += new System.EventHandler(this.WFReciboDepositoEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSContabilidad)).EndInit();
            this.pnlCorteSeleccion.ResumeLayout(false);
            this.pnlCorteSeleccion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dEPOSITOSIMPRESIONBindingSource)).EndInit();
            this.pnlEdicion.ResumeLayout(false);
            this.pnlEdicion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox CBCorteActual;
        private System.Windows.Forms.DateTimePicker DTPFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LBFolio;
        private System.Windows.Forms.Panel pnlCorteSeleccion;
        private System.Windows.Forms.NumericTextBox TBMonto;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnGuardar;
        private Contabilidad.DSContabilidad dSContabilidad;
        private Contabilidad.DSContabilidadTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBoxFB CBCajero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBNotas;
        private System.Windows.Forms.BindingSource dEPOSITOSIMPRESIONBindingSource;
        private Contabilidad.DSContabilidadTableAdapters.DEPOSITOSIMPRESIONTableAdapter dEPOSITOSIMPRESIONTableAdapter;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Panel pnlEdicion;
    }
}