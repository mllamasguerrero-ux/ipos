namespace iPos.Reportes.Catalogos
{
    partial class WFInventarioCosteadoMultiSucursal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFInventarioCosteadoMultiSucursal));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.previewControl1 = new FastReport.Preview.PreviewControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CBTodasLineas = new System.Windows.Forms.CheckBox();
            this.ITEMButton = new System.Windows.Forms.Button();
            this.ITEMLabel = new System.Windows.Forms.Label();
            this.ITEMIDTextBox = new iPos.Tools.TextBoxFB();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTodosProveedores = new iPos.Tools.CheckBoxFB();
            this.label4 = new System.Windows.Forms.Label();
            this.PERSONAIDTextBox = new iPos.Tools.TextBoxFB();
            this.PERSONAButton = new System.Windows.Forms.Button();
            this.PERSONALabel = new System.Windows.Forms.Label();
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
            this.tabControl1.Location = new System.Drawing.Point(0, 112);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(885, 398);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.previewControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(877, 372);
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
            this.previewControl1.Size = new System.Drawing.Size(871, 366);
            this.previewControl1.TabIndex = 0;
            this.previewControl1.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.CBTodasLineas);
            this.panel1.Controls.Add(this.ITEMButton);
            this.panel1.Controls.Add(this.ITEMLabel);
            this.panel1.Controls.Add(this.ITEMIDTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbTodosProveedores);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.PERSONAIDTextBox);
            this.panel1.Controls.Add(this.PERSONALabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.PERSONAButton);
            this.panel1.Controls.Add(this.BTEnviar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(885, 112);
            this.panel1.TabIndex = 12;
            // 
            // CBTodasLineas
            // 
            this.CBTodasLineas.AutoSize = true;
            this.CBTodasLineas.ForeColor = System.Drawing.Color.White;
            this.CBTodasLineas.Location = new System.Drawing.Point(478, 69);
            this.CBTodasLineas.Name = "CBTodasLineas";
            this.CBTodasLineas.Size = new System.Drawing.Size(102, 17);
            this.CBTodasLineas.TabIndex = 185;
            this.CBTodasLineas.Text = "Todas las lineas";
            this.CBTodasLineas.UseVisualStyleBackColor = true;
            // 
            // ITEMButton
            // 
            this.ITEMButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ITEMButton.BackgroundImage")));
            this.ITEMButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ITEMButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ITEMButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ITEMButton.Location = new System.Drawing.Point(188, 69);
            this.ITEMButton.Name = "ITEMButton";
            this.ITEMButton.Size = new System.Drawing.Size(23, 23);
            this.ITEMButton.TabIndex = 182;
            this.ITEMButton.UseVisualStyleBackColor = true;
            // 
            // ITEMLabel
            // 
            this.ITEMLabel.AutoSize = true;
            this.ITEMLabel.ForeColor = System.Drawing.Color.White;
            this.ITEMLabel.Location = new System.Drawing.Point(215, 74);
            this.ITEMLabel.Name = "ITEMLabel";
            this.ITEMLabel.Size = new System.Drawing.Size(16, 13);
            this.ITEMLabel.TabIndex = 184;
            this.ITEMLabel.Text = "...";
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
            this.ITEMIDTextBox.IndiceCampoValue = 1;
            this.ITEMIDTextBox.LabelDescription = this.ITEMLabel;
            this.ITEMIDTextBox.Location = new System.Drawing.Point(100, 70);
            this.ITEMIDTextBox.MostrarErrores = true;
            this.ITEMIDTextBox.Name = "ITEMIDTextBox";
            this.ITEMIDTextBox.NombreCampoSelector = "clave";
            this.ITEMIDTextBox.NombreCampoValue = "clave";
            this.ITEMIDTextBox.Query = "select id,clave,nombre from linea";
            this.ITEMIDTextBox.QueryDeSeleccion = "select id,clave,nombre from linea where clave = @clave";
            this.ITEMIDTextBox.QueryPorDBValue = "select id,clave,nombre from linea where id = @id";
            this.ITEMIDTextBox.Size = new System.Drawing.Size(82, 20);
            this.ITEMIDTextBox.TabIndex = 181;
            this.ITEMIDTextBox.Tag = 34;
            this.ITEMIDTextBox.TextDescription = null;
            this.ITEMIDTextBox.Titulo = "Lineas";
            this.ITEMIDTextBox.ValidarEntrada = true;
            this.ITEMIDTextBox.ValidationExpression = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(52, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 183;
            this.label1.Text = "Linea:";
            // 
            // cbTodosProveedores
            // 
            this.cbTodosProveedores.AutoSize = true;
            this.cbTodosProveedores.ForeColor = System.Drawing.Color.White;
            this.cbTodosProveedores.Location = new System.Drawing.Point(478, 35);
            this.cbTodosProveedores.Name = "cbTodosProveedores";
            this.cbTodosProveedores.Size = new System.Drawing.Size(56, 17);
            this.cbTodosProveedores.TabIndex = 168;
            this.cbTodosProveedores.Text = "Todos";
            this.cbTodosProveedores.TextValue = "0";
            this.cbTodosProveedores.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(25, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 167;
            this.label4.Text = "Proveedor:";
            // 
            // PERSONAIDTextBox
            // 
            this.PERSONAIDTextBox.BotonLookUp = this.PERSONAButton;
            this.PERSONAIDTextBox.Condicion = null;
            this.PERSONAIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PERSONAIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PERSONAIDTextBox.DbValue = null;
            this.PERSONAIDTextBox.Format_Expression = null;
            this.PERSONAIDTextBox.IndiceCampoDescripcion = 2;
            this.PERSONAIDTextBox.IndiceCampoSelector = 1;
            this.PERSONAIDTextBox.IndiceCampoValue = 1;
            this.PERSONAIDTextBox.LabelDescription = this.PERSONALabel;
            this.PERSONAIDTextBox.Location = new System.Drawing.Point(100, 32);
            this.PERSONAIDTextBox.MostrarErrores = true;
            this.PERSONAIDTextBox.Name = "PERSONAIDTextBox";
            this.PERSONAIDTextBox.NombreCampoSelector = "clave";
            this.PERSONAIDTextBox.NombreCampoValue = "clave";
            this.PERSONAIDTextBox.Query = "select id,clave,nombre from persona where tipopersonaid in (40)";
            this.PERSONAIDTextBox.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid in (40) and  clave= @clav" +
    "e";
            this.PERSONAIDTextBox.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid in (40) and  id = @id";
            this.PERSONAIDTextBox.Size = new System.Drawing.Size(82, 20);
            this.PERSONAIDTextBox.TabIndex = 163;
            this.PERSONAIDTextBox.Tag = 34;
            this.PERSONAIDTextBox.TextDescription = null;
            this.PERSONAIDTextBox.Titulo = "Proveedores";
            this.PERSONAIDTextBox.ValidarEntrada = true;
            this.PERSONAIDTextBox.ValidationExpression = null;
            // 
            // PERSONAButton
            // 
            this.PERSONAButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PERSONAButton.BackgroundImage")));
            this.PERSONAButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PERSONAButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PERSONAButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.PERSONAButton.Location = new System.Drawing.Point(188, 32);
            this.PERSONAButton.Name = "PERSONAButton";
            this.PERSONAButton.Size = new System.Drawing.Size(23, 23);
            this.PERSONAButton.TabIndex = 164;
            this.PERSONAButton.UseVisualStyleBackColor = true;
            // 
            // PERSONALabel
            // 
            this.PERSONALabel.AutoSize = true;
            this.PERSONALabel.ForeColor = System.Drawing.Color.White;
            this.PERSONALabel.Location = new System.Drawing.Point(215, 38);
            this.PERSONALabel.Name = "PERSONALabel";
            this.PERSONALabel.Size = new System.Drawing.Size(16, 13);
            this.PERSONALabel.TabIndex = 166;
            this.PERSONALabel.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Inventario Costeado MultiSucursal";
            // 
            // BTEnviar
            // 
            this.BTEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.BTEnviar.ForeColor = System.Drawing.Color.White;
            this.BTEnviar.Location = new System.Drawing.Point(689, 65);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(92, 27);
            this.BTEnviar.TabIndex = 5;
            this.BTEnviar.Text = "Enviar";
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // WFInventarioCosteadoMultiSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(885, 510);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFInventarioCosteadoMultiSucursal";
            this.Text = "Inventario Costeado MultiSucursal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WFInventarioCosteadoMultiSucursal_FormClosing);
            this.Load += new System.EventHandler(this.WFInventarioCosteadoMultiSucursal_Load);
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
        private FastReport.Preview.PreviewControl previewControl1;
        private System.Windows.Forms.Panel panel1;
        private Tools.CheckBoxFB cbTodosProveedores;
        private System.Windows.Forms.Label label4;
        private Tools.TextBoxFB PERSONAIDTextBox;
        private System.Windows.Forms.Button PERSONAButton;
        private System.Windows.Forms.Label PERSONALabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTEnviar;
        private System.Windows.Forms.Button ITEMButton;
        private System.Windows.Forms.Label ITEMLabel;
        private Tools.TextBoxFB ITEMIDTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CBTodasLineas;
        private FastReport.Report report1;
    }
}