
namespace iPos
{
    partial class WFAsignacionProdSat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFAsignacionProdSat));
            this.bindingSource1_LOOKUP = new System.Windows.Forms.BindingSource(this.components);
            this.label3_LOOKUP = new System.Windows.Forms.Label();
            this.label2_LOOKUP = new System.Windows.Forms.Label();
            this.label1_LOOKUP = new System.Windows.Forms.Label();
            this.DDOperador_LOOKUP = new System.Windows.Forms.ComboBox();
            this.DDBuscar_LOOKUP = new System.Windows.Forms.ComboBox();
            this.button3_LOOKUP = new System.Windows.Forms.Button();
            this.button1_LOOKUP = new System.Windows.Forms.Button();
            this.FbCommand1_LOOKUP = new FirebirdSql.Data.FirebirdClient.FbCommand();
            this.FbConnection1_LOOKUP = new FirebirdSql.Data.FirebirdClient.FbConnection();
            this.label4_LOOKUP = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.productoSatLabel = new System.Windows.Forms.Label();
            this.PRODUCTOSATButton = new System.Windows.Forms.Button();
            this.btnAsignarClaveSat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.productoSatTextBoxFb = new iPos.Tools.TextBoxFB();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.TBValor_LOOKUP = new System.Windows.Forms.TextBoxET();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1_LOOKUP = new System.Windows.Forms.DataGridViewE();
            this.DGPRODUCTOID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGLINEACLAVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGLINEANOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGMARCACLAVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGMARCANOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGPRODUCTOCLAVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGPRODUCTONOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGPRODUCTODESCRIPCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGPRODUCTODESCRIPCION1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCLAVESAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marquesina = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_LOOKUP)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_LOOKUP)).BeginInit();
            this.SuspendLayout();
            // 
            // label3_LOOKUP
            // 
            this.label3_LOOKUP.AutoSize = true;
            this.label3_LOOKUP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label3_LOOKUP.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3_LOOKUP.ForeColor = System.Drawing.Color.White;
            this.label3_LOOKUP.Location = new System.Drawing.Point(331, 24);
            this.label3_LOOKUP.Name = "label3_LOOKUP";
            this.label3_LOOKUP.Size = new System.Drawing.Size(35, 12);
            this.label3_LOOKUP.TabIndex = 17;
            this.label3_LOOKUP.Text = "Valor:";
            // 
            // label2_LOOKUP
            // 
            this.label2_LOOKUP.AutoSize = true;
            this.label2_LOOKUP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label2_LOOKUP.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2_LOOKUP.ForeColor = System.Drawing.Color.White;
            this.label2_LOOKUP.Location = new System.Drawing.Point(219, 23);
            this.label2_LOOKUP.Name = "label2_LOOKUP";
            this.label2_LOOKUP.Size = new System.Drawing.Size(56, 12);
            this.label2_LOOKUP.TabIndex = 16;
            this.label2_LOOKUP.Text = "Condicion:";
            // 
            // label1_LOOKUP
            // 
            this.label1_LOOKUP.AutoSize = true;
            this.label1_LOOKUP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label1_LOOKUP.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1_LOOKUP.ForeColor = System.Drawing.Color.White;
            this.label1_LOOKUP.Location = new System.Drawing.Point(10, 23);
            this.label1_LOOKUP.Name = "label1_LOOKUP";
            this.label1_LOOKUP.Size = new System.Drawing.Size(59, 12);
            this.label1_LOOKUP.TabIndex = 15;
            this.label1_LOOKUP.Text = "Filtrar por:";
            // 
            // DDOperador_LOOKUP
            // 
            this.DDOperador_LOOKUP.FormattingEnabled = true;
            this.DDOperador_LOOKUP.Items.AddRange(new object[] {
            "Igual",
            "Empiece",
            "Contenga"});
            this.DDOperador_LOOKUP.Location = new System.Drawing.Point(221, 38);
            this.DDOperador_LOOKUP.Name = "DDOperador_LOOKUP";
            this.DDOperador_LOOKUP.Size = new System.Drawing.Size(104, 21);
            this.DDOperador_LOOKUP.TabIndex = 12;
            // 
            // DDBuscar_LOOKUP
            // 
            this.DDBuscar_LOOKUP.FormattingEnabled = true;
            this.DDBuscar_LOOKUP.Location = new System.Drawing.Point(12, 38);
            this.DDBuscar_LOOKUP.Name = "DDBuscar_LOOKUP";
            this.DDBuscar_LOOKUP.Size = new System.Drawing.Size(203, 21);
            this.DDBuscar_LOOKUP.TabIndex = 11;
            // 
            // button3_LOOKUP
            // 
            this.button3_LOOKUP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button3_LOOKUP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3_LOOKUP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button3_LOOKUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3_LOOKUP.ForeColor = System.Drawing.Color.White;
            this.button3_LOOKUP.Location = new System.Drawing.Point(427, 65);
            this.button3_LOOKUP.Name = "button3_LOOKUP";
            this.button3_LOOKUP.Size = new System.Drawing.Size(48, 25);
            this.button3_LOOKUP.TabIndex = 19;
            this.button3_LOOKUP.Text = "Todos";
            this.button3_LOOKUP.UseVisualStyleBackColor = false;
            this.button3_LOOKUP.Click += new System.EventHandler(this.button3_LOOKUP_Click);
            // 
            // button1_LOOKUP
            // 
            this.button1_LOOKUP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1_LOOKUP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1_LOOKUP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1_LOOKUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1_LOOKUP.ForeColor = System.Drawing.Color.White;
            this.button1_LOOKUP.Location = new System.Drawing.Point(331, 65);
            this.button1_LOOKUP.Name = "button1_LOOKUP";
            this.button1_LOOKUP.Size = new System.Drawing.Size(61, 25);
            this.button1_LOOKUP.TabIndex = 14;
            this.button1_LOOKUP.Text = "Buscar";
            this.button1_LOOKUP.UseVisualStyleBackColor = false;
            this.button1_LOOKUP.Click += new System.EventHandler(this.button1_LOOKUP_Click);
            // 
            // FbCommand1_LOOKUP
            // 
            this.FbCommand1_LOOKUP.CommandText = "select * from LOOKUP where  1 = 1 ";
            this.FbCommand1_LOOKUP.CommandTimeout = 30;
            this.FbCommand1_LOOKUP.Connection = this.FbConnection1_LOOKUP;
            // 
            // FbConnection1_LOOKUP
            // 
            this.FbConnection1_LOOKUP.ConnectionString = "Data Source=manuel;Initial Catalog=generador;Persist Security Info=True;User ID=s" +
    "a;Password=Twincept";
            // 
            // label4_LOOKUP
            // 
            this.label4_LOOKUP.AutoSize = true;
            this.label4_LOOKUP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.label4_LOOKUP.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4_LOOKUP.ForeColor = System.Drawing.Color.White;
            this.label4_LOOKUP.Location = new System.Drawing.Point(3, 0);
            this.label4_LOOKUP.Name = "label4_LOOKUP";
            this.label4_LOOKUP.Size = new System.Drawing.Size(70, 18);
            this.label4_LOOKUP.TabIndex = 20;
            this.label4_LOOKUP.Text = "LOOKUP";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.panel2.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.checkedListBox1);
            this.panel2.Controls.Add(this.label4_LOOKUP);
            this.panel2.Controls.Add(this.DDBuscar_LOOKUP);
            this.panel2.Controls.Add(this.button3_LOOKUP);
            this.panel2.Controls.Add(this.DDOperador_LOOKUP);
            this.panel2.Controls.Add(this.label3_LOOKUP);
            this.panel2.Controls.Add(this.TBValor_LOOKUP);
            this.panel2.Controls.Add(this.label2_LOOKUP);
            this.panel2.Controls.Add(this.button1_LOOKUP);
            this.panel2.Controls.Add(this.label1_LOOKUP);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1084, 97);
            this.panel2.TabIndex = 22;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.PRODUCTOSATButton);
            this.panel4.Controls.Add(this.btnAsignarClaveSat);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.productoSatTextBoxFb);
            this.panel4.Location = new System.Drawing.Point(759, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(325, 97);
            this.panel4.TabIndex = 295;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(185, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 16);
            this.label2.TabIndex = 295;
            this.label2.Text = "Asignar clave SAT";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.panel3.Controls.Add(this.productoSatLabel);
            this.panel3.Location = new System.Drawing.Point(3, 72);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(199, 24);
            this.panel3.TabIndex = 294;
            // 
            // productoSatLabel
            // 
            this.productoSatLabel.AutoSize = true;
            this.productoSatLabel.ForeColor = System.Drawing.Color.Black;
            this.productoSatLabel.Location = new System.Drawing.Point(3, 6);
            this.productoSatLabel.Name = "productoSatLabel";
            this.productoSatLabel.Size = new System.Drawing.Size(19, 13);
            this.productoSatLabel.TabIndex = 291;
            this.productoSatLabel.Text = "...";
            // 
            // PRODUCTOSATButton
            // 
            this.PRODUCTOSATButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.PRODUCTOSATButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.PRODUCTOSATButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PRODUCTOSATButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PRODUCTOSATButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.PRODUCTOSATButton.Location = new System.Drawing.Point(301, 36);
            this.PRODUCTOSATButton.Name = "PRODUCTOSATButton";
            this.PRODUCTOSATButton.Size = new System.Drawing.Size(21, 23);
            this.PRODUCTOSATButton.TabIndex = 290;
            this.PRODUCTOSATButton.UseVisualStyleBackColor = false;
            this.PRODUCTOSATButton.Click += new System.EventHandler(this.PRODUCTOSATButton_Click);
            // 
            // btnAsignarClaveSat
            // 
            this.btnAsignarClaveSat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.btnAsignarClaveSat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAsignarClaveSat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnAsignarClaveSat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarClaveSat.ForeColor = System.Drawing.Color.Black;
            this.btnAsignarClaveSat.Location = new System.Drawing.Point(205, 71);
            this.btnAsignarClaveSat.Name = "btnAsignarClaveSat";
            this.btnAsignarClaveSat.Size = new System.Drawing.Size(117, 25);
            this.btnAsignarClaveSat.TabIndex = 292;
            this.btnAsignarClaveSat.Text = "Asignar clave sat";
            this.btnAsignarClaveSat.UseVisualStyleBackColor = false;
            this.btnAsignarClaveSat.Click += new System.EventHandler(this.btnAsignarClaveSat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 293;
            this.label1.Text = "Clave SAT";
            // 
            // productoSatTextBoxFb
            // 
            this.productoSatTextBoxFb.BotonLookUp = null;
            this.productoSatTextBoxFb.Condicion = null;
            this.productoSatTextBoxFb.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.productoSatTextBoxFb.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.productoSatTextBoxFb.DbValue = null;
            this.productoSatTextBoxFb.Format_Expression = null;
            this.productoSatTextBoxFb.IndiceCampoDescripcion = 2;
            this.productoSatTextBoxFb.IndiceCampoSelector = 1;
            this.productoSatTextBoxFb.IndiceCampoValue = 0;
            this.productoSatTextBoxFb.LabelDescription = this.productoSatLabel;
            this.productoSatTextBoxFb.Location = new System.Drawing.Point(3, 38);
            this.productoSatTextBoxFb.Name = "productoSatTextBoxFb";
            this.productoSatTextBoxFb.NombreCampoSelector = "sat_claveprodserv";
            this.productoSatTextBoxFb.NombreCampoValue = "id";
            this.productoSatTextBoxFb.Query = "select id, sat_claveprodserv, sat_descripcion from sat_productoservicio";
            this.productoSatTextBoxFb.QueryDeSeleccion = "select id, sat_claveprodserv, sat_descripcion from sat_productoservicio where sat" +
    "_claveprodserv = @sat_claveprodserv";
            this.productoSatTextBoxFb.QueryPorDBValue = "select id, sat_claveprodserv, sat_descripcion from sat_productoservicio where id " +
    "= @id";
            this.productoSatTextBoxFb.Size = new System.Drawing.Size(292, 20);
            this.productoSatTextBoxFb.TabIndex = 289;
            this.productoSatTextBoxFb.Tag = 34;
            this.productoSatTextBoxFb.TextDescription = null;
            this.productoSatTextBoxFb.Titulo = null;
            this.productoSatTextBoxFb.ValidarEntrada = true;
            this.productoSatTextBoxFb.ValidationExpression = null;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(496, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(257, 79);
            this.checkedListBox1.TabIndex = 22;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            this.checkedListBox1.SelectedValueChanged += new System.EventHandler(this.checkedListBox1_SelectedValueChanged);
            // 
            // TBValor_LOOKUP
            // 
            this.TBValor_LOOKUP.Format_Expression = null;
            this.TBValor_LOOKUP.Location = new System.Drawing.Point(331, 38);
            this.TBValor_LOOKUP.Name = "TBValor_LOOKUP";
            this.TBValor_LOOKUP.Size = new System.Drawing.Size(144, 20);
            this.TBValor_LOOKUP.TabIndex = 13;
            this.TBValor_LOOKUP.Tag = 34;
            this.TBValor_LOOKUP.ValidationExpression = null;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dataGridView1_LOOKUP);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 417);
            this.panel1.TabIndex = 23;
            // 
            // dataGridView1_LOOKUP
            // 
            this.dataGridView1_LOOKUP.AllowUserToAddRows = false;
            this.dataGridView1_LOOKUP.AllowUserToDeleteRows = false;
            this.dataGridView1_LOOKUP.AutoGenerateColumns = false;
            this.dataGridView1_LOOKUP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1_LOOKUP.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1_LOOKUP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1_LOOKUP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGPRODUCTOID,
            this.DGLINEACLAVE,
            this.DGLINEANOMBRE,
            this.DGMARCACLAVE,
            this.DGMARCANOMBRE,
            this.DGPRODUCTOCLAVE,
            this.DGPRODUCTONOMBRE,
            this.DGPRODUCTODESCRIPCION,
            this.DGPRODUCTODESCRIPCION1,
            this.DGCLAVESAT});
            this.dataGridView1_LOOKUP.DataSource = this.bindingSource1_LOOKUP;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1_LOOKUP.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1_LOOKUP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1_LOOKUP.EnableHeadersVisualStyles = false;
            this.dataGridView1_LOOKUP.Location = new System.Drawing.Point(0, 103);
            this.dataGridView1_LOOKUP.Name = "dataGridView1_LOOKUP";
            this.dataGridView1_LOOKUP.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1_LOOKUP.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1_LOOKUP.RowHeadersVisible = false;
            this.dataGridView1_LOOKUP.Size = new System.Drawing.Size(1084, 314);
            this.dataGridView1_LOOKUP.TabIndex = 1;
            this.dataGridView1_LOOKUP.EnterKeyDownEvent += new System.EventHandler(this.dataGridView1_LOOKUP_EnterKeyDownEvent);
            this.dataGridView1_LOOKUP.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_LOOKUP_CellDoubleClick);
            this.dataGridView1_LOOKUP.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView1_LOOKUP_ColumnAdded);
            this.dataGridView1_LOOKUP.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_LOOKUP_DataError);
            this.dataGridView1_LOOKUP.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_LOOKUP_RowsAdded);
            this.dataGridView1_LOOKUP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_LOOKUP_KeyDown);
            // 
            // DGPRODUCTOID
            // 
            this.DGPRODUCTOID.DataPropertyName = "productoid";
            this.DGPRODUCTOID.HeaderText = "PRODUCTOID";
            this.DGPRODUCTOID.Name = "DGPRODUCTOID";
            this.DGPRODUCTOID.ReadOnly = true;
            this.DGPRODUCTOID.Visible = false;
            this.DGPRODUCTOID.Width = 103;
            // 
            // DGLINEACLAVE
            // 
            this.DGLINEACLAVE.DataPropertyName = "LINEACLAVE";
            this.DGLINEACLAVE.HeaderText = "LINEA CLAVE";
            this.DGLINEACLAVE.Name = "DGLINEACLAVE";
            this.DGLINEACLAVE.ReadOnly = true;
            this.DGLINEACLAVE.Width = 103;
            // 
            // DGLINEANOMBRE
            // 
            this.DGLINEANOMBRE.DataPropertyName = "LINEANOMBRE";
            this.DGLINEANOMBRE.HeaderText = "LINEA NOMBRE";
            this.DGLINEANOMBRE.Name = "DGLINEANOMBRE";
            this.DGLINEANOMBRE.ReadOnly = true;
            this.DGLINEANOMBRE.Width = 114;
            // 
            // DGMARCACLAVE
            // 
            this.DGMARCACLAVE.DataPropertyName = "MARCACLAVE";
            this.DGMARCACLAVE.HeaderText = "MARCA CLAVE";
            this.DGMARCACLAVE.Name = "DGMARCACLAVE";
            this.DGMARCACLAVE.ReadOnly = true;
            this.DGMARCACLAVE.Width = 112;
            // 
            // DGMARCANOMBRE
            // 
            this.DGMARCANOMBRE.DataPropertyName = "MARCANOMBRE";
            this.DGMARCANOMBRE.HeaderText = "MARCA NOMBRE";
            this.DGMARCANOMBRE.Name = "DGMARCANOMBRE";
            this.DGMARCANOMBRE.ReadOnly = true;
            this.DGMARCANOMBRE.Width = 123;
            // 
            // DGPRODUCTOCLAVE
            // 
            this.DGPRODUCTOCLAVE.DataPropertyName = "PRODUCTOCLAVE";
            this.DGPRODUCTOCLAVE.HeaderText = "PRODUCTO CLAVE";
            this.DGPRODUCTOCLAVE.Name = "DGPRODUCTOCLAVE";
            this.DGPRODUCTOCLAVE.ReadOnly = true;
            this.DGPRODUCTOCLAVE.Width = 131;
            // 
            // DGPRODUCTONOMBRE
            // 
            this.DGPRODUCTONOMBRE.DataPropertyName = "PRODUCTONOMBRE";
            this.DGPRODUCTONOMBRE.HeaderText = "PRODUCTO NOMBRE";
            this.DGPRODUCTONOMBRE.Name = "DGPRODUCTONOMBRE";
            this.DGPRODUCTONOMBRE.ReadOnly = true;
            this.DGPRODUCTONOMBRE.Width = 142;
            // 
            // DGPRODUCTODESCRIPCION
            // 
            this.DGPRODUCTODESCRIPCION.DataPropertyName = "PRODUCTODESCRIPCION";
            this.DGPRODUCTODESCRIPCION.HeaderText = "PRODUCTO DESCRIPCION";
            this.DGPRODUCTODESCRIPCION.Name = "DGPRODUCTODESCRIPCION";
            this.DGPRODUCTODESCRIPCION.ReadOnly = true;
            this.DGPRODUCTODESCRIPCION.Width = 171;
            // 
            // DGPRODUCTODESCRIPCION1
            // 
            this.DGPRODUCTODESCRIPCION1.DataPropertyName = "PRODUCTODESCRIPCION1";
            this.DGPRODUCTODESCRIPCION1.HeaderText = "PRODUCTO DESCRIPCION 1";
            this.DGPRODUCTODESCRIPCION1.Name = "DGPRODUCTODESCRIPCION1";
            this.DGPRODUCTODESCRIPCION1.ReadOnly = true;
            this.DGPRODUCTODESCRIPCION1.Width = 180;
            // 
            // DGCLAVESAT
            // 
            this.DGCLAVESAT.DataPropertyName = "CLAVESAT";
            this.DGCLAVESAT.HeaderText = "CLAVE SAT";
            this.DGCLAVESAT.Name = "DGCLAVESAT";
            this.DGCLAVESAT.ReadOnly = true;
            this.DGCLAVESAT.Width = 91;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "LOOKUP";
            this.dataGridViewTextBoxColumn2.HeaderText = "LOOKUP";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // Marquesina
            // 
            this.Marquesina.Interval = 80;
            this.Marquesina.Tick += new System.EventHandler(this.Marquesina_Tick);
            // 
            // WFAsignacionProdSat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(1084, 417);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1100, 738);
            this.Name = "WFAsignacionProdSat";
            this.Text = "LOOKUP";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.Load += new System.EventHandler(this.LOOKUPLookUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_LOOKUP)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_LOOKUP)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
     
        private System.Windows.Forms.BindingSource bindingSource1_LOOKUP;
        
        private System.Windows.Forms.TextBoxET TBValor_LOOKUP;
        private System.Windows.Forms.ComboBox DDOperador_LOOKUP;
        private System.Windows.Forms.ComboBox DDBuscar_LOOKUP;
       
        private System.Windows.Forms.Button button3_LOOKUP;
        private System.Windows.Forms.Label label3_LOOKUP;
        private System.Windows.Forms.Label label2_LOOKUP;
        private System.Windows.Forms.Label label1_LOOKUP;
        private System.Windows.Forms.Button button1_LOOKUP;
        private FirebirdSql.Data.FirebirdClient.FbCommand FbCommand1_LOOKUP;
        private FirebirdSql.Data.FirebirdClient.FbConnection FbConnection1_LOOKUP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label4_LOOKUP;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewE dataGridView1_LOOKUP;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label productoSatLabel;
        private System.Windows.Forms.Button PRODUCTOSATButton;
        private Tools.TextBoxFB productoSatTextBoxFb;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGPRODUCTOID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGLINEACLAVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGLINEANOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGMARCACLAVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGMARCANOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGPRODUCTOCLAVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGPRODUCTONOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGPRODUCTODESCRIPCION;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGPRODUCTODESCRIPCION1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCLAVESAT;
        private System.Windows.Forms.Button btnAsignarClaveSat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer Marquesina;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        //private Skinner.FormSkin formSkin1;

    }
}

