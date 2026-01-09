namespace iPosReporting.Reporteria.ReportesWebExis
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.Label cLAVELabel;
            System.Windows.Forms.Label dESCRIPCION1Label;
            System.Windows.Forms.Label eXISTENCIALabel;
            this.dSWebExis = new iPosReporting.Reporteria.ReportesWebExis.DSWebExis();
            this.eXISTENCIAWEBEXISBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eXISTENCIAWEBEXISTableAdapter = new iPosReporting.Reporteria.ReportesWebExis.DSWebExisTableAdapters.EXISTENCIAWEBEXISTableAdapter();
            this.tableAdapterManager = new iPosReporting.Reporteria.ReportesWebExis.DSWebExisTableAdapters.TableAdapterManager();
            this.eXISTENCIAWEBEXISBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.eXISTENCIAWEBEXISBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.cLAVETextBox = new System.Windows.Forms.TextBox();
            this.dESCRIPCION1TextBox = new System.Windows.Forms.TextBox();
            this.eXISTENCIATextBox = new System.Windows.Forms.TextBox();
            cLAVELabel = new System.Windows.Forms.Label();
            dESCRIPCION1Label = new System.Windows.Forms.Label();
            eXISTENCIALabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dSWebExis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eXISTENCIAWEBEXISBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eXISTENCIAWEBEXISBindingNavigator)).BeginInit();
            this.eXISTENCIAWEBEXISBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // dSWebExis
            // 
            this.dSWebExis.DataSetName = "DSWebExis";
            this.dSWebExis.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // eXISTENCIAWEBEXISBindingSource
            // 
            this.eXISTENCIAWEBEXISBindingSource.DataMember = "EXISTENCIAWEBEXIS";
            this.eXISTENCIAWEBEXISBindingSource.DataSource = this.dSWebExis;
            // 
            // eXISTENCIAWEBEXISTableAdapter
            // 
            this.eXISTENCIAWEBEXISTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPosReporting.Reporteria.ReportesWebExis.DSWebExisTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // eXISTENCIAWEBEXISBindingNavigator
            // 
            this.eXISTENCIAWEBEXISBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.eXISTENCIAWEBEXISBindingNavigator.BindingSource = this.eXISTENCIAWEBEXISBindingSource;
            this.eXISTENCIAWEBEXISBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.eXISTENCIAWEBEXISBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.eXISTENCIAWEBEXISBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.eXISTENCIAWEBEXISBindingNavigatorSaveItem});
            this.eXISTENCIAWEBEXISBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.eXISTENCIAWEBEXISBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.eXISTENCIAWEBEXISBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.eXISTENCIAWEBEXISBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.eXISTENCIAWEBEXISBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.eXISTENCIAWEBEXISBindingNavigator.Name = "eXISTENCIAWEBEXISBindingNavigator";
            this.eXISTENCIAWEBEXISBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.eXISTENCIAWEBEXISBindingNavigator.Size = new System.Drawing.Size(800, 25);
            this.eXISTENCIAWEBEXISBindingNavigator.TabIndex = 0;
            this.eXISTENCIAWEBEXISBindingNavigator.Text = "bindingNavigator1";
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 15);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 6);
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
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // eXISTENCIAWEBEXISBindingNavigatorSaveItem
            // 
            this.eXISTENCIAWEBEXISBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.eXISTENCIAWEBEXISBindingNavigatorSaveItem.Enabled = false;
            this.eXISTENCIAWEBEXISBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("eXISTENCIAWEBEXISBindingNavigatorSaveItem.Image")));
            this.eXISTENCIAWEBEXISBindingNavigatorSaveItem.Name = "eXISTENCIAWEBEXISBindingNavigatorSaveItem";
            this.eXISTENCIAWEBEXISBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 20);
            this.eXISTENCIAWEBEXISBindingNavigatorSaveItem.Text = "Save Data";
            // 
            // cLAVELabel
            // 
            cLAVELabel.AutoSize = true;
            cLAVELabel.Location = new System.Drawing.Point(370, 130);
            cLAVELabel.Name = "cLAVELabel";
            cLAVELabel.Size = new System.Drawing.Size(44, 13);
            cLAVELabel.TabIndex = 1;
            cLAVELabel.Text = "CLAVE:";
            // 
            // cLAVETextBox
            // 
            this.cLAVETextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eXISTENCIAWEBEXISBindingSource, "CLAVE", true));
            this.cLAVETextBox.Location = new System.Drawing.Point(465, 127);
            this.cLAVETextBox.Name = "cLAVETextBox";
            this.cLAVETextBox.Size = new System.Drawing.Size(100, 20);
            this.cLAVETextBox.TabIndex = 2;
            // 
            // dESCRIPCION1Label
            // 
            dESCRIPCION1Label.AutoSize = true;
            dESCRIPCION1Label.Location = new System.Drawing.Point(370, 156);
            dESCRIPCION1Label.Name = "dESCRIPCION1Label";
            dESCRIPCION1Label.Size = new System.Drawing.Size(89, 13);
            dESCRIPCION1Label.TabIndex = 3;
            dESCRIPCION1Label.Text = "DESCRIPCION1:";
            // 
            // dESCRIPCION1TextBox
            // 
            this.dESCRIPCION1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eXISTENCIAWEBEXISBindingSource, "DESCRIPCION1", true));
            this.dESCRIPCION1TextBox.Location = new System.Drawing.Point(465, 153);
            this.dESCRIPCION1TextBox.Name = "dESCRIPCION1TextBox";
            this.dESCRIPCION1TextBox.Size = new System.Drawing.Size(100, 20);
            this.dESCRIPCION1TextBox.TabIndex = 4;
            // 
            // eXISTENCIALabel
            // 
            eXISTENCIALabel.AutoSize = true;
            eXISTENCIALabel.Location = new System.Drawing.Point(370, 182);
            eXISTENCIALabel.Name = "eXISTENCIALabel";
            eXISTENCIALabel.Size = new System.Drawing.Size(73, 13);
            eXISTENCIALabel.TabIndex = 5;
            eXISTENCIALabel.Text = "EXISTENCIA:";
            // 
            // eXISTENCIATextBox
            // 
            this.eXISTENCIATextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eXISTENCIAWEBEXISBindingSource, "EXISTENCIA", true));
            this.eXISTENCIATextBox.Location = new System.Drawing.Point(465, 179);
            this.eXISTENCIATextBox.Name = "eXISTENCIATextBox";
            this.eXISTENCIATextBox.Size = new System.Drawing.Size(100, 20);
            this.eXISTENCIATextBox.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(cLAVELabel);
            this.Controls.Add(this.cLAVETextBox);
            this.Controls.Add(dESCRIPCION1Label);
            this.Controls.Add(this.dESCRIPCION1TextBox);
            this.Controls.Add(eXISTENCIALabel);
            this.Controls.Add(this.eXISTENCIATextBox);
            this.Controls.Add(this.eXISTENCIAWEBEXISBindingNavigator);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSWebExis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eXISTENCIAWEBEXISBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eXISTENCIAWEBEXISBindingNavigator)).EndInit();
            this.eXISTENCIAWEBEXISBindingNavigator.ResumeLayout(false);
            this.eXISTENCIAWEBEXISBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DSWebExis dSWebExis;
        private System.Windows.Forms.BindingSource eXISTENCIAWEBEXISBindingSource;
        private DSWebExisTableAdapters.EXISTENCIAWEBEXISTableAdapter eXISTENCIAWEBEXISTableAdapter;
        private DSWebExisTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator eXISTENCIAWEBEXISBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton eXISTENCIAWEBEXISBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox cLAVETextBox;
        private System.Windows.Forms.TextBox dESCRIPCION1TextBox;
        private System.Windows.Forms.TextBox eXISTENCIATextBox;
    }
}