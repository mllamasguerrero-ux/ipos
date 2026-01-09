namespace iPos
{
    partial class WFMovilPagoRestante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFMovilPagoRestante));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblOtraVenta = new System.Windows.Forms.Label();
            this.btnSeleccionarVenta = new System.Windows.Forms.Button();
            this.RBAplicarOtra = new System.Windows.Forms.RadioButton();
            this.RBAnticipo = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(67, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Que desea hacer con el pago que no se ha aplicado?";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblOtraVenta);
            this.groupBox1.Controls.Add(this.btnSeleccionarVenta);
            this.groupBox1.Controls.Add(this.RBAplicarOtra);
            this.groupBox1.Controls.Add(this.RBAnticipo);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(41, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 139);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // lblOtraVenta
            // 
            this.lblOtraVenta.AutoSize = true;
            this.lblOtraVenta.Location = new System.Drawing.Point(292, 61);
            this.lblOtraVenta.Name = "lblOtraVenta";
            this.lblOtraVenta.Size = new System.Drawing.Size(16, 13);
            this.lblOtraVenta.TabIndex = 4;
            this.lblOtraVenta.Text = "...";
            // 
            // btnSeleccionarVenta
            // 
            this.btnSeleccionarVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnSeleccionarVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnSeleccionarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarVenta.Location = new System.Drawing.Point(164, 56);
            this.btnSeleccionarVenta.Name = "btnSeleccionarVenta";
            this.btnSeleccionarVenta.Size = new System.Drawing.Size(122, 23);
            this.btnSeleccionarVenta.TabIndex = 3;
            this.btnSeleccionarVenta.Text = "Seleccionar venta";
            this.btnSeleccionarVenta.UseVisualStyleBackColor = false;
            this.btnSeleccionarVenta.Click += new System.EventHandler(this.btnSeleccionarVenta_Click);
            // 
            // RBAplicarOtra
            // 
            this.RBAplicarOtra.AutoSize = true;
            this.RBAplicarOtra.Location = new System.Drawing.Point(29, 59);
            this.RBAplicarOtra.Name = "RBAplicarOtra";
            this.RBAplicarOtra.Size = new System.Drawing.Size(117, 17);
            this.RBAplicarOtra.TabIndex = 1;
            this.RBAplicarOtra.TabStop = true;
            this.RBAplicarOtra.Text = "Aplicar a otra venta";
            this.RBAplicarOtra.UseVisualStyleBackColor = true;
            // 
            // RBAnticipo
            // 
            this.RBAnticipo.AutoSize = true;
            this.RBAnticipo.Location = new System.Drawing.Point(29, 20);
            this.RBAnticipo.Name = "RBAnticipo";
            this.RBAnticipo.Size = new System.Drawing.Size(63, 17);
            this.RBAnticipo.TabIndex = 0;
            this.RBAnticipo.TabStop = true;
            this.RBAnticipo.Text = "Anticipo";
            this.RBAnticipo.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(158, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Enviar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(318, 215);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // WFMovilPagoRestante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(533, 262);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFMovilPagoRestante";
            this.Text = "WFMovilPagoRestante";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RBAplicarOtra;
        private System.Windows.Forms.RadioButton RBAnticipo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSeleccionarVenta;
        private System.Windows.Forms.Label lblOtraVenta;
        private System.Windows.Forms.Button button2;
    }
}