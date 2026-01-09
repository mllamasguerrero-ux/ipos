namespace iPosReporting
{
    partial class WFFacturaEnvioMail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFFacturaEnvioMail));
            this.TBMail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnEnviar = new System.Windows.Forms.Button();
            this.BtnNoEnviar = new System.Windows.Forms.Button();
            this.CBMailTo = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CBTodaListaCombo = new System.Windows.Forms.CheckBox();
            this.RBCombo = new System.Windows.Forms.RadioButton();
            this.RBTexto = new System.Windows.Forms.RadioButton();
            this.TBBody = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TBMail
            // 
            this.TBMail.Location = new System.Drawing.Point(27, 16);
            this.TBMail.Name = "TBMail";
            this.TBMail.Size = new System.Drawing.Size(265, 20);
            this.TBMail.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(31, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enviar al correo";
            // 
            // BtnEnviar
            // 
            this.BtnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BtnEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BtnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEnviar.ForeColor = System.Drawing.Color.White;
            this.BtnEnviar.Location = new System.Drawing.Point(234, 214);
            this.BtnEnviar.Name = "BtnEnviar";
            this.BtnEnviar.Size = new System.Drawing.Size(75, 23);
            this.BtnEnviar.TabIndex = 2;
            this.BtnEnviar.Text = "Enviar";
            this.BtnEnviar.UseVisualStyleBackColor = false;
            this.BtnEnviar.Click += new System.EventHandler(this.BtnEnviar_Click);
            // 
            // BtnNoEnviar
            // 
            this.BtnNoEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BtnNoEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BtnNoEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNoEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNoEnviar.ForeColor = System.Drawing.Color.White;
            this.BtnNoEnviar.Location = new System.Drawing.Point(34, 253);
            this.BtnNoEnviar.Name = "BtnNoEnviar";
            this.BtnNoEnviar.Size = new System.Drawing.Size(75, 23);
            this.BtnNoEnviar.TabIndex = 3;
            this.BtnNoEnviar.Text = "No enviar";
            this.BtnNoEnviar.UseVisualStyleBackColor = false;
            this.BtnNoEnviar.Click += new System.EventHandler(this.BtnNoEnviar_Click);
            // 
            // CBMailTo
            // 
            this.CBMailTo.FormattingEnabled = true;
            this.CBMailTo.Location = new System.Drawing.Point(27, 51);
            this.CBMailTo.Name = "CBMailTo";
            this.CBMailTo.Size = new System.Drawing.Size(265, 21);
            this.CBMailTo.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.CBTodaListaCombo);
            this.groupBox1.Controls.Add(this.RBCombo);
            this.groupBox1.Controls.Add(this.RBTexto);
            this.groupBox1.Controls.Add(this.TBMail);
            this.groupBox1.Controls.Add(this.CBMailTo);
            this.groupBox1.Location = new System.Drawing.Point(34, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // CBTodaListaCombo
            // 
            this.CBTodaListaCombo.AutoSize = true;
            this.CBTodaListaCombo.ForeColor = System.Drawing.Color.White;
            this.CBTodaListaCombo.Location = new System.Drawing.Point(321, 55);
            this.CBTodaListaCombo.Name = "CBTodaListaCombo";
            this.CBTodaListaCombo.Size = new System.Drawing.Size(119, 17);
            this.CBTodaListaCombo.TabIndex = 7;
            this.CBTodaListaCombo.Text = "Todos los de la lista";
            this.CBTodaListaCombo.UseVisualStyleBackColor = true;
            // 
            // RBCombo
            // 
            this.RBCombo.AutoSize = true;
            this.RBCombo.Location = new System.Drawing.Point(7, 54);
            this.RBCombo.Name = "RBCombo";
            this.RBCombo.Size = new System.Drawing.Size(14, 13);
            this.RBCombo.TabIndex = 6;
            this.RBCombo.UseVisualStyleBackColor = true;
            this.RBCombo.CheckedChanged += new System.EventHandler(this.RBCombo_CheckedChanged);
            // 
            // RBTexto
            // 
            this.RBTexto.AutoSize = true;
            this.RBTexto.Checked = true;
            this.RBTexto.Location = new System.Drawing.Point(7, 19);
            this.RBTexto.Name = "RBTexto";
            this.RBTexto.Size = new System.Drawing.Size(14, 13);
            this.RBTexto.TabIndex = 5;
            this.RBTexto.TabStop = true;
            this.RBTexto.UseVisualStyleBackColor = true;
            this.RBTexto.CheckedChanged += new System.EventHandler(this.RBTexto_CheckedChanged);
            // 
            // TBBody
            // 
            this.TBBody.Location = new System.Drawing.Point(61, 153);
            this.TBBody.Multiline = true;
            this.TBBody.Name = "TBBody";
            this.TBBody.Size = new System.Drawing.Size(413, 55);
            this.TBBody.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(58, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mensaje";
            // 
            // WFFacturaEnvioMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPosReporting.Properties.Resources.ipos_material_flat_walppaer_5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(634, 288);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TBBody);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnNoEnviar);
            this.Controls.Add(this.BtnEnviar);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFFacturaEnvioMail";
            this.Text = "WFFacturaEnvioMail";
            this.Load += new System.EventHandler(this.WFFacturaEnvioMail_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBMail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnEnviar;
        private System.Windows.Forms.Button BtnNoEnviar;
        private System.Windows.Forms.ComboBox CBMailTo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CBTodaListaCombo;
        private System.Windows.Forms.RadioButton RBCombo;
        private System.Windows.Forms.RadioButton RBTexto;
        private System.Windows.Forms.TextBox TBBody;
        private System.Windows.Forms.Label label2;
    }
}