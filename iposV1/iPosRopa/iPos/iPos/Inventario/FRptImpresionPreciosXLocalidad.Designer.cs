namespace iPos
{
    partial class FRptImpresionPreciosXLocalidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRptImpresionPreciosXLocalidad));
            this.report1 = new FastReport.Report();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.previewControl1 = new FastReport.Preview.PreviewControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbSinExistencias = new System.Windows.Forms.CheckBox();
            this.CBTodos = new System.Windows.Forms.CheckBox();
            this.ANAQUELFINComboBox = new System.Windows.Forms.ComboBoxFB();
            this.ANAQUELINICIOComboBox = new System.Windows.Forms.ComboBoxFB();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 80);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(798, 482);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.previewControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(790, 456);
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
            this.previewControl1.Size = new System.Drawing.Size(784, 450);
            this.previewControl1.TabIndex = 1;
            this.previewControl1.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.cbSinExistencias);
            this.panel1.Controls.Add(this.CBTodos);
            this.panel1.Controls.Add(this.ANAQUELFINComboBox);
            this.panel1.Controls.Add(this.ANAQUELINICIOComboBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnGenerar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 80);
            this.panel1.TabIndex = 9;
            // 
            // cbSinExistencias
            // 
            this.cbSinExistencias.AutoSize = true;
            this.cbSinExistencias.ForeColor = System.Drawing.Color.White;
            this.cbSinExistencias.Location = new System.Drawing.Point(274, 43);
            this.cbSinExistencias.Name = "cbSinExistencias";
            this.cbSinExistencias.Size = new System.Drawing.Size(92, 17);
            this.cbSinExistencias.TabIndex = 10;
            this.cbSinExistencias.Text = "Sin Existencia";
            this.cbSinExistencias.UseVisualStyleBackColor = true;
            // 
            // CBTodos
            // 
            this.CBTodos.AutoSize = true;
            this.CBTodos.ForeColor = System.Drawing.Color.White;
            this.CBTodos.Location = new System.Drawing.Point(389, 43);
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
            this.ANAQUELFINComboBox.Location = new System.Drawing.Point(527, 8);
            this.ANAQUELFINComboBox.Name = "ANAQUELFINComboBox";
            this.ANAQUELFINComboBox.NombreCampoSelector = "id";
            this.ANAQUELFINComboBox.Query = "select anaquel.id , anaquel.clave as nombre  from anaquel  order by anaquel.clave" +
    "";
            this.ANAQUELFINComboBox.QueryDeSeleccion = "select anaquel.id , anaquel.clave as nombre  from anaquel   where anaquel.id = @i" +
    "d ";
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
            this.ANAQUELINICIOComboBox.Location = new System.Drawing.Point(286, 7);
            this.ANAQUELINICIOComboBox.Name = "ANAQUELINICIOComboBox";
            this.ANAQUELINICIOComboBox.NombreCampoSelector = "id";
            this.ANAQUELINICIOComboBox.Query = "select anaquel.id , anaquel.clave as nombre  from anaquel  order by anaquel.clave" +
    "";
            this.ANAQUELINICIOComboBox.QueryDeSeleccion = "select anaquel.id , anaquel.clave as nombre  from anaquel   where anaquel.id = @i" +
    "d ";
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
            this.label2.Location = new System.Drawing.Point(442, 9);
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
            this.label1.Location = new System.Drawing.Point(192, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Del anaquel:";
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnGenerar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Location = new System.Drawing.Point(506, 39);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 5;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // FRptImpresionPreciosXLocalidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(798, 562);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRptImpresionPreciosXLocalidad";
            this.Text = "Impresion de Precios por Localidad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRptImpresionPreciosXLocalidad_FormClosing);
            this.Load += new System.EventHandler(this.FRptImpresionPreciosXLocalidad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FastReport.Report report1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private FastReport.Preview.PreviewControl previewControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox CBTodos;
        private System.Windows.Forms.ComboBoxFB ANAQUELFINComboBox;
        private System.Windows.Forms.ComboBoxFB ANAQUELINICIOComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.CheckBox cbSinExistencias;
    }
}