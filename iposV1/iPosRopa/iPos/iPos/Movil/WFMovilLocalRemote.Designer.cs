namespace iPos
{
    partial class WFMovilLocalRemote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFMovilLocalRemote));
            this.USARCONEXIONLOCALTextBox = new System.Windows.Forms.ComboBox();
            this.label121 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // USARCONEXIONLOCALTextBox
            // 
            this.USARCONEXIONLOCALTextBox.FormattingEnabled = true;
            this.USARCONEXIONLOCALTextBox.Items.AddRange(new object[] {
            "N",
            "S"});
            this.USARCONEXIONLOCALTextBox.Location = new System.Drawing.Point(233, 46);
            this.USARCONEXIONLOCALTextBox.Name = "USARCONEXIONLOCALTextBox";
            this.USARCONEXIONLOCALTextBox.Size = new System.Drawing.Size(62, 21);
            this.USARCONEXIONLOCALTextBox.TabIndex = 114;
            this.USARCONEXIONLOCALTextBox.Tag = "";
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.BackColor = System.Drawing.Color.Transparent;
            this.label121.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label121.ForeColor = System.Drawing.Color.White;
            this.label121.Location = new System.Drawing.Point(88, 47);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(129, 16);
            this.label121.TabIndex = 113;
            this.label121.Text = "Usar conexión local:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::iPos.Properties.Resources.saveNoBack_J;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(125, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 36);
            this.button1.TabIndex = 115;
            this.button1.Text = "Guardar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // WFMovilLocalRemote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(366, 161);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.USARCONEXIONLOCALTextBox);
            this.Controls.Add(this.label121);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFMovilLocalRemote";
            this.Text = "WFMovilLocalRemote";
            this.Load += new System.EventHandler(this.WFMovilLocalRemote_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox USARCONEXIONLOCALTextBox;
        private System.Windows.Forms.Label label121;
        private System.Windows.Forms.Button button1;
    }
}