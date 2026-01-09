
namespace iPos
{
    partial class WFReporteEdit
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
            this.components = new System.ComponentModel.Container();
            FirebirdSql.Data.FirebirdClient.FbParameter fbParameter1 = new FirebirdSql.Data.FirebirdClient.FbParameter();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFReporteEdit));
            this.ACTIVOLabel = new System.Windows.Forms.Label();
            this.CLAVELabel = new System.Windows.Forms.Label();
            this.NOMBRELabel = new System.Windows.Forms.Label();
            this.NOMBRETextBox = new System.Windows.Forms.TextBox();
            this.RFV_CLAVE = new CustomValidation.RequiredFieldValidator();
            this.LBError = new System.Windows.Forms.Label();
            this.FbConnection1 = new FirebirdSql.Data.FirebirdClient.FbConnection();
            this.FbCommand1 = new FirebirdSql.Data.FirebirdClient.FbCommand();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pERFILREPORTEDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dgDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPermitido = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgPerfil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pERFILREPORTEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSAccessControl = new iPos.Login_and_Maintenance.DSAccessControl();
            this.label2 = new System.Windows.Forms.Label();
            this.ARCHIVOTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DESCRIPCIONTextBox = new System.Windows.Forms.TextBox();
            this.ACTIVOTextBox = new System.Windows.Forms.CheckBox();
            this.BTIniciaEdicion = new System.Windows.Forms.Button();
            this.BTCancelar = new System.Windows.Forms.Button();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.pERFILREPORTETableAdapter = new iPos.Login_and_Maintenance.DSAccessControlTableAdapters.PERFILREPORTETableAdapter();
            this.tableAdapterManager = new iPos.Login_and_Maintenance.DSAccessControlTableAdapters.TableAdapterManager();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pERFILREPORTEDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pERFILREPORTEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSAccessControl)).BeginInit();
            this.SuspendLayout();
            // 
            // ACTIVOLabel
            // 
            this.ACTIVOLabel.AutoSize = true;
            this.ACTIVOLabel.BackColor = System.Drawing.Color.Transparent;
            this.ACTIVOLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ACTIVOLabel.ForeColor = System.Drawing.Color.White;
            this.ACTIVOLabel.Location = new System.Drawing.Point(11, 10);
            this.ACTIVOLabel.Name = "ACTIVOLabel";
            this.ACTIVOLabel.Size = new System.Drawing.Size(47, 13);
            this.ACTIVOLabel.TabIndex = 1;
            this.ACTIVOLabel.Text = "Activo:";
            // 
            // CLAVELabel
            // 
            this.CLAVELabel.AutoSize = true;
            this.CLAVELabel.BackColor = System.Drawing.Color.Transparent;
            this.CLAVELabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLAVELabel.ForeColor = System.Drawing.Color.White;
            this.CLAVELabel.Location = new System.Drawing.Point(17, 9);
            this.CLAVELabel.Name = "CLAVELabel";
            this.CLAVELabel.Size = new System.Drawing.Size(24, 13);
            this.CLAVELabel.TabIndex = 1;
            this.CLAVELabel.Text = "ID:";
            // 
            // NOMBRELabel
            // 
            this.NOMBRELabel.AutoSize = true;
            this.NOMBRELabel.BackColor = System.Drawing.Color.Transparent;
            this.NOMBRELabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NOMBRELabel.ForeColor = System.Drawing.Color.White;
            this.NOMBRELabel.Location = new System.Drawing.Point(11, 40);
            this.NOMBRELabel.Name = "NOMBRELabel";
            this.NOMBRELabel.Size = new System.Drawing.Size(54, 13);
            this.NOMBRELabel.TabIndex = 1;
            this.NOMBRELabel.Text = "Nombre:";
            // 
            // NOMBRETextBox
            // 
            this.NOMBRETextBox.Location = new System.Drawing.Point(113, 37);
            this.NOMBRETextBox.Name = "NOMBRETextBox";
            this.NOMBRETextBox.Size = new System.Drawing.Size(263, 20);
            this.NOMBRETextBox.TabIndex = 2;
            // 
            // RFV_CLAVE
            // 
            this.RFV_CLAVE.Enabled = true;
            this.RFV_CLAVE.ErrorMessage = "Se requiere el campo CLAVE";
            this.RFV_CLAVE.Icon = null;
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::iPos.Properties.Resources.saveNoBack_J;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(105, 453);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.pERFILREPORTEDataGridView);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ARCHIVOTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.DESCRIPCIONTextBox);
            this.panel1.Controls.Add(this.ACTIVOTextBox);
            this.panel1.Controls.Add(this.ACTIVOLabel);
            this.panel1.Controls.Add(this.NOMBRELabel);
            this.panel1.Controls.Add(this.NOMBRETextBox);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(6, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 414);
            this.panel1.TabIndex = 2;
            this.panel1.TabStop = true;
            // 
            // pERFILREPORTEDataGridView
            // 
            this.pERFILREPORTEDataGridView.AllowUserToAddRows = false;
            this.pERFILREPORTEDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pERFILREPORTEDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.pERFILREPORTEDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pERFILREPORTEDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgDescripcion,
            this.dgPermitido,
            this.dgPerfil});
            this.pERFILREPORTEDataGridView.DataSource = this.pERFILREPORTEBindingSource;
            this.pERFILREPORTEDataGridView.Location = new System.Drawing.Point(14, 160);
            this.pERFILREPORTEDataGridView.Name = "pERFILREPORTEDataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pERFILREPORTEDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.pERFILREPORTEDataGridView.RowHeadersVisible = false;
            this.pERFILREPORTEDataGridView.Size = new System.Drawing.Size(362, 241);
            this.pERFILREPORTEDataGridView.TabIndex = 9;
            // 
            // dgDescripcion
            // 
            this.dgDescripcion.DataPropertyName = "PF_DESCRIPCION";
            this.dgDescripcion.HeaderText = "PERFIL";
            this.dgDescripcion.Name = "dgDescripcion";
            this.dgDescripcion.ReadOnly = true;
            this.dgDescripcion.Width = 250;
            // 
            // dgPermitido
            // 
            this.dgPermitido.DataPropertyName = "PERMITIDO";
            this.dgPermitido.FalseValue = "0";
            this.dgPermitido.HeaderText = "";
            this.dgPermitido.Name = "dgPermitido";
            this.dgPermitido.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPermitido.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgPermitido.TrueValue = "1";
            this.dgPermitido.Width = 40;
            // 
            // dgPerfil
            // 
            this.dgPerfil.DataPropertyName = "PF_PERFIL";
            this.dgPerfil.HeaderText = "PF_PERFIL";
            this.dgPerfil.Name = "dgPerfil";
            this.dgPerfil.Visible = false;
            // 
            // pERFILREPORTEBindingSource
            // 
            this.pERFILREPORTEBindingSource.DataMember = "PERFILREPORTE";
            this.pERFILREPORTEBindingSource.DataSource = this.dSAccessControl;
            // 
            // dSAccessControl
            // 
            this.dSAccessControl.DataSetName = "DSAccessControl";
            this.dSAccessControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Archivo:";
            // 
            // ARCHIVOTextBox
            // 
            this.ARCHIVOTextBox.Location = new System.Drawing.Point(113, 67);
            this.ARCHIVOTextBox.Name = "ARCHIVOTextBox";
            this.ARCHIVOTextBox.Size = new System.Drawing.Size(263, 20);
            this.ARCHIVOTextBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Descripcion:";
            // 
            // DESCRIPCIONTextBox
            // 
            this.DESCRIPCIONTextBox.Location = new System.Drawing.Point(113, 97);
            this.DESCRIPCIONTextBox.Multiline = true;
            this.DESCRIPCIONTextBox.Name = "DESCRIPCIONTextBox";
            this.DESCRIPCIONTextBox.Size = new System.Drawing.Size(263, 57);
            this.DESCRIPCIONTextBox.TabIndex = 7;
            // 
            // ACTIVOTextBox
            // 
            this.ACTIVOTextBox.AutoSize = true;
            this.ACTIVOTextBox.Location = new System.Drawing.Point(113, 10);
            this.ACTIVOTextBox.Name = "ACTIVOTextBox";
            this.ACTIVOTextBox.Size = new System.Drawing.Size(15, 14);
            this.ACTIVOTextBox.TabIndex = 5;
            this.ACTIVOTextBox.UseVisualStyleBackColor = true;
            // 
            // BTIniciaEdicion
            // 
            this.BTIniciaEdicion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTIniciaEdicion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTIniciaEdicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTIniciaEdicion.ForeColor = System.Drawing.Color.White;
            this.BTIniciaEdicion.Location = new System.Drawing.Point(20, 457);
            this.BTIniciaEdicion.Name = "BTIniciaEdicion";
            this.BTIniciaEdicion.Size = new System.Drawing.Size(57, 23);
            this.BTIniciaEdicion.TabIndex = 46;
            this.BTIniciaEdicion.Text = "Editar";
            this.BTIniciaEdicion.UseVisualStyleBackColor = false;
            this.BTIniciaEdicion.Visible = false;
            this.BTIniciaEdicion.Click += new System.EventHandler(this.BTIniciaEdicion_Click);
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
            this.BTCancelar.Location = new System.Drawing.Point(250, 453);
            this.BTCancelar.Name = "BTCancelar";
            this.BTCancelar.Size = new System.Drawing.Size(109, 30);
            this.BTCancelar.TabIndex = 47;
            this.BTCancelar.Text = "Cancelar";
            this.BTCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTCancelar.UseVisualStyleBackColor = false;
            this.BTCancelar.Click += new System.EventHandler(this.BTCancelar_Click);
            // 
            // IDTextBox
            // 
            this.IDTextBox.Enabled = false;
            this.IDTextBox.Location = new System.Drawing.Point(119, 6);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(263, 20);
            this.IDTextBox.TabIndex = 48;
            // 
            // pERFILREPORTETableAdapter
            // 
            this.pERFILREPORTETableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.DERECHOS_USUARIOSTableAdapter = null;
            this.tableAdapterManager.PERFILES_DERECHOSTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = iPos.Login_and_Maintenance.DSAccessControlTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // WFReporteEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(411, 489);
            this.Controls.Add(this.IDTextBox);
            this.Controls.Add(this.BTCancelar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CLAVELabel);
            this.Controls.Add(this.BTIniciaEdicion);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFReporteEdit";
            this.Text = "REPORTE";
            this.Load += new System.EventHandler(this.LINEAEdit_Reg_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pERFILREPORTEDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pERFILREPORTEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSAccessControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

  }

  #endregion



        private System.Windows.Forms.TextBox NOMBRETextBox;
        private System.Windows.Forms.Panel panel1;
  
  private FirebirdSql.Data.FirebirdClient.FbConnection FbConnection1;
  private FirebirdSql.Data.FirebirdClient.FbCommand FbCommand1;
  private System.Windows.Forms.Button button1;
  private System.Windows.Forms.Label LBError;




  private CustomValidation.RequiredFieldValidator RFV_CLAVE;
        private System.Windows.Forms.Label ACTIVOLabel;
        private System.Windows.Forms.Label CLAVELabel;
        private System.Windows.Forms.Label NOMBRELabel;
        private System.Windows.Forms.Button BTIniciaEdicion;
        private System.Windows.Forms.CheckBox ACTIVOTextBox;
        private System.Windows.Forms.Button BTCancelar;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ARCHIVOTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DESCRIPCIONTextBox;
        private Login_and_Maintenance.DSAccessControl dSAccessControl;
        private System.Windows.Forms.BindingSource pERFILREPORTEBindingSource;
        private Login_and_Maintenance.DSAccessControlTableAdapters.PERFILREPORTETableAdapter pERFILREPORTETableAdapter;
        private Login_and_Maintenance.DSAccessControlTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum pERFILREPORTEDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDescripcion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgPermitido;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPerfil;
 

    }
}

