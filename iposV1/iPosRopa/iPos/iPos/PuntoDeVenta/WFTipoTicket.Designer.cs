namespace iPos
{
    partial class WFTipoTicket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFTipoTicket));
            this.label1 = new System.Windows.Forms.Label();
            this.TICKETLARGOTextBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TICKETLARGOCOTIZACIONTextBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(79, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ticket largo";
            // 
            // TICKETLARGOTextBox
            // 
            this.TICKETLARGOTextBox.AutoSize = true;
            this.TICKETLARGOTextBox.BackColor = System.Drawing.Color.Transparent;
            this.TICKETLARGOTextBox.Location = new System.Drawing.Point(203, 32);
            this.TICKETLARGOTextBox.Name = "TICKETLARGOTextBox";
            this.TICKETLARGOTextBox.Size = new System.Drawing.Size(15, 14);
            this.TICKETLARGOTextBox.TabIndex = 1;
            this.TICKETLARGOTextBox.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(108, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cambiar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TICKETLARGOCOTIZACIONTextBox
            // 
            this.TICKETLARGOCOTIZACIONTextBox.AutoSize = true;
            this.TICKETLARGOCOTIZACIONTextBox.BackColor = System.Drawing.Color.Transparent;
            this.TICKETLARGOCOTIZACIONTextBox.Location = new System.Drawing.Point(203, 66);
            this.TICKETLARGOCOTIZACIONTextBox.Name = "TICKETLARGOCOTIZACIONTextBox";
            this.TICKETLARGOCOTIZACIONTextBox.Size = new System.Drawing.Size(15, 14);
            this.TICKETLARGOCOTIZACIONTextBox.TabIndex = 4;
            this.TICKETLARGOCOTIZACIONTextBox.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(79, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ticket largo cotizacion";
            // 
            // WFTipoTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(284, 197);
            this.Controls.Add(this.TICKETLARGOCOTIZACIONTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TICKETLARGOTextBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFTipoTicket";
            this.Text = "Tipo Ticket";
            this.Load += new System.EventHandler(this.WFTipoTicket_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox TICKETLARGOTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox TICKETLARGOCOTIZACIONTextBox;
        private System.Windows.Forms.Label label2;
    }
}