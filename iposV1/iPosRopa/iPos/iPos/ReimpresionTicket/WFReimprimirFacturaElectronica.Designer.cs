namespace iPos
{
    partial class WFReimprimirFacturaElectronica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFReimprimirFacturaElectronica));
            this.LBTipo = new System.Windows.Forms.Label();
            this.CBTipoTran = new System.Windows.Forms.ComboBox();
            this.BTReImprimir = new System.Windows.Forms.Button();
            this.BTSeleccionar = new System.Windows.Forms.Button();
            this.RBPorTransaccion = new System.Windows.Forms.Label();
            this.TBFolio = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBSerieSAT = new System.Windows.Forms.TextBox();
            this.RBPorFactura = new System.Windows.Forms.RadioButton();
            this.BTSeleccionarFE = new System.Windows.Forms.Button();
            this.TBFolioSAT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RBPorTrans = new System.Windows.Forms.RadioButton();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LBTipo
            // 
            this.LBTipo.AutoSize = true;
            this.LBTipo.BackColor = System.Drawing.Color.Transparent;
            this.LBTipo.ForeColor = System.Drawing.Color.White;
            this.LBTipo.Location = new System.Drawing.Point(59, 56);
            this.LBTipo.Name = "LBTipo";
            this.LBTipo.Size = new System.Drawing.Size(31, 13);
            this.LBTipo.TabIndex = 2;
            this.LBTipo.Text = "Tipo:";
            // 
            // CBTipoTran
            // 
            this.CBTipoTran.FormattingEnabled = true;
            this.CBTipoTran.Items.AddRange(new object[] {
            "Venta",
            "Devolucion"});
            this.CBTipoTran.Location = new System.Drawing.Point(93, 53);
            this.CBTipoTran.Name = "CBTipoTran";
            this.CBTipoTran.Size = new System.Drawing.Size(233, 21);
            this.CBTipoTran.TabIndex = 1;
            // 
            // BTReImprimir
            // 
            this.BTReImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTReImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTReImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTReImprimir.ForeColor = System.Drawing.Color.White;
            this.BTReImprimir.Image = global::iPos.Properties.Resources.printNoBack_J;
            this.BTReImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTReImprimir.Location = new System.Drawing.Point(642, 121);
            this.BTReImprimir.Name = "BTReImprimir";
            this.BTReImprimir.Size = new System.Drawing.Size(147, 32);
            this.BTReImprimir.TabIndex = 4;
            this.BTReImprimir.Text = "Reimprimir factura";
            this.BTReImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTReImprimir.UseVisualStyleBackColor = false;
            this.BTReImprimir.Click += new System.EventHandler(this.BTReImprimir_Click);
            // 
            // BTSeleccionar
            // 
            this.BTSeleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTSeleccionar.Enabled = false;
            this.BTSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTSeleccionar.ForeColor = System.Drawing.Color.White;
            this.BTSeleccionar.Location = new System.Drawing.Point(275, 11);
            this.BTSeleccionar.Name = "BTSeleccionar";
            this.BTSeleccionar.Size = new System.Drawing.Size(34, 23);
            this.BTSeleccionar.TabIndex = 3;
            this.BTSeleccionar.Text = "...";
            this.BTSeleccionar.UseVisualStyleBackColor = false;
            this.BTSeleccionar.Click += new System.EventHandler(this.BTSeleccionar_Click);
            // 
            // RBPorTransaccion
            // 
            this.RBPorTransaccion.AutoSize = true;
            this.RBPorTransaccion.ForeColor = System.Drawing.Color.White;
            this.RBPorTransaccion.Location = new System.Drawing.Point(42, 16);
            this.RBPorTransaccion.Name = "RBPorTransaccion";
            this.RBPorTransaccion.Size = new System.Drawing.Size(94, 13);
            this.RBPorTransaccion.TabIndex = 1;
            this.RBPorTransaccion.Text = "Transacción - folio";
            // 
            // TBFolio
            // 
            this.TBFolio.Enabled = false;
            this.TBFolio.Location = new System.Drawing.Point(176, 13);
            this.TBFolio.Name = "TBFolio";
            this.TBFolio.Size = new System.Drawing.Size(93, 20);
            this.TBFolio.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.TBSerieSAT);
            this.groupBox2.Controls.Add(this.RBPorFactura);
            this.groupBox2.Controls.Add(this.BTSeleccionarFE);
            this.groupBox2.Controls.Add(this.TBFolioSAT);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.RBPorTrans);
            this.groupBox2.Controls.Add(this.BTSeleccionar);
            this.groupBox2.Controls.Add(this.TBFolio);
            this.groupBox2.Controls.Add(this.RBPorTransaccion);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox2.Location = new System.Drawing.Point(353, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(540, 68);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(313, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Folio:";
            // 
            // TBSerieSAT
            // 
            this.TBSerieSAT.Location = new System.Drawing.Point(177, 41);
            this.TBSerieSAT.Name = "TBSerieSAT";
            this.TBSerieSAT.Size = new System.Drawing.Size(92, 20);
            this.TBSerieSAT.TabIndex = 9;
            // 
            // RBPorFactura
            // 
            this.RBPorFactura.AutoSize = true;
            this.RBPorFactura.Checked = true;
            this.RBPorFactura.Location = new System.Drawing.Point(22, 40);
            this.RBPorFactura.Name = "RBPorFactura";
            this.RBPorFactura.Size = new System.Drawing.Size(14, 13);
            this.RBPorFactura.TabIndex = 8;
            this.RBPorFactura.TabStop = true;
            this.RBPorFactura.UseVisualStyleBackColor = true;
            this.RBPorFactura.CheckedChanged += new System.EventHandler(this.RBPorFactura_CheckedChanged);
            // 
            // BTSeleccionarFE
            // 
            this.BTSeleccionarFE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTSeleccionarFE.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTSeleccionarFE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTSeleccionarFE.ForeColor = System.Drawing.Color.White;
            this.BTSeleccionarFE.Location = new System.Drawing.Point(460, 38);
            this.BTSeleccionarFE.Name = "BTSeleccionarFE";
            this.BTSeleccionarFE.Size = new System.Drawing.Size(34, 23);
            this.BTSeleccionarFE.TabIndex = 7;
            this.BTSeleccionarFE.Text = "...";
            this.BTSeleccionarFE.UseVisualStyleBackColor = false;
            this.BTSeleccionarFE.Click += new System.EventHandler(this.BTSeleccionarFE_Click);
            // 
            // TBFolioSAT
            // 
            this.TBFolioSAT.Location = new System.Drawing.Point(345, 40);
            this.TBFolioSAT.Name = "TBFolioSAT";
            this.TBFolioSAT.Size = new System.Drawing.Size(109, 20);
            this.TBFolioSAT.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(42, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Factura electronica - serie";
            // 
            // RBPorTrans
            // 
            this.RBPorTrans.AutoSize = true;
            this.RBPorTrans.Location = new System.Drawing.Point(21, 15);
            this.RBPorTrans.Name = "RBPorTrans";
            this.RBPorTrans.Size = new System.Drawing.Size(14, 13);
            this.RBPorTrans.TabIndex = 4;
            this.RBPorTrans.UseVisualStyleBackColor = true;
            // 
            // WFReimprimirFacturaElectronica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(918, 163);
            this.Controls.Add(this.BTReImprimir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.LBTipo);
            this.Controls.Add(this.CBTipoTran);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFReimprimirFacturaElectronica";
            this.Text = "Reimprimir Factura Electronica";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBTipo;
        private System.Windows.Forms.ComboBox CBTipoTran;
        private System.Windows.Forms.Button BTReImprimir;
        private System.Windows.Forms.Button BTSeleccionar;
        private System.Windows.Forms.Label RBPorTransaccion;
        private System.Windows.Forms.TextBox TBFolio;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBSerieSAT;
        private System.Windows.Forms.RadioButton RBPorFactura;
        private System.Windows.Forms.Button BTSeleccionarFE;
        private System.Windows.Forms.TextBox TBFolioSAT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton RBPorTrans;
    }
}