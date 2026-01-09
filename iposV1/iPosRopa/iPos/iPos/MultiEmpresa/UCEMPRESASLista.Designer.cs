
namespace iPos
{
    partial class UCEMPRESASLista
    {
       
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Código generado por el Diseñador de Windows Forms
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCEMPRESASLista));
            this.dataGridView1_EMPRESAS = new System.Windows.Forms.DataGridViewSum();
            this.dgEM_NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgEM_DATABASE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgEM_USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgEM_PASSWORD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgEM_SERVER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Default = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1_EMPRESAS = new System.Windows.Forms.BindingSource(this.components);
            this.label3_EMPRESAS = new System.Windows.Forms.Label();
            this.label2_EMPRESAS = new System.Windows.Forms.Label();
            this.label1_EMPRESAS = new System.Windows.Forms.Label();
            this.TBValor_EMPRESAS = new System.Windows.Forms.TextBox();
            this.DDOperador_EMPRESAS = new System.Windows.Forms.ComboBox();
            this.DDBuscar_EMPRESAS = new System.Windows.Forms.ComboBox();
            this.label4_EMPRESAS = new System.Windows.Forms.Label();
            this.button3_EMPRESAS = new System.Windows.Forms.Button();
            this.button1_EMPRESAS = new System.Windows.Forms.Button();
            this.FbCommand1_EMPRESAS = new FirebirdSql.Data.FirebirdClient.FbCommand();
            this.FbConnection1_EMPRESAS = new FirebirdSql.Data.FirebirdClient.FbConnection();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TSBAgregar = new System.Windows.Forms.ToolStripButton();
            this.TSBEditar = new System.Windows.Forms.ToolStripButton();
            this.TSBCerrar = new System.Windows.Forms.ToolStripButton();
            this.TSBDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.BTSeleccion = new System.Windows.Forms.ToolStripMenuItem();
            this.TSBAyuda = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.F5Info = new System.Windows.Forms.ToolStripLabel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.myOwnButtonColumn1 = new iPos.MyOwnButtonCell.MyOwnButtonColumn();
            this.btnEditMachineConfig = new System.Windows.Forms.Button();
            this.btnEditarSincConfig = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_EMPRESAS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_EMPRESAS)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1_EMPRESAS
            // 
            this.dataGridView1_EMPRESAS.AllowUserToAddRows = false;
            this.dataGridView1_EMPRESAS.AutoGenerateColumns = false;
            this.dataGridView1_EMPRESAS.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1_EMPRESAS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1_EMPRESAS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgEM_NOMBRE,
            this.dgEM_DATABASE,
            this.dgEM_USUARIO,
            this.dgEM_PASSWORD,
            this.dgEM_SERVER,
            this.Default});
            this.dataGridView1_EMPRESAS.DataSource = this.bindingSource1_EMPRESAS;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1_EMPRESAS.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1_EMPRESAS.EnableHeadersVisualStyles = false;
            this.dataGridView1_EMPRESAS.Location = new System.Drawing.Point(12, 132);
            this.dataGridView1_EMPRESAS.Name = "dataGridView1_EMPRESAS";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1_EMPRESAS.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1_EMPRESAS.RowHeadersVisible = false;
            this.dataGridView1_EMPRESAS.Size = new System.Drawing.Size(604, 155);
            this.dataGridView1_EMPRESAS.TabIndex = 1;
            this.dataGridView1_EMPRESAS.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_EMPRESAS_CellContentClick);
            this.dataGridView1_EMPRESAS.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_EMPRESAS_DataError);
            this.dataGridView1_EMPRESAS.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_EMPRESAS_RowsAdded);
            // 
            // dgEM_NOMBRE
            // 
            this.dgEM_NOMBRE.DataPropertyName = "EM_NOMBRE";
            this.dgEM_NOMBRE.HeaderText = "EM_NOMBRE";
            this.dgEM_NOMBRE.Name = "dgEM_NOMBRE";
            // 
            // dgEM_DATABASE
            // 
            this.dgEM_DATABASE.DataPropertyName = "EM_DATABASE";
            this.dgEM_DATABASE.HeaderText = "EM_DATABASE";
            this.dgEM_DATABASE.Name = "dgEM_DATABASE";
            // 
            // dgEM_USUARIO
            // 
            this.dgEM_USUARIO.DataPropertyName = "EM_USUARIO";
            this.dgEM_USUARIO.HeaderText = "EM_USUARIO";
            this.dgEM_USUARIO.Name = "dgEM_USUARIO";
            // 
            // dgEM_PASSWORD
            // 
            this.dgEM_PASSWORD.DataPropertyName = "EM_PASSWORD";
            this.dgEM_PASSWORD.HeaderText = "EM_PASSWORD";
            this.dgEM_PASSWORD.Name = "dgEM_PASSWORD";
            // 
            // dgEM_SERVER
            // 
            this.dgEM_SERVER.DataPropertyName = "EM_SERVER";
            this.dgEM_SERVER.HeaderText = "EM_SERVER";
            this.dgEM_SERVER.Name = "dgEM_SERVER";
            // 
            // Default
            // 
            this.Default.DataPropertyName = "EM_DEFAULT";
            this.Default.HeaderText = "Default";
            this.Default.Name = "Default";
            this.Default.ReadOnly = true;
            // 
            // label3_EMPRESAS
            // 
            this.label3_EMPRESAS.AutoSize = true;
            this.label3_EMPRESAS.BackColor = System.Drawing.Color.Transparent;
            this.label3_EMPRESAS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3_EMPRESAS.ForeColor = System.Drawing.Color.White;
            this.label3_EMPRESAS.Location = new System.Drawing.Point(306, 84);
            this.label3_EMPRESAS.Name = "label3_EMPRESAS";
            this.label3_EMPRESAS.Size = new System.Drawing.Size(40, 13);
            this.label3_EMPRESAS.TabIndex = 17;
            this.label3_EMPRESAS.Text = "Valor:";
            // 
            // label2_EMPRESAS
            // 
            this.label2_EMPRESAS.AutoSize = true;
            this.label2_EMPRESAS.BackColor = System.Drawing.Color.Transparent;
            this.label2_EMPRESAS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2_EMPRESAS.ForeColor = System.Drawing.Color.White;
            this.label2_EMPRESAS.Location = new System.Drawing.Point(164, 84);
            this.label2_EMPRESAS.Name = "label2_EMPRESAS";
            this.label2_EMPRESAS.Size = new System.Drawing.Size(67, 13);
            this.label2_EMPRESAS.TabIndex = 16;
            this.label2_EMPRESAS.Text = "Condicion:";
            // 
            // label1_EMPRESAS
            // 
            this.label1_EMPRESAS.AutoSize = true;
            this.label1_EMPRESAS.BackColor = System.Drawing.Color.Transparent;
            this.label1_EMPRESAS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1_EMPRESAS.ForeColor = System.Drawing.Color.White;
            this.label1_EMPRESAS.Location = new System.Drawing.Point(22, 84);
            this.label1_EMPRESAS.Name = "label1_EMPRESAS";
            this.label1_EMPRESAS.Size = new System.Drawing.Size(65, 13);
            this.label1_EMPRESAS.TabIndex = 15;
            this.label1_EMPRESAS.Text = "Filtrar por:";
            // 
            // TBValor_EMPRESAS
            // 
            this.TBValor_EMPRESAS.Location = new System.Drawing.Point(309, 106);
            this.TBValor_EMPRESAS.Name = "TBValor_EMPRESAS";
            this.TBValor_EMPRESAS.Size = new System.Drawing.Size(100, 20);
            this.TBValor_EMPRESAS.TabIndex = 13;
            // 
            // DDOperador_EMPRESAS
            // 
            this.DDOperador_EMPRESAS.FormattingEnabled = true;
            this.DDOperador_EMPRESAS.Items.AddRange(new object[] {
            "Igual",
            "Empiece",
            "Contenga"});
            this.DDOperador_EMPRESAS.Location = new System.Drawing.Point(167, 106);
            this.DDOperador_EMPRESAS.Name = "DDOperador_EMPRESAS";
            this.DDOperador_EMPRESAS.Size = new System.Drawing.Size(121, 21);
            this.DDOperador_EMPRESAS.TabIndex = 12;
            // 
            // DDBuscar_EMPRESAS
            // 
            this.DDBuscar_EMPRESAS.FormattingEnabled = true;
            this.DDBuscar_EMPRESAS.Items.AddRange(new object[] {
            "EM_NOMBRE",
            "EM_DATABASE",
            "EM_USUARIO",
            "EM_PASSWORD",
            "EM_SERVER"});
            this.DDBuscar_EMPRESAS.Location = new System.Drawing.Point(25, 106);
            this.DDBuscar_EMPRESAS.Name = "DDBuscar_EMPRESAS";
            this.DDBuscar_EMPRESAS.Size = new System.Drawing.Size(121, 21);
            this.DDBuscar_EMPRESAS.TabIndex = 11;
            // 
            // label4_EMPRESAS
            // 
            this.label4_EMPRESAS.AutoSize = true;
            this.label4_EMPRESAS.BackColor = System.Drawing.Color.Transparent;
            this.label4_EMPRESAS.Font = new System.Drawing.Font("Lucida Sans Unicode", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4_EMPRESAS.ForeColor = System.Drawing.Color.White;
            this.label4_EMPRESAS.Location = new System.Drawing.Point(246, 9);
            this.label4_EMPRESAS.Name = "label4_EMPRESAS";
            this.label4_EMPRESAS.Size = new System.Drawing.Size(268, 59);
            this.label4_EMPRESAS.TabIndex = 20;
            this.label4_EMPRESAS.Text = "EMPRESAS";
            // 
            // button3_EMPRESAS
            // 
            this.button3_EMPRESAS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button3_EMPRESAS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3_EMPRESAS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3_EMPRESAS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3_EMPRESAS.ForeColor = System.Drawing.Color.White;
            this.button3_EMPRESAS.Location = new System.Drawing.Point(493, 101);
            this.button3_EMPRESAS.Name = "button3_EMPRESAS";
            this.button3_EMPRESAS.Size = new System.Drawing.Size(57, 25);
            this.button3_EMPRESAS.TabIndex = 19;
            this.button3_EMPRESAS.Text = "Todos";
            this.button3_EMPRESAS.UseVisualStyleBackColor = false;
            this.button3_EMPRESAS.Click += new System.EventHandler(this.button3_EMPRESAS_Click);
            // 
            // button1_EMPRESAS
            // 
            this.button1_EMPRESAS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1_EMPRESAS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1_EMPRESAS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1_EMPRESAS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1_EMPRESAS.ForeColor = System.Drawing.Color.White;
            this.button1_EMPRESAS.Location = new System.Drawing.Point(424, 101);
            this.button1_EMPRESAS.Name = "button1_EMPRESAS";
            this.button1_EMPRESAS.Size = new System.Drawing.Size(57, 25);
            this.button1_EMPRESAS.TabIndex = 14;
            this.button1_EMPRESAS.Text = "Buscar";
            this.button1_EMPRESAS.UseVisualStyleBackColor = false;
            this.button1_EMPRESAS.Click += new System.EventHandler(this.button1_EMPRESAS_Click);
            // 
            // FbCommand1_EMPRESAS
            // 
            this.FbCommand1_EMPRESAS.CommandText = "Select e.*,case when c.CF_ID is null then \'NO\' else \'SI\' end EM_DEFAULT from EMPR" +
    "ESAS e left join CONFIGURACION c on e.em_nombre = c.CF_DEFAULT_DB where  1 = 1 ";
            this.FbCommand1_EMPRESAS.CommandTimeout = 30;
            this.FbCommand1_EMPRESAS.Connection = this.FbConnection1_EMPRESAS;
            // 
            // FbConnection1_EMPRESAS
            // 
            this.FbConnection1_EMPRESAS.ConnectionString = "Data Source=manuel;Initial Catalog=generador;Persist Security Info=True;User ID=s" +
    "a;Password=Twincept";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Location = new System.Drawing.Point(622, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(107, 231);
            this.panel1.TabIndex = 46;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSBAgregar,
            this.TSBEditar,
            this.TSBCerrar,
            this.TSBDefault,
            this.BTSeleccion,
            this.TSBAyuda,
            this.toolStripSeparator1,
            this.F5Info});
            this.toolStrip1.Location = new System.Drawing.Point(11, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 20, 1, 0);
            this.toolStrip1.Size = new System.Drawing.Size(96, 231);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TSBAgregar
            // 
            this.TSBAgregar.ForeColor = System.Drawing.Color.White;
            this.TSBAgregar.Image = global::iPos.Properties.Resources.folder_plus;
            this.TSBAgregar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.TSBAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBAgregar.Name = "TSBAgregar";
            this.TSBAgregar.Size = new System.Drawing.Size(93, 20);
            this.TSBAgregar.Text = "Agregar";
            this.TSBAgregar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.TSBAgregar.ToolTipText = "Ctrl-G";
            this.TSBAgregar.Click += new System.EventHandler(this.button7_EMPRESAS_Click);
            // 
            // TSBEditar
            // 
            this.TSBEditar.ForeColor = System.Drawing.Color.White;
            this.TSBEditar.Image = global::iPos.Properties.Resources.pencil_box;
            this.TSBEditar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.TSBEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBEditar.Name = "TSBEditar";
            this.TSBEditar.Size = new System.Drawing.Size(93, 20);
            this.TSBEditar.Text = "Editar";
            this.TSBEditar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.TSBEditar.ToolTipText = "Ctrl-G";
            this.TSBEditar.Click += new System.EventHandler(this.button4_EMPRESAS_Click);
            // 
            // TSBCerrar
            // 
            this.TSBCerrar.ForeColor = System.Drawing.Color.White;
            this.TSBCerrar.Image = global::iPos.Properties.Resources.close_box;
            this.TSBCerrar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.TSBCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBCerrar.Name = "TSBCerrar";
            this.TSBCerrar.Size = new System.Drawing.Size(93, 20);
            this.TSBCerrar.Text = "Cerrar";
            this.TSBCerrar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.TSBCerrar.ToolTipText = "Esc";
            this.TSBCerrar.Click += new System.EventHandler(this.TSBCerrar_Click);
            // 
            // TSBDefault
            // 
            this.TSBDefault.ForeColor = System.Drawing.Color.White;
            this.TSBDefault.Image = global::iPos.Properties.Resources.cursor_default;
            this.TSBDefault.Name = "TSBDefault";
            this.TSBDefault.Size = new System.Drawing.Size(93, 20);
            this.TSBDefault.Text = "Default";
            this.TSBDefault.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TSBDefault.ToolTipText = "Ctrl-L";
            this.TSBDefault.Click += new System.EventHandler(this.BTDefault_Click);
            // 
            // BTSeleccion
            // 
            this.BTSeleccion.ForeColor = System.Drawing.Color.White;
            this.BTSeleccion.Image = global::iPos.Properties.Resources.cursor_default;
            this.BTSeleccion.Name = "BTSeleccion";
            this.BTSeleccion.Size = new System.Drawing.Size(93, 20);
            this.BTSeleccion.Text = "Seleccionar";
            this.BTSeleccion.ToolTipText = "Ctrl-L";
            this.BTSeleccion.Click += new System.EventHandler(this.BTSeleccionar_Click);
            // 
            // TSBAyuda
            // 
            this.TSBAyuda.ForeColor = System.Drawing.Color.White;
            this.TSBAyuda.Image = global::iPos.Properties.Resources.help_box;
            this.TSBAyuda.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.TSBAyuda.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBAyuda.Name = "TSBAyuda";
            this.TSBAyuda.Size = new System.Drawing.Size(93, 20);
            this.TSBAyuda.Text = "Ayuda";
            this.TSBAyuda.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.TSBAyuda.ToolTipText = "F1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(93, 6);
            // 
            // F5Info
            // 
            this.F5Info.ForeColor = System.Drawing.Color.White;
            this.F5Info.Name = "F5Info";
            this.F5Info.Size = new System.Drawing.Size(93, 15);
            this.F5Info.Text = "Ctrl-S Listado";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "EM_NOMBRE";
            this.dataGridViewTextBoxColumn1.HeaderText = "EM_NOMBRE";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "EM_DATABASE";
            this.dataGridViewTextBoxColumn2.HeaderText = "EM_DATABASE";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "EM_USUARIO";
            this.dataGridViewTextBoxColumn3.HeaderText = "EM_USUARIO";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "EM_PASSWORD";
            this.dataGridViewTextBoxColumn4.HeaderText = "EM_PASSWORD";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "EM_SERVER";
            this.dataGridViewTextBoxColumn5.HeaderText = "EM_SERVER";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "EM_DEFAULT";
            this.dataGridViewTextBoxColumn6.HeaderText = "Default";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "Eliminar";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "Eliminar";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn1.Width = 50;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.HeaderText = "Editar";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.Text = "Editar";
            this.dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn2.Visible = false;
            this.dataGridViewButtonColumn2.Width = 50;
            // 
            // dataGridViewButtonColumn3
            // 
            this.dataGridViewButtonColumn3.HeaderText = "Guardar";
            this.dataGridViewButtonColumn3.Name = "dataGridViewButtonColumn3";
            this.dataGridViewButtonColumn3.Text = "Guardar";
            this.dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn3.Width = 50;
            // 
            // dataGridViewButtonColumn4
            // 
            this.dataGridViewButtonColumn4.HeaderText = "Cancelar";
            this.dataGridViewButtonColumn4.Name = "dataGridViewButtonColumn4";
            this.dataGridViewButtonColumn4.Text = "Cancelar";
            this.dataGridViewButtonColumn4.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn4.Width = 50;
            // 
            // myOwnButtonColumn1
            // 
            this.myOwnButtonColumn1.HeaderText = "Edit";
            this.myOwnButtonColumn1.Name = "myOwnButtonColumn1";
            this.myOwnButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.myOwnButtonColumn1.Width = 50;
            // 
            // btnEditMachineConfig
            // 
            this.btnEditMachineConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnEditMachineConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditMachineConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditMachineConfig.ForeColor = System.Drawing.Color.White;
            this.btnEditMachineConfig.Location = new System.Drawing.Point(12, 399);
            this.btnEditMachineConfig.Name = "btnEditMachineConfig";
            this.btnEditMachineConfig.Size = new System.Drawing.Size(142, 37);
            this.btnEditMachineConfig.TabIndex = 47;
            this.btnEditMachineConfig.Text = "Editar configuración de la maquina";
            this.btnEditMachineConfig.UseVisualStyleBackColor = false;
            this.btnEditMachineConfig.Click += new System.EventHandler(this.btnEditMachineConfig_Click);
            // 
            // btnEditarSincConfig
            // 
            this.btnEditarSincConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnEditarSincConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarSincConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarSincConfig.ForeColor = System.Drawing.Color.White;
            this.btnEditarSincConfig.Location = new System.Drawing.Point(190, 399);
            this.btnEditarSincConfig.Name = "btnEditarSincConfig";
            this.btnEditarSincConfig.Size = new System.Drawing.Size(142, 37);
            this.btnEditarSincConfig.TabIndex = 48;
            this.btnEditarSincConfig.Text = "Editar configuración de sincronización";
            this.btnEditarSincConfig.UseVisualStyleBackColor = false;
            this.btnEditarSincConfig.Click += new System.EventHandler(this.btnEditarSincConfig_Click);
            // 
            // UCEMPRESASLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.fondo_con_logo_ipos_3_0;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(783, 448);
            this.Controls.Add(this.btnEditarSincConfig);
            this.Controls.Add(this.btnEditMachineConfig);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4_EMPRESAS);
            this.Controls.Add(this.button3_EMPRESAS);
            this.Controls.Add(this.label3_EMPRESAS);
            this.Controls.Add(this.label2_EMPRESAS);
            this.Controls.Add(this.label1_EMPRESAS);
            this.Controls.Add(this.button1_EMPRESAS);
            this.Controls.Add(this.TBValor_EMPRESAS);
            this.Controls.Add(this.DDOperador_EMPRESAS);
            this.Controls.Add(this.DDBuscar_EMPRESAS);
            this.Controls.Add(this.dataGridView1_EMPRESAS);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1024, 738);
            this.Name = "UCEMPRESASLista";
            this.Text = "Empresas";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.Load += new System.EventHandler(this.EMPRESASLista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_EMPRESAS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_EMPRESAS)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
     
        private System.Windows.Forms.BindingSource bindingSource1_EMPRESAS;
        
        private System.Windows.Forms.TextBox TBValor_EMPRESAS;
        private System.Windows.Forms.ComboBox DDOperador_EMPRESAS;
        private System.Windows.Forms.ComboBox DDBuscar_EMPRESAS;
       
    
        private System.Windows.Forms.DataGridViewSum dataGridView1_EMPRESAS;
        private System.Windows.Forms.Button button3_EMPRESAS;
        private System.Windows.Forms.Label label3_EMPRESAS;
        private System.Windows.Forms.Label label2_EMPRESAS;
        private System.Windows.Forms.Label label1_EMPRESAS;
        private System.Windows.Forms.Button button1_EMPRESAS;
        private System.Windows.Forms.Label label4_EMPRESAS;
        private FirebirdSql.Data.FirebirdClient.FbCommand FbCommand1_EMPRESAS;
        private FirebirdSql.Data.FirebirdClient.FbConnection FbConnection1_EMPRESAS;
      
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn3;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn4;
        private MyOwnButtonCell.MyOwnButtonColumn myOwnButtonColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEM_NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEM_DATABASE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEM_USUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEM_PASSWORD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEM_SERVER;
        private System.Windows.Forms.DataGridViewTextBoxColumn Default;
        //private Skinner.FormSkin formSkin1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TSBAgregar;
        private System.Windows.Forms.ToolStripButton TSBEditar;
        private System.Windows.Forms.ToolStripButton TSBCerrar;
        private System.Windows.Forms.ToolStripMenuItem TSBDefault;
        private System.Windows.Forms.ToolStripButton TSBAyuda;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel F5Info;
        private System.Windows.Forms.ToolStripMenuItem BTSeleccion;
        private System.Windows.Forms.Button btnEditMachineConfig;
        private System.Windows.Forms.Button btnEditarSincConfig;
 
    }
}

