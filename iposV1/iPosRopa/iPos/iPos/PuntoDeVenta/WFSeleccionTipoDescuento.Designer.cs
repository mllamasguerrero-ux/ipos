namespace iPos
{
    partial class WFSeleccionTipoDescuento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFSeleccionTipoDescuento));
            this.CBTipoDescuento = new System.Windows.Forms.ComboBox();
            this.CALLELabel = new System.Windows.Forms.Label();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CBTipoDescuento
            // 
            this.CBTipoDescuento.FormattingEnabled = true;
            this.CBTipoDescuento.Location = new System.Drawing.Point(142, 33);
            this.CBTipoDescuento.Name = "CBTipoDescuento";
            this.CBTipoDescuento.Size = new System.Drawing.Size(222, 21);
            this.CBTipoDescuento.TabIndex = 0;
            // 
            // CALLELabel
            // 
            this.CALLELabel.AutoSize = true;
            this.CALLELabel.BackColor = System.Drawing.Color.Transparent;
            this.CALLELabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.CALLELabel.ForeColor = System.Drawing.Color.White;
            this.CALLELabel.Location = new System.Drawing.Point(31, 34);
            this.CALLELabel.Name = "CALLELabel";
            this.CALLELabel.Size = new System.Drawing.Size(105, 16);
            this.CALLELabel.TabIndex = 2;
            this.CALLELabel.Text = "Tipo descuento:";
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnSeleccionar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnSeleccionar.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionar.Location = new System.Drawing.Point(145, 98);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(121, 30);
            this.btnSeleccionar.TabIndex = 53;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // WFSeleccionTipoDescuento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(413, 140);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.CALLELabel);
            this.Controls.Add(this.CBTipoDescuento);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFSeleccionTipoDescuento";
            this.Text = "WFSeleccionTipoDescuento";
            this.Load += new System.EventHandler(this.WFSeleccionTipoDescuento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBTipoDescuento;
        private System.Windows.Forms.Label CALLELabel;
        private System.Windows.Forms.Button btnSeleccionar;
    }
}