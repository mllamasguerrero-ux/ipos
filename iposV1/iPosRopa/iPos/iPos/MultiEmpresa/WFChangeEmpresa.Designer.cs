namespace iPos
{
    partial class WFChangeEmpresa
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFChangeEmpresa));
            this.label4_EMPRESAS = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbChangeCompany = new System.Windows.Forms.ComboBox();
            this.btnChangeCompany = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FbConnection1_EMPRESAS = new FirebirdSql.Data.FirebirdClient.FbConnection();
            this.FbCommand1_EMPRESAS = new FirebirdSql.Data.FirebirdClient.FbCommand();
            this.bindingSource1_EMPRESAS = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_EMPRESAS)).BeginInit();
            this.SuspendLayout();
            // 
            // label4_EMPRESAS
            // 
            this.label4_EMPRESAS.AutoSize = true;
            this.label4_EMPRESAS.BackColor = System.Drawing.Color.Transparent;
            this.label4_EMPRESAS.Font = new System.Drawing.Font("Lucida Sans Unicode", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4_EMPRESAS.ForeColor = System.Drawing.Color.White;
            this.label4_EMPRESAS.Location = new System.Drawing.Point(34, 9);
            this.label4_EMPRESAS.Name = "label4_EMPRESAS";
            this.label4_EMPRESAS.Size = new System.Drawing.Size(476, 59);
            this.label4_EMPRESAS.TabIndex = 21;
            this.label4_EMPRESAS.Text = "CAMBIAR EMPRESA";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cmbChangeCompany);
            this.panel1.Controls.Add(this.btnChangeCompany);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(523, 223);
            this.panel1.TabIndex = 23;
            // 
            // cmbChangeCompany
            // 
            this.cmbChangeCompany.FormattingEnabled = true;
            this.cmbChangeCompany.Location = new System.Drawing.Point(95, 87);
            this.cmbChangeCompany.Name = "cmbChangeCompany";
            this.cmbChangeCompany.Size = new System.Drawing.Size(325, 21);
            this.cmbChangeCompany.TabIndex = 25;
            // 
            // btnChangeCompany
            // 
            this.btnChangeCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeCompany.ForeColor = System.Drawing.Color.White;
            this.btnChangeCompany.Location = new System.Drawing.Point(216, 148);
            this.btnChangeCompany.Name = "btnChangeCompany";
            this.btnChangeCompany.Size = new System.Drawing.Size(75, 23);
            this.btnChangeCompany.TabIndex = 24;
            this.btnChangeCompany.Text = "Cambiar";
            this.btnChangeCompany.UseVisualStyleBackColor = true;
            this.btnChangeCompany.Click += new System.EventHandler(this.btnChangeCompany_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(91, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 25);
            this.label1.TabIndex = 23;
            this.label1.Text = "Seleccione la Empresa:";
            // 
            // FbConnection1_EMPRESAS
            // 
            this.FbConnection1_EMPRESAS.ConnectionString = "Data Source=manuel;Initial Catalog=generador;Persist Security Info=True;User ID=s" +
    "a;Password=Twincept";
            // 
            // FbCommand1_EMPRESAS
            // 
            this.FbCommand1_EMPRESAS.CommandText = "Select e.EM_NOMBRE,case when c.CF_ID is null then \'NO\' else \'SI\' end EM_DEFAULT f" +
    "rom EMPRESAS e left join CONFIGURACION c on e.em_nombre = c.CF_DEFAULT_DB where " +
    " 1 = 1 ";
            this.FbCommand1_EMPRESAS.CommandTimeout = 30;
            this.FbCommand1_EMPRESAS.Connection = this.FbConnection1_EMPRESAS;
            // 
            // WFChangeEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.fondo_con_logo_ipos_2_0;
            this.ClientSize = new System.Drawing.Size(545, 306);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4_EMPRESAS);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFChangeEmpresa";
            this.Text = "Cambia Empresa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WFChangeEmpresa_FormClosing);
            this.Load += new System.EventHandler(this.WFChangeEmpresa_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_EMPRESAS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4_EMPRESAS;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnChangeCompany;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbChangeCompany;
        private FirebirdSql.Data.FirebirdClient.FbConnection FbConnection1_EMPRESAS;
        private FirebirdSql.Data.FirebirdClient.FbCommand FbCommand1_EMPRESAS;
        private System.Windows.Forms.BindingSource bindingSource1_EMPRESAS;
    }
}