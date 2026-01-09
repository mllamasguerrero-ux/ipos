namespace iPos
{
    partial class WFRetiros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFRetiros));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PNLSupervisor = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.ComboSupervisor = new System.Windows.Forms.ComboBoxFB();
            this.PNLPagoAProveedor = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.DTFecha = new System.Windows.Forms.DateTimePicker();
            this.TBFactura = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboProveedor = new System.Windows.Forms.ComboBoxFB();
            this.RBSupervisor = new System.Windows.Forms.RadioButton();
            this.RBPagoAProveedor = new System.Windows.Forms.RadioButton();
            this.TBNotas = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TBImporte = new System.Windows.Forms.NumericTextBox();
            this.dSSalidas = new iPos.Salidas.DSSalidas();
            this.rETIROSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rETIROSTableAdapter = new iPos.Salidas.DSSalidasTableAdapters.RETIROSTableAdapter();
            this.tableAdapterManager = new iPos.Salidas.DSSalidasTableAdapters.TableAdapterManager();
            this.groupBox1.SuspendLayout();
            this.PNLSupervisor.SuspendLayout();
            this.PNLPagoAProveedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSSalidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rETIROSBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.PNLSupervisor);
            this.groupBox1.Controls.Add(this.PNLPagoAProveedor);
            this.groupBox1.Controls.Add(this.RBSupervisor);
            this.groupBox1.Controls.Add(this.RBPagoAProveedor);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Location = new System.Drawing.Point(26, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(640, 191);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TIPO DE RETIRO";
            // 
            // PNLSupervisor
            // 
            this.PNLSupervisor.Controls.Add(this.label4);
            this.PNLSupervisor.Controls.Add(this.ComboSupervisor);
            this.PNLSupervisor.Enabled = false;
            this.PNLSupervisor.Location = new System.Drawing.Point(176, 149);
            this.PNLSupervisor.Name = "PNLSupervisor";
            this.PNLSupervisor.Size = new System.Drawing.Size(443, 36);
            this.PNLSupervisor.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Supervisor:";
            // 
            // ComboSupervisor
            // 
            this.ComboSupervisor.Condicion = null;
            this.ComboSupervisor.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ComboSupervisor.DisplayMember = "nombre";
            this.ComboSupervisor.FormattingEnabled = true;
            this.ComboSupervisor.IndiceCampoSelector = 0;
            this.ComboSupervisor.LabelDescription = null;
            this.ComboSupervisor.Location = new System.Drawing.Point(143, 8);
            this.ComboSupervisor.Name = "ComboSupervisor";
            this.ComboSupervisor.NombreCampoSelector = "id";
            this.ComboSupervisor.Query = "select p.id,p.nombre from persona p inner join usuario_perfil u on u.up_personaid" +
    " = p.id where p.tipopersonaid = 20 and u.up_perfil = 11 group by p.id, p.nombre";
            this.ComboSupervisor.QueryDeSeleccion = "select id,nombre from persona where tipopersonaid = 20 and  id = @id";
            this.ComboSupervisor.SelectedDataDisplaying = null;
            this.ComboSupervisor.SelectedDataValue = null;
            this.ComboSupervisor.Size = new System.Drawing.Size(273, 21);
            this.ComboSupervisor.TabIndex = 6;
            this.ComboSupervisor.ValueMember = "id";
            // 
            // PNLPagoAProveedor
            // 
            this.PNLPagoAProveedor.Controls.Add(this.label3);
            this.PNLPagoAProveedor.Controls.Add(this.DTFecha);
            this.PNLPagoAProveedor.Controls.Add(this.TBFactura);
            this.PNLPagoAProveedor.Controls.Add(this.label2);
            this.PNLPagoAProveedor.Controls.Add(this.label1);
            this.PNLPagoAProveedor.Controls.Add(this.ComboProveedor);
            this.PNLPagoAProveedor.Location = new System.Drawing.Point(176, 22);
            this.PNLPagoAProveedor.Name = "PNLPagoAProveedor";
            this.PNLPagoAProveedor.Size = new System.Drawing.Size(443, 110);
            this.PNLPagoAProveedor.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Fecha factura:";
            // 
            // DTFecha
            // 
            this.DTFecha.Location = new System.Drawing.Point(143, 69);
            this.DTFecha.Name = "DTFecha";
            this.DTFecha.Size = new System.Drawing.Size(273, 20);
            this.DTFecha.TabIndex = 5;
            // 
            // TBFactura
            // 
            this.TBFactura.Location = new System.Drawing.Point(143, 38);
            this.TBFactura.Name = "TBFactura";
            this.TBFactura.Size = new System.Drawing.Size(273, 20);
            this.TBFactura.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Factura:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Proveedor:";
            // 
            // ComboProveedor
            // 
            this.ComboProveedor.Condicion = null;
            this.ComboProveedor.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ComboProveedor.DisplayMember = "nombre";
            this.ComboProveedor.FormattingEnabled = true;
            this.ComboProveedor.IndiceCampoSelector = 0;
            this.ComboProveedor.LabelDescription = null;
            this.ComboProveedor.Location = new System.Drawing.Point(143, 7);
            this.ComboProveedor.Name = "ComboProveedor";
            this.ComboProveedor.NombreCampoSelector = "id";
            this.ComboProveedor.Query = "select id,nombre from persona where tipopersonaid = 40";
            this.ComboProveedor.QueryDeSeleccion = "select id,nombre from persona where tipopersonaid = 40 and  id = @id";
            this.ComboProveedor.SelectedDataDisplaying = null;
            this.ComboProveedor.SelectedDataValue = null;
            this.ComboProveedor.Size = new System.Drawing.Size(273, 21);
            this.ComboProveedor.TabIndex = 3;
            this.ComboProveedor.ValueMember = "id";
            // 
            // RBSupervisor
            // 
            this.RBSupervisor.AutoSize = true;
            this.RBSupervisor.Location = new System.Drawing.Point(10, 161);
            this.RBSupervisor.Name = "RBSupervisor";
            this.RBSupervisor.Size = new System.Drawing.Size(106, 17);
            this.RBSupervisor.TabIndex = 2;
            this.RBSupervisor.Text = "Del supervisor";
            this.RBSupervisor.UseVisualStyleBackColor = true;
            // 
            // RBPagoAProveedor
            // 
            this.RBPagoAProveedor.AutoSize = true;
            this.RBPagoAProveedor.Checked = true;
            this.RBPagoAProveedor.Location = new System.Drawing.Point(10, 33);
            this.RBPagoAProveedor.Name = "RBPagoAProveedor";
            this.RBPagoAProveedor.Size = new System.Drawing.Size(126, 17);
            this.RBPagoAProveedor.TabIndex = 1;
            this.RBPagoAProveedor.TabStop = true;
            this.RBPagoAProveedor.Text = "Pago a proveedor";
            this.RBPagoAProveedor.UseVisualStyleBackColor = true;
            this.RBPagoAProveedor.CheckedChanged += new System.EventHandler(this.RBPagoAProveedor_CheckedChanged);
            // 
            // TBNotas
            // 
            this.TBNotas.Location = new System.Drawing.Point(345, 209);
            this.TBNotas.MaxLength = 255;
            this.TBNotas.Multiline = true;
            this.TBNotas.Name = "TBNotas";
            this.TBNotas.Size = new System.Drawing.Size(273, 48);
            this.TBNotas.TabIndex = 7;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.Location = new System.Drawing.Point(345, 309);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(164, 23);
            this.btnEnviar.TabIndex = 9;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(295, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Notas:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(278, 279);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Cantidad:";
            // 
            // TBImporte
            // 
            this.TBImporte.AllowNegative = true;
            this.TBImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBImporte.Format_Expression = null;
            this.TBImporte.Location = new System.Drawing.Point(345, 272);
            this.TBImporte.Name = "TBImporte";
            this.TBImporte.NumericPrecision = 12;
            this.TBImporte.NumericScaleOnFocus = 2;
            this.TBImporte.NumericScaleOnLostFocus = 2;
            this.TBImporte.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TBImporte.Size = new System.Drawing.Size(164, 24);
            this.TBImporte.TabIndex = 8;
            this.TBImporte.Tag = 34;
            this.TBImporte.Text = "0";
            this.TBImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBImporte.ValidationExpression = null;
            this.TBImporte.ZeroIsValid = true;
            // 
            // dSSalidas
            // 
            this.dSSalidas.DataSetName = "DSSalidas";
            this.dSSalidas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rETIROSBindingSource
            // 
            this.rETIROSBindingSource.DataMember = "RETIROS";
            this.rETIROSBindingSource.DataSource = this.dSSalidas;
            // 
            // rETIROSTableAdapter
            // 
            this.rETIROSTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Salidas.DSSalidasTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // WFRetiros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(769, 417);
            this.Controls.Add(this.TBImporte);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.TBNotas);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFRetiros";
            this.Text = "Retiros";
            this.Load += new System.EventHandler(this.WFRetiros_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.PNLSupervisor.ResumeLayout(false);
            this.PNLSupervisor.PerformLayout();
            this.PNLPagoAProveedor.ResumeLayout(false);
            this.PNLPagoAProveedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSSalidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rETIROSBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RBPagoAProveedor;
        private System.Windows.Forms.RadioButton RBSupervisor;
        private System.Windows.Forms.Panel PNLSupervisor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBoxFB ComboSupervisor;
        private System.Windows.Forms.Panel PNLPagoAProveedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DTFecha;
        private System.Windows.Forms.TextBox TBFactura;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBoxFB ComboProveedor;
        private System.Windows.Forms.TextBox TBNotas;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericTextBox TBImporte;
        private Salidas.DSSalidas dSSalidas;
        private System.Windows.Forms.BindingSource rETIROSBindingSource;
        private Salidas.DSSalidasTableAdapters.RETIROSTableAdapter rETIROSTableAdapter;
        private Salidas.DSSalidasTableAdapters.TableAdapterManager tableAdapterManager;
    }
}