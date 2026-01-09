namespace iPos.PuntoDeVenta
{
    partial class WFProductosSinClaveSat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFProductosSinClaveSat));
            this.dSSatFacturacion = new iPos.PuntoDeVenta.DSSatFacturacion();
            this.pRODUCTOS_SIN_CLAVESATBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pRODUCTOS_SIN_CLAVESATTableAdapter = new iPos.PuntoDeVenta.DSSatFacturacionTableAdapters.PRODUCTOS_SIN_CLAVESATTableAdapter();
            this.tableAdapterManager = new iPos.PuntoDeVenta.DSSatFacturacionTableAdapters.TableAdapterManager();
            this.pRODUCTOS_SIN_CLAVESATDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dSSatFacturacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRODUCTOS_SIN_CLAVESATBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRODUCTOS_SIN_CLAVESATDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dSSatFacturacion
            // 
            this.dSSatFacturacion.DataSetName = "DSSatFacturacion";
            this.dSSatFacturacion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pRODUCTOS_SIN_CLAVESATBindingSource
            // 
            this.pRODUCTOS_SIN_CLAVESATBindingSource.DataMember = "PRODUCTOS_SIN_CLAVESAT";
            this.pRODUCTOS_SIN_CLAVESATBindingSource.DataSource = this.dSSatFacturacion;
            // 
            // pRODUCTOS_SIN_CLAVESATTableAdapter
            // 
            this.pRODUCTOS_SIN_CLAVESATTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.PRODUCTOS_SIN_CLAVESATTableAdapter = this.pRODUCTOS_SIN_CLAVESATTableAdapter;
            this.tableAdapterManager.UpdateOrder = iPos.PuntoDeVenta.DSSatFacturacionTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // pRODUCTOS_SIN_CLAVESATDataGridView
            // 
            this.pRODUCTOS_SIN_CLAVESATDataGridView.AutoGenerateColumns = false;
            this.pRODUCTOS_SIN_CLAVESATDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pRODUCTOS_SIN_CLAVESATDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.pRODUCTOS_SIN_CLAVESATDataGridView.DataSource = this.pRODUCTOS_SIN_CLAVESATBindingSource;
            this.pRODUCTOS_SIN_CLAVESATDataGridView.Location = new System.Drawing.Point(1, 68);
            this.pRODUCTOS_SIN_CLAVESATDataGridView.Name = "pRODUCTOS_SIN_CLAVESATDataGridView";
            this.pRODUCTOS_SIN_CLAVESATDataGridView.RowHeadersVisible = false;
            this.pRODUCTOS_SIN_CLAVESATDataGridView.Size = new System.Drawing.Size(494, 238);
            this.pRODUCTOS_SIN_CLAVESATDataGridView.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CLAVE";
            this.dataGridViewTextBoxColumn2.HeaderText = "CLAVE";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 170;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DESCRIPCION1";
            this.dataGridViewTextBoxColumn3.HeaderText = "DESCRIPCION1";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 220;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Transparent;
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(203, 317);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(480, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Los Siguientes Productos no cuentan con Clave del SAT asignada:";
            // 
            // WFProductosSinClaveSat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(495, 352);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.pRODUCTOS_SIN_CLAVESATDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFProductosSinClaveSat";
            this.Text = "Productos Sin Clave del SAT";
            ((System.ComponentModel.ISupportInitialize)(this.dSSatFacturacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRODUCTOS_SIN_CLAVESATBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRODUCTOS_SIN_CLAVESATDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DSSatFacturacion dSSatFacturacion;
        private System.Windows.Forms.BindingSource pRODUCTOS_SIN_CLAVESATBindingSource;
        private DSSatFacturacionTableAdapters.PRODUCTOS_SIN_CLAVESATTableAdapter pRODUCTOS_SIN_CLAVESATTableAdapter;
        private DSSatFacturacionTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum pRODUCTOS_SIN_CLAVESATDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label1;
    }
}