namespace IposV3CustomInstallerActions
{
    partial class WFDataBaseOptions
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
            this.label1 = new System.Windows.Forms.Label();
            this.CBBaseDatos = new System.Windows.Forms.CheckBox();
            this.btnContinue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sera aqui el servidor de base de datos?";
            // 
            // CBBaseDatos
            // 
            this.CBBaseDatos.AutoSize = true;
            this.CBBaseDatos.Checked = true;
            this.CBBaseDatos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBBaseDatos.Location = new System.Drawing.Point(395, 92);
            this.CBBaseDatos.Name = "CBBaseDatos";
            this.CBBaseDatos.Size = new System.Drawing.Size(15, 14);
            this.CBBaseDatos.TabIndex = 1;
            this.CBBaseDatos.UseVisualStyleBackColor = true;
            // 
            // btnContinue
            // 
            this.btnContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.Location = new System.Drawing.Point(310, 195);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(209, 50);
            this.btnContinue.TabIndex = 4;
            this.btnContinue.Text = "Continuar";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // WFDataBaseOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 305);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.CBBaseDatos);
            this.Controls.Add(this.label1);
            this.Name = "WFDataBaseOptions";
            this.Text = "Opciones de base de datos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CBBaseDatos;
        private System.Windows.Forms.Button btnContinue;
    }
}