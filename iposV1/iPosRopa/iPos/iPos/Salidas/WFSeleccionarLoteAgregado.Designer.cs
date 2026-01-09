namespace iPos
{
    partial class WFSeleccionarLoteAgregado
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
            this.CBListLotes = new System.Windows.Forms.ComboBox();
            this.RBNuevo = new System.Windows.Forms.RadioButton();
            this.RBYaAgregado = new System.Windows.Forms.RadioButton();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.CBListLotes);
            this.groupBox1.Controls.Add(this.RBNuevo);
            this.groupBox1.Controls.Add(this.RBYaAgregado);
            this.groupBox1.Location = new System.Drawing.Point(59, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // CBListLotes
            // 
            this.CBListLotes.FormattingEnabled = true;
            this.CBListLotes.Location = new System.Drawing.Point(158, 25);
            this.CBListLotes.Name = "CBListLotes";
            this.CBListLotes.Size = new System.Drawing.Size(144, 21);
            this.CBListLotes.TabIndex = 2;
            // 
            // RBNuevo
            // 
            this.RBNuevo.AutoSize = true;
            this.RBNuevo.Checked = true;
            this.RBNuevo.ForeColor = System.Drawing.Color.White;
            this.RBNuevo.Location = new System.Drawing.Point(22, 66);
            this.RBNuevo.Name = "RBNuevo";
            this.RBNuevo.Size = new System.Drawing.Size(136, 17);
            this.RBNuevo.TabIndex = 1;
            this.RBNuevo.TabStop = true;
            this.RBNuevo.Text = "Nuevo o con lote vacio";
            this.RBNuevo.UseVisualStyleBackColor = true;
            // 
            // RBYaAgregado
            // 
            this.RBYaAgregado.AutoSize = true;
            this.RBYaAgregado.ForeColor = System.Drawing.Color.White;
            this.RBYaAgregado.Location = new System.Drawing.Point(22, 29);
            this.RBYaAgregado.Name = "RBYaAgregado";
            this.RBYaAgregado.Size = new System.Drawing.Size(108, 17);
            this.RBYaAgregado.TabIndex = 0;
            this.RBYaAgregado.Text = "Lote ya agregado";
            this.RBYaAgregado.UseVisualStyleBackColor = true;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.Location = new System.Drawing.Point(148, 150);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(164, 23);
            this.btnEnviar.TabIndex = 10;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // WFSeleccionarLoteAgregado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(440, 206);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.groupBox1);
            this.Name = "WFSeleccionarLoteAgregado";
            this.Text = "Seleccionar lote agregado";
            this.Load += new System.EventHandler(this.WFSeleccionarLoteAgregado_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CBListLotes;
        private System.Windows.Forms.RadioButton RBNuevo;
        private System.Windows.Forms.RadioButton RBYaAgregado;
        private System.Windows.Forms.Button btnEnviar;
    }
}