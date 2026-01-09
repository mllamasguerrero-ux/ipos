namespace iPos
{
    partial class WFListaInventarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFListaInventarios));
            this.BTCapturar = new System.Windows.Forms.Button();
            this.DTPFecha = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RB_Estatus_Todas = new System.Windows.Forms.RadioButton();
            this.RB_Estatus_Cerradas = new System.Windows.Forms.RadioButton();
            this.RB_Estatus_Pendientes = new System.Windows.Forms.RadioButton();
            this.BTLlenar = new System.Windows.Forms.Button();
            this.LBFecha = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridViewSum();
            this.CONSECUTIVO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ALMACENNOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPOINVENTARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCICLICO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLAVEESTATUSDOCTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAJA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TURNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PERSONA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sUCURSALDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sUCURSALIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAJAIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tURNOIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fECHADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sERIEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tOTALDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESTATUSDOCTOID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGTIPODOCTOID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rEFERENCIADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listaInventarioFisicoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSInventarioFisico = new iPos.Inventario.DSInventarioFisico();
            this.BTEditar = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTCapturarXLoc = new System.Windows.Forms.Button();
            this.btnImprimirInvActual = new System.Windows.Forms.Button();
            this.btnLimpiarInventariosNoTerminados = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RBNoCiclicos = new System.Windows.Forms.RadioButton();
            this.RBCiclicos = new System.Windows.Forms.RadioButton();
            this.RBTodos = new System.Windows.Forms.RadioButton();
            this.listaInventarioFisicoTableAdapter = new iPos.Inventario.DSInventarioFisicoTableAdapters.ListaInventarioFisicoTableAdapter();
            this.tableAdapterManager = new iPos.Inventario.DSInventarioFisicoTableAdapters.TableAdapterManager();
            this.btnReconteo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaInventarioFisicoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSInventarioFisico)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTCapturar
            // 
            this.BTCapturar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTCapturar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTCapturar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCapturar.ForeColor = System.Drawing.Color.White;
            this.BTCapturar.Location = new System.Drawing.Point(856, 60);
            this.BTCapturar.Name = "BTCapturar";
            this.BTCapturar.Size = new System.Drawing.Size(125, 40);
            this.BTCapturar.TabIndex = 3;
            this.BTCapturar.Text = "Nuevo";
            this.BTCapturar.UseVisualStyleBackColor = false;
            this.BTCapturar.Click += new System.EventHandler(this.BTCapturar_Click);
            // 
            // DTPFecha
            // 
            this.DTPFecha.Location = new System.Drawing.Point(556, 29);
            this.DTPFecha.Name = "DTPFecha";
            this.DTPFecha.Size = new System.Drawing.Size(233, 20);
            this.DTPFecha.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.RB_Estatus_Todas);
            this.groupBox1.Controls.Add(this.RB_Estatus_Cerradas);
            this.groupBox1.Controls.Add(this.RB_Estatus_Pendientes);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 42);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estatus";
            // 
            // RB_Estatus_Todas
            // 
            this.RB_Estatus_Todas.AutoSize = true;
            this.RB_Estatus_Todas.Checked = true;
            this.RB_Estatus_Todas.ForeColor = System.Drawing.Color.White;
            this.RB_Estatus_Todas.Location = new System.Drawing.Point(189, 20);
            this.RB_Estatus_Todas.Name = "RB_Estatus_Todas";
            this.RB_Estatus_Todas.Size = new System.Drawing.Size(60, 17);
            this.RB_Estatus_Todas.TabIndex = 2;
            this.RB_Estatus_Todas.TabStop = true;
            this.RB_Estatus_Todas.Text = "Todas";
            this.RB_Estatus_Todas.UseVisualStyleBackColor = true;
            // 
            // RB_Estatus_Cerradas
            // 
            this.RB_Estatus_Cerradas.AutoSize = true;
            this.RB_Estatus_Cerradas.ForeColor = System.Drawing.Color.White;
            this.RB_Estatus_Cerradas.Location = new System.Drawing.Point(103, 20);
            this.RB_Estatus_Cerradas.Name = "RB_Estatus_Cerradas";
            this.RB_Estatus_Cerradas.Size = new System.Drawing.Size(75, 17);
            this.RB_Estatus_Cerradas.TabIndex = 1;
            this.RB_Estatus_Cerradas.Text = "Cerradas";
            this.RB_Estatus_Cerradas.UseVisualStyleBackColor = true;
            // 
            // RB_Estatus_Pendientes
            // 
            this.RB_Estatus_Pendientes.AutoSize = true;
            this.RB_Estatus_Pendientes.ForeColor = System.Drawing.Color.White;
            this.RB_Estatus_Pendientes.Location = new System.Drawing.Point(6, 20);
            this.RB_Estatus_Pendientes.Name = "RB_Estatus_Pendientes";
            this.RB_Estatus_Pendientes.Size = new System.Drawing.Size(88, 17);
            this.RB_Estatus_Pendientes.TabIndex = 0;
            this.RB_Estatus_Pendientes.Text = "Pendientes";
            this.RB_Estatus_Pendientes.UseVisualStyleBackColor = true;
            // 
            // BTLlenar
            // 
            this.BTLlenar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTLlenar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTLlenar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTLlenar.ForeColor = System.Drawing.Color.White;
            this.BTLlenar.Location = new System.Drawing.Point(805, 26);
            this.BTLlenar.Name = "BTLlenar";
            this.BTLlenar.Size = new System.Drawing.Size(87, 23);
            this.BTLlenar.TabIndex = 6;
            this.BTLlenar.Text = "Llenar";
            this.BTLlenar.UseVisualStyleBackColor = false;
            this.BTLlenar.Click += new System.EventHandler(this.BTLlenar_Click);
            // 
            // LBFecha
            // 
            this.LBFecha.AutoSize = true;
            this.LBFecha.BackColor = System.Drawing.Color.Transparent;
            this.LBFecha.ForeColor = System.Drawing.Color.White;
            this.LBFecha.Location = new System.Drawing.Point(503, 34);
            this.LBFecha.Name = "LBFecha";
            this.LBFecha.Size = new System.Drawing.Size(47, 13);
            this.LBFecha.TabIndex = 7;
            this.LBFecha.Text = "Desde:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CONSECUTIVO,
            this.ALMACENNOMBRE,
            this.TIPOINVENTARIO,
            this.DGCICLICO,
            this.CLAVEESTATUSDOCTO,
            this.CAJA,
            this.TURNO,
            this.PERSONA,
            this.FECHA,
            this.sUCURSALDataGridViewTextBoxColumn,
            this.sUCURSALIDDataGridViewTextBoxColumn,
            this.cAJAIDDataGridViewTextBoxColumn,
            this.tURNOIDDataGridViewTextBoxColumn,
            this.fECHADataGridViewTextBoxColumn,
            this.sERIEDataGridViewTextBoxColumn,
            this.tOTALDataGridViewTextBoxColumn,
            this.ESTATUSDOCTOID,
            this.DGTIPODOCTOID,
            this.rEFERENCIADataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.listaInventarioFisicoBindingSource;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(14, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(820, 252);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // CONSECUTIVO
            // 
            this.CONSECUTIVO.DataPropertyName = "CONSECUTIVO";
            this.CONSECUTIVO.HeaderText = "CONS.";
            this.CONSECUTIVO.Name = "CONSECUTIVO";
            this.CONSECUTIVO.ReadOnly = true;
            this.CONSECUTIVO.Width = 80;
            // 
            // ALMACENNOMBRE
            // 
            this.ALMACENNOMBRE.DataPropertyName = "ALMACENNOMBRE";
            this.ALMACENNOMBRE.HeaderText = "ALMACEN";
            this.ALMACENNOMBRE.Name = "ALMACENNOMBRE";
            this.ALMACENNOMBRE.ReadOnly = true;
            this.ALMACENNOMBRE.Width = 80;
            // 
            // TIPOINVENTARIO
            // 
            this.TIPOINVENTARIO.DataPropertyName = "TIPOINVENTARIO";
            this.TIPOINVENTARIO.HeaderText = "TIPO";
            this.TIPOINVENTARIO.Name = "TIPOINVENTARIO";
            this.TIPOINVENTARIO.ReadOnly = true;
            this.TIPOINVENTARIO.Width = 125;
            // 
            // DGCICLICO
            // 
            this.DGCICLICO.DataPropertyName = "CICLICO";
            this.DGCICLICO.HeaderText = "CICLICO";
            this.DGCICLICO.Name = "DGCICLICO";
            this.DGCICLICO.ReadOnly = true;
            this.DGCICLICO.Width = 65;
            // 
            // CLAVEESTATUSDOCTO
            // 
            this.CLAVEESTATUSDOCTO.DataPropertyName = "CLAVEESTATUSDOCTO";
            this.CLAVEESTATUSDOCTO.HeaderText = "ESTATUS";
            this.CLAVEESTATUSDOCTO.Name = "CLAVEESTATUSDOCTO";
            this.CLAVEESTATUSDOCTO.ReadOnly = true;
            // 
            // CAJA
            // 
            this.CAJA.DataPropertyName = "CAJA";
            this.CAJA.HeaderText = "CAJA";
            this.CAJA.Name = "CAJA";
            this.CAJA.ReadOnly = true;
            // 
            // TURNO
            // 
            this.TURNO.DataPropertyName = "TURNO";
            this.TURNO.HeaderText = "TURNO";
            this.TURNO.Name = "TURNO";
            this.TURNO.ReadOnly = true;
            this.TURNO.Visible = false;
            // 
            // PERSONA
            // 
            this.PERSONA.DataPropertyName = "PERSONA";
            this.PERSONA.HeaderText = "USUARIO";
            this.PERSONA.Name = "PERSONA";
            this.PERSONA.ReadOnly = true;
            // 
            // FECHA
            // 
            this.FECHA.DataPropertyName = "FECHA";
            this.FECHA.HeaderText = "FECHA";
            this.FECHA.Name = "FECHA";
            this.FECHA.ReadOnly = true;
            // 
            // sUCURSALDataGridViewTextBoxColumn
            // 
            this.sUCURSALDataGridViewTextBoxColumn.DataPropertyName = "SUCURSAL";
            this.sUCURSALDataGridViewTextBoxColumn.HeaderText = "SUCURSAL";
            this.sUCURSALDataGridViewTextBoxColumn.Name = "sUCURSALDataGridViewTextBoxColumn";
            this.sUCURSALDataGridViewTextBoxColumn.ReadOnly = true;
            this.sUCURSALDataGridViewTextBoxColumn.Visible = false;
            // 
            // sUCURSALIDDataGridViewTextBoxColumn
            // 
            this.sUCURSALIDDataGridViewTextBoxColumn.DataPropertyName = "SUCURSALID";
            this.sUCURSALIDDataGridViewTextBoxColumn.HeaderText = "SUCURSALID";
            this.sUCURSALIDDataGridViewTextBoxColumn.Name = "sUCURSALIDDataGridViewTextBoxColumn";
            this.sUCURSALIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.sUCURSALIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // cAJAIDDataGridViewTextBoxColumn
            // 
            this.cAJAIDDataGridViewTextBoxColumn.DataPropertyName = "CAJAID";
            this.cAJAIDDataGridViewTextBoxColumn.HeaderText = "CAJAID";
            this.cAJAIDDataGridViewTextBoxColumn.Name = "cAJAIDDataGridViewTextBoxColumn";
            this.cAJAIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.cAJAIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // tURNOIDDataGridViewTextBoxColumn
            // 
            this.tURNOIDDataGridViewTextBoxColumn.DataPropertyName = "TURNOID";
            this.tURNOIDDataGridViewTextBoxColumn.HeaderText = "TURNOID";
            this.tURNOIDDataGridViewTextBoxColumn.Name = "tURNOIDDataGridViewTextBoxColumn";
            this.tURNOIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.tURNOIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // fECHADataGridViewTextBoxColumn
            // 
            this.fECHADataGridViewTextBoxColumn.DataPropertyName = "FECHA";
            this.fECHADataGridViewTextBoxColumn.HeaderText = "FECHA";
            this.fECHADataGridViewTextBoxColumn.Name = "fECHADataGridViewTextBoxColumn";
            this.fECHADataGridViewTextBoxColumn.ReadOnly = true;
            this.fECHADataGridViewTextBoxColumn.Visible = false;
            // 
            // sERIEDataGridViewTextBoxColumn
            // 
            this.sERIEDataGridViewTextBoxColumn.DataPropertyName = "SERIE";
            this.sERIEDataGridViewTextBoxColumn.HeaderText = "SERIE";
            this.sERIEDataGridViewTextBoxColumn.Name = "sERIEDataGridViewTextBoxColumn";
            this.sERIEDataGridViewTextBoxColumn.ReadOnly = true;
            this.sERIEDataGridViewTextBoxColumn.Visible = false;
            // 
            // tOTALDataGridViewTextBoxColumn
            // 
            this.tOTALDataGridViewTextBoxColumn.DataPropertyName = "TOTAL";
            this.tOTALDataGridViewTextBoxColumn.HeaderText = "TOTAL";
            this.tOTALDataGridViewTextBoxColumn.Name = "tOTALDataGridViewTextBoxColumn";
            this.tOTALDataGridViewTextBoxColumn.ReadOnly = true;
            this.tOTALDataGridViewTextBoxColumn.Visible = false;
            // 
            // ESTATUSDOCTOID
            // 
            this.ESTATUSDOCTOID.DataPropertyName = "ESTATUSDOCTOID";
            this.ESTATUSDOCTOID.HeaderText = "ESTATUSDOCTOID";
            this.ESTATUSDOCTOID.Name = "ESTATUSDOCTOID";
            this.ESTATUSDOCTOID.ReadOnly = true;
            this.ESTATUSDOCTOID.Visible = false;
            // 
            // DGTIPODOCTOID
            // 
            this.DGTIPODOCTOID.DataPropertyName = "TIPODOCTOID";
            this.DGTIPODOCTOID.HeaderText = "TIPODOCTOID";
            this.DGTIPODOCTOID.Name = "DGTIPODOCTOID";
            this.DGTIPODOCTOID.ReadOnly = true;
            this.DGTIPODOCTOID.Visible = false;
            // 
            // rEFERENCIADataGridViewTextBoxColumn
            // 
            this.rEFERENCIADataGridViewTextBoxColumn.DataPropertyName = "REFERENCIA";
            this.rEFERENCIADataGridViewTextBoxColumn.HeaderText = "REFERENCIA";
            this.rEFERENCIADataGridViewTextBoxColumn.Name = "rEFERENCIADataGridViewTextBoxColumn";
            this.rEFERENCIADataGridViewTextBoxColumn.ReadOnly = true;
            this.rEFERENCIADataGridViewTextBoxColumn.Visible = false;
            // 
            // listaInventarioFisicoBindingSource
            // 
            this.listaInventarioFisicoBindingSource.DataMember = "ListaInventarioFisico";
            this.listaInventarioFisicoBindingSource.DataSource = this.dSInventarioFisico;
            // 
            // dSInventarioFisico
            // 
            this.dSInventarioFisico.DataSetName = "DSInventarioFisico";
            this.dSInventarioFisico.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BTEditar
            // 
            this.BTEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEditar.ForeColor = System.Drawing.Color.White;
            this.BTEditar.Location = new System.Drawing.Point(856, 173);
            this.BTEditar.Name = "BTEditar";
            this.BTEditar.Size = new System.Drawing.Size(125, 44);
            this.BTEditar.TabIndex = 9;
            this.BTEditar.Text = "Editar/Consultar";
            this.BTEditar.UseVisualStyleBackColor = false;
            this.BTEditar.Click += new System.EventHandler(this.BTEditar_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CONSECUTIVO";
            this.dataGridViewTextBoxColumn1.HeaderText = "CONSECUTIVO";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FOLIO";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn2.HeaderText = "FOLIO";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CLAVEESTATUSDOCTO";
            this.dataGridViewTextBoxColumn3.HeaderText = "CLAVEESTATUSDOCTO";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CAJA";
            this.dataGridViewTextBoxColumn4.HeaderText = "CAJA";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "TURNO";
            this.dataGridViewTextBoxColumn5.HeaderText = "TURNO";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "FECHA";
            this.dataGridViewTextBoxColumn6.HeaderText = "FECHA";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "SUCURSAL";
            this.dataGridViewTextBoxColumn7.HeaderText = "SUCURSAL";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "SUCURSALID";
            this.dataGridViewTextBoxColumn8.HeaderText = "SUCURSALID";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "CAJAID";
            this.dataGridViewTextBoxColumn9.HeaderText = "CAJAID";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "TURNOID";
            this.dataGridViewTextBoxColumn10.HeaderText = "TURNOID";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "FECHA";
            this.dataGridViewTextBoxColumn11.HeaderText = "FECHA";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "SERIE";
            this.dataGridViewTextBoxColumn12.HeaderText = "SERIE";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Visible = false;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "TOTAL";
            this.dataGridViewTextBoxColumn13.HeaderText = "TOTAL";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Visible = false;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "ESTATUSDOCTOID";
            this.dataGridViewTextBoxColumn14.HeaderText = "ESTATUSDOCTOID";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Visible = false;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "REFERENCIA";
            this.dataGridViewTextBoxColumn15.HeaderText = "REFERENCIA";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Visible = false;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "REFERENCIA";
            this.dataGridViewTextBoxColumn16.HeaderText = "REFERENCIA";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Visible = false;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "REFERENCIA";
            this.dataGridViewTextBoxColumn17.HeaderText = "REFERENCIA";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Visible = false;
            // 
            // BTCapturarXLoc
            // 
            this.BTCapturarXLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTCapturarXLoc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTCapturarXLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCapturarXLoc.ForeColor = System.Drawing.Color.White;
            this.BTCapturarXLoc.Location = new System.Drawing.Point(856, 114);
            this.BTCapturarXLoc.Name = "BTCapturarXLoc";
            this.BTCapturarXLoc.Size = new System.Drawing.Size(125, 46);
            this.BTCapturarXLoc.TabIndex = 10;
            this.BTCapturarXLoc.Text = "Nuevo por localidad";
            this.BTCapturarXLoc.UseVisualStyleBackColor = false;
            this.BTCapturarXLoc.Click += new System.EventHandler(this.BTCapturarXLoc_Click);
            // 
            // btnImprimirInvActual
            // 
            this.btnImprimirInvActual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnImprimirInvActual.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnImprimirInvActual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirInvActual.ForeColor = System.Drawing.Color.White;
            this.btnImprimirInvActual.Location = new System.Drawing.Point(856, 289);
            this.btnImprimirInvActual.Name = "btnImprimirInvActual";
            this.btnImprimirInvActual.Size = new System.Drawing.Size(125, 44);
            this.btnImprimirInvActual.TabIndex = 11;
            this.btnImprimirInvActual.Text = "Imprimir inventario actual";
            this.btnImprimirInvActual.UseVisualStyleBackColor = false;
            this.btnImprimirInvActual.Click += new System.EventHandler(this.btnImprimirInvActual_Click);
            // 
            // btnLimpiarInventariosNoTerminados
            // 
            this.btnLimpiarInventariosNoTerminados.BackColor = System.Drawing.Color.Firebrick;
            this.btnLimpiarInventariosNoTerminados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarInventariosNoTerminados.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarInventariosNoTerminados.Location = new System.Drawing.Point(218, 318);
            this.btnLimpiarInventariosNoTerminados.Name = "btnLimpiarInventariosNoTerminados";
            this.btnLimpiarInventariosNoTerminados.Size = new System.Drawing.Size(217, 25);
            this.btnLimpiarInventariosNoTerminados.TabIndex = 12;
            this.btnLimpiarInventariosNoTerminados.Text = "Limpiar inventarios no terminados";
            this.btnLimpiarInventariosNoTerminados.UseVisualStyleBackColor = false;
            this.btnLimpiarInventariosNoTerminados.Click += new System.EventHandler(this.btnLimpiarInventariosNoTerminados_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.RBNoCiclicos);
            this.groupBox2.Controls.Add(this.RBCiclicos);
            this.groupBox2.Controls.Add(this.RBTodos);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(286, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 42);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ciclico";
            // 
            // RBNoCiclicos
            // 
            this.RBNoCiclicos.AutoSize = true;
            this.RBNoCiclicos.ForeColor = System.Drawing.Color.White;
            this.RBNoCiclicos.Location = new System.Drawing.Point(93, 20);
            this.RBNoCiclicos.Name = "RBNoCiclicos";
            this.RBNoCiclicos.Size = new System.Drawing.Size(88, 17);
            this.RBNoCiclicos.TabIndex = 2;
            this.RBNoCiclicos.Text = "No ciclicos";
            this.RBNoCiclicos.UseVisualStyleBackColor = true;
            // 
            // RBCiclicos
            // 
            this.RBCiclicos.AutoSize = true;
            this.RBCiclicos.ForeColor = System.Drawing.Color.White;
            this.RBCiclicos.Location = new System.Drawing.Point(6, 20);
            this.RBCiclicos.Name = "RBCiclicos";
            this.RBCiclicos.Size = new System.Drawing.Size(69, 17);
            this.RBCiclicos.TabIndex = 1;
            this.RBCiclicos.Text = "Ciclicos";
            this.RBCiclicos.UseVisualStyleBackColor = true;
            // 
            // RBTodos
            // 
            this.RBTodos.AutoSize = true;
            this.RBTodos.Checked = true;
            this.RBTodos.ForeColor = System.Drawing.Color.White;
            this.RBTodos.Location = new System.Drawing.Point(197, 20);
            this.RBTodos.Name = "RBTodos";
            this.RBTodos.Size = new System.Drawing.Size(60, 17);
            this.RBTodos.TabIndex = 0;
            this.RBTodos.TabStop = true;
            this.RBTodos.Text = "Todos";
            this.RBTodos.UseVisualStyleBackColor = true;
            // 
            // listaInventarioFisicoTableAdapter
            // 
            this.listaInventarioFisicoTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Inventario.DSInventarioFisicoTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // btnReconteo
            // 
            this.btnReconteo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnReconteo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnReconteo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReconteo.ForeColor = System.Drawing.Color.White;
            this.btnReconteo.Location = new System.Drawing.Point(856, 231);
            this.btnReconteo.Name = "btnReconteo";
            this.btnReconteo.Size = new System.Drawing.Size(125, 44);
            this.btnReconteo.TabIndex = 14;
            this.btnReconteo.Text = "Reporte reconteo";
            this.btnReconteo.UseVisualStyleBackColor = false;
            this.btnReconteo.Click += new System.EventHandler(this.btnReconteo_Click);
            // 
            // WFListaInventarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(993, 345);
            this.Controls.Add(this.btnReconteo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnLimpiarInventariosNoTerminados);
            this.Controls.Add(this.btnImprimirInvActual);
            this.Controls.Add(this.BTCapturarXLoc);
            this.Controls.Add(this.BTEditar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.LBFecha);
            this.Controls.Add(this.BTLlenar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DTPFecha);
            this.Controls.Add(this.BTCapturar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFListaInventarios";
            this.Text = "Lista de inventarios";
            this.Load += new System.EventHandler(this.WFListaInventarios_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaInventarioFisicoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSInventarioFisico)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private iPos.Inventario.DSInventarioFisico dSInventarioFisico;
        private System.Windows.Forms.BindingSource listaInventarioFisicoBindingSource;
        private iPos.Inventario.DSInventarioFisicoTableAdapters.ListaInventarioFisicoTableAdapter listaInventarioFisicoTableAdapter;
        private iPos.Inventario.DSInventarioFisicoTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button BTCapturar;
        private System.Windows.Forms.DateTimePicker DTPFecha;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RB_Estatus_Todas;
        private System.Windows.Forms.RadioButton RB_Estatus_Cerradas;
        private System.Windows.Forms.RadioButton RB_Estatus_Pendientes;
        private System.Windows.Forms.Button BTLlenar;
        private System.Windows.Forms.Label LBFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewSum dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.Button BTEditar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.Button BTCapturarXLoc;
        private System.Windows.Forms.Button btnImprimirInvActual;
        private System.Windows.Forms.Button btnLimpiarInventariosNoTerminados;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RBNoCiclicos;
        private System.Windows.Forms.RadioButton RBCiclicos;
        private System.Windows.Forms.RadioButton RBTodos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONSECUTIVO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ALMACENNOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPOINVENTARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCICLICO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLAVEESTATUSDOCTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CAJA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TURNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PERSONA;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn sUCURSALDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sUCURSALIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAJAIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tURNOIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fECHADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sERIEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tOTALDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESTATUSDOCTOID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGTIPODOCTOID;
        private System.Windows.Forms.DataGridViewTextBoxColumn rEFERENCIADataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnReconteo;
    }
}