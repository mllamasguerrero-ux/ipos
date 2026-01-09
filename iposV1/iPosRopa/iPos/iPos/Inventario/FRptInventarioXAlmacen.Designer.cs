namespace iPos
{
	partial class FRptInventarioXAlmacen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRptInventarioXAlmacen));
            this.btnGenerar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.previewControl1 = new FastReport.Preview.PreviewControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PRODUCTOSUSTITUTOButton = new System.Windows.Forms.Button();
            this.PRODUCTOIDTextBox = new iPos.Tools.TextBoxFB();
            this.PRODUCTOSUSTITUTOLabel = new System.Windows.Forms.Label();
            this.ALMACENComboBox = new System.Windows.Forms.ComboBoxFB();
            this.CBTodosAlmacenes = new System.Windows.Forms.CheckBox();
            this.CBTodosProductos = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.report1 = new FastReport.Report();
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
            this.btnGenerar.Location = new System.Drawing.Point(625, 41);
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
            this.tabControl1.Size = new System.Drawing.Size(813, 482);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.previewControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(805, 456);
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
            this.previewControl1.Size = new System.Drawing.Size(799, 450);
            this.previewControl1.TabIndex = 1;
            this.previewControl1.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.PRODUCTOSUSTITUTOButton);
            this.panel1.Controls.Add(this.PRODUCTOIDTextBox);
            this.panel1.Controls.Add(this.PRODUCTOSUSTITUTOLabel);
            this.panel1.Controls.Add(this.ALMACENComboBox);
            this.panel1.Controls.Add(this.CBTodosAlmacenes);
            this.panel1.Controls.Add(this.CBTodosProductos);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnGenerar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(813, 80);
            this.panel1.TabIndex = 1;
            // 
            // PRODUCTOSUSTITUTOButton
            // 
            this.PRODUCTOSUSTITUTOButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.PRODUCTOSUSTITUTOButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PRODUCTOSUSTITUTOButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PRODUCTOSUSTITUTOButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.PRODUCTOSUSTITUTOButton.Location = new System.Drawing.Point(595, 11);
            this.PRODUCTOSUSTITUTOButton.Name = "PRODUCTOSUSTITUTOButton";
            this.PRODUCTOSUSTITUTOButton.Size = new System.Drawing.Size(21, 23);
            this.PRODUCTOSUSTITUTOButton.TabIndex = 173;
            this.PRODUCTOSUSTITUTOButton.UseVisualStyleBackColor = true;
            // 
            // PRODUCTOIDTextBox
            // 
            this.PRODUCTOIDTextBox.BotonLookUp = this.PRODUCTOSUSTITUTOButton;
            this.PRODUCTOIDTextBox.Condicion = null;
            this.PRODUCTOIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PRODUCTOIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PRODUCTOIDTextBox.DbValue = null;
            this.PRODUCTOIDTextBox.Format_Expression = null;
            this.PRODUCTOIDTextBox.IndiceCampoDescripcion = 2;
            this.PRODUCTOIDTextBox.IndiceCampoSelector = 1;
            this.PRODUCTOIDTextBox.IndiceCampoValue = 0;
            this.PRODUCTOIDTextBox.LabelDescription = this.PRODUCTOSUSTITUTOLabel;
            this.PRODUCTOIDTextBox.Location = new System.Drawing.Point(506, 14);
            this.PRODUCTOIDTextBox.MostrarErrores = true;
            this.PRODUCTOIDTextBox.Name = "PRODUCTOIDTextBox";
            this.PRODUCTOIDTextBox.NombreCampoSelector = "clave";
            this.PRODUCTOIDTextBox.NombreCampoValue = "id";
            this.PRODUCTOIDTextBox.Query = "select id,clave, nombre from producto";
            this.PRODUCTOIDTextBox.QueryDeSeleccion = "select id,clave,nombre from producto where clave = @clave";
            this.PRODUCTOIDTextBox.QueryPorDBValue = "select id,clave,nombre from producto where id = @id";
            this.PRODUCTOIDTextBox.Size = new System.Drawing.Size(82, 20);
            this.PRODUCTOIDTextBox.TabIndex = 172;
            this.PRODUCTOIDTextBox.Tag = 34;
            this.PRODUCTOIDTextBox.TextDescription = null;
            this.PRODUCTOIDTextBox.Titulo = "Lineas";
            this.PRODUCTOIDTextBox.ValidarEntrada = true;
            this.PRODUCTOIDTextBox.ValidationExpression = null;
            // 
            // PRODUCTOSUSTITUTOLabel
            // 
            this.PRODUCTOSUSTITUTOLabel.AutoSize = true;
            this.PRODUCTOSUSTITUTOLabel.ForeColor = System.Drawing.Color.White;
            this.PRODUCTOSUSTITUTOLabel.Location = new System.Drawing.Point(622, 17);
            this.PRODUCTOSUSTITUTOLabel.Name = "PRODUCTOSUSTITUTOLabel";
            this.PRODUCTOSUSTITUTOLabel.Size = new System.Drawing.Size(16, 13);
            this.PRODUCTOSUSTITUTOLabel.TabIndex = 174;
            this.PRODUCTOSUSTITUTOLabel.Text = "...";
            // 
            // ALMACENComboBox
            // 
            this.ALMACENComboBox.Condicion = null;
            this.ALMACENComboBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ALMACENComboBox.DisplayMember = "nombre";
            this.ALMACENComboBox.FormattingEnabled = true;
            this.ALMACENComboBox.IndiceCampoSelector = 0;
            this.ALMACENComboBox.LabelDescription = null;
            this.ALMACENComboBox.Location = new System.Drawing.Point(275, 13);
            this.ALMACENComboBox.Name = "ALMACENComboBox";
            this.ALMACENComboBox.NombreCampoSelector = "id";
            this.ALMACENComboBox.Query = "select id,nombre from almacen";
            this.ALMACENComboBox.QueryDeSeleccion = "select id,nombre from almacen where   id = @id";
            this.ALMACENComboBox.SelectedDataDisplaying = null;
            this.ALMACENComboBox.SelectedDataValue = null;
            this.ALMACENComboBox.Size = new System.Drawing.Size(125, 21);
            this.ALMACENComboBox.TabIndex = 171;
            this.ALMACENComboBox.ValueMember = "id";
            // 
            // CBTodosAlmacenes
            // 
            this.CBTodosAlmacenes.AutoSize = true;
            this.CBTodosAlmacenes.ForeColor = System.Drawing.Color.White;
            this.CBTodosAlmacenes.Location = new System.Drawing.Point(275, 45);
            this.CBTodosAlmacenes.Name = "CBTodosAlmacenes";
            this.CBTodosAlmacenes.Size = new System.Drawing.Size(56, 17);
            this.CBTodosAlmacenes.TabIndex = 10;
            this.CBTodosAlmacenes.Text = "Todos";
            this.CBTodosAlmacenes.UseVisualStyleBackColor = true;
            // 
            // CBTodosProductos
            // 
            this.CBTodosProductos.AutoSize = true;
            this.CBTodosProductos.ForeColor = System.Drawing.Color.White;
            this.CBTodosProductos.Location = new System.Drawing.Point(506, 45);
            this.CBTodosProductos.Name = "CBTodosProductos";
            this.CBTodosProductos.Size = new System.Drawing.Size(56, 17);
            this.CBTodosProductos.TabIndex = 9;
            this.CBTodosProductos.Text = "Todos";
            this.CBTodosProductos.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(407, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Del producto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(179, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Del almacen:";
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // FRptInventarioXAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(813, 562);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRptInventarioXAlmacen";
            this.Text = "Inventario por almacen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRptInventarioXAlmacen_FormClosing);
            this.Load += new System.EventHandler(this.FRptInventarioXAlmacen_Load);
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
        private System.Windows.Forms.CheckBox CBTodosProductos;
        private System.Windows.Forms.TabPage tabPage1;
        private FastReport.Preview.PreviewControl previewControl1;
        private FastReport.Report report1;
        private System.Windows.Forms.CheckBox CBTodosAlmacenes;
        private System.Windows.Forms.ComboBoxFB ALMACENComboBox;
        private System.Windows.Forms.Button PRODUCTOSUSTITUTOButton;
        private Tools.TextBoxFB PRODUCTOIDTextBox;
        private System.Windows.Forms.Label PRODUCTOSUSTITUTOLabel;
	}
}