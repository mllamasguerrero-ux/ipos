namespace iPos
{
    partial class PERFILEdicion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PERFILEdicion));
            this.PF_DESCRIPCIONLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pERFILES_DERECHOSDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dgDerecho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPermitido = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pERFILES_DERECHOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSSeguridad = new iPos.Login_and_Maintenance.DSSeguridad();
            this.pERFILES_DERECHOSTableAdapter = new iPos.Login_and_Maintenance.DSSeguridadTableAdapters.PERFILES_DERECHOSTableAdapter();
            this.tableAdapterManager = new iPos.Login_and_Maintenance.DSSeguridadTableAdapters.TableAdapterManager();
            this.BtnCopiarDe = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PF_DESCRIPCIONTextBox = new iPos.Tools.TextBoxFB();
            this.BTCancelar = new System.Windows.Forms.Button();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CBBuscar = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pERFILES_DERECHOSDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pERFILES_DERECHOSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSSeguridad)).BeginInit();
            this.SuspendLayout();
            // 
            // PF_DESCRIPCIONLabel
            // 
            this.PF_DESCRIPCIONLabel.AutoSize = true;
            this.PF_DESCRIPCIONLabel.BackColor = System.Drawing.Color.Transparent;
            this.PF_DESCRIPCIONLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PF_DESCRIPCIONLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PF_DESCRIPCIONLabel.Location = new System.Drawing.Point(132, 24);
            this.PF_DESCRIPCIONLabel.Name = "PF_DESCRIPCIONLabel";
            this.PF_DESCRIPCIONLabel.Size = new System.Drawing.Size(40, 13);
            this.PF_DESCRIPCIONLabel.TabIndex = 3;
            this.PF_DESCRIPCIONLabel.Text = "Perfil:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.Image = global::iPos.Properties.Resources.saveNoBack_J;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(160, 427);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "Guardar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pERFILES_DERECHOSDataGridView
            // 
            this.pERFILES_DERECHOSDataGridView.AllowUserToAddRows = false;
            this.pERFILES_DERECHOSDataGridView.AutoGenerateColumns = false;
            this.pERFILES_DERECHOSDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pERFILES_DERECHOSDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgDerecho,
            this.dataGridViewTextBoxColumn2,
            this.dgPermitido});
            this.pERFILES_DERECHOSDataGridView.DataSource = this.pERFILES_DERECHOSBindingSource;
            this.pERFILES_DERECHOSDataGridView.Location = new System.Drawing.Point(12, 124);
            this.pERFILES_DERECHOSDataGridView.Name = "pERFILES_DERECHOSDataGridView";
            this.pERFILES_DERECHOSDataGridView.RowHeadersVisible = false;
            this.pERFILES_DERECHOSDataGridView.Size = new System.Drawing.Size(559, 297);
            this.pERFILES_DERECHOSDataGridView.TabIndex = 2;
            this.pERFILES_DERECHOSDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pERFILES_DERECHOSDataGridView_CellContentClick);
            // 
            // dgDerecho
            // 
            this.dgDerecho.DataPropertyName = "DR_DERECHO";
            this.dgDerecho.HeaderText = "ID";
            this.dgDerecho.Name = "dgDerecho";
            this.dgDerecho.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DR_DESCRIPCION";
            this.dataGridViewTextBoxColumn2.HeaderText = "DESCRIPCION";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 380;
            // 
            // dgPermitido
            // 
            this.dgPermitido.DataPropertyName = "PERMITIDO";
            this.dgPermitido.FalseValue = "0";
            this.dgPermitido.HeaderText = "PERMITIDO";
            this.dgPermitido.Name = "dgPermitido";
            this.dgPermitido.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPermitido.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgPermitido.TrueValue = "1";
            // 
            // pERFILES_DERECHOSBindingSource
            // 
            this.pERFILES_DERECHOSBindingSource.DataMember = "PERFILES_DERECHOS";
            this.pERFILES_DERECHOSBindingSource.DataSource = this.dSSeguridad;
            // 
            // dSSeguridad
            // 
            this.dSSeguridad.DataSetName = "DSSeguridad";
            this.dSSeguridad.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pERFILES_DERECHOSTableAdapter
            // 
            this.pERFILES_DERECHOSTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.PERFILES_DERECHOSTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = iPos.Login_and_Maintenance.DSSeguridadTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // BtnCopiarDe
            // 
            this.BtnCopiarDe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BtnCopiarDe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BtnCopiarDe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCopiarDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCopiarDe.ForeColor = System.Drawing.Color.White;
            this.BtnCopiarDe.Location = new System.Drawing.Point(401, 47);
            this.BtnCopiarDe.Name = "BtnCopiarDe";
            this.BtnCopiarDe.Size = new System.Drawing.Size(86, 23);
            this.BtnCopiarDe.TabIndex = 3;
            this.BtnCopiarDe.Text = "Copiar de";
            this.BtnCopiarDe.UseVisualStyleBackColor = false;
            this.BtnCopiarDe.Click += new System.EventHandler(this.BtnCopiarDe_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "DR_DERECHO";
            this.dataGridViewTextBoxColumn1.HeaderText = "DR_DERECHO";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // PF_DESCRIPCIONTextBox
            // 
            this.PF_DESCRIPCIONTextBox.BotonLookUp = null;
            this.PF_DESCRIPCIONTextBox.Condicion = null;
            this.PF_DESCRIPCIONTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.VarChar;
            this.PF_DESCRIPCIONTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.PF_DESCRIPCIONTextBox.DbValue = null;
            this.PF_DESCRIPCIONTextBox.Format_Expression = null;
            this.PF_DESCRIPCIONTextBox.IndiceCampoDescripcion = 0;
            this.PF_DESCRIPCIONTextBox.IndiceCampoSelector = 1;
            this.PF_DESCRIPCIONTextBox.IndiceCampoValue = 0;
            this.PF_DESCRIPCIONTextBox.LabelDescription = null;
            this.PF_DESCRIPCIONTextBox.Location = new System.Drawing.Point(185, 21);
            this.PF_DESCRIPCIONTextBox.Name = "PF_DESCRIPCIONTextBox";
            this.PF_DESCRIPCIONTextBox.NombreCampoSelector = "@pf_descripcion";
            this.PF_DESCRIPCIONTextBox.NombreCampoValue = null;
            this.PF_DESCRIPCIONTextBox.Query = "Select * from perfiles";
            this.PF_DESCRIPCIONTextBox.QueryDeSeleccion = "Select * from perfiles WHERE  pf_descripcion=@pf_descripcion";
            this.PF_DESCRIPCIONTextBox.QueryPorDBValue = null;
            this.PF_DESCRIPCIONTextBox.Size = new System.Drawing.Size(302, 20);
            this.PF_DESCRIPCIONTextBox.TabIndex = 1;
            this.PF_DESCRIPCIONTextBox.Tag = 34;
            this.PF_DESCRIPCIONTextBox.TextDescription = null;
            this.PF_DESCRIPCIONTextBox.Titulo = "PERFILES";
            this.PF_DESCRIPCIONTextBox.ValidationExpression = null;
            // 
            // BTCancelar
            // 
            this.BTCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BTCancelar.Image = global::iPos.Properties.Resources.cancel_J;
            this.BTCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTCancelar.Location = new System.Drawing.Point(319, 427);
            this.BTCancelar.Name = "BTCancelar";
            this.BTCancelar.Size = new System.Drawing.Size(109, 30);
            this.BTCancelar.TabIndex = 4;
            this.BTCancelar.Text = "Cancelar";
            this.BTCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTCancelar.UseVisualStyleBackColor = false;
            this.BTCancelar.Click += new System.EventHandler(this.BTCancelar_Click);
            // 
            // TBBuscar
            // 
            this.TBBuscar.Location = new System.Drawing.Point(192, 92);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(181, 20);
            this.TBBuscar.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(77, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Buscar por:";
            // 
            // CBBuscar
            // 
            this.CBBuscar.FormattingEnabled = true;
            this.CBBuscar.Items.AddRange(new object[] {
            "Por id",
            "Por descripcion"});
            this.CBBuscar.Location = new System.Drawing.Point(56, 93);
            this.CBBuscar.Name = "CBBuscar";
            this.CBBuscar.Size = new System.Drawing.Size(121, 21);
            this.CBBuscar.TabIndex = 7;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(379, 93);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(86, 23);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnExportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(411, 494);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(86, 23);
            this.btnExportar.TabIndex = 9;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnImportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportar.ForeColor = System.Drawing.Color.White;
            this.btnImportar.Location = new System.Drawing.Point(503, 494);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(86, 23);
            this.btnImportar.TabIndex = 10;
            this.btnImportar.Text = "Importar";
            this.btnImportar.UseVisualStyleBackColor = false;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // PERFILEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(738, 529);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.CBBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBBuscar);
            this.Controls.Add(this.BTCancelar);
            this.Controls.Add(this.BtnCopiarDe);
            this.Controls.Add(this.pERFILES_DERECHOSDataGridView);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PF_DESCRIPCIONTextBox);
            this.Controls.Add(this.PF_DESCRIPCIONLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(1024, 738);
            this.Name = "PERFILEdicion";
            this.Text = "Editar Perfiles";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.Load += new System.EventHandler(this.PERFILEdicion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pERFILES_DERECHOSDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pERFILES_DERECHOSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSSeguridad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label PF_DESCRIPCIONLabel;
        //private Skinner.FormSkin formSkin1;
        private iPos.Tools.TextBoxFB PF_DESCRIPCIONTextBox;
        private System.Windows.Forms.Button button1;
        private Login_and_Maintenance.DSSeguridad dSSeguridad;
        private System.Windows.Forms.BindingSource pERFILES_DERECHOSBindingSource;
        private Login_and_Maintenance.DSSeguridadTableAdapters.PERFILES_DERECHOSTableAdapter pERFILES_DERECHOSTableAdapter;
        private Login_and_Maintenance.DSSeguridadTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum pERFILES_DERECHOSDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button BtnCopiarDe;
        private System.Windows.Forms.Button BTCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDerecho;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgPermitido;
        private System.Windows.Forms.TextBox TBBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}