namespace iPos.Convertidor
{
    partial class WinFormToWPF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinFormToWPF));
            this.TBRutaModificar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TBRutaProyectoBase = new System.Windows.Forms.TextBox();
            this.dSConvertidor = new iPos.Convertidor.DSConvertidor();
            this.fORMULARIOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fORMULARIOSDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnConvertir = new System.Windows.Forms.Button();
            this.aRCHIVOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aRCHIVOSDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dSConvertidor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fORMULARIOSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fORMULARIOSDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aRCHIVOSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aRCHIVOSDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TBRutaModificar
            // 
            this.TBRutaModificar.Location = new System.Drawing.Point(148, 57);
            this.TBRutaModificar.Name = "TBRutaModificar";
            this.TBRutaModificar.Size = new System.Drawing.Size(255, 20);
            this.TBRutaModificar.TabIndex = 0;
            this.TBRutaModificar.Text = "C:\\IposProject\\iPosRopa2Prueba2\\iPos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(40, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ruta a modificar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(40, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ruta a proyecto base";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // TBRutaProyectoBase
            // 
            this.TBRutaProyectoBase.Location = new System.Drawing.Point(148, 19);
            this.TBRutaProyectoBase.Name = "TBRutaProyectoBase";
            this.TBRutaProyectoBase.Size = new System.Drawing.Size(255, 20);
            this.TBRutaProyectoBase.TabIndex = 3;
            this.TBRutaProyectoBase.Text = "C:\\IposProject\\iPosRopa\\iPos";
            // 
            // dSConvertidor
            // 
            this.dSConvertidor.DataSetName = "DSConvertidor";
            this.dSConvertidor.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fORMULARIOSBindingSource
            // 
            this.fORMULARIOSBindingSource.DataMember = "FORMULARIOS";
            this.fORMULARIOSBindingSource.DataSource = this.dSConvertidor;
            // 
            // fORMULARIOSDataGridView
            // 
            this.fORMULARIOSDataGridView.AutoGenerateColumns = false;
            this.fORMULARIOSDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fORMULARIOSDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.fORMULARIOSDataGridView.DataSource = this.fORMULARIOSBindingSource;
            this.fORMULARIOSDataGridView.Location = new System.Drawing.Point(12, 112);
            this.fORMULARIOSDataGridView.Name = "fORMULARIOSDataGridView";
            this.fORMULARIOSDataGridView.Size = new System.Drawing.Size(325, 220);
            this.fORMULARIOSDataGridView.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "NOMBRE";
            this.dataGridViewTextBoxColumn1.HeaderText = "NOMBRE";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NOMBRECOMPLETO";
            this.dataGridViewTextBoxColumn2.HeaderText = "NOMBRECOMPLETO";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "RUTA";
            this.dataGridViewTextBoxColumn3.HeaderText = "RUTA";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // btnConvertir
            // 
            this.btnConvertir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.btnConvertir.ForeColor = System.Drawing.Color.White;
            this.btnConvertir.Location = new System.Drawing.Point(148, 83);
            this.btnConvertir.Name = "btnConvertir";
            this.btnConvertir.Size = new System.Drawing.Size(75, 23);
            this.btnConvertir.TabIndex = 6;
            this.btnConvertir.Text = "Convertir";
            this.btnConvertir.UseVisualStyleBackColor = false;
            this.btnConvertir.Click += new System.EventHandler(this.btnConvertir_Click);
            // 
            // aRCHIVOSBindingSource
            // 
            this.aRCHIVOSBindingSource.DataMember = "ARCHIVOS";
            this.aRCHIVOSBindingSource.DataSource = this.dSConvertidor;
            // 
            // aRCHIVOSDataGridView
            // 
            this.aRCHIVOSDataGridView.AutoGenerateColumns = false;
            this.aRCHIVOSDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.aRCHIVOSDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.aRCHIVOSDataGridView.DataSource = this.aRCHIVOSBindingSource;
            this.aRCHIVOSDataGridView.Location = new System.Drawing.Point(360, 112);
            this.aRCHIVOSDataGridView.Name = "aRCHIVOSDataGridView";
            this.aRCHIVOSDataGridView.Size = new System.Drawing.Size(300, 220);
            this.aRCHIVOSDataGridView.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "NOMBRE";
            this.dataGridViewTextBoxColumn4.HeaderText = "NOMBRE";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "RUTA";
            this.dataGridViewTextBoxColumn5.HeaderText = "RUTA";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(484, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // WinFormToWPF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(708, 393);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.aRCHIVOSDataGridView);
            this.Controls.Add(this.btnConvertir);
            this.Controls.Add(this.fORMULARIOSDataGridView);
            this.Controls.Add(this.TBRutaProyectoBase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBRutaModificar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WinFormToWPF";
            this.Text = "WinFormToWPF";
            ((System.ComponentModel.ISupportInitialize)(this.dSConvertidor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fORMULARIOSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fORMULARIOSDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aRCHIVOSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aRCHIVOSDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBRutaModificar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBRutaProyectoBase;
        private DSConvertidor dSConvertidor;
        private System.Windows.Forms.BindingSource fORMULARIOSBindingSource;
        private System.Windows.Forms.DataGridViewSum fORMULARIOSDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button btnConvertir;
        private System.Windows.Forms.BindingSource aRCHIVOSBindingSource;
        private System.Windows.Forms.DataGridViewSum aRCHIVOSDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Button button1;
    }
}