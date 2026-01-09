namespace iPos.Reportes
{
    partial class WFProductosListaPrecios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFProductosListaPrecios));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.previewControl1 = new FastReport.Preview.PreviewControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LISTAPRECIOIDTextBox = new System.Windows.Forms.ComboBox();
            this.LISTAPRECIOIDLabel = new System.Windows.Forms.Label();
            this.CBMostrarExistencia = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BTEnviar = new System.Windows.Forms.Button();
            this.report1 = new FastReport.Report();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 109);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(885, 401);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.previewControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(877, 375);
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
            this.previewControl1.Size = new System.Drawing.Size(871, 369);
            this.previewControl1.TabIndex = 0;
            this.previewControl1.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.LISTAPRECIOIDTextBox);
            this.panel1.Controls.Add(this.LISTAPRECIOIDLabel);
            this.panel1.Controls.Add(this.CBMostrarExistencia);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.BTEnviar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(885, 109);
            this.panel1.TabIndex = 9;
            // 
            // LISTAPRECIOIDTextBox
            // 
            this.LISTAPRECIOIDTextBox.FormattingEnabled = true;
            this.LISTAPRECIOIDTextBox.Items.AddRange(new object[] {
            "Todas",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.LISTAPRECIOIDTextBox.Location = new System.Drawing.Point(468, 51);
            this.LISTAPRECIOIDTextBox.Name = "LISTAPRECIOIDTextBox";
            this.LISTAPRECIOIDTextBox.Size = new System.Drawing.Size(58, 21);
            this.LISTAPRECIOIDTextBox.TabIndex = 5;
            // 
            // LISTAPRECIOIDLabel
            // 
            this.LISTAPRECIOIDLabel.AutoSize = true;
            this.LISTAPRECIOIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.LISTAPRECIOIDLabel.ForeColor = System.Drawing.Color.White;
            this.LISTAPRECIOIDLabel.Location = new System.Drawing.Point(412, 52);
            this.LISTAPRECIOIDLabel.Name = "LISTAPRECIOIDLabel";
            this.LISTAPRECIOIDLabel.Size = new System.Drawing.Size(50, 16);
            this.LISTAPRECIOIDLabel.TabIndex = 182;
            this.LISTAPRECIOIDLabel.Text = "Precio:";
            // 
            // CBMostrarExistencia
            // 
            this.CBMostrarExistencia.AutoSize = true;
            this.CBMostrarExistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.CBMostrarExistencia.ForeColor = System.Drawing.Color.White;
            this.CBMostrarExistencia.Location = new System.Drawing.Point(203, 50);
            this.CBMostrarExistencia.Name = "CBMostrarExistencia";
            this.CBMostrarExistencia.Size = new System.Drawing.Size(135, 20);
            this.CBMostrarExistencia.TabIndex = 4;
            this.CBMostrarExistencia.Text = "Mostrar existencia";
            this.CBMostrarExistencia.UseVisualStyleBackColor = true;
            this.CBMostrarExistencia.CheckedChanged += new System.EventHandler(this.CBMostrarExistencia_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "LISTA DE PRECIOS";
            // 
            // BTEnviar
            // 
            this.BTEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.BTEnviar.ForeColor = System.Drawing.Color.White;
            this.BTEnviar.Location = new System.Drawing.Point(631, 44);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(86, 30);
            this.BTEnviar.TabIndex = 6;
            this.BTEnviar.Text = "Enviar";
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // WFProductosListaPrecios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(885, 510);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFProductosListaPrecios";
            this.Text = "Lista de precios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WFProductosListaPrecios_FormClosing);
            this.Load += new System.EventHandler(this.WFProductosListaPrecios_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTEnviar;
        private FastReport.Preview.PreviewControl previewControl1;
        private FastReport.Report report1;
        private System.Windows.Forms.CheckBox CBMostrarExistencia;
        private System.Windows.Forms.ComboBox LISTAPRECIOIDTextBox;
        private System.Windows.Forms.Label LISTAPRECIOIDLabel;
    }
}