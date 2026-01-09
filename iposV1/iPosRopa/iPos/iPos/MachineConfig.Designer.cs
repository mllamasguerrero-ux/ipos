namespace iPos
{
    partial class MachineConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MachineConfig));
            this.panelConfig = new System.Windows.Forms.Panel();
            this.txtPathIpos = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPathIposServer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtServerMachineName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPathLocalServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtClientMachineName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdBtnClientType = new System.Windows.Forms.RadioButton();
            this.rdBtnServerType = new System.Windows.Forms.RadioButton();
            this.txtCompanyKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveConfiguration = new System.Windows.Forms.Button();
            this.panelConfig.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelConfig
            // 
            this.panelConfig.BackColor = System.Drawing.Color.Transparent;
            this.panelConfig.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelConfig.Controls.Add(this.txtPathIpos);
            this.panelConfig.Controls.Add(this.label6);
            this.panelConfig.Controls.Add(this.groupBox1);
            this.panelConfig.Controls.Add(this.txtCompanyKey);
            this.panelConfig.Controls.Add(this.label1);
            this.panelConfig.Location = new System.Drawing.Point(8, 13);
            this.panelConfig.Name = "panelConfig";
            this.panelConfig.Size = new System.Drawing.Size(638, 335);
            this.panelConfig.TabIndex = 3;
            // 
            // txtPathIpos
            // 
            this.txtPathIpos.Location = new System.Drawing.Point(206, 45);
            this.txtPathIpos.Name = "txtPathIpos";
            this.txtPathIpos.Size = new System.Drawing.Size(282, 20);
            this.txtPathIpos.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(26, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 24);
            this.label6.TabIndex = 3;
            this.label6.Text = "Ruta Ipos Instalador:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPathIposServer);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtServerMachineName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPathLocalServer);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtClientMachineName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rdBtnClientType);
            this.groupBox1.Controls.Add(this.rdBtnServerType);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(31, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 247);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Maquina";
            // 
            // txtPathIposServer
            // 
            this.txtPathIposServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPathIposServer.Location = new System.Drawing.Point(206, 88);
            this.txtPathIposServer.Name = "txtPathIposServer";
            this.txtPathIposServer.Size = new System.Drawing.Size(354, 24);
            this.txtPathIposServer.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(44, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ruta al Servidor Ipos:";
            // 
            // txtServerMachineName
            // 
            this.txtServerMachineName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServerMachineName.Location = new System.Drawing.Point(206, 58);
            this.txtServerMachineName.Name = "txtServerMachineName";
            this.txtServerMachineName.Size = new System.Drawing.Size(354, 24);
            this.txtServerMachineName.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(44, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nombre del Servidor:";
            // 
            // txtPathLocalServer
            // 
            this.txtPathLocalServer.Enabled = false;
            this.txtPathLocalServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPathLocalServer.Location = new System.Drawing.Point(206, 187);
            this.txtPathLocalServer.Name = "txtPathLocalServer";
            this.txtPathLocalServer.Size = new System.Drawing.Size(354, 24);
            this.txtPathLocalServer.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(44, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ruta al Servidor:";
            // 
            // txtClientMachineName
            // 
            this.txtClientMachineName.Enabled = false;
            this.txtClientMachineName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientMachineName.Location = new System.Drawing.Point(206, 149);
            this.txtClientMachineName.Name = "txtClientMachineName";
            this.txtClientMachineName.Size = new System.Drawing.Size(354, 24);
            this.txtClientMachineName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(44, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre de Maquina:";
            // 
            // rdBtnClientType
            // 
            this.rdBtnClientType.AutoSize = true;
            this.rdBtnClientType.Location = new System.Drawing.Point(35, 120);
            this.rdBtnClientType.Name = "rdBtnClientType";
            this.rdBtnClientType.Size = new System.Drawing.Size(76, 24);
            this.rdBtnClientType.TabIndex = 1;
            this.rdBtnClientType.Text = "Cliente";
            this.rdBtnClientType.UseVisualStyleBackColor = true;
            this.rdBtnClientType.CheckedChanged += new System.EventHandler(this.rdBtnClientType_CheckedChanged);
            // 
            // rdBtnServerType
            // 
            this.rdBtnServerType.AutoSize = true;
            this.rdBtnServerType.Checked = true;
            this.rdBtnServerType.Location = new System.Drawing.Point(35, 35);
            this.rdBtnServerType.Name = "rdBtnServerType";
            this.rdBtnServerType.Size = new System.Drawing.Size(85, 24);
            this.rdBtnServerType.TabIndex = 0;
            this.rdBtnServerType.TabStop = true;
            this.rdBtnServerType.Text = "Servidor";
            this.rdBtnServerType.UseVisualStyleBackColor = true;
            this.rdBtnServerType.CheckedChanged += new System.EventHandler(this.rdBtnServerType_CheckedChanged);
            // 
            // txtCompanyKey
            // 
            this.txtCompanyKey.Location = new System.Drawing.Point(206, 12);
            this.txtCompanyKey.Name = "txtCompanyKey";
            this.txtCompanyKey.Size = new System.Drawing.Size(282, 20);
            this.txtCompanyKey.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Llave de Empresa:";
            // 
            // btnSaveConfiguration
            // 
            this.btnSaveConfiguration.Location = new System.Drawing.Point(262, 356);
            this.btnSaveConfiguration.Name = "btnSaveConfiguration";
            this.btnSaveConfiguration.Size = new System.Drawing.Size(130, 34);
            this.btnSaveConfiguration.TabIndex = 4;
            this.btnSaveConfiguration.Text = "Guardar Configuración";
            this.btnSaveConfiguration.UseVisualStyleBackColor = true;
            this.btnSaveConfiguration.Click += new System.EventHandler(this.btnSaveConfiguration_Click);
            // 
            // MachineConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(654, 402);
            this.Controls.Add(this.btnSaveConfiguration);
            this.Controls.Add(this.panelConfig);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MachineConfig";
            this.Text = "Configuración de la Maquina";
            this.Load += new System.EventHandler(this.MachineConfig_Load);
            this.panelConfig.ResumeLayout(false);
            this.panelConfig.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelConfig;
        private System.Windows.Forms.TextBox txtPathIpos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPathIposServer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtServerMachineName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPathLocalServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtClientMachineName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdBtnClientType;
        private System.Windows.Forms.RadioButton rdBtnServerType;
        private System.Windows.Forms.TextBox txtCompanyKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveConfiguration;
    }
}