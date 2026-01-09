namespace iPos.Reportes
{
    partial class WFClienteEstadoCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFClienteEstadoCuenta));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.previewControl1 = new FastReport.Preview.PreviewControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlClientesApartado = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.PERSONAAPARTADOIDTextBox = new iPos.Tools.TextBoxFB();
            this.PERSONAAPARTADOButton = new System.Windows.Forms.Button();
            this.PERSONAAPARTADOLabel = new System.Windows.Forms.Label();
            this.pnlClientes = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.PERSONAIDTextBox = new iPos.Tools.TextBoxFB();
            this.PERSONAButton = new System.Windows.Forms.Button();
            this.PERSONALabel = new System.Windows.Forms.Label();
            this.CBESAPARTADO = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BTEnviar = new System.Windows.Forms.Button();
            this.DTPFrom = new System.Windows.Forms.DateTimePicker();
            this.DTPTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.report1 = new FastReport.Report();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlClientesApartado.SuspendLayout();
            this.pnlClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 171);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(885, 339);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.previewControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(877, 313);
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
            this.previewControl1.Size = new System.Drawing.Size(871, 307);
            this.previewControl1.TabIndex = 0;
            this.previewControl1.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.pnlClientesApartado);
            this.panel1.Controls.Add(this.pnlClientes);
            this.panel1.Controls.Add(this.CBESAPARTADO);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BTEnviar);
            this.panel1.Controls.Add(this.DTPFrom);
            this.panel1.Controls.Add(this.DTPTo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(885, 171);
            this.panel1.TabIndex = 9;
            // 
            // pnlClientesApartado
            // 
            this.pnlClientesApartado.Controls.Add(this.label5);
            this.pnlClientesApartado.Controls.Add(this.PERSONAAPARTADOIDTextBox);
            this.pnlClientesApartado.Controls.Add(this.PERSONAAPARTADOLabel);
            this.pnlClientesApartado.Controls.Add(this.PERSONAAPARTADOButton);
            this.pnlClientesApartado.Enabled = false;
            this.pnlClientesApartado.Location = new System.Drawing.Point(433, 64);
            this.pnlClientesApartado.Name = "pnlClientesApartado";
            this.pnlClientesApartado.Size = new System.Drawing.Size(425, 37);
            this.pnlClientesApartado.TabIndex = 169;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(20, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 167;
            this.label5.Text = "Cliente de apartado:";
            // 
            // PERSONAAPARTADOIDTextBox
            // 
            this.PERSONAAPARTADOIDTextBox.BotonLookUp = this.PERSONAAPARTADOButton;
            this.PERSONAAPARTADOIDTextBox.Condicion = null;
            this.PERSONAAPARTADOIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PERSONAAPARTADOIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PERSONAAPARTADOIDTextBox.DbValue = null;
            this.PERSONAAPARTADOIDTextBox.Format_Expression = null;
            this.PERSONAAPARTADOIDTextBox.IndiceCampoDescripcion = 2;
            this.PERSONAAPARTADOIDTextBox.IndiceCampoSelector = 0;
            this.PERSONAAPARTADOIDTextBox.IndiceCampoValue = 0;
            this.PERSONAAPARTADOIDTextBox.LabelDescription = this.PERSONAAPARTADOLabel;
            this.PERSONAAPARTADOIDTextBox.Location = new System.Drawing.Point(153, 9);
            this.PERSONAAPARTADOIDTextBox.MostrarErrores = true;
            this.PERSONAAPARTADOIDTextBox.Name = "PERSONAAPARTADOIDTextBox";
            this.PERSONAAPARTADOIDTextBox.NombreCampoSelector = "id";
            this.PERSONAAPARTADOIDTextBox.NombreCampoValue = "id";
            this.PERSONAAPARTADOIDTextBox.Query = "select id,nombres,apellidos from personaapartado";
            this.PERSONAAPARTADOIDTextBox.QueryDeSeleccion = "select id,nombres,apellidos from personaapartado where id= @id";
            this.PERSONAAPARTADOIDTextBox.QueryPorDBValue = "select id,nombres,apellidos from personaapartado where id = @id";
            this.PERSONAAPARTADOIDTextBox.Size = new System.Drawing.Size(82, 20);
            this.PERSONAAPARTADOIDTextBox.TabIndex = 163;
            this.PERSONAAPARTADOIDTextBox.Tag = 34;
            this.PERSONAAPARTADOIDTextBox.TextDescription = null;
            this.PERSONAAPARTADOIDTextBox.Titulo = "Clientes de apartado";
            this.PERSONAAPARTADOIDTextBox.ValidarEntrada = true;
            this.PERSONAAPARTADOIDTextBox.ValidationExpression = null;
            // 
            // PERSONAAPARTADOButton
            // 
            this.PERSONAAPARTADOButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.PERSONAAPARTADOButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PERSONAAPARTADOButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PERSONAAPARTADOButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.PERSONAAPARTADOButton.Location = new System.Drawing.Point(241, 9);
            this.PERSONAAPARTADOButton.Name = "PERSONAAPARTADOButton";
            this.PERSONAAPARTADOButton.Size = new System.Drawing.Size(23, 23);
            this.PERSONAAPARTADOButton.TabIndex = 164;
            this.PERSONAAPARTADOButton.UseVisualStyleBackColor = true;
            // 
            // PERSONAAPARTADOLabel
            // 
            this.PERSONAAPARTADOLabel.AutoSize = true;
            this.PERSONAAPARTADOLabel.ForeColor = System.Drawing.Color.White;
            this.PERSONAAPARTADOLabel.Location = new System.Drawing.Point(268, 15);
            this.PERSONAAPARTADOLabel.Name = "PERSONAAPARTADOLabel";
            this.PERSONAAPARTADOLabel.Size = new System.Drawing.Size(16, 13);
            this.PERSONAAPARTADOLabel.TabIndex = 166;
            this.PERSONAAPARTADOLabel.Text = "...";
            // 
            // pnlClientes
            // 
            this.pnlClientes.Controls.Add(this.label4);
            this.pnlClientes.Controls.Add(this.PERSONAIDTextBox);
            this.pnlClientes.Controls.Add(this.PERSONALabel);
            this.pnlClientes.Controls.Add(this.PERSONAButton);
            this.pnlClientes.Location = new System.Drawing.Point(28, 64);
            this.pnlClientes.Name = "pnlClientes";
            this.pnlClientes.Size = new System.Drawing.Size(338, 37);
            this.pnlClientes.TabIndex = 168;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 167;
            this.label4.Text = "Cliente:";
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
            this.PERSONAIDTextBox.Location = new System.Drawing.Point(56, 7);
            this.PERSONAIDTextBox.MostrarErrores = true;
            this.PERSONAIDTextBox.Name = "PERSONAIDTextBox";
            this.PERSONAIDTextBox.NombreCampoSelector = "clave";
            this.PERSONAIDTextBox.NombreCampoValue = "id";
            this.PERSONAIDTextBox.Query = "select id,clave,nombre from persona where tipopersonaid in (50)";
            this.PERSONAIDTextBox.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid in (50) and  clave= @clav" +
    "e";
            this.PERSONAIDTextBox.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid in (50) and  id = @id";
            this.PERSONAIDTextBox.Size = new System.Drawing.Size(82, 20);
            this.PERSONAIDTextBox.TabIndex = 163;
            this.PERSONAIDTextBox.Tag = 34;
            this.PERSONAIDTextBox.TextDescription = null;
            this.PERSONAIDTextBox.Titulo = "Clientes";
            this.PERSONAIDTextBox.ValidarEntrada = true;
            this.PERSONAIDTextBox.ValidationExpression = null;
            // 
            // PERSONAButton
            // 
            this.PERSONAButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.PERSONAButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PERSONAButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PERSONAButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.PERSONAButton.Location = new System.Drawing.Point(142, 7);
            this.PERSONAButton.Name = "PERSONAButton";
            this.PERSONAButton.Size = new System.Drawing.Size(23, 23);
            this.PERSONAButton.TabIndex = 164;
            this.PERSONAButton.UseVisualStyleBackColor = true;
            // 
            // PERSONALabel
            // 
            this.PERSONALabel.AutoSize = true;
            this.PERSONALabel.ForeColor = System.Drawing.Color.White;
            this.PERSONALabel.Location = new System.Drawing.Point(171, 13);
            this.PERSONALabel.Name = "PERSONALabel";
            this.PERSONALabel.Size = new System.Drawing.Size(16, 13);
            this.PERSONALabel.TabIndex = 166;
            this.PERSONALabel.Text = "...";
            // 
            // CBESAPARTADO
            // 
            this.CBESAPARTADO.AutoSize = true;
            this.CBESAPARTADO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBESAPARTADO.ForeColor = System.Drawing.Color.White;
            this.CBESAPARTADO.Location = new System.Drawing.Point(34, 41);
            this.CBESAPARTADO.Name = "CBESAPARTADO";
            this.CBESAPARTADO.Size = new System.Drawing.Size(150, 17);
            this.CBESAPARTADO.TabIndex = 165;
            this.CBESAPARTADO.Text = "Clientes de apartado?";
            this.CBESAPARTADO.UseVisualStyleBackColor = true;
            this.CBESAPARTADO.CheckedChanged += new System.EventHandler(this.CBESAPARTADO_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "ESTADO DE CUENTA DEL CLIENTE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(31, 118);
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
            this.BTEnviar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BTEnviar.Location = new System.Drawing.Point(706, 113);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(75, 23);
            this.BTEnviar.TabIndex = 5;
            this.BTEnviar.Text = "Enviar";
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
            // 
            // DTPFrom
            // 
            this.DTPFrom.Location = new System.Drawing.Point(84, 114);
            this.DTPFrom.Name = "DTPFrom";
            this.DTPFrom.Size = new System.Drawing.Size(200, 20);
            this.DTPFrom.TabIndex = 3;
            // 
            // DTPTo
            // 
            this.DTPTo.Location = new System.Drawing.Point(477, 114);
            this.DTPTo.Name = "DTPTo";
            this.DTPTo.Size = new System.Drawing.Size(200, 20);
            this.DTPTo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(453, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "A:";
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // WFClienteEstadoCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(885, 510);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFClienteEstadoCuenta";
            this.Text = "Estado de Cuenta de Cliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WFClienteEstadoCuenta_FormClosing);
            this.Load += new System.EventHandler(this.WFClienteEstadoCuenta_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlClientesApartado.ResumeLayout(false);
            this.pnlClientesApartado.PerformLayout();
            this.pnlClientes.ResumeLayout(false);
            this.pnlClientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTEnviar;
        private System.Windows.Forms.DateTimePicker DTPFrom;
        private System.Windows.Forms.DateTimePicker DTPTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label PERSONALabel;
        private System.Windows.Forms.Button PERSONAButton;
        private Tools.TextBoxFB PERSONAIDTextBox;
        private FastReport.Preview.PreviewControl previewControl1;
        private FastReport.Report report1;
        private System.Windows.Forms.Panel pnlClientesApartado;
        private System.Windows.Forms.Label label5;
        private Tools.TextBoxFB PERSONAAPARTADOIDTextBox;
        private System.Windows.Forms.Button PERSONAAPARTADOButton;
        private System.Windows.Forms.Label PERSONAAPARTADOLabel;
        private System.Windows.Forms.Panel pnlClientes;
        private System.Windows.Forms.CheckBox CBESAPARTADO;
    }
}