namespace iPos
{
    partial class WFPreguntaAlmacen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFPreguntaAlmacen));
            this.ALMACENORIGENComboBox = new System.Windows.Forms.ComboBoxFB();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.ALMACENDESTINOComboBox = new System.Windows.Forms.ComboBoxFB();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTraspasoAlmacenes = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ALMACENORIGENComboBox
            // 
            this.ALMACENORIGENComboBox.Condicion = null;
            this.ALMACENORIGENComboBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ALMACENORIGENComboBox.DisplayMember = "nombre";
            this.ALMACENORIGENComboBox.FormattingEnabled = true;
            this.ALMACENORIGENComboBox.IndiceCampoSelector = 0;
            this.ALMACENORIGENComboBox.LabelDescription = null;
            this.ALMACENORIGENComboBox.Location = new System.Drawing.Point(164, 27);
            this.ALMACENORIGENComboBox.Name = "ALMACENORIGENComboBox";
            this.ALMACENORIGENComboBox.NombreCampoSelector = "id";
            this.ALMACENORIGENComboBox.Query = "select id,nombre from almacen";
            this.ALMACENORIGENComboBox.QueryDeSeleccion = "select id,nombre from almacen where   id = @id";
            this.ALMACENORIGENComboBox.SelectedDataDisplaying = null;
            this.ALMACENORIGENComboBox.SelectedDataValue = null;
            this.ALMACENORIGENComboBox.Size = new System.Drawing.Size(125, 21);
            this.ALMACENORIGENComboBox.TabIndex = 172;
            this.ALMACENORIGENComboBox.ValueMember = "id";
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.BackColor = System.Drawing.Color.Transparent;
            this.lblAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.lblAlmacen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblAlmacen.Location = new System.Drawing.Point(28, 30);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(120, 16);
            this.lblAlmacen.TabIndex = 171;
            this.lblAlmacen.Text = "Almacen origen:";
            // 
            // ALMACENDESTINOComboBox
            // 
            this.ALMACENDESTINOComboBox.Condicion = null;
            this.ALMACENDESTINOComboBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.ALMACENDESTINOComboBox.DisplayMember = "nombre";
            this.ALMACENDESTINOComboBox.FormattingEnabled = true;
            this.ALMACENDESTINOComboBox.IndiceCampoSelector = 0;
            this.ALMACENDESTINOComboBox.LabelDescription = null;
            this.ALMACENDESTINOComboBox.Location = new System.Drawing.Point(164, 69);
            this.ALMACENDESTINOComboBox.Name = "ALMACENDESTINOComboBox";
            this.ALMACENDESTINOComboBox.NombreCampoSelector = "id";
            this.ALMACENDESTINOComboBox.Query = "select id,nombre from almacen";
            this.ALMACENDESTINOComboBox.QueryDeSeleccion = "select id,nombre from almacen where   id = @id";
            this.ALMACENDESTINOComboBox.SelectedDataDisplaying = null;
            this.ALMACENDESTINOComboBox.SelectedDataValue = null;
            this.ALMACENDESTINOComboBox.Size = new System.Drawing.Size(125, 21);
            this.ALMACENDESTINOComboBox.TabIndex = 174;
            this.ALMACENDESTINOComboBox.ValueMember = "id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(21, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 16);
            this.label1.TabIndex = 173;
            this.label1.Text = "Almacen destino:";
            // 
            // btnTraspasoAlmacenes
            // 
            this.btnTraspasoAlmacenes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnTraspasoAlmacenes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnTraspasoAlmacenes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraspasoAlmacenes.ForeColor = System.Drawing.Color.White;
            this.btnTraspasoAlmacenes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTraspasoAlmacenes.Location = new System.Drawing.Point(164, 117);
            this.btnTraspasoAlmacenes.Name = "btnTraspasoAlmacenes";
            this.btnTraspasoAlmacenes.Size = new System.Drawing.Size(125, 23);
            this.btnTraspasoAlmacenes.TabIndex = 175;
            this.btnTraspasoAlmacenes.Text = "Enviar";
            this.btnTraspasoAlmacenes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTraspasoAlmacenes.UseVisualStyleBackColor = false;
            this.btnTraspasoAlmacenes.Click += new System.EventHandler(this.btnTraspasoAlmacenes_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(17, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 23);
            this.button1.TabIndex = 176;
            this.button1.Text = "Cancelar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // WFPreguntaAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(321, 174);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTraspasoAlmacenes);
            this.Controls.Add(this.ALMACENDESTINOComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ALMACENORIGENComboBox);
            this.Controls.Add(this.lblAlmacen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFPreguntaAlmacen";
            this.Text = "WFPreguntaAlmacen";
            this.Load += new System.EventHandler(this.WFPreguntaAlmacen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBoxFB ALMACENORIGENComboBox;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.ComboBoxFB ALMACENDESTINOComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTraspasoAlmacenes;
        private System.Windows.Forms.Button button1;

    }
}