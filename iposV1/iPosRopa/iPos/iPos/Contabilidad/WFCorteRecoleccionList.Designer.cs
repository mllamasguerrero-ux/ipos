namespace iPos.Contabilidad
{
    partial class WFCorteRecoleccionList
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
            this.cORTERECOLECCIONDataGridView = new System.Windows.Forms.DataGridView();
            this.DGEDITAR = new System.Windows.Forms.DataGridViewImageColumn();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cORTERECOLECCIONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSContabilidad3 = new iPos.Contabilidad.DSContabilidad3();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CAJEROCLAVEButton = new System.Windows.Forms.Button();
            this.CAJEROCLAVETextBox = new iPos.Tools.TextBoxFB();
            this.CAJEROCLAVELabel = new System.Windows.Forms.Label();
            this.CBCajero = new System.Windows.Forms.CheckBox();
            this.CBFechaCorte = new System.Windows.Forms.CheckBox();
            this.DTPFechaInicioCorte = new System.Windows.Forms.DateTimePicker();
            this.DTPFechaFinCorte = new System.Windows.Forms.DateTimePicker();
            this.ENCARGADOCLAVEButton = new System.Windows.Forms.Button();
            this.ENCARGADOCLAVETextBox = new iPos.Tools.TextBoxFB();
            this.ENCARGADOCLAVELabel = new System.Windows.Forms.Label();
            this.CBEncargado = new System.Windows.Forms.CheckBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.TBFolioRecoleccion = new System.Windows.Forms.TextBox();
            this.CBFecha = new System.Windows.Forms.CheckBox();
            this.DTPFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.DTPFechaFin = new System.Windows.Forms.DateTimePicker();
            this.CBFolioRecoleccion = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cORTERECOLECCIONTableAdapter = new iPos.Contabilidad.DSContabilidad3TableAdapters.CORTERECOLECCIONTableAdapter();
            this.tableAdapterManager = new iPos.Contabilidad.DSContabilidad3TableAdapters.TableAdapterManager();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.cORTERECOLECCIONDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cORTERECOLECCIONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSContabilidad3)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cORTERECOLECCIONDataGridView
            // 
            this.cORTERECOLECCIONDataGridView.AllowUserToAddRows = false;
            this.cORTERECOLECCIONDataGridView.AutoGenerateColumns = false;
            this.cORTERECOLECCIONDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cORTERECOLECCIONDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGEDITAR,
            this.DGID,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.cORTERECOLECCIONDataGridView.DataSource = this.cORTERECOLECCIONBindingSource;
            this.cORTERECOLECCIONDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cORTERECOLECCIONDataGridView.Location = new System.Drawing.Point(0, 0);
            this.cORTERECOLECCIONDataGridView.Name = "cORTERECOLECCIONDataGridView";
            this.cORTERECOLECCIONDataGridView.RowHeadersVisible = false;
            this.cORTERECOLECCIONDataGridView.Size = new System.Drawing.Size(800, 239);
            this.cORTERECOLECCIONDataGridView.TabIndex = 2;
            this.cORTERECOLECCIONDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cORTERECOLECCIONDataGridView_CellContentClick);
            // 
            // DGEDITAR
            // 
            this.DGEDITAR.HeaderText = "";
            this.DGEDITAR.Image = global::iPos.Properties.Resources.Edit;
            this.DGEDITAR.Name = "DGEDITAR";
            this.DGEDITAR.Width = 30;
            // 
            // DGID
            // 
            this.DGID.DataPropertyName = "ID";
            this.DGID.HeaderText = "ID";
            this.DGID.Name = "DGID";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "NOMBREENCARGADO";
            this.dataGridViewTextBoxColumn10.HeaderText = "ENCARGADO";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 250;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ACTIVO";
            this.dataGridViewTextBoxColumn2.HeaderText = "ACTIVO";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CREADOPOR_USERID";
            this.dataGridViewTextBoxColumn4.HeaderText = "CREADOPOR_USERID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ENCARGADOID";
            this.dataGridViewTextBoxColumn7.HeaderText = "ENCARGADOID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 250;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "FECHAHORA";
            this.dataGridViewTextBoxColumn8.HeaderText = "FECHA/HORA";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 150;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "MONTO";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn9.HeaderText = "MONTO";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 250;
            // 
            // cORTERECOLECCIONBindingSource
            // 
            this.cORTERECOLECCIONBindingSource.DataMember = "CORTERECOLECCION";
            this.cORTERECOLECCIONBindingSource.DataSource = this.dSContabilidad3;
            // 
            // dSContabilidad3
            // 
            this.dSContabilidad3.DataSetName = "DSContabilidad3";
            this.dSContabilidad3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.CAJEROCLAVEButton);
            this.panel1.Controls.Add(this.CAJEROCLAVETextBox);
            this.panel1.Controls.Add(this.CAJEROCLAVELabel);
            this.panel1.Controls.Add(this.CBCajero);
            this.panel1.Controls.Add(this.CBFechaCorte);
            this.panel1.Controls.Add(this.DTPFechaInicioCorte);
            this.panel1.Controls.Add(this.DTPFechaFinCorte);
            this.panel1.Controls.Add(this.ENCARGADOCLAVEButton);
            this.panel1.Controls.Add(this.ENCARGADOCLAVETextBox);
            this.panel1.Controls.Add(this.ENCARGADOCLAVELabel);
            this.panel1.Controls.Add(this.CBEncargado);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.btnAgregar);
            this.panel1.Controls.Add(this.TBFolioRecoleccion);
            this.panel1.Controls.Add(this.CBFecha);
            this.panel1.Controls.Add(this.DTPFechaInicio);
            this.panel1.Controls.Add(this.DTPFechaFin);
            this.panel1.Controls.Add(this.CBFolioRecoleccion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 200);
            this.panel1.TabIndex = 3;
            // 
            // CAJEROCLAVEButton
            // 
            this.CAJEROCLAVEButton.BackColor = System.Drawing.Color.Transparent;
            this.CAJEROCLAVEButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.CAJEROCLAVEButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CAJEROCLAVEButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CAJEROCLAVEButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.CAJEROCLAVEButton.Location = new System.Drawing.Point(277, 165);
            this.CAJEROCLAVEButton.Name = "CAJEROCLAVEButton";
            this.CAJEROCLAVEButton.Size = new System.Drawing.Size(21, 23);
            this.CAJEROCLAVEButton.TabIndex = 182;
            this.CAJEROCLAVEButton.UseVisualStyleBackColor = false;
            // 
            // CAJEROCLAVETextBox
            // 
            this.CAJEROCLAVETextBox.BotonLookUp = this.CAJEROCLAVEButton;
            this.CAJEROCLAVETextBox.Condicion = null;
            this.CAJEROCLAVETextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.CAJEROCLAVETextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.CAJEROCLAVETextBox.DbValue = null;
            this.CAJEROCLAVETextBox.Format_Expression = null;
            this.CAJEROCLAVETextBox.IndiceCampoDescripcion = 2;
            this.CAJEROCLAVETextBox.IndiceCampoSelector = 1;
            this.CAJEROCLAVETextBox.IndiceCampoValue = 0;
            this.CAJEROCLAVETextBox.LabelDescription = this.CAJEROCLAVELabel;
            this.CAJEROCLAVETextBox.Location = new System.Drawing.Point(193, 166);
            this.CAJEROCLAVETextBox.MostrarErrores = true;
            this.CAJEROCLAVETextBox.Name = "CAJEROCLAVETextBox";
            this.CAJEROCLAVETextBox.NombreCampoSelector = "clave";
            this.CAJEROCLAVETextBox.NombreCampoValue = "id";
            this.CAJEROCLAVETextBox.Query = "select id,clave,nombre from persona where tipopersonaid in (12,13,20,21)";
            this.CAJEROCLAVETextBox.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid in (12,13,20,21)  and  cl" +
    "ave = @clave";
            this.CAJEROCLAVETextBox.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid in (12,13,20,21)  and  id" +
    " = @id";
            this.CAJEROCLAVETextBox.Size = new System.Drawing.Size(82, 20);
            this.CAJEROCLAVETextBox.TabIndex = 181;
            this.CAJEROCLAVETextBox.Tag = 34;
            this.CAJEROCLAVETextBox.TextDescription = null;
            this.CAJEROCLAVETextBox.Titulo = "Cajeros";
            this.CAJEROCLAVETextBox.ValidarEntrada = true;
            this.CAJEROCLAVETextBox.ValidationExpression = null;
            // 
            // CAJEROCLAVELabel
            // 
            this.CAJEROCLAVELabel.AutoSize = true;
            this.CAJEROCLAVELabel.BackColor = System.Drawing.Color.Transparent;
            this.CAJEROCLAVELabel.ForeColor = System.Drawing.Color.White;
            this.CAJEROCLAVELabel.Location = new System.Drawing.Point(304, 170);
            this.CAJEROCLAVELabel.Name = "CAJEROCLAVELabel";
            this.CAJEROCLAVELabel.Size = new System.Drawing.Size(16, 13);
            this.CAJEROCLAVELabel.TabIndex = 183;
            this.CAJEROCLAVELabel.Text = "...";
            // 
            // CBCajero
            // 
            this.CBCajero.AutoSize = true;
            this.CBCajero.BackColor = System.Drawing.Color.Transparent;
            this.CBCajero.ForeColor = System.Drawing.Color.White;
            this.CBCajero.Location = new System.Drawing.Point(12, 166);
            this.CBCajero.Name = "CBCajero";
            this.CBCajero.Size = new System.Drawing.Size(140, 17);
            this.CBCajero.TabIndex = 179;
            this.CBCajero.Text = "Filtro por cajero de corte";
            this.CBCajero.UseVisualStyleBackColor = false;
            // 
            // CBFechaCorte
            // 
            this.CBFechaCorte.AutoSize = true;
            this.CBFechaCorte.BackColor = System.Drawing.Color.Transparent;
            this.CBFechaCorte.ForeColor = System.Drawing.Color.White;
            this.CBFechaCorte.Location = new System.Drawing.Point(12, 130);
            this.CBFechaCorte.Name = "CBFechaCorte";
            this.CBFechaCorte.Size = new System.Drawing.Size(138, 17);
            this.CBFechaCorte.TabIndex = 178;
            this.CBFechaCorte.Text = "Filtro por fecha de corte";
            this.CBFechaCorte.UseVisualStyleBackColor = false;
            // 
            // DTPFechaInicioCorte
            // 
            this.DTPFechaInicioCorte.Location = new System.Drawing.Point(193, 127);
            this.DTPFechaInicioCorte.Name = "DTPFechaInicioCorte";
            this.DTPFechaInicioCorte.Size = new System.Drawing.Size(200, 20);
            this.DTPFechaInicioCorte.TabIndex = 177;
            // 
            // DTPFechaFinCorte
            // 
            this.DTPFechaFinCorte.Location = new System.Drawing.Point(464, 125);
            this.DTPFechaFinCorte.Name = "DTPFechaFinCorte";
            this.DTPFechaFinCorte.Size = new System.Drawing.Size(200, 20);
            this.DTPFechaFinCorte.TabIndex = 176;
            // 
            // ENCARGADOCLAVEButton
            // 
            this.ENCARGADOCLAVEButton.BackColor = System.Drawing.Color.Transparent;
            this.ENCARGADOCLAVEButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.ENCARGADOCLAVEButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ENCARGADOCLAVEButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ENCARGADOCLAVEButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ENCARGADOCLAVEButton.Location = new System.Drawing.Point(277, 91);
            this.ENCARGADOCLAVEButton.Name = "ENCARGADOCLAVEButton";
            this.ENCARGADOCLAVEButton.Size = new System.Drawing.Size(21, 23);
            this.ENCARGADOCLAVEButton.TabIndex = 174;
            this.ENCARGADOCLAVEButton.UseVisualStyleBackColor = false;
            // 
            // ENCARGADOCLAVETextBox
            // 
            this.ENCARGADOCLAVETextBox.BotonLookUp = this.ENCARGADOCLAVEButton;
            this.ENCARGADOCLAVETextBox.Condicion = null;
            this.ENCARGADOCLAVETextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ENCARGADOCLAVETextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ENCARGADOCLAVETextBox.DbValue = null;
            this.ENCARGADOCLAVETextBox.Format_Expression = null;
            this.ENCARGADOCLAVETextBox.IndiceCampoDescripcion = 2;
            this.ENCARGADOCLAVETextBox.IndiceCampoSelector = 1;
            this.ENCARGADOCLAVETextBox.IndiceCampoValue = 0;
            this.ENCARGADOCLAVETextBox.LabelDescription = this.ENCARGADOCLAVELabel;
            this.ENCARGADOCLAVETextBox.Location = new System.Drawing.Point(193, 92);
            this.ENCARGADOCLAVETextBox.MostrarErrores = true;
            this.ENCARGADOCLAVETextBox.Name = "ENCARGADOCLAVETextBox";
            this.ENCARGADOCLAVETextBox.NombreCampoSelector = "clave";
            this.ENCARGADOCLAVETextBox.NombreCampoValue = "id";
            this.ENCARGADOCLAVETextBox.Query = "select id,clave,nombre from persona where tipopersonaid = 70";
            this.ENCARGADOCLAVETextBox.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid = 70 and  clave = @clave";
            this.ENCARGADOCLAVETextBox.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid = 70 and  id = @id";
            this.ENCARGADOCLAVETextBox.Size = new System.Drawing.Size(82, 20);
            this.ENCARGADOCLAVETextBox.TabIndex = 173;
            this.ENCARGADOCLAVETextBox.Tag = 34;
            this.ENCARGADOCLAVETextBox.TextDescription = null;
            this.ENCARGADOCLAVETextBox.Titulo = "Encargados";
            this.ENCARGADOCLAVETextBox.ValidarEntrada = true;
            this.ENCARGADOCLAVETextBox.ValidationExpression = null;
            // 
            // ENCARGADOCLAVELabel
            // 
            this.ENCARGADOCLAVELabel.AutoSize = true;
            this.ENCARGADOCLAVELabel.BackColor = System.Drawing.Color.Transparent;
            this.ENCARGADOCLAVELabel.ForeColor = System.Drawing.Color.White;
            this.ENCARGADOCLAVELabel.Location = new System.Drawing.Point(304, 96);
            this.ENCARGADOCLAVELabel.Name = "ENCARGADOCLAVELabel";
            this.ENCARGADOCLAVELabel.Size = new System.Drawing.Size(16, 13);
            this.ENCARGADOCLAVELabel.TabIndex = 175;
            this.ENCARGADOCLAVELabel.Text = "...";
            // 
            // CBEncargado
            // 
            this.CBEncargado.AutoSize = true;
            this.CBEncargado.BackColor = System.Drawing.Color.Transparent;
            this.CBEncargado.ForeColor = System.Drawing.Color.White;
            this.CBEncargado.Location = new System.Drawing.Point(12, 95);
            this.CBEncargado.Name = "CBEncargado";
            this.CBEncargado.Size = new System.Drawing.Size(178, 17);
            this.CBEncargado.TabIndex = 172;
            this.CBEncargado.Text = "Filtro por encargado recoleccion";
            this.CBEncargado.UseVisualStyleBackColor = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(665, 156);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(123, 27);
            this.btnBuscar.TabIndex = 171;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnAgregar.BackgroundImage = global::iPos.Properties.Resources.Add;
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(731, 14);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(50, 29);
            this.btnAgregar.TabIndex = 170;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // TBFolioRecoleccion
            // 
            this.TBFolioRecoleccion.Location = new System.Drawing.Point(193, 23);
            this.TBFolioRecoleccion.Name = "TBFolioRecoleccion";
            this.TBFolioRecoleccion.Size = new System.Drawing.Size(94, 20);
            this.TBFolioRecoleccion.TabIndex = 169;
            // 
            // CBFecha
            // 
            this.CBFecha.AutoSize = true;
            this.CBFecha.BackColor = System.Drawing.Color.Transparent;
            this.CBFecha.Checked = true;
            this.CBFecha.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBFecha.ForeColor = System.Drawing.Color.White;
            this.CBFecha.Location = new System.Drawing.Point(12, 59);
            this.CBFecha.Name = "CBFecha";
            this.CBFecha.Size = new System.Drawing.Size(169, 17);
            this.CBFecha.TabIndex = 168;
            this.CBFecha.Text = "Filtro por fecha de recoleccion";
            this.CBFecha.UseVisualStyleBackColor = false;
            // 
            // DTPFechaInicio
            // 
            this.DTPFechaInicio.Location = new System.Drawing.Point(193, 56);
            this.DTPFechaInicio.Name = "DTPFechaInicio";
            this.DTPFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.DTPFechaInicio.TabIndex = 167;
            // 
            // DTPFechaFin
            // 
            this.DTPFechaFin.Location = new System.Drawing.Point(464, 54);
            this.DTPFechaFin.Name = "DTPFechaFin";
            this.DTPFechaFin.Size = new System.Drawing.Size(200, 20);
            this.DTPFechaFin.TabIndex = 166;
            // 
            // CBFolioRecoleccion
            // 
            this.CBFolioRecoleccion.AutoSize = true;
            this.CBFolioRecoleccion.BackColor = System.Drawing.Color.Transparent;
            this.CBFolioRecoleccion.ForeColor = System.Drawing.Color.White;
            this.CBFolioRecoleccion.Location = new System.Drawing.Point(12, 26);
            this.CBFolioRecoleccion.Name = "CBFolioRecoleccion";
            this.CBFolioRecoleccion.Size = new System.Drawing.Size(161, 17);
            this.CBFolioRecoleccion.TabIndex = 165;
            this.CBFolioRecoleccion.Text = "Filtro por folio de recoleccion";
            this.CBFolioRecoleccion.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 439);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 11);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cORTERECOLECCIONDataGridView);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 200);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 239);
            this.panel3.TabIndex = 5;
            // 
            // cORTERECOLECCIONTableAdapter
            // 
            this.cORTERECOLECCIONTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Contabilidad.DSContabilidad3TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // WFCorteRecoleccionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "WFCorteRecoleccionList";
            this.Text = "RECOLECCIONES DE CORTES";
            this.Load += new System.EventHandler(this.WFCorteRecoleccionList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cORTERECOLECCIONDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cORTERECOLECCIONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSContabilidad3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DSContabilidad3 dSContabilidad3;
        private System.Windows.Forms.BindingSource cORTERECOLECCIONBindingSource;
        private DSContabilidad3TableAdapters.CORTERECOLECCIONTableAdapter cORTERECOLECCIONTableAdapter;
        private DSContabilidad3TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView cORTERECOLECCIONDataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox TBFolioRecoleccion;
        private System.Windows.Forms.CheckBox CBFecha;
        private System.Windows.Forms.DateTimePicker DTPFechaInicio;
        private System.Windows.Forms.DateTimePicker DTPFechaFin;
        private System.Windows.Forms.CheckBox CBFolioRecoleccion;
        private System.Windows.Forms.CheckBox CBCajero;
        private System.Windows.Forms.CheckBox CBFechaCorte;
        private System.Windows.Forms.DateTimePicker DTPFechaInicioCorte;
        private System.Windows.Forms.DateTimePicker DTPFechaFinCorte;
        private System.Windows.Forms.Button ENCARGADOCLAVEButton;
        private Tools.TextBoxFB ENCARGADOCLAVETextBox;
        private System.Windows.Forms.Label ENCARGADOCLAVELabel;
        private System.Windows.Forms.CheckBox CBEncargado;
        private System.Windows.Forms.Button CAJEROCLAVEButton;
        private Tools.TextBoxFB CAJEROCLAVETextBox;
        private System.Windows.Forms.Label CAJEROCLAVELabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewImageColumn DGEDITAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    }
}