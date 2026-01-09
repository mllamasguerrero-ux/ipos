namespace iPosReporting
{
	partial class FormKardexResumido
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKardexResumido));
            this.gET_KARDEX_REPORT_SUMMARYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSReportIpos = new iPosReporting.DSReportIpos();
            this.gET_KARDEX_REPORTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pRODUCTO1TableAdapter = new iPosReporting.DSReportIposTableAdapters.PRODUCTO1TableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.TBProductoInicial = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.DTPFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.kARDEX1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kARDEX1TableAdapter = new iPosReporting.DSReportIposTableAdapters.KARDEX1TableAdapter();
            this.TBProductoFinal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DTPFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gET_KARDEX_REPORTTableAdapter = new iPosReporting.DSReportIposTableAdapters.GET_KARDEX_REPORTTableAdapter();
            this.tableAdapterManager = new iPosReporting.DSReportIposTableAdapters.TableAdapterManager();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gET_KARDEX_REPORT_SUMMARYTableAdapter = new iPosReporting.DSReportIposTableAdapters.GET_KARDEX_REPORT_SUMMARYTableAdapter();
            this.TBTabular = new System.Windows.Forms.TabPage();
            this.gET_KARDEX_REPORT_SUMMARYDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TBControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.gET_KARDEX_REPORT_SUMMARYBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSReportIpos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gET_KARDEX_REPORTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kARDEX1BindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.TBTabular.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gET_KARDEX_REPORT_SUMMARYDataGridView)).BeginInit();
            this.TBControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gET_KARDEX_REPORT_SUMMARYBindingSource
            // 
            this.gET_KARDEX_REPORT_SUMMARYBindingSource.DataMember = "GET_KARDEX_REPORT_SUMMARY";
            this.gET_KARDEX_REPORT_SUMMARYBindingSource.DataSource = this.dSReportIpos;
            // 
            // dSReportIpos
            // 
            this.dSReportIpos.DataSetName = "DSReportIpos";
            this.dSReportIpos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gET_KARDEX_REPORTBindingSource
            // 
            this.gET_KARDEX_REPORTBindingSource.DataMember = "GET_KARDEX_REPORT";
            this.gET_KARDEX_REPORTBindingSource.DataSource = this.dSReportIpos;
            // 
            // pRODUCTO1TableAdapter
            // 
            this.pRODUCTO1TableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(121, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Del producto:";
            // 
            // TBProductoInicial
            // 
            this.TBProductoInicial.Location = new System.Drawing.Point(212, 19);
            this.TBProductoInicial.Name = "TBProductoInicial";
            this.TBProductoInicial.Size = new System.Drawing.Size(174, 20);
            this.TBProductoInicial.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(772, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Generar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DTPFechaInicial
            // 
            this.DTPFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFechaInicial.Location = new System.Drawing.Point(521, 18);
            this.DTPFechaInicial.Name = "DTPFechaInicial";
            this.DTPFechaInicial.Size = new System.Drawing.Size(200, 20);
            this.DTPFechaInicial.TabIndex = 7;
            // 
            // kARDEX1TableAdapter
            // 
            this.kARDEX1TableAdapter.ClearBeforeFill = true;
            // 
            // TBProductoFinal
            // 
            this.TBProductoFinal.Location = new System.Drawing.Point(212, 44);
            this.TBProductoFinal.Name = "TBProductoFinal";
            this.TBProductoFinal.Size = new System.Drawing.Size(174, 20);
            this.TBProductoFinal.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(129, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Al producto:";
            // 
            // DTPFechaFinal
            // 
            this.DTPFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFechaFinal.Location = new System.Drawing.Point(521, 44);
            this.DTPFechaFinal.Name = "DTPFechaFinal";
            this.DTPFechaFinal.Size = new System.Drawing.Size(200, 20);
            this.DTPFechaFinal.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(446, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "A la fecha:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(438, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "De la fecha:";
            // 
            // gET_KARDEX_REPORTTableAdapter
            // 
            this.gET_KARDEX_REPORTTableAdapter.ClearBeforeFill = true;
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
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TBProductoInicial);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.DTPFechaFinal);
            this.panel1.Controls.Add(this.DTPFechaInicial);
            this.panel1.Controls.Add(this.TBProductoFinal);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(968, 70);
            this.panel1.TabIndex = 1;
            // 
            // gET_KARDEX_REPORT_SUMMARYTableAdapter
            // 
            this.gET_KARDEX_REPORT_SUMMARYTableAdapter.ClearBeforeFill = true;
            // 
            // TBTabular
            // 
            this.TBTabular.Controls.Add(this.gET_KARDEX_REPORT_SUMMARYDataGridView);
            this.TBTabular.Location = new System.Drawing.Point(4, 22);
            this.TBTabular.Name = "TBTabular";
            this.TBTabular.Padding = new System.Windows.Forms.Padding(3);
            this.TBTabular.Size = new System.Drawing.Size(960, 466);
            this.TBTabular.TabIndex = 2;
            this.TBTabular.Text = "TABULAR";
            this.TBTabular.UseVisualStyleBackColor = true;
            // 
            // gET_KARDEX_REPORT_SUMMARYDataGridView
            // 
            this.gET_KARDEX_REPORT_SUMMARYDataGridView.AllowUserToAddRows = false;
            this.gET_KARDEX_REPORT_SUMMARYDataGridView.AutoGenerateColumns = false;
            this.gET_KARDEX_REPORT_SUMMARYDataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gET_KARDEX_REPORT_SUMMARYDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gET_KARDEX_REPORT_SUMMARYDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gET_KARDEX_REPORT_SUMMARYDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn22,
            this.dataGridViewTextBoxColumn23,
            this.dataGridViewTextBoxColumn24,
            this.dataGridViewTextBoxColumn25,
            this.dataGridViewTextBoxColumn26});
            this.gET_KARDEX_REPORT_SUMMARYDataGridView.DataSource = this.gET_KARDEX_REPORT_SUMMARYBindingSource;
            this.gET_KARDEX_REPORT_SUMMARYDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gET_KARDEX_REPORT_SUMMARYDataGridView.EnableHeadersVisualStyles = false;
            this.gET_KARDEX_REPORT_SUMMARYDataGridView.Location = new System.Drawing.Point(3, 3);
            this.gET_KARDEX_REPORT_SUMMARYDataGridView.Name = "gET_KARDEX_REPORT_SUMMARYDataGridView";
            this.gET_KARDEX_REPORT_SUMMARYDataGridView.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gET_KARDEX_REPORT_SUMMARYDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gET_KARDEX_REPORT_SUMMARYDataGridView.RowHeadersVisible = false;
            this.gET_KARDEX_REPORT_SUMMARYDataGridView.Size = new System.Drawing.Size(954, 460);
            this.gET_KARDEX_REPORT_SUMMARYDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "NUMERO";
            this.dataGridViewTextBoxColumn17.HeaderText = "NUMERO";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Visible = false;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "PRODUCTOID";
            this.dataGridViewTextBoxColumn18.HeaderText = "PRODUCTOID";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Visible = false;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "PRODUCTOCLAVE";
            this.dataGridViewTextBoxColumn19.HeaderText = "PRODUCTO";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "PRODUCTODESCRIPCION";
            this.dataGridViewTextBoxColumn20.HeaderText = "DESCRIPCION";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.Width = 150;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "CANTIDADINI";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.dataGridViewTextBoxColumn21.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn21.HeaderText = "CANT. INICIAL";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            this.dataGridViewTextBoxColumn21.Width = 120;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "CANTIDADENTRADAS";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.dataGridViewTextBoxColumn22.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn22.HeaderText = "ENTRADAS";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            this.dataGridViewTextBoxColumn22.Width = 120;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "CANTIDADSALIDAS";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.dataGridViewTextBoxColumn23.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn23.HeaderText = "SALIDAS";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            this.dataGridViewTextBoxColumn23.Width = 120;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "CANTIDADFIN";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.dataGridViewTextBoxColumn24.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn24.HeaderText = "CANT. FINAL";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            this.dataGridViewTextBoxColumn24.Width = 120;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "PRODUCTOPRECIO";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.dataGridViewTextBoxColumn25.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn25.HeaderText = "PRECIO";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.DataPropertyName = "PRODUCTOCOSTOREPO";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.dataGridViewTextBoxColumn26.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn26.HeaderText = "COSTO REPO.";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.ReadOnly = true;
            this.dataGridViewTextBoxColumn26.Width = 120;
            // 
            // TBControl
            // 
            this.TBControl.Controls.Add(this.TBTabular);
            this.TBControl.Controls.Add(this.tabPage1);
            this.TBControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBControl.Location = new System.Drawing.Point(0, 70);
            this.TBControl.Name = "TBControl";
            this.TBControl.SelectedIndex = 0;
            this.TBControl.Size = new System.Drawing.Size(968, 492);
            this.TBControl.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.reportViewer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(960, 466);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "REPORTE";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.gET_KARDEX_REPORT_SUMMARYBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "iPosReporting.RptKardexResumido.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(954, 460);
            this.reportViewer1.TabIndex = 0;
            // 
            // FormKardexResumido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::iPosReporting.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(968, 562);
            this.Controls.Add(this.TBControl);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormKardexResumido";
            this.Text = "Kardex";
            this.Load += new System.EventHandler(this.FormKardexResumido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gET_KARDEX_REPORT_SUMMARYBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSReportIpos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gET_KARDEX_REPORTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kARDEX1BindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TBTabular.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gET_KARDEX_REPORT_SUMMARYDataGridView)).EndInit();
            this.TBControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private iPosReporting.DSReportIposTableAdapters.PRODUCTO1TableAdapter pRODUCTO1TableAdapter;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox TBProductoInicial;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker DTPFechaInicial;
		private System.Windows.Forms.BindingSource kARDEX1BindingSource;
        private iPosReporting.DSReportIposTableAdapters.KARDEX1TableAdapter kARDEX1TableAdapter;
        private System.Windows.Forms.TextBox TBProductoFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DTPFechaFinal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DSReportIpos dSReportIpos;
        private System.Windows.Forms.BindingSource gET_KARDEX_REPORTBindingSource;
        private DSReportIposTableAdapters.GET_KARDEX_REPORTTableAdapter gET_KARDEX_REPORTTableAdapter;
        private DSReportIposTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource gET_KARDEX_REPORT_SUMMARYBindingSource;
        private DSReportIposTableAdapters.GET_KARDEX_REPORT_SUMMARYTableAdapter gET_KARDEX_REPORT_SUMMARYTableAdapter;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.TabPage TBTabular;
        private System.Windows.Forms.DataGridView gET_KARDEX_REPORT_SUMMARYDataGridView;
        private System.Windows.Forms.TabControl TBControl;
        private System.Windows.Forms.TabPage tabPage1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
	}
}