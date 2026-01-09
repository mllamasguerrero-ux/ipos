namespace CodeGenerator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TBCarpetaDestino2 = new System.Windows.Forms.TextBox();
            this.btnGenerarCodigo = new System.Windows.Forms.Button();
            this.btnLoadDataFromIntermediateExcel = new System.Windows.Forms.Button();
            this.btnGenerarExcel = new System.Windows.Forms.Button();
            this.btnExaminarExcel = new System.Windows.Forms.Button();
            this.LBExcelDestino = new System.Windows.Forms.Label();
            this.TBExcelDestino = new System.Windows.Forms.TextBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cb = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameHyphenizedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameRealTableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.schemaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameParentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.queryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.foreignMainKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.campoClaveDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.campoNombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.esTablaGeneralDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dsGeneracion1 = new CodeGenerator.DSGeneracion();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.excelWebCustomCtrls1 = new CodeGenerator.ExcelWebCustomCtrls();
            this.btnFormatReport = new System.Windows.Forms.Button();
            this.TBFormatReport = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGeneracion1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.excelWebCustomCtrls1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(662, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(225, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cargar datos desde db entities";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(921, 801);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.TBCarpetaDestino2);
            this.tabPage1.Controls.Add(this.btnGenerarCodigo);
            this.tabPage1.Controls.Add(this.btnLoadDataFromIntermediateExcel);
            this.tabPage1.Controls.Add(this.btnGenerarExcel);
            this.tabPage1.Controls.Add(this.btnExaminarExcel);
            this.tabPage1.Controls.Add(this.LBExcelDestino);
            this.tabPage1.Controls.Add(this.TBExcelDestino);
            this.tabPage1.Controls.Add(this.linkLabel2);
            this.tabPage1.Controls.Add(this.linkLabel1);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(913, 768);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Paso 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(447, 667);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 31);
            this.button2.TabIndex = 14;
            this.button2.Text = "EXAMINAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 643);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Ruta para generar codigo";
            // 
            // TBCarpetaDestino2
            // 
            this.TBCarpetaDestino2.Location = new System.Drawing.Point(50, 667);
            this.TBCarpetaDestino2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TBCarpetaDestino2.Name = "TBCarpetaDestino2";
            this.TBCarpetaDestino2.Size = new System.Drawing.Size(371, 27);
            this.TBCarpetaDestino2.TabIndex = 12;
            this.TBCarpetaDestino2.Text = "C:\\IposProject\\GeneratedProjects\\IposV3";
            // 
            // btnGenerarCodigo
            // 
            this.btnGenerarCodigo.Enabled = false;
            this.btnGenerarCodigo.Location = new System.Drawing.Point(685, 667);
            this.btnGenerarCodigo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGenerarCodigo.Name = "btnGenerarCodigo";
            this.btnGenerarCodigo.Size = new System.Drawing.Size(161, 31);
            this.btnGenerarCodigo.TabIndex = 11;
            this.btnGenerarCodigo.Text = "GENERAR CODIGO";
            this.btnGenerarCodigo.UseVisualStyleBackColor = true;
            this.btnGenerarCodigo.Click += new System.EventHandler(this.btnGenerarCodigo_Click);
            // 
            // btnLoadDataFromIntermediateExcel
            // 
            this.btnLoadDataFromIntermediateExcel.Location = new System.Drawing.Point(662, 77);
            this.btnLoadDataFromIntermediateExcel.Name = "btnLoadDataFromIntermediateExcel";
            this.btnLoadDataFromIntermediateExcel.Size = new System.Drawing.Size(225, 29);
            this.btnLoadDataFromIntermediateExcel.TabIndex = 10;
            this.btnLoadDataFromIntermediateExcel.Text = "Cargar datos desde excel";
            this.btnLoadDataFromIntermediateExcel.UseVisualStyleBackColor = true;
            this.btnLoadDataFromIntermediateExcel.Click += new System.EventHandler(this.btnLoadDataFromIntermediateExcel_Click);
            // 
            // btnGenerarExcel
            // 
            this.btnGenerarExcel.Enabled = false;
            this.btnGenerarExcel.Location = new System.Drawing.Point(74, 563);
            this.btnGenerarExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGenerarExcel.Name = "btnGenerarExcel";
            this.btnGenerarExcel.Size = new System.Drawing.Size(161, 31);
            this.btnGenerarExcel.TabIndex = 9;
            this.btnGenerarExcel.Text = "GENERAR EXCEL";
            this.btnGenerarExcel.UseVisualStyleBackColor = true;
            this.btnGenerarExcel.Click += new System.EventHandler(this.btnGenerarExcel_Click);
            // 
            // btnExaminarExcel
            // 
            this.btnExaminarExcel.Location = new System.Drawing.Point(423, 79);
            this.btnExaminarExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExaminarExcel.Name = "btnExaminarExcel";
            this.btnExaminarExcel.Size = new System.Drawing.Size(161, 31);
            this.btnExaminarExcel.TabIndex = 8;
            this.btnExaminarExcel.Text = "EXAMINAR";
            this.btnExaminarExcel.UseVisualStyleBackColor = true;
            this.btnExaminarExcel.Click += new System.EventHandler(this.btnExaminarExcel_Click);
            // 
            // LBExcelDestino
            // 
            this.LBExcelDestino.AutoSize = true;
            this.LBExcelDestino.Location = new System.Drawing.Point(26, 55);
            this.LBExcelDestino.Name = "LBExcelDestino";
            this.LBExcelDestino.Size = new System.Drawing.Size(120, 20);
            this.LBExcelDestino.TabIndex = 7;
            this.LBExcelDestino.Text = "Excel intermedio";
            // 
            // TBExcelDestino
            // 
            this.TBExcelDestino.Location = new System.Drawing.Point(26, 79);
            this.TBExcelDestino.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TBExcelDestino.Name = "TBExcelDestino";
            this.TBExcelDestino.Size = new System.Drawing.Size(371, 27);
            this.TBExcelDestino.TabIndex = 6;
            this.TBExcelDestino.Text = "C:\\IposV3\\IposV3\\CodeGenerator\\GENERADOR\\excelsources\\excelgeneradointial_usuario" +
    "promocion_impoexpo.xlsx";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(102, 123);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(37, 20);
            this.linkLabel2.TabIndex = 3;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "All -";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(21, 123);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(41, 20);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "All +";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cb,
            this.nameDataGridViewTextBoxColumn,
            this.nameHyphenizedDataGridViewTextBoxColumn,
            this.nameRealTableDataGridViewTextBoxColumn,
            this.schemaDataGridViewTextBoxColumn,
            this.folderDataGridViewTextBoxColumn,
            this.tipoDataGridViewTextBoxColumn,
            this.nameParentDataGridViewTextBoxColumn,
            this.queryDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.foreignMainKeyDataGridViewTextBoxColumn,
            this.campoClaveDataGridViewTextBoxColumn,
            this.campoNombreDataGridViewTextBoxColumn,
            this.esTablaGeneralDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(21, 160);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(743, 377);
            this.dataGridView1.TabIndex = 1;
            // 
            // cb
            // 
            this.cb.DataPropertyName = "cb";
            this.cb.FalseValue = "0";
            this.cb.HeaderText = "gcb";
            this.cb.MinimumWidth = 6;
            this.cb.Name = "cb";
            this.cb.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cb.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cb.TrueValue = "1";
            this.cb.Width = 50;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // nameHyphenizedDataGridViewTextBoxColumn
            // 
            this.nameHyphenizedDataGridViewTextBoxColumn.DataPropertyName = "NameHyphenized";
            this.nameHyphenizedDataGridViewTextBoxColumn.HeaderText = "NameHyphenized";
            this.nameHyphenizedDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameHyphenizedDataGridViewTextBoxColumn.Name = "nameHyphenizedDataGridViewTextBoxColumn";
            this.nameHyphenizedDataGridViewTextBoxColumn.Width = 125;
            // 
            // nameRealTableDataGridViewTextBoxColumn
            // 
            this.nameRealTableDataGridViewTextBoxColumn.DataPropertyName = "NameRealTable";
            this.nameRealTableDataGridViewTextBoxColumn.HeaderText = "NameRealTable";
            this.nameRealTableDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameRealTableDataGridViewTextBoxColumn.Name = "nameRealTableDataGridViewTextBoxColumn";
            this.nameRealTableDataGridViewTextBoxColumn.Width = 125;
            // 
            // schemaDataGridViewTextBoxColumn
            // 
            this.schemaDataGridViewTextBoxColumn.DataPropertyName = "Schema_";
            this.schemaDataGridViewTextBoxColumn.HeaderText = "Schema_";
            this.schemaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.schemaDataGridViewTextBoxColumn.Name = "schemaDataGridViewTextBoxColumn";
            this.schemaDataGridViewTextBoxColumn.Width = 125;
            // 
            // folderDataGridViewTextBoxColumn
            // 
            this.folderDataGridViewTextBoxColumn.DataPropertyName = "Folder";
            this.folderDataGridViewTextBoxColumn.HeaderText = "Folder";
            this.folderDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.folderDataGridViewTextBoxColumn.Name = "folderDataGridViewTextBoxColumn";
            this.folderDataGridViewTextBoxColumn.Width = 125;
            // 
            // tipoDataGridViewTextBoxColumn
            // 
            this.tipoDataGridViewTextBoxColumn.DataPropertyName = "Tipo";
            this.tipoDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tipoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tipoDataGridViewTextBoxColumn.Name = "tipoDataGridViewTextBoxColumn";
            this.tipoDataGridViewTextBoxColumn.Width = 125;
            // 
            // nameParentDataGridViewTextBoxColumn
            // 
            this.nameParentDataGridViewTextBoxColumn.DataPropertyName = "NameParent";
            this.nameParentDataGridViewTextBoxColumn.HeaderText = "NameParent";
            this.nameParentDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameParentDataGridViewTextBoxColumn.Name = "nameParentDataGridViewTextBoxColumn";
            this.nameParentDataGridViewTextBoxColumn.Width = 125;
            // 
            // queryDataGridViewTextBoxColumn
            // 
            this.queryDataGridViewTextBoxColumn.DataPropertyName = "Query";
            this.queryDataGridViewTextBoxColumn.HeaderText = "Query";
            this.queryDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.queryDataGridViewTextBoxColumn.Name = "queryDataGridViewTextBoxColumn";
            this.queryDataGridViewTextBoxColumn.Width = 125;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.Width = 125;
            // 
            // foreignMainKeyDataGridViewTextBoxColumn
            // 
            this.foreignMainKeyDataGridViewTextBoxColumn.DataPropertyName = "ForeignMainKey";
            this.foreignMainKeyDataGridViewTextBoxColumn.HeaderText = "ForeignMainKey";
            this.foreignMainKeyDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.foreignMainKeyDataGridViewTextBoxColumn.Name = "foreignMainKeyDataGridViewTextBoxColumn";
            this.foreignMainKeyDataGridViewTextBoxColumn.Width = 125;
            // 
            // campoClaveDataGridViewTextBoxColumn
            // 
            this.campoClaveDataGridViewTextBoxColumn.DataPropertyName = "CampoClave";
            this.campoClaveDataGridViewTextBoxColumn.HeaderText = "CampoClave";
            this.campoClaveDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.campoClaveDataGridViewTextBoxColumn.Name = "campoClaveDataGridViewTextBoxColumn";
            this.campoClaveDataGridViewTextBoxColumn.Width = 125;
            // 
            // campoNombreDataGridViewTextBoxColumn
            // 
            this.campoNombreDataGridViewTextBoxColumn.DataPropertyName = "CampoNombre";
            this.campoNombreDataGridViewTextBoxColumn.HeaderText = "CampoNombre";
            this.campoNombreDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.campoNombreDataGridViewTextBoxColumn.Name = "campoNombreDataGridViewTextBoxColumn";
            this.campoNombreDataGridViewTextBoxColumn.Width = 125;
            // 
            // esTablaGeneralDataGridViewTextBoxColumn
            // 
            this.esTablaGeneralDataGridViewTextBoxColumn.DataPropertyName = "EsTablaGeneral";
            this.esTablaGeneralDataGridViewTextBoxColumn.HeaderText = "EsTablaGeneral";
            this.esTablaGeneralDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.esTablaGeneralDataGridViewTextBoxColumn.Name = "esTablaGeneralDataGridViewTextBoxColumn";
            this.esTablaGeneralDataGridViewTextBoxColumn.Width = 125;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "UserTables";
            this.bindingSource1.DataSource = this.dsGeneracion1;
            // 
            // dsGeneracion1
            // 
            this.dsGeneracion1.DataSetName = "DSGeneracion";
            this.dsGeneracion1.Namespace = "http://tempuri.org/DSGeneracion.xsd";
            this.dsGeneracion1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.TBFormatReport);
            this.tabPage2.Controls.Add(this.btnFormatReport);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(913, 768);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Paso 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // bindingSource2
            // 
            this.bindingSource2.DataMember = "columnas";
            this.bindingSource2.DataSource = this.dsGeneracion1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // excelWebCustomCtrls1
            // 
            this.excelWebCustomCtrls1.DataSetName = "ExcelWebCustomCtrls";
            this.excelWebCustomCtrls1.Namespace = "http://tempuri.org/ExcelWebCustomCtrls.xsd";
            this.excelWebCustomCtrls1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnFormatReport
            // 
            this.btnFormatReport.Location = new System.Drawing.Point(458, 139);
            this.btnFormatReport.Name = "btnFormatReport";
            this.btnFormatReport.Size = new System.Drawing.Size(94, 29);
            this.btnFormatReport.TabIndex = 0;
            this.btnFormatReport.Text = "Format report";
            this.btnFormatReport.UseVisualStyleBackColor = true;
            this.btnFormatReport.Click += new System.EventHandler(this.btnFormatReport_Click);
            // 
            // TBFormatReport
            // 
            this.TBFormatReport.Location = new System.Drawing.Point(84, 97);
            this.TBFormatReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TBFormatReport.Name = "TBFormatReport";
            this.TBFormatReport.Size = new System.Drawing.Size(468, 27);
            this.TBFormatReport.TabIndex = 7;
            this.TBFormatReport.Text = "C:\\IposV3\\IposV3\\IposV3\\Reports\\Sistema\\RECIBOLARGO.frx";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 801);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGeneracion1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.excelWebCustomCtrls1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DSGeneracion dsGeneracion1;
        private BindingSource bindingSource1;
        private DataGridView dataGridView1;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel1;
        private BindingSource bindingSource2;
        private Button btnGenerarExcel;
        private Button btnExaminarExcel;
        private Label LBExcelDestino;
        private TextBox TBExcelDestino;
        private OpenFileDialog openFileDialog1;
        private Button btnLoadDataFromIntermediateExcel;
        private DataGridViewCheckBoxColumn cb;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameHyphenizedDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameRealTableDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn schemaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn folderDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tipoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameParentDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn queryDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn foreignMainKeyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn campoClaveDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn campoNombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn esTablaGeneralDataGridViewTextBoxColumn;
        private Button btnGenerarCodigo;
        private Button button2;
        private Label label1;
        private TextBox TBCarpetaDestino2;
        private FolderBrowserDialog folderBrowserDialog1;
        private ExcelWebCustomCtrls excelWebCustomCtrls1;
        private TextBox TBFormatReport;
        private Button btnFormatReport;
    }
}