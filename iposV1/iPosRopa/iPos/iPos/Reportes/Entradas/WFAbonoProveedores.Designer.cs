namespace iPos.Reportes.Entradas
{
    partial class WFAbonoProveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFAbonoProveedores));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbTodosUsuarios = new iPos.Tools.CheckBoxFB();
            this.label5 = new System.Windows.Forms.Label();
            this.USUARIOIDTextBox = new iPos.Tools.TextBoxFB();
            this.USUARIOButton = new System.Windows.Forms.Button();
            this.USUARIOLabel = new System.Windows.Forms.Label();
            this.cbTodosProveedores = new iPos.Tools.CheckBoxFB();
            this.label4 = new System.Windows.Forms.Label();
            this.PERSONAIDTextBox = new iPos.Tools.TextBoxFB();
            this.PERSONAButton = new System.Windows.Forms.Button();
            this.PERSONALabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BTEnviar = new System.Windows.Forms.Button();
            this.DTPFrom = new System.Windows.Forms.DateTimePicker();
            this.DTPTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.cbTodosUsuarios);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.USUARIOIDTextBox);
            this.panel1.Controls.Add(this.USUARIOLabel);
            this.panel1.Controls.Add(this.USUARIOButton);
            this.panel1.Controls.Add(this.cbTodosProveedores);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.PERSONAIDTextBox);
            this.panel1.Controls.Add(this.PERSONALabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.PERSONAButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BTEnviar);
            this.panel1.Controls.Add(this.DTPFrom);
            this.panel1.Controls.Add(this.DTPTo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(885, 112);
            this.panel1.TabIndex = 10;
            // 
            // cbTodosUsuarios
            // 
            this.cbTodosUsuarios.AutoSize = true;
            this.cbTodosUsuarios.ForeColor = System.Drawing.Color.White;
            this.cbTodosUsuarios.Location = new System.Drawing.Point(439, 62);
            this.cbTodosUsuarios.Name = "cbTodosUsuarios";
            this.cbTodosUsuarios.Size = new System.Drawing.Size(56, 17);
            this.cbTodosUsuarios.TabIndex = 173;
            this.cbTodosUsuarios.Text = "Todos";
            this.cbTodosUsuarios.TextValue = "0";
            this.cbTodosUsuarios.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(40, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 172;
            this.label5.Text = "Usuario:";
            // 
            // USUARIOIDTextBox
            // 
            this.USUARIOIDTextBox.BotonLookUp = this.USUARIOButton;
            this.USUARIOIDTextBox.Condicion = null;
            this.USUARIOIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.USUARIOIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.USUARIOIDTextBox.DbValue = null;
            this.USUARIOIDTextBox.Format_Expression = null;
            this.USUARIOIDTextBox.IndiceCampoDescripcion = 2;
            this.USUARIOIDTextBox.IndiceCampoSelector = 1;
            this.USUARIOIDTextBox.IndiceCampoValue = 0;
            this.USUARIOIDTextBox.LabelDescription = this.USUARIOLabel;
            this.USUARIOIDTextBox.Location = new System.Drawing.Point(100, 58);
            this.USUARIOIDTextBox.MostrarErrores = true;
            this.USUARIOIDTextBox.Name = "USUARIOIDTextBox";
            this.USUARIOIDTextBox.NombreCampoSelector = "clave";
            this.USUARIOIDTextBox.NombreCampoValue = "id";
            this.USUARIOIDTextBox.Query = "select id,clave,nombre from persona where tipopersonaid in (20)";
            this.USUARIOIDTextBox.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid in (20) and  clave= @clav" +
    "e";
            this.USUARIOIDTextBox.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid in (20) and  id = @id";
            this.USUARIOIDTextBox.Size = new System.Drawing.Size(82, 20);
            this.USUARIOIDTextBox.TabIndex = 169;
            this.USUARIOIDTextBox.Tag = 34;
            this.USUARIOIDTextBox.TextDescription = null;
            this.USUARIOIDTextBox.Titulo = "Usuarios";
            this.USUARIOIDTextBox.ValidarEntrada = true;
            this.USUARIOIDTextBox.ValidationExpression = null;
            // 
            // USUARIOButton
            // 
            this.USUARIOButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("USUARIOButton.BackgroundImage")));
            this.USUARIOButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.USUARIOButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.USUARIOButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.USUARIOButton.Location = new System.Drawing.Point(188, 58);
            this.USUARIOButton.Name = "USUARIOButton";
            this.USUARIOButton.Size = new System.Drawing.Size(23, 23);
            this.USUARIOButton.TabIndex = 170;
            this.USUARIOButton.UseVisualStyleBackColor = true;
            // 
            // USUARIOLabel
            // 
            this.USUARIOLabel.AutoSize = true;
            this.USUARIOLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.USUARIOLabel.Location = new System.Drawing.Point(215, 64);
            this.USUARIOLabel.Name = "USUARIOLabel";
            this.USUARIOLabel.Size = new System.Drawing.Size(16, 13);
            this.USUARIOLabel.TabIndex = 171;
            this.USUARIOLabel.Text = "...";
            // 
            // cbTodosProveedores
            // 
            this.cbTodosProveedores.AutoSize = true;
            this.cbTodosProveedores.ForeColor = System.Drawing.Color.White;
            this.cbTodosProveedores.Location = new System.Drawing.Point(439, 37);
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
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(25, 38);
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
            this.PERSONAIDTextBox.IndiceCampoValue = 0;
            this.PERSONAIDTextBox.LabelDescription = this.PERSONALabel;
            this.PERSONAIDTextBox.Location = new System.Drawing.Point(100, 32);
            this.PERSONAIDTextBox.MostrarErrores = true;
            this.PERSONAIDTextBox.Name = "PERSONAIDTextBox";
            this.PERSONAIDTextBox.NombreCampoSelector = "clave";
            this.PERSONAIDTextBox.NombreCampoValue = "id";
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
            this.PERSONALabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
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
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "ABONO A PROVEEDORES";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(47, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desde:";
            // 
            // BTEnviar
            // 
            this.BTEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTEnviar.ForeColor = System.Drawing.Color.White;
            this.BTEnviar.Location = new System.Drawing.Point(711, 83);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(75, 23);
            this.BTEnviar.TabIndex = 5;
            this.BTEnviar.Text = "Enviar";
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
            // 
            // DTPFrom
            // 
            this.DTPFrom.Location = new System.Drawing.Point(100, 87);
            this.DTPFrom.Name = "DTPFrom";
            this.DTPFrom.Size = new System.Drawing.Size(200, 20);
            this.DTPFrom.TabIndex = 3;
            // 
            // DTPTo
            // 
            this.DTPTo.Location = new System.Drawing.Point(477, 87);
            this.DTPTo.Name = "DTPTo";
            this.DTPTo.Size = new System.Drawing.Size(200, 20);
            this.DTPTo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(436, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "A:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 112);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(885, 398);
            this.tabControl1.TabIndex = 11;
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
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // WFAbonoProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(885, 510);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFAbonoProveedores";
            this.Text = "Abono a Proveedores";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WFAbonoProveedores_FormClosing);
            this.Load += new System.EventHandler(this.WFAbonoProveedores_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private Tools.TextBoxFB PERSONAIDTextBox;
        private System.Windows.Forms.Button PERSONAButton;
        private System.Windows.Forms.Label PERSONALabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTEnviar;
        private System.Windows.Forms.DateTimePicker DTPFrom;
        private System.Windows.Forms.DateTimePicker DTPTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private FastReport.Preview.PreviewControl previewControl1;
        private Tools.CheckBoxFB cbTodosUsuarios;
        private System.Windows.Forms.Label label5;
        private Tools.TextBoxFB USUARIOIDTextBox;
        private System.Windows.Forms.Button USUARIOButton;
        private System.Windows.Forms.Label USUARIOLabel;
        private Tools.CheckBoxFB cbTodosProveedores;
        private FastReport.Report report1;
    }
}