namespace iPos
{
    partial class WFCancelacionAltSeleccion
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RBSustitucion = new System.Windows.Forms.RadioButton();
            this.RBNotaCredito = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancelacion = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "La cancelacion no debe ser directa pues la transaccion es por mas de ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(22, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(432, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "5000 en la v3.3 o 1000 en la version 4.0 y ya han pasado mas de 72 horas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(22, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "¿Que tipo de cancelacion desea hacer?";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.RBSustitucion);
            this.groupBox1.Controls.Add(this.RBNotaCredito);
            this.groupBox1.Location = new System.Drawing.Point(25, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 110);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // RBSustitucion
            // 
            this.RBSustitucion.AutoSize = true;
            this.RBSustitucion.ForeColor = System.Drawing.Color.White;
            this.RBSustitucion.Location = new System.Drawing.Point(27, 55);
            this.RBSustitucion.Name = "RBSustitucion";
            this.RBSustitucion.Size = new System.Drawing.Size(94, 17);
            this.RBSustitucion.TabIndex = 1;
            this.RBSustitucion.Text = "Por sustitucion";
            this.RBSustitucion.UseVisualStyleBackColor = true;
            this.RBSustitucion.CheckedChanged += new System.EventHandler(this.RBSustitucion_CheckedChanged);
            // 
            // RBNotaCredito
            // 
            this.RBNotaCredito.AutoSize = true;
            this.RBNotaCredito.Checked = true;
            this.RBNotaCredito.ForeColor = System.Drawing.Color.White;
            this.RBNotaCredito.Location = new System.Drawing.Point(27, 19);
            this.RBNotaCredito.Name = "RBNotaCredito";
            this.RBNotaCredito.Size = new System.Drawing.Size(115, 17);
            this.RBNotaCredito.TabIndex = 0;
            this.RBNotaCredito.TabStop = true;
            this.RBNotaCredito.Text = "Por nota de credito";
            this.RBNotaCredito.UseVisualStyleBackColor = true;
            this.RBNotaCredito.CheckedChanged += new System.EventHandler(this.RBNotaCredito_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(129, 229);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 39);
            this.button1.TabIndex = 175;
            this.button1.Text = "Seleccionar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancelacion
            // 
            this.btnCancelacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancelacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnCancelacion.ForeColor = System.Drawing.Color.White;
            this.btnCancelacion.Location = new System.Drawing.Point(360, 229);
            this.btnCancelacion.Name = "btnCancelacion";
            this.btnCancelacion.Size = new System.Drawing.Size(159, 39);
            this.btnCancelacion.TabIndex = 176;
            this.btnCancelacion.Text = "No hacer cancelacion";
            this.btnCancelacion.UseVisualStyleBackColor = false;
            this.btnCancelacion.Click += new System.EventHandler(this.btnCancelacion_Click);
            // 
            // WFCancelacionAltSeleccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(531, 280);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelacion);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "WFCancelacionAltSeleccion";
            this.Text = "Seleccion de cancelacion alternativa";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RBSustitucion;
        private System.Windows.Forms.RadioButton RBNotaCredito;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancelacion;
    }
}