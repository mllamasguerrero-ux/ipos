namespace iPos
{
    partial class WFReciboGastosAdicEdit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFReciboGastosAdicEdit));
            this.mARCAIDLabel = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gRIDPVGASTODataGridView = new System.Windows.Forms.DataGridViewE();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGGASTOID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGTOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGELIMINAR = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gRIDPVGASTOADICBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSContabilidad = new iPos.Contabilidad.DSContabilidad();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.TBMonto = new System.Windows.Forms.NumericTextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.pnlCorteSeleccion = new System.Windows.Forms.Panel();
            this.GASTOButton = new System.Windows.Forms.Button();
            this.GASTOIDTextBox = new iPos.Tools.TextBoxFB();
            this.GASTOLabel = new System.Windows.Forms.Label();
            this.LBFolio = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableAdapterManager = new iPos.Contabilidad.DSContabilidadTableAdapters.TableAdapterManager();
            this.gRIDPVGASTOADICTableAdapter = new iPos.Contabilidad.DSContabilidadTableAdapters.GRIDPVGASTOADICTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gRIDPVGASTODataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gRIDPVGASTOADICBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSContabilidad)).BeginInit();
            this.SuspendLayout();
            // 
            // mARCAIDLabel
            // 
            this.mARCAIDLabel.AutoSize = true;
            this.mARCAIDLabel.BackColor = System.Drawing.Color.Transparent;
            this.mARCAIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mARCAIDLabel.ForeColor = System.Drawing.Color.White;
            this.mARCAIDLabel.Location = new System.Drawing.Point(40, 73);
            this.mARCAIDLabel.Name = "mARCAIDLabel";
            this.mARCAIDLabel.Size = new System.Drawing.Size(44, 13);
            this.mARCAIDLabel.TabIndex = 158;
            this.mARCAIDLabel.Text = "Gasto:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(476, 424);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // gRIDPVGASTODataGridView
            // 
            this.gRIDPVGASTODataGridView.AllowUserToAddRows = false;
            this.gRIDPVGASTODataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gRIDPVGASTODataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gRIDPVGASTODataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gRIDPVGASTODataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGID,
            this.dataGridViewTextBoxColumn2,
            this.DGGASTOID,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.DGTOTAL,
            this.DGELIMINAR});
            this.gRIDPVGASTODataGridView.DataSource = this.gRIDPVGASTOADICBindingSource;
            this.gRIDPVGASTODataGridView.Location = new System.Drawing.Point(28, 141);
            this.gRIDPVGASTODataGridView.Name = "gRIDPVGASTODataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gRIDPVGASTODataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gRIDPVGASTODataGridView.RowHeadersVisible = false;
            this.gRIDPVGASTODataGridView.Size = new System.Drawing.Size(612, 220);
            this.gRIDPVGASTODataGridView.TabIndex = 8;
            this.gRIDPVGASTODataGridView.EnterKeyDownEvent += new System.EventHandler(this.gRIDPVGASTODataGridView_EnterKeyDownEvent);
            this.gRIDPVGASTODataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gRIDPVGASTODataGridView_CellContentClick);
            this.gRIDPVGASTODataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gRIDPVGASTODataGridView_CellValidating);
            this.gRIDPVGASTODataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gRIDPVGASTODataGridView_DataError);
            // 
            // DGID
            // 
            this.DGID.DataPropertyName = "ID";
            this.DGID.HeaderText = "ID";
            this.DGID.Name = "DGID";
            this.DGID.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PARTIDA";
            this.dataGridViewTextBoxColumn2.HeaderText = "PARTIDA";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // DGGASTOID
            // 
            this.DGGASTOID.DataPropertyName = "GASTOID";
            this.DGGASTOID.HeaderText = "GASTOID";
            this.DGGASTOID.Name = "DGGASTOID";
            this.DGGASTOID.ReadOnly = true;
            this.DGGASTOID.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "GASTOCLAVE";
            this.dataGridViewTextBoxColumn4.HeaderText = "GASTO CLAVE";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "GASTONOMBRE";
            this.dataGridViewTextBoxColumn5.HeaderText = "GASTO NOMBRE";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // DGTOTAL
            // 
            this.DGTOTAL.DataPropertyName = "TOTAL";
            this.DGTOTAL.HeaderText = "TOTAL";
            this.DGTOTAL.Name = "DGTOTAL";
            // 
            // DGELIMINAR
            // 
            this.DGELIMINAR.HeaderText = "";
            this.DGELIMINAR.Name = "DGELIMINAR";
            this.DGELIMINAR.Text = "ELIMINAR";
            this.DGELIMINAR.UseColumnTextForButtonValue = true;
            // 
            // gRIDPVGASTOADICBindingSource
            // 
            this.gRIDPVGASTOADICBindingSource.DataMember = "GRIDPVGASTOADIC";
            this.gRIDPVGASTOADICBindingSource.DataSource = this.dSContabilidad;
            // 
            // dSContabilidad
            // 
            this.dSContabilidad.DataSetName = "DSContabilidad";
            this.dSContabilidad.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(547, 91);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 26);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // TBMonto
            // 
            this.TBMonto.AllowNegative = true;
            this.TBMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBMonto.Format_Expression = null;
            this.TBMonto.Location = new System.Drawing.Point(386, 90);
            this.TBMonto.Name = "TBMonto";
            this.TBMonto.NumericPrecision = 12;
            this.TBMonto.NumericScaleOnFocus = 2;
            this.TBMonto.NumericScaleOnLostFocus = 2;
            this.TBMonto.NumericValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TBMonto.Size = new System.Drawing.Size(120, 24);
            this.TBMonto.TabIndex = 6;
            this.TBMonto.Tag = 34;
            this.TBMonto.Text = "0.00";
            this.TBMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBMonto.ValidationExpression = null;
            this.TBMonto.ZeroIsValid = true;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.BackColor = System.Drawing.Color.Transparent;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblCantidad.Location = new System.Drawing.Point(386, 73);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(46, 13);
            this.lblCantidad.TabIndex = 162;
            this.lblCantidad.Text = "Monto:";
            // 
            // pnlCorteSeleccion
            // 
            this.pnlCorteSeleccion.BackColor = System.Drawing.Color.Transparent;
            this.pnlCorteSeleccion.ForeColor = System.Drawing.Color.White;
            this.pnlCorteSeleccion.Location = new System.Drawing.Point(386, 27);
            this.pnlCorteSeleccion.Name = "pnlCorteSeleccion";
            this.pnlCorteSeleccion.Size = new System.Drawing.Size(123, 25);
            this.pnlCorteSeleccion.TabIndex = 2;
            // 
            // GASTOButton
            // 
            this.GASTOButton.BackColor = System.Drawing.Color.Transparent;
            this.GASTOButton.BackgroundImage = global::iPos.Properties.Resources.search_J;
            this.GASTOButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GASTOButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GASTOButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.GASTOButton.Location = new System.Drawing.Point(131, 91);
            this.GASTOButton.Name = "GASTOButton";
            this.GASTOButton.Size = new System.Drawing.Size(21, 23);
            this.GASTOButton.TabIndex = 5;
            this.GASTOButton.UseVisualStyleBackColor = false;
            this.GASTOButton.Click += new System.EventHandler(this.GASTOButton_Click);
            // 
            // GASTOIDTextBox
            // 
            this.GASTOIDTextBox.BotonLookUp = null;
            this.GASTOIDTextBox.Condicion = null;
            this.GASTOIDTextBox.DataBaseType = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.GASTOIDTextBox.DbTypeDBValue = FirebirdSql.Data.FirebirdClient.FbDbType.Array;
            this.GASTOIDTextBox.DbValue = null;
            this.GASTOIDTextBox.Format_Expression = null;
            this.GASTOIDTextBox.IndiceCampoDescripcion = 2;
            this.GASTOIDTextBox.IndiceCampoSelector = 1;
            this.GASTOIDTextBox.IndiceCampoValue = 0;
            this.GASTOIDTextBox.LabelDescription = this.GASTOLabel;
            this.GASTOIDTextBox.Location = new System.Drawing.Point(43, 91);
            this.GASTOIDTextBox.MostrarErrores = true;
            this.GASTOIDTextBox.Name = "GASTOIDTextBox";
            this.GASTOIDTextBox.NombreCampoSelector = "clave";
            this.GASTOIDTextBox.NombreCampoValue = "id";
            this.GASTOIDTextBox.Query = "select id,clave,nombre from gastoadicional";
            this.GASTOIDTextBox.QueryDeSeleccion = "select id,clave,nombre from gastoadicional where clave = @clave";
            this.GASTOIDTextBox.QueryPorDBValue = "select id,clave,nombre from gastoadicional where id = @id";
            this.GASTOIDTextBox.Size = new System.Drawing.Size(82, 20);
            this.GASTOIDTextBox.TabIndex = 4;
            this.GASTOIDTextBox.Tag = 34;
            this.GASTOIDTextBox.TextDescription = null;
            this.GASTOIDTextBox.Titulo = "Gastos";
            this.GASTOIDTextBox.ValidarEntrada = true;
            this.GASTOIDTextBox.ValidationExpression = null;
            // 
            // GASTOLabel
            // 
            this.GASTOLabel.AutoSize = true;
            this.GASTOLabel.BackColor = System.Drawing.Color.Transparent;
            this.GASTOLabel.ForeColor = System.Drawing.Color.White;
            this.GASTOLabel.Location = new System.Drawing.Point(159, 98);
            this.GASTOLabel.Name = "GASTOLabel";
            this.GASTOLabel.Size = new System.Drawing.Size(16, 13);
            this.GASTOLabel.TabIndex = 159;
            this.GASTOLabel.Text = "...";
            // 
            // LBFolio
            // 
            this.LBFolio.AutoSize = true;
            this.LBFolio.BackColor = System.Drawing.Color.Transparent;
            this.LBFolio.ForeColor = System.Drawing.Color.White;
            this.LBFolio.Location = new System.Drawing.Point(84, 27);
            this.LBFolio.Name = "LBFolio";
            this.LBFolio.Size = new System.Drawing.Size(16, 13);
            this.LBFolio.TabIndex = 23;
            this.LBFolio.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(40, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Folio:";
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Contabilidad.DSContabilidadTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // gRIDPVGASTOADICTableAdapter
            // 
            this.gRIDPVGASTOADICTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(286, 379);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 32);
            this.button1.TabIndex = 163;
            this.button1.Text = "Terminar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // WFReciboGastosAdicEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(666, 461);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gRIDPVGASTODataGridView);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.TBMonto);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.pnlCorteSeleccion);
            this.Controls.Add(this.GASTOButton);
            this.Controls.Add(this.GASTOIDTextBox);
            this.Controls.Add(this.GASTOLabel);
            this.Controls.Add(this.mARCAIDLabel);
            this.Controls.Add(this.LBFolio);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFReciboGastosAdicEdit";
            this.Text = "Gastos adicionales";
            this.Load += new System.EventHandler(this.WFReciboGastosAdicEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gRIDPVGASTODataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gRIDPVGASTOADICBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSContabilidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LBFolio;
        private System.Windows.Forms.Button GASTOButton;
        private Tools.TextBoxFB GASTOIDTextBox;
        private System.Windows.Forms.Label GASTOLabel;
        private System.Windows.Forms.Panel pnlCorteSeleccion;
        private System.Windows.Forms.NumericTextBox TBMonto;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnAgregar;
        private Contabilidad.DSContabilidad dSContabilidad;
        private Contabilidad.DSContabilidadTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewE gRIDPVGASTODataGridView;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGGASTOID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGTOTAL;
        private System.Windows.Forms.DataGridViewButtonColumn DGELIMINAR;
        private System.Windows.Forms.Label mARCAIDLabel;
        private System.Windows.Forms.BindingSource gRIDPVGASTOADICBindingSource;
        private Contabilidad.DSContabilidadTableAdapters.GRIDPVGASTOADICTableAdapter gRIDPVGASTOADICTableAdapter;
        private System.Windows.Forms.Button button1;
    }
}