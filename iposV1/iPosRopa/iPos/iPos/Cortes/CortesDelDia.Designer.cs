namespace iPos
{
    partial class CortesDelDia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CortesDelDia));
            this.DTFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataSet1 = new iPos.ReimpresionTicket.DataSet1();
            this.corteTicketFechaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.corteTicketFechaTableAdapter = new iPos.ReimpresionTicket.DataSet1TableAdapters.CorteTicketFechaTableAdapter();
            this.tableAdapterManager = new iPos.ReimpresionTicket.DataSet1TableAdapters.TableAdapterManager();
            this.dSPuntoVenta = new iPos.PuntoDeVenta.DSPuntoVenta();
            this.corteTrasladosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.corteTrasladosTableAdapter = new iPos.PuntoDeVenta.DSPuntoVentaTableAdapters.CorteTrasladosTableAdapter();
            this.tableAdapterManager1 = new iPos.PuntoDeVenta.DSPuntoVentaTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.corteTicketFechaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.corteTrasladosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DTFecha
            // 
            this.DTFecha.Location = new System.Drawing.Point(73, 57);
            this.DTFecha.Name = "DTFecha";
            this.DTFecha.Size = new System.Drawing.Size(233, 20);
            this.DTFecha.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(37, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dia:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(82, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Obtener reporte por cajero";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // corteTicketFechaBindingSource
            // 
            this.corteTicketFechaBindingSource.DataMember = "CorteTicketFecha";
            this.corteTicketFechaBindingSource.DataSource = this.dataSet1;
            // 
            // corteTicketFechaTableAdapter
            // 
            this.corteTicketFechaTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.ReimpresionTicket.DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dSPuntoVenta
            // 
            this.dSPuntoVenta.DataSetName = "DSPuntoVenta";
            this.dSPuntoVenta.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dSPuntoVenta.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // corteTrasladosBindingSource
            // 
            this.corteTrasladosBindingSource.DataMember = "CorteTraslados";
            this.corteTrasladosBindingSource.DataSource = this.dSPuntoVenta;
            // 
            // corteTrasladosTableAdapter
            // 
            this.corteTrasladosTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.UpdateOrder = iPos.PuntoDeVenta.DSPuntoVentaTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // CortesDelDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(346, 197);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DTFecha);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CortesDelDia";
            this.Text = "Cortes del dia por cajero";
            this.Load += new System.EventHandler(this.CortesDelDia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.corteTicketFechaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSPuntoVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.corteTrasladosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DTFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private ReimpresionTicket.DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource corteTicketFechaBindingSource;
        private ReimpresionTicket.DataSet1TableAdapters.CorteTicketFechaTableAdapter corteTicketFechaTableAdapter;
        private ReimpresionTicket.DataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private PuntoDeVenta.DSPuntoVenta dSPuntoVenta;
        private System.Windows.Forms.BindingSource corteTrasladosBindingSource;
        private PuntoDeVenta.DSPuntoVentaTableAdapters.CorteTrasladosTableAdapter corteTrasladosTableAdapter;
        private PuntoDeVenta.DSPuntoVentaTableAdapters.TableAdapterManager tableAdapterManager1;
    }
}