
namespace iPos
{
    partial class EMPRESASEdit_Reg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EMPRESASEdit_Reg));
            this.panel1 = new System.Windows.Forms.Panel();
            this.fixDbButton = new System.Windows.Forms.Button();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btEliminar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.GBConecctionData = new System.Windows.Forms.Panel();
            this.REPLICADORCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.HAB_POOLINGCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlColor = new System.Windows.Forms.Panel();
            this.EM_DATABASELabel = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.EM_PASSWORDLabel = new System.Windows.Forms.Label();
            this.ESMATRIZCheckBox = new System.Windows.Forms.CheckBox();
            this.EM_USUARIOTextBox = new System.Windows.Forms.TextBoxET();
            this.label3 = new System.Windows.Forms.Label();
            this.EM_PASSWORDTextBox = new System.Windows.Forms.TextBoxET();
            this.BTRefreshComboCaja = new System.Windows.Forms.Button();
            this.EM_USUARIOLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EM_SERVERLabel = new System.Windows.Forms.Label();
            this.HABILITAR_IMPEXP_AUTCheckBox = new System.Windows.Forms.CheckBox();
            this.EM_DATABASETextBox = new System.Windows.Forms.TextBoxET();
            this.label1 = new System.Windows.Forms.Label();
            this.EM_SERVERTextBox = new System.Windows.Forms.TextBoxET();
            this.EM_CAJAComboBox = new System.Windows.Forms.ComboBox();
            this.BTExaminar = new System.Windows.Forms.Button();
            this.CBCustomConn = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.EM_NOMBRELabel = new System.Windows.Forms.Label();
            this.EM_NOMBRETextBox = new System.Windows.Forms.TextBoxET();
            this.FbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            this.FbCommand1 = new FirebirdSql.Data.FirebirdClient.FbCommand();
            this.requiredFieldValidator1 = new CustomValidation.RequiredFieldValidator();
            this.OpenFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.RFV_EM_NOMBRE = new CustomValidation.RequiredFieldValidator();
            this.cmdBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.GBConecctionData.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.fixDbButton);
            this.panel1.Controls.Add(this.btnAyuda);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.btnLimpiar);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(495, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(115, 210);
            this.panel1.TabIndex = 7;
            // 
            // fixDbButton
            // 
            this.fixDbButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.fixDbButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fixDbButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fixDbButton.ForeColor = System.Drawing.Color.White;
            this.fixDbButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fixDbButton.Location = new System.Drawing.Point(9, 177);
            this.fixDbButton.Name = "fixDbButton";
            this.fixDbButton.Size = new System.Drawing.Size(99, 30);
            this.fixDbButton.TabIndex = 58;
            this.fixDbButton.Text = "Reparar BD";
            this.fixDbButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fixDbButton.UseVisualStyleBackColor = false;
            this.fixDbButton.Click += new System.EventHandler(this.fixDbButton_Click);
            // 
            // btnAyuda
            // 
            this.btnAyuda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAyuda.ForeColor = System.Drawing.Color.White;
            this.btnAyuda.Image = global::iPos.Properties.Resources.helpNoBackSmall_J;
            this.btnAyuda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAyuda.Location = new System.Drawing.Point(9, 141);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(99, 30);
            this.btnAyuda.TabIndex = 57;
            this.btnAyuda.Text = "Ayuda";
            this.btnAyuda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAyuda.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = global::iPos.Properties.Resources.saveNoBackSmall_J;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(9, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(99, 30);
            this.btnGuardar.TabIndex = 53;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.TSBGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Image = global::iPos.Properties.Resources.cleanNoBackSmall_J;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(9, 108);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(99, 30);
            this.btnLimpiar.TabIndex = 56;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.TSMLimpiar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Image = global::iPos.Properties.Resources.exitNoBackSmall_J;
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(9, 39);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(99, 30);
            this.btnCerrar.TabIndex = 54;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.TSBCerrar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = global::iPos.Properties.Resources.canelNoBackSmallWhite_J;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(9, 72);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(99, 30);
            this.btnEliminar.TabIndex = 55;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.TSBEliminar_Click);
            // 
            // btEliminar
            // 
            this.btEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btEliminar.Enabled = false;
            this.btEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEliminar.ForeColor = System.Drawing.Color.White;
            this.btEliminar.Location = new System.Drawing.Point(152, 302);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(57, 23);
            this.btEliminar.TabIndex = 52;
            this.btEliminar.Text = "Eliminar";
            this.btEliminar.UseVisualStyleBackColor = false;
            this.btEliminar.Visible = false;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(110)))), ((int)(((byte)(153)))));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.GBConecctionData);
            this.panel2.Controls.Add(this.CBCustomConn);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(7, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(448, 225);
            this.panel2.TabIndex = 51;
            // 
            // GBConecctionData
            // 
            this.GBConecctionData.BackColor = System.Drawing.Color.Transparent;
            this.GBConecctionData.Controls.Add(this.REPLICADORCheckBox);
            this.GBConecctionData.Controls.Add(this.label5);
            this.GBConecctionData.Controls.Add(this.HAB_POOLINGCheckBox);
            this.GBConecctionData.Controls.Add(this.label4);
            this.GBConecctionData.Controls.Add(this.pnlColor);
            this.GBConecctionData.Controls.Add(this.EM_DATABASELabel);
            this.GBConecctionData.Controls.Add(this.btnColor);
            this.GBConecctionData.Controls.Add(this.EM_PASSWORDLabel);
            this.GBConecctionData.Controls.Add(this.ESMATRIZCheckBox);
            this.GBConecctionData.Controls.Add(this.EM_USUARIOTextBox);
            this.GBConecctionData.Controls.Add(this.label3);
            this.GBConecctionData.Controls.Add(this.EM_PASSWORDTextBox);
            this.GBConecctionData.Controls.Add(this.BTRefreshComboCaja);
            this.GBConecctionData.Controls.Add(this.EM_USUARIOLabel);
            this.GBConecctionData.Controls.Add(this.label2);
            this.GBConecctionData.Controls.Add(this.EM_SERVERLabel);
            this.GBConecctionData.Controls.Add(this.HABILITAR_IMPEXP_AUTCheckBox);
            this.GBConecctionData.Controls.Add(this.EM_DATABASETextBox);
            this.GBConecctionData.Controls.Add(this.label1);
            this.GBConecctionData.Controls.Add(this.EM_SERVERTextBox);
            this.GBConecctionData.Controls.Add(this.EM_CAJAComboBox);
            this.GBConecctionData.Controls.Add(this.BTExaminar);
            this.GBConecctionData.Location = new System.Drawing.Point(2, 24);
            this.GBConecctionData.Name = "GBConecctionData";
            this.GBConecctionData.Size = new System.Drawing.Size(443, 198);
            this.GBConecctionData.TabIndex = 53;
            // 
            // REPLICADORCheckBox
            // 
            this.REPLICADORCheckBox.AutoSize = true;
            this.REPLICADORCheckBox.Location = new System.Drawing.Point(263, 166);
            this.REPLICADORCheckBox.Name = "REPLICADORCheckBox";
            this.REPLICADORCheckBox.Size = new System.Drawing.Size(15, 14);
            this.REPLICADORCheckBox.TabIndex = 24;
            this.REPLICADORCheckBox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(199, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Replicador";
            // 
            // HAB_POOLINGCheckBox
            // 
            this.HAB_POOLINGCheckBox.AutoSize = true;
            this.HAB_POOLINGCheckBox.Location = new System.Drawing.Point(124, 165);
            this.HAB_POOLINGCheckBox.Name = "HAB_POOLINGCheckBox";
            this.HAB_POOLINGCheckBox.Size = new System.Drawing.Size(15, 14);
            this.HAB_POOLINGCheckBox.TabIndex = 22;
            this.HAB_POOLINGCheckBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(49, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Hab. Pooling";
            // 
            // pnlColor
            // 
            this.pnlColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.pnlColor.Location = new System.Drawing.Point(324, 125);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(43, 22);
            this.pnlColor.TabIndex = 20;
            // 
            // EM_DATABASELabel
            // 
            this.EM_DATABASELabel.AutoSize = true;
            this.EM_DATABASELabel.BackColor = System.Drawing.Color.Transparent;
            this.EM_DATABASELabel.ForeColor = System.Drawing.Color.White;
            this.EM_DATABASELabel.Location = new System.Drawing.Point(37, 9);
            this.EM_DATABASELabel.Name = "EM_DATABASELabel";
            this.EM_DATABASELabel.Size = new System.Drawing.Size(80, 13);
            this.EM_DATABASELabel.TabIndex = 1;
            this.EM_DATABASELabel.Text = "Database path:";
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnColor.ForeColor = System.Drawing.Color.White;
            this.btnColor.Location = new System.Drawing.Point(373, 123);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(56, 23);
            this.btnColor.TabIndex = 19;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // EM_PASSWORDLabel
            // 
            this.EM_PASSWORDLabel.AutoSize = true;
            this.EM_PASSWORDLabel.BackColor = System.Drawing.Color.Transparent;
            this.EM_PASSWORDLabel.ForeColor = System.Drawing.Color.White;
            this.EM_PASSWORDLabel.Location = new System.Drawing.Point(61, 55);
            this.EM_PASSWORDLabel.Name = "EM_PASSWORDLabel";
            this.EM_PASSWORDLabel.Size = new System.Drawing.Size(56, 13);
            this.EM_PASSWORDLabel.TabIndex = 1;
            this.EM_PASSWORDLabel.Text = "Password:";
            // 
            // ESMATRIZCheckBox
            // 
            this.ESMATRIZCheckBox.AutoSize = true;
            this.ESMATRIZCheckBox.Location = new System.Drawing.Point(263, 139);
            this.ESMATRIZCheckBox.Name = "ESMATRIZCheckBox";
            this.ESMATRIZCheckBox.Size = new System.Drawing.Size(15, 14);
            this.ESMATRIZCheckBox.TabIndex = 18;
            this.ESMATRIZCheckBox.UseVisualStyleBackColor = true;
            // 
            // EM_USUARIOTextBox
            // 
            this.EM_USUARIOTextBox.Format_Expression = null;
            this.EM_USUARIOTextBox.Location = new System.Drawing.Point(123, 29);
            this.EM_USUARIOTextBox.Name = "EM_USUARIOTextBox";
            this.EM_USUARIOTextBox.Size = new System.Drawing.Size(266, 20);
            this.EM_USUARIOTextBox.TabIndex = 6;
            this.EM_USUARIOTextBox.Tag = 34;
            this.EM_USUARIOTextBox.ValidationExpression = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(208, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Es matriz";
            // 
            // EM_PASSWORDTextBox
            // 
            this.EM_PASSWORDTextBox.Format_Expression = null;
            this.EM_PASSWORDTextBox.Location = new System.Drawing.Point(123, 52);
            this.EM_PASSWORDTextBox.Name = "EM_PASSWORDTextBox";
            this.EM_PASSWORDTextBox.Size = new System.Drawing.Size(266, 20);
            this.EM_PASSWORDTextBox.TabIndex = 7;
            this.EM_PASSWORDTextBox.Tag = 34;
            this.EM_PASSWORDTextBox.ValidationExpression = null;
            // 
            // BTRefreshComboCaja
            // 
            this.BTRefreshComboCaja.BackgroundImage = global::iPos.Properties.Resources.refresh_J;
            this.BTRefreshComboCaja.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTRefreshComboCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTRefreshComboCaja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTRefreshComboCaja.Location = new System.Drawing.Point(357, 99);
            this.BTRefreshComboCaja.Name = "BTRefreshComboCaja";
            this.BTRefreshComboCaja.Size = new System.Drawing.Size(26, 23);
            this.BTRefreshComboCaja.TabIndex = 16;
            this.BTRefreshComboCaja.UseVisualStyleBackColor = true;
            this.BTRefreshComboCaja.Click += new System.EventHandler(this.BTRefreshComboCaja_Click);
            // 
            // EM_USUARIOLabel
            // 
            this.EM_USUARIOLabel.AutoSize = true;
            this.EM_USUARIOLabel.BackColor = System.Drawing.Color.Transparent;
            this.EM_USUARIOLabel.ForeColor = System.Drawing.Color.White;
            this.EM_USUARIOLabel.Location = new System.Drawing.Point(71, 32);
            this.EM_USUARIOLabel.Name = "EM_USUARIOLabel";
            this.EM_USUARIOLabel.Size = new System.Drawing.Size(46, 13);
            this.EM_USUARIOLabel.TabIndex = 1;
            this.EM_USUARIOLabel.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(86, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Caja:";
            // 
            // EM_SERVERLabel
            // 
            this.EM_SERVERLabel.AutoSize = true;
            this.EM_SERVERLabel.BackColor = System.Drawing.Color.Transparent;
            this.EM_SERVERLabel.ForeColor = System.Drawing.Color.White;
            this.EM_SERVERLabel.Location = new System.Drawing.Point(76, 79);
            this.EM_SERVERLabel.Name = "EM_SERVERLabel";
            this.EM_SERVERLabel.Size = new System.Drawing.Size(41, 13);
            this.EM_SERVERLabel.TabIndex = 1;
            this.EM_SERVERLabel.Text = "Server:";
            // 
            // HABILITAR_IMPEXP_AUTCheckBox
            // 
            this.HABILITAR_IMPEXP_AUTCheckBox.AutoSize = true;
            this.HABILITAR_IMPEXP_AUTCheckBox.Location = new System.Drawing.Point(124, 139);
            this.HABILITAR_IMPEXP_AUTCheckBox.Name = "HABILITAR_IMPEXP_AUTCheckBox";
            this.HABILITAR_IMPEXP_AUTCheckBox.Size = new System.Drawing.Size(15, 14);
            this.HABILITAR_IMPEXP_AUTCheckBox.TabIndex = 17;
            this.HABILITAR_IMPEXP_AUTCheckBox.UseVisualStyleBackColor = true;
            // 
            // EM_DATABASETextBox
            // 
            this.EM_DATABASETextBox.Format_Expression = null;
            this.EM_DATABASETextBox.Location = new System.Drawing.Point(123, 6);
            this.EM_DATABASETextBox.Name = "EM_DATABASETextBox";
            this.EM_DATABASETextBox.Size = new System.Drawing.Size(266, 20);
            this.EM_DATABASETextBox.TabIndex = 5;
            this.EM_DATABASETextBox.Tag = 34;
            this.EM_DATABASETextBox.ValidationExpression = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Hab. Imp/Exp Aut.";
            // 
            // EM_SERVERTextBox
            // 
            this.EM_SERVERTextBox.Format_Expression = null;
            this.EM_SERVERTextBox.Location = new System.Drawing.Point(123, 76);
            this.EM_SERVERTextBox.Name = "EM_SERVERTextBox";
            this.EM_SERVERTextBox.Size = new System.Drawing.Size(266, 20);
            this.EM_SERVERTextBox.TabIndex = 8;
            this.EM_SERVERTextBox.Tag = 34;
            this.EM_SERVERTextBox.ValidationExpression = null;
            // 
            // EM_CAJAComboBox
            // 
            this.EM_CAJAComboBox.DisplayMember = "NOMBRE";
            this.EM_CAJAComboBox.FormattingEnabled = true;
            this.EM_CAJAComboBox.Location = new System.Drawing.Point(124, 102);
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
            this.BTExaminar.Location = new System.Drawing.Point(391, 5);
            this.BTExaminar.Name = "BTExaminar";
            this.BTExaminar.Size = new System.Drawing.Size(38, 21);
            this.BTExaminar.TabIndex = 5;
            this.BTExaminar.Text = "...";
            this.BTExaminar.UseVisualStyleBackColor = false;
            this.BTExaminar.Click += new System.EventHandler(this.BTExaminar_Click);
            // 
            // CBCustomConn
            // 
            this.CBCustomConn.AutoSize = true;
            this.CBCustomConn.BackColor = System.Drawing.Color.Transparent;
            this.CBCustomConn.Checked = true;
            this.CBCustomConn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBCustomConn.ForeColor = System.Drawing.Color.White;
            this.CBCustomConn.Location = new System.Drawing.Point(8, 6);
            this.CBCustomConn.Name = "CBCustomConn";
            this.CBCustomConn.Size = new System.Drawing.Size(189, 17);
            this.CBCustomConn.TabIndex = 3;
            this.CBCustomConn.Text = "Datos Personalizados de conexion";
            this.CBCustomConn.UseVisualStyleBackColor = false;
            this.CBCustomConn.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(236, 302);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 23);
            this.button2.TabIndex = 50;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(319, 302);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 23);
            this.button1.TabIndex = 49;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EM_NOMBRELabel
            // 
            this.EM_NOMBRELabel.AutoSize = true;
            this.EM_NOMBRELabel.BackColor = System.Drawing.Color.Transparent;
            this.EM_NOMBRELabel.Location = new System.Drawing.Point(12, 38);
            this.EM_NOMBRELabel.Name = "EM_NOMBRELabel";
            this.EM_NOMBRELabel.Size = new System.Drawing.Size(57, 13);
            this.EM_NOMBRELabel.TabIndex = 47;
            this.EM_NOMBRELabel.Text = "NOMBRE:";
            // 
            // EM_NOMBRETextBox
            // 
            this.EM_NOMBRETextBox.Format_Expression = null;
            this.EM_NOMBRETextBox.Location = new System.Drawing.Point(132, 35);
            this.EM_NOMBRETextBox.Name = "EM_NOMBRETextBox";
            this.EM_NOMBRETextBox.Size = new System.Drawing.Size(264, 20);
            this.EM_NOMBRETextBox.TabIndex = 48;
            this.EM_NOMBRETextBox.Tag = 34;
            this.EM_NOMBRETextBox.ValidationExpression = null;
            this.EM_NOMBRETextBox.Validated += new System.EventHandler(this.EM_NOMBRETextBox_Validated);
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
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.Enabled = true;
            this.requiredFieldValidator1.Icon = null;
            // 
            // OpenFileDialog2
            // 
            this.OpenFileDialog2.FileName = "OpenFileDialog2";
            this.OpenFileDialog2.Filter = "Firebird (*.fdb)|*.fdb|Todos los archivos (*.*)|*.*";
            // 
            // RFV_EM_NOMBRE
            // 
            this.RFV_EM_NOMBRE.ControlToValidate = this.EM_NOMBRETextBox;
            this.RFV_EM_NOMBRE.Enabled = true;
            this.RFV_EM_NOMBRE.ErrorMessage = "Se requiere el campo EM_NOMBRE";
            this.RFV_EM_NOMBRE.Icon = null;
            // 
            // cmdBackgroundWorker
            // 
            this.cmdBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.cmdBackgroundWorker_DoWork);
            this.cmdBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.cmdBackgroundWorker_ProgressChanged);
            this.cmdBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.cmdBackgroundWorker_RunWorkerCompleted);
            // 
            // EMPRESASEdit_Reg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.fondo_con_logo_ipos_3_0;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(630, 338);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.EM_NOMBRELabel);
            this.Controls.Add(this.EM_NOMBRETextBox);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(1024, 738);
            this.Name = "EMPRESASEdit_Reg";
            this.Text = "Editar Registro de Empresa";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.Load += new System.EventHandler(this.EMPRESASEdit_Reg_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EMPRESASEdit_Reg_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.GBConecctionData.ResumeLayout(false);
            this.GBConecctionData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

  }
  #endregion

  //private Skinner.FormSkin formSkin1;
  private System.Windows.Forms.Panel panel1;
  private System.Windows.Forms.Button btEliminar;
  private System.Windows.Forms.Panel panel2;
  private System.Windows.Forms.CheckBox CBCustomConn;
  private System.Windows.Forms.Panel pnlColor;
  private System.Windows.Forms.Button btnColor;
  private System.Windows.Forms.CheckBox ESMATRIZCheckBox;
  private System.Windows.Forms.Label label3;
  private System.Windows.Forms.Button BTRefreshComboCaja;
  private System.Windows.Forms.Label label2;
  private System.Windows.Forms.CheckBox HABILITAR_IMPEXP_AUTCheckBox;
  private System.Windows.Forms.Label label1;
  private System.Windows.Forms.ComboBox EM_CAJAComboBox;
  internal System.Windows.Forms.Button BTExaminar;
  private System.Windows.Forms.Label EM_DATABASELabel;
  private System.Windows.Forms.TextBoxET EM_SERVERTextBox;
  private System.Windows.Forms.TextBoxET EM_DATABASETextBox;
  private System.Windows.Forms.Label EM_SERVERLabel;
  private System.Windows.Forms.Label EM_USUARIOLabel;
  private System.Windows.Forms.TextBoxET EM_PASSWORDTextBox;
  private System.Windows.Forms.TextBoxET EM_USUARIOTextBox;
  private System.Windows.Forms.Label EM_PASSWORDLabel;
  private System.Windows.Forms.Button button2;
  private System.Windows.Forms.Button button1;
  private System.Windows.Forms.Label EM_NOMBRELabel;
  private System.Windows.Forms.TextBoxET EM_NOMBRETextBox;
  private FirebirdSql.Data.FirebirdClient.FbConnection FbConnection1;
  private FirebirdSql.Data.FirebirdClient.FbCommand FbCommand1;
  private CustomValidation.RequiredFieldValidator requiredFieldValidator1;
  internal System.Windows.Forms.OpenFileDialog OpenFileDialog2;
  private CustomValidation.RequiredFieldValidator RFV_EM_NOMBRE;
  private System.Windows.Forms.Button btnGuardar;
  private System.Windows.Forms.Button btnCerrar;
  private System.Windows.Forms.Button btnEliminar;
  private System.Windows.Forms.Button btnLimpiar;
  private System.Windows.Forms.Button btnAyuda;
  private System.Windows.Forms.Panel GBConecctionData;
  private System.Windows.Forms.CheckBox HAB_POOLINGCheckBox;
  private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox REPLICADORCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button fixDbButton;
        private System.ComponentModel.BackgroundWorker cmdBackgroundWorker;
    }
  }

