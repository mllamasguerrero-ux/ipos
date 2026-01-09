namespace iPos.MultiEmpresa
{
    partial class WFSyncConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFSyncConfig));
            this.habSyncCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ultimoCambioDateTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.conexionEnRedTextBox = new System.Windows.Forms.TextBox();
            this.cambioManualDeFechaCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ultimaSyncDateTime = new System.Windows.Forms.Label();
            this.limpiarNoSyncCheckBox = new System.Windows.Forms.CheckBox();
            this.autoSyncCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.conexionTextBox = new System.Windows.Forms.TextBox();
            this.originalRadioButton = new System.Windows.Forms.RadioButton();
            this.copiaRadioButton = new System.Windows.Forms.RadioButton();
            this.guardarButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // habSyncCheckBox
            // 
            this.habSyncCheckBox.AutoSize = true;
            this.habSyncCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.habSyncCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.habSyncCheckBox.ForeColor = System.Drawing.Color.White;
            this.habSyncCheckBox.Location = new System.Drawing.Point(29, 22);
            this.habSyncCheckBox.Name = "habSyncCheckBox";
            this.habSyncCheckBox.Size = new System.Drawing.Size(165, 20);
            this.habSyncCheckBox.TabIndex = 0;
            this.habSyncCheckBox.Text = "Habilitar sincronizacion";
            this.habSyncCheckBox.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.originalRadioButton);
            this.groupBox1.Controls.Add(this.copiaRadioButton);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(29, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(726, 302);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ultimoCambioDateTime);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.conexionEnRedTextBox);
            this.panel2.Controls.Add(this.cambioManualDeFechaCheckBox);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(360, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(351, 217);
            this.panel2.TabIndex = 4;
            // 
            // ultimoCambioDateTime
            // 
            this.ultimoCambioDateTime.AutoSize = true;
            this.ultimoCambioDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.ultimoCambioDateTime.ForeColor = System.Drawing.Color.White;
            this.ultimoCambioDateTime.Location = new System.Drawing.Point(97, 18);
            this.ultimoCambioDateTime.Name = "ultimoCambioDateTime";
            this.ultimoCambioDateTime.Size = new System.Drawing.Size(17, 16);
            this.ultimoCambioDateTime.TabIndex = 9;
            this.ultimoCambioDateTime.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(4, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(344, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ruta en red donde se copiara cada que haya un cambio";
            // 
            // conexionEnRedTextBox
            // 
            this.conexionEnRedTextBox.Location = new System.Drawing.Point(15, 73);
            this.conexionEnRedTextBox.Name = "conexionEnRedTextBox";
            this.conexionEnRedTextBox.Size = new System.Drawing.Size(319, 20);
            this.conexionEnRedTextBox.TabIndex = 7;
            // 
            // cambioManualDeFechaCheckBox
            // 
            this.cambioManualDeFechaCheckBox.AutoSize = true;
            this.cambioManualDeFechaCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.cambioManualDeFechaCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.cambioManualDeFechaCheckBox.ForeColor = System.Drawing.Color.White;
            this.cambioManualDeFechaCheckBox.Location = new System.Drawing.Point(15, 120);
            this.cambioManualDeFechaCheckBox.Name = "cambioManualDeFechaCheckBox";
            this.cambioManualDeFechaCheckBox.Size = new System.Drawing.Size(176, 20);
            this.cambioManualDeFechaCheckBox.TabIndex = 6;
            this.cambioManualDeFechaCheckBox.Text = "Cambio manual de fecha";
            this.cambioManualDeFechaCheckBox.UseVisualStyleBackColor = false;
            this.cambioManualDeFechaCheckBox.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(4, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ultimo Cambio";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ultimaSyncDateTime);
            this.panel1.Controls.Add(this.limpiarNoSyncCheckBox);
            this.panel1.Controls.Add(this.autoSyncCheckBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.conexionTextBox);
            this.panel1.Location = new System.Drawing.Point(19, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 217);
            this.panel1.TabIndex = 3;
            // 
            // ultimaSyncDateTime
            // 
            this.ultimaSyncDateTime.AutoSize = true;
            this.ultimaSyncDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.ultimaSyncDateTime.ForeColor = System.Drawing.Color.White;
            this.ultimaSyncDateTime.Location = new System.Drawing.Point(95, 70);
            this.ultimaSyncDateTime.Name = "ultimaSyncDateTime";
            this.ultimaSyncDateTime.Size = new System.Drawing.Size(17, 16);
            this.ultimaSyncDateTime.TabIndex = 6;
            this.ultimaSyncDateTime.Text = "...";
            // 
            // limpiarNoSyncCheckBox
            // 
            this.limpiarNoSyncCheckBox.AutoSize = true;
            this.limpiarNoSyncCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.limpiarNoSyncCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.limpiarNoSyncCheckBox.ForeColor = System.Drawing.Color.White;
            this.limpiarNoSyncCheckBox.Location = new System.Drawing.Point(20, 168);
            this.limpiarNoSyncCheckBox.Name = "limpiarNoSyncCheckBox";
            this.limpiarNoSyncCheckBox.Size = new System.Drawing.Size(239, 20);
            this.limpiarNoSyncCheckBox.TabIndex = 5;
            this.limpiarNoSyncCheckBox.Text = "Limpiar empresas no sincronizadas";
            this.limpiarNoSyncCheckBox.UseVisualStyleBackColor = false;
            // 
            // autoSyncCheckBox
            // 
            this.autoSyncCheckBox.AutoSize = true;
            this.autoSyncCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.autoSyncCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.autoSyncCheckBox.ForeColor = System.Drawing.Color.White;
            this.autoSyncCheckBox.Location = new System.Drawing.Point(20, 120);
            this.autoSyncCheckBox.Name = "autoSyncCheckBox";
            this.autoSyncCheckBox.Size = new System.Drawing.Size(199, 20);
            this.autoSyncCheckBox.TabIndex = 4;
            this.autoSyncCheckBox.Text = "Sincronizar automaticamente";
            this.autoSyncCheckBox.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(17, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ultima Sinc";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Conexion";
            // 
            // conexionTextBox
            // 
            this.conexionTextBox.Location = new System.Drawing.Point(20, 30);
            this.conexionTextBox.Name = "conexionTextBox";
            this.conexionTextBox.Size = new System.Drawing.Size(293, 20);
            this.conexionTextBox.TabIndex = 0;
            // 
            // originalRadioButton
            // 
            this.originalRadioButton.AutoSize = true;
            this.originalRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.originalRadioButton.ForeColor = System.Drawing.Color.White;
            this.originalRadioButton.Location = new System.Drawing.Point(360, 41);
            this.originalRadioButton.Name = "originalRadioButton";
            this.originalRadioButton.Size = new System.Drawing.Size(72, 20);
            this.originalRadioButton.TabIndex = 2;
            this.originalRadioButton.TabStop = true;
            this.originalRadioButton.Text = "Original";
            this.originalRadioButton.UseVisualStyleBackColor = true;
            // 
            // copiaRadioButton
            // 
            this.copiaRadioButton.AutoSize = true;
            this.copiaRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.copiaRadioButton.ForeColor = System.Drawing.Color.White;
            this.copiaRadioButton.Location = new System.Drawing.Point(19, 41);
            this.copiaRadioButton.Name = "copiaRadioButton";
            this.copiaRadioButton.Size = new System.Drawing.Size(62, 20);
            this.copiaRadioButton.TabIndex = 0;
            this.copiaRadioButton.TabStop = true;
            this.copiaRadioButton.Text = "Copia";
            this.copiaRadioButton.UseVisualStyleBackColor = true;
            // 
            // guardarButton
            // 
            this.guardarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.guardarButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.guardarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guardarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.guardarButton.ForeColor = System.Drawing.Color.White;
            this.guardarButton.Location = new System.Drawing.Point(342, 400);
            this.guardarButton.Margin = new System.Windows.Forms.Padding(0);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(83, 26);
            this.guardarButton.TabIndex = 2;
            this.guardarButton.Text = "Guardar";
            this.guardarButton.UseVisualStyleBackColor = false;
            this.guardarButton.Click += new System.EventHandler(this.guardarButton_Click);
            // 
            // WFSyncConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(767, 447);
            this.Controls.Add(this.guardarButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.habSyncCheckBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFSyncConfig";
            this.Text = "Configuración de sincronización";
            this.Load += new System.EventHandler(this.WFSyncConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox habSyncCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox limpiarNoSyncCheckBox;
        private System.Windows.Forms.CheckBox autoSyncCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox conexionTextBox;
        private System.Windows.Forms.RadioButton originalRadioButton;
        private System.Windows.Forms.RadioButton copiaRadioButton;
        private System.Windows.Forms.CheckBox cambioManualDeFechaCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button guardarButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox conexionEnRedTextBox;
        private System.Windows.Forms.Label ultimoCambioDateTime;
        private System.Windows.Forms.Label ultimaSyncDateTime;
    }
}