namespace iPos.Utilerias.Mapa
{
    partial class WFSeleccionLocation
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
            this.webBrowserMap = new System.Windows.Forms.WebBrowser();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.txtLongitude = new System.Windows.Forms.TextBox();
            this.txtLatitude = new System.Windows.Forms.TextBox();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webBrowserMap
            // 
            this.webBrowserMap.Location = new System.Drawing.Point(25, 78);
            this.webBrowserMap.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserMap.Name = "webBrowserMap";
            this.webBrowserMap.Size = new System.Drawing.Size(760, 360);
            this.webBrowserMap.TabIndex = 3;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.ForeColor = System.Drawing.Color.White;
            this.label38.Location = new System.Drawing.Point(268, 11);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(51, 13);
            this.label38.TabIndex = 291;
            this.label38.Text = "Longitud:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.BackColor = System.Drawing.Color.Transparent;
            this.label39.ForeColor = System.Drawing.Color.White;
            this.label39.Location = new System.Drawing.Point(68, 11);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(42, 13);
            this.label39.TabIndex = 290;
            this.label39.Text = "Latitud:";
            // 
            // txtLongitude
            // 
            this.txtLongitude.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLongitude.Location = new System.Drawing.Point(270, 27);
            this.txtLongitude.Name = "txtLongitude";
            this.txtLongitude.Size = new System.Drawing.Size(153, 20);
            this.txtLongitude.TabIndex = 289;
            this.txtLongitude.Leave += new System.EventHandler(this.txtLongitude_Leave);
            // 
            // txtLatitude
            // 
            this.txtLatitude.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLatitude.Location = new System.Drawing.Point(71, 27);
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.Size = new System.Drawing.Size(167, 20);
            this.txtLatitude.TabIndex = 288;
            this.txtLatitude.Leave += new System.EventHandler(this.txtLatitude_Leave);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnFinalizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizar.ForeColor = System.Drawing.Color.White;
            this.btnFinalizar.Location = new System.Drawing.Point(447, 25);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(160, 23);
            this.btnFinalizar.TabIndex = 292;
            this.btnFinalizar.Text = "HECHO";
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // WFSeleccionLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(821, 450);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.txtLongitude);
            this.Controls.Add(this.txtLatitude);
            this.Controls.Add(this.webBrowserMap);
            this.Name = "WFSeleccionLocation";
            this.Text = "SELECCION DE GEO LOCALIZACION";
            this.Load += new System.EventHandler(this.WFSeleccionLocation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowserMap;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox txtLongitude;
        private System.Windows.Forms.TextBox txtLatitude;
        private System.Windows.Forms.Button btnFinalizar;
    }
}