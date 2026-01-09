namespace iPos.Reportes.Ventas
{
    partial class WFReporteDeVentasXRuta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFReporteDeVentasXRuta));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.previewControl1 = new FastReport.Preview.PreviewControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEsFactura = new System.Windows.Forms.Label();
            this.CBEsFactura = new System.Windows.Forms.ComboBox();
            this.CBRutasTodas = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CBEstatusVenta = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CBTipoVenta = new System.Windows.Forms.ComboBox();
            this.LBRutaNombre = new System.Windows.Forms.Label();
            this.BTRutaEmbarque = new System.Windows.Forms.Button();
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
            this.tabControl1.TabIndex = 12;
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
            this.panel1.Controls.Add(this.lblEsFactura);
            this.panel1.Controls.Add(this.CBEsFactura);
            this.panel1.Controls.Add(this.CBRutasTodas);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.CBEstatusVenta);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.CBTipoVenta);
            this.panel1.Controls.Add(this.LBRutaNombre);
            this.panel1.Controls.Add(this.BTRutaEmbarque);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BTEnviar);
            this.panel1.Controls.Add(this.DTPFrom);
            this.panel1.Controls.Add(this.DTPTo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(885, 109);
            this.panel1.TabIndex = 11;
            // 
            // lblEsFactura
            // 
            this.lblEsFactura.AutoSize = true;
            this.lblEsFactura.Enabled = false;
            this.lblEsFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEsFactura.ForeColor = System.Drawing.Color.White;
            this.lblEsFactura.Location = new System.Drawing.Point(699, 23);
            this.lblEsFactura.Name = "lblEsFactura";
            this.lblEsFactura.Size = new System.Drawing.Size(65, 13);
            this.lblEsFactura.TabIndex = 182;
            this.lblEsFactura.Text = "Es factura";
            this.lblEsFactura.Visible = false;
            // 
            // CBEsFactura
            // 
            this.CBEsFactura.AccessibleDescription = "resizeforscreen";
            this.CBEsFactura.Enabled = false;
            this.CBEsFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBEsFactura.FormattingEnabled = true;
            this.CBEsFactura.Items.AddRange(new object[] {
            "FACTURA",
            "REMISION",
            "TODOS"});
            this.CBEsFactura.Location = new System.Drawing.Point(702, 48);
            this.CBEsFactura.Name = "CBEsFactura";
            this.CBEsFactura.Size = new System.Drawing.Size(132, 21);
            this.CBEsFactura.TabIndex = 181;
            // 
            // CBRutasTodas
            // 
            this.CBRutasTodas.AutoSize = true;
            this.CBRutasTodas.ForeColor = System.Drawing.Color.White;
            this.CBRutasTodas.Location = new System.Drawing.Point(535, 22);
            this.CBRutasTodas.Name = "CBRutasTodas";
            this.CBRutasTodas.Size = new System.Drawing.Size(103, 17);
            this.CBRutasTodas.TabIndex = 180;
            this.CBRutasTodas.Text = "Todas las Rutas";
            this.CBRutasTodas.UseVisualStyleBackColor = true;
            this.CBRutasTodas.CheckedChanged += new System.EventHandler(this.CBRutasTodas_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(421, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 179;
            this.label5.Text = "Estatus de Venta:";
            // 
            // CBEstatusVenta
            // 
            this.CBEstatusVenta.AccessibleDescription = "resizeforscreen";
            this.CBEstatusVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBEstatusVenta.FormattingEnabled = true;
            this.CBEstatusVenta.Items.AddRange(new object[] {
            "COMPLETAS",
            "PENDIENTES",
            "TODOS"});
            this.CBEstatusVenta.Location = new System.Drawing.Point(535, 84);
            this.CBEstatusVenta.Name = "CBEstatusVenta";
            this.CBEstatusVenta.Size = new System.Drawing.Size(132, 21);
            this.CBEstatusVenta.TabIndex = 178;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(422, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 177;
            this.label4.Text = "Tipo de Venta:";
            // 
            // CBTipoVenta
            // 
            this.CBTipoVenta.AccessibleDescription = "resizeforscreen";
            this.CBTipoVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBTipoVenta.FormattingEnabled = true;
            this.CBTipoVenta.Items.AddRange(new object[] {
            "VENTAS",
            "VENTAS A FUTURO",
            "TODOS"});
            this.CBTipoVenta.Location = new System.Drawing.Point(535, 48);
            this.CBTipoVenta.Name = "CBTipoVenta";
            this.CBTipoVenta.Size = new System.Drawing.Size(132, 21);
            this.CBTipoVenta.TabIndex = 176;
            this.CBTipoVenta.SelectedIndexChanged += new System.EventHandler(this.CBTipoVenta_SelectedIndexChanged);
            // 
            // LBRutaNombre
            // 
            this.LBRutaNombre.AutoSize = true;
            this.LBRutaNombre.BackColor = System.Drawing.Color.Transparent;
            this.LBRutaNombre.Enabled = false;
            this.LBRutaNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBRutaNombre.ForeColor = System.Drawing.Color.White;
            this.LBRutaNombre.Location = new System.Drawing.Point(263, 22);
            this.LBRutaNombre.Name = "LBRutaNombre";
            this.LBRutaNombre.Size = new System.Drawing.Size(21, 20);
            this.LBRutaNombre.TabIndex = 175;
            this.LBRutaNombre.Text = "...";
            // 
            // BTRutaEmbarque
            // 
            this.BTRutaEmbarque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTRutaEmbarque.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTRutaEmbarque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTRutaEmbarque.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTRutaEmbarque.ForeColor = System.Drawing.Color.White;
            this.BTRutaEmbarque.Location = new System.Drawing.Point(195, 15);
            this.BTRutaEmbarque.Name = "BTRutaEmbarque";
            this.BTRutaEmbarque.Size = new System.Drawing.Size(54, 27);
            this.BTRutaEmbarque.TabIndex = 174;
            this.BTRutaEmbarque.Text = "Ruta";
            this.BTRutaEmbarque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTRutaEmbarque.UseVisualStyleBackColor = false;
            this.BTRutaEmbarque.Click += new System.EventHandler(this.BTRutaEmbarque_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ventas Por Ruta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(125, 48);
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
            this.BTEnviar.Location = new System.Drawing.Point(702, 82);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(75, 23);
            this.BTEnviar.TabIndex = 6;
            this.BTEnviar.Text = "Enviar";
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
            // 
            // DTPFrom
            // 
            this.DTPFrom.Location = new System.Drawing.Point(195, 48);
            this.DTPFrom.Name = "DTPFrom";
            this.DTPFrom.Size = new System.Drawing.Size(200, 20);
            this.DTPFrom.TabIndex = 4;
            // 
            // DTPTo
            // 
            this.DTPTo.Location = new System.Drawing.Point(195, 81);
            this.DTPTo.Name = "DTPTo";
            this.DTPTo.Size = new System.Drawing.Size(200, 20);
            this.DTPTo.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(154, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "A:";
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // WFReporteDeVentasXRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(885, 510);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFReporteDeVentasXRuta";
            this.Text = "Reporte De Ventas Por Ruta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WFReporteDeVentasXRuta_FormClosing);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTEnviar;
        private System.Windows.Forms.DateTimePicker DTPFrom;
        private System.Windows.Forms.DateTimePicker DTPTo;
        private System.Windows.Forms.Label label2;
        private FastReport.Report report1;
        private System.Windows.Forms.Label LBRutaNombre;
        private System.Windows.Forms.Button BTRutaEmbarque;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CBTipoVenta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CBEstatusVenta;
        private System.Windows.Forms.CheckBox CBRutasTodas;
        private System.Windows.Forms.Label lblEsFactura;
        private System.Windows.Forms.ComboBox CBEsFactura;
    }
}