namespace iPos
{
    partial class WFDesaprobarMovilCXC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFDesaprobarMovilCXC));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RBError = new System.Windows.Forms.RadioButton();
            this.RBCancel = new System.Windows.Forms.RadioButton();
            this.btnDesaprobar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(46, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(423, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desea cancelar la venta o solo dejarla  en estado de error?";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.RBError);
            this.groupBox1.Controls.Add(this.RBCancel);
            this.groupBox1.Location = new System.Drawing.Point(50, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // RBError
            // 
            this.RBError.AutoSize = true;
            this.RBError.Checked = true;
            this.RBError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBError.ForeColor = System.Drawing.Color.White;
            this.RBError.Location = new System.Drawing.Point(199, 45);
            this.RBError.Name = "RBError";
            this.RBError.Size = new System.Drawing.Size(209, 20);
            this.RBError.TabIndex = 1;
            this.RBError.TabStop = true;
            this.RBError.Text = "Dejarla en estado de error";
            this.RBError.UseVisualStyleBackColor = true;
            // 
            // RBCancel
            // 
            this.RBCancel.AutoSize = true;
            this.RBCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RBCancel.ForeColor = System.Drawing.Color.White;
            this.RBCancel.Location = new System.Drawing.Point(31, 45);
            this.RBCancel.Name = "RBCancel";
            this.RBCancel.Size = new System.Drawing.Size(88, 20);
            this.RBCancel.TabIndex = 0;
            this.RBCancel.Text = "Cancelar";
            this.RBCancel.UseVisualStyleBackColor = true;
            // 
            // btnDesaprobar
            // 
            this.btnDesaprobar.BackColor = System.Drawing.Color.Transparent;
            this.btnDesaprobar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnDesaprobar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesaprobar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnDesaprobar.ForeColor = System.Drawing.Color.White;
            this.btnDesaprobar.Location = new System.Drawing.Point(190, 239);
            this.btnDesaprobar.Name = "btnDesaprobar";
            this.btnDesaprobar.Size = new System.Drawing.Size(134, 43);
            this.btnDesaprobar.TabIndex = 2;
            this.btnDesaprobar.Text = "Desaprobar";
            this.btnDesaprobar.UseVisualStyleBackColor = false;
            this.btnDesaprobar.Click += new System.EventHandler(this.btnDesaprobar_Click);
            // 
            // WFDesaprobarMovilCXC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(511, 313);
            this.Controls.Add(this.btnDesaprobar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFDesaprobarMovilCXC";
            this.Text = "Desaprobar movil";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RBError;
        private System.Windows.Forms.RadioButton RBCancel;
        private System.Windows.Forms.Button btnDesaprobar;
    }
}