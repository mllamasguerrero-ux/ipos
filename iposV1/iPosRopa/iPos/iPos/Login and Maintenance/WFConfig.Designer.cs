namespace iPos
{
    partial class WFConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFConfig));
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Button1 = new System.Windows.Forms.Button();
            this.TBServidor = new System.Windows.Forms.TextBoxET();
            this.TBUsuario = new System.Windows.Forms.TextBoxET();
            this.TBPassword = new System.Windows.Forms.TextBoxET();
            this.TBBaseDatos = new System.Windows.Forms.TextBoxET();
            this.SuspendLayout();
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.Label6.ForeColor = System.Drawing.Color.White;
            this.Label6.Location = new System.Drawing.Point(53, 28);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(55, 15);
            this.Label6.TabIndex = 29;
            this.Label6.Text = "Servidor:";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.Label5.ForeColor = System.Drawing.Color.White;
            this.Label5.Location = new System.Drawing.Point(55, 84);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(53, 15);
            this.Label5.TabIndex = 27;
            this.Label5.Text = "Usuario:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.Label4.ForeColor = System.Drawing.Color.White;
            this.Label4.Location = new System.Drawing.Point(44, 111);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(64, 15);
            this.Label4.TabIndex = 25;
            this.Label4.Text = "Password:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.Label3.ForeColor = System.Drawing.Color.White;
            this.Label3.Location = new System.Drawing.Point(20, 54);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(88, 15);
            this.Label3.TabIndex = 23;
            this.Label3.Text = "Base de datos:";
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.Button1.ForeColor = System.Drawing.Color.White;
            this.Button1.Location = new System.Drawing.Point(96, 154);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 25);
            this.Button1.TabIndex = 5;
            this.Button1.Text = "Enviar";
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // TBServidor
            // 
            this.TBServidor.Format_Expression = null;
            this.TBServidor.Location = new System.Drawing.Point(114, 27);
            this.TBServidor.Name = "TBServidor";
            this.TBServidor.Size = new System.Drawing.Size(122, 20);
            this.TBServidor.TabIndex = 1;
            this.TBServidor.Tag = 34;
            this.TBServidor.ValidationExpression = null;
            // 
            // TBUsuario
            // 
            this.TBUsuario.Format_Expression = null;
            this.TBUsuario.Location = new System.Drawing.Point(114, 83);
            this.TBUsuario.Name = "TBUsuario";
            this.TBUsuario.Size = new System.Drawing.Size(122, 20);
            this.TBUsuario.TabIndex = 3;
            this.TBUsuario.Tag = 34;
            this.TBUsuario.ValidationExpression = null;
            // 
            // TBPassword
            // 
            this.TBPassword.Format_Expression = null;
            this.TBPassword.Location = new System.Drawing.Point(114, 110);
            this.TBPassword.Name = "TBPassword";
            this.TBPassword.Size = new System.Drawing.Size(122, 20);
            this.TBPassword.TabIndex = 4;
            this.TBPassword.Tag = 34;
            this.TBPassword.UseSystemPasswordChar = true;
            this.TBPassword.ValidationExpression = null;
            // 
            // TBBaseDatos
            // 
            this.TBBaseDatos.Format_Expression = null;
            this.TBBaseDatos.Location = new System.Drawing.Point(114, 53);
            this.TBBaseDatos.Name = "TBBaseDatos";
            this.TBBaseDatos.Size = new System.Drawing.Size(122, 20);
            this.TBBaseDatos.TabIndex = 2;
            this.TBBaseDatos.Tag = 34;
            this.TBBaseDatos.ValidationExpression = null;
            // 
            // WFConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(262, 184);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.TBServidor);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.TBUsuario);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.TBPassword);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.TBBaseDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFConfig";
            this.Text = "WFConfig";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.Load += new System.EventHandler(this.WFConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        internal System.Windows.Forms.TextBoxET TBServidor;
        internal System.Windows.Forms.TextBoxET TBUsuario;
        internal System.Windows.Forms.TextBoxET TBPassword;
        internal System.Windows.Forms.TextBoxET TBBaseDatos;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        //private Skinner.FormSkin formSkin1;
    }
}