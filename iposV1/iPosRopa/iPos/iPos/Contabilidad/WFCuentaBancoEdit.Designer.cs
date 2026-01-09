
namespace iPos
{
    partial class WFCuentaBancoEdit
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
            FirebirdSql.Data.FirebirdClient.FbParameter fbParameter1 = new FirebirdSql.Data.FirebirdClient.FbParameter();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.LBError = new System.Windows.Forms.Label();
            this.FbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            this.FbCommand1 = new FirebirdSql.Data.FirebirdClient.FbCommand();
            this.BTCancelar = new System.Windows.Forms.Button();
            this.BTIniciaEdicion = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.NOCUENTATextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RFCTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BANCOIDButton = new System.Windows.Forms.Button();
            this.BANCOIDTextBox = new iPos.Tools.TextBoxFB();
            this.BANCOIDLabel = new System.Windows.Forms.Label();
            this.ACTIVOTextBox = new System.Windows.Forms.CheckBox();
            this.ACTIVOLabel = new System.Windows.Forms.Label();
            this.NOMBRELabel = new System.Windows.Forms.Label();
            this.NOMBRETextBox = new System.Windows.Forms.TextBox();
            this.IDLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.PREDETERMINADATextBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // IDTextBox
            // 
            this.IDTextBox.Enabled = false;
            this.IDTextBox.Location = new System.Drawing.Point(190, 17);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(204, 20);
            this.IDTextBox.TabIndex = 1;
            this.IDTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.CLAVETextBox_Validating);
            // 
            // LBError
            // 
            this.LBError.AutoSize = true;
            this.LBError.ForeColor = System.Drawing.Color.Red;
            this.LBError.Location = new System.Drawing.Point(26, 20);
            this.LBError.Name = "LBError";
            this.LBError.Size = new System.Drawing.Size(10, 13);
            this.LBError.TabIndex = 44;
            this.LBError.Text = "-";
            // 
            // FbConnection1
            // 
            this.FbConnection1.ConnectionString = "Data Source=manuel;Initial Catalog=generador;Persist Security Info=True;User ID=s" +
    "a;Password=Twincept";
            // 
            // FbCommand1
            // 
            this.FbCommand1.CommandText = "select * from LINEA  where 1=1  and ID=@ID  and  1= 1 ";
            this.FbCommand1.CommandTimeout = 30;
            this.FbCommand1.Connection = this.FbConnection1;
            fbParameter1.FbDbType = FirebirdSql.Data.FirebirdClient.FbDbType.BigInt;
            fbParameter1.ParameterName = "@ID";
            this.FbCommand1.Parameters.AddRange(new FirebirdSql.Data.FirebirdClient.FbParameter[] {
            fbParameter1});
            // 
            // BTCancelar
            // 
            this.BTCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTCancelar.ForeColor = System.Drawing.Color.White;
            this.BTCancelar.Image = global::iPos.Properties.Resources.cancel_J;
            this.BTCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTCancelar.Location = new System.Drawing.Point(282, 272);
            this.BTCancelar.Name = "BTCancelar";
            this.BTCancelar.Size = new System.Drawing.Size(112, 30);
            this.BTCancelar.TabIndex = 47;
            this.BTCancelar.Text = "Cancelar";
            this.BTCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTCancelar.UseVisualStyleBackColor = false;
            this.BTCancelar.Click += new System.EventHandler(this.BTCancelar_Click);
            // 
            // BTIniciaEdicion
            // 
            this.BTIniciaEdicion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTIniciaEdicion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTIniciaEdicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTIniciaEdicion.ForeColor = System.Drawing.Color.White;
            this.BTIniciaEdicion.Location = new System.Drawing.Point(88, 276);
            this.BTIniciaEdicion.Name = "BTIniciaEdicion";
            this.BTIniciaEdicion.Size = new System.Drawing.Size(57, 23);
            this.BTIniciaEdicion.TabIndex = 46;
            this.BTIniciaEdicion.Text = "Editar";
            this.BTIniciaEdicion.UseVisualStyleBackColor = false;
            this.BTIniciaEdicion.Visible = false;
            this.BTIniciaEdicion.Click += new System.EventHandler(this.BTIniciaEdicion_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.PREDETERMINADATextBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.NOCUENTATextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.RFCTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BANCOIDButton);
            this.panel1.Controls.Add(this.BANCOIDTextBox);
            this.panel1.Controls.Add(this.BANCOIDLabel);
            this.panel1.Controls.Add(this.ACTIVOTextBox);
            this.panel1.Controls.Add(this.ACTIVOLabel);
            this.panel1.Controls.Add(this.NOMBRELabel);
            this.panel1.Controls.Add(this.NOMBRETextBox);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(6, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 223);
            this.panel1.TabIndex = 2;
            this.panel1.TabStop = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(85, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 189;
            this.label3.Text = "No Cuenta:";
            // 
            // NOCUENTATextBox
            // 
            this.NOCUENTATextBox.Location = new System.Drawing.Point(184, 135);
            this.NOCUENTATextBox.Name = "NOCUENTATextBox";
            this.NOCUENTATextBox.Size = new System.Drawing.Size(204, 20);
            this.NOCUENTATextBox.TabIndex = 190;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(85, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 187;
            this.label2.Text = "Rfc:";
            // 
            // RFCTextBox
            // 
            this.RFCTextBox.Location = new System.Drawing.Point(184, 100);
            this.RFCTextBox.Name = "RFCTextBox";
            this.RFCTextBox.Size = new System.Drawing.Size(204, 20);
            this.RFCTextBox.TabIndex = 188;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(83, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 186;
            this.label1.Text = "Banco:";
            // 
            // BANCOIDButton
            // 
            this.BANCOIDButton.AccessibleDescription = "";
            this.BANCOIDButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.BANCOIDButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BANCOIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BANCOIDButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BANCOIDButton.Location = new System.Drawing.Point(269, 68);
            this.BANCOIDButton.Name = "BANCOIDButton";
            this.BANCOIDButton.Size = new System.Drawing.Size(21, 23);
            this.BANCOIDButton.TabIndex = 184;
            this.BANCOIDButton.UseVisualStyleBackColor = true;
            // 
            // BANCOIDTextBox
            // 
            this.BANCOIDTextBox.AccessibleDescription = "";
            this.BANCOIDTextBox.BotonLookUp = this.BANCOIDButton;
            this.BANCOIDTextBox.Condicion = null;
            this.BANCOIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.BANCOIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.BANCOIDTextBox.DbValue = null;
            this.BANCOIDTextBox.Format_Expression = null;
            this.BANCOIDTextBox.IndiceCampoDescripcion = 2;
            this.BANCOIDTextBox.IndiceCampoSelector = 1;
            this.BANCOIDTextBox.IndiceCampoValue = 0;
            this.BANCOIDTextBox.LabelDescription = this.BANCOIDLabel;
            this.BANCOIDTextBox.Location = new System.Drawing.Point(184, 69);
            this.BANCOIDTextBox.MostrarErrores = true;
            this.BANCOIDTextBox.Name = "BANCOIDTextBox";
            this.BANCOIDTextBox.NombreCampoSelector = "clave";
            this.BANCOIDTextBox.NombreCampoValue = "id";
            this.BANCOIDTextBox.Query = "select id,clave,nombre from bancos";
            this.BANCOIDTextBox.QueryDeSeleccion = "select id,clave,nombre from bancos where clave = @clave";
            this.BANCOIDTextBox.QueryPorDBValue = "select id,clave,nombre from bancos where id = @id";
            this.BANCOIDTextBox.Size = new System.Drawing.Size(82, 20);
            this.BANCOIDTextBox.TabIndex = 183;
            this.BANCOIDTextBox.Tag = 34;
            this.BANCOIDTextBox.TextDescription = null;
            this.BANCOIDTextBox.Titulo = "Bancos";
            this.BANCOIDTextBox.ValidarEntrada = true;
            this.BANCOIDTextBox.ValidationExpression = null;
            // 
            // BANCOIDLabel
            // 
            this.BANCOIDLabel.AccessibleDescription = "";
            this.BANCOIDLabel.AutoSize = true;
            this.BANCOIDLabel.ForeColor = System.Drawing.Color.White;
            this.BANCOIDLabel.Location = new System.Drawing.Point(296, 72);
            this.BANCOIDLabel.Name = "BANCOIDLabel";
            this.BANCOIDLabel.Size = new System.Drawing.Size(16, 13);
            this.BANCOIDLabel.TabIndex = 185;
            this.BANCOIDLabel.Text = "...";
            // 
            // ACTIVOTextBox
            // 
            this.ACTIVOTextBox.AutoSize = true;
            this.ACTIVOTextBox.Location = new System.Drawing.Point(184, 41);
            this.ACTIVOTextBox.Name = "ACTIVOTextBox";
            this.ACTIVOTextBox.Size = new System.Drawing.Size(15, 14);
            this.ACTIVOTextBox.TabIndex = 5;
            this.ACTIVOTextBox.UseVisualStyleBackColor = true;
            // 
            // ACTIVOLabel
            // 
            this.ACTIVOLabel.AutoSize = true;
            this.ACTIVOLabel.BackColor = System.Drawing.Color.Transparent;
            this.ACTIVOLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ACTIVOLabel.ForeColor = System.Drawing.Color.White;
            this.ACTIVOLabel.Location = new System.Drawing.Point(85, 42);
            this.ACTIVOLabel.Name = "ACTIVOLabel";
            this.ACTIVOLabel.Size = new System.Drawing.Size(47, 13);
            this.ACTIVOLabel.TabIndex = 1;
            this.ACTIVOLabel.Text = "Activo:";
            // 
            // NOMBRELabel
            // 
            this.NOMBRELabel.AutoSize = true;
            this.NOMBRELabel.BackColor = System.Drawing.Color.Transparent;
            this.NOMBRELabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NOMBRELabel.ForeColor = System.Drawing.Color.White;
            this.NOMBRELabel.Location = new System.Drawing.Point(85, 10);
            this.NOMBRELabel.Name = "NOMBRELabel";
            this.NOMBRELabel.Size = new System.Drawing.Size(54, 13);
            this.NOMBRELabel.TabIndex = 1;
            this.NOMBRELabel.Text = "Nombre:";
            // 
            // NOMBRETextBox
            // 
            this.NOMBRETextBox.Location = new System.Drawing.Point(184, 7);
            this.NOMBRETextBox.Name = "NOMBRETextBox";
            this.NOMBRETextBox.Size = new System.Drawing.Size(204, 20);
            this.NOMBRETextBox.TabIndex = 2;
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.BackColor = System.Drawing.Color.Transparent;
            this.IDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDLabel.ForeColor = System.Drawing.Color.White;
            this.IDLabel.Location = new System.Drawing.Point(97, 21);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(24, 13);
            this.IDLabel.TabIndex = 1;
            this.IDLabel.Text = "ID:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::iPos.Properties.Resources.saveNoBack_J;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(151, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PREDETERMINADATextBox
            // 
            this.PREDETERMINADATextBox.AutoSize = true;
            this.PREDETERMINADATextBox.Location = new System.Drawing.Point(194, 179);
            this.PREDETERMINADATextBox.Name = "PREDETERMINADATextBox";
            this.PREDETERMINADATextBox.Size = new System.Drawing.Size(15, 14);
            this.PREDETERMINADATextBox.TabIndex = 192;
            this.PREDETERMINADATextBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(85, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 191;
            this.label4.Text = "Predeterminada :";
            // 
            // WFCuentaBancoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(510, 321);
            this.Controls.Add(this.BTCancelar);
            this.Controls.Add(this.BTIniciaEdicion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.IDTextBox);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "WFCuentaBancoEdit";
            this.Text = "CUENTA BANCO";
            this.Load += new System.EventHandler(this.LINEAEdit_Reg_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

  }

  #endregion



        private System.Windows.Forms.TextBox IDTextBox;


        private System.Windows.Forms.TextBox NOMBRETextBox;
        private System.Windows.Forms.Panel panel1;
  
  private FirebirdSql.Data.FirebirdClient.FbConnection FbConnection1;
  private FirebirdSql.Data.FirebirdClient.FbCommand FbCommand1;
  private System.Windows.Forms.Button button1;
  private System.Windows.Forms.Label LBError;



        private System.Windows.Forms.Label ACTIVOLabel;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Label NOMBRELabel;
        private System.Windows.Forms.Button BTIniciaEdicion;
        private System.Windows.Forms.CheckBox ACTIVOTextBox;
        private System.Windows.Forms.Button BTCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BANCOIDButton;
        private Tools.TextBoxFB BANCOIDTextBox;
        private System.Windows.Forms.Label BANCOIDLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NOCUENTATextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RFCTextBox;
        private System.Windows.Forms.CheckBox PREDETERMINADATextBox;
        private System.Windows.Forms.Label label4;
    }
}

