namespace iPos
{
    partial class WFGastoImprimir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFGastoImprimir));
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dSContabilidad = new iPos.Contabilidad.DSContabilidad();
            this.rECIBOGASTODETALLEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rECIBOGASTODETALLETableAdapter = new iPos.Contabilidad.DSContabilidadTableAdapters.RECIBOGASTODETALLETableAdapter();
            this.tableAdapterManager = new iPos.Contabilidad.DSContabilidadTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.dSContabilidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rECIBOGASTODETALLEBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(347, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "---------------------------------------------------------------------------------" +
    "----";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Imprimiendo recibo de gasto ....";
            // 
            // dSContabilidad
            // 
            this.dSContabilidad.DataSetName = "DSContabilidad";
            this.dSContabilidad.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rECIBOGASTODETALLEBindingSource
            // 
            this.rECIBOGASTODETALLEBindingSource.DataMember = "RECIBOGASTODETALLE";
            this.rECIBOGASTODETALLEBindingSource.DataSource = this.dSContabilidad;
            // 
            // rECIBOGASTODETALLETableAdapter
            // 
            this.rECIBOGASTODETALLETableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = iPos.Contabilidad.DSContabilidadTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // WFGastoImprimir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_5;
            this.ClientSize = new System.Drawing.Size(726, 255);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WFGastoImprimir";
            this.Text = "Impresion de gasto";
            this.Load += new System.EventHandler(this.WFGastoImprimir_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSContabilidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rECIBOGASTODETALLEBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Contabilidad.DSContabilidad dSContabilidad;
        private System.Windows.Forms.BindingSource rECIBOGASTODETALLEBindingSource;
        private Contabilidad.DSContabilidadTableAdapters.RECIBOGASTODETALLETableAdapter rECIBOGASTODETALLETableAdapter;
        private Contabilidad.DSContabilidadTableAdapters.TableAdapterManager tableAdapterManager;
    }
}