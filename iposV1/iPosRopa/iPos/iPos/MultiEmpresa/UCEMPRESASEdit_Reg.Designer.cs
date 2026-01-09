
namespace iPos
{
    partial class UCEMPRESASEdit_Reg
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
            this.EM_NOMBRELabel = new System.Windows.Forms.Label();
            this.EM_DATABASELabel = new System.Windows.Forms.Label();
            this.EM_USUARIOLabel = new System.Windows.Forms.Label();
            this.EM_PASSWORDLabel = new System.Windows.Forms.Label();
            this.EM_SERVERLabel = new System.Windows.Forms.Label();
            this.LBError = new System.Windows.Forms.Label();
            this.FbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            this.FbCommand1 = new FirebirdSql.Data.FirebirdClient.FbCommand();
            this.button1 = new System.Windows.Forms.Button();
            this.requiredFieldValidator1 = new CustomValidation.RequiredFieldValidator();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CBCustomConn = new System.Windows.Forms.CheckBox();
            this.GBConecctionData = new System.Windows.Forms.GroupBox();
            this.pnlColor = new System.Windows.Forms.Panel();
            this.btnColor = new System.Windows.Forms.Button();
            this.ESMATRIZCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BTRefreshComboCaja = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.HABILITAR_IMPEXP_AUTCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EM_CAJAComboBox = new System.Windows.Forms.ComboBox();
            this.BTExaminar = new System.Windows.Forms.Button();
            this.EM_SERVERTextBox = new System.Windows.Forms.TextBoxET();
            this.EM_DATABASETextBox = new System.Windows.Forms.TextBoxET();
            this.EM_PASSWORDTextBox = new System.Windows.Forms.TextBoxET();
            this.EM_USUARIOTextBox = new System.Windows.Forms.TextBoxET();
            this.btEliminar = new System.Windows.Forms.Button();
            this.OpenFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.EM_NOMBRETextBox = new System.Windows.Forms.TextBoxET();
            this.RFV_EM_NOMBRE = new CustomValidation.RequiredFieldValidator();
            this.panel1.SuspendLayout();
            this.GBConecctionData.SuspendLayout();
            this.SuspendLayout();
            // 
            // EM_NOMBRELabel
            // 
            this.EM_NOMBRELabel.AutoSize = true;
            this.EM_NOMBRELabel.BackColor = System.Drawing.Color.Transparent;
            this.EM_NOMBRELabel.Location = new System.Drawing.Point(57, 7);
            this.EM_NOMBRELabel.Name = "EM_NOMBRELabel";
            this.EM_NOMBRELabel.Size = new System.Drawing.Size(54, 13);
            this.EM_NOMBRELabel.TabIndex = 1;
            this.EM_NOMBRELabel.Text = "Nombre:";
            // 
            // EM_DATABASELabel
            // 
            this.EM_DATABASELabel.AutoSize = true;
            this.EM_DATABASELabel.BackColor = System.Drawing.Color.Transparent;
            this.EM_DATABASELabel.Location = new System.Drawing.Point(25, 12);
            this.EM_DATABASELabel.Name = "EM_DATABASELabel";
            this.EM_DATABASELabel.Size = new System.Drawing.Size(94, 13);
            this.EM_DATABASELabel.TabIndex = 1;
            this.EM_DATABASELabel.Text = "Database path:";
            // 
            // EM_USUARIOLabel
            // 
            this.EM_USUARIOLabel.AutoSize = true;
            this.EM_USUARIOLabel.BackColor = System.Drawing.Color.Transparent;
            this.EM_USUARIOLabel.Location = new System.Drawing.Point(65, 35);
            this.EM_USUARIOLabel.Name = "EM_USUARIOLabel";
            this.EM_USUARIOLabel.Size = new System.Drawing.Size(54, 13);
            this.EM_USUARIOLabel.TabIndex = 1;
            this.EM_USUARIOLabel.Text = "Usuario:";
            // 
            // EM_PASSWORDLabel
            // 
            this.EM_PASSWORDLabel.AutoSize = true;
            this.EM_PASSWORDLabel.BackColor = System.Drawing.Color.Transparent;
            this.EM_PASSWORDLabel.Location = new System.Drawing.Point(54, 58);
            this.EM_PASSWORDLabel.Name = "EM_PASSWORDLabel";
            this.EM_PASSWORDLabel.Size = new System.Drawing.Size(65, 13);
            this.EM_PASSWORDLabel.TabIndex = 1;
            this.EM_PASSWORDLabel.Text = "Password:";
            // 
            // EM_SERVERLabel
            // 
            this.EM_SERVERLabel.AutoSize = true;
            this.EM_SERVERLabel.BackColor = System.Drawing.Color.Transparent;
            this.EM_SERVERLabel.Location = new System.Drawing.Point(71, 82);
            this.EM_SERVERLabel.Name = "EM_SERVERLabel";
            this.EM_SERVERLabel.Size = new System.Drawing.Size(48, 13);
            this.EM_SERVERLabel.TabIndex = 1;
            this.EM_SERVERLabel.Text = "Server:";
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
            this.FbCommand1.CommandText = "select * from EMPRESAS  where 1=1  and EM_NOMBRE=@EM_NOMBRE  and  1= 1 ";
            this.FbCommand1.CommandTimeout = 30;
            this.FbCommand1.Connection = this.FbConnection1;
            fbParameter1.ParameterName = "@EM_NOMBRE";
            this.FbCommand1.Parameters.AddRange(new FirebirdSql.Data.FirebirdClient.FbParameter[] {
            fbParameter1});
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(318, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 23);
            this.button1.TabIndex = 43;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.Enabled = true;
            this.requiredFieldValidator1.Icon = null;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(243, 212);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 23);
            this.button2.TabIndex = 44;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.CBCustomConn);
            this.panel1.Controls.Add(this.GBConecctionData);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 179);
            this.panel1.TabIndex = 45;
            // 
            // CBCustomConn
            // 
            this.CBCustomConn.AutoSize = true;
            this.CBCustomConn.BackColor = System.Drawing.Color.Transparent;
            this.CBCustomConn.Checked = true;
            this.CBCustomConn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBCustomConn.Location = new System.Drawing.Point(8, 6);
            this.CBCustomConn.Name = "CBCustomConn";
            this.CBCustomConn.Size = new System.Drawing.Size(221, 17);
            this.CBCustomConn.TabIndex = 3;
            this.CBCustomConn.Text = "Datos Personalizados de conexion";
            this.CBCustomConn.UseVisualStyleBackColor = false;
            this.CBCustomConn.Visible = false;
            this.CBCustomConn.Validated += new System.EventHandler(this.CBDefault_Validated);
            // 
            // GBConecctionData
            // 
            this.GBConecctionData.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.GBConecctionData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GBConecctionData.Controls.Add(this.pnlColor);
            this.GBConecctionData.Controls.Add(this.btnColor);
            this.GBConecctionData.Controls.Add(this.ESMATRIZCheckBox);
            this.GBConecctionData.Controls.Add(this.label3);
            this.GBConecctionData.Controls.Add(this.BTRefreshComboCaja);
            this.GBConecctionData.Controls.Add(this.label2);
            this.GBConecctionData.Controls.Add(this.HABILITAR_IMPEXP_AUTCheckBox);
            this.GBConecctionData.Controls.Add(this.label1);
            this.GBConecctionData.Controls.Add(this.EM_CAJAComboBox);
            this.GBConecctionData.Controls.Add(this.BTExaminar);
            this.GBConecctionData.Controls.Add(this.EM_DATABASELabel);
            this.GBConecctionData.Controls.Add(this.EM_SERVERTextBox);
            this.GBConecctionData.Controls.Add(this.EM_DATABASETextBox);
            this.GBConecctionData.Controls.Add(this.EM_SERVERLabel);
            this.GBConecctionData.Controls.Add(this.EM_USUARIOLabel);
            this.GBConecctionData.Controls.Add(this.EM_PASSWORDTextBox);
            this.GBConecctionData.Controls.Add(this.EM_USUARIOTextBox);
            this.GBConecctionData.Controls.Add(this.EM_PASSWORDLabel);
            this.GBConecctionData.Location = new System.Drawing.Point(3, 22);
            this.GBConecctionData.Name = "GBConecctionData";
            this.GBConecctionData.Size = new System.Drawing.Size(439, 154);
            this.GBConecctionData.TabIndex = 4;
            this.GBConecctionData.TabStop = false;
            // 
            // pnlColor
            // 
            this.pnlColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.pnlColor.Location = new System.Drawing.Point(326, 128);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(43, 22);
            this.pnlColor.TabIndex = 20;
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.ForeColor = System.Drawing.Color.White;
            this.btnColor.Location = new System.Drawing.Point(375, 126);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(56, 23);
            this.btnColor.TabIndex = 19;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // ESMATRIZCheckBox
            // 
            this.ESMATRIZCheckBox.AutoSize = true;
            this.ESMATRIZCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.ESMATRIZCheckBox.Location = new System.Drawing.Point(265, 132);
            this.ESMATRIZCheckBox.Name = "ESMATRIZCheckBox";
            this.ESMATRIZCheckBox.Size = new System.Drawing.Size(15, 14);
            this.ESMATRIZCheckBox.TabIndex = 18;
            this.ESMATRIZCheckBox.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(197, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = " Es matriz";
            // 
            // BTRefreshComboCaja
            // 
            this.BTRefreshComboCaja.BackColor = System.Drawing.Color.Transparent;
            this.BTRefreshComboCaja.BackgroundImage = global::iPos.Properties.Resources.refresh_J;
            this.BTRefreshComboCaja.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTRefreshComboCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTRefreshComboCaja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTRefreshComboCaja.Location = new System.Drawing.Point(360, 105);
            this.BTRefreshComboCaja.Name = "BTRefreshComboCaja";
            this.BTRefreshComboCaja.Size = new System.Drawing.Size(26, 23);
            this.BTRefreshComboCaja.TabIndex = 16;
            this.BTRefreshComboCaja.UseVisualStyleBackColor = false;
            this.BTRefreshComboCaja.Click += new System.EventHandler(this.BTRefreshComboCaja_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(83, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Caja:";
            // 
            // HABILITAR_IMPEXP_AUTCheckBox
            // 
            this.HABILITAR_IMPEXP_AUTCheckBox.AutoSize = true;
            this.HABILITAR_IMPEXP_AUTCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.HABILITAR_IMPEXP_AUTCheckBox.Location = new System.Drawing.Point(126, 132);
            this.HABILITAR_IMPEXP_AUTCheckBox.Name = "HABILITAR_IMPEXP_AUTCheckBox";
            this.HABILITAR_IMPEXP_AUTCheckBox.Size = new System.Drawing.Size(15, 14);
            this.HABILITAR_IMPEXP_AUTCheckBox.TabIndex = 17;
            this.HABILITAR_IMPEXP_AUTCheckBox.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(6, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Hab. IMP/EXP Aut.";
            // 
            // EM_CAJAComboBox
            // 
            this.EM_CAJAComboBox.DisplayMember = "NOMBRE";
            this.EM_CAJAComboBox.FormattingEnabled = true;
            this.EM_CAJAComboBox.Location = new System.Drawing.Point(126, 105);
            this.EM_CAJAComboBox.Name = "EM_CAJAComboBox";
            this.EM_CAJAComboBox.Size = new System.Drawing.Size(233, 21);
            this.EM_CAJAComboBox.TabIndex = 9;
            this.EM_CAJAComboBox.ValueMember = "ID";
            // 
            // BTExaminar
            // 
            this.BTExaminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTExaminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTExaminar.ForeColor = System.Drawing.Color.White;
            this.BTExaminar.Location = new System.Drawing.Point(393, 8);
            this.BTExaminar.Name = "BTExaminar";
            this.BTExaminar.Size = new System.Drawing.Size(38, 21);
            this.BTExaminar.TabIndex = 5;
            this.BTExaminar.Text = "...";
            this.BTExaminar.UseVisualStyleBackColor = false;
            this.BTExaminar.Click += new System.EventHandler(this.BTExaminar_Click);
            // 
            // EM_SERVERTextBox
            // 
            this.EM_SERVERTextBox.Format_Expression = null;
            this.EM_SERVERTextBox.Location = new System.Drawing.Point(125, 79);
            this.EM_SERVERTextBox.Name = "EM_SERVERTextBox";
            this.EM_SERVERTextBox.Size = new System.Drawing.Size(266, 20);
            this.EM_SERVERTextBox.TabIndex = 8;
            this.EM_SERVERTextBox.Tag = 34;
            this.EM_SERVERTextBox.ValidationExpression = null;
            // 
            // EM_DATABASETextBox
            // 
            this.EM_DATABASETextBox.Format_Expression = null;
            this.EM_DATABASETextBox.Location = new System.Drawing.Point(125, 9);
            this.EM_DATABASETextBox.Name = "EM_DATABASETextBox";
            this.EM_DATABASETextBox.Size = new System.Drawing.Size(266, 20);
            this.EM_DATABASETextBox.TabIndex = 5;
            this.EM_DATABASETextBox.Tag = 34;
            this.EM_DATABASETextBox.ValidationExpression = null;
            // 
            // EM_PASSWORDTextBox
            // 
            this.EM_PASSWORDTextBox.Format_Expression = null;
            this.EM_PASSWORDTextBox.Location = new System.Drawing.Point(125, 55);
            this.EM_PASSWORDTextBox.Name = "EM_PASSWORDTextBox";
            this.EM_PASSWORDTextBox.Size = new System.Drawing.Size(266, 20);
            this.EM_PASSWORDTextBox.TabIndex = 7;
            this.EM_PASSWORDTextBox.Tag = 34;
            this.EM_PASSWORDTextBox.ValidationExpression = null;
            // 
            // EM_USUARIOTextBox
            // 
            this.EM_USUARIOTextBox.Format_Expression = null;
            this.EM_USUARIOTextBox.Location = new System.Drawing.Point(125, 32);
            this.EM_USUARIOTextBox.Name = "EM_USUARIOTextBox";
            this.EM_USUARIOTextBox.Size = new System.Drawing.Size(266, 20);
            this.EM_USUARIOTextBox.TabIndex = 6;
            this.EM_USUARIOTextBox.Tag = 34;
            this.EM_USUARIOTextBox.ValidationExpression = null;
            // 
            // btEliminar
            // 
            this.btEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btEliminar.Enabled = false;
            this.btEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEliminar.ForeColor = System.Drawing.Color.White;
            this.btEliminar.Location = new System.Drawing.Point(156, 212);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(63, 23);
            this.btEliminar.TabIndex = 46;
            this.btEliminar.Text = "Eliminar";
            this.btEliminar.UseVisualStyleBackColor = false;
            this.btEliminar.Visible = false;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // OpenFileDialog2
            // 
            this.OpenFileDialog2.FileName = "OpenFileDialog2";
            this.OpenFileDialog2.Filter = "Firebird (*.fdb)|*.fdb|Todos los archivos (*.*)|*.*";
            // 
            // EM_NOMBRETextBox
            // 
            this.EM_NOMBRETextBox.Format_Expression = null;
            this.EM_NOMBRETextBox.Location = new System.Drawing.Point(125, 4);
            this.EM_NOMBRETextBox.Name = "EM_NOMBRETextBox";
            this.EM_NOMBRETextBox.Size = new System.Drawing.Size(264, 20);
            this.EM_NOMBRETextBox.TabIndex = 2;
            this.EM_NOMBRETextBox.Tag = 34;
            this.EM_NOMBRETextBox.ValidationExpression = null;
            this.EM_NOMBRETextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EM_NOMBRETextBox_KeyDown);
            this.EM_NOMBRETextBox.Validated += new System.EventHandler(this.EM_NOMBRETextBox_Validated);
            // 
            // RFV_EM_NOMBRE
            // 
            this.RFV_EM_NOMBRE.ControlToValidate = this.EM_NOMBRETextBox;
            this.RFV_EM_NOMBRE.Enabled = true;
            this.RFV_EM_NOMBRE.ErrorMessage = "Se requiere el campo EM_NOMBRE";
            this.RFV_EM_NOMBRE.Icon = null;
            // 
            // UCEMPRESASEdit_Reg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.EM_NOMBRELabel);
            this.Controls.Add(this.EM_NOMBRETextBox);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Name = "UCEMPRESASEdit_Reg";
            this.Size = new System.Drawing.Size(454, 241);
            this.Load += new System.EventHandler(this.EMPRESASEdit_Reg_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.GBConecctionData.ResumeLayout(false);
            this.GBConecctionData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

  }
  #endregion
        private System.Windows.Forms.TextBoxET EM_NOMBRETextBox;
        private System.Windows.Forms.TextBoxET EM_DATABASETextBox;
        private System.Windows.Forms.TextBoxET EM_USUARIOTextBox;
        private System.Windows.Forms.TextBoxET EM_PASSWORDTextBox;
        private System.Windows.Forms.TextBoxET EM_SERVERTextBox;
  private System.Windows.Forms.Button button2;
  private System.Windows.Forms.Panel panel1;
  private System.Windows.Forms.Button btEliminar;
  
  private FirebirdSql.Data.FirebirdClient.FbConnection FbConnection1;
  private FirebirdSql.Data.FirebirdClient.FbCommand FbCommand1;
  private System.Windows.Forms.Button button1;
  private System.Windows.Forms.Label LBError;
  private CustomValidation.RequiredFieldValidator requiredFieldValidator1;
        private CustomValidation.RequiredFieldValidator RFV_EM_NOMBRE;
        private System.Windows.Forms.Label EM_NOMBRELabel;
        private System.Windows.Forms.Label EM_DATABASELabel;
        private System.Windows.Forms.Label EM_USUARIOLabel;
        private System.Windows.Forms.Label EM_PASSWORDLabel;
        private System.Windows.Forms.Label EM_SERVERLabel;
        private System.Windows.Forms.CheckBox CBCustomConn;
        private System.Windows.Forms.GroupBox GBConecctionData;
        internal System.Windows.Forms.Button BTExaminar;
        internal System.Windows.Forms.OpenFileDialog OpenFileDialog2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox HABILITAR_IMPEXP_AUTCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTRefreshComboCaja;
        private System.Windows.Forms.ComboBox EM_CAJAComboBox;
        private System.Windows.Forms.CheckBox ESMATRIZCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlColor;
        private System.Windows.Forms.Button btnColor;
 
 
    }
}

