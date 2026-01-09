namespace iPos
{
    partial class FLogin
    {
        
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.BTOtraEmpresa = new System.Windows.Forms.Button();
            this.LBEmpresaActual = new System.Windows.Forms.Label();
            this.dSAccessControl = new iPos.Login_and_Maintenance.DSAccessControl();
            this.tableAdapterManager = new iPos.Login_and_Maintenance.DSAccessControlTableAdapters.TableAdapterManager();
            this.bCancelar = new System.Windows.Forms.Button();
            this.TBPassUser = new System.Windows.Forms.TextBoxET();
            this.TBNameUser = new System.Windows.Forms.TextBoxET();
            this.btnCambiarEmpresa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dSAccessControl)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.label1.Location = new System.Drawing.Point(29, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "USUARIO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.label2.Location = new System.Drawing.Point(24, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "PASSWORD";
            // 
            // button1
            // 
            this.button1.AccessibleDescription = "resizeforscreen";
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(150)))), ((int)(((byte)(219)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.Location = new System.Drawing.Point(113, 249);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Entrar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BTOtraEmpresa
            // 
            this.BTOtraEmpresa.BackColor = System.Drawing.Color.Transparent;
            this.BTOtraEmpresa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTOtraEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTOtraEmpresa.ForeColor = System.Drawing.Color.White;
            this.BTOtraEmpresa.Image = global::iPos.Properties.Resources.settings;
            this.BTOtraEmpresa.Location = new System.Drawing.Point(390, 89);
            this.BTOtraEmpresa.Name = "BTOtraEmpresa";
            this.BTOtraEmpresa.Size = new System.Drawing.Size(41, 40);
            this.BTOtraEmpresa.TabIndex = 5;
            this.BTOtraEmpresa.UseVisualStyleBackColor = false;
            this.BTOtraEmpresa.Click += new System.EventHandler(this.BTOtraEmpresa_Click);
            // 
            // LBEmpresaActual
            // 
            this.LBEmpresaActual.AutoSize = true;
            this.LBEmpresaActual.BackColor = System.Drawing.Color.Transparent;
            this.LBEmpresaActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBEmpresaActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.LBEmpresaActual.Location = new System.Drawing.Point(3, 89);
            this.LBEmpresaActual.Name = "LBEmpresaActual";
            this.LBEmpresaActual.Size = new System.Drawing.Size(126, 13);
            this.LBEmpresaActual.TabIndex = 9;
            this.LBEmpresaActual.Text = "EMPRESA ACTUAL: ";
            // 
            // dSAccessControl
            // 
            this.dSAccessControl.DataSetName = "DSAccessControl";
            this.dSAccessControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.DERECHOS_USUARIOSTableAdapter = null;
            this.tableAdapterManager.PERFILES_DERECHOSTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = iPos.Login_and_Maintenance.DSAccessControlTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // bCancelar
            // 
            this.bCancelar.AccessibleDescription = "resizeforscreen";
            this.bCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(150)))), ((int)(((byte)(219)))));
            this.bCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.bCancelar.FlatAppearance.BorderSize = 0;
            this.bCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bCancelar.Location = new System.Drawing.Point(238, 249);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(100, 23);
            this.bCancelar.TabIndex = 4;
            this.bCancelar.Text = "Salir";
            this.bCancelar.UseVisualStyleBackColor = false;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // TBPassUser
            // 
            this.TBPassUser.AccessibleDescription = "resizeforscreen";
            this.TBPassUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBPassUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBPassUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.TBPassUser.Format_Expression = null;
            this.TBPassUser.Location = new System.Drawing.Point(108, 193);
            this.TBPassUser.Name = "TBPassUser";
            this.TBPassUser.PasswordChar = '*';
            this.TBPassUser.Size = new System.Drawing.Size(192, 17);
            this.TBPassUser.TabIndex = 2;
            this.TBPassUser.Tag = 34;
            this.TBPassUser.ValidationExpression = null;
            // 
            // TBNameUser
            // 
            this.TBNameUser.AccessibleDescription = "resizeforscreen";
            this.TBNameUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBNameUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBNameUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.TBNameUser.Format_Expression = null;
            this.TBNameUser.Location = new System.Drawing.Point(108, 130);
            this.TBNameUser.Name = "TBNameUser";
            this.TBNameUser.Size = new System.Drawing.Size(192, 17);
            this.TBNameUser.TabIndex = 1;
            this.TBNameUser.Tag = 34;
            this.TBNameUser.ValidationExpression = null;
            // 
            // btnCambiarEmpresa
            // 
            this.btnCambiarEmpresa.BackColor = System.Drawing.Color.Transparent;
            this.btnCambiarEmpresa.FlatAppearance.BorderSize = 0;
            this.btnCambiarEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarEmpresa.Image = global::iPos.Properties.Resources.changeEnterprise;
            this.btnCambiarEmpresa.Location = new System.Drawing.Point(375, 233);
            this.btnCambiarEmpresa.Name = "btnCambiarEmpresa";
            this.btnCambiarEmpresa.Size = new System.Drawing.Size(56, 55);
            this.btnCambiarEmpresa.TabIndex = 12;
            this.btnCambiarEmpresa.UseVisualStyleBackColor = false;
            this.btnCambiarEmpresa.Click += new System.EventHandler(this.btnCambiarEmpresa_Click);
            // 
            // FLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.BackgroundImage = global::iPos.Properties.Resources.LOGIN_IPOS_MATERIAL_DESIGN;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.bCancelar;
            this.ClientSize = new System.Drawing.Size(430, 295);
            this.ControlBox = false;
            this.Controls.Add(this.btnCambiarEmpresa);
            this.Controls.Add(this.bCancelar);
            this.Controls.Add(this.LBEmpresaActual);
            this.Controls.Add(this.BTOtraEmpresa);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBPassUser);
            this.Controls.Add(this.TBNameUser);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1024, 738);
            this.Name = "FLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.Load += new System.EventHandler(this.FLogin_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FLogin_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dSAccessControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.TextBoxET TBNameUser;
        private System.Windows.Forms.TextBoxET TBPassUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        //private Skinner.FormSkin formSkin1;
        private System.Windows.Forms.Button BTOtraEmpresa;
        private System.Windows.Forms.Label LBEmpresaActual;
        private Login_and_Maintenance.DSAccessControl dSAccessControl;
        private Login_and_Maintenance.DSAccessControlTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Button btnCambiarEmpresa;
    }
}