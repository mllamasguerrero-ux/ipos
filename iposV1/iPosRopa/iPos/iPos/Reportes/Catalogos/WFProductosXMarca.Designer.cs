namespace iPos.Reportes
{
    partial class WFProductosXMarca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFProductosXMarca));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.previewControl1 = new FastReport.Preview.PreviewControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ITEMButton = new System.Windows.Forms.Button();
            this.ITEMIDTextBox = new iPos.Tools.TextBoxFB();
            this.ITEMLabel = new System.Windows.Forms.Label();
            this.LISTAPRECIOIDTextBox = new System.Windows.Forms.ComboBox();
            this.LISTAPRECIOIDLabel = new System.Windows.Forms.Label();
            this.CBMostrarExistencia = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CBTodasItem = new System.Windows.Forms.CheckBox();
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
            this.panel1.Controls.Add(this.ITEMButton);
            this.panel1.Controls.Add(this.ITEMIDTextBox);
            this.panel1.Controls.Add(this.ITEMLabel);
            this.panel1.Controls.Add(this.LISTAPRECIOIDTextBox);
            this.panel1.Controls.Add(this.LISTAPRECIOIDLabel);
            this.panel1.Controls.Add(this.CBMostrarExistencia);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.CBTodasItem);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.BTEnviar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(885, 109);
            this.panel1.TabIndex = 9;
            // 
            // ITEMButton
            // 
            this.ITEMButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.ITEMButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ITEMButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ITEMButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ITEMButton.Location = new System.Drawing.Point(367, 47);
            this.ITEMButton.Name = "ITEMButton";
            this.ITEMButton.Size = new System.Drawing.Size(23, 23);
            this.ITEMButton.TabIndex = 2;
            this.ITEMButton.UseVisualStyleBackColor = true;
            // 
            // ITEMIDTextBox
            // 
            this.ITEMIDTextBox.BotonLookUp = this.ITEMButton;
            this.ITEMIDTextBox.Condicion = null;
            this.ITEMIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ITEMIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ITEMIDTextBox.DbValue = null;
            this.ITEMIDTextBox.Format_Expression = null;
            this.ITEMIDTextBox.IndiceCampoDescripcion = 2;
            this.ITEMIDTextBox.IndiceCampoSelector = 1;
            this.ITEMIDTextBox.IndiceCampoValue = 0;
            this.ITEMIDTextBox.LabelDescription = this.ITEMLabel;
            this.ITEMIDTextBox.Location = new System.Drawing.Point(279, 49);
            this.ITEMIDTextBox.MostrarErrores = true;
            this.ITEMIDTextBox.Name = "ITEMIDTextBox";
            this.ITEMIDTextBox.NombreCampoSelector = "clave";
            this.ITEMIDTextBox.NombreCampoValue = "id";
            this.ITEMIDTextBox.Query = "select id,clave,nombre from marca";
            this.ITEMIDTextBox.QueryDeSeleccion = "select id,clave,nombre from marca where clave = @clave";
            this.ITEMIDTextBox.QueryPorDBValue = "select id,clave,nombre from marca where id = @id";
            this.ITEMIDTextBox.Size = new System.Drawing.Size(82, 20);
            this.ITEMIDTextBox.TabIndex = 1;
            this.ITEMIDTextBox.Tag = 34;
            this.ITEMIDTextBox.TextDescription = null;
            this.ITEMIDTextBox.Titulo = "Marcas";
            this.ITEMIDTextBox.ValidarEntrada = true;
            this.ITEMIDTextBox.ValidationExpression = null;
            // 
            // ITEMLabel
            // 
            this.ITEMLabel.AutoSize = true;
            this.ITEMLabel.ForeColor = System.Drawing.Color.White;
            this.ITEMLabel.Location = new System.Drawing.Point(394, 52);
            this.ITEMLabel.Name = "ITEMLabel";
            this.ITEMLabel.Size = new System.Drawing.Size(16, 13);
            this.ITEMLabel.TabIndex = 185;
            this.ITEMLabel.Text = "...";
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
            this.LISTAPRECIOIDTextBox.Location = new System.Drawing.Point(434, 78);
            this.LISTAPRECIOIDTextBox.Name = "LISTAPRECIOIDTextBox";
            this.LISTAPRECIOIDTextBox.Size = new System.Drawing.Size(58, 21);
            this.LISTAPRECIOIDTextBox.TabIndex = 5;
            // 
            // LISTAPRECIOIDLabel
            // 
            this.LISTAPRECIOIDLabel.AutoSize = true;
            this.LISTAPRECIOIDLabel.ForeColor = System.Drawing.Color.White;
            this.LISTAPRECIOIDLabel.Location = new System.Drawing.Point(391, 81);
            this.LISTAPRECIOIDLabel.Name = "LISTAPRECIOIDLabel";
            this.LISTAPRECIOIDLabel.Size = new System.Drawing.Size(37, 13);
            this.LISTAPRECIOIDLabel.TabIndex = 182;
            this.LISTAPRECIOIDLabel.Text = "Precio";
            // 
            // CBMostrarExistencia
            // 
            this.CBMostrarExistencia.AutoSize = true;
            this.CBMostrarExistencia.ForeColor = System.Drawing.Color.White;
            this.CBMostrarExistencia.Location = new System.Drawing.Point(215, 80);
            this.CBMostrarExistencia.Name = "CBMostrarExistencia";
            this.CBMostrarExistencia.Size = new System.Drawing.Size(111, 17);
            this.CBMostrarExistencia.TabIndex = 4;
            this.CBMostrarExistencia.Text = "Mostrar existencia";
            this.CBMostrarExistencia.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(212, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 179;
            this.label4.Text = "Marca:";
            // 
            // CBTodasItem
            // 
            this.CBTodasItem.AutoSize = true;
            this.CBTodasItem.ForeColor = System.Drawing.Color.White;
            this.CBTodasItem.Location = new System.Drawing.Point(539, 51);
            this.CBTodasItem.Name = "CBTodasItem";
            this.CBTodasItem.Size = new System.Drawing.Size(109, 17);
            this.CBTodasItem.TabIndex = 3;
            this.CBTodasItem.Text = "Todas las marcas";
            this.CBTodasItem.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "PRODUCTO POR MARCA";
            // 
            // BTEnviar
            // 
            this.BTEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTEnviar.ForeColor = System.Drawing.Color.White;
            this.BTEnviar.Location = new System.Drawing.Point(564, 76);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(75, 23);
            this.BTEnviar.TabIndex = 6;
            this.BTEnviar.Text = "Enviar";
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // WFProductosXMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(885, 510);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFProductosXMarca";
            this.Text = "Producto por marca";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WFProductosXMarca_FormClosing);
            this.Load += new System.EventHandler(this.WFProductosXMarca_Load);
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
        private System.Windows.Forms.CheckBox CBTodasItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox CBMostrarExistencia;
        private System.Windows.Forms.ComboBox LISTAPRECIOIDTextBox;
        private System.Windows.Forms.Label LISTAPRECIOIDLabel;
        private System.Windows.Forms.Button ITEMButton;
        private Tools.TextBoxFB ITEMIDTextBox;
        private System.Windows.Forms.Label ITEMLabel;
    }
}