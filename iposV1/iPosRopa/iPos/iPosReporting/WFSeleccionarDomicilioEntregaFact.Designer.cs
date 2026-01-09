namespace iPos
{
    partial class WFSeleccionarDomicilioEntregaFact
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dOMICILIOSXPERSONADataGridView = new System.Windows.Forms.DataGridView();
            this.DGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnSeleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dOMICILIOSXPERSONABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSCatalogos3 = new iPosReporting.DSGeneral();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSeleccionPrevia = new System.Windows.Forms.Label();
            this.btnUsarDatosCliente = new System.Windows.Forms.Button();
            this.lblMensajeSeleccion = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dOMICILIOSXPERSONATableAdapter = new iPosReporting.DSGeneralTableAdapters.DOMICILIOSXPERSONATableAdapter();
            this.tableAdapterManager = new iPosReporting.DSGeneralTableAdapters.TableAdapterManager();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dOMICILIOSXPERSONADataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOMICILIOSXPERSONABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogos3)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dOMICILIOSXPERSONADataGridView
            // 
            this.dOMICILIOSXPERSONADataGridView.AllowUserToAddRows = false;
            this.dOMICILIOSXPERSONADataGridView.AutoGenerateColumns = false;
            this.dOMICILIOSXPERSONADataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dOMICILIOSXPERSONADataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGID,
            this.BtnSeleccionar,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20});
            this.dOMICILIOSXPERSONADataGridView.DataSource = this.dOMICILIOSXPERSONABindingSource;
            this.dOMICILIOSXPERSONADataGridView.Location = new System.Drawing.Point(3, 19);
            this.dOMICILIOSXPERSONADataGridView.Name = "dOMICILIOSXPERSONADataGridView";
            this.dOMICILIOSXPERSONADataGridView.RowHeadersVisible = false;
            this.dOMICILIOSXPERSONADataGridView.Size = new System.Drawing.Size(1011, 220);
            this.dOMICILIOSXPERSONADataGridView.TabIndex = 2;
            this.dOMICILIOSXPERSONADataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dOMICILIOSXPERSONADataGridView_CellContentClick);
            // 
            // DGID
            // 
            this.DGID.DataPropertyName = "ID";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.DGID.DefaultCellStyle = dataGridViewCellStyle1;
            this.DGID.HeaderText = "ID";
            this.DGID.Name = "DGID";
            this.DGID.Visible = false;
            // 
            // BtnSeleccionar
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.BtnSeleccionar.DefaultCellStyle = dataGridViewCellStyle2;
            this.BtnSeleccionar.HeaderText = "";
            this.BtnSeleccionar.Name = "BtnSeleccionar";
            this.BtnSeleccionar.Text = "SELECCIONAR";
            this.BtnSeleccionar.UseColumnTextForButtonValue = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ACTIVO";
            this.dataGridViewTextBoxColumn2.HeaderText = "ACTIVO";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "CALLE";
            this.dataGridViewTextBoxColumn7.HeaderText = "CALLE";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 140;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "NUMEROEXTERIOR";
            this.dataGridViewTextBoxColumn8.HeaderText = "#EXT";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 45;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "NUMEROINTERIOR";
            this.dataGridViewTextBoxColumn9.HeaderText = "#INT";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "COLONIA";
            this.dataGridViewTextBoxColumn10.HeaderText = "COLONIA";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "MUNICIPIO";
            this.dataGridViewTextBoxColumn11.HeaderText = "MUNICIPIO";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 50;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "ESTADO";
            this.dataGridViewTextBoxColumn12.HeaderText = "ESTADO";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 50;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "CODIGOPOSTAL";
            this.dataGridViewTextBoxColumn13.HeaderText = "C. P.";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "REFERENCIADOM";
            this.dataGridViewTextBoxColumn18.HeaderText = "REF.";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "LATITUD";
            this.dataGridViewTextBoxColumn19.HeaderText = "LAT";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.Width = 50;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "LONGITUD";
            this.dataGridViewTextBoxColumn20.HeaderText = "LONG";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.Width = 50;
            // 
            // dOMICILIOSXPERSONABindingSource
            // 
            this.dOMICILIOSXPERSONABindingSource.DataMember = "DOMICILIOSXPERSONA";
            this.dOMICILIOSXPERSONABindingSource.DataSource = this.dSCatalogos3;
            // 
            // dSCatalogos3
            // 
            this.dSCatalogos3.DataSetName = "DSCatalogos3";
            this.dSCatalogos3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lblSeleccionPrevia);
            this.panel1.Controls.Add(this.btnUsarDatosCliente);
            this.panel1.Controls.Add(this.lblMensajeSeleccion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1017, 61);
            this.panel1.TabIndex = 3;
            // 
            // lblSeleccionPrevia
            // 
            this.lblSeleccionPrevia.AutoSize = true;
            this.lblSeleccionPrevia.BackColor = System.Drawing.Color.Transparent;
            this.lblSeleccionPrevia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeleccionPrevia.ForeColor = System.Drawing.Color.White;
            this.lblSeleccionPrevia.Location = new System.Drawing.Point(13, 33);
            this.lblSeleccionPrevia.Name = "lblSeleccionPrevia";
            this.lblSeleccionPrevia.Size = new System.Drawing.Size(20, 16);
            this.lblSeleccionPrevia.TabIndex = 5;
            this.lblSeleccionPrevia.Text = "...";
            // 
            // btnUsarDatosCliente
            // 
            this.btnUsarDatosCliente.Location = new System.Drawing.Point(787, 12);
            this.btnUsarDatosCliente.Name = "btnUsarDatosCliente";
            this.btnUsarDatosCliente.Size = new System.Drawing.Size(202, 36);
            this.btnUsarDatosCliente.TabIndex = 4;
            this.btnUsarDatosCliente.Text = "USAR DATOS DEL CLIENTE";
            this.btnUsarDatosCliente.UseVisualStyleBackColor = true;
            this.btnUsarDatosCliente.Click += new System.EventHandler(this.btnUsarDatosCliente_Click);
            // 
            // lblMensajeSeleccion
            // 
            this.lblMensajeSeleccion.AutoSize = true;
            this.lblMensajeSeleccion.BackColor = System.Drawing.Color.Transparent;
            this.lblMensajeSeleccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensajeSeleccion.ForeColor = System.Drawing.Color.White;
            this.lblMensajeSeleccion.Location = new System.Drawing.Point(13, 12);
            this.lblMensajeSeleccion.Name = "lblMensajeSeleccion";
            this.lblMensajeSeleccion.Size = new System.Drawing.Size(20, 16);
            this.lblMensajeSeleccion.TabIndex = 3;
            this.lblMensajeSeleccion.Text = "...";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.dOMICILIOSXPERSONADataGridView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1017, 280);
            this.panel2.TabIndex = 4;
            // 
            // dOMICILIOSXPERSONATableAdapter
            // 
            this.dOMICILIOSXPERSONATableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPosReporting.DSGeneralTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewButtonColumn1
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewButtonColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "SELECCIONAR";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CALLE";
            this.dataGridViewTextBoxColumn3.HeaderText = "CALLE";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 140;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "NUMEROEXTERIOR";
            this.dataGridViewTextBoxColumn4.HeaderText = "#EXT";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 45;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "NUMEROINTERIOR";
            this.dataGridViewTextBoxColumn5.HeaderText = "#INT";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "COLONIA";
            this.dataGridViewTextBoxColumn6.HeaderText = "COLONIA";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // WFSeleccionarDomicilioEntrega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPosReporting.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(1017, 334);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "WFSeleccionarDomicilioEntrega";
            this.Text = "SELECCIONAR DOMICILIO DE ENTREGA";
            this.Load += new System.EventHandler(this.WFSeleccionarDomicilioEntrega_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dOMICILIOSXPERSONADataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOMICILIOSXPERSONABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSCatalogos3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private iPosReporting.DSGeneral dSCatalogos3;
        private System.Windows.Forms.BindingSource dOMICILIOSXPERSONABindingSource;
        private iPosReporting.DSGeneralTableAdapters.DOMICILIOSXPERSONATableAdapter dOMICILIOSXPERSONATableAdapter;
        private iPosReporting.DSGeneralTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView dOMICILIOSXPERSONADataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMensajeSeleccion;
        private System.Windows.Forms.Button btnUsarDatosCliente;
        private System.Windows.Forms.Label lblSeleccionPrevia;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGID;
        private System.Windows.Forms.DataGridViewButtonColumn BtnSeleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}