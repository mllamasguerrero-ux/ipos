
namespace iPosCustomReporting
{
    partial class GeneralLookUp
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
        #region Código generado por el Diseñador de Windows Forms
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralLookUp));
            this.dataGridView1_LOOKUP = new System.Windows.FormsReporting.DataGridViewE();
            this.bindingSource1_LOOKUP = new System.Windows.Forms.BindingSource(this.components);
            this.label3_LOOKUP = new System.Windows.Forms.Label();
            this.label2_LOOKUP = new System.Windows.Forms.Label();
            this.label1_LOOKUP = new System.Windows.Forms.Label();
            this.DDOperador_LOOKUP = new System.Windows.Forms.ComboBox();
            this.DDBuscar_LOOKUP = new System.Windows.Forms.ComboBox();
            this.button3_LOOKUP = new System.Windows.Forms.Button();
            this.button1_LOOKUP = new System.Windows.Forms.Button();
            this.FbCommand1_LOOKUP = new FirebirdSql.Data.FirebirdClient.FbCommand();
            this.FbConnection1_LOOKUP = new FirebirdSql.Data.FirebirdClient.FbConnection();
            this.label4_LOOKUP = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TBValor_LOOKUP = new System.Windows.Forms.TextBoxETRpt();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_LOOKUP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_LOOKUP)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1_LOOKUP
            // 
            this.dataGridView1_LOOKUP.AllowUserToAddRows = false;
            this.dataGridView1_LOOKUP.AllowUserToDeleteRows = false;
            this.dataGridView1_LOOKUP.AutoGenerateColumns = false;
            this.dataGridView1_LOOKUP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1_LOOKUP.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1_LOOKUP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1_LOOKUP.DataSource = this.bindingSource1_LOOKUP;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1_LOOKUP.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1_LOOKUP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1_LOOKUP.EnableHeadersVisualStyles = false;
            this.dataGridView1_LOOKUP.Location = new System.Drawing.Point(0, 103);
            this.dataGridView1_LOOKUP.Name = "dataGridView1_LOOKUP";
            this.dataGridView1_LOOKUP.ReadOnly = true;
            this.dataGridView1_LOOKUP.RowHeadersVisible = false;
            this.dataGridView1_LOOKUP.Size = new System.Drawing.Size(368, 314);
            this.dataGridView1_LOOKUP.TabIndex = 1;
            this.dataGridView1_LOOKUP.EnterKeyDownEvent += new System.EventHandler(this.dataGridView1_LOOKUP_EnterKeyDownEvent);
            this.dataGridView1_LOOKUP.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_LOOKUP_CellDoubleClick);
            this.dataGridView1_LOOKUP.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView1_LOOKUP_ColumnAdded);
            this.dataGridView1_LOOKUP.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_LOOKUP_DataError);
            this.dataGridView1_LOOKUP.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_LOOKUP_RowsAdded);
            this.dataGridView1_LOOKUP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_LOOKUP_KeyDown);
            // 
            // label3_LOOKUP
            // 
            this.label3_LOOKUP.AutoSize = true;
            this.label3_LOOKUP.BackColor = System.Drawing.Color.Transparent;
            this.label3_LOOKUP.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3_LOOKUP.ForeColor = System.Drawing.Color.White;
            this.label3_LOOKUP.Location = new System.Drawing.Point(228, 23);
            this.label3_LOOKUP.Name = "label3_LOOKUP";
            this.label3_LOOKUP.Size = new System.Drawing.Size(35, 12);
            this.label3_LOOKUP.TabIndex = 17;
            this.label3_LOOKUP.Text = "Valor:";
            // 
            // label2_LOOKUP
            // 
            this.label2_LOOKUP.AutoSize = true;
            this.label2_LOOKUP.BackColor = System.Drawing.Color.Transparent;
            this.label2_LOOKUP.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2_LOOKUP.ForeColor = System.Drawing.Color.White;
            this.label2_LOOKUP.Location = new System.Drawing.Point(139, 23);
            this.label2_LOOKUP.Name = "label2_LOOKUP";
            this.label2_LOOKUP.Size = new System.Drawing.Size(56, 12);
            this.label2_LOOKUP.TabIndex = 16;
            this.label2_LOOKUP.Text = "Condicion:";
            // 
            // label1_LOOKUP
            // 
            this.label1_LOOKUP.AutoSize = true;
            this.label1_LOOKUP.BackColor = System.Drawing.Color.Transparent;
            this.label1_LOOKUP.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1_LOOKUP.ForeColor = System.Drawing.Color.White;
            this.label1_LOOKUP.Location = new System.Drawing.Point(33, 23);
            this.label1_LOOKUP.Name = "label1_LOOKUP";
            this.label1_LOOKUP.Size = new System.Drawing.Size(59, 12);
            this.label1_LOOKUP.TabIndex = 15;
            this.label1_LOOKUP.Text = "Filtrar por:";
            // 
            // DDOperador_LOOKUP
            // 
            this.DDOperador_LOOKUP.FormattingEnabled = true;
            this.DDOperador_LOOKUP.Items.AddRange(new object[] {
            "Igual",
            "Empiece",
            "Contenga"});
            this.DDOperador_LOOKUP.Location = new System.Drawing.Point(140, 38);
            this.DDOperador_LOOKUP.Name = "DDOperador_LOOKUP";
            this.DDOperador_LOOKUP.Size = new System.Drawing.Size(84, 21);
            this.DDOperador_LOOKUP.TabIndex = 12;
            // 
            // DDBuscar_LOOKUP
            // 
            this.DDBuscar_LOOKUP.FormattingEnabled = true;
            this.DDBuscar_LOOKUP.Location = new System.Drawing.Point(35, 38);
            this.DDBuscar_LOOKUP.Name = "DDBuscar_LOOKUP";
            this.DDBuscar_LOOKUP.Size = new System.Drawing.Size(99, 21);
            this.DDBuscar_LOOKUP.TabIndex = 11;
            // 
            // button3_LOOKUP
            // 
            this.button3_LOOKUP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button3_LOOKUP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3_LOOKUP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button3_LOOKUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3_LOOKUP.ForeColor = System.Drawing.Color.White;
            this.button3_LOOKUP.Location = new System.Drawing.Point(201, 64);
            this.button3_LOOKUP.Name = "button3_LOOKUP";
            this.button3_LOOKUP.Size = new System.Drawing.Size(62, 25);
            this.button3_LOOKUP.TabIndex = 19;
            this.button3_LOOKUP.Text = "Todos";
            this.button3_LOOKUP.UseVisualStyleBackColor = false;
            this.button3_LOOKUP.Click += new System.EventHandler(this.button3_LOOKUP_Click);
            // 
            // button1_LOOKUP
            // 
            this.button1_LOOKUP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(116)))), ((int)(((byte)(156)))));
            this.button1_LOOKUP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1_LOOKUP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1_LOOKUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1_LOOKUP.ForeColor = System.Drawing.Color.White;
            this.button1_LOOKUP.Location = new System.Drawing.Point(97, 65);
            this.button1_LOOKUP.Name = "button1_LOOKUP";
            this.button1_LOOKUP.Size = new System.Drawing.Size(70, 25);
            this.button1_LOOKUP.TabIndex = 14;
            this.button1_LOOKUP.Text = "Buscar";
            this.button1_LOOKUP.UseVisualStyleBackColor = false;
            this.button1_LOOKUP.Click += new System.EventHandler(this.button1_LOOKUP_Click);
            // 
            // FbCommand1_LOOKUP
            // 
            this.FbCommand1_LOOKUP.CommandText = "select * from LOOKUP where  1 = 1 ";
            this.FbCommand1_LOOKUP.CommandTimeout = 30;
            this.FbCommand1_LOOKUP.Connection = this.FbConnection1_LOOKUP;
            // 
            // FbConnection1_LOOKUP
            // 
            this.FbConnection1_LOOKUP.ConnectionString = "Data Source=manuel;Initial Catalog=generador;Persist Security Info=True;User ID=s" +
    "a;Password=Twincept";
            // 
            // label4_LOOKUP
            // 
            this.label4_LOOKUP.AutoSize = true;
            this.label4_LOOKUP.BackColor = System.Drawing.Color.Transparent;
            this.label4_LOOKUP.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4_LOOKUP.ForeColor = System.Drawing.Color.White;
            this.label4_LOOKUP.Location = new System.Drawing.Point(3, 0);
            this.label4_LOOKUP.Name = "label4_LOOKUP";
            this.label4_LOOKUP.Size = new System.Drawing.Size(70, 18);
            this.label4_LOOKUP.TabIndex = 20;
            this.label4_LOOKUP.Text = "LOOKUP";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(170)))));
            this.panel2.BackgroundImage = global::iPosReporting.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Controls.Add(this.label4_LOOKUP);
            this.panel2.Controls.Add(this.DDBuscar_LOOKUP);
            this.panel2.Controls.Add(this.button3_LOOKUP);
            this.panel2.Controls.Add(this.DDOperador_LOOKUP);
            this.panel2.Controls.Add(this.label3_LOOKUP);
            this.panel2.Controls.Add(this.TBValor_LOOKUP);
            this.panel2.Controls.Add(this.label2_LOOKUP);
            this.panel2.Controls.Add(this.button1_LOOKUP);
            this.panel2.Controls.Add(this.label1_LOOKUP);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(368, 97);
            this.panel2.TabIndex = 22;
            // 
            // TBValor_LOOKUP
            // 
            this.TBValor_LOOKUP.Format_Expression = null;
            this.TBValor_LOOKUP.Location = new System.Drawing.Point(230, 38);
            this.TBValor_LOOKUP.Name = "TBValor_LOOKUP";
            this.TBValor_LOOKUP.Size = new System.Drawing.Size(100, 20);
            this.TBValor_LOOKUP.TabIndex = 13;
            this.TBValor_LOOKUP.Tag = 34;
            this.TBValor_LOOKUP.ValidationExpression = null;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dataGridView1_LOOKUP);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 417);
            this.panel1.TabIndex = 23;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "LOOKUP";
            this.dataGridViewTextBoxColumn2.HeaderText = "LOOKUP";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // GeneralLookUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::iPosReporting.Properties.Resources.ipos_material_flat_walppaer_5_sin_logo;
            this.ClientSize = new System.Drawing.Size(368, 417);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1024, 738);
            this.Name = "GeneralLookUp";
            this.Text = "LOOKUP";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(121)))), ((int)(((byte)(121)))));
            this.Load += new System.EventHandler(this.LOOKUPLookUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_LOOKUP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_LOOKUP)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
     
        private System.Windows.Forms.BindingSource bindingSource1_LOOKUP;
        
        private System.Windows.Forms.TextBoxETRpt TBValor_LOOKUP;
        private System.Windows.Forms.ComboBox DDOperador_LOOKUP;
        private System.Windows.Forms.ComboBox DDBuscar_LOOKUP;


        private System.Windows.FormsReporting.DataGridViewE dataGridView1_LOOKUP;
        private System.Windows.Forms.Button button3_LOOKUP;
        private System.Windows.Forms.Label label3_LOOKUP;
        private System.Windows.Forms.Label label2_LOOKUP;
        private System.Windows.Forms.Label label1_LOOKUP;
        private System.Windows.Forms.Button button1_LOOKUP;
        private FirebirdSql.Data.FirebirdClient.FbCommand FbCommand1_LOOKUP;
        private FirebirdSql.Data.FirebirdClient.FbConnection FbConnection1_LOOKUP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label4_LOOKUP;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        //private Skinner.FormSkin formSkin1;
 
    }
}

