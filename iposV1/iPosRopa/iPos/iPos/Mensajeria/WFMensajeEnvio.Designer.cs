namespace iPos
{
    partial class WFMensajeEnvio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFMensajeEnvio));
            this.btnEnviar = new System.Windows.Forms.Button();
            this.sUCURSALDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.DGENVIAR = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCLAVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGNOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sUCURSALBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSMensajeria = new iPos.Mensajeria.DSMensajeria();
            this.CBTodasSucursales = new System.Windows.Forms.CheckBox();
            this.CLAVELabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CBRestrictivo = new System.Windows.Forms.CheckBox();
            this.CBSoloAdministradores = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CBTodasAreas = new System.Windows.Forms.CheckBox();
            this.aREADataGridView = new System.Windows.Forms.DataGridViewSum();
            this.DGAREAENVIAR = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGAREANOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGAREACLAVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGAREAID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aREABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sUCURSALTableAdapter = new iPos.Mensajeria.DSMensajeriaTableAdapters.SUCURSALTableAdapter();
            this.tableAdapterManager = new iPos.Mensajeria.DSMensajeriaTableAdapters.TableAdapterManager();
            this.aREATableAdapter = new iPos.Mensajeria.DSMensajeriaTableAdapters.AREATableAdapter();
            this.datosAdjuntosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.datosAdjuntosDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.TBAsunto = new System.Windows.Forms.TextBox();
            this.LBLFechaEnvio = new System.Windows.Forms.Label();
            this.LBLEstadoMensaje = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.BodyMessage = new LiveSwitch.TextControl.Editor();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MENSAJENIVELURGENCIATextBox = new System.Windows.Forms.ComboBoxFB();
            this.dSCatalogos = new iPos.Catalogos.DSCatalogos();
            this.sUCURSALBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.sUCURSALTableAdapter1 = new iPos.Catalogos.DSCatalogosTableAdapters.SUCURSALTableAdapter();
            this.tableAdapterManager1 = new iPos.Catalogos.DSCatalogosTableAdapters.TableAdapterManager();
            this.DGADJUNTONOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGADJUNTORUTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGELIMINAR = new System.Windows.Forms.DataGridViewImageColumn();
            this.DGNOMBREFTP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.sUCURSALDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sUCURSALBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSMensajeria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aREADataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aREABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datosAdjuntosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datosAdjuntosDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sUCURSALBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.Location = new System.Drawing.Point(383, 556);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 12;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // sUCURSALDataGridView
            // 
            this.sUCURSALDataGridView.AllowUserToAddRows = false;
            this.sUCURSALDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sUCURSALDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.sUCURSALDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sUCURSALDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGENVIAR,
            this.DGID,
            this.DGCLAVE,
            this.DGNOMBRE});
            this.sUCURSALDataGridView.DataSource = this.sUCURSALBindingSource;
            this.sUCURSALDataGridView.Location = new System.Drawing.Point(12, 293);
            this.sUCURSALDataGridView.Name = "sUCURSALDataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sUCURSALDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.sUCURSALDataGridView.RowHeadersVisible = false;
            this.sUCURSALDataGridView.Size = new System.Drawing.Size(310, 114);
            this.sUCURSALDataGridView.TabIndex = 4;
            // 
            // DGENVIAR
            // 
            this.DGENVIAR.DataPropertyName = "ENVIAR";
            this.DGENVIAR.FalseValue = "0";
            this.DGENVIAR.HeaderText = "ENVIAR";
            this.DGENVIAR.Name = "DGENVIAR";
            this.DGENVIAR.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGENVIAR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DGENVIAR.TrueValue = "1";
            this.DGENVIAR.Width = 70;
            // 
            // DGID
            // 
            this.DGID.DataPropertyName = "ID";
            this.DGID.HeaderText = "ID";
            this.DGID.Name = "DGID";
            this.DGID.Visible = false;
            // 
            // DGCLAVE
            // 
            this.DGCLAVE.DataPropertyName = "CLAVE";
            this.DGCLAVE.HeaderText = "CLAVE";
            this.DGCLAVE.Name = "DGCLAVE";
            // 
            // DGNOMBRE
            // 
            this.DGNOMBRE.DataPropertyName = "NOMBRE";
            this.DGNOMBRE.HeaderText = "NOMBRE";
            this.DGNOMBRE.Name = "DGNOMBRE";
            // 
            // sUCURSALBindingSource
            // 
            this.sUCURSALBindingSource.DataMember = "SUCURSAL";
            this.sUCURSALBindingSource.DataSource = this.dSMensajeria;
            // 
            // dSMensajeria
            // 
            this.dSMensajeria.DataSetName = "DSMensajeria";
            this.dSMensajeria.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CBTodasSucursales
            // 
            this.CBTodasSucursales.AutoSize = true;
            this.CBTodasSucursales.BackColor = System.Drawing.Color.Transparent;
            this.CBTodasSucursales.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CBTodasSucursales.Location = new System.Drawing.Point(266, 270);
            this.CBTodasSucursales.Name = "CBTodasSucursales";
            this.CBTodasSucursales.Size = new System.Drawing.Size(56, 17);
            this.CBTodasSucursales.TabIndex = 3;
            this.CBTodasSucursales.Text = "Todas";
            this.CBTodasSucursales.UseVisualStyleBackColor = false;
            this.CBTodasSucursales.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // CLAVELabel
            // 
            this.CLAVELabel.AutoSize = true;
            this.CLAVELabel.BackColor = System.Drawing.Color.Transparent;
            this.CLAVELabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CLAVELabel.Location = new System.Drawing.Point(12, 410);
            this.CLAVELabel.Name = "CLAVELabel";
            this.CLAVELabel.Size = new System.Drawing.Size(48, 13);
            this.CLAVELabel.TabIndex = 16;
            this.CLAVELabel.Text = "Prioridad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(12, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Sucursales";
            // 
            // CBRestrictivo
            // 
            this.CBRestrictivo.AutoSize = true;
            this.CBRestrictivo.BackColor = System.Drawing.Color.Transparent;
            this.CBRestrictivo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CBRestrictivo.Location = new System.Drawing.Point(266, 430);
            this.CBRestrictivo.Name = "CBRestrictivo";
            this.CBRestrictivo.Size = new System.Drawing.Size(76, 17);
            this.CBRestrictivo.TabIndex = 8;
            this.CBRestrictivo.Text = "Restrictivo";
            this.CBRestrictivo.UseVisualStyleBackColor = false;
            // 
            // CBSoloAdministradores
            // 
            this.CBSoloAdministradores.AutoSize = true;
            this.CBSoloAdministradores.BackColor = System.Drawing.Color.Transparent;
            this.CBSoloAdministradores.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CBSoloAdministradores.Location = new System.Drawing.Point(363, 430);
            this.CBSoloAdministradores.Name = "CBSoloAdministradores";
            this.CBSoloAdministradores.Size = new System.Drawing.Size(124, 17);
            this.CBSoloAdministradores.TabIndex = 9;
            this.CBSoloAdministradores.Text = "Solo Administradores";
            this.CBSoloAdministradores.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(360, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Areas";
            this.label2.Visible = false;
            // 
            // CBTodasAreas
            // 
            this.CBTodasAreas.AutoSize = true;
            this.CBTodasAreas.BackColor = System.Drawing.Color.Transparent;
            this.CBTodasAreas.Checked = true;
            this.CBTodasAreas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBTodasAreas.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CBTodasAreas.Location = new System.Drawing.Point(736, 270);
            this.CBTodasAreas.Name = "CBTodasAreas";
            this.CBTodasAreas.Size = new System.Drawing.Size(56, 17);
            this.CBTodasAreas.TabIndex = 5;
            this.CBTodasAreas.Text = "Todas";
            this.CBTodasAreas.UseVisualStyleBackColor = false;
            this.CBTodasAreas.Visible = false;
            // 
            // aREADataGridView
            // 
            this.aREADataGridView.AllowUserToAddRows = false;
            this.aREADataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.aREADataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.aREADataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.aREADataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGAREAENVIAR,
            this.DGAREANOMBRE,
            this.DGAREACLAVE,
            this.DGAREAID});
            this.aREADataGridView.DataSource = this.aREABindingSource;
            this.aREADataGridView.Location = new System.Drawing.Point(363, 290);
            this.aREADataGridView.Name = "aREADataGridView";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.aREADataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.aREADataGridView.RowHeadersVisible = false;
            this.aREADataGridView.Size = new System.Drawing.Size(429, 117);
            this.aREADataGridView.TabIndex = 6;
            this.aREADataGridView.Visible = false;
            // 
            // DGAREAENVIAR
            // 
            this.DGAREAENVIAR.DataPropertyName = "ENVIAR";
            this.DGAREAENVIAR.HeaderText = "ENVIAR";
            this.DGAREAENVIAR.Name = "DGAREAENVIAR";
            this.DGAREAENVIAR.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGAREAENVIAR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DGAREANOMBRE
            // 
            this.DGAREANOMBRE.DataPropertyName = "NOMBRE";
            this.DGAREANOMBRE.HeaderText = "NOMBRE";
            this.DGAREANOMBRE.Name = "DGAREANOMBRE";
            // 
            // DGAREACLAVE
            // 
            this.DGAREACLAVE.DataPropertyName = "CLAVE";
            this.DGAREACLAVE.HeaderText = "CLAVE";
            this.DGAREACLAVE.Name = "DGAREACLAVE";
            // 
            // DGAREAID
            // 
            this.DGAREAID.DataPropertyName = "ID";
            this.DGAREAID.HeaderText = "ID";
            this.DGAREAID.Name = "DGAREAID";
            // 
            // aREABindingSource
            // 
            this.aREABindingSource.DataMember = "AREA";
            this.aREABindingSource.DataSource = this.dSMensajeria;
            // 
            // sUCURSALTableAdapter
            // 
            this.sUCURSALTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AREATableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BUZONTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Mensajeria.DSMensajeriaTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // aREATableAdapter
            // 
            this.aREATableAdapter.ClearBeforeFill = true;
            // 
            // datosAdjuntosBindingSource
            // 
            this.datosAdjuntosBindingSource.DataMember = "DatosAdjuntos";
            this.datosAdjuntosBindingSource.DataSource = this.dSMensajeria;
            // 
            // datosAdjuntosDataGridView
            // 
            this.datosAdjuntosDataGridView.AllowUserToAddRows = false;
            this.datosAdjuntosDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datosAdjuntosDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.datosAdjuntosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datosAdjuntosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGADJUNTONOMBRE,
            this.DGADJUNTORUTA,
            this.DGELIMINAR,
            this.DGNOMBREFTP});
            this.datosAdjuntosDataGridView.DataSource = this.datosAdjuntosBindingSource;
            this.datosAdjuntosDataGridView.Location = new System.Drawing.Point(12, 460);
            this.datosAdjuntosDataGridView.Name = "datosAdjuntosDataGridView";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datosAdjuntosDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.datosAdjuntosDataGridView.RowHeadersVisible = false;
            this.datosAdjuntosDataGridView.Size = new System.Drawing.Size(780, 81);
            this.datosAdjuntosDataGridView.TabIndex = 11;
            this.datosAdjuntosDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datosAdjuntosDataGridView_CellContentClick);
            // 
            // btnAddFile
            // 
            this.btnAddFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnAddFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnAddFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFile.ForeColor = System.Drawing.Color.White;
            this.btnAddFile.Location = new System.Drawing.Point(589, 426);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(119, 23);
            this.btnAddFile.TabIndex = 10;
            this.btnAddFile.Text = "Adjuntar archivo";
            this.btnAddFile.UseVisualStyleBackColor = false;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "F";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Asunto:";
            // 
            // TBAsunto
            // 
            this.TBAsunto.Location = new System.Drawing.Point(61, 79);
            this.TBAsunto.Name = "TBAsunto";
            this.TBAsunto.Size = new System.Drawing.Size(722, 20);
            this.TBAsunto.TabIndex = 1;
            // 
            // LBLFechaEnvio
            // 
            this.LBLFechaEnvio.AutoSize = true;
            this.LBLFechaEnvio.BackColor = System.Drawing.Color.Transparent;
            this.LBLFechaEnvio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.LBLFechaEnvio.ForeColor = System.Drawing.Color.White;
            this.LBLFechaEnvio.Location = new System.Drawing.Point(12, 37);
            this.LBLFechaEnvio.Name = "LBLFechaEnvio";
            this.LBLFechaEnvio.Size = new System.Drawing.Size(49, 16);
            this.LBLFechaEnvio.TabIndex = 25;
            this.LBLFechaEnvio.Text = "Fecha:";
            // 
            // LBLEstadoMensaje
            // 
            this.LBLEstadoMensaje.AutoSize = true;
            this.LBLEstadoMensaje.BackColor = System.Drawing.Color.Transparent;
            this.LBLEstadoMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.LBLEstadoMensaje.ForeColor = System.Drawing.Color.White;
            this.LBLEstadoMensaje.Location = new System.Drawing.Point(528, 37);
            this.LBLEstadoMensaje.Name = "LBLEstadoMensaje";
            this.LBLEstadoMensaje.Size = new System.Drawing.Size(134, 16);
            this.LBLEstadoMensaje.TabIndex = 26;
            this.LBLEstadoMensaje.Text = "Estado del mensaje: ";
            // 
            // BodyMessage
            // 
            this.BodyMessage.BodyBackgroundColor = System.Drawing.Color.White;
            this.BodyMessage.BodyHtml = null;
            this.BodyMessage.BodyText = null;
            this.BodyMessage.DocumentText = resources.GetString("BodyMessage.DocumentText");
            this.BodyMessage.EditorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BodyMessage.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BodyMessage.FontSize = LiveSwitch.TextControl.FontSize.Three;
            this.BodyMessage.Html = null;
            this.BodyMessage.Location = new System.Drawing.Point(15, 109);
            this.BodyMessage.Name = "BodyMessage";
            this.BodyMessage.Size = new System.Drawing.Size(768, 150);
            this.BodyMessage.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CLAVE";
            this.dataGridViewTextBoxColumn2.HeaderText = "CLAVE";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NOMBRE";
            this.dataGridViewTextBoxColumn3.HeaderText = "NOMBRE";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "NOMBRE";
            this.dataGridViewTextBoxColumn4.HeaderText = "NOMBRE";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CLAVE";
            this.dataGridViewTextBoxColumn5.HeaderText = "CLAVE";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn6.HeaderText = "ID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "NOMBRE";
            this.dataGridViewTextBoxColumn7.HeaderText = "NOMBRE";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 200;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "RUTA";
            this.dataGridViewTextBoxColumn8.HeaderText = "RUTA";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 400;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "NOMBREFTP";
            this.dataGridViewTextBoxColumn9.HeaderText = "NOMBREFTP";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // MENSAJENIVELURGENCIATextBox
            // 
            this.MENSAJENIVELURGENCIATextBox.Condicion = null;
            this.MENSAJENIVELURGENCIATextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.MENSAJENIVELURGENCIATextBox.DisplayMember = "nombre";
            this.MENSAJENIVELURGENCIATextBox.FormattingEnabled = true;
            this.MENSAJENIVELURGENCIATextBox.IndiceCampoSelector = 0;
            this.MENSAJENIVELURGENCIATextBox.LabelDescription = null;
            this.MENSAJENIVELURGENCIATextBox.Location = new System.Drawing.Point(12, 426);
            this.MENSAJENIVELURGENCIATextBox.Name = "MENSAJENIVELURGENCIATextBox";
            this.MENSAJENIVELURGENCIATextBox.NombreCampoSelector = "id";
            this.MENSAJENIVELURGENCIATextBox.Query = "select id,nombre from MENSAJENIVELURGENCIA";
            this.MENSAJENIVELURGENCIATextBox.QueryDeSeleccion = "select id,nombre from MENSAJENIVELURGENCIA where  id = @id";
            this.MENSAJENIVELURGENCIATextBox.SelectedDataDisplaying = null;
            this.MENSAJENIVELURGENCIATextBox.SelectedDataValue = null;
            this.MENSAJENIVELURGENCIATextBox.Size = new System.Drawing.Size(227, 21);
            this.MENSAJENIVELURGENCIATextBox.TabIndex = 7;
            this.MENSAJENIVELURGENCIATextBox.ValueMember = "id";
            // 
            // dSCatalogos
            // 
            this.dSCatalogos.DataSetName = "DSCatalogos";
            this.dSCatalogos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sUCURSALBindingSource1
            // 
            this.sUCURSALBindingSource1.DataMember = "SUCURSAL";
            this.sUCURSALBindingSource1.DataSource = this.dSCatalogos;
            // 
            // sUCURSALTableAdapter1
            // 
            this.sUCURSALTableAdapter1.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.LINEA_VIEWTableAdapter = null;
            this.tableAdapterManager1.PERSONAAPARTADOTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = iPos.Catalogos.DSCatalogosTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // DGADJUNTONOMBRE
            // 
            this.DGADJUNTONOMBRE.DataPropertyName = "NOMBRE";
            this.DGADJUNTONOMBRE.HeaderText = "NOMBRE";
            this.DGADJUNTONOMBRE.Name = "DGADJUNTONOMBRE";
            this.DGADJUNTONOMBRE.Width = 200;
            // 
            // DGADJUNTORUTA
            // 
            this.DGADJUNTORUTA.DataPropertyName = "RUTA";
            this.DGADJUNTORUTA.HeaderText = "RUTA";
            this.DGADJUNTORUTA.Name = "DGADJUNTORUTA";
            this.DGADJUNTORUTA.Width = 400;
            // 
            // DGELIMINAR
            // 
            this.DGELIMINAR.HeaderText = "";
            this.DGELIMINAR.Image = global::iPos.Properties.Resources.close_J;
            this.DGELIMINAR.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.DGELIMINAR.Name = "DGELIMINAR";
            this.DGELIMINAR.Width = 50;
            // 
            // DGNOMBREFTP
            // 
            this.DGNOMBREFTP.DataPropertyName = "NOMBREFTP";
            this.DGNOMBREFTP.HeaderText = "NOMBREFTP";
            this.DGNOMBREFTP.Name = "DGNOMBREFTP";
            this.DGNOMBREFTP.Visible = false;
            // 
            // WFMensajeEnvio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(837, 591);
            this.Controls.Add(this.LBLEstadoMensaje);
            this.Controls.Add(this.LBLFechaEnvio);
            this.Controls.Add(this.TBAsunto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddFile);
            this.Controls.Add(this.datosAdjuntosDataGridView);
            this.Controls.Add(this.aREADataGridView);
            this.Controls.Add(this.CBTodasAreas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CBSoloAdministradores);
            this.Controls.Add(this.CBRestrictivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CLAVELabel);
            this.Controls.Add(this.CBTodasSucursales);
            this.Controls.Add(this.MENSAJENIVELURGENCIATextBox);
            this.Controls.Add(this.sUCURSALDataGridView);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.BodyMessage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFMensajeEnvio";
            this.Text = "Nuevo Mensaje";
            this.Load += new System.EventHandler(this.WFCrearMensaje_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sUCURSALDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sUCURSALBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSMensajeria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aREADataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aREABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datosAdjuntosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datosAdjuntosDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sUCURSALBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LiveSwitch.TextControl.Editor BodyMessage;
        private System.Windows.Forms.Button btnEnviar;
        private Mensajeria.DSMensajeria dSMensajeria;
        private System.Windows.Forms.BindingSource sUCURSALBindingSource;
        private Mensajeria.DSMensajeriaTableAdapters.SUCURSALTableAdapter sUCURSALTableAdapter;
        private Mensajeria.DSMensajeriaTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum sUCURSALDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCLAVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGNOMBRE;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGENVIAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ComboBoxFB MENSAJENIVELURGENCIATextBox;
        private System.Windows.Forms.CheckBox CBTodasSucursales;
        private System.Windows.Forms.Label CLAVELabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CBRestrictivo;
        private System.Windows.Forms.CheckBox CBSoloAdministradores;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox CBTodasAreas;
        private System.Windows.Forms.BindingSource aREABindingSource;
        private Mensajeria.DSMensajeriaTableAdapters.AREATableAdapter aREATableAdapter;
        private System.Windows.Forms.DataGridViewSum aREADataGridView;
        private System.Windows.Forms.BindingSource datosAdjuntosBindingSource;
        private System.Windows.Forms.DataGridViewSum datosAdjuntosDataGridView;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBAsunto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGAREAENVIAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGAREANOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGAREACLAVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGAREAID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Label LBLFechaEnvio;
        private System.Windows.Forms.Label LBLEstadoMensaje;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private Catalogos.DSCatalogos dSCatalogos;
        private System.Windows.Forms.BindingSource sUCURSALBindingSource1;
        private Catalogos.DSCatalogosTableAdapters.SUCURSALTableAdapter sUCURSALTableAdapter1;
        private Catalogos.DSCatalogosTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGADJUNTONOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGADJUNTORUTA;
        private System.Windows.Forms.DataGridViewImageColumn DGELIMINAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGNOMBREFTP;
    }
}