namespace iPos.Login_and_Maintenance
{
    partial class TestLog
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
            this.dETALLELOGDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dETALLELOGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSSeguridad = new iPos.Login_and_Maintenance.DSSeguridad();
            ((System.ComponentModel.ISupportInitialize)(this.dETALLELOGDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dETALLELOGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSSeguridad)).BeginInit();
            this.SuspendLayout();
            // 
            // dETALLELOGDataGridView
            // 
            this.dETALLELOGDataGridView.AutoGenerateColumns = false;
            this.dETALLELOGDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dETALLELOGDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dETALLELOGDataGridView.DataSource = this.dETALLELOGBindingSource;
            this.dETALLELOGDataGridView.Location = new System.Drawing.Point(150, 70);
            this.dETALLELOGDataGridView.Name = "dETALLELOGDataGridView";
            this.dETALLELOGDataGridView.Size = new System.Drawing.Size(343, 220);
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
            // dETALLELOGBindingSource
            // 
            this.dETALLELOGBindingSource.DataMember = "DETALLELOG";
            this.dETALLELOGBindingSource.DataSource = this.dSSeguridad;
            // 
            // dSSeguridad
            // 
            this.dSSeguridad.DataSetName = "DSSeguridad";
            this.dSSeguridad.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TestLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 381);
            this.Controls.Add(this.dETALLELOGDataGridView);
            this.Name = "TestLog";
            this.Text = "TestLog";
            this.Load += new System.EventHandler(this.TestLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dETALLELOGDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dETALLELOGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSSeguridad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DSSeguridad dSSeguridad;
        private System.Windows.Forms.BindingSource dETALLELOGBindingSource;
        private System.Windows.Forms.DataGridView dETALLELOGDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}