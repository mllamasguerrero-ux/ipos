namespace iPos.Tools
{
    partial class WFCmdOutput
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
            this.cmdOutputTextBox = new System.Windows.Forms.TextBox();
            this.acceptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdOutputTextBox
            // 
            this.cmdOutputTextBox.BackColor = System.Drawing.Color.White;
            this.cmdOutputTextBox.Location = new System.Drawing.Point(28, 27);
            this.cmdOutputTextBox.Multiline = true;
            this.cmdOutputTextBox.Name = "cmdOutputTextBox";
            this.cmdOutputTextBox.ReadOnly = true;
            this.cmdOutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.cmdOutputTextBox.Size = new System.Drawing.Size(411, 267);
            this.cmdOutputTextBox.TabIndex = 0;
            // 
            // acceptButton
            // 
            this.acceptButton.BackColor = System.Drawing.Color.SteelBlue;
            this.acceptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.acceptButton.ForeColor = System.Drawing.Color.White;
            this.acceptButton.Location = new System.Drawing.Point(192, 311);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 1;
            this.acceptButton.Text = "Aceptar";
            this.acceptButton.UseVisualStyleBackColor = false;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // WFCmdOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(463, 346);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.cmdOutputTextBox);
            this.Name = "WFCmdOutput";
            this.Text = "Resultados";
            this.Load += new System.EventHandler(this.WFCmdOutput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cmdOutputTextBox;
        private System.Windows.Forms.Button acceptButton;
    }
}