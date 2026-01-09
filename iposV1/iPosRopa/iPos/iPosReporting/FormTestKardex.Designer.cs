namespace iPosReporting
{
	partial class FormTestKardex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTestKardex));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dSReportIpos = new iPosReporting.DSReportIpos();
            this.gET_KARDEXBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gET_KARDEXTableAdapter = new iPosReporting.DSReportIposTableAdapters.GET_KARDEXTableAdapter();
            this.tableAdapterManager = new iPosReporting.DSReportIposTableAdapters.TableAdapterManager();
            this.gET_KARDEXBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.gET_KARDEXBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.fillToolStrip = new System.Windows.Forms.ToolStrip();
            this.pRODUCTO_IDToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.pRODUCTO_IDToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.fECHAINIToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.fECHAINIToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.fECHAFINToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.fECHAFINToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.aLMACENIDToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.aLMACENIDToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.fillToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.gET_KARDEXDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dSReportIpos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gET_KARDEXBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gET_KARDEXBindingNavigator)).BeginInit();
            this.gET_KARDEXBindingNavigator.SuspendLayout();
            this.fillToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gET_KARDEXDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dSReportIpos
            // 
            this.dSReportIpos.DataSetName = "DSReportIpos";
            this.dSReportIpos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gET_KARDEXBindingSource
            // 
            this.gET_KARDEXBindingSource.DataMember = "GET_KARDEX";
            this.gET_KARDEXBindingSource.DataSource = this.dSReportIpos;
            // 
            // gET_KARDEXTableAdapter
            // 
            this.gET_KARDEXTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CLIENTESTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.PRODUCTO1TableAdapter = null;
            this.tableAdapterManager.UpdateOrder = iPosReporting.DSReportIposTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // gET_KARDEXBindingNavigator
            // 
            this.gET_KARDEXBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.gET_KARDEXBindingNavigator.BindingSource = this.gET_KARDEXBindingSource;
            this.gET_KARDEXBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.gET_KARDEXBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.gET_KARDEXBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.gET_KARDEXBindingNavigatorSaveItem});
            this.gET_KARDEXBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.gET_KARDEXBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.gET_KARDEXBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.gET_KARDEXBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.gET_KARDEXBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.gET_KARDEXBindingNavigator.Name = "gET_KARDEXBindingNavigator";
            this.gET_KARDEXBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.gET_KARDEXBindingNavigator.Size = new System.Drawing.Size(987, 25);
            this.gET_KARDEXBindingNavigator.TabIndex = 0;
            this.gET_KARDEXBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // gET_KARDEXBindingNavigatorSaveItem
            // 
            this.gET_KARDEXBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.gET_KARDEXBindingNavigatorSaveItem.Enabled = false;
            this.gET_KARDEXBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("gET_KARDEXBindingNavigatorSaveItem.Image")));
            this.gET_KARDEXBindingNavigatorSaveItem.Name = "gET_KARDEXBindingNavigatorSaveItem";
            this.gET_KARDEXBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.gET_KARDEXBindingNavigatorSaveItem.Text = "Save Data";
            // 
            // fillToolStrip
            // 
            this.fillToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pRODUCTO_IDToolStripLabel,
            this.pRODUCTO_IDToolStripTextBox,
            this.fECHAINIToolStripLabel,
            this.fECHAINIToolStripTextBox,
            this.fECHAFINToolStripLabel,
            this.fECHAFINToolStripTextBox,
            this.aLMACENIDToolStripLabel,
            this.aLMACENIDToolStripTextBox,
            this.fillToolStripButton});
            this.fillToolStrip.Location = new System.Drawing.Point(0, 25);
            this.fillToolStrip.Name = "fillToolStrip";
            this.fillToolStrip.Size = new System.Drawing.Size(987, 25);
            this.fillToolStrip.TabIndex = 1;
            this.fillToolStrip.Text = "fillToolStrip";
            // 
            // pRODUCTO_IDToolStripLabel
            // 
            this.pRODUCTO_IDToolStripLabel.Name = "pRODUCTO_IDToolStripLabel";
            this.pRODUCTO_IDToolStripLabel.Size = new System.Drawing.Size(88, 22);
            this.pRODUCTO_IDToolStripLabel.Text = "PRODUCTO_ID:";
            // 
            // pRODUCTO_IDToolStripTextBox
            // 
            this.pRODUCTO_IDToolStripTextBox.Name = "pRODUCTO_IDToolStripTextBox";
            this.pRODUCTO_IDToolStripTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // fECHAINIToolStripLabel
            // 
            this.fECHAINIToolStripLabel.Name = "fECHAINIToolStripLabel";
            this.fECHAINIToolStripLabel.Size = new System.Drawing.Size(62, 22);
            this.fECHAINIToolStripLabel.Text = "FECHAINI:";
            // 
            // fECHAINIToolStripTextBox
            // 
            this.fECHAINIToolStripTextBox.Name = "fECHAINIToolStripTextBox";
            this.fECHAINIToolStripTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // fECHAFINToolStripLabel
            // 
            this.fECHAFINToolStripLabel.Name = "fECHAFINToolStripLabel";
            this.fECHAFINToolStripLabel.Size = new System.Drawing.Size(65, 22);
            this.fECHAFINToolStripLabel.Text = "FECHAFIN:";
            // 
            // fECHAFINToolStripTextBox
            // 
            this.fECHAFINToolStripTextBox.Name = "fECHAFINToolStripTextBox";
            this.fECHAFINToolStripTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // aLMACENIDToolStripLabel
            // 
            this.aLMACENIDToolStripLabel.Name = "aLMACENIDToolStripLabel";
            this.aLMACENIDToolStripLabel.Size = new System.Drawing.Size(77, 22);
            this.aLMACENIDToolStripLabel.Text = "ALMACENID:";
            // 
            // aLMACENIDToolStripTextBox
            // 
            this.aLMACENIDToolStripTextBox.Name = "aLMACENIDToolStripTextBox";
            this.aLMACENIDToolStripTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // fillToolStripButton
            // 
            this.fillToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillToolStripButton.Name = "fillToolStripButton";
            this.fillToolStripButton.Size = new System.Drawing.Size(26, 22);
            this.fillToolStripButton.Text = "Fill";
            this.fillToolStripButton.Click += new System.EventHandler(this.fillToolStripButton_Click);
            // 
            // gET_KARDEXDataGridView
            // 
            this.gET_KARDEXDataGridView.AllowUserToAddRows = false;
            this.gET_KARDEXDataGridView.AllowUserToDeleteRows = false;
            this.gET_KARDEXDataGridView.AllowUserToResizeRows = false;
            this.gET_KARDEXDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gET_KARDEXDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gET_KARDEXDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gET_KARDEXDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16});
            this.gET_KARDEXDataGridView.DataSource = this.gET_KARDEXBindingSource;
            this.gET_KARDEXDataGridView.Location = new System.Drawing.Point(24, 77);
            this.gET_KARDEXDataGridView.Name = "gET_KARDEXDataGridView";
            this.gET_KARDEXDataGridView.Size = new System.Drawing.Size(951, 220);
            this.gET_KARDEXDataGridView.TabIndex = 2;
            this.gET_KARDEXDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gET_KARDEXDataGridView_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "NUMERO";
            this.dataGridViewTextBoxColumn1.HeaderText = "NUMERO";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "KARDEXID";
            this.dataGridViewTextBoxColumn2.HeaderText = "KARDEXID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DOCTOID";
            this.dataGridViewTextBoxColumn3.HeaderText = "DOCTOID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "MOVTOID";
            this.dataGridViewTextBoxColumn4.HeaderText = "MOVTOID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "PRODUCTOID";
            this.dataGridViewTextBoxColumn5.HeaderText = "PRODUCTOID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "SUCURSALID";
            this.dataGridViewTextBoxColumn6.HeaderText = "SUCURSALID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "FECHA";
            this.dataGridViewTextBoxColumn7.HeaderText = "FECHA";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "FECHAHORA";
            this.dataGridViewTextBoxColumn8.HeaderText = "FECHAHORA";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "SUCURSALCLAVE";
            this.dataGridViewTextBoxColumn9.HeaderText = "SUCURSALCLAVE";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "TIPODOCTOCLAVE";
            this.dataGridViewTextBoxColumn10.HeaderText = "TIPODOCTOCLAVE";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "DOCTOFOLIO";
            this.dataGridViewTextBoxColumn11.HeaderText = "DOCTOFOLIO";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "PRODUCTOCLAVE";
            this.dataGridViewTextBoxColumn12.HeaderText = "PRODUCTOCLAVE";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "PRODUCTODESCRIPCION";
            this.dataGridViewTextBoxColumn13.HeaderText = "PRODUCTODESCRIPCION";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "CANTIDADINI";
            this.dataGridViewTextBoxColumn14.HeaderText = "CANTIDADINI";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "CANTIDADMOV";
            this.dataGridViewTextBoxColumn15.HeaderText = "CANTIDADMOV";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "CANTIDADFIN";
            this.dataGridViewTextBoxColumn16.HeaderText = "CANTIDADFIN";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // FormTestKardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPosReporting.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(987, 648);
            this.Controls.Add(this.gET_KARDEXDataGridView);
            this.Controls.Add(this.fillToolStrip);
            this.Controls.Add(this.gET_KARDEXBindingNavigator);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTestKardex";
            this.Text = "FormTestKardex";
            ((System.ComponentModel.ISupportInitialize)(this.dSReportIpos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gET_KARDEXBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gET_KARDEXBindingNavigator)).EndInit();
            this.gET_KARDEXBindingNavigator.ResumeLayout(false);
            this.gET_KARDEXBindingNavigator.PerformLayout();
            this.fillToolStrip.ResumeLayout(false);
            this.fillToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gET_KARDEXDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private DSReportIpos dSReportIpos;
		private System.Windows.Forms.BindingSource gET_KARDEXBindingSource;
		private iPosReporting.DSReportIposTableAdapters.GET_KARDEXTableAdapter gET_KARDEXTableAdapter;
		private iPosReporting.DSReportIposTableAdapters.TableAdapterManager tableAdapterManager;
		private System.Windows.Forms.BindingNavigator gET_KARDEXBindingNavigator;
		private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
		private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
		private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
		private System.Windows.Forms.ToolStripButton gET_KARDEXBindingNavigatorSaveItem;
		private System.Windows.Forms.ToolStrip fillToolStrip;
		private System.Windows.Forms.ToolStripLabel pRODUCTO_IDToolStripLabel;
		private System.Windows.Forms.ToolStripTextBox pRODUCTO_IDToolStripTextBox;
		private System.Windows.Forms.ToolStripLabel fECHAINIToolStripLabel;
		private System.Windows.Forms.ToolStripTextBox fECHAINIToolStripTextBox;
		private System.Windows.Forms.ToolStripLabel fECHAFINToolStripLabel;
		private System.Windows.Forms.ToolStripTextBox fECHAFINToolStripTextBox;
		private System.Windows.Forms.ToolStripLabel aLMACENIDToolStripLabel;
		private System.Windows.Forms.ToolStripTextBox aLMACENIDToolStripTextBox;
		private System.Windows.Forms.ToolStripButton fillToolStripButton;
		private System.Windows.Forms.DataGridView gET_KARDEXDataGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
	}
}