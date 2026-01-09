namespace iPos.Reportes
{
    partial class WFInformeProductosStock
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
            System.Windows.Forms.Label mARCAIDLabel;
            System.Windows.Forms.Label lINEAIDLabel;
            System.Windows.Forms.Label pROVEEDOR1IDLabel;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFInformeProductosStock));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.previewControl1 = new FastReport.Preview.PreviewControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboOrden = new System.Windows.Forms.ComboBox();
            this.cbDebajoStock = new System.Windows.Forms.CheckBox();
            this.CBTodosProveedores = new System.Windows.Forms.CheckBox();
            this.CBTodasMarcas = new System.Windows.Forms.CheckBox();
            this.MARCAButton = new System.Windows.Forms.Button();
            this.PROVEEDOR1Button = new System.Windows.Forms.Button();
            this.LINEAButton = new System.Windows.Forms.Button();
            this.MARCAIDTextBox = new iPos.Tools.TextBoxFB();
            this.MARCALabel = new System.Windows.Forms.Label();
            this.PROVEEDOR1IDTextBox = new iPos.Tools.TextBoxFB();
            this.PROVEEDOR1Label = new System.Windows.Forms.Label();
            this.LINEALabel = new System.Windows.Forms.Label();
            this.LINEAIDTextBox = new iPos.Tools.TextBoxFB();
            this.CBTodasLineas = new System.Windows.Forms.CheckBox();
            this.BTEnviar = new System.Windows.Forms.Button();
            this.report1 = new FastReport.Report();
            mARCAIDLabel = new System.Windows.Forms.Label();
            lINEAIDLabel = new System.Windows.Forms.Label();
            pROVEEDOR1IDLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            this.SuspendLayout();
            // 
            // mARCAIDLabel
            // 
            mARCAIDLabel.AutoSize = true;
            mARCAIDLabel.ForeColor = System.Drawing.Color.White;
            mARCAIDLabel.Location = new System.Drawing.Point(167, 81);
            mARCAIDLabel.Name = "mARCAIDLabel";
            mARCAIDLabel.Size = new System.Drawing.Size(40, 13);
            mARCAIDLabel.TabIndex = 164;
            mARCAIDLabel.Text = "Marca:";
            // 
            // lINEAIDLabel
            // 
            lINEAIDLabel.AutoSize = true;
            lINEAIDLabel.ForeColor = System.Drawing.Color.White;
            lINEAIDLabel.Location = new System.Drawing.Point(171, 54);
            lINEAIDLabel.Name = "lINEAIDLabel";
            lINEAIDLabel.Size = new System.Drawing.Size(36, 13);
            lINEAIDLabel.TabIndex = 163;
            lINEAIDLabel.Text = "Linea:";
            // 
            // pROVEEDOR1IDLabel
            // 
            pROVEEDOR1IDLabel.AutoSize = true;
            pROVEEDOR1IDLabel.ForeColor = System.Drawing.Color.White;
            pROVEEDOR1IDLabel.Location = new System.Drawing.Point(148, 28);
            pROVEEDOR1IDLabel.Name = "pROVEEDOR1IDLabel";
            pROVEEDOR1IDLabel.Size = new System.Drawing.Size(59, 13);
            pROVEEDOR1IDLabel.TabIndex = 162;
            pROVEEDOR1IDLabel.Text = "Proveedor:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(168, 109);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(39, 13);
            label1.TabIndex = 170;
            label1.Text = "Orden:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 140);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(885, 370);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.previewControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(877, 344);
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
            this.previewControl1.Size = new System.Drawing.Size(871, 338);
            this.previewControl1.TabIndex = 0;
            this.previewControl1.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(label1);
            this.panel1.Controls.Add(this.comboOrden);
            this.panel1.Controls.Add(this.cbDebajoStock);
            this.panel1.Controls.Add(this.CBTodosProveedores);
            this.panel1.Controls.Add(this.CBTodasMarcas);
            this.panel1.Controls.Add(this.MARCAButton);
            this.panel1.Controls.Add(this.PROVEEDOR1Button);
            this.panel1.Controls.Add(this.LINEAButton);
            this.panel1.Controls.Add(this.MARCAIDTextBox);
            this.panel1.Controls.Add(this.PROVEEDOR1IDTextBox);
            this.panel1.Controls.Add(this.MARCALabel);
            this.panel1.Controls.Add(this.PROVEEDOR1Label);
            this.panel1.Controls.Add(this.LINEALabel);
            this.panel1.Controls.Add(this.LINEAIDTextBox);
            this.panel1.Controls.Add(mARCAIDLabel);
            this.panel1.Controls.Add(lINEAIDLabel);
            this.panel1.Controls.Add(pROVEEDOR1IDLabel);
            this.panel1.Controls.Add(this.CBTodasLineas);
            this.panel1.Controls.Add(this.BTEnviar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(885, 140);
            this.panel1.TabIndex = 9;
            // 
            // comboOrden
            // 
            this.comboOrden.FormattingEnabled = true;
            this.comboOrden.Items.AddRange(new object[] {
            "Proveedor",
            "Linea",
            "Marca"});
            this.comboOrden.Location = new System.Drawing.Point(213, 106);
            this.comboOrden.Name = "comboOrden";
            this.comboOrden.Size = new System.Drawing.Size(131, 21);
            this.comboOrden.TabIndex = 169;
            // 
            // cbDebajoStock
            // 
            this.cbDebajoStock.AutoSize = true;
            this.cbDebajoStock.ForeColor = System.Drawing.Color.White;
            this.cbDebajoStock.Location = new System.Drawing.Point(526, 108);
            this.cbDebajoStock.Name = "cbDebajoStock";
            this.cbDebajoStock.Size = new System.Drawing.Size(146, 17);
            this.cbDebajoStock.TabIndex = 168;
            this.cbDebajoStock.Text = "Solo por debajo del stock";
            this.cbDebajoStock.UseVisualStyleBackColor = true;
            // 
            // CBTodosProveedores
            // 
            this.CBTodosProveedores.AutoSize = true;
            this.CBTodosProveedores.ForeColor = System.Drawing.Color.White;
            this.CBTodosProveedores.Location = new System.Drawing.Point(526, 24);
            this.CBTodosProveedores.Name = "CBTodosProveedores";
            this.CBTodosProveedores.Size = new System.Drawing.Size(134, 17);
            this.CBTodosProveedores.TabIndex = 3;
            this.CBTodosProveedores.Text = "Todas los proveedores";
            this.CBTodosProveedores.UseVisualStyleBackColor = true;
            // 
            // CBTodasMarcas
            // 
            this.CBTodasMarcas.AutoSize = true;
            this.CBTodasMarcas.ForeColor = System.Drawing.Color.White;
            this.CBTodasMarcas.Location = new System.Drawing.Point(526, 80);
            this.CBTodasMarcas.Name = "CBTodasMarcas";
            this.CBTodasMarcas.Size = new System.Drawing.Size(109, 17);
            this.CBTodasMarcas.TabIndex = 9;
            this.CBTodasMarcas.Text = "Todas las marcas";
            this.CBTodasMarcas.UseVisualStyleBackColor = true;
            // 
            // MARCAButton
            // 
            this.MARCAButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MARCAButton.BackgroundImage")));
            this.MARCAButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MARCAButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MARCAButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.MARCAButton.Location = new System.Drawing.Point(297, 75);
            this.MARCAButton.Name = "MARCAButton";
            this.MARCAButton.Size = new System.Drawing.Size(23, 23);
            this.MARCAButton.TabIndex = 8;
            this.MARCAButton.UseVisualStyleBackColor = true;
            // 
            // PROVEEDOR1Button
            // 
            this.PROVEEDOR1Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PROVEEDOR1Button.BackgroundImage")));
            this.PROVEEDOR1Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PROVEEDOR1Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PROVEEDOR1Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.PROVEEDOR1Button.Location = new System.Drawing.Point(297, 24);
            this.PROVEEDOR1Button.Name = "PROVEEDOR1Button";
            this.PROVEEDOR1Button.Size = new System.Drawing.Size(23, 23);
            this.PROVEEDOR1Button.TabIndex = 2;
            this.PROVEEDOR1Button.UseVisualStyleBackColor = true;
            // 
            // LINEAButton
            // 
            this.LINEAButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LINEAButton.BackgroundImage")));
            this.LINEAButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LINEAButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LINEAButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.LINEAButton.Location = new System.Drawing.Point(297, 49);
            this.LINEAButton.Name = "LINEAButton";
            this.LINEAButton.Size = new System.Drawing.Size(23, 23);
            this.LINEAButton.TabIndex = 5;
            this.LINEAButton.UseVisualStyleBackColor = true;
            // 
            // MARCAIDTextBox
            // 
            this.MARCAIDTextBox.BotonLookUp = this.MARCAButton;
            this.MARCAIDTextBox.Condicion = null;
            this.MARCAIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.MARCAIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.MARCAIDTextBox.DbValue = null;
            this.MARCAIDTextBox.Format_Expression = null;
            this.MARCAIDTextBox.IndiceCampoDescripcion = 2;
            this.MARCAIDTextBox.IndiceCampoSelector = 1;
            this.MARCAIDTextBox.IndiceCampoValue = 0;
            this.MARCAIDTextBox.LabelDescription = this.MARCALabel;
            this.MARCAIDTextBox.Location = new System.Drawing.Point(214, 75);
            this.MARCAIDTextBox.MostrarErrores = true;
            this.MARCAIDTextBox.Name = "MARCAIDTextBox";
            this.MARCAIDTextBox.NombreCampoSelector = "clave";
            this.MARCAIDTextBox.NombreCampoValue = "id";
            this.MARCAIDTextBox.Query = "select id,clave,nombre from marca";
            this.MARCAIDTextBox.QueryDeSeleccion = "select id,clave,nombre from marca where clave = @clave";
            this.MARCAIDTextBox.QueryPorDBValue = "select id,clave,nombre from marca where id = @id";
            this.MARCAIDTextBox.Size = new System.Drawing.Size(82, 20);
            this.MARCAIDTextBox.TabIndex = 7;
            this.MARCAIDTextBox.Tag = 34;
            this.MARCAIDTextBox.TextDescription = null;
            this.MARCAIDTextBox.Titulo = "Marcas";
            this.MARCAIDTextBox.ValidarEntrada = true;
            this.MARCAIDTextBox.ValidationExpression = null;
            // 
            // MARCALabel
            // 
            this.MARCALabel.AutoSize = true;
            this.MARCALabel.ForeColor = System.Drawing.Color.White;
            this.MARCALabel.Location = new System.Drawing.Point(329, 80);
            this.MARCALabel.Name = "MARCALabel";
            this.MARCALabel.Size = new System.Drawing.Size(16, 13);
            this.MARCALabel.TabIndex = 167;
            this.MARCALabel.Text = "...";
            // 
            // PROVEEDOR1IDTextBox
            // 
            this.PROVEEDOR1IDTextBox.BotonLookUp = this.PROVEEDOR1Button;
            this.PROVEEDOR1IDTextBox.Condicion = null;
            this.PROVEEDOR1IDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PROVEEDOR1IDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PROVEEDOR1IDTextBox.DbValue = null;
            this.PROVEEDOR1IDTextBox.Format_Expression = null;
            this.PROVEEDOR1IDTextBox.IndiceCampoDescripcion = 2;
            this.PROVEEDOR1IDTextBox.IndiceCampoSelector = 1;
            this.PROVEEDOR1IDTextBox.IndiceCampoValue = 0;
            this.PROVEEDOR1IDTextBox.LabelDescription = this.PROVEEDOR1Label;
            this.PROVEEDOR1IDTextBox.Location = new System.Drawing.Point(213, 25);
            this.PROVEEDOR1IDTextBox.MostrarErrores = true;
            this.PROVEEDOR1IDTextBox.Name = "PROVEEDOR1IDTextBox";
            this.PROVEEDOR1IDTextBox.NombreCampoSelector = "clave";
            this.PROVEEDOR1IDTextBox.NombreCampoValue = "id";
            this.PROVEEDOR1IDTextBox.Query = "select id,clave,nombre from persona where tipopersonaid = 40";
            this.PROVEEDOR1IDTextBox.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid = 40 and  clave = @clave";
            this.PROVEEDOR1IDTextBox.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid = 40 and  id = @id";
            this.PROVEEDOR1IDTextBox.Size = new System.Drawing.Size(82, 20);
            this.PROVEEDOR1IDTextBox.TabIndex = 1;
            this.PROVEEDOR1IDTextBox.Tag = 34;
            this.PROVEEDOR1IDTextBox.TextDescription = null;
            this.PROVEEDOR1IDTextBox.Titulo = "Proveedores";
            this.PROVEEDOR1IDTextBox.ValidarEntrada = true;
            this.PROVEEDOR1IDTextBox.ValidationExpression = null;
            // 
            // PROVEEDOR1Label
            // 
            this.PROVEEDOR1Label.AutoSize = true;
            this.PROVEEDOR1Label.ForeColor = System.Drawing.Color.White;
            this.PROVEEDOR1Label.Location = new System.Drawing.Point(329, 28);
            this.PROVEEDOR1Label.Name = "PROVEEDOR1Label";
            this.PROVEEDOR1Label.Size = new System.Drawing.Size(16, 13);
            this.PROVEEDOR1Label.TabIndex = 166;
            this.PROVEEDOR1Label.Text = "...";
            // 
            // LINEALabel
            // 
            this.LINEALabel.AutoSize = true;
            this.LINEALabel.ForeColor = System.Drawing.Color.White;
            this.LINEALabel.Location = new System.Drawing.Point(329, 54);
            this.LINEALabel.Name = "LINEALabel";
            this.LINEALabel.Size = new System.Drawing.Size(16, 13);
            this.LINEALabel.TabIndex = 165;
            this.LINEALabel.Text = "...";
            // 
            // LINEAIDTextBox
            // 
            this.LINEAIDTextBox.BotonLookUp = this.LINEAButton;
            this.LINEAIDTextBox.Condicion = null;
            this.LINEAIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.LINEAIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.LINEAIDTextBox.DbValue = null;
            this.LINEAIDTextBox.Format_Expression = null;
            this.LINEAIDTextBox.IndiceCampoDescripcion = 2;
            this.LINEAIDTextBox.IndiceCampoSelector = 1;
            this.LINEAIDTextBox.IndiceCampoValue = 0;
            this.LINEAIDTextBox.LabelDescription = this.LINEALabel;
            this.LINEAIDTextBox.Location = new System.Drawing.Point(213, 50);
            this.LINEAIDTextBox.MostrarErrores = true;
            this.LINEAIDTextBox.Name = "LINEAIDTextBox";
            this.LINEAIDTextBox.NombreCampoSelector = "clave";
            this.LINEAIDTextBox.NombreCampoValue = "id";
            this.LINEAIDTextBox.Query = "select id,clave,nombre from linea";
            this.LINEAIDTextBox.QueryDeSeleccion = "select id,clave,nombre from linea where clave = @clave";
            this.LINEAIDTextBox.QueryPorDBValue = "select id,clave,nombre from linea where id = @id";
            this.LINEAIDTextBox.Size = new System.Drawing.Size(82, 20);
            this.LINEAIDTextBox.TabIndex = 4;
            this.LINEAIDTextBox.Tag = 34;
            this.LINEAIDTextBox.TextDescription = null;
            this.LINEAIDTextBox.Titulo = "Lineas";
            this.LINEAIDTextBox.ValidarEntrada = true;
            this.LINEAIDTextBox.ValidationExpression = null;
            // 
            // CBTodasLineas
            // 
            this.CBTodasLineas.AutoSize = true;
            this.CBTodasLineas.ForeColor = System.Drawing.Color.White;
            this.CBTodasLineas.Location = new System.Drawing.Point(526, 52);
            this.CBTodasLineas.Name = "CBTodasLineas";
            this.CBTodasLineas.Size = new System.Drawing.Size(102, 17);
            this.CBTodasLineas.TabIndex = 6;
            this.CBTodasLineas.Text = "Todas las lineas";
            this.CBTodasLineas.UseVisualStyleBackColor = true;
            // 
            // BTEnviar
            // 
            this.BTEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.BTEnviar.ForeColor = System.Drawing.Color.White;
            this.BTEnviar.Location = new System.Drawing.Point(729, 54);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(82, 26);
            this.BTEnviar.TabIndex = 10;
            this.BTEnviar.Text = "Enviar";
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // WFInformeProductosStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(885, 510);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFInformeProductosStock";
            this.Text = "Catalogo de productos por stock";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WFInformeProductosStock_FormClosing);
            this.Load += new System.EventHandler(this.WFInformeProductosStock_Load);
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
        private System.Windows.Forms.Button BTEnviar;
        private FastReport.Preview.PreviewControl previewControl1;
        private FastReport.Report report1;
        private System.Windows.Forms.CheckBox CBTodasLineas;
        private System.Windows.Forms.CheckBox CBTodosProveedores;
        private System.Windows.Forms.CheckBox CBTodasMarcas;
        private System.Windows.Forms.Button MARCAButton;
        private System.Windows.Forms.Button PROVEEDOR1Button;
        private System.Windows.Forms.Button LINEAButton;
        private Tools.TextBoxFB MARCAIDTextBox;
        private System.Windows.Forms.Label MARCALabel;
        private Tools.TextBoxFB PROVEEDOR1IDTextBox;
        private System.Windows.Forms.Label PROVEEDOR1Label;
        private System.Windows.Forms.Label LINEALabel;
        private Tools.TextBoxFB LINEAIDTextBox;
        private System.Windows.Forms.ComboBox comboOrden;
        private System.Windows.Forms.CheckBox cbDebajoStock;
    }
}