namespace iPos.Utilerias.Procesos
{
    partial class WFObtenerPuntosBancomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFObtenerPuntosBancomer));
            this.CALLELabel = new System.Windows.Forms.Label();
            this.txtPuntosDisponibles = new System.Windows.Forms.TextBox();
            this.txtPuntosPesos = new System.Windows.Forms.TextBox();
            this.COLONIALabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CALLELabel
            // 
            this.CALLELabel.AutoSize = true;
            this.CALLELabel.BackColor = System.Drawing.Color.Transparent;
            this.CALLELabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CALLELabel.ForeColor = System.Drawing.Color.White;
            this.CALLELabel.Location = new System.Drawing.Point(65, 71);
            this.CALLELabel.Name = "CALLELabel";
            this.CALLELabel.Size = new System.Drawing.Size(114, 15);
            this.CALLELabel.TabIndex = 8;
            this.CALLELabel.Text = "Puntos disponibles:";
            // 
            // txtPuntosDisponibles
            // 
            this.txtPuntosDisponibles.Location = new System.Drawing.Point(185, 70);
            this.txtPuntosDisponibles.Name = "txtPuntosDisponibles";
            this.txtPuntosDisponibles.Size = new System.Drawing.Size(210, 20);
            this.txtPuntosDisponibles.TabIndex = 10;
            // 
            // txtPuntosPesos
            // 
            this.txtPuntosPesos.Location = new System.Drawing.Point(185, 127);
            this.txtPuntosPesos.Name = "txtPuntosPesos";
            this.txtPuntosPesos.Size = new System.Drawing.Size(210, 20);
            this.txtPuntosPesos.TabIndex = 11;
            // 
            // COLONIALabel
            // 
            this.COLONIALabel.AutoSize = true;
            this.COLONIALabel.BackColor = System.Drawing.Color.Transparent;
            this.COLONIALabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.COLONIALabel.ForeColor = System.Drawing.Color.White;
            this.COLONIALabel.Location = new System.Drawing.Point(12, 127);
            this.COLONIALabel.Name = "COLONIALabel";
            this.COLONIALabel.Size = new System.Drawing.Size(167, 15);
            this.COLONIALabel.TabIndex = 9;
            this.COLONIALabel.Text = "Puntos disponibles en pesos:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(144, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Volver a Cargar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // WFObtenerPuntosBancomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(407, 246);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CALLELabel);
            this.Controls.Add(this.txtPuntosDisponibles);
            this.Controls.Add(this.txtPuntosPesos);
            this.Controls.Add(this.COLONIALabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFObtenerPuntosBancomer";
            this.Text = "Obtener Puntos Bancomer";
            this.Load += new System.EventHandler(this.WFObtenerPuntosBancomer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CALLELabel;
        private System.Windows.Forms.TextBox txtPuntosDisponibles;
        private System.Windows.Forms.TextBox txtPuntosPesos;
        private System.Windows.Forms.Label COLONIALabel;
        private System.Windows.Forms.Button button1;
    }
}