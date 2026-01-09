namespace iPos
{
    partial class CortesEdicion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CortesEdicion));
            this.cortesDeFechaDataGridView = new System.Windows.Forms.DataGridViewSum();
            this.cortesDeFechaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSCortes = new iPos.Cortes.DSCortes();
            this.DTFecha = new System.Windows.Forms.DateTimePicker();
            this.BTEnviar = new System.Windows.Forms.Button();
            this.cortesDeFechaTableAdapter = new iPos.Cortes.DSCortesTableAdapters.CortesDeFechaTableAdapter();
            this.tableAdapterManager = new iPos.Cortes.DSCortesTableAdapters.TableAdapterManager();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INICIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TERMINA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditarCorte = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnReporte = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCORTEID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCAJEROID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.cortesDeFechaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cortesDeFechaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCortes)).BeginInit();
            this.SuspendLayout();
            // 
            // cortesDeFechaDataGridView
            // 
            this.cortesDeFechaDataGridView.AllowUserToAddRows = false;
            this.cortesDeFechaDataGridView.AutoGenerateColumns = false;
            this.cortesDeFechaDataGridView.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cortesDeFechaDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.cortesDeFechaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cortesDeFechaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn5,
            this.INICIA,
            this.TERMINA,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.btnEditarCorte,
            this.btnReporte,
            this.dataGridViewTextBoxColumn10,
            this.DGCORTEID,
            this.DGCAJEROID});
            this.cortesDeFechaDataGridView.DataSource = this.cortesDeFechaBindingSource;
            this.cortesDeFechaDataGridView.EnableHeadersVisualStyles = false;
            this.cortesDeFechaDataGridView.Location = new System.Drawing.Point(2, 72);
            this.cortesDeFechaDataGridView.Name = "cortesDeFechaDataGridView";
            this.cortesDeFechaDataGridView.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cortesDeFechaDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.cortesDeFechaDataGridView.RowHeadersVisible = false;
            this.cortesDeFechaDataGridView.Size = new System.Drawing.Size(844, 340);
            this.cortesDeFechaDataGridView.TabIndex = 2;
            this.cortesDeFechaDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cortesDeFechaDataGridView_CellContentClick);
            this.cortesDeFechaDataGridView.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.cortesDeFechaDataGridView_PreviewKeyDown);
            // 
            // cortesDeFechaBindingSource
            // 
            this.cortesDeFechaBindingSource.DataMember = "CortesDeFecha";
            this.cortesDeFechaBindingSource.DataSource = this.dSCortes;
            // 
            // dSCortes
            // 
            this.dSCortes.DataSetName = "DSCortes";
            this.dSCortes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DTFecha
            // 
            this.DTFecha.Enabled = false;
            this.DTFecha.Location = new System.Drawing.Point(340, 28);
            this.DTFecha.Name = "DTFecha";
            this.DTFecha.Size = new System.Drawing.Size(200, 20);
            this.DTFecha.TabIndex = 4;
            // 
            // BTEnviar
            // 
            this.BTEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.BTEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.BTEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.BTEnviar.ForeColor = System.Drawing.Color.White;
            this.BTEnviar.Location = new System.Drawing.Point(560, 24);
            this.BTEnviar.Name = "BTEnviar";
            this.BTEnviar.Size = new System.Drawing.Size(78, 25);
            this.BTEnviar.TabIndex = 174;
            this.BTEnviar.Text = "Enviar";
            this.BTEnviar.UseVisualStyleBackColor = false;
            this.BTEnviar.Click += new System.EventHandler(this.BTEnviar_Click);
            // 
            // cortesDeFechaTableAdapter
            // 
            this.cortesDeFechaTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Cortes.DSCortesTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(230, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 15);
            this.label1.TabIndex = 175;
            this.label1.Text = "Fecha de corte:";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 75;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.DataPropertyName = "ID";
            this.dataGridViewButtonColumn1.HeaderText = "HISTORIAL";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn1.Text = "Ver";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "CAJEROID";
            this.dataGridViewTextBoxColumn11.HeaderText = "CAJEROID";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FECHACORTE";
            this.dataGridViewTextBoxColumn2.HeaderText = "FECHA CORTE";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "CAJERONOMBRE";
            this.dataGridViewTextBoxColumn9.HeaderText = "CAJERO";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 130;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "SALDOINICIAL";
            dataGridViewCellStyle2.Format = "N2";
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn5.HeaderText = "SALDO INICIAL";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 75;
            // 
            // INICIA
            // 
            this.INICIA.DataPropertyName = "INICIA";
            dataGridViewCellStyle3.Format = "t";
            dataGridViewCellStyle3.NullValue = null;
            this.INICIA.DefaultCellStyle = dataGridViewCellStyle3;
            this.INICIA.HeaderText = "INICIA";
            this.INICIA.Name = "INICIA";
            this.INICIA.ReadOnly = true;
            this.INICIA.Width = 75;
            // 
            // TERMINA
            // 
            this.TERMINA.DataPropertyName = "TERMINA";
            dataGridViewCellStyle4.Format = "t";
            dataGridViewCellStyle4.NullValue = null;
            this.TERMINA.DefaultCellStyle = dataGridViewCellStyle4;
            this.TERMINA.HeaderText = "TERMINA";
            this.TERMINA.Name = "TERMINA";
            this.TERMINA.ReadOnly = true;
            this.TERMINA.Width = 75;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "SALDOFINAL";
            dataGridViewCellStyle5.Format = "N2";
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn6.HeaderText = "SALDO FINAL";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "SALDOREAL";
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn7.HeaderText = "SALDO REAL";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "DIFERENCIA";
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn8.HeaderText = "DIFERENCIA";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 80;
            // 
            // btnEditarCorte
            // 
            this.btnEditarCorte.HeaderText = "";
            this.btnEditarCorte.Image = global::iPos.Properties.Resources.edit_J;
            this.btnEditarCorte.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.btnEditarCorte.Name = "btnEditarCorte";
            this.btnEditarCorte.ReadOnly = true;
            this.btnEditarCorte.Width = 30;
            // 
            // btnReporte
            // 
            this.btnReporte.HeaderText = "";
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.ReadOnly = true;
            this.btnReporte.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnReporte.Text = "Ver Historial";
            this.btnReporte.UseColumnTextForButtonValue = true;
            this.btnReporte.Width = 75;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "CAJEROUSERNAME";
            this.dataGridViewTextBoxColumn10.HeaderText = "CAJERO NOMBRE USUARIO";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 75;
            // 
            // DGCORTEID
            // 
            this.DGCORTEID.DataPropertyName = "ID";
            this.DGCORTEID.HeaderText = "ID";
            this.DGCORTEID.Name = "DGCORTEID";
            this.DGCORTEID.ReadOnly = true;
            this.DGCORTEID.Width = 75;
            // 
            // DGCAJEROID
            // 
            this.DGCAJEROID.DataPropertyName = "CAJEROID";
            this.DGCAJEROID.HeaderText = "CAJEROID";
            this.DGCAJEROID.Name = "DGCAJEROID";
            this.DGCAJEROID.ReadOnly = true;
            this.DGCAJEROID.Visible = false;
            // 
            // CortesEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(848, 433);
            this.Controls.Add(this.cortesDeFechaDataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTEnviar);
            this.Controls.Add(this.DTFecha);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CortesEdicion";
            this.Text = "Cortes Edicion";
            this.Load += new System.EventHandler(this.CortesEdicion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cortesDeFechaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cortesDeFechaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCortes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Cortes.DSCortes dSCortes;
        private System.Windows.Forms.BindingSource cortesDeFechaBindingSource;
        private Cortes.DSCortesTableAdapters.CortesDeFechaTableAdapter cortesDeFechaTableAdapter;
        private Cortes.DSCortesTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewSum cortesDeFechaDataGridView;
        private System.Windows.Forms.DateTimePicker DTFecha;
        private System.Windows.Forms.Button BTEnviar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn INICIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TERMINA;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewImageColumn btnEditarCorte;
        private System.Windows.Forms.DataGridViewButtonColumn btnReporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCORTEID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCAJEROID;
    }
}