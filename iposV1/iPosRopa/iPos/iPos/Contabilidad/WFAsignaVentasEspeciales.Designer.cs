namespace iPos
{
    partial class WFAsignaVentasEspeciales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFAsignaVentasEspeciales));
            this.aPARTADOSPENDIENTESDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.vENTASESPECIALESASIGNACIONESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSContabilidad3 = new iPos.Contabilidad.DSContabilidad3();
            this.DPInicio = new System.Windows.Forms.DateTimePicker();
            this.DPFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar00 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.CBTodosClientes = new System.Windows.Forms.CheckBox();
            this.CLIENTEButton = new System.Windows.Forms.Button();
            this.CLIENTETextBox = new iPos.Tools.TextBoxFB();
            this.CLIENTELabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TBFolio = new System.Windows.Forms.TextBox();
            this.CBTodosFolios = new System.Windows.Forms.CheckBox();
            this.vENTASESPECIALESASIGNACIONESTableAdapter = new iPos.Contabilidad.DSContabilidad3TableAdapters.VENTASESPECIALESASIGNACIONESTableAdapter();
            this.tableAdapterManager1 = new iPos.Contabilidad.DSContabilidad3TableAdapters.TableAdapterManager();
            this.DGESVENTAESPECIAL = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGMODIFICADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.aPARTADOSPENDIENTESDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vENTASESPECIALESASIGNACIONESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSContabilidad3)).BeginInit();
            this.SuspendLayout();
            // 
            // aPARTADOSPENDIENTESDataGridView
            // 
            this.aPARTADOSPENDIENTESDataGridView.AllowUserToAddRows = false;
            this.aPARTADOSPENDIENTESDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.aPARTADOSPENDIENTESDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.aPARTADOSPENDIENTESDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.aPARTADOSPENDIENTESDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGESVENTAESPECIAL,
            this.DGMODIFICADO,
            this.dataGridViewTextBoxColumn2,
            this.FECHA,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.DGID});
            this.aPARTADOSPENDIENTESDataGridView.DataSource = this.vENTASESPECIALESASIGNACIONESBindingSource;
            this.aPARTADOSPENDIENTESDataGridView.Location = new System.Drawing.Point(3, 150);
            this.aPARTADOSPENDIENTESDataGridView.Name = "aPARTADOSPENDIENTESDataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.aPARTADOSPENDIENTESDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.aPARTADOSPENDIENTESDataGridView.RowHeadersVisible = false;
            this.aPARTADOSPENDIENTESDataGridView.Size = new System.Drawing.Size(755, 223);
            this.aPARTADOSPENDIENTESDataGridView.TabIndex = 2;
            this.aPARTADOSPENDIENTESDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.aPARTADOSPENDIENTESDataGridView_CellValueChanged);
            // 
            // vENTASESPECIALESASIGNACIONESBindingSource
            // 
            this.vENTASESPECIALESASIGNACIONESBindingSource.DataMember = "VENTASESPECIALESASIGNACIONES";
            this.vENTASESPECIALESASIGNACIONESBindingSource.DataSource = this.dSContabilidad3;
            // 
            // dSContabilidad3
            // 
            this.dSContabilidad3.DataSetName = "DSContabilidad3";
            this.dSContabilidad3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DPInicio
            // 
            this.DPInicio.Location = new System.Drawing.Point(121, 42);
            this.DPInicio.Name = "DPInicio";
            this.DPInicio.Size = new System.Drawing.Size(200, 20);
            this.DPInicio.TabIndex = 3;
            // 
            // DPFin
            // 
            this.DPFin.Location = new System.Drawing.Point(510, 42);
            this.DPFin.Name = "DPFin";
            this.DPFin.Size = new System.Drawing.Size(200, 20);
            this.DPFin.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(39, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "De la fecha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(440, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "A la fecha:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(39, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Asigna ventas especiales";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(596, 116);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 23);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.Location = new System.Drawing.Point(58, 393);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(237, 39);
            this.btnEnviar.TabIndex = 11;
            this.btnEnviar.Text = "Aplicar operaciones seleccionadas";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(397, 392);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(237, 39);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar00
            // 
            this.progressBar00.Location = new System.Drawing.Point(163, 441);
            this.progressBar00.Name = "progressBar00";
            this.progressBar00.Size = new System.Drawing.Size(132, 23);
            this.progressBar00.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(108, 445);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Progreso";
            // 
            // CBTodosClientes
            // 
            this.CBTodosClientes.AutoSize = true;
            this.CBTodosClientes.BackColor = System.Drawing.Color.Transparent;
            this.CBTodosClientes.Checked = true;
            this.CBTodosClientes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBTodosClientes.ForeColor = System.Drawing.Color.White;
            this.CBTodosClientes.Location = new System.Drawing.Point(107, 82);
            this.CBTodosClientes.Name = "CBTodosClientes";
            this.CBTodosClientes.Size = new System.Drawing.Size(56, 17);
            this.CBTodosClientes.TabIndex = 207;
            this.CBTodosClientes.Text = "Todos";
            this.CBTodosClientes.UseVisualStyleBackColor = false;
            // 
            // CLIENTEButton
            // 
            this.CLIENTEButton.BackColor = System.Drawing.Color.Transparent;
            this.CLIENTEButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.CLIENTEButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CLIENTEButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CLIENTEButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.CLIENTEButton.Location = new System.Drawing.Point(274, 77);
            this.CLIENTEButton.Name = "CLIENTEButton";
            this.CLIENTEButton.Size = new System.Drawing.Size(21, 23);
            this.CLIENTEButton.TabIndex = 204;
            this.CLIENTEButton.UseVisualStyleBackColor = false;
            // 
            // CLIENTETextBox
            // 
            this.CLIENTETextBox.BotonLookUp = this.CLIENTEButton;
            this.CLIENTETextBox.Condicion = null;
            this.CLIENTETextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.CLIENTETextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.CLIENTETextBox.DbValue = null;
            this.CLIENTETextBox.Format_Expression = null;
            this.CLIENTETextBox.IndiceCampoDescripcion = 2;
            this.CLIENTETextBox.IndiceCampoSelector = 1;
            this.CLIENTETextBox.IndiceCampoValue = 0;
            this.CLIENTETextBox.LabelDescription = this.CLIENTELabel;
            this.CLIENTETextBox.Location = new System.Drawing.Point(173, 80);
            this.CLIENTETextBox.MostrarErrores = true;
            this.CLIENTETextBox.Name = "CLIENTETextBox";
            this.CLIENTETextBox.NombreCampoSelector = "clave";
            this.CLIENTETextBox.NombreCampoValue = "id";
            this.CLIENTETextBox.Query = "select id, clave, nombre, gaffete from persona where tipopersonaid  in (50) ";
            this.CLIENTETextBox.QueryDeSeleccion = "select id, clave, nombre, gaffete from persona where tipopersonaid  in (50) and  " +
    "clave= @clave";
            this.CLIENTETextBox.QueryPorDBValue = "select id, clave ,nombre, gaffete from persona where tipopersonaid  in (50) and  " +
    "id = @id";
            this.CLIENTETextBox.Size = new System.Drawing.Size(95, 20);
            this.CLIENTETextBox.TabIndex = 203;
            this.CLIENTETextBox.Tag = 34;
            this.CLIENTETextBox.TextDescription = null;
            this.CLIENTETextBox.Titulo = "Clientes";
            this.CLIENTETextBox.ValidarEntrada = true;
            this.CLIENTETextBox.ValidationExpression = null;
            // 
            // CLIENTELabel
            // 
            this.CLIENTELabel.AutoSize = true;
            this.CLIENTELabel.BackColor = System.Drawing.Color.Transparent;
            this.CLIENTELabel.ForeColor = System.Drawing.Color.White;
            this.CLIENTELabel.Location = new System.Drawing.Point(301, 83);
            this.CLIENTELabel.Name = "CLIENTELabel";
            this.CLIENTELabel.Size = new System.Drawing.Size(16, 13);
            this.CLIENTELabel.TabIndex = 206;
            this.CLIENTELabel.Text = "...";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(51, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 205;
            this.label6.Text = "Cliente:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(469, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 208;
            this.label5.Text = "Folio:";
            // 
            // TBFolio
            // 
            this.TBFolio.Location = new System.Drawing.Point(603, 84);
            this.TBFolio.Name = "TBFolio";
            this.TBFolio.Size = new System.Drawing.Size(105, 20);
            this.TBFolio.TabIndex = 209;
            // 
            // CBTodosFolios
            // 
            this.CBTodosFolios.AutoSize = true;
            this.CBTodosFolios.BackColor = System.Drawing.Color.Transparent;
            this.CBTodosFolios.Checked = true;
            this.CBTodosFolios.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBTodosFolios.ForeColor = System.Drawing.Color.White;
            this.CBTodosFolios.Location = new System.Drawing.Point(516, 86);
            this.CBTodosFolios.Name = "CBTodosFolios";
            this.CBTodosFolios.Size = new System.Drawing.Size(56, 17);
            this.CBTodosFolios.TabIndex = 210;
            this.CBTodosFolios.Text = "Todos";
            this.CBTodosFolios.UseVisualStyleBackColor = false;
            // 
            // vENTASESPECIALESASIGNACIONESTableAdapter
            // 
            this.vENTASESPECIALESASIGNACIONESTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.UpdateOrder = iPos.Contabilidad.DSContabilidad3TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // DGESVENTAESPECIAL
            // 
            this.DGESVENTAESPECIAL.DataPropertyName = "ESVENTAESPECIAL";
            this.DGESVENTAESPECIAL.FalseValue = "N";
            this.DGESVENTAESPECIAL.HeaderText = "ES VENTA ESPECIAL";
            this.DGESVENTAESPECIAL.Name = "DGESVENTAESPECIAL";
            this.DGESVENTAESPECIAL.TrueValue = "S";
            // 
            // DGMODIFICADO
            // 
            this.DGMODIFICADO.DataPropertyName = "MODIFICADO";
            this.DGMODIFICADO.HeaderText = "MODIFICADO";
            this.DGMODIFICADO.Name = "DGMODIFICADO";
            this.DGMODIFICADO.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FOLIO";
            this.dataGridViewTextBoxColumn2.HeaderText = "FOLIO";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // FECHA
            // 
            this.FECHA.DataPropertyName = "FECHA";
            this.FECHA.HeaderText = "FECHA";
            this.FECHA.Name = "FECHA";
            this.FECHA.ReadOnly = true;
            this.FECHA.Width = 75;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NOMBRES";
            this.dataGridViewTextBoxColumn3.HeaderText = "NOMBRES";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "APELLIDOS";
            this.dataGridViewTextBoxColumn4.HeaderText = "APELLIDOS";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "TOTAL";
            this.dataGridViewTextBoxColumn5.HeaderText = "TOTAL";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 90;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ABONO";
            this.dataGridViewTextBoxColumn6.HeaderText = "ABONO";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 90;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "SALDO";
            this.dataGridViewTextBoxColumn7.HeaderText = "SALDO";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 90;
            // 
            // DGID
            // 
            this.DGID.DataPropertyName = "ID";
            this.DGID.HeaderText = "ID";
            this.DGID.Name = "DGID";
            this.DGID.Visible = false;
            // 
            // WFAsignaVentasEspeciales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(770, 481);
            this.Controls.Add(this.CBTodosFolios);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TBFolio);
            this.Controls.Add(this.CBTodosClientes);
            this.Controls.Add(this.CLIENTEButton);
            this.Controls.Add(this.CLIENTETextBox);
            this.Controls.Add(this.CLIENTELabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressBar00);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DPFin);
            this.Controls.Add(this.DPInicio);
            this.Controls.Add(this.aPARTADOSPENDIENTESDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFAsignaVentasEspeciales";
            this.Text = "Asigna Ventas Especiales";
            ((System.ComponentModel.ISupportInitialize)(this.aPARTADOSPENDIENTESDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vENTASESPECIALESASIGNACIONESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSContabilidad3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewSum aPARTADOSPENDIENTESDataGridView;
        private System.Windows.Forms.DateTimePicker DPInicio;
        private System.Windows.Forms.DateTimePicker DPFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar00;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox CBTodosClientes;
        private System.Windows.Forms.Button CLIENTEButton;
        private Tools.TextBoxFB CLIENTETextBox;
        private System.Windows.Forms.Label CLIENTELabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TBFolio;
        private System.Windows.Forms.CheckBox CBTodosFolios;
        private Contabilidad.DSContabilidad3 dSContabilidad3;
        private System.Windows.Forms.BindingSource vENTASESPECIALESASIGNACIONESBindingSource;
        private Contabilidad.DSContabilidad3TableAdapters.VENTASESPECIALESASIGNACIONESTableAdapter vENTASESPECIALESASIGNACIONESTableAdapter;
        private Contabilidad.DSContabilidad3TableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGESVENTAESPECIAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGMODIFICADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
    }
}