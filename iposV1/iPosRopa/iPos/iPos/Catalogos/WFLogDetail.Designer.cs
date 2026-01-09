namespace iPos
{
    partial class WFLogDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFLogDetail));
            this.dSCatalogos = new iPos.Catalogos.DSCatalogos();
            this.dETALLELOGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dETALLELOGDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLogUser = new System.Windows.Forms.TextBox();
            this.txtLogDate = new System.Windows.Forms.TextBox();
            this.txtLogTable = new System.Windows.Forms.TextBox();
            this.txtLogRegistry = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dETALLELOGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dETALLELOGDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dSCatalogos
            // 
            this.dSCatalogos.DataSetName = "DSCatalogos";
            this.dSCatalogos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dETALLELOGBindingSource
            // 
            this.dETALLELOGBindingSource.DataMember = "DETALLELOG";
            this.dETALLELOGBindingSource.DataSource = this.dSCatalogos;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(438, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "En el registro:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(92, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sobre la tabla:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(492, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "El día:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cambios realizados por:";
            // 
            // dETALLELOGDataGridView
            // 
            this.dETALLELOGDataGridView.AllowUserToAddRows = false;
            this.dETALLELOGDataGridView.AllowUserToDeleteRows = false;
            this.dETALLELOGDataGridView.AllowUserToOrderColumns = true;
            this.dETALLELOGDataGridView.AutoGenerateColumns = false;
            this.dETALLELOGDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dETALLELOGDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dETALLELOGDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dETALLELOGDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dETALLELOGDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dETALLELOGDataGridView.DataSource = this.dETALLELOGBindingSource;
            this.dETALLELOGDataGridView.Location = new System.Drawing.Point(29, 116);
            this.dETALLELOGDataGridView.Name = "dETALLELOGDataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dETALLELOGDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dETALLELOGDataGridView.RowHeadersVisible = false;
            this.dETALLELOGDataGridView.Size = new System.Drawing.Size(729, 295);
            this.dETALLELOGDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CAMPO";
            this.dataGridViewTextBoxColumn1.HeaderText = "CAMPO";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ANTES";
            this.dataGridViewTextBoxColumn2.HeaderText = "ANTES";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DESPUES";
            this.dataGridViewTextBoxColumn3.HeaderText = "DESPUES";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // txtLogUser
            // 
            this.txtLogUser.Enabled = false;
            this.txtLogUser.Location = new System.Drawing.Point(209, 20);
            this.txtLogUser.Name = "txtLogUser";
            this.txtLogUser.Size = new System.Drawing.Size(174, 20);
            this.txtLogUser.TabIndex = 6;
            // 
            // txtLogDate
            // 
            this.txtLogDate.Enabled = false;
            this.txtLogDate.Location = new System.Drawing.Point(550, 22);
            this.txtLogDate.Name = "txtLogDate";
            this.txtLogDate.Size = new System.Drawing.Size(208, 20);
            this.txtLogDate.TabIndex = 7;
            // 
            // txtLogTable
            // 
            this.txtLogTable.Enabled = false;
            this.txtLogTable.Location = new System.Drawing.Point(209, 68);
            this.txtLogTable.Name = "txtLogTable";
            this.txtLogTable.Size = new System.Drawing.Size(174, 20);
            this.txtLogTable.TabIndex = 8;
            // 
            // txtLogRegistry
            // 
            this.txtLogRegistry.Enabled = false;
            this.txtLogRegistry.Location = new System.Drawing.Point(550, 68);
            this.txtLogRegistry.Name = "txtLogRegistry";
            this.txtLogRegistry.Size = new System.Drawing.Size(208, 20);
            this.txtLogRegistry.TabIndex = 9;
            // 
            // WFLogDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(800, 433);
            this.Controls.Add(this.txtLogRegistry);
            this.Controls.Add(this.txtLogTable);
            this.Controls.Add(this.txtLogDate);
            this.Controls.Add(this.txtLogUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dETALLELOGDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFLogDetail";
            this.Text = "Detalle de modificación";
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dETALLELOGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dETALLELOGDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Catalogos.DSCatalogos dSCatalogos;
        private System.Windows.Forms.BindingSource dETALLELOGBindingSource;
        private System.Windows.Forms.DataGridViewSum dETALLELOGDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLogUser;
        private System.Windows.Forms.TextBox txtLogDate;
        private System.Windows.Forms.TextBox txtLogTable;
        private System.Windows.Forms.TextBox txtLogRegistry;
    }
}