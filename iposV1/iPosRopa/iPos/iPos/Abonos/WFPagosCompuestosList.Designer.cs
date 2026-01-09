namespace iPos
{
    partial class WFPagosCompuestosList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAgregarBanco = new System.Windows.Forms.Button();
            this.pAGOLISTDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.TIMBRARCHECKBOX = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGFolio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BANCONOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGTIMBRADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGAPLICADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVer = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pAGOLISTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSAbonos = new iPos.Abonos.DSAbonos();
            this.pAGOLISTTableAdapter = new iPos.Abonos.DSAbonosTableAdapters.PAGOLISTTableAdapter();
            this.tableAdapterManager = new iPos.Abonos.DSAbonosTableAdapters.TableAdapterManager();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.aplicadosComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.timbradosComboBox = new System.Windows.Forms.ComboBox();
            this.FormaPagoComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timbrarPagosButton = new System.Windows.Forms.Button();
            this.seleccionarPagosButton = new System.Windows.Forms.Button();
            this.timbrarButton = new System.Windows.Forms.Button();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ITEMButton = new System.Windows.Forms.Button();
            this.ITEMIDTextBox = new iPos.Tools.TextBoxFB();
            this.ITEMLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CBIncluirCancelaciones = new System.Windows.Forms.CheckBox();
            this.CBSoloFiscales = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnlProgresoTimbrado = new System.Windows.Forms.Panel();
            this.lblProgresoTimbrado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pAGOLISTDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAGOLISTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSAbonos)).BeginInit();
            this.pnlProgresoTimbrado.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Location = new System.Drawing.Point(97, 74);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(191, 20);
            this.dtpFechaInicial.TabIndex = 3;
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Location = new System.Drawing.Point(97, 110);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(191, 20);
            this.dtpFechaFinal.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Fecha final";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(520, 70);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(131, 23);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAgregarBanco
            // 
            this.btnAgregarBanco.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnAgregarBanco.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnAgregarBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarBanco.ForeColor = System.Drawing.Color.White;
            this.btnAgregarBanco.Location = new System.Drawing.Point(694, 70);
            this.btnAgregarBanco.Name = "btnAgregarBanco";
            this.btnAgregarBanco.Size = new System.Drawing.Size(131, 23);
            this.btnAgregarBanco.TabIndex = 8;
            this.btnAgregarBanco.Text = "Agregar Pago";
            this.btnAgregarBanco.UseVisualStyleBackColor = false;
            this.btnAgregarBanco.Click += new System.EventHandler(this.btnAgregarBitacora_Click);
            // 
            // pAGOLISTDataGridView
            // 
            this.pAGOLISTDataGridView.AllowUserToAddRows = false;
            this.pAGOLISTDataGridView.AutoGenerateColumns = false;
            this.pAGOLISTDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pAGOLISTDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TIMBRARCHECKBOX,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn13,
            this.DGFolio,
            this.BANCONOMBRE,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.DGTIMBRADO,
            this.DGAPLICADO,
            this.DGVer});
            this.pAGOLISTDataGridView.DataSource = this.pAGOLISTBindingSource;
            this.pAGOLISTDataGridView.Location = new System.Drawing.Point(12, 151);
            this.pAGOLISTDataGridView.Name = "pAGOLISTDataGridView";
            this.pAGOLISTDataGridView.RowHeadersVisible = false;
            this.pAGOLISTDataGridView.Size = new System.Drawing.Size(848, 280);
            this.pAGOLISTDataGridView.TabIndex = 11;
            this.pAGOLISTDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pAGOLISTDataGridView_CellContentClick);
            // 
            // TIMBRARCHECKBOX
            // 
            this.TIMBRARCHECKBOX.HeaderText = "";
            this.TIMBRARCHECKBOX.Name = "TIMBRARCHECKBOX";
            this.TIMBRARCHECKBOX.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FECHA";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn2.HeaderText = "FECHA";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "FECHAHORA";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn3.HeaderText = "FECHAHORA";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "IMPORTE";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn4.HeaderText = "IMPORTE";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "FORMAPAGOCLAVE";
            this.dataGridViewTextBoxColumn5.HeaderText = "FORMAPAGOCLAVE";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "FORMAPAGONOMBRE";
            this.dataGridViewTextBoxColumn6.HeaderText = "FORMA PAGO";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "FORMAPAGOSATNOMBRE";
            this.dataGridViewTextBoxColumn9.HeaderText = "FORMA PAGO SAT";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "REFERENCIABANCARIA";
            this.dataGridViewTextBoxColumn13.HeaderText = "REFERENCIA BANCARIA";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Width = 80;
            // 
            // DGFolio
            // 
            this.DGFolio.DataPropertyName = "ID";
            this.DGFolio.HeaderText = "FOLIO";
            this.DGFolio.Name = "DGFolio";
            this.DGFolio.Width = 70;
            // 
            // BANCONOMBRE
            // 
            this.BANCONOMBRE.DataPropertyName = "BANCONOMBRE";
            this.BANCONOMBRE.HeaderText = "BANCO";
            this.BANCONOMBRE.Name = "BANCONOMBRE";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "TIPOPAGOCLAVE";
            this.dataGridViewTextBoxColumn14.HeaderText = "TIPOPAGOCLAVE";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Visible = false;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "TIPOPAGONOMBRE";
            this.dataGridViewTextBoxColumn15.HeaderText = "TIPO PAGO";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.Width = 70;
            // 
            // DGTIMBRADO
            // 
            this.DGTIMBRADO.DataPropertyName = "TIMBRADO";
            this.DGTIMBRADO.HeaderText = "TIMB.";
            this.DGTIMBRADO.Name = "DGTIMBRADO";
            this.DGTIMBRADO.Width = 50;
            // 
            // DGAPLICADO
            // 
            this.DGAPLICADO.DataPropertyName = "APLICADO";
            this.DGAPLICADO.HeaderText = "APL.";
            this.DGAPLICADO.Name = "DGAPLICADO";
            this.DGAPLICADO.Width = 50;
            // 
            // DGVer
            // 
            this.DGVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DGVer.HeaderText = "";
            this.DGVer.Name = "DGVer";
            this.DGVer.Text = "Ver";
            this.DGVer.UseColumnTextForButtonValue = true;
            // 
            // pAGOLISTBindingSource
            // 
            this.pAGOLISTBindingSource.DataMember = "PAGOLIST";
            this.pAGOLISTBindingSource.DataSource = this.dSAbonos;
            // 
            // dSAbonos
            // 
            this.dSAbonos.DataSetName = "DSAbonos";
            this.dSAbonos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pAGOLISTTableAdapter
            // 
            this.pAGOLISTTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Abonos.DSAbonosTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Fecha inicial";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(307, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Aplicados";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // aplicadosComboBox
            // 
            this.aplicadosComboBox.FormattingEnabled = true;
            this.aplicadosComboBox.Items.AddRange(new object[] {
            "Aplicados",
            "No Aplicados",
            "Todos"});
            this.aplicadosComboBox.Location = new System.Drawing.Point(369, 30);
            this.aplicadosComboBox.Name = "aplicadosComboBox";
            this.aplicadosComboBox.Size = new System.Drawing.Size(96, 21);
            this.aplicadosComboBox.TabIndex = 14;
            this.aplicadosComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(307, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Timbrados";
            // 
            // timbradosComboBox
            // 
            this.timbradosComboBox.FormattingEnabled = true;
            this.timbradosComboBox.Items.AddRange(new object[] {
            "Timbrados",
            "No Timbrados",
            "Todos"});
            this.timbradosComboBox.Location = new System.Drawing.Point(369, 72);
            this.timbradosComboBox.Name = "timbradosComboBox";
            this.timbradosComboBox.Size = new System.Drawing.Size(96, 21);
            this.timbradosComboBox.TabIndex = 16;
            // 
            // FormaPagoComboBox
            // 
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
            "Deposito a terceros",
            "Todos"});
            this.FormaPagoComboBox.Location = new System.Drawing.Point(97, 30);
            this.FormaPagoComboBox.Name = "FormaPagoComboBox";
            this.FormaPagoComboBox.Size = new System.Drawing.Size(191, 21);
            this.FormaPagoComboBox.TabIndex = 78;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 79;
            this.label3.Text = "Forma de Pago";
            // 
            // timbrarPagosButton
            // 
            this.timbrarPagosButton.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.timbrarPagosButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.timbrarPagosButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timbrarPagosButton.ForeColor = System.Drawing.Color.White;
            this.timbrarPagosButton.Location = new System.Drawing.Point(369, 452);
            this.timbrarPagosButton.Name = "timbrarPagosButton";
            this.timbrarPagosButton.Size = new System.Drawing.Size(142, 23);
            this.timbrarPagosButton.TabIndex = 80;
            this.timbrarPagosButton.Text = "Timbrar Multiples Pagos";
            this.timbrarPagosButton.UseVisualStyleBackColor = false;
            this.timbrarPagosButton.Click += new System.EventHandler(this.timbrarPagosButton_Click);
            // 
            // seleccionarPagosButton
            // 
            this.seleccionarPagosButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.seleccionarPagosButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.seleccionarPagosButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.seleccionarPagosButton.ForeColor = System.Drawing.Color.White;
            this.seleccionarPagosButton.Location = new System.Drawing.Point(248, 452);
            this.seleccionarPagosButton.Name = "seleccionarPagosButton";
            this.seleccionarPagosButton.Size = new System.Drawing.Size(112, 23);
            this.seleccionarPagosButton.TabIndex = 81;
            this.seleccionarPagosButton.Text = "Seleccionar Todos";
            this.seleccionarPagosButton.UseVisualStyleBackColor = false;
            this.seleccionarPagosButton.Visible = false;
            this.seleccionarPagosButton.Click += new System.EventHandler(this.seleccionarPagosButton_Click);
            // 
            // timbrarButton
            // 
            this.timbrarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.timbrarButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.timbrarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timbrarButton.ForeColor = System.Drawing.Color.White;
            this.timbrarButton.Location = new System.Drawing.Point(520, 452);
            this.timbrarButton.Name = "timbrarButton";
            this.timbrarButton.Size = new System.Drawing.Size(103, 23);
            this.timbrarButton.TabIndex = 82;
            this.timbrarButton.Text = "Timbrar Pagos";
            this.timbrarButton.UseVisualStyleBackColor = false;
            this.timbrarButton.Visible = false;
            this.timbrarButton.Click += new System.EventHandler(this.timbrarButton_Click);
            // 
            // cancelarButton
            // 
            this.cancelarButton.BackColor = System.Drawing.Color.DarkRed;
            this.cancelarButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.cancelarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelarButton.ForeColor = System.Drawing.Color.White;
            this.cancelarButton.Location = new System.Drawing.Point(395, 452);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(99, 23);
            this.cancelarButton.TabIndex = 83;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = false;
            this.cancelarButton.Visible = false;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn1.HeaderText = "FOLIO";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "FECHA";
            this.dataGridViewTextBoxColumn7.HeaderText = "FECHA";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 70;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "BANCONOMBRE";
            this.dataGridViewTextBoxColumn8.HeaderText = "BANCO";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 70;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "TIPOPAGOCLAVE";
            this.dataGridViewTextBoxColumn10.HeaderText = "TIPOPAGOCLAVE";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "TOTALABONADO";
            this.dataGridViewTextBoxColumn11.HeaderText = "TOTAL ABONADO";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 120;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "TIMBRADO";
            this.dataGridViewTextBoxColumn12.HeaderText = "TIMBRADO";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 80;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dataGridViewButtonColumn1.HeaderText = "Ver";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "VER";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn1.Width = 60;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.HeaderText = "Editar";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.Text = "EDITAR";
            this.dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn2.Width = 60;
            // 
            // dataGridViewButtonColumn3
            // 
            this.dataGridViewButtonColumn3.HeaderText = "Recibir";
            this.dataGridViewButtonColumn3.Name = "dataGridViewButtonColumn3";
            this.dataGridViewButtonColumn3.Text = "RECIBIR";
            this.dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn3.Width = 60;
            // 
            // ITEMButton
            // 
            this.ITEMButton.BackColor = System.Drawing.Color.Transparent;
            this.ITEMButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.ITEMButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ITEMButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ITEMButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ITEMButton.Location = new System.Drawing.Point(464, 107);
            this.ITEMButton.Name = "ITEMButton";
            this.ITEMButton.Size = new System.Drawing.Size(23, 23);
            this.ITEMButton.TabIndex = 208;
            this.ITEMButton.UseVisualStyleBackColor = false;
            this.ITEMButton.Click += new System.EventHandler(this.ITEMButton_Click);
            // 
            // ITEMIDTextBox
            // 
            this.ITEMIDTextBox.BotonLookUp = null;
            this.ITEMIDTextBox.Condicion = null;
            this.ITEMIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ITEMIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ITEMIDTextBox.DbValue = null;
            this.ITEMIDTextBox.Format_Expression = null;
            this.ITEMIDTextBox.IndiceCampoDescripcion = 2;
            this.ITEMIDTextBox.IndiceCampoSelector = 1;
            this.ITEMIDTextBox.IndiceCampoValue = 0;
            this.ITEMIDTextBox.LabelDescription = this.ITEMLabel;
            this.ITEMIDTextBox.Location = new System.Drawing.Point(369, 108);
            this.ITEMIDTextBox.MostrarErrores = true;
            this.ITEMIDTextBox.Name = "ITEMIDTextBox";
            this.ITEMIDTextBox.NombreCampoSelector = "clave";
            this.ITEMIDTextBox.NombreCampoValue = "id";
            this.ITEMIDTextBox.Query = "select id, clave, nombre, gaffete from persona where tipopersonaid  in (50) ";
            this.ITEMIDTextBox.QueryDeSeleccion = "select id, clave, nombre, gaffete from persona where tipopersonaid  in (50) and  " +
    "clave= @clave";
            this.ITEMIDTextBox.QueryPorDBValue = "select id, clave ,nombre, gaffete from persona where tipopersonaid  in (50) and  " +
    "id = @id";
            this.ITEMIDTextBox.Size = new System.Drawing.Size(94, 20);
            this.ITEMIDTextBox.TabIndex = 207;
            this.ITEMIDTextBox.Tag = 34;
            this.ITEMIDTextBox.TextDescription = null;
            this.ITEMIDTextBox.Titulo = "Clientes";
            this.ITEMIDTextBox.ValidarEntrada = true;
            this.ITEMIDTextBox.ValidationExpression = null;
            // 
            // ITEMLabel
            // 
            this.ITEMLabel.AutoSize = true;
            this.ITEMLabel.BackColor = System.Drawing.Color.Transparent;
            this.ITEMLabel.ForeColor = System.Drawing.Color.White;
            this.ITEMLabel.Location = new System.Drawing.Point(491, 112);
            this.ITEMLabel.Name = "ITEMLabel";
            this.ITEMLabel.Size = new System.Drawing.Size(16, 13);
            this.ITEMLabel.TabIndex = 210;
            this.ITEMLabel.Text = "...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(307, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 209;
            this.label6.Text = "Cliente:";
            // 
            // CBIncluirCancelaciones
            // 
            this.CBIncluirCancelaciones.AutoSize = true;
            this.CBIncluirCancelaciones.BackColor = System.Drawing.Color.Transparent;
            this.CBIncluirCancelaciones.ForeColor = System.Drawing.Color.White;
            this.CBIncluirCancelaciones.Location = new System.Drawing.Point(734, 117);
            this.CBIncluirCancelaciones.Name = "CBIncluirCancelaciones";
            this.CBIncluirCancelaciones.Size = new System.Drawing.Size(126, 17);
            this.CBIncluirCancelaciones.TabIndex = 211;
            this.CBIncluirCancelaciones.Text = "Incluir cancelaciones";
            this.CBIncluirCancelaciones.UseVisualStyleBackColor = false;
            // 
            // CBSoloFiscales
            // 
            this.CBSoloFiscales.AutoSize = true;
            this.CBSoloFiscales.BackColor = System.Drawing.Color.Transparent;
            this.CBSoloFiscales.ForeColor = System.Drawing.Color.White;
            this.CBSoloFiscales.Location = new System.Drawing.Point(604, 29);
            this.CBSoloFiscales.Name = "CBSoloFiscales";
            this.CBSoloFiscales.Size = new System.Drawing.Size(187, 17);
            this.CBSoloFiscales.TabIndex = 212;
            this.CBSoloFiscales.Text = "solo movimientos fiscales a timbrar";
            this.CBSoloFiscales.UseVisualStyleBackColor = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(374, 5);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 213;
            this.progressBar1.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // pnlProgresoTimbrado
            // 
            this.pnlProgresoTimbrado.Controls.Add(this.lblProgresoTimbrado);
            this.pnlProgresoTimbrado.Controls.Add(this.progressBar1);
            this.pnlProgresoTimbrado.Location = new System.Drawing.Point(383, 481);
            this.pnlProgresoTimbrado.Name = "pnlProgresoTimbrado";
            this.pnlProgresoTimbrado.Size = new System.Drawing.Size(495, 40);
            this.pnlProgresoTimbrado.TabIndex = 214;
            this.pnlProgresoTimbrado.Visible = false;
            // 
            // lblProgresoTimbrado
            // 
            this.lblProgresoTimbrado.AutoSize = true;
            this.lblProgresoTimbrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgresoTimbrado.ForeColor = System.Drawing.Color.White;
            this.lblProgresoTimbrado.Location = new System.Drawing.Point(22, 3);
            this.lblProgresoTimbrado.Name = "lblProgresoTimbrado";
            this.lblProgresoTimbrado.Size = new System.Drawing.Size(92, 37);
            this.lblProgresoTimbrado.TabIndex = 214;
            this.lblProgresoTimbrado.Text = "0 DE";
            // 
            // WFPagosCompuestosList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(872, 521);
            this.Controls.Add(this.pnlProgresoTimbrado);
            this.Controls.Add(this.CBSoloFiscales);
            this.Controls.Add(this.CBIncluirCancelaciones);
            this.Controls.Add(this.ITEMButton);
            this.Controls.Add(this.ITEMIDTextBox);
            this.Controls.Add(this.ITEMLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.timbrarButton);
            this.Controls.Add(this.seleccionarPagosButton);
            this.Controls.Add(this.timbrarPagosButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FormaPagoComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.timbradosComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.aplicadosComboBox);
            this.Controls.Add(this.pAGOLISTDataGridView);
            this.Controls.Add(this.btnAgregarBanco);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFechaFinal);
            this.Controls.Add(this.dtpFechaInicial);
            this.Name = "WFPagosCompuestosList";
            this.Text = "Pagos";
            this.Load += new System.EventHandler(this.WFPagosCompuestosList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pAGOLISTDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAGOLISTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSAbonos)).EndInit();
            this.pnlProgresoTimbrado.ResumeLayout(false);
            this.pnlProgresoTimbrado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAgregarBanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn3;
        private Abonos.DSAbonos dSAbonos;
        private System.Windows.Forms.BindingSource pAGOLISTBindingSource;
        private Abonos.DSAbonosTableAdapters.PAGOLISTTableAdapter pAGOLISTTableAdapter;
        private Abonos.DSAbonosTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum pAGOLISTDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox aplicadosComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox timbradosComboBox;
        private System.Windows.Forms.ComboBox FormaPagoComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button timbrarPagosButton;
        private System.Windows.Forms.Button seleccionarPagosButton;
        private System.Windows.Forms.Button timbrarButton;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.Button ITEMButton;
        private Tools.TextBoxFB ITEMIDTextBox;
        private System.Windows.Forms.Label ITEMLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox CBIncluirCancelaciones;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TIMBRARCHECKBOX;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGFolio;
        private System.Windows.Forms.DataGridViewTextBoxColumn BANCONOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGTIMBRADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGAPLICADO;
        private System.Windows.Forms.DataGridViewButtonColumn DGVer;
        private System.Windows.Forms.CheckBox CBSoloFiscales;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel pnlProgresoTimbrado;
        private System.Windows.Forms.Label lblProgresoTimbrado;
    }
}