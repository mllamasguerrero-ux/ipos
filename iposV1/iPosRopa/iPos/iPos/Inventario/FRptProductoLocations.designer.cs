namespace iPos
{
	partial class FRptProductoLocations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRptProductoLocations));
            this.btnGenerar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.previewControl1 = new FastReport.Preview.PreviewControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CBTicket = new System.Windows.Forms.CheckBox();
            this.CBKitsDesensamblados = new System.Windows.Forms.CheckBox();
            this.CBTodos = new System.Windows.Forms.CheckBox();
            this.ANAQUELFINComboBox = new System.Windows.Forms.ComboBoxFB();
            this.ANAQUELINICIOComboBox = new System.Windows.Forms.ComboBoxFB();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.report1 = new FastReport.Report();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.ALMACENComboBox = new System.Windows.Forms.ComboBoxFB();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnGenerar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Location = new System.Drawing.Point(752, 45);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 5;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 80);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(834, 482);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.previewControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(826, 456);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "REPORTE";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // previewControl1
            // 
            this.previewControl1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.previewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewControl1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.previewControl1.Location = new System.Drawing.Point(3, 3);
            this.previewControl1.Name = "previewControl1";
            this.previewControl1.PageOffset = new System.Drawing.Point(10, 10);
            this.previewControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.previewControl1.SaveInitialDirectory = null;
            this.previewControl1.Size = new System.Drawing.Size(820, 450);
            this.previewControl1.TabIndex = 1;
            this.previewControl1.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lblAlmacen);
            this.panel1.Controls.Add(this.ALMACENComboBox);
            this.panel1.Controls.Add(this.CBTicket);
            this.panel1.Controls.Add(this.CBKitsDesensamblados);
            this.panel1.Controls.Add(this.CBTodos);
            this.panel1.Controls.Add(this.ANAQUELFINComboBox);
            this.panel1.Controls.Add(this.ANAQUELINICIOComboBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnGenerar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 80);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // CBTicket
            // 
            this.CBTicket.AutoSize = true;
            this.CBTicket.ForeColor = System.Drawing.Color.White;
            this.CBTicket.Location = new System.Drawing.Point(204, 45);
            this.CBTicket.Name = "CBTicket";
            this.CBTicket.Size = new System.Drawing.Size(56, 17);
            this.CBTicket.TabIndex = 11;
            this.CBTicket.Text = "Ticket";
            this.CBTicket.UseVisualStyleBackColor = true;
            // 
            // CBKitsDesensamblados
            // 
            this.CBKitsDesensamblados.AutoSize = true;
            this.CBKitsDesensamblados.ForeColor = System.Drawing.Color.White;
            this.CBKitsDesensamblados.Location = new System.Drawing.Point(361, 45);
            this.CBKitsDesensamblados.Name = "CBKitsDesensamblados";
            this.CBKitsDesensamblados.Size = new System.Drawing.Size(125, 17);
            this.CBKitsDesensamblados.TabIndex = 10;
            this.CBKitsDesensamblados.Text = "Kits desensamblados";
            this.CBKitsDesensamblados.UseVisualStyleBackColor = true;
            // 
            // CBTodos
            // 
            this.CBTodos.AutoSize = true;
            this.CBTodos.ForeColor = System.Drawing.Color.White;
            this.CBTodos.Location = new System.Drawing.Point(678, 49);
            this.CBTodos.Name = "CBTodos";
            this.CBTodos.Size = new System.Drawing.Size(56, 17);
            this.CBTodos.TabIndex = 9;
            this.CBTodos.Text = "Todos";
            this.CBTodos.UseVisualStyleBackColor = true;
            // 
            // ANAQUELFINComboBox
            // 
            this.ANAQUELFINComboBox.Condicion = null;
            this.ANAQUELFINComboBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ANAQUELFINComboBox.DisplayMember = "nombre";
            this.ANAQUELFINComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ANAQUELFINComboBox.FormattingEnabled = true;
            this.ANAQUELFINComboBox.IndiceCampoSelector = 0;
            this.ANAQUELFINComboBox.LabelDescription = null;
            this.ANAQUELFINComboBox.Location = new System.Drawing.Point(592, 17);
            this.ANAQUELFINComboBox.Name = "ANAQUELFINComboBox";
            this.ANAQUELFINComboBox.NombreCampoSelector = "id";
            this.ANAQUELFINComboBox.Query = "select id, nombre from ( select anaquel.id , anaquel.clave as nombre, 0 as orden " +
    "from anaquel union all select -2 id, \'Libre\' AS nombre, 1 as orden from rdb$data" +
    "base) r  order by orden, nombre";
            this.ANAQUELFINComboBox.QueryDeSeleccion = "select id, nombre from ( select anaquel.id , anaquel.clave as nombre, 0 as orden " +
    "from anaquel union all select -2 id, \'Libre\' AS nombre, 1 as orden from rdb$data" +
    "base) r  where r.id = @id";
            this.ANAQUELFINComboBox.SelectedDataDisplaying = null;
            this.ANAQUELFINComboBox.SelectedDataValue = null;
            this.ANAQUELFINComboBox.Size = new System.Drawing.Size(148, 21);
            this.ANAQUELFINComboBox.TabIndex = 8;
            this.ANAQUELFINComboBox.ValueMember = "id";
            // 
            // ANAQUELINICIOComboBox
            // 
            this.ANAQUELINICIOComboBox.Condicion = null;
            this.ANAQUELINICIOComboBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ANAQUELINICIOComboBox.DisplayMember = "nombre";
            this.ANAQUELINICIOComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ANAQUELINICIOComboBox.FormattingEnabled = true;
            this.ANAQUELINICIOComboBox.IndiceCampoSelector = 0;
            this.ANAQUELINICIOComboBox.LabelDescription = null;
            this.ANAQUELINICIOComboBox.Location = new System.Drawing.Point(351, 16);
            this.ANAQUELINICIOComboBox.Name = "ANAQUELINICIOComboBox";
            this.ANAQUELINICIOComboBox.NombreCampoSelector = "id";
            this.ANAQUELINICIOComboBox.Query = "select id, nombre from ( select anaquel.id , anaquel.clave as nombre, 0 as orden " +
    "from anaquel union all select -2 id, \'Libre\' AS nombre, 1 as orden from rdb$data" +
    "base) r  order by orden, nombre";
            this.ANAQUELINICIOComboBox.QueryDeSeleccion = "select id, nombre from ( select anaquel.id , anaquel.clave as nombre, 0 as orden " +
    "from anaquel union all select -2 id, \'Libre\' AS nombre, 1 as orden from rdb$data" +
    "base) r  where r.id = @id";
            this.ANAQUELINICIOComboBox.SelectedDataDisplaying = null;
            this.ANAQUELINICIOComboBox.SelectedDataValue = null;
            this.ANAQUELINICIOComboBox.Size = new System.Drawing.Size(148, 21);
            this.ANAQUELINICIOComboBox.TabIndex = 7;
            this.ANAQUELINICIOComboBox.ValueMember = "id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(507, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Al anaquel:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(257, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Del anaquel:";
            // 
            // report1
            // 
            this.report1.NeedRefresh = false;
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.BackColor = System.Drawing.Color.Transparent;
            this.lblAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlmacen.ForeColor = System.Drawing.Color.White;
            this.lblAlmacen.Location = new System.Drawing.Point(12, 19);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(64, 16);
            this.lblAlmacen.TabIndex = 173;
            this.lblAlmacen.Text = "Almacen:";
            // 
            // ALMACENComboBox
            // 
            this.ALMACENComboBox.Condicion = null;
            this.ALMACENComboBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ALMACENComboBox.DisplayMember = "nombre";
            this.ALMACENComboBox.FormattingEnabled = true;
            this.ALMACENComboBox.IndiceCampoSelector = 0;
            this.ALMACENComboBox.LabelDescription = null;
            this.ALMACENComboBox.Location = new System.Drawing.Point(80, 16);
            this.ALMACENComboBox.Name = "ALMACENComboBox";
            this.ALMACENComboBox.NombreCampoSelector = "id";
            this.ALMACENComboBox.Query = "select id,nombre from almacen";
            this.ALMACENComboBox.QueryDeSeleccion = "select id,nombre from almacen where   id = @id";
            this.ALMACENComboBox.SelectedDataDisplaying = null;
            this.ALMACENComboBox.SelectedDataValue = null;
            this.ALMACENComboBox.Size = new System.Drawing.Size(116, 21);
            this.ALMACENComboBox.TabIndex = 174;
            this.ALMACENComboBox.ValueMember = "id";
            this.ALMACENComboBox.SelectedIndexChanged += new System.EventHandler(this.ALMACENComboBox_SelectedIndexChanged);
            // 
            // FRptProductoLocations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(834, 562);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRptProductoLocations";
            this.Text = "Producto x localidad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRptProductoLocations_FormClosing);
            this.Load += new System.EventHandler(this.FRptProductoLocations_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Panel panel1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.ComboBoxFB ANAQUELFINComboBox;
        private System.Windows.Forms.ComboBoxFB ANAQUELINICIOComboBox;
        private System.Windows.Forms.CheckBox CBTodos;
        private System.Windows.Forms.TabPage tabPage1;
        private FastReport.Preview.PreviewControl previewControl1;
        private FastReport.Report report1;
        private System.Windows.Forms.CheckBox CBKitsDesensamblados;
        private System.Windows.Forms.CheckBox CBTicket;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.ComboBoxFB ALMACENComboBox;
    }
}