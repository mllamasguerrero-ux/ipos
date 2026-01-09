namespace iPos.Exportaciones
{
    partial class WFSolicitudMercanciaList
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
            this.sOLICITUDMERCAENVIADADataGridView = new System.Windows.Forms.DataGridView();
            this.DTPFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.DTPFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnNueva = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.sOLICITUDMERCAENVIADABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSExportaciones = new iPos.Exportaciones.DSExportaciones();
            this.sOLICITUDMERCAENVIADATableAdapter = new iPos.Exportaciones.DSExportacionesTableAdapters.SOLICITUDMERCAENVIADATableAdapter();
            this.tableAdapterManager = new iPos.Exportaciones.DSExportacionesTableAdapters.TableAdapterManager();
            this.DGBtnVer = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DGBtnEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUCURSALCLAVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBSoloPendientes = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.sOLICITUDMERCAENVIADADataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sOLICITUDMERCAENVIADABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSExportaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // sOLICITUDMERCAENVIADADataGridView
            // 
            this.sOLICITUDMERCAENVIADADataGridView.AllowUserToAddRows = false;
            this.sOLICITUDMERCAENVIADADataGridView.AutoGenerateColumns = false;
            this.sOLICITUDMERCAENVIADADataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sOLICITUDMERCAENVIADADataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGBtnVer,
            this.DGBtnEliminar,
            this.DGID,
            this.dataGridViewTextBoxColumn2,
            this.SUCURSALCLAVE,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.sOLICITUDMERCAENVIADADataGridView.DataSource = this.sOLICITUDMERCAENVIADABindingSource;
            this.sOLICITUDMERCAENVIADADataGridView.Location = new System.Drawing.Point(12, 136);
            this.sOLICITUDMERCAENVIADADataGridView.Name = "sOLICITUDMERCAENVIADADataGridView";
            this.sOLICITUDMERCAENVIADADataGridView.RowHeadersVisible = false;
            this.sOLICITUDMERCAENVIADADataGridView.Size = new System.Drawing.Size(833, 269);
            this.sOLICITUDMERCAENVIADADataGridView.TabIndex = 2;
            this.sOLICITUDMERCAENVIADADataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sOLICITUDMERCAENVIADADataGridView_CellContentClick);
            // 
            // DTPFechaInicio
            // 
            this.DTPFechaInicio.Location = new System.Drawing.Point(103, 47);
            this.DTPFechaInicio.Name = "DTPFechaInicio";
            this.DTPFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.DTPFechaInicio.TabIndex = 3;
            // 
            // DTPFechaFin
            // 
            this.DTPFechaFin.Location = new System.Drawing.Point(412, 47);
            this.DTPFechaFin.Name = "DTPFechaFin";
            this.DTPFechaFin.Size = new System.Drawing.Size(200, 20);
            this.DTPFechaFin.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Fecha inicial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(327, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Fecha final";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(758, 40);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnNueva
            // 
            this.btnNueva.Location = new System.Drawing.Point(521, 107);
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(132, 23);
            this.btnNueva.TabIndex = 8;
            this.btnNueva.Text = "Nueva Solicitud";
            this.btnNueva.UseVisualStyleBackColor = true;
            this.btnNueva.Click += new System.EventHandler(this.btnNueva_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(41, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "SOLICITUDES DE MERCANCIA";
            // 
            // sOLICITUDMERCAENVIADABindingSource
            // 
            this.sOLICITUDMERCAENVIADABindingSource.DataMember = "SOLICITUDMERCAENVIADA";
            this.sOLICITUDMERCAENVIADABindingSource.DataSource = this.dSExportaciones;
            // 
            // dSExportaciones
            // 
            this.dSExportaciones.DataSetName = "DSExportaciones";
            this.dSExportaciones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sOLICITUDMERCAENVIADATableAdapter
            // 
            this.sOLICITUDMERCAENVIADATableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Exportaciones.DSExportacionesTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // DGBtnVer
            // 
            this.DGBtnVer.HeaderText = "VER";
            this.DGBtnVer.Name = "DGBtnVer";
            this.DGBtnVer.Text = "VER";
            this.DGBtnVer.UseColumnTextForButtonValue = true;
            this.DGBtnVer.Width = 65;
            // 
            // DGBtnEliminar
            // 
            this.DGBtnEliminar.HeaderText = "ELIMINAR";
            this.DGBtnEliminar.Name = "DGBtnEliminar";
            this.DGBtnEliminar.Text = "ELIMINAR";
            this.DGBtnEliminar.UseColumnTextForButtonValue = true;
            this.DGBtnEliminar.Width = 75;
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
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FOLIO";
            this.dataGridViewTextBoxColumn2.HeaderText = "FOLIO";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // SUCURSALCLAVE
            // 
            this.SUCURSALCLAVE.DataPropertyName = "SUCURSALCLAVE";
            this.SUCURSALCLAVE.HeaderText = "SUCURSAL CLAVE";
            this.SUCURSALCLAVE.Name = "SUCURSALCLAVE";
            this.SUCURSALCLAVE.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NOMBRE";
            this.dataGridViewTextBoxColumn3.HeaderText = "NOMBRE";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "FECHA";
            this.dataGridViewTextBoxColumn4.HeaderText = "FECHA";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "ESTATUSPEDIDO";
            this.dataGridViewTextBoxColumn10.HeaderText = "ESTATUS PEDIDO";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "CORTEID";
            this.dataGridViewTextBoxColumn7.HeaderText = "CORTEID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "VENDEDORID";
            this.dataGridViewTextBoxColumn8.HeaderText = "VENDEDORID";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "NOMBRECAJERO";
            this.dataGridViewTextBoxColumn9.HeaderText = "NOMBRE CAJERO";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "SUBTIPODOCTOID";
            this.dataGridViewTextBoxColumn11.HeaderText = "SUBTIPODOCTOID";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "TRASLADOAFTP";
            this.dataGridViewTextBoxColumn12.HeaderText = "TRASLADOAFTP";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Visible = false;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "EXPFILEID";
            this.dataGridViewTextBoxColumn13.HeaderText = "EXPFILEID";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Visible = false;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "ESTATUS";
            this.dataGridViewTextBoxColumn14.HeaderText = "ESTATUS";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "FECHAINI";
            this.dataGridViewTextBoxColumn5.HeaderText = "FECHAINI";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "FECHAFIN";
            this.dataGridViewTextBoxColumn6.HeaderText = "FECHAFIN";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // CBSoloPendientes
            // 
            this.CBSoloPendientes.AutoSize = true;
            this.CBSoloPendientes.BackColor = System.Drawing.Color.Transparent;
            this.CBSoloPendientes.Checked = true;
            this.CBSoloPendientes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBSoloPendientes.ForeColor = System.Drawing.Color.White;
            this.CBSoloPendientes.Location = new System.Drawing.Point(630, 46);
            this.CBSoloPendientes.Name = "CBSoloPendientes";
            this.CBSoloPendientes.Size = new System.Drawing.Size(102, 17);
            this.CBSoloPendientes.TabIndex = 10;
            this.CBSoloPendientes.Text = "Solo pendientes";
            this.CBSoloPendientes.UseVisualStyleBackColor = false;
            // 
            // WFSolicitudMercanciaList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(857, 450);
            this.Controls.Add(this.CBSoloPendientes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnNueva);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTPFechaFin);
            this.Controls.Add(this.DTPFechaInicio);
            this.Controls.Add(this.sOLICITUDMERCAENVIADADataGridView);
            this.Name = "WFSolicitudMercanciaList";
            this.Text = "WFSolicitudMercanciaList";
            this.Load += new System.EventHandler(this.WFSolicitudMercanciaList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sOLICITUDMERCAENVIADADataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sOLICITUDMERCAENVIADABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSExportaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DSExportaciones dSExportaciones;
        private System.Windows.Forms.BindingSource sOLICITUDMERCAENVIADABindingSource;
        private DSExportacionesTableAdapters.SOLICITUDMERCAENVIADATableAdapter sOLICITUDMERCAENVIADATableAdapter;
        private DSExportacionesTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView sOLICITUDMERCAENVIADADataGridView;
        private System.Windows.Forms.DateTimePicker DTPFechaInicio;
        private System.Windows.Forms.DateTimePicker DTPFechaFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnNueva;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewButtonColumn DGBtnVer;
        private System.Windows.Forms.DataGridViewButtonColumn DGBtnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUCURSALCLAVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.CheckBox CBSoloPendientes;
    }
}