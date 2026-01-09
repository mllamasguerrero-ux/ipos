namespace iPos
{
    partial class WFPreguntarAplicado
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
            this.DTPFechaAplicado = new System.Windows.Forms.DateTimePicker();
            this.lblFechaAplicado = new System.Windows.Forms.Label();
            this.CBAplicado = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BTEnviar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DTPFechaAplicado
            // 
            this.DTPFechaAplicado.CustomFormat = "dd/MM/yyyy";
            this.DTPFechaAplicado.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPFechaAplicado.Location = new System.Drawing.Point(147, 114);
            this.DTPFechaAplicado.Name = "DTPFechaAplicado";
            this.DTPFechaAplicado.Size = new System.Drawing.Size(123, 20);
            this.DTPFechaAplicado.TabIndex = 90;
            // 
            // lblFechaAplicado
            // 
            this.lblFechaAplicado.AutoSize = true;
            this.lblFechaAplicado.BackColor = System.Drawing.Color.Transparent;
            this.lblFechaAplicado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaAplicado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFechaAplicado.Location = new System.Drawing.Point(53, 31);
            this.lblFechaAplicado.Name = "lblFechaAplicado";
            this.lblFechaAplicado.Size = new System.Drawing.Size(300, 16);
            this.lblFechaAplicado.TabIndex = 89;
            this.lblFechaAplicado.Text = "El pago es de cheque y no esta aplicado, ";
            // 
            // CBAplicado
            // 
            this.CBAplicado.AutoSize = true;
            this.CBAplicado.BackColor = System.Drawing.Color.Transparent;
            this.CBAplicado.ForeColor = System.Drawing.Color.White;
            this.CBAplicado.Location = new System.Drawing.Point(56, 117);
            this.CBAplicado.Name = "CBAplicado";
            this.CBAplicado.Size = new System.Drawing.Size(67, 17);
            this.CBAplicado.TabIndex = 88;
            this.CBAplicado.Text = "Aplicado";
            this.CBAplicado.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(53, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 16);
            this.label1.TabIndex = 91;
            this.label1.Text = " que fecha de aplicacion se debe considerar:";
            // 
            // BTEnviar
            // 
            this.BTEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTEnviar.ForeColor = System.Drawing.Color.White;
            this.BTEnviar.Location = new System.Drawing.Point(147, 160);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(123, 27);
            this.BTEnviar.TabIndex = 92;
            this.BTEnviar.Text = "Enviar";
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(290, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 27);
            this.button1.TabIndex = 93;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // WFPreguntarAplicado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(425, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BTEnviar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTPFechaAplicado);
            this.Controls.Add(this.lblFechaAplicado);
            this.Controls.Add(this.CBAplicado);
            this.Name = "WFPreguntarAplicado";
            this.Text = "Preguntar fecha aplicacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DTPFechaAplicado;
        private System.Windows.Forms.Label lblFechaAplicado;
        private System.Windows.Forms.CheckBox CBAplicado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTEnviar;
        private System.Windows.Forms.Button button1;
    }
}