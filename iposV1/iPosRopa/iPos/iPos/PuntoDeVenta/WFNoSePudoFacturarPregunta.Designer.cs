namespace iPos
{
    partial class WFNoSePudoFacturarPregunta
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RBCancelar = new System.Windows.Forms.RadioButton();
            this.RBRemision = new System.Windows.Forms.RadioButton();
            this.RBReintentar = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.RBCancelar);
            this.groupBox1.Controls.Add(this.RBRemision);
            this.groupBox1.Controls.Add(this.RBReintentar);
            this.groupBox1.Location = new System.Drawing.Point(31, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // RBCancelar
            // 
            this.RBCancelar.AutoSize = true;
            this.RBCancelar.ForeColor = System.Drawing.Color.White;
            this.RBCancelar.Location = new System.Drawing.Point(20, 87);
            this.RBCancelar.Name = "RBCancelar";
            this.RBCancelar.Size = new System.Drawing.Size(67, 17);
            this.RBCancelar.TabIndex = 2;
            this.RBCancelar.Text = "Cancelar";
            this.RBCancelar.UseVisualStyleBackColor = true;
            this.RBCancelar.CheckedChanged += new System.EventHandler(this.RBCancelar_CheckedChanged);
            // 
            // RBRemision
            // 
            this.RBRemision.AutoSize = true;
            this.RBRemision.Checked = true;
            this.RBRemision.ForeColor = System.Drawing.Color.White;
            this.RBRemision.Location = new System.Drawing.Point(20, 52);
            this.RBRemision.Name = "RBRemision";
            this.RBRemision.Size = new System.Drawing.Size(180, 17);
            this.RBRemision.TabIndex = 1;
            this.RBRemision.TabStop = true;
            this.RBRemision.Text = "Dejar por mientras como remision";
            this.RBRemision.UseVisualStyleBackColor = true;
            this.RBRemision.CheckedChanged += new System.EventHandler(this.RBRemision_CheckedChanged);
            // 
            // RBReintentar
            // 
            this.RBReintentar.AutoSize = true;
            this.RBReintentar.ForeColor = System.Drawing.Color.White;
            this.RBReintentar.Location = new System.Drawing.Point(20, 19);
            this.RBReintentar.Name = "RBReintentar";
            this.RBReintentar.Size = new System.Drawing.Size(141, 17);
            this.RBReintentar.TabIndex = 0;
            this.RBReintentar.Text = "Reintentar la facturacion";
            this.RBReintentar.UseVisualStyleBackColor = true;
            this.RBReintentar.CheckedChanged += new System.EventHandler(this.RBReintentar_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "No se pudo completar la facturación";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(28, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Que desea hacer?";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(64, 226);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(189, 23);
            this.btnEnviar.TabIndex = 3;
            this.btnEnviar.Text = "ENVIAR";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // WFNoSePudoFacturarPregunta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(399, 261);
            this.ControlBox = false;
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "WFNoSePudoFacturarPregunta";
            this.Text = "Pregunta facturacion";
            this.Load += new System.EventHandler(this.WFNoSePudoFacturarPregunta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RBCancelar;
        private System.Windows.Forms.RadioButton RBRemision;
        private System.Windows.Forms.RadioButton RBReintentar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEnviar;
    }
}