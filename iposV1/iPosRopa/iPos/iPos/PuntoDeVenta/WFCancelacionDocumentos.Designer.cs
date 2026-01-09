namespace iPos
{
    partial class WFCancelacionDocumentos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFCancelacionDocumentos));
            this.TBFolioDocumento = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CBTipoDocumento = new System.Windows.Forms.ComboBox();
            this.TBFolioSAT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBSerieSAT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RBFolioSAT = new System.Windows.Forms.RadioButton();
            this.RBFolioDocumento = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TBFolioDocumento
            // 
            this.TBFolioDocumento.Enabled = false;
            this.TBFolioDocumento.Location = new System.Drawing.Point(184, 22);
            this.TBFolioDocumento.Name = "TBFolioDocumento";
            this.TBFolioDocumento.Size = new System.Drawing.Size(108, 20);
            this.TBFolioDocumento.TabIndex = 50;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(61, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 13);
            this.label15.TabIndex = 49;
            this.label15.Text = "Folio documento:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(184, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Tipo documento:";
            // 
            // CBTipoDocumento
            // 
            this.CBTipoDocumento.FormattingEnabled = true;
            this.CBTipoDocumento.Items.AddRange(new object[] {
            "Venta",
            "Devolución"});
            this.CBTipoDocumento.Location = new System.Drawing.Point(311, 36);
            this.CBTipoDocumento.Name = "CBTipoDocumento";
            this.CBTipoDocumento.Size = new System.Drawing.Size(120, 21);
            this.CBTipoDocumento.TabIndex = 52;
            // 
            // TBFolioSAT
            // 
            this.TBFolioSAT.Location = new System.Drawing.Point(184, 59);
            this.TBFolioSAT.Name = "TBFolioSAT";
            this.TBFolioSAT.Size = new System.Drawing.Size(108, 20);
            this.TBFolioSAT.TabIndex = 56;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(61, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "Folio SAT:";
            // 
            // TBSerieSAT
            // 
            this.TBSerieSAT.Location = new System.Drawing.Point(389, 59);
            this.TBSerieSAT.Name = "TBSerieSAT";
            this.TBSerieSAT.Size = new System.Drawing.Size(56, 20);
            this.TBSerieSAT.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(315, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "Serie SAT:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(232, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 28);
            this.button1.TabIndex = 59;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.RBFolioSAT);
            this.groupBox1.Controls.Add(this.RBFolioDocumento);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.TBFolioDocumento);
            this.groupBox1.Controls.Add(this.TBSerieSAT);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TBFolioSAT);
            this.groupBox1.Location = new System.Drawing.Point(48, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(473, 100);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            // 
            // RBFolioSAT
            // 
            this.RBFolioSAT.AutoSize = true;
            this.RBFolioSAT.Location = new System.Drawing.Point(41, 62);
            this.RBFolioSAT.Name = "RBFolioSAT";
            this.RBFolioSAT.Size = new System.Drawing.Size(14, 13);
            this.RBFolioSAT.TabIndex = 60;
            this.RBFolioSAT.TabStop = true;
            this.RBFolioSAT.UseVisualStyleBackColor = true;
            this.RBFolioSAT.CheckedChanged += new System.EventHandler(this.RBFolioSAT_CheckedChanged);
            // 
            // RBFolioDocumento
            // 
            this.RBFolioDocumento.AutoSize = true;
            this.RBFolioDocumento.Location = new System.Drawing.Point(41, 25);
            this.RBFolioDocumento.Name = "RBFolioDocumento";
            this.RBFolioDocumento.Size = new System.Drawing.Size(14, 13);
            this.RBFolioDocumento.TabIndex = 59;
            this.RBFolioDocumento.TabStop = true;
            this.RBFolioDocumento.UseVisualStyleBackColor = true;
            this.RBFolioDocumento.CheckedChanged += new System.EventHandler(this.RBFolioDocumento_CheckedChanged);
            // 
            // WFCancelacionDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(569, 247);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CBTipoDocumento);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFCancelacionDocumentos";
            this.Text = "WFCancelacionDocumentos";
            this.Load += new System.EventHandler(this.WFCancelacionDocumentos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBFolioDocumento;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBTipoDocumento;
        private System.Windows.Forms.TextBox TBFolioSAT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBSerieSAT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RBFolioSAT;
        private System.Windows.Forms.RadioButton RBFolioDocumento;
    }
}