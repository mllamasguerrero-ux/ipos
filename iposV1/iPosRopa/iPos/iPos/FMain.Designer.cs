namespace iPos
{
    partial class FMain
    {
        
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCambiarEmpresa = new System.Windows.Forms.Button();
            this.BTProveedores = new System.Windows.Forms.Button();
            this.BTClientes = new System.Windows.Forms.Button();
            this.BTProductos = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCortesDelDia = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.rootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dSAccessControl = new iPos.Login_and_Maintenance.DSAccessControl();
            this.mENUITEMSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mENUITEMSTableAdapter = new iPos.Login_and_Maintenance.DSAccessControlTableAdapters.MENUITEMSTableAdapter();
            this.tableAdapterManager = new iPos.Login_and_Maintenance.DSAccessControlTableAdapters.TableAdapterManager();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSAccessControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mENUITEMSBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.panel2.BackgroundImage = global::iPos.Properties.Resources.ipos_material_flat_walppaer_4;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(795, 394);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(795, 105);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.panel3.Controls.Add(this.btnCambiarEmpresa);
            this.panel3.Controls.Add(this.BTProveedores);
            this.panel3.Controls.Add(this.BTClientes);
            this.panel3.Controls.Add(this.BTProductos);
            this.panel3.Controls.Add(this.button8);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.button7);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.btnCortesDelDia);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button5);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(795, 78);
            this.panel3.TabIndex = 2;
            // 
            // btnCambiarEmpresa
            // 
            this.btnCambiarEmpresa.FlatAppearance.BorderSize = 0;
            this.btnCambiarEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarEmpresa.ForeColor = System.Drawing.Color.White;
            this.btnCambiarEmpresa.Image = global::iPos.Properties.Resources.location_ipos2;
            this.btnCambiarEmpresa.Location = new System.Drawing.Point(720, -2);
            this.btnCambiarEmpresa.Name = "btnCambiarEmpresa";
            this.btnCambiarEmpresa.Size = new System.Drawing.Size(70, 78);
            this.btnCambiarEmpresa.TabIndex = 12;
            this.btnCambiarEmpresa.Text = "Camb.Emp";
            this.btnCambiarEmpresa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCambiarEmpresa.UseVisualStyleBackColor = false;
            this.btnCambiarEmpresa.Click += new System.EventHandler(this.btnCambiarEmpresa_Click);
            // 
            // BTProveedores
            // 
            this.BTProveedores.BackgroundImage = global::iPos.Properties.Resources.provider_ipos2;
            this.BTProveedores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTProveedores.FlatAppearance.BorderSize = 0;
            this.BTProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTProveedores.ForeColor = System.Drawing.Color.White;
            this.BTProveedores.Location = new System.Drawing.Point(61, -2);
            this.BTProveedores.Name = "BTProveedores";
            this.BTProveedores.Size = new System.Drawing.Size(58, 77);
            this.BTProveedores.TabIndex = 11;
            this.BTProveedores.Text = "Proveed.";
            this.BTProveedores.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTProveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTProveedores.UseVisualStyleBackColor = false;
            this.BTProveedores.Click += new System.EventHandler(this.BTProveedores_Click);
            // 
            // BTClientes
            // 
            this.BTClientes.BackgroundImage = global::iPos.Properties.Resources.customer_ipos2;
            this.BTClientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTClientes.FlatAppearance.BorderSize = 0;
            this.BTClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTClientes.ForeColor = System.Drawing.Color.White;
            this.BTClientes.Location = new System.Drawing.Point(3, -2);
            this.BTClientes.Name = "BTClientes";
            this.BTClientes.Size = new System.Drawing.Size(53, 77);
            this.BTClientes.TabIndex = 10;
            this.BTClientes.Text = "Clientes";
            this.BTClientes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BTClientes.UseVisualStyleBackColor = false;
            this.BTClientes.Click += new System.EventHandler(this.BTClientes_Click);
            // 
            // BTProductos
            // 
            this.BTProductos.BackgroundImage = global::iPos.Properties.Resources.product_ipos2;
            this.BTProductos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTProductos.FlatAppearance.BorderSize = 0;
            this.BTProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTProductos.ForeColor = System.Drawing.Color.White;
            this.BTProductos.Location = new System.Drawing.Point(123, -2);
            this.BTProductos.Name = "BTProductos";
            this.BTProductos.Size = new System.Drawing.Size(68, 78);
            this.BTProductos.TabIndex = 2;
            this.BTProductos.Text = "Productos";
            this.BTProductos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTProductos.UseVisualStyleBackColor = false;
            this.BTProductos.Click += new System.EventHandler(this.BTProductos_Click);
            // 
            // button8
            // 
            this.button8.BackgroundImage = global::iPos.Properties.Resources.print2_ipos2;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(326, -2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(68, 78);
            this.button8.TabIndex = 7;
            this.button8.Text = "Corte Caj";
            this.button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::iPos.Properties.Resources.export_ipos2;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(456, -2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 78);
            this.button1.TabIndex = 3;
            this.button1.Text = "Export.";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button7
            // 
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Image = global::iPos.Properties.Resources.money_ipos2;
            this.button7.Location = new System.Drawing.Point(652, -2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(68, 78);
            this.button7.TabIndex = 9;
            this.button7.Text = "Retiros";
            this.button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::iPos.Properties.Resources.import_ipos2;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(521, -2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 78);
            this.button2.TabIndex = 4;
            this.button2.Text = "Import.";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCortesDelDia
            // 
            this.btnCortesDelDia.BackgroundImage = global::iPos.Properties.Resources.cash_terminal;
            this.btnCortesDelDia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCortesDelDia.FlatAppearance.BorderSize = 0;
            this.btnCortesDelDia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCortesDelDia.ForeColor = System.Drawing.Color.White;
            this.btnCortesDelDia.Image = global::iPos.Properties.Resources.print3_ipos2;
            this.btnCortesDelDia.Location = new System.Drawing.Point(586, -2);
            this.btnCortesDelDia.Name = "btnCortesDelDia";
            this.btnCortesDelDia.Size = new System.Drawing.Size(68, 78);
            this.btnCortesDelDia.TabIndex = 8;
            this.btnCortesDelDia.Text = "Cortes dia";
            this.btnCortesDelDia.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCortesDelDia.UseVisualStyleBackColor = false;
            this.btnCortesDelDia.Click += new System.EventHandler(this.button6_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::iPos.Properties.Resources.shop_ipos2;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(190, -2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(68, 78);
            this.button3.TabIndex = 5;
            this.button3.Text = "Venta";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::iPos.Properties.Resources.invetario_ipos2;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(391, -2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(68, 78);
            this.button5.TabIndex = 7;
            this.button5.Text = "Inventario";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::iPos.Properties.Resources.print_ipos2;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(258, -2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(68, 78);
            this.button4.TabIndex = 6;
            this.button4.Text = "Corte Adm";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rootToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(795, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Click += new System.EventHandler(this.menuStrip1_Click);
            // 
            // rootToolStripMenuItem
            // 
            this.rootToolStripMenuItem.Name = "rootToolStripMenuItem";
            this.rootToolStripMenuItem.Size = new System.Drawing.Size(23, 20);
            this.rootToolStripMenuItem.Text = " ";
            // 
            // dSAccessControl
            // 
            this.dSAccessControl.DataSetName = "DSAccessControl";
            this.dSAccessControl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mENUITEMSBindingSource
            // 
            this.mENUITEMSBindingSource.DataMember = "MENUITEMS";
            this.mENUITEMSBindingSource.DataSource = this.dSAccessControl;
            // 
            // mENUITEMSTableAdapter
            // 
            this.mENUITEMSTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.DERECHOS_USUARIOSTableAdapter = null;
            this.tableAdapterManager.PERFILES_DERECHOSTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = iPos.Login_and_Maintenance.DSAccessControlTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 394);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1024, 738);
            this.Name = "FMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema IPOS 1309.7045";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSAccessControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mENUITEMSBindingSource)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rootToolStripMenuItem;
        private System.Windows.Forms.Button BTProductos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnCortesDelDia;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button BTProveedores;
        private System.Windows.Forms.Button BTClientes;
        private System.Windows.Forms.Panel panel3;
        private Login_and_Maintenance.DSAccessControl dSAccessControl;
        private System.Windows.Forms.BindingSource mENUITEMSBindingSource;
        private Login_and_Maintenance.DSAccessControlTableAdapters.MENUITEMSTableAdapter mENUITEMSTableAdapter;
        private Login_and_Maintenance.DSAccessControlTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button btnCambiarEmpresa;
        //private Skinner.FormSkin formSkin1;
    }
}