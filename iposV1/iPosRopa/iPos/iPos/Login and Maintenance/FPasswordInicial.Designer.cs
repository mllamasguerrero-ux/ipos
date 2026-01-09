namespace iPos
{
    partial class FPasswordInicial
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
            this.US_PASSWORDLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BTSetPassword = new System.Windows.Forms.Button();
            this.US_PASSWORDAntLabel = new System.Windows.Forms.Label();
            this.US_PASSWORDAntTextBox = new System.Windows.Forms.TextBoxET();
            this.US_PASSWORDConfTextBox = new System.Windows.Forms.TextBoxET();
            this.US_PASSWORDTextBox = new System.Windows.Forms.TextBoxET();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // US_PASSWORDLabel
            // 
            this.US_PASSWORDLabel.AutoSize = true;
            this.US_PASSWORDLabel.BackColor = System.Drawing.Color.Transparent;
            this.US_PASSWORDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.US_PASSWORDLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.US_PASSWORDLabel.Location = new System.Drawing.Point(103, 99);
            this.US_PASSWORDLabel.Name = "US_PASSWORDLabel";
            this.US_PASSWORDLabel.Size = new System.Drawing.Size(106, 13);
            this.US_PASSWORDLabel.TabIndex = 3;
            this.US_PASSWORDLabel.Text = "Password Nuevo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(149, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Confirma:";
            // 
            // BTSetPassword
            // 
            this.BTSetPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTSetPassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTSetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTSetPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTSetPassword.ForeColor = System.Drawing.Color.White;
            this.BTSetPassword.Image = global::iPos.Properties.Resources.saveNoBack_J;
            this.BTSetPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTSetPassword.Location = new System.Drawing.Point(178, 193);
            this.BTSetPassword.Name = "BTSetPassword";
            this.BTSetPassword.Size = new System.Drawing.Size(105, 35);
            this.BTSetPassword.TabIndex = 4;
            this.BTSetPassword.Text = "    Guardar";
            this.BTSetPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTSetPassword.UseVisualStyleBackColor = false;
            this.BTSetPassword.Click += new System.EventHandler(this.BTSetPassword_Click);
            // 
            // US_PASSWORDAntLabel
            // 
            this.US_PASSWORDAntLabel.AutoSize = true;
            this.US_PASSWORDAntLabel.BackColor = System.Drawing.Color.Transparent;
            this.US_PASSWORDAntLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.US_PASSWORDAntLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.US_PASSWORDAntLabel.Location = new System.Drawing.Point(96, 66);
            this.US_PASSWORDAntLabel.Name = "US_PASSWORDAntLabel";
            this.US_PASSWORDAntLabel.Size = new System.Drawing.Size(113, 13);
            this.US_PASSWORDAntLabel.TabIndex = 8;
            this.US_PASSWORDAntLabel.Text = "Password Anterior:";
            // 
            // US_PASSWORDAntTextBox
            // 
            this.US_PASSWORDAntTextBox.Format_Expression = null;
            this.US_PASSWORDAntTextBox.Location = new System.Drawing.Point(219, 63);
            this.US_PASSWORDAntTextBox.Name = "US_PASSWORDAntTextBox";
            this.US_PASSWORDAntTextBox.PasswordChar = '*';
            this.US_PASSWORDAntTextBox.Size = new System.Drawing.Size(141, 20);
            this.US_PASSWORDAntTextBox.TabIndex = 1;
            this.US_PASSWORDAntTextBox.Tag = 34;
            this.US_PASSWORDAntTextBox.ValidationExpression = null;
            // 
            // US_PASSWORDConfTextBox
            // 
            this.US_PASSWORDConfTextBox.Format_Expression = null;
            this.US_PASSWORDConfTextBox.Location = new System.Drawing.Point(219, 129);
            this.US_PASSWORDConfTextBox.Name = "US_PASSWORDConfTextBox";
            this.US_PASSWORDConfTextBox.PasswordChar = '*';
            this.US_PASSWORDConfTextBox.Size = new System.Drawing.Size(141, 20);
            this.US_PASSWORDConfTextBox.TabIndex = 3;
            this.US_PASSWORDConfTextBox.Tag = 34;
            this.US_PASSWORDConfTextBox.ValidationExpression = null;
            // 
            // US_PASSWORDTextBox
            // 
            this.US_PASSWORDTextBox.Format_Expression = null;
            this.US_PASSWORDTextBox.Location = new System.Drawing.Point(219, 96);
            this.US_PASSWORDTextBox.Name = "US_PASSWORDTextBox";
            this.US_PASSWORDTextBox.PasswordChar = '*';
            this.US_PASSWORDTextBox.Size = new System.Drawing.Size(141, 20);
            this.US_PASSWORDTextBox.TabIndex = 2;
            this.US_PASSWORDTextBox.Tag = 34;
            this.US_PASSWORDTextBox.ValidationExpression = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(158, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "CAMBIO DE PASSWORD";
            // 
            // FPasswordInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(454, 272);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.US_PASSWORDAntLabel);
            this.Controls.Add(this.US_PASSWORDAntTextBox);
            this.Controls.Add(this.BTSetPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.US_PASSWORDConfTextBox);
            this.Controls.Add(this.US_PASSWORDLabel);
            this.Controls.Add(this.US_PASSWORDTextBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(1024, 738);
            this.Name = "FPasswordInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAMBIO DE PASSWORD";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Label US_PASSWORDLabel;
        private System.Windows.Forms.TextBoxET US_PASSWORDTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBoxET US_PASSWORDConfTextBox;
        private System.Windows.Forms.Button BTSetPassword;
        private System.Windows.Forms.Label US_PASSWORDAntLabel;
        private System.Windows.Forms.TextBoxET US_PASSWORDAntTextBox;
        private System.Windows.Forms.Label label2;
        //private Skinner.FormSkin formSkin1;
    }
}