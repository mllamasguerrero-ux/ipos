namespace iPos.Reportes.Bancomer
{
    partial class WFReporteTransBancomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFReporteTransBancomer));
            this.hastaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.desdeDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.todasTermCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTEnviar = new System.Windows.Forms.Button();
            this.TERMINALButton = new System.Windows.Forms.Button();
            this.TERMINALLabel = new System.Windows.Forms.Label();
            this.TERMINALIDTextBox = new iPos.Tools.TextBoxFB();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.previewControl1 = new FastReport.Preview.PreviewControl();
            this.report1 = new FastReport.Report();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            this.SuspendLayout();
            // 
            // hastaDateTimePicker
            // 
            this.hastaDateTimePicker.Location = new System.Drawing.Point(551, 53);
            this.hastaDateTimePicker.Name = "hastaDateTimePicker";
            this.hastaDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.hastaDateTimePicker.TabIndex = 0;
            // 
            // desdeDateTimePicker
            // 
            this.desdeDateTimePicker.Location = new System.Drawing.Point(198, 52);
            this.desdeDateTimePicker.Name = "desdeDateTimePicker";
            this.desdeDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.desdeDateTimePicker.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(145, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Desde:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(501, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(133, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Terminal:";
            // 
            // todasTermCheckBox
            // 
            this.todasTermCheckBox.AutoSize = true;
            this.todasTermCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.todasTermCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.todasTermCheckBox.ForeColor = System.Drawing.Color.White;
            this.todasTermCheckBox.Location = new System.Drawing.Point(504, 106);
            this.todasTermCheckBox.Name = "todasTermCheckBox";
            this.todasTermCheckBox.Size = new System.Drawing.Size(61, 17);
            this.todasTermCheckBox.TabIndex = 6;
            this.todasTermCheckBox.Text = "Todas";
            this.todasTermCheckBox.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.BTEnviar);
            this.panel1.Controls.Add(this.TERMINALButton);
            this.panel1.Controls.Add(this.TERMINALLabel);
            this.panel1.Controls.Add(this.TERMINALIDTextBox);
            this.panel1.Controls.Add(this.desdeDateTimePicker);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.todasTermCheckBox);
            this.panel1.Controls.Add(this.hastaDateTimePicker);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 159);
            this.panel1.TabIndex = 8;
            // 
            // BTEnviar
            // 
            this.BTEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTEnviar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BTEnviar.Location = new System.Drawing.Point(676, 103);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(75, 23);
            this.BTEnviar.TabIndex = 170;
            this.BTEnviar.Text = "Enviar";
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
            // 
            // TERMINALButton
            // 
            this.TERMINALButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.TERMINALButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TERMINALButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TERMINALButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.TERMINALButton.Location = new System.Drawing.Point(282, 103);
            this.TERMINALButton.Name = "TERMINALButton";
            this.TERMINALButton.Size = new System.Drawing.Size(24, 24);
            this.TERMINALButton.TabIndex = 167;
            this.TERMINALButton.UseVisualStyleBackColor = true;
            // 
            // TERMINALLabel
            // 
            this.TERMINALLabel.AutoSize = true;
            this.TERMINALLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TERMINALLabel.Location = new System.Drawing.Point(313, 108);
            this.TERMINALLabel.Name = "TERMINALLabel";
            this.TERMINALLabel.Size = new System.Drawing.Size(16, 13);
            this.TERMINALLabel.TabIndex = 169;
            this.TERMINALLabel.Text = "...";
            // 
            // TERMINALIDTextBox
            // 
            this.TERMINALIDTextBox.BotonLookUp = this.TERMINALButton;
            this.TERMINALIDTextBox.Condicion = null;
            this.TERMINALIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.TERMINALIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.TERMINALIDTextBox.DbValue = null;
            this.TERMINALIDTextBox.Format_Expression = null;
            this.TERMINALIDTextBox.IndiceCampoDescripcion = 2;
            this.TERMINALIDTextBox.IndiceCampoSelector = 1;
            this.TERMINALIDTextBox.IndiceCampoValue = 0;
            this.TERMINALIDTextBox.LabelDescription = this.TERMINALLabel;
            this.TERMINALIDTextBox.Location = new System.Drawing.Point(198, 104);
            this.TERMINALIDTextBox.MostrarErrores = true;
            this.TERMINALIDTextBox.Name = "TERMINALIDTextBox";
            this.TERMINALIDTextBox.NombreCampoSelector = "clave";
            this.TERMINALIDTextBox.NombreCampoValue = "numeroterminalbancomer";
            this.TERMINALIDTextBox.Query = "select numeroterminalbancomer,clave,nombre from caja where coalesce(numerotermina" +
    "lbancomer,0)  > 0";
            this.TERMINALIDTextBox.QueryDeSeleccion = "select numeroterminalbancomer,clave,nombre from caja where coalesce(numerotermina" +
    "lbancomer,0)  > 0 and clave = @clave";
            this.TERMINALIDTextBox.QueryPorDBValue = "select numeroterminalbancomer,clave,nombre from caja where id = @id";
            this.TERMINALIDTextBox.Size = new System.Drawing.Size(82, 20);
            this.TERMINALIDTextBox.TabIndex = 166;
            this.TERMINALIDTextBox.Tag = 34;
            this.TERMINALIDTextBox.TextDescription = null;
            this.TERMINALIDTextBox.Titulo = "Terminales";
            this.TERMINALIDTextBox.ValidarEntrada = true;
            this.TERMINALIDTextBox.ValidationExpression = null;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 159);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(834, 272);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.previewControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(826, 246);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "REPORTE";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // previewControl1
            // 
            this.previewControl1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.previewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewControl1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.previewControl1.Location = new System.Drawing.Point(3, 3);
            this.previewControl1.Name = "previewControl1";
            this.previewControl1.PageOffset = new System.Drawing.Point(10, 10);
            this.previewControl1.Size = new System.Drawing.Size(820, 240);
            this.previewControl1.TabIndex = 0;
            this.previewControl1.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // WFReporteTransBancomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(834, 431);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFReporteTransBancomer";
            this.Text = "Reporte de Transacciones Bancomer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WFReporteTransBancomer_FormClosing);
            this.Load += new System.EventHandler(this.WFReporteTransBancomer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker hastaDateTimePicker;
        private System.Windows.Forms.DateTimePicker desdeDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox todasTermCheckBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button TERMINALButton;
        private System.Windows.Forms.Label TERMINALLabel;
        private Tools.TextBoxFB TERMINALIDTextBox;
        private System.Windows.Forms.Button BTEnviar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private FastReport.Preview.PreviewControl previewControl1;
        private FastReport.Report report1;
    }
}