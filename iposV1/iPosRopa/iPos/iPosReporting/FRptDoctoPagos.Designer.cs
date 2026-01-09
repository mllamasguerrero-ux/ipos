namespace iPosReporting
{
	partial class FRptDoctoPagos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRptDoctoPagos));
            this.dSReportIpos = new iPosReporting.DSReportIpos();
            this.pRODUCTO1TableAdapter = new iPosReporting.DSReportIposTableAdapters.PRODUCTO1TableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.previewControl1 = new FastReport.Preview.PreviewControl();
            this.tableAdapterManager = new iPosReporting.DSReportIposTableAdapters.TableAdapterManager();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CBGrupoCajerosTodos = new System.Windows.Forms.CheckBox();
            this.GRUPOUSUARIOIDTextBox = new iPos.Tools.TextBoxFBRpt();
            this.GRUPOUSUARIOIDButton = new System.Windows.Forms.Button();
            this.GRUPOUSUARIOIDLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CBCajerosTodos = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.VENDEDORButton = new System.Windows.Forms.Button();
            this.VENDEDORLabel = new System.Windows.Forms.Label();
            this.VENDEDORIDTextBox = new iPos.Tools.TextBoxFBRpt();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DTPFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.DTPFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.CBFormaPago = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CBTipoDocto = new System.Windows.Forms.ComboBox();
            this.report1 = new FastReport.Report();
            this.dOCUMENTOSPAGOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSReportIpos2 = new iPosReporting.DSReportIpos2();
            this.tableAdapterManager1 = new iPosReporting.DSReportIpos2TableAdapters.TableAdapterManager();
            this.dOCUMENTOSPAGOSTableAdapter = new iPosReporting.DSReportIpos2TableAdapters.DOCUMENTOSPAGOSTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dSReportIpos)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOCUMENTOSPAGOSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSReportIpos2)).BeginInit();
            this.SuspendLayout();
            // 
            // dSReportIpos
            // 
            this.dSReportIpos.DataSetName = "DSReportIpos";
            this.dSReportIpos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pRODUCTO1TableAdapter
            // 
            this.pRODUCTO1TableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(588, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Generar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 128);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(813, 434);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.previewControl1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(805, 408);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "REPORTE";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // previewControl1
            // 
            this.previewControl1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.previewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewControl1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.previewControl1.Location = new System.Drawing.Point(3, 3);
            this.previewControl1.Name = "previewControl1";
            this.previewControl1.PageOffset = new System.Drawing.Point(10, 10);
            this.previewControl1.Size = new System.Drawing.Size(799, 402);
            this.previewControl1.TabIndex = 1;
            this.previewControl1.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CLIENTESTableAdapter = null;
            this.tableAdapterManager.PRODUCTO1TableAdapter = this.pRODUCTO1TableAdapter;
            this.tableAdapterManager.UpdateOrder = iPosReporting.DSReportIposTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.CBGrupoCajerosTodos);
            this.panel1.Controls.Add(this.GRUPOUSUARIOIDTextBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.GRUPOUSUARIOIDButton);
            this.panel1.Controls.Add(this.GRUPOUSUARIOIDLabel);
            this.panel1.Controls.Add(this.CBCajerosTodos);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.VENDEDORButton);
            this.panel1.Controls.Add(this.VENDEDORLabel);
            this.panel1.Controls.Add(this.VENDEDORIDTextBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.DTPFechaFinal);
            this.panel1.Controls.Add(this.DTPFechaInicial);
            this.panel1.Controls.Add(this.CBFormaPago);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CBTipoDocto);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(813, 128);
            this.panel1.TabIndex = 1;
            // 
            // CBGrupoCajerosTodos
            // 
            this.CBGrupoCajerosTodos.AutoSize = true;
            this.CBGrupoCajerosTodos.Checked = true;
            this.CBGrupoCajerosTodos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBGrupoCajerosTodos.ForeColor = System.Drawing.Color.White;
            this.CBGrupoCajerosTodos.Location = new System.Drawing.Point(332, 96);
            this.CBGrupoCajerosTodos.Name = "CBGrupoCajerosTodos";
            this.CBGrupoCajerosTodos.Size = new System.Drawing.Size(159, 17);
            this.CBGrupoCajerosTodos.TabIndex = 191;
            this.CBGrupoCajerosTodos.Text = "Todos los grupos de cajeros";
            this.CBGrupoCajerosTodos.UseVisualStyleBackColor = true;
            // 
            // GRUPOUSUARIOIDTextBox
            // 
            this.GRUPOUSUARIOIDTextBox.BotonLookUp = this.GRUPOUSUARIOIDButton;
            this.GRUPOUSUARIOIDTextBox.Condicion = null;
            this.GRUPOUSUARIOIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.GRUPOUSUARIOIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.GRUPOUSUARIOIDTextBox.DbValue = null;
            this.GRUPOUSUARIOIDTextBox.Format_Expression = null;
            this.GRUPOUSUARIOIDTextBox.IndiceCampoDescripcion = 2;
            this.GRUPOUSUARIOIDTextBox.IndiceCampoSelector = 1;
            this.GRUPOUSUARIOIDTextBox.IndiceCampoValue = 0;
            this.GRUPOUSUARIOIDTextBox.LabelDescription = this.GRUPOUSUARIOIDLabel;
            this.GRUPOUSUARIOIDTextBox.Location = new System.Drawing.Point(121, 96);
            this.GRUPOUSUARIOIDTextBox.MostrarErrores = true;
            this.GRUPOUSUARIOIDTextBox.Name = "GRUPOUSUARIOIDTextBox";
            this.GRUPOUSUARIOIDTextBox.NombreCampoSelector = "clave";
            this.GRUPOUSUARIOIDTextBox.NombreCampoValue = "id";
            this.GRUPOUSUARIOIDTextBox.Query = "select id,clave,nombre from grupousuario";
            this.GRUPOUSUARIOIDTextBox.QueryDeSeleccion = "select id,clave,nombre from grupousuario where  clave= @clave";
            this.GRUPOUSUARIOIDTextBox.QueryPorDBValue = "select id,clave,nombre from grupousuario where   id = @id";
            this.GRUPOUSUARIOIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.GRUPOUSUARIOIDTextBox.TabIndex = 190;
            this.GRUPOUSUARIOIDTextBox.Tag = 34;
            this.GRUPOUSUARIOIDTextBox.TextDescription = null;
            this.GRUPOUSUARIOIDTextBox.Titulo = "Grupos de usuario";
            this.GRUPOUSUARIOIDTextBox.ValidarEntrada = true;
            this.GRUPOUSUARIOIDTextBox.ValidationExpression = null;
            // 
            // GRUPOUSUARIOIDButton
            // 
            this.GRUPOUSUARIOIDButton.AccessibleDescription = "";
            this.GRUPOUSUARIOIDButton.Location = new System.Drawing.Point(227, 96);
            this.GRUPOUSUARIOIDButton.Name = "GRUPOUSUARIOIDButton";
            this.GRUPOUSUARIOIDButton.Size = new System.Drawing.Size(30, 20);
            this.GRUPOUSUARIOIDButton.TabIndex = 188;
            this.GRUPOUSUARIOIDButton.Text = "...";
            this.GRUPOUSUARIOIDButton.UseVisualStyleBackColor = true;
            // 
            // GRUPOUSUARIOIDLabel
            // 
            this.GRUPOUSUARIOIDLabel.AccessibleDescription = "";
            this.GRUPOUSUARIOIDLabel.AutoSize = true;
            this.GRUPOUSUARIOIDLabel.ForeColor = System.Drawing.Color.White;
            this.GRUPOUSUARIOIDLabel.Location = new System.Drawing.Point(257, 102);
            this.GRUPOUSUARIOIDLabel.Name = "GRUPOUSUARIOIDLabel";
            this.GRUPOUSUARIOIDLabel.Size = new System.Drawing.Size(16, 13);
            this.GRUPOUSUARIOIDLabel.TabIndex = 189;
            this.GRUPOUSUARIOIDLabel.Text = "...";
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "";
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(13, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 187;
            this.label6.Text = "Grupo de cajeros:";
            // 
            // CBCajerosTodos
            // 
            this.CBCajerosTodos.AutoSize = true;
            this.CBCajerosTodos.Checked = true;
            this.CBCajerosTodos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBCajerosTodos.ForeColor = System.Drawing.Color.White;
            this.CBCajerosTodos.Location = new System.Drawing.Point(332, 68);
            this.CBCajerosTodos.Name = "CBCajerosTodos";
            this.CBCajerosTodos.Size = new System.Drawing.Size(109, 17);
            this.CBCajerosTodos.TabIndex = 180;
            this.CBCajerosTodos.Text = "Todos los cajeros";
            this.CBCajerosTodos.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(74, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 179;
            this.label5.Text = "Cajero:";
            // 
            // VENDEDORButton
            // 
            this.VENDEDORButton.Location = new System.Drawing.Point(228, 66);
            this.VENDEDORButton.Name = "VENDEDORButton";
            this.VENDEDORButton.Size = new System.Drawing.Size(29, 20);
            this.VENDEDORButton.TabIndex = 177;
            this.VENDEDORButton.Text = "...";
            this.VENDEDORButton.UseVisualStyleBackColor = true;
            // 
            // VENDEDORLabel
            // 
            this.VENDEDORLabel.AutoSize = true;
            this.VENDEDORLabel.ForeColor = System.Drawing.Color.White;
            this.VENDEDORLabel.Location = new System.Drawing.Point(257, 73);
            this.VENDEDORLabel.Name = "VENDEDORLabel";
            this.VENDEDORLabel.Size = new System.Drawing.Size(16, 13);
            this.VENDEDORLabel.TabIndex = 178;
            this.VENDEDORLabel.Text = "...";
            // 
            // VENDEDORIDTextBox
            // 
            this.VENDEDORIDTextBox.BotonLookUp = this.VENDEDORButton;
            this.VENDEDORIDTextBox.Condicion = null;
            this.VENDEDORIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.VENDEDORIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.VENDEDORIDTextBox.DbValue = null;
            this.VENDEDORIDTextBox.Format_Expression = null;
            this.VENDEDORIDTextBox.IndiceCampoDescripcion = 2;
            this.VENDEDORIDTextBox.IndiceCampoSelector = 1;
            this.VENDEDORIDTextBox.IndiceCampoValue = 0;
            this.VENDEDORIDTextBox.LabelDescription = this.VENDEDORLabel;
            this.VENDEDORIDTextBox.Location = new System.Drawing.Point(122, 66);
            this.VENDEDORIDTextBox.MostrarErrores = true;
            this.VENDEDORIDTextBox.Name = "VENDEDORIDTextBox";
            this.VENDEDORIDTextBox.NombreCampoSelector = "clave";
            this.VENDEDORIDTextBox.NombreCampoValue = "id";
            this.VENDEDORIDTextBox.Query = "select id,clave,nombre from persona where tipopersonaid in (22,20)";
            this.VENDEDORIDTextBox.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid  in (22,20) and  clave= @" +
    "clave";
            this.VENDEDORIDTextBox.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid  in (22,20) and  id = @id" +
    "";
            this.VENDEDORIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.VENDEDORIDTextBox.TabIndex = 176;
            this.VENDEDORIDTextBox.Tag = 34;
            this.VENDEDORIDTextBox.TextDescription = null;
            this.VENDEDORIDTextBox.Titulo = "Cajeros";
            this.VENDEDORIDTextBox.ValidarEntrada = true;
            this.VENDEDORIDTextBox.ValidationExpression = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(355, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "A la fecha:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(44, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "De la fecha:";
            // 
            // DTPFechaFinal
            // 
            this.DTPFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFechaFinal.Location = new System.Drawing.Point(430, 38);
            this.DTPFechaFinal.Name = "DTPFechaFinal";
            this.DTPFechaFinal.Size = new System.Drawing.Size(139, 20);
            this.DTPFechaFinal.TabIndex = 4;
            // 
            // DTPFechaInicial
            // 
            this.DTPFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFechaInicial.Location = new System.Drawing.Point(122, 38);
            this.DTPFechaInicial.Name = "DTPFechaInicial";
            this.DTPFechaInicial.Size = new System.Drawing.Size(135, 20);
            this.DTPFechaInicial.TabIndex = 3;
            // 
            // CBFormaPago
            // 
            this.CBFormaPago.FormattingEnabled = true;
            this.CBFormaPago.Items.AddRange(new object[] {
            "Todas",
            "Efectivo",
            "Tarjeta",
            "Cheque",
            "Credito",
            "Intercambio de mercancias",
            "Multiple"});
            this.CBFormaPago.Location = new System.Drawing.Point(430, 11);
            this.CBFormaPago.Name = "CBFormaPago";
            this.CBFormaPago.Size = new System.Drawing.Size(139, 21);
            this.CBFormaPago.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(329, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Forma de pago:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tipo documento:";
            // 
            // CBTipoDocto
            // 
            this.CBTipoDocto.FormattingEnabled = true;
            this.CBTipoDocto.Items.AddRange(new object[] {
            "Venta",
            "Compra"});
            this.CBTipoDocto.Location = new System.Drawing.Point(122, 11);
            this.CBTipoDocto.Name = "CBTipoDocto";
            this.CBTipoDocto.Size = new System.Drawing.Size(135, 21);
            this.CBTipoDocto.TabIndex = 1;
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // dOCUMENTOSPAGOSBindingSource
            // 
            this.dOCUMENTOSPAGOSBindingSource.DataMember = "DOCUMENTOSPAGOS";
            this.dOCUMENTOSPAGOSBindingSource.DataSource = this.dSReportIpos2;
            // 
            // dSReportIpos2
            // 
            this.dSReportIpos2.DataSetName = "DSReportIpos2";
            this.dSReportIpos2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.UpdateOrder = iPosReporting.DSReportIpos2TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dOCUMENTOSPAGOSTableAdapter
            // 
            this.dOCUMENTOSPAGOSTableAdapter.ClearBeforeFill = true;
            // 
            // FRptDoctoPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::iPosReporting.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(813, 562);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRptDoctoPagos";
            this.Text = "Documentos por forma de pago";
            this.Load += new System.EventHandler(this.FRptDoctoPagos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSReportIpos)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOCUMENTOSPAGOSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSReportIpos2)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private iPosReporting.DSReportIposTableAdapters.PRODUCTO1TableAdapter pRODUCTO1TableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private DSReportIpos dSReportIpos;
        private DSReportIposTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Panel panel1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private DSReportIpos2 dSReportIpos2;
        private DSReportIpos2TableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.ComboBox CBFormaPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBTipoDocto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DTPFechaFinal;
        private System.Windows.Forms.DateTimePicker DTPFechaInicial;
        private System.Windows.Forms.BindingSource dOCUMENTOSPAGOSBindingSource;
        private DSReportIpos2TableAdapters.DOCUMENTOSPAGOSTableAdapter dOCUMENTOSPAGOSTableAdapter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button VENDEDORButton;
        private System.Windows.Forms.Label VENDEDORLabel;
        private iPos.Tools.TextBoxFBRpt VENDEDORIDTextBox;
        private System.Windows.Forms.CheckBox CBCajerosTodos;
        private System.Windows.Forms.TabPage tabPage3;
        private FastReport.Preview.PreviewControl previewControl1;
        private FastReport.Report report1;
        private iPos.Tools.TextBoxFBRpt GRUPOUSUARIOIDTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button GRUPOUSUARIOIDButton;
        private System.Windows.Forms.Label GRUPOUSUARIOIDLabel;
        private System.Windows.Forms.CheckBox CBGrupoCajerosTodos;
	}
}