namespace iPos
{
    partial class FAdministracion
    {
        
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAdministracion));
            this.BTUsuarios = new System.Windows.Forms.Button();
            this.BTPerfiles = new System.Windows.Forms.Button();
            this.BTExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTUsuarios
            // 
            this.BTUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTUsuarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.BTUsuarios.ForeColor = System.Drawing.Color.White;
            this.BTUsuarios.Location = new System.Drawing.Point(12, 57);
            this.BTUsuarios.Name = "BTUsuarios";
            this.BTUsuarios.Size = new System.Drawing.Size(151, 25);
            this.BTUsuarios.TabIndex = 0;
            this.BTUsuarios.Text = "Usuarios";
            this.BTUsuarios.UseVisualStyleBackColor = false;
            this.BTUsuarios.Click += new System.EventHandler(this.BTUsuarios_Click);
            // 
            // BTPerfiles
            // 
            this.BTPerfiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTPerfiles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTPerfiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTPerfiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.BTPerfiles.ForeColor = System.Drawing.Color.White;
            this.BTPerfiles.Location = new System.Drawing.Point(12, 100);
            this.BTPerfiles.Name = "BTPerfiles";
            this.BTPerfiles.Size = new System.Drawing.Size(151, 25);
            this.BTPerfiles.TabIndex = 1;
            this.BTPerfiles.Text = "Perfiles";
            this.BTPerfiles.UseVisualStyleBackColor = false;
            this.BTPerfiles.Click += new System.EventHandler(this.BTPerfiles_Click);
            // 
            // BTExit
            // 
            this.BTExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.BTExit.ForeColor = System.Drawing.Color.White;
            this.BTExit.Location = new System.Drawing.Point(12, 142);
            this.BTExit.Name = "BTExit";
            this.BTExit.Size = new System.Drawing.Size(151, 25);
            this.BTExit.TabIndex = 2;
            this.BTExit.Text = "Salir";
            this.BTExit.UseVisualStyleBackColor = false;
            this.BTExit.Click += new System.EventHandler(this.BTExit_Click);
            // 
            // FAdministracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(180, 200);
            this.Controls.Add(this.BTExit);
            this.Controls.Add(this.BTPerfiles);
            this.Controls.Add(this.BTUsuarios);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FAdministracion";
            this.Text = "FAdministracion";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.Load += new System.EventHandler(this.FAdministracion_Load);
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Button BTUsuarios;
        private System.Windows.Forms.Button BTPerfiles;
        private System.Windows.Forms.Button BTExit;
        //private Skinner.FormSkin formSkin1;
    }
}