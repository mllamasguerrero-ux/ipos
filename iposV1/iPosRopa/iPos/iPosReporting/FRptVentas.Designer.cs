namespace iPosReporting
{
    partial class FRptVentas
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRptVentas));
            this.rEP_VENTABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSReportIpos = new iPosReporting.DSReportIpos();
            this.label1 = new System.Windows.Forms.Label();
            this.DTPFrom = new System.Windows.Forms.DateTimePicker();
            this.DTPTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.BTEnviar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CBReporteTabular = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CBFactRem = new System.Windows.Forms.ComboBox();
            this.comboBoxAlmacen = new System.Windows.Forms.ComboBox();
            this.aLMACENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CBSoloAlmacen = new System.Windows.Forms.CheckBox();
            this.CBCajerosTodos = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.VENDEDORButton = new System.Windows.Forms.Button();
            this.VENDEDORLabel = new System.Windows.Forms.Label();
            this.VENDEDORIDTextBox = new iPos.Tools.TextBoxFBRpt();
            this.CBTipo = new System.Windows.Forms.ComboBox();
            this.LBTIPOREG = new System.Windows.Forms.Label();
            this.rEP_VENTATableAdapter = new iPosReporting.DSReportIposTableAdapters.REP_VENTATableAdapter();
            this.tableAdapterManager = new iPosReporting.DSReportIposTableAdapters.TableAdapterManager();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rEP_VENTADataGridView = new System.Windows.Forms.DataGridView();
            this.TIPODOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VENDEDOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESFACTURAELECTRONICA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SERIEFOLIOSAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUCURSALT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SALDO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESTATUSDOCTONOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabReporte = new System.Windows.Forms.TabPage();
            this.previewControl1 = new FastReport.Preview.PreviewControl();
            this.report1 = new FastReport.Report();
            this.aLMACENTableAdapter = new iPosReporting.DSReportIposTableAdapters.ALMACENTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.rEP_VENTABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSReportIpos)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aLMACENBindingSource)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rEP_VENTADataGridView)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabReporte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            this.SuspendLayout();
            // 
            // rEP_VENTABindingSource
            // 
            this.rEP_VENTABindingSource.DataMember = "REP_VENTA";
            this.rEP_VENTABindingSource.DataSource = this.dSReportIpos;
            // 
            // dSReportIpos
            // 
            this.dSReportIpos.DataSetName = "DSReportIpos";
            this.dSReportIpos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(432, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desde:";
            // 
            // DTPFrom
            // 
            this.DTPFrom.Location = new System.Drawing.Point(485, 14);
            this.DTPFrom.Name = "DTPFrom";
            this.DTPFrom.Size = new System.Drawing.Size(200, 20);
            this.DTPFrom.TabIndex = 3;
            // 
            // DTPTo
            // 
            this.DTPTo.Location = new System.Drawing.Point(787, 14);
            this.DTPTo.Name = "DTPTo";
            this.DTPTo.Size = new System.Drawing.Size(200, 20);
            this.DTPTo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(765, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "A:";
            // 
            // BTEnviar
            // 
            this.BTEnviar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTEnviar.AutoSize = true;
            this.BTEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTEnviar.ForeColor = System.Drawing.Color.White;
            this.BTEnviar.Location = new System.Drawing.Point(1035, 43);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(75, 25);
            this.BTEnviar.TabIndex = 5;
            this.BTEnviar.Text = "Enviar";
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.CBReporteTabular);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.CBFactRem);
            this.panel1.Controls.Add(this.comboBoxAlmacen);
            this.panel1.Controls.Add(this.CBSoloAlmacen);
            this.panel1.Controls.Add(this.CBCajerosTodos);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.VENDEDORButton);
            this.panel1.Controls.Add(this.VENDEDORLabel);
            this.panel1.Controls.Add(this.VENDEDORIDTextBox);
            this.panel1.Controls.Add(this.CBTipo);
            this.panel1.Controls.Add(this.LBTIPOREG);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BTEnviar);
            this.panel1.Controls.Add(this.DTPFrom);
            this.panel1.Controls.Add(this.DTPTo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1148, 113);
            this.panel1.TabIndex = 7;
            // 
            // CBReporteTabular
            // 
            this.CBReporteTabular.AutoSize = true;
            this.CBReporteTabular.ForeColor = System.Drawing.Color.White;
            this.CBReporteTabular.Location = new System.Drawing.Point(842, 74);
            this.CBReporteTabular.Name = "CBReporteTabular";
            this.CBReporteTabular.Size = new System.Drawing.Size(132, 17);
            this.CBReporteTabular.TabIndex = 184;
            this.CBReporteTabular.Text = "Mostrar reporte tabular";
            this.CBReporteTabular.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(765, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 181;
            this.label5.Text = "Fact./Rem.";
            // 
            // CBFactRem
            // 
            this.CBFactRem.FormattingEnabled = true;
            this.CBFactRem.Items.AddRange(new object[] {
            "TODOS",
            "REMISION",
            "FACTURA"});
            this.CBFactRem.Location = new System.Drawing.Point(842, 44);
            this.CBFactRem.Name = "CBFactRem";
            this.CBFactRem.Size = new System.Drawing.Size(145, 21);
            this.CBFactRem.TabIndex = 180;
            // 
            // comboBoxAlmacen
            // 
            this.comboBoxAlmacen.DataSource = this.aLMACENBindingSource;
            this.comboBoxAlmacen.DisplayMember = "CLAVE";
            this.comboBoxAlmacen.FormattingEnabled = true;
            this.comboBoxAlmacen.Location = new System.Drawing.Point(192, 44);
            this.comboBoxAlmacen.Name = "comboBoxAlmacen";
            this.comboBoxAlmacen.Size = new System.Drawing.Size(178, 21);
            this.comboBoxAlmacen.TabIndex = 179;
            this.comboBoxAlmacen.ValueMember = "ID";
            // 
            // aLMACENBindingSource
            // 
            this.aLMACENBindingSource.DataMember = "ALMACEN";
            this.aLMACENBindingSource.DataSource = this.dSReportIpos;
            // 
            // CBSoloAlmacen
            // 
            this.CBSoloAlmacen.AutoSize = true;
            this.CBSoloAlmacen.BackColor = System.Drawing.Color.Transparent;
            this.CBSoloAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBSoloAlmacen.ForeColor = System.Drawing.Color.White;
            this.CBSoloAlmacen.Location = new System.Drawing.Point(54, 46);
            this.CBSoloAlmacen.Name = "CBSoloAlmacen";
            this.CBSoloAlmacen.Size = new System.Drawing.Size(127, 17);
            this.CBSoloAlmacen.TabIndex = 177;
            this.CBSoloAlmacen.Text = "Solo del almacen:";
            this.CBSoloAlmacen.UseVisualStyleBackColor = false;
            // 
            // CBCajerosTodos
            // 
            this.CBCajerosTodos.AutoSize = true;
            this.CBCajerosTodos.ForeColor = System.Drawing.Color.White;
            this.CBCajerosTodos.Location = new System.Drawing.Point(485, 74);
            this.CBCajerosTodos.Name = "CBCajerosTodos";
            this.CBCajerosTodos.Size = new System.Drawing.Size(109, 17);
            this.CBCajerosTodos.TabIndex = 176;
            this.CBCajerosTodos.Text = "Todos los cajeros";
            this.CBCajerosTodos.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(432, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 175;
            this.label4.Text = "Cajero:";
            // 
            // VENDEDORButton
            // 
            this.VENDEDORButton.Location = new System.Drawing.Point(591, 42);
            this.VENDEDORButton.Name = "VENDEDORButton";
            this.VENDEDORButton.Size = new System.Drawing.Size(31, 23);
            this.VENDEDORButton.TabIndex = 173;
            this.VENDEDORButton.Text = "...";
            this.VENDEDORButton.UseVisualStyleBackColor = true;
            // 
            // VENDEDORLabel
            // 
            this.VENDEDORLabel.AutoSize = true;
            this.VENDEDORLabel.ForeColor = System.Drawing.Color.White;
            this.VENDEDORLabel.Location = new System.Drawing.Point(628, 50);
            this.VENDEDORLabel.Name = "VENDEDORLabel";
            this.VENDEDORLabel.Size = new System.Drawing.Size(16, 13);
            this.VENDEDORLabel.TabIndex = 174;
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
            this.VENDEDORIDTextBox.Location = new System.Drawing.Point(485, 44);
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
            this.VENDEDORIDTextBox.TabIndex = 172;
            this.VENDEDORIDTextBox.Tag = 34;
            this.VENDEDORIDTextBox.TextDescription = null;
            this.VENDEDORIDTextBox.Titulo = "Cajeros";
            this.VENDEDORIDTextBox.ValidarEntrada = true;
            this.VENDEDORIDTextBox.ValidationExpression = null;
            // 
            // CBTipo
            // 
            this.CBTipo.FormattingEnabled = true;
            this.CBTipo.Items.AddRange(new object[] {
            "VENTAS",
            "TRASLADOS",
            "DEVOLUCIONES",
            "TODOS"});
            this.CBTipo.Location = new System.Drawing.Point(192, 14);
            this.CBTipo.Name = "CBTipo";
            this.CBTipo.Size = new System.Drawing.Size(231, 21);
            this.CBTipo.TabIndex = 2;
            // 
            // LBTIPOREG
            // 
            this.LBTIPOREG.AutoSize = true;
            this.LBTIPOREG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBTIPOREG.ForeColor = System.Drawing.Color.White;
            this.LBTIPOREG.Location = new System.Drawing.Point(81, 17);
            this.LBTIPOREG.Name = "LBTIPOREG";
            this.LBTIPOREG.Size = new System.Drawing.Size(100, 13);
            this.LBTIPOREG.TabIndex = 13;
            this.LBTIPOREG.Text = "Tipo de registro:";
            // 
            // rEP_VENTATableAdapter
            // 
            this.rEP_VENTATableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CLIENTESTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.PRODUCTO1TableAdapter = null;
            this.tableAdapterManager.UpdateOrder = iPosReporting.DSReportIposTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.reportViewer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1140, 499);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "REPORTE";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSVentas";
            reportDataSource1.Value = this.rEP_VENTABindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "iPosReporting.RptVentas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1134, 493);
            this.reportViewer1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rEP_VENTADataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1140, 499);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TABULAR";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rEP_VENTADataGridView
            // 
            this.rEP_VENTADataGridView.AllowUserToAddRows = false;
            this.rEP_VENTADataGridView.AutoGenerateColumns = false;
            this.rEP_VENTADataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rEP_VENTADataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.rEP_VENTADataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rEP_VENTADataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TIPODOC,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.VENDEDOR,
            this.ESFACTURAELECTRONICA,
            this.dataGridViewTextBoxColumn5,
            this.SERIEFOLIOSAT,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.SUCURSALT,
            this.SALDO,
            this.ESTATUSDOCTONOMBRE});
            this.rEP_VENTADataGridView.DataSource = this.rEP_VENTABindingSource;
            this.rEP_VENTADataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rEP_VENTADataGridView.EnableHeadersVisualStyles = false;
            this.rEP_VENTADataGridView.Location = new System.Drawing.Point(3, 3);
            this.rEP_VENTADataGridView.Name = "rEP_VENTADataGridView";
            this.rEP_VENTADataGridView.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rEP_VENTADataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.rEP_VENTADataGridView.RowHeadersVisible = false;
            this.rEP_VENTADataGridView.Size = new System.Drawing.Size(1134, 493);
            this.rEP_VENTADataGridView.TabIndex = 0;
            // 
            // TIPODOC
            // 
            this.TIPODOC.DataPropertyName = "TIPODOC";
            this.TIPODOC.HeaderText = "TIPO";
            this.TIPODOC.Name = "TIPODOC";
            this.TIPODOC.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "NUMERO";
            this.dataGridViewTextBoxColumn1.HeaderText = "NUMERO";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FECHA";
            this.dataGridViewTextBoxColumn2.HeaderText = "FECHA";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "FECHAHORA";
            this.dataGridViewTextBoxColumn3.HeaderText = "HORA";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TURNOCLAVE";
            this.dataGridViewTextBoxColumn4.HeaderText = "TURNO";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // VENDEDOR
            // 
            this.VENDEDOR.DataPropertyName = "VENDEDOR";
            this.VENDEDOR.HeaderText = "VENDEDOR";
            this.VENDEDOR.Name = "VENDEDOR";
            this.VENDEDOR.ReadOnly = true;
            // 
            // ESFACTURAELECTRONICA
            // 
            this.ESFACTURAELECTRONICA.DataPropertyName = "ESFACTURAELECTRONICA";
            this.ESFACTURAELECTRONICA.HeaderText = "FACT. ELECT.";
            this.ESFACTURAELECTRONICA.Name = "ESFACTURAELECTRONICA";
            this.ESFACTURAELECTRONICA.ReadOnly = true;
            this.ESFACTURAELECTRONICA.Width = 50;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DOCTOFOLIO";
            this.dataGridViewTextBoxColumn5.HeaderText = "FOLIO";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // SERIEFOLIOSAT
            // 
            this.SERIEFOLIOSAT.DataPropertyName = "SERIEFOLIOSAT";
            this.SERIEFOLIOSAT.HeaderText = "SERIE - FOLIO SAT";
            this.SERIEFOLIOSAT.Name = "SERIEFOLIOSAT";
            this.SERIEFOLIOSAT.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "IMPORTE";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn6.HeaderText = "IMPORTE";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "DESCUENTO";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle3.Format = "N2";
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn7.HeaderText = "DESCUENTO";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "SUBTOTAL";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn8.HeaderText = "SUBTOTAL";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "IVA";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn9.HeaderText = "IVA";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 80;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "TOTAL";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn10.HeaderText = "TOTAL";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // SUCURSALT
            // 
            this.SUCURSALT.DataPropertyName = "SUCURSALT";
            this.SUCURSALT.HeaderText = "SUC. DESTINO";
            this.SUCURSALT.Name = "SUCURSALT";
            this.SUCURSALT.ReadOnly = true;
            // 
            // SALDO
            // 
            this.SALDO.DataPropertyName = "SALDO";
            this.SALDO.HeaderText = "SALDO";
            this.SALDO.Name = "SALDO";
            this.SALDO.ReadOnly = true;
            this.SALDO.Width = 75;
            // 
            // ESTATUSDOCTONOMBRE
            // 
            this.ESTATUSDOCTONOMBRE.DataPropertyName = "ESTATUSDOCTONOMBRE";
            this.ESTATUSDOCTONOMBRE.HeaderText = "ESTATUS";
            this.ESTATUSDOCTONOMBRE.Name = "ESTATUSDOCTONOMBRE";
            this.ESTATUSDOCTONOMBRE.ReadOnly = true;
            this.ESTATUSDOCTONOMBRE.Width = 50;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabReporte);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 113);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1148, 525);
            this.tabControl1.TabIndex = 8;
            // 
            // tabReporte
            // 
            this.tabReporte.Controls.Add(this.previewControl1);
            this.tabReporte.Location = new System.Drawing.Point(4, 22);
            this.tabReporte.Name = "tabReporte";
            this.tabReporte.Padding = new System.Windows.Forms.Padding(3);
            this.tabReporte.Size = new System.Drawing.Size(1140, 499);
            this.tabReporte.TabIndex = 2;
            this.tabReporte.Text = "REPORTE";
            this.tabReporte.UseVisualStyleBackColor = true;
            // 
            // previewControl1
            // 
            this.previewControl1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.previewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewControl1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.previewControl1.Location = new System.Drawing.Point(3, 3);
            this.previewControl1.Name = "previewControl1";
            this.previewControl1.PageOffset = new System.Drawing.Point(10, 10);
            this.previewControl1.Size = new System.Drawing.Size(1134, 493);
            this.previewControl1.TabIndex = 0;
            this.previewControl1.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // aLMACENTableAdapter
            // 
            this.aLMACENTableAdapter.ClearBeforeFill = true;
            // 
            // FRptVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::iPosReporting.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1148, 638);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRptVentas";
            this.Text = "REPORTES DE VENTAS";
            this.Load += new System.EventHandler(this.FRptVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rEP_VENTABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSReportIpos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aLMACENBindingSource)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rEP_VENTADataGridView)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabReporte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DTPFrom;
        private System.Windows.Forms.DateTimePicker DTPTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTEnviar;
        private System.Windows.Forms.Panel panel1;
        private DSReportIpos dSReportIpos;
        private System.Windows.Forms.BindingSource rEP_VENTABindingSource;
        private DSReportIposTableAdapters.REP_VENTATableAdapter rEP_VENTATableAdapter;
        private DSReportIposTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox CBTipo;
        private System.Windows.Forms.Label LBTIPOREG;
        private System.Windows.Forms.TabPage tabPage2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView rEP_VENTADataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPODOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn VENDEDOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESFACTURAELECTRONICA;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn SERIEFOLIOSAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUCURSALT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SALDO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESTATUSDOCTONOMBRE;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabReporte;
        private FastReport.Preview.PreviewControl previewControl1;
        private FastReport.Report report1;
        private System.Windows.Forms.CheckBox CBCajerosTodos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button VENDEDORButton;
        private System.Windows.Forms.Label VENDEDORLabel;
        private iPos.Tools.TextBoxFBRpt VENDEDORIDTextBox;
        private System.Windows.Forms.CheckBox CBSoloAlmacen;
        private System.Windows.Forms.ComboBox comboBoxAlmacen;
        private System.Windows.Forms.BindingSource aLMACENBindingSource;
        private DSReportIposTableAdapters.ALMACENTableAdapter aLMACENTableAdapter;
        private System.Windows.Forms.CheckBox CBReporteTabular;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CBFactRem;
    }
}