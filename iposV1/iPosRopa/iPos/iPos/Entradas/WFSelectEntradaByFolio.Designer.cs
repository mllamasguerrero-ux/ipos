namespace iPos
{
    partial class WFSelectEntradaByFolio
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LBTipo = new System.Windows.Forms.Label();
            this.CBTipoTran = new System.Windows.Forms.ComboBox();
            this.BTReImprimir = new System.Windows.Forms.Button();
            this.BTSeleccionar = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.TBFolio = new System.Windows.Forms.TextBox();
            this.SUCURSALIDLabel = new System.Windows.Forms.Label();
            this.SUCURSALIDButton = new System.Windows.Forms.Button();
            this.SUCURSALIDTextBox = new iPos.Tools.TextBoxFB();
            this.CBSucursal = new System.Windows.Forms.CheckBox();
            this.pnlSucursal = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.pnlSucursal.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.pnlSucursal);
            this.groupBox1.Controls.Add(this.LBTipo);
            this.groupBox1.Controls.Add(this.CBTipoTran);
            this.groupBox1.Controls.Add(this.BTReImprimir);
            this.groupBox1.Controls.Add(this.BTSeleccionar);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Controls.Add(this.TBFolio);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(736, 109);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transacciones";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // LBTipo
            // 
            this.LBTipo.AutoSize = true;
            this.LBTipo.Location = new System.Drawing.Point(6, 26);
            this.LBTipo.Name = "LBTipo";
            this.LBTipo.Size = new System.Drawing.Size(36, 13);
            this.LBTipo.TabIndex = 2;
            this.LBTipo.Text = "Tipo:";
            // 
            // CBTipoTran
            // 
            this.CBTipoTran.FormattingEnabled = true;
            this.CBTipoTran.Items.AddRange(new object[] {
            "COMPRAS",
            "CANCELACIONES",
            "PEDIDOS RECEPCION",
            "TRASLADOS RECEPCION ",
            "ORDENES DE COMPRA",
            "RECEPCION DE ORDENES DE COMPRA",
            "DEVOLUCION DE TRASLADOS ENVIADOS",
            "DEVOLUCION DE SURTIMIENTO DE PEDIDOS ENVIADOS",
            "COMPRAS SUCURSALES"});
            this.CBTipoTran.Location = new System.Drawing.Point(87, 23);
            this.CBTipoTran.Name = "CBTipoTran";
            this.CBTipoTran.Size = new System.Drawing.Size(203, 21);
            this.CBTipoTran.TabIndex = 1;
            this.CBTipoTran.Validated += new System.EventHandler(this.CBTipoTran_Validated);
            // 
            // BTReImprimir
            // 
            this.BTReImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTReImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTReImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTReImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTReImprimir.Location = new System.Drawing.Point(611, 74);
            this.BTReImprimir.Name = "BTReImprimir";
            this.BTReImprimir.Size = new System.Drawing.Size(103, 29);
            this.BTReImprimir.TabIndex = 4;
            this.BTReImprimir.Text = "Ver";
            this.BTReImprimir.UseVisualStyleBackColor = false;
            this.BTReImprimir.Click += new System.EventHandler(this.BTReImprimir_Click);
            // 
            // BTSeleccionar
            // 
            this.BTSeleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTSeleccionar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTSeleccionar.Location = new System.Drawing.Point(499, 21);
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
            this.Label1.Location = new System.Drawing.Point(307, 26);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(38, 13);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Folio:";
            this.Label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // TBFolio
            // 
            this.TBFolio.Location = new System.Drawing.Point(351, 23);
            this.TBFolio.Name = "TBFolio";
            this.TBFolio.Size = new System.Drawing.Size(142, 20);
            this.TBFolio.TabIndex = 2;
            this.TBFolio.TextChanged += new System.EventHandler(this.TBFolio_TextChanged);
            this.TBFolio.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBFolio_KeyUp);
            // 
            // SUCURSALIDLabel
            // 
            this.SUCURSALIDLabel.AutoSize = true;
            this.SUCURSALIDLabel.BackColor = System.Drawing.Color.Transparent;
            this.SUCURSALIDLabel.ForeColor = System.Drawing.Color.White;
            this.SUCURSALIDLabel.Location = new System.Drawing.Point(215, 9);
            this.SUCURSALIDLabel.Name = "SUCURSALIDLabel";
            this.SUCURSALIDLabel.Size = new System.Drawing.Size(19, 13);
            this.SUCURSALIDLabel.TabIndex = 231;
            this.SUCURSALIDLabel.Text = "...";
            // 
            // SUCURSALIDButton
            // 
            this.SUCURSALIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.SUCURSALIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SUCURSALIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SUCURSALIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.SUCURSALIDButton.Location = new System.Drawing.Point(185, 4);
            this.SUCURSALIDButton.Name = "SUCURSALIDButton";
            this.SUCURSALIDButton.Size = new System.Drawing.Size(24, 23);
            this.SUCURSALIDButton.TabIndex = 230;
            this.SUCURSALIDButton.UseVisualStyleBackColor = true;
            // 
            // SUCURSALIDTextBox
            // 
            this.SUCURSALIDTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.SUCURSALIDTextBox.BotonLookUp = this.SUCURSALIDButton;
            this.SUCURSALIDTextBox.Condicion = null;
            this.SUCURSALIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SUCURSALIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.SUCURSALIDTextBox.DbValue = null;
            this.SUCURSALIDTextBox.Format_Expression = null;
            this.SUCURSALIDTextBox.IndiceCampoDescripcion = 2;
            this.SUCURSALIDTextBox.IndiceCampoSelector = 1;
            this.SUCURSALIDTextBox.IndiceCampoValue = 0;
            this.SUCURSALIDTextBox.LabelDescription = this.SUCURSALIDLabel;
            this.SUCURSALIDTextBox.Location = new System.Drawing.Point(84, 6);
            this.SUCURSALIDTextBox.MostrarErrores = true;
            this.SUCURSALIDTextBox.Name = "SUCURSALIDTextBox";
            this.SUCURSALIDTextBox.NombreCampoSelector = "clave";
            this.SUCURSALIDTextBox.NombreCampoValue = "id";
            this.SUCURSALIDTextBox.Query = "select id,clave,nombre from sucursal";
            this.SUCURSALIDTextBox.QueryDeSeleccion = "select id,clave,nombre from sucursal where  clave = @clave";
            this.SUCURSALIDTextBox.QueryPorDBValue = "select id,clave,nombre from sucursal where  id = @id";
            this.SUCURSALIDTextBox.Size = new System.Drawing.Size(95, 20);
            this.SUCURSALIDTextBox.TabIndex = 229;
            this.SUCURSALIDTextBox.Tag = 34;
            this.SUCURSALIDTextBox.TextDescription = null;
            this.SUCURSALIDTextBox.Titulo = "Sucursal";
            this.SUCURSALIDTextBox.ValidarEntrada = true;
            this.SUCURSALIDTextBox.ValidationExpression = null;
            // 
            // CBSucursal
            // 
            this.CBSucursal.AutoSize = true;
            this.CBSucursal.BackColor = System.Drawing.Color.Transparent;
            this.CBSucursal.Checked = true;
            this.CBSucursal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBSucursal.ForeColor = System.Drawing.Color.Transparent;
            this.CBSucursal.Location = new System.Drawing.Point(3, 8);
            this.CBSucursal.Name = "CBSucursal";
            this.CBSucursal.Size = new System.Drawing.Size(75, 17);
            this.CBSucursal.TabIndex = 232;
            this.CBSucursal.Text = "Sucursal";
            this.CBSucursal.UseVisualStyleBackColor = false;
            // 
            // pnlSucursal
            // 
            this.pnlSucursal.Controls.Add(this.CBSucursal);
            this.pnlSucursal.Controls.Add(this.SUCURSALIDTextBox);
            this.pnlSucursal.Controls.Add(this.SUCURSALIDLabel);
            this.pnlSucursal.Controls.Add(this.SUCURSALIDButton);
            this.pnlSucursal.Location = new System.Drawing.Point(2, 50);
            this.pnlSucursal.Name = "pnlSucursal";
            this.pnlSucursal.Size = new System.Drawing.Size(571, 38);
            this.pnlSucursal.TabIndex = 233;
            this.pnlSucursal.Visible = false;
            // 
            // WFSelectEntradaByFolio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(754, 148);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "WFSelectEntradaByFolio";
            this.Text = "Seleccionar registro por folio";
            this.Load += new System.EventHandler(this.WFSelectEntradaByFolio_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlSucursal.ResumeLayout(false);
            this.pnlSucursal.PerformLayout();
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
        private System.Windows.Forms.Label SUCURSALIDLabel;
        private System.Windows.Forms.Button SUCURSALIDButton;
        private Tools.TextBoxFB SUCURSALIDTextBox;
        private System.Windows.Forms.CheckBox CBSucursal;
        private System.Windows.Forms.Panel pnlSucursal;
    }
}