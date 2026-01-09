namespace iPos
{
    partial class WFAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFAbout));
            this.label79 = new System.Windows.Forms.Label();
            this.LBVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.BackColor = System.Drawing.Color.Transparent;
            this.label79.ForeColor = System.Drawing.Color.White;
            this.label79.Location = new System.Drawing.Point(38, 50);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(53, 13);
            this.label79.TabIndex = 91;
            this.label79.Text = "Version:";
            // 
            // LBVersion
            // 
            this.LBVersion.AutoSize = true;
            this.LBVersion.BackColor = System.Drawing.Color.Transparent;
            this.LBVersion.ForeColor = System.Drawing.Color.White;
            this.LBVersion.Location = new System.Drawing.Point(94, 52);
            this.LBVersion.Name = "LBVersion";
            this.LBVersion.Size = new System.Drawing.Size(19, 13);
            this.LBVersion.TabIndex = 92;
            this.LBVersion.Text = "...";
            // 
            // WFAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(317, 172);
            this.Controls.Add(this.LBVersion);
            this.Controls.Add(this.label79);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFAbout";
            this.Text = "Acerca de Ipos";
            this.Load += new System.EventHandler(this.WFAbout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label LBVersion;
    }
}