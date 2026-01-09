namespace iPos
{
    partial class WFLogEventoTable
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
            System.Windows.Forms.Label label65;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFLogEventoTable));
            this.LOGUSERButton = new System.Windows.Forms.Button();
            this.LOGUSERLabel = new System.Windows.Forms.Label();
            this.lOGDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGFECHAHORA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBREUSUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPOEVENTONOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLIENTE_NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGENCABEZADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lOGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSCatalogos = new iPos.Catalogos.DSCatalogos();
            this.btnSearchLog = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerBegin = new System.Windows.Forms.DateTimePicker();
            this.cmbTableType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlCliente = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLogCliente = new iPos.Tools.TextBoxFB();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtLogUser = new iPos.Tools.TextBoxFB();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlProveedor = new System.Windows.Forms.Panel();
            this.LogProveedorLabel = new System.Windows.Forms.Label();
            this.logProveedorButton = new System.Windows.Forms.Button();
            this.txtLogProveedor = new iPos.Tools.TextBoxFB();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lOGTableAdapter = new iPos.Catalogos.DSCatalogosTableAdapters.LOGTableAdapter();
            this.tableAdapterManager = new iPos.Catalogos.DSCatalogosTableAdapters.TableAdapterManager();
            this.lOGEVENTOTABLATableAdapter = new iPos.Catalogos.DSCatalogosTableAdapters.LOGEVENTOTABLATableAdapter();
            label65 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lOGDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogos)).BeginInit();
            this.pnlCliente.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlProveedor.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label65
            // 
            label65.AutoSize = true;
            label65.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label65.ForeColor = System.Drawing.Color.White;
            label65.Location = new System.Drawing.Point(1, 9);
            label65.Name = "label65";
            label65.Size = new System.Drawing.Size(69, 13);
            label65.TabIndex = 158;
            label65.Text = "Proveedor:";
            // 
            // LOGUSERButton
            // 
            this.LOGUSERButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.LOGUSERButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LOGUSERButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LOGUSERButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.LOGUSERButton.Location = new System.Drawing.Point(559, 15);
            this.LOGUSERButton.Name = "LOGUSERButton";
            this.LOGUSERButton.Size = new System.Drawing.Size(21, 23);
            this.LOGUSERButton.TabIndex = 3;
            this.LOGUSERButton.UseVisualStyleBackColor = true;
            // 
            // LOGUSERLabel
            // 
            this.LOGUSERLabel.AutoSize = true;
            this.LOGUSERLabel.ForeColor = System.Drawing.Color.White;
            this.LOGUSERLabel.Location = new System.Drawing.Point(590, 20);
            this.LOGUSERLabel.Name = "LOGUSERLabel";
            this.LOGUSERLabel.Size = new System.Drawing.Size(16, 13);
            this.LOGUSERLabel.TabIndex = 185;
            this.LOGUSERLabel.Text = "...";
            // 
            // lOGDataGridView
            // 
            this.lOGDataGridView.AllowUserToAddRows = false;
            this.lOGDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lOGDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.lOGDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lOGDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGID,
            this.DGFECHAHORA,
            this.NOMBREUSUARIO,
            this.TIPOEVENTONOMBRE,
            this.CLIENTE_NOMBRE,
            this.DGENCABEZADO,
            this.NOTA});
            this.lOGDataGridView.DataSource = this.lOGBindingSource;
            this.lOGDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lOGDataGridView.Location = new System.Drawing.Point(0, 0);
            this.lOGDataGridView.Name = "lOGDataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lOGDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.lOGDataGridView.RowHeadersVisible = false;
            this.lOGDataGridView.Size = new System.Drawing.Size(999, 265);
            this.lOGDataGridView.TabIndex = 11;
            // 
            // DGID
            // 
            this.DGID.DataPropertyName = "ID";
            this.DGID.HeaderText = "ID";
            this.DGID.Name = "DGID";
            this.DGID.Visible = false;
            this.DGID.Width = 300;
            // 
            // DGFECHAHORA
            // 
            this.DGFECHAHORA.DataPropertyName = "FECHAHORA";
            this.DGFECHAHORA.FillWeight = 85.71429F;
            this.DGFECHAHORA.HeaderText = "FECHA HORA";
            this.DGFECHAHORA.Name = "DGFECHAHORA";
            this.DGFECHAHORA.Width = 125;
            // 
            // NOMBREUSUARIO
            // 
            this.NOMBREUSUARIO.DataPropertyName = "USUARIO_NOMBRE";
            this.NOMBREUSUARIO.FillWeight = 182.1429F;
            this.NOMBREUSUARIO.HeaderText = "USUARIO";
            this.NOMBREUSUARIO.Name = "NOMBREUSUARIO";
            this.NOMBREUSUARIO.Width = 125;
            // 
            // TIPOEVENTONOMBRE
            // 
            this.TIPOEVENTONOMBRE.DataPropertyName = "TIPOEVENTONOMBRE";
            this.TIPOEVENTONOMBRE.HeaderText = "TIPO EVENTO";
            this.TIPOEVENTONOMBRE.Name = "TIPOEVENTONOMBRE";
            // 
            // CLIENTE_NOMBRE
            // 
            this.CLIENTE_NOMBRE.DataPropertyName = "CLIENTE_NOMBRE";
            this.CLIENTE_NOMBRE.HeaderText = "CLIENTE";
            this.CLIENTE_NOMBRE.Name = "CLIENTE_NOMBRE";
            this.CLIENTE_NOMBRE.Width = 125;
            // 
            // DGENCABEZADO
            // 
            this.DGENCABEZADO.DataPropertyName = "ENCABEZADO";
            this.DGENCABEZADO.HeaderText = "ENCABEZADO";
            this.DGENCABEZADO.Name = "DGENCABEZADO";
            // 
            // NOTA
            // 
            this.NOTA.DataPropertyName = "NOTA";
            this.NOTA.HeaderText = "NOTA";
            this.NOTA.Name = "NOTA";
            this.NOTA.Width = 400;
            // 
            // lOGBindingSource
            // 
            this.lOGBindingSource.DataMember = "LOGEVENTOTABLA";
            this.lOGBindingSource.DataSource = this.dSCatalogos;
            // 
            // dSCatalogos
            // 
            this.dSCatalogos.DataSetName = "DSCatalogos";
            this.dSCatalogos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnSearchLog
            // 
            this.btnSearchLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnSearchLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnSearchLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchLog.ForeColor = System.Drawing.Color.White;
            this.btnSearchLog.Location = new System.Drawing.Point(690, 85);
            this.btnSearchLog.Name = "btnSearchLog";
            this.btnSearchLog.Size = new System.Drawing.Size(75, 23);
            this.btnSearchLog.TabIndex = 9;
            this.btnSearchLog.Text = "Buscar";
            this.btnSearchLog.UseVisualStyleBackColor = false;
            this.btnSearchLog.Click += new System.EventHandler(this.btnSearchLog_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(395, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Usuario:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(395, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Fecha fin:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Fecha Inicio:";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(474, 87);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(210, 20);
            this.dateTimePickerEnd.TabIndex = 8;
            // 
            // dateTimePickerBegin
            // 
            this.dateTimePickerBegin.Location = new System.Drawing.Point(87, 88);
            this.dateTimePickerBegin.Name = "dateTimePickerBegin";
            this.dateTimePickerBegin.Size = new System.Drawing.Size(210, 20);
            this.dateTimePickerBegin.TabIndex = 7;
            // 
            // cmbTableType
            // 
            this.cmbTableType.Enabled = false;
            this.cmbTableType.FormattingEnabled = true;
            this.cmbTableType.Items.AddRange(new object[] {
            "Clientes",
            "Proveedores"});
            this.cmbTableType.Location = new System.Drawing.Point(87, 17);
            this.cmbTableType.Name = "cmbTableType";
            this.cmbTableType.Size = new System.Drawing.Size(210, 21);
            this.cmbTableType.TabIndex = 1;
            this.cmbTableType.SelectedIndexChanged += new System.EventHandler(this.cmbTableType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(38, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tabla:";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.Location = new System.Drawing.Point(185, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(21, 23);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(212, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "...";
            // 
            // pnlCliente
            // 
            this.pnlCliente.BackColor = System.Drawing.Color.Transparent;
            this.pnlCliente.Controls.Add(this.label7);
            this.pnlCliente.Controls.Add(this.txtLogCliente);
            this.pnlCliente.Controls.Add(this.button1);
            this.pnlCliente.Controls.Add(this.label6);
            this.pnlCliente.Enabled = false;
            this.pnlCliente.Location = new System.Drawing.Point(3, 50);
            this.pnlCliente.Name = "pnlCliente";
            this.pnlCliente.Size = new System.Drawing.Size(377, 29);
            this.pnlCliente.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(28, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 189;
            this.label7.Text = "Cliente:";
            // 
            // txtLogCliente
            // 
            this.txtLogCliente.BotonLookUp = this.button1;
            this.txtLogCliente.Condicion = null;
            this.txtLogCliente.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.txtLogCliente.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.txtLogCliente.DbValue = null;
            this.txtLogCliente.Enabled = false;
            this.txtLogCliente.Format_Expression = null;
            this.txtLogCliente.IndiceCampoDescripcion = 2;
            this.txtLogCliente.IndiceCampoSelector = 1;
            this.txtLogCliente.IndiceCampoValue = 0;
            this.txtLogCliente.LabelDescription = this.label6;
            this.txtLogCliente.Location = new System.Drawing.Point(84, 5);
            this.txtLogCliente.MostrarErrores = true;
            this.txtLogCliente.Name = "txtLogCliente";
            this.txtLogCliente.NombreCampoSelector = "clave";
            this.txtLogCliente.NombreCampoValue = "id";
            this.txtLogCliente.Query = "select p.id,p.clave,p.nombre from persona p where p.tipopersonaid in (50)";
            this.txtLogCliente.QueryDeSeleccion = "select id, clave, nombre from persona where tipopersonaid  in (50) and  clave= @c" +
    "lave";
            this.txtLogCliente.QueryPorDBValue = "select id,clave ,nombre from persona where tipopersonaid  in (50) and  id = @id";
            this.txtLogCliente.Size = new System.Drawing.Size(95, 20);
            this.txtLogCliente.TabIndex = 5;
            this.txtLogCliente.Tag = 34;
            this.txtLogCliente.TextDescription = null;
            this.txtLogCliente.Titulo = "Clientes";
            this.txtLogCliente.ValidarEntrada = true;
            this.txtLogCliente.ValidationExpression = null;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TABLAID";
            this.dataGridViewTextBoxColumn3.HeaderText = "TABLAID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "VER";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn1.Width = 70;
            // 
            // txtLogUser
            // 
            this.txtLogUser.BotonLookUp = this.LOGUSERButton;
            this.txtLogUser.Condicion = null;
            this.txtLogUser.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.txtLogUser.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.txtLogUser.DbValue = null;
            this.txtLogUser.Format_Expression = null;
            this.txtLogUser.IndiceCampoDescripcion = 2;
            this.txtLogUser.IndiceCampoSelector = 1;
            this.txtLogUser.IndiceCampoValue = 0;
            this.txtLogUser.LabelDescription = this.LOGUSERLabel;
            this.txtLogUser.Location = new System.Drawing.Point(475, 18);
            this.txtLogUser.MostrarErrores = true;
            this.txtLogUser.Name = "txtLogUser";
            this.txtLogUser.NombreCampoSelector = "clave";
            this.txtLogUser.NombreCampoValue = "id";
            this.txtLogUser.Query = "select p.id,p.clave,p.nombre from persona p where p.tipopersonaid in (20)";
            this.txtLogUser.QueryDeSeleccion = "select id, clave, nombre from persona where tipopersonaid  in (20) and  clave= @c" +
    "lave";
            this.txtLogUser.QueryPorDBValue = "select id,clave ,nombre from persona where tipopersonaid  in (20) and  id = @id";
            this.txtLogUser.Size = new System.Drawing.Size(81, 20);
            this.txtLogUser.TabIndex = 2;
            this.txtLogUser.Tag = 34;
            this.txtLogUser.TextDescription = null;
            this.txtLogUser.Titulo = "Usuarios";
            this.txtLogUser.ValidarEntrada = true;
            this.txtLogUser.ValidationExpression = null;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.pnlProveedor);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbTableType);
            this.panel1.Controls.Add(this.pnlCliente);
            this.panel1.Controls.Add(this.dateTimePickerBegin);
            this.panel1.Controls.Add(this.LOGUSERButton);
            this.panel1.Controls.Add(this.dateTimePickerEnd);
            this.panel1.Controls.Add(this.txtLogUser);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.LOGUSERLabel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnSearchLog);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(999, 136);
            this.panel1.TabIndex = 191;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pnlProveedor
            // 
            this.pnlProveedor.Controls.Add(this.LogProveedorLabel);
            this.pnlProveedor.Controls.Add(this.logProveedorButton);
            this.pnlProveedor.Controls.Add(this.txtLogProveedor);
            this.pnlProveedor.Controls.Add(label65);
            this.pnlProveedor.Location = new System.Drawing.Point(394, 50);
            this.pnlProveedor.Name = "pnlProveedor";
            this.pnlProveedor.Size = new System.Drawing.Size(417, 31);
            this.pnlProveedor.TabIndex = 186;
            // 
            // LogProveedorLabel
            // 
            this.LogProveedorLabel.AutoSize = true;
            this.LogProveedorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogProveedorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LogProveedorLabel.Location = new System.Drawing.Point(191, 9);
            this.LogProveedorLabel.Name = "LogProveedorLabel";
            this.LogProveedorLabel.Size = new System.Drawing.Size(19, 13);
            this.LogProveedorLabel.TabIndex = 159;
            this.LogProveedorLabel.Text = "...";
            // 
            // logProveedorButton
            // 
            this.logProveedorButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logProveedorButton.BackgroundImage")));
            this.logProveedorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logProveedorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logProveedorButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.logProveedorButton.Location = new System.Drawing.Point(164, 4);
            this.logProveedorButton.Name = "logProveedorButton";
            this.logProveedorButton.Size = new System.Drawing.Size(21, 23);
            this.logProveedorButton.TabIndex = 157;
            this.logProveedorButton.UseVisualStyleBackColor = true;
            // 
            // txtLogProveedor
            // 
            this.txtLogProveedor.BotonLookUp = this.logProveedorButton;
            this.txtLogProveedor.Condicion = null;
            this.txtLogProveedor.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.txtLogProveedor.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.txtLogProveedor.DbValue = null;
            this.txtLogProveedor.Format_Expression = null;
            this.txtLogProveedor.IndiceCampoDescripcion = 2;
            this.txtLogProveedor.IndiceCampoSelector = 1;
            this.txtLogProveedor.IndiceCampoValue = 0;
            this.txtLogProveedor.LabelDescription = this.LogProveedorLabel;
            this.txtLogProveedor.Location = new System.Drawing.Point(80, 5);
            this.txtLogProveedor.MostrarErrores = true;
            this.txtLogProveedor.Name = "txtLogProveedor";
            this.txtLogProveedor.NombreCampoSelector = "clave";
            this.txtLogProveedor.NombreCampoValue = "id";
            this.txtLogProveedor.Query = "select id,clave,nombre from persona where tipopersonaid = 40";
            this.txtLogProveedor.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid = 40 and  clave = @clave";
            this.txtLogProveedor.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid = 40 and  id = @id";
            this.txtLogProveedor.Size = new System.Drawing.Size(82, 20);
            this.txtLogProveedor.TabIndex = 156;
            this.txtLogProveedor.Tag = 34;
            this.txtLogProveedor.TextDescription = null;
            this.txtLogProveedor.Titulo = "Proveedores adicionales";
            this.txtLogProveedor.ValidarEntrada = true;
            this.txtLogProveedor.ValidationExpression = null;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 401);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(999, 67);
            this.panel2.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lOGDataGridView);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 136);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(999, 265);
            this.panel3.TabIndex = 10;
            // 
            // lOGTableAdapter
            // 
            this.lOGTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.LINEA_VIEWTableAdapter = null;
            this.tableAdapterManager.PERSONAAPARTADOTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = iPos.Catalogos.DSCatalogosTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // lOGEVENTOTABLATableAdapter
            // 
            this.lOGEVENTOTABLATableAdapter.ClearBeforeFill = true;
            // 
            // WFLogEventoTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(999, 468);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFLogEventoTable";
            this.Text = "Notas de incidencia / Negociaciones ";
            this.Load += new System.EventHandler(this.WFLogEventoTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lOGDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogos)).EndInit();
            this.pnlCliente.ResumeLayout(false);
            this.pnlCliente.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlProveedor.ResumeLayout(false);
            this.pnlProveedor.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTableType;
        private System.Windows.Forms.DateTimePicker dateTimePickerBegin;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearchLog;
        private Catalogos.DSCatalogos dSCatalogos;
        private System.Windows.Forms.BindingSource lOGBindingSource;
        private Catalogos.DSCatalogosTableAdapters.LOGTableAdapter lOGTableAdapter;
        private Catalogos.DSCatalogosTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum lOGDataGridView;
        private System.Windows.Forms.Button LOGUSERButton;
        private Tools.TextBoxFB txtLogUser;
        private System.Windows.Forms.Label LOGUSERLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.Button button1;
        private Tools.TextBoxFB txtLogCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlCliente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Catalogos.DSCatalogosTableAdapters.LOGEVENTOTABLATableAdapter lOGEVENTOTABLATableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGFECHAHORA;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBREUSUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPOEVENTONOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLIENTE_NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGENCABEZADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOTA;
        private System.Windows.Forms.Panel pnlProveedor;
        private System.Windows.Forms.Label LogProveedorLabel;
        private System.Windows.Forms.Button logProveedorButton;
        private Tools.TextBoxFB txtLogProveedor;
    }
}