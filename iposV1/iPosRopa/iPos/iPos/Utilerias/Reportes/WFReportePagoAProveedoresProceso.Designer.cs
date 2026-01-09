namespace iPos.Utilerias
{
    partial class WFReportePagoAProveedoresProceso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFReportePagoAProveedoresProceso));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CheckBoxTodosClientes = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.CheckBoxSelectCliente = new System.Windows.Forms.CheckBox();
            this.CheckBoxSelectProveedor = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ButtonProveedores = new System.Windows.Forms.Button();
            this.ProveedoresLabel = new System.Windows.Forms.Label();
            this.TextBoxProveedor = new iPos.Tools.TextBoxFB();
            this.ButtonClientes = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.LabelClientes = new System.Windows.Forms.Label();
            this.TextBoxCliente = new iPos.Tools.TextBoxFB();
            this.CheckBoxTodosProveedores = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LabelDesde = new System.Windows.Forms.Label();
            this.BTEnviar = new System.Windows.Forms.Button();
            this.DTPFrom = new System.Windows.Forms.DateTimePicker();
            this.DTPTo = new System.Windows.Forms.DateTimePicker();
            this.LabelA = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.previewControl1 = new FastReport.Preview.PreviewControl();
            this.report1 = new FastReport.Report();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.CheckBoxTodosClientes);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.CheckBoxTodosProveedores);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.LabelDesde);
            this.panel1.Controls.Add(this.BTEnviar);
            this.panel1.Controls.Add(this.DTPFrom);
            this.panel1.Controls.Add(this.DTPTo);
            this.panel1.Controls.Add(this.LabelA);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(840, 167);
            this.panel1.TabIndex = 10;
            // 
            // CheckBoxTodosClientes
            // 
            this.CheckBoxTodosClientes.AutoSize = true;
            this.CheckBoxTodosClientes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CheckBoxTodosClientes.Location = new System.Drawing.Point(646, 121);
            this.CheckBoxTodosClientes.Name = "CheckBoxTodosClientes";
            this.CheckBoxTodosClientes.Size = new System.Drawing.Size(56, 17);
            this.CheckBoxTodosClientes.TabIndex = 180;
            this.CheckBoxTodosClientes.Text = "Todos";
            this.CheckBoxTodosClientes.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.CheckBoxSelectCliente);
            this.panel3.Controls.Add(this.CheckBoxSelectProveedor);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.ButtonProveedores);
            this.panel3.Controls.Add(this.ProveedoresLabel);
            this.panel3.Controls.Add(this.TextBoxProveedor);
            this.panel3.Controls.Add(this.ButtonClientes);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.LabelClientes);
            this.panel3.Controls.Add(this.TextBoxCliente);
            this.panel3.Location = new System.Drawing.Point(34, 69);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(578, 85);
            this.panel3.TabIndex = 179;
            // 
            // CheckBoxSelectCliente
            // 
            this.CheckBoxSelectCliente.AutoSize = true;
            this.CheckBoxSelectCliente.Location = new System.Drawing.Point(6, 56);
            this.CheckBoxSelectCliente.Name = "CheckBoxSelectCliente";
            this.CheckBoxSelectCliente.Size = new System.Drawing.Size(15, 14);
            this.CheckBoxSelectCliente.TabIndex = 180;
            this.CheckBoxSelectCliente.UseVisualStyleBackColor = true;
            // 
            // CheckBoxSelectProveedor
            // 
            this.CheckBoxSelectProveedor.AutoSize = true;
            this.CheckBoxSelectProveedor.Location = new System.Drawing.Point(6, 9);
            this.CheckBoxSelectProveedor.Name = "CheckBoxSelectProveedor";
            this.CheckBoxSelectProveedor.Size = new System.Drawing.Size(15, 14);
            this.CheckBoxSelectProveedor.TabIndex = 179;
            this.CheckBoxSelectProveedor.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(23, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 167;
            this.label4.Text = "Proveedor:";
            // 
            // ButtonProveedores
            // 
            this.ButtonProveedores.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonProveedores.BackgroundImage")));
            this.ButtonProveedores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonProveedores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ButtonProveedores.Location = new System.Drawing.Point(201, 4);
            this.ButtonProveedores.Name = "ButtonProveedores";
            this.ButtonProveedores.Size = new System.Drawing.Size(23, 23);
            this.ButtonProveedores.TabIndex = 164;
            this.ButtonProveedores.UseVisualStyleBackColor = true;
            // 
            // ProveedoresLabel
            // 
            this.ProveedoresLabel.AutoSize = true;
            this.ProveedoresLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ProveedoresLabel.Location = new System.Drawing.Point(230, 10);
            this.ProveedoresLabel.Name = "ProveedoresLabel";
            this.ProveedoresLabel.Size = new System.Drawing.Size(16, 13);
            this.ProveedoresLabel.TabIndex = 166;
            this.ProveedoresLabel.Text = "...";
            // 
            // TextBoxProveedor
            // 
            this.TextBoxProveedor.BotonLookUp = this.ButtonProveedores;
            this.TextBoxProveedor.Condicion = null;
            this.TextBoxProveedor.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.TextBoxProveedor.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.TextBoxProveedor.DbValue = null;
            this.TextBoxProveedor.Format_Expression = null;
            this.TextBoxProveedor.IndiceCampoDescripcion = 2;
            this.TextBoxProveedor.IndiceCampoSelector = 1;
            this.TextBoxProveedor.IndiceCampoValue = 0;
            this.TextBoxProveedor.LabelDescription = this.ProveedoresLabel;
            this.TextBoxProveedor.Location = new System.Drawing.Point(113, 7);
            this.TextBoxProveedor.MostrarErrores = true;
            this.TextBoxProveedor.Name = "TextBoxProveedor";
            this.TextBoxProveedor.NombreCampoSelector = "clave";
            this.TextBoxProveedor.NombreCampoValue = "id";
            this.TextBoxProveedor.Query = "select id,clave,nombre from persona where tipopersonaid in (40)";
            this.TextBoxProveedor.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid in (40) and  clave= @clav" +
    "e";
            this.TextBoxProveedor.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid in (40) and  id = @id";
            this.TextBoxProveedor.Size = new System.Drawing.Size(82, 20);
            this.TextBoxProveedor.TabIndex = 163;
            this.TextBoxProveedor.Tag = 34;
            this.TextBoxProveedor.TextDescription = null;
            this.TextBoxProveedor.Titulo = "Proveedores";
            this.TextBoxProveedor.ValidarEntrada = true;
            this.TextBoxProveedor.ValidationExpression = null;
            // 
            // ButtonClientes
            // 
            this.ButtonClientes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonClientes.BackgroundImage")));
            this.ButtonClientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.ButtonClientes.Location = new System.Drawing.Point(201, 49);
            this.ButtonClientes.Name = "ButtonClientes";
            this.ButtonClientes.Size = new System.Drawing.Size(23, 23);
            this.ButtonClientes.TabIndex = 170;
            this.ButtonClientes.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(23, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 172;
            this.label5.Text = "Cliente:";
            // 
            // LabelClientes
            // 
            this.LabelClientes.AutoSize = true;
            this.LabelClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LabelClientes.Location = new System.Drawing.Point(230, 56);
            this.LabelClientes.Name = "LabelClientes";
            this.LabelClientes.Size = new System.Drawing.Size(16, 13);
            this.LabelClientes.TabIndex = 171;
            this.LabelClientes.Text = "...";
            // 
            // TextBoxCliente
            // 
            this.TextBoxCliente.BotonLookUp = this.ButtonClientes;
            this.TextBoxCliente.Condicion = null;
            this.TextBoxCliente.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.TextBoxCliente.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.TextBoxCliente.DbValue = null;
            this.TextBoxCliente.Format_Expression = null;
            this.TextBoxCliente.IndiceCampoDescripcion = 2;
            this.TextBoxCliente.IndiceCampoSelector = 1;
            this.TextBoxCliente.IndiceCampoValue = 0;
            this.TextBoxCliente.LabelDescription = this.LabelClientes;
            this.TextBoxCliente.Location = new System.Drawing.Point(113, 52);
            this.TextBoxCliente.MostrarErrores = true;
            this.TextBoxCliente.Name = "TextBoxCliente";
            this.TextBoxCliente.NombreCampoSelector = "clave";
            this.TextBoxCliente.NombreCampoValue = "id";
            this.TextBoxCliente.Query = "select id,clave,nombre from persona where tipopersonaid in (50)";
            this.TextBoxCliente.QueryDeSeleccion = "select id,clave,nombre from persona where tipopersonaid in (50) and  clave= @clav" +
    "e";
            this.TextBoxCliente.QueryPorDBValue = "select id,clave,nombre from persona where tipopersonaid in (50) and  id = @id";
            this.TextBoxCliente.Size = new System.Drawing.Size(82, 20);
            this.TextBoxCliente.TabIndex = 169;
            this.TextBoxCliente.Tag = 34;
            this.TextBoxCliente.TextDescription = null;
            this.TextBoxCliente.Titulo = "Clientes";
            this.TextBoxCliente.ValidarEntrada = true;
            this.TextBoxCliente.ValidationExpression = null;
            // 
            // CheckBoxTodosProveedores
            // 
            this.CheckBoxTodosProveedores.AutoSize = true;
            this.CheckBoxTodosProveedores.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CheckBoxTodosProveedores.Location = new System.Drawing.Point(646, 77);
            this.CheckBoxTodosProveedores.Name = "CheckBoxTodosProveedores";
            this.CheckBoxTodosProveedores.Size = new System.Drawing.Size(56, 17);
            this.CheckBoxTodosProveedores.TabIndex = 172;
            this.CheckBoxTodosProveedores.Text = "Todos";
            this.CheckBoxTodosProveedores.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(251, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(243, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "PAGO A PROVEEDORES POR PROCESO";
            // 
            // LabelDesde
            // 
            this.LabelDesde.AutoSize = true;
            this.LabelDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelDesde.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LabelDesde.Location = new System.Drawing.Point(37, 46);
            this.LabelDesde.Name = "LabelDesde";
            this.LabelDesde.Size = new System.Drawing.Size(47, 13);
            this.LabelDesde.TabIndex = 1;
            this.LabelDesde.Text = "Desde:";
            // 
            // BTEnviar
            // 
            this.BTEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.BTEnviar.ForeColor = System.Drawing.Color.White;
            this.BTEnviar.Location = new System.Drawing.Point(646, 37);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(75, 25);
            this.BTEnviar.TabIndex = 7;
            this.BTEnviar.Text = "Enviar";
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
            // 
            // DTPFrom
            // 
            this.DTPFrom.Location = new System.Drawing.Point(98, 43);
            this.DTPFrom.Name = "DTPFrom";
            this.DTPFrom.Size = new System.Drawing.Size(200, 20);
            this.DTPFrom.TabIndex = 5;
            // 
            // DTPTo
            // 
            this.DTPTo.Location = new System.Drawing.Point(412, 43);
            this.DTPTo.Name = "DTPTo";
            this.DTPTo.Size = new System.Drawing.Size(200, 20);
            this.DTPTo.TabIndex = 6;
            // 
            // LabelA
            // 
            this.LabelA.AutoSize = true;
            this.LabelA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LabelA.Location = new System.Drawing.Point(376, 46);
            this.LabelA.Name = "LabelA";
            this.LabelA.Size = new System.Drawing.Size(19, 13);
            this.LabelA.TabIndex = 3;
            this.LabelA.Text = "A:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.previewControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 167);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(840, 394);
            this.panel2.TabIndex = 11;
            // 
            // previewControl1
            // 
            this.previewControl1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.previewControl1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.previewControl1.Location = new System.Drawing.Point(0, 0);
            this.previewControl1.Name = "previewControl1";
            this.previewControl1.PageOffset = new System.Drawing.Point(10, 10);
            this.previewControl1.Size = new System.Drawing.Size(840, 394);
            this.previewControl1.TabIndex = 1;
            this.previewControl1.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // WFReportePagoAProveedoresProceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(840, 561);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFReportePagoAProveedoresProceso";
            this.Text = "Reporte Pago a Proveedores por Procesoo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WFReportePagoAProveedoresProceso_FormClosing);
            this.Load += new System.EventHandler(this.WFReportePagoAProveedoresProceso_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LabelDesde;
        private System.Windows.Forms.Button BTEnviar;
        private System.Windows.Forms.DateTimePicker DTPFrom;
        private System.Windows.Forms.DateTimePicker DTPTo;
        private System.Windows.Forms.Label LabelA;
        private System.Windows.Forms.Panel panel2;
        private FastReport.Preview.PreviewControl previewControl1;
        private System.Windows.Forms.CheckBox CheckBoxTodosProveedores;
        private System.Windows.Forms.CheckBox CheckBoxTodosClientes;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox CheckBoxSelectCliente;
        private System.Windows.Forms.CheckBox CheckBoxSelectProveedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ButtonProveedores;
        private System.Windows.Forms.Label ProveedoresLabel;
        private Tools.TextBoxFB TextBoxProveedor;
        private System.Windows.Forms.Button ButtonClientes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LabelClientes;
        private Tools.TextBoxFB TextBoxCliente;
        private FastReport.Report report1;
    }
}