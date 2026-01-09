namespace iPos.Reportes.Entradas
{
    partial class WFFaltantesOrdenesCompraConHistorial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFFaltantesOrdenesCompraConHistorial));
            this.BTEnviar = new System.Windows.Forms.Button();
            this.PERSONAIDTextBox = new iPos.Tools.TextBoxFB();
            this.PERSONAButton = new System.Windows.Forms.Button();
            this.PERSONALabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CBTodos = new System.Windows.Forms.CheckBox();
            this.report1 = new FastReport.Report();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.previewControl1 = new FastReport.Preview.PreviewControl();
            this.DTPFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DTPTo = new System.Windows.Forms.DateTimePicker();
            this.CBTraslados = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTEnviar
            // 
            this.BTEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTEnviar.ForeColor = System.Drawing.Color.White;
            this.BTEnviar.Location = new System.Drawing.Point(737, 50);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(75, 23);
            this.BTEnviar.TabIndex = 174;
            this.BTEnviar.Text = "Enviar";
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
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
            this.PERSONAIDTextBox.Location = new System.Drawing.Point(136, 11);
            this.PERSONAIDTextBox.MostrarErrores = true;
            this.PERSONAIDTextBox.Name = "PERSONAIDTextBox";
            this.PERSONAIDTextBox.NombreCampoSelector = "clave";
            this.PERSONAIDTextBox.NombreCampoValue = "id";
            this.PERSONAIDTextBox.Query = "select id,clave,nombre from persona where tipopersonaid in (40)";
            this.PERSONAIDTextBox.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid in (40) and  clave= @clav" +
    "e";
            this.PERSONAIDTextBox.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid in (40) and  id = @id";
            this.PERSONAIDTextBox.Size = new System.Drawing.Size(82, 20);
            this.PERSONAIDTextBox.TabIndex = 175;
            this.PERSONAIDTextBox.Tag = 34;
            this.PERSONAIDTextBox.TextDescription = null;
            this.PERSONAIDTextBox.Titulo = "Proveedores";
            this.PERSONAIDTextBox.ValidarEntrada = true;
            this.PERSONAIDTextBox.ValidationExpression = null;
            // 
            // PERSONAButton
            // 
            this.PERSONAButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.PERSONAButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PERSONAButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PERSONAButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.PERSONAButton.Location = new System.Drawing.Point(224, 9);
            this.PERSONAButton.Name = "PERSONAButton";
            this.PERSONAButton.Size = new System.Drawing.Size(23, 23);
            this.PERSONAButton.TabIndex = 186;
            this.PERSONAButton.UseVisualStyleBackColor = true;
            // 
            // PERSONALabel
            // 
            this.PERSONALabel.AutoSize = true;
            this.PERSONALabel.BackColor = System.Drawing.Color.Transparent;
            this.PERSONALabel.ForeColor = System.Drawing.Color.White;
            this.PERSONALabel.Location = new System.Drawing.Point(325, 18);
            this.PERSONALabel.Name = "PERSONALabel";
            this.PERSONALabel.Size = new System.Drawing.Size(16, 13);
            this.PERSONALabel.TabIndex = 177;
            this.PERSONALabel.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(61, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 178;
            this.label4.Text = "Proveedor:";
            // 
            // CBTodos
            // 
            this.CBTodos.AutoSize = true;
            this.CBTodos.BackColor = System.Drawing.Color.Transparent;
            this.CBTodos.ForeColor = System.Drawing.Color.White;
            this.CBTodos.Location = new System.Drawing.Point(263, 15);
            this.CBTodos.Name = "CBTodos";
            this.CBTodos.Size = new System.Drawing.Size(56, 17);
            this.CBTodos.TabIndex = 179;
            this.CBTodos.Text = "Todos";
            this.CBTodos.UseVisualStyleBackColor = false;
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(864, 336);
            this.tabControl1.TabIndex = 180;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.previewControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(856, 310);
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
            this.previewControl1.Size = new System.Drawing.Size(850, 304);
            this.previewControl1.TabIndex = 0;
            this.previewControl1.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // DTPFrom
            // 
            this.DTPFrom.Location = new System.Drawing.Point(114, 55);
            this.DTPFrom.Name = "DTPFrom";
            this.DTPFrom.Size = new System.Drawing.Size(200, 20);
            this.DTPFrom.TabIndex = 181;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(61, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 182;
            this.label1.Text = "Desde:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(337, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 183;
            this.label2.Text = "Hasta:";
            // 
            // DTPTo
            // 
            this.DTPTo.Location = new System.Drawing.Point(387, 55);
            this.DTPTo.Name = "DTPTo";
            this.DTPTo.Size = new System.Drawing.Size(200, 20);
            this.DTPTo.TabIndex = 184;
            // 
            // CBTraslados
            // 
            this.CBTraslados.AutoSize = true;
            this.CBTraslados.BackColor = System.Drawing.Color.Transparent;
            this.CBTraslados.ForeColor = System.Drawing.Color.White;
            this.CBTraslados.Location = new System.Drawing.Point(617, 58);
            this.CBTraslados.Name = "CBTraslados";
            this.CBTraslados.Size = new System.Drawing.Size(99, 17);
            this.CBTraslados.TabIndex = 185;
            this.CBTraslados.Text = "Incluir traslados";
            this.CBTraslados.UseVisualStyleBackColor = false;
            this.CBTraslados.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.PERSONAButton);
            this.panel1.Controls.Add(this.BTEnviar);
            this.panel1.Controls.Add(this.CBTraslados);
            this.panel1.Controls.Add(this.PERSONAIDTextBox);
            this.panel1.Controls.Add(this.DTPTo);
            this.panel1.Controls.Add(this.PERSONALabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.CBTodos);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.DTPFrom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 89);
            this.panel1.TabIndex = 187;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 89);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(864, 336);
            this.panel2.TabIndex = 188;
            // 
            // WFFaltantesOrdenesCompraConHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(864, 425);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFFaltantesOrdenesCompraConHistorial";
            this.Text = "Reporte de faltantes de ordenes de compra con historial";
            this.Load += new System.EventHandler(this.WFFaltantesOrdenesCompraConHistorial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTEnviar;
        private Tools.TextBoxFB PERSONAIDTextBox;
        private System.Windows.Forms.Label PERSONALabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox CBTodos;
        private FastReport.Report report1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private FastReport.Preview.PreviewControl previewControl1;
        private System.Windows.Forms.DateTimePicker DTPFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DTPTo;
        private System.Windows.Forms.CheckBox CBTraslados;
        private System.Windows.Forms.Button PERSONAButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;

    }
}