namespace iPos
{
    partial class WFReimpresionTickets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFReimpresionTickets));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CBTipoCorte = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CBCajero = new System.Windows.Forms.ComboBoxFB();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BTReimprimirCorte = new System.Windows.Forms.Button();
            this.DTPCorte = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReinicializaVerifone = new System.Windows.Forms.Button();
            this.BTReImprimirVoucher = new System.Windows.Forms.Button();
            this.LBTipo = new System.Windows.Forms.Label();
            this.CBTipoTran = new System.Windows.Forms.ComboBox();
            this.BTReImprimir = new System.Windows.Forms.Button();
            this.BTSeleccionar = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.TBFolio = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.CBTipoCorte);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.CBCajero);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.BTReimprimirCorte);
            this.groupBox2.Controls.Add(this.DTPCorte);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(14, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(915, 74);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cortes";
            // 
            // CBTipoCorte
            // 
            this.CBTipoCorte.FormattingEnabled = true;
            this.CBTipoCorte.Items.AddRange(new object[] {
            "Normal",
            "Por Montos de Billetes",
            "Apertura"});
            this.CBTipoCorte.Location = new System.Drawing.Point(587, 28);
            this.CBTipoCorte.Name = "CBTipoCorte";
            this.CBTipoCorte.Size = new System.Drawing.Size(166, 21);
            this.CBTipoCorte.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(544, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tipo:";
            // 
            // CBCajero
            // 
            this.CBCajero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(222)))), ((int)(((byte)(229)))));
            this.CBCajero.Condicion = null;
            this.CBCajero.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.CBCajero.DisplayMember = "NOMBRE";
            this.CBCajero.FormattingEnabled = true;
            this.CBCajero.IndiceCampoSelector = 0;
            this.CBCajero.LabelDescription = null;
            this.CBCajero.Location = new System.Drawing.Point(352, 31);
            this.CBCajero.Name = "CBCajero";
            this.CBCajero.NombreCampoSelector = null;
            this.CBCajero.Query = "select ID,USERNAME as NOMBRE from persona where ACTIVO = \'S\' and username is not " +
    "null";
            this.CBCajero.QueryDeSeleccion = null;
            this.CBCajero.SelectedDataDisplaying = null;
            this.CBCajero.SelectedDataValue = null;
            this.CBCajero.Size = new System.Drawing.Size(182, 21);
            this.CBCajero.TabIndex = 6;
            this.CBCajero.ValueMember = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fecha:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(303, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cajero:";
            // 
            // BTReimprimirCorte
            // 
            this.BTReimprimirCorte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTReimprimirCorte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTReimprimirCorte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTReimprimirCorte.Image = global::iPos.Properties.Resources.printNoBack_J;
            this.BTReimprimirCorte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTReimprimirCorte.Location = new System.Drawing.Point(761, 25);
            this.BTReimprimirCorte.Name = "BTReimprimirCorte";
            this.BTReimprimirCorte.Size = new System.Drawing.Size(147, 32);
            this.BTReimprimirCorte.TabIndex = 7;
            this.BTReimprimirCorte.Text = "Reimprimir corte";
            this.BTReimprimirCorte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTReimprimirCorte.UseVisualStyleBackColor = false;
            this.BTReimprimirCorte.Click += new System.EventHandler(this.BTReimprimirCorte_Click);
            // 
            // DTPCorte
            // 
            this.DTPCorte.Location = new System.Drawing.Point(63, 31);
            this.DTPCorte.Name = "DTPCorte";
            this.DTPCorte.Size = new System.Drawing.Size(233, 20);
            this.DTPCorte.TabIndex = 5;
            this.DTPCorte.ValueChanged += new System.EventHandler(this.DTPCorte_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnReinicializaVerifone);
            this.groupBox1.Controls.Add(this.BTReImprimirVoucher);
            this.groupBox1.Controls.Add(this.LBTipo);
            this.groupBox1.Controls.Add(this.CBTipoTran);
            this.groupBox1.Controls.Add(this.BTReImprimir);
            this.groupBox1.Controls.Add(this.BTSeleccionar);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Controls.Add(this.TBFolio);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(915, 131);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transacciones";
            // 
            // btnReinicializaVerifone
            // 
            this.btnReinicializaVerifone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnReinicializaVerifone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnReinicializaVerifone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReinicializaVerifone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnReinicializaVerifone.ForeColor = System.Drawing.Color.White;
            this.btnReinicializaVerifone.Location = new System.Drawing.Point(517, 89);
            this.btnReinicializaVerifone.Name = "btnReinicializaVerifone";
            this.btnReinicializaVerifone.Size = new System.Drawing.Size(191, 25);
            this.btnReinicializaVerifone.TabIndex = 214;
            this.btnReinicializaVerifone.Text = "Reinicializa terminal verifone";
            this.btnReinicializaVerifone.UseVisualStyleBackColor = false;
            this.btnReinicializaVerifone.Visible = false;
            this.btnReinicializaVerifone.Click += new System.EventHandler(this.btnReinicializaVerifone_Click);
            // 
            // BTReImprimirVoucher
            // 
            this.BTReImprimirVoucher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTReImprimirVoucher.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTReImprimirVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTReImprimirVoucher.Image = global::iPos.Properties.Resources.printNoBack_J;
            this.BTReImprimirVoucher.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTReImprimirVoucher.Location = new System.Drawing.Point(743, 82);
            this.BTReImprimirVoucher.Name = "BTReImprimirVoucher";
            this.BTReImprimirVoucher.Size = new System.Drawing.Size(165, 32);
            this.BTReImprimirVoucher.TabIndex = 5;
            this.BTReImprimirVoucher.Text = "Reimprimir voucher";
            this.BTReImprimirVoucher.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTReImprimirVoucher.UseVisualStyleBackColor = false;
            this.BTReImprimirVoucher.Visible = false;
            this.BTReImprimirVoucher.Click += new System.EventHandler(this.BTReImprimirVoucher_Click);
            // 
            // LBTipo
            // 
            this.LBTipo.AutoSize = true;
            this.LBTipo.Location = new System.Drawing.Point(19, 28);
            this.LBTipo.Name = "LBTipo";
            this.LBTipo.Size = new System.Drawing.Size(36, 13);
            this.LBTipo.TabIndex = 2;
            this.LBTipo.Text = "Tipo:";
            // 
            // CBTipoTran
            // 
            this.CBTipoTran.FormattingEnabled = true;
            this.CBTipoTran.Items.AddRange(new object[] {
            "Venta Cerrada",
            "Venta Cancelada",
            "Traslados Envio",
            "Traslados Recepcion",
            "Compra",
            "Pedido Recepcion",
            "Venta a Futuro",
            "Devolucion de traslado enviado",
            "Devolucion de pedido enviado"});
            this.CBTipoTran.Location = new System.Drawing.Point(63, 24);
            this.CBTipoTran.Name = "CBTipoTran";
            this.CBTipoTran.Size = new System.Drawing.Size(233, 21);
            this.CBTipoTran.TabIndex = 1;
            this.CBTipoTran.SelectedIndexChanged += new System.EventHandler(this.CBTipoTran_SelectedIndexChanged);
            // 
            // BTReImprimir
            // 
            this.BTReImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTReImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTReImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTReImprimir.Image = global::iPos.Properties.Resources.printNoBack_J;
            this.BTReImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTReImprimir.Location = new System.Drawing.Point(743, 19);
            this.BTReImprimir.Name = "BTReImprimir";
            this.BTReImprimir.Size = new System.Drawing.Size(165, 32);
            this.BTReImprimir.TabIndex = 4;
            this.BTReImprimir.Text = "Reimprimir ticket";
            this.BTReImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTReImprimir.UseVisualStyleBackColor = false;
            this.BTReImprimir.Click += new System.EventHandler(this.BTReImprimir_Click);
            // 
            // BTSeleccionar
            // 
            this.BTSeleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTSeleccionar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTSeleccionar.Location = new System.Drawing.Point(503, 22);
            this.BTSeleccionar.Name = "BTSeleccionar";
            this.BTSeleccionar.Size = new System.Drawing.Size(34, 23);
            this.BTSeleccionar.TabIndex = 3;
            this.BTSeleccionar.Text = "...";
            this.BTSeleccionar.UseVisualStyleBackColor = false;
            this.BTSeleccionar.Click += new System.EventHandler(this.BTSeleccionar_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(311, 28);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(38, 13);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Folio:";
            // 
            // TBFolio
            // 
            this.TBFolio.Location = new System.Drawing.Point(355, 25);
            this.TBFolio.Name = "TBFolio";
            this.TBFolio.Size = new System.Drawing.Size(142, 20);
            this.TBFolio.TabIndex = 2;
            // 
            // WFReimpresionTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(940, 248);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFReimpresionTickets";
            this.Text = "Reimpresion Tickets y Cortes";
            this.Load += new System.EventHandler(this.WFReimpresionTickets_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BTReImprimir;
        private System.Windows.Forms.Button BTSeleccionar;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox TBFolio;
        private System.Windows.Forms.ComboBox CBTipoTran;
        private System.Windows.Forms.Label LBTipo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTReimprimirCorte;
        private System.Windows.Forms.DateTimePicker DTPCorte;
        private System.Windows.Forms.ComboBoxFB CBCajero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CBTipoCorte;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BTReImprimirVoucher;
        private System.Windows.Forms.Button btnReinicializaVerifone;
    }
}