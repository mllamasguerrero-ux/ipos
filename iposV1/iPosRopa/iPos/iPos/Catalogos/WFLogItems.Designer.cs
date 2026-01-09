namespace iPos
{
    partial class WFLogItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFLogItems));
            this.LOGUSERButton = new System.Windows.Forms.Button();
            this.LOGUSERLabel = new System.Windows.Forms.Label();
            this.ITEMButton = new System.Windows.Forms.Button();
            this.lblLogElementDetail = new System.Windows.Forms.Label();
            this.lOGDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.DGTABLAID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGFECHAHORA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBREUSUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ANTES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESPUES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVER = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lOGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSCatalogos = new iPos.Catalogos.DSCatalogos();
            this.btnSearchLog = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerBegin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTableType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlCliente = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLogCliente = new iPos.Tools.TextBoxFB();
            this.pnlProducto = new System.Windows.Forms.Panel();
            this.txtLogElement = new iPos.Tools.TextBoxFB();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtLogUser = new iPos.Tools.TextBoxFB();
            this.lOGTableAdapter = new iPos.Catalogos.DSCatalogosTableAdapters.LOGTableAdapter();
            this.tableAdapterManager = new iPos.Catalogos.DSCatalogosTableAdapters.TableAdapterManager();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.lOGDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogos)).BeginInit();
            this.pnlCliente.SuspendLayout();
            this.pnlProducto.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
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
            // ITEMButton
            // 
            this.ITEMButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.ITEMButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ITEMButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ITEMButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ITEMButton.Location = new System.Drawing.Point(173, 4);
            this.ITEMButton.Name = "ITEMButton";
            this.ITEMButton.Size = new System.Drawing.Size(21, 23);
            this.ITEMButton.TabIndex = 6;
            this.ITEMButton.UseVisualStyleBackColor = true;
            this.ITEMButton.Click += new System.EventHandler(this.ITEMButton_Click);
            // 
            // lblLogElementDetail
            // 
            this.lblLogElementDetail.AutoSize = true;
            this.lblLogElementDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblLogElementDetail.Location = new System.Drawing.Point(204, 12);
            this.lblLogElementDetail.Name = "lblLogElementDetail";
            this.lblLogElementDetail.Size = new System.Drawing.Size(16, 13);
            this.lblLogElementDetail.TabIndex = 182;
            this.lblLogElementDetail.Text = "...";
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
            this.DGTABLAID,
            this.DGFECHAHORA,
            this.DGID,
            this.NOMBREUSUARIO,
            this.ANTES,
            this.DESPUES,
            this.DGVER});
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
            this.lOGDataGridView.Size = new System.Drawing.Size(776, 251);
            this.lOGDataGridView.TabIndex = 11;
            this.lOGDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.lOGDataGridView_CellContentClick);
            // 
            // DGTABLAID
            // 
            this.DGTABLAID.DataPropertyName = "TABLAID";
            this.DGTABLAID.HeaderText = "TABLAID";
            this.DGTABLAID.Name = "DGTABLAID";
            this.DGTABLAID.Visible = false;
            this.DGTABLAID.Width = 150;
            // 
            // DGFECHAHORA
            // 
            this.DGFECHAHORA.DataPropertyName = "FECHAHORA";
            this.DGFECHAHORA.FillWeight = 85.71429F;
            this.DGFECHAHORA.HeaderText = "FECHA HORA";
            this.DGFECHAHORA.Name = "DGFECHAHORA";
            this.DGFECHAHORA.Width = 150;
            // 
            // DGID
            // 
            this.DGID.DataPropertyName = "ID";
            this.DGID.HeaderText = "ID";
            this.DGID.Name = "DGID";
            this.DGID.Visible = false;
            this.DGID.Width = 300;
            // 
            // NOMBREUSUARIO
            // 
            this.NOMBREUSUARIO.DataPropertyName = "NOMBREUSUARIO";
            this.NOMBREUSUARIO.FillWeight = 182.1429F;
            this.NOMBREUSUARIO.HeaderText = "NOMBRE USUARIO";
            this.NOMBREUSUARIO.Name = "NOMBREUSUARIO";
            this.NOMBREUSUARIO.Width = 319;
            // 
            // ANTES
            // 
            this.ANTES.DataPropertyName = "ANTES";
            this.ANTES.HeaderText = "ANTES";
            this.ANTES.Name = "ANTES";
            this.ANTES.Visible = false;
            // 
            // DESPUES
            // 
            this.DESPUES.DataPropertyName = "DESPUES";
            this.DESPUES.HeaderText = "DESPUES";
            this.DESPUES.Name = "DESPUES";
            this.DESPUES.Visible = false;
            // 
            // DGVER
            // 
            this.DGVER.FillWeight = 32.14286F;
            this.DGVER.HeaderText = "";
            this.DGVER.Name = "DGVER";
            this.DGVER.Text = "VER";
            this.DGVER.UseColumnTextForButtonValue = true;
            this.DGVER.Width = 56;
            // 
            // lOGBindingSource
            // 
            this.lOGBindingSource.DataMember = "LOG";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Producto:";
            // 
            // cmbTableType
            // 
            this.cmbTableType.FormattingEnabled = true;
            this.cmbTableType.Items.AddRange(new object[] {
            "Producto",
            "Cliente"});
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
            this.button1.Location = new System.Drawing.Point(185, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(21, 23);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(212, 7);
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
            this.txtLogCliente.Location = new System.Drawing.Point(84, 2);
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
            // pnlProducto
            // 
            this.pnlProducto.BackColor = System.Drawing.Color.Transparent;
            this.pnlProducto.Controls.Add(this.label2);
            this.pnlProducto.Controls.Add(this.lblLogElementDetail);
            this.pnlProducto.Controls.Add(this.txtLogElement);
            this.pnlProducto.Controls.Add(this.ITEMButton);
            this.pnlProducto.Location = new System.Drawing.Point(386, 49);
            this.pnlProducto.Name = "pnlProducto";
            this.pnlProducto.Size = new System.Drawing.Size(378, 30);
            this.pnlProducto.TabIndex = 4;
            // 
            // txtLogElement
            // 
            this.txtLogElement.BotonLookUp = null;
            this.txtLogElement.Condicion = null;
            this.txtLogElement.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.txtLogElement.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.txtLogElement.DbValue = null;
            this.txtLogElement.Format_Expression = null;
            this.txtLogElement.IndiceCampoDescripcion = 2;
            this.txtLogElement.IndiceCampoSelector = 1;
            this.txtLogElement.IndiceCampoValue = 0;
            this.txtLogElement.LabelDescription = this.lblLogElementDetail;
            this.txtLogElement.Location = new System.Drawing.Point(88, 6);
            this.txtLogElement.MostrarErrores = true;
            this.txtLogElement.Name = "txtLogElement";
            this.txtLogElement.NombreCampoSelector = "clave";
            this.txtLogElement.NombreCampoValue = "id";
            this.txtLogElement.Query = "select id,clave, descripcion1 from producto";
            this.txtLogElement.QueryDeSeleccion = "select id,clave,descripcion1 from producto where clave = @clave";
            this.txtLogElement.QueryPorDBValue = "select id,clave,descripcion1 from producto where id = @id";
            this.txtLogElement.Size = new System.Drawing.Size(82, 20);
            this.txtLogElement.TabIndex = 5;
            this.txtLogElement.Tag = 34;
            this.txtLogElement.TextDescription = null;
            this.txtLogElement.Titulo = "Productos";
            this.txtLogElement.ValidarEntrada = true;
            this.txtLogElement.ValidationExpression = null;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pnlProducto);
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
            this.panel1.Size = new System.Drawing.Size(776, 136);
            this.panel1.TabIndex = 191;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 387);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 100);
            this.panel2.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lOGDataGridView);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 136);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(776, 251);
            this.panel3.TabIndex = 10;
            // 
            // WFLogItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(776, 487);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFLogItems";
            this.Text = "Historial de Modificaciónes";
            this.Load += new System.EventHandler(this.WFLogItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lOGDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogos)).EndInit();
            this.pnlCliente.ResumeLayout(false);
            this.pnlCliente.PerformLayout();
            this.pnlProducto.ResumeLayout(false);
            this.pnlProducto.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTableType;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.Button ITEMButton;
        private Tools.TextBoxFB txtLogElement;
        private System.Windows.Forms.Label lblLogElementDetail;
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
        private System.Windows.Forms.Panel pnlProducto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGTABLAID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGFECHAHORA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBREUSUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ANTES;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESPUES;
        private System.Windows.Forms.DataGridViewButtonColumn DGVER;
    }
}