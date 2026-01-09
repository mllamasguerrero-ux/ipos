namespace CodeGenerator
{
    partial class FormWebClient
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
            components = new System.ComponentModel.Container();
            button1 = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnLoadDataFromExcelParametros = new Button();
            btnGenerarCodigoParametros = new Button();
            TBExcelDestino2 = new TextBox();
            btnGenerarExcelParams = new Button();
            button3 = new Button();
            button2 = new Button();
            label1 = new Label();
            TBCarpetaDestino2 = new TextBox();
            btnGenerarCodigo = new Button();
            btnLoadDataFromIntermediateExcel = new Button();
            btnGenerarExcel = new Button();
            btnExaminarExcel = new Button();
            LBExcelDestino = new Label();
            TBExcelDestino = new TextBox();
            linkLabel2 = new LinkLabel();
            linkLabel1 = new LinkLabel();
            dataGridView1 = new DataGridView();
            bindingSource1 = new BindingSource(components);
            tabPage2 = new TabPage();
            TBFormatReport = new TextBox();
            btnFormatReport = new Button();
            bindingSource2 = new BindingSource(components);
            openFileDialog1 = new OpenFileDialog();
            folderBrowserDialog1 = new FolderBrowserDialog();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(662, 5);
            button1.Name = "button1";
            button1.Size = new Size(225, 29);
            button1.TabIndex = 0;
            button1.Text = "Cargar controladores";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(921, 801);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnLoadDataFromExcelParametros);
            tabPage1.Controls.Add(btnGenerarCodigoParametros);
            tabPage1.Controls.Add(TBExcelDestino2);
            tabPage1.Controls.Add(btnGenerarExcelParams);
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(TBCarpetaDestino2);
            tabPage1.Controls.Add(btnGenerarCodigo);
            tabPage1.Controls.Add(btnLoadDataFromIntermediateExcel);
            tabPage1.Controls.Add(btnGenerarExcel);
            tabPage1.Controls.Add(btnExaminarExcel);
            tabPage1.Controls.Add(LBExcelDestino);
            tabPage1.Controls.Add(TBExcelDestino);
            tabPage1.Controls.Add(linkLabel2);
            tabPage1.Controls.Add(linkLabel1);
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Controls.Add(button1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(913, 768);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Paso 1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnLoadDataFromExcelParametros
            // 
            btnLoadDataFromExcelParametros.Location = new Point(662, 113);
            btnLoadDataFromExcelParametros.Name = "btnLoadDataFromExcelParametros";
            btnLoadDataFromExcelParametros.Size = new Size(225, 29);
            btnLoadDataFromExcelParametros.TabIndex = 19;
            btnLoadDataFromExcelParametros.Text = "Cargar desde excel parametros";
            btnLoadDataFromExcelParametros.UseVisualStyleBackColor = true;
            btnLoadDataFromExcelParametros.Click += btnLoadDataFromExcelParametros_Click;
            // 
            // btnGenerarCodigoParametros
            // 
            btnGenerarCodigoParametros.Enabled = false;
            btnGenerarCodigoParametros.Location = new Point(636, 730);
            btnGenerarCodigoParametros.Margin = new Padding(3, 4, 3, 4);
            btnGenerarCodigoParametros.Name = "btnGenerarCodigoParametros";
            btnGenerarCodigoParametros.Size = new Size(251, 31);
            btnGenerarCodigoParametros.TabIndex = 18;
            btnGenerarCodigoParametros.Text = "GENERAR CODIGO PARAMETROS";
            btnGenerarCodigoParametros.UseVisualStyleBackColor = true;
            btnGenerarCodigoParametros.Click += btnGenerarCodigoParametros_Click;
            // 
            // TBExcelDestino2
            // 
            TBExcelDestino2.Location = new Point(21, 73);
            TBExcelDestino2.Margin = new Padding(3, 4, 3, 4);
            TBExcelDestino2.Name = "TBExcelDestino2";
            TBExcelDestino2.Size = new Size(371, 27);
            TBExcelDestino2.TabIndex = 17;
            TBExcelDestino2.Text = "C:\\IposV3\\IposV3\\CodeGenerator\\GENERADOR\\excelsources\\excelcontrollers_parte2_HS.xlsx";
            // 
            // btnGenerarExcelParams
            // 
            btnGenerarExcelParams.Enabled = false;
            btnGenerarExcelParams.Location = new Point(437, 563);
            btnGenerarExcelParams.Margin = new Padding(3, 4, 3, 4);
            btnGenerarExcelParams.Name = "btnGenerarExcelParams";
            btnGenerarExcelParams.Size = new Size(299, 31);
            btnGenerarExcelParams.TabIndex = 16;
            btnGenerarExcelParams.Text = "GENERAR EXCEL PARAMETROS";
            btnGenerarExcelParams.UseVisualStyleBackColor = true;
            btnGenerarExcelParams.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(662, 38);
            button3.Name = "button3";
            button3.Size = new Size(225, 29);
            button3.TabIndex = 15;
            button3.Text = "Cargar clases de parametros";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(447, 667);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(161, 31);
            button2.TabIndex = 14;
            button2.Text = "EXAMINAR";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 643);
            label1.Name = "label1";
            label1.Size = new Size(179, 20);
            label1.TabIndex = 13;
            label1.Text = "Ruta para generar codigo";
            // 
            // TBCarpetaDestino2
            // 
            TBCarpetaDestino2.Location = new Point(50, 667);
            TBCarpetaDestino2.Margin = new Padding(3, 4, 3, 4);
            TBCarpetaDestino2.Name = "TBCarpetaDestino2";
            TBCarpetaDestino2.Size = new Size(371, 27);
            TBCarpetaDestino2.TabIndex = 12;
            TBCarpetaDestino2.Text = "C:\\IposProject\\GeneratedProjects\\IposV3Web";
            // 
            // btnGenerarCodigo
            // 
            btnGenerarCodigo.Enabled = false;
            btnGenerarCodigo.Location = new Point(636, 667);
            btnGenerarCodigo.Margin = new Padding(3, 4, 3, 4);
            btnGenerarCodigo.Name = "btnGenerarCodigo";
            btnGenerarCodigo.Size = new Size(251, 31);
            btnGenerarCodigo.TabIndex = 11;
            btnGenerarCodigo.Text = "GENERAR CODIGO CONTROLADORES";
            btnGenerarCodigo.UseVisualStyleBackColor = true;
            btnGenerarCodigo.Click += btnGenerarCodigo_Click;
            // 
            // btnLoadDataFromIntermediateExcel
            // 
            btnLoadDataFromIntermediateExcel.Location = new Point(662, 77);
            btnLoadDataFromIntermediateExcel.Name = "btnLoadDataFromIntermediateExcel";
            btnLoadDataFromIntermediateExcel.Size = new Size(225, 29);
            btnLoadDataFromIntermediateExcel.TabIndex = 10;
            btnLoadDataFromIntermediateExcel.Text = "Cargar datos desde excel";
            btnLoadDataFromIntermediateExcel.UseVisualStyleBackColor = true;
            btnLoadDataFromIntermediateExcel.Click += btnLoadDataFromIntermediateExcel_Click;
            // 
            // btnGenerarExcel
            // 
            btnGenerarExcel.Enabled = false;
            btnGenerarExcel.Location = new Point(74, 563);
            btnGenerarExcel.Margin = new Padding(3, 4, 3, 4);
            btnGenerarExcel.Name = "btnGenerarExcel";
            btnGenerarExcel.Size = new Size(299, 31);
            btnGenerarExcel.TabIndex = 9;
            btnGenerarExcel.Text = "GENERAR EXCEL CONTROLADORES";
            btnGenerarExcel.UseVisualStyleBackColor = true;
            btnGenerarExcel.Click += btnGenerarExcel_Click;
            // 
            // btnExaminarExcel
            // 
            btnExaminarExcel.Location = new Point(418, 38);
            btnExaminarExcel.Margin = new Padding(3, 4, 3, 4);
            btnExaminarExcel.Name = "btnExaminarExcel";
            btnExaminarExcel.Size = new Size(161, 31);
            btnExaminarExcel.TabIndex = 8;
            btnExaminarExcel.Text = "EXAMINAR";
            btnExaminarExcel.UseVisualStyleBackColor = true;
            btnExaminarExcel.Click += btnExaminarExcel_Click;
            // 
            // LBExcelDestino
            // 
            LBExcelDestino.AutoSize = true;
            LBExcelDestino.Location = new Point(21, 14);
            LBExcelDestino.Name = "LBExcelDestino";
            LBExcelDestino.Size = new Size(120, 20);
            LBExcelDestino.TabIndex = 7;
            LBExcelDestino.Text = "Excel intermedio";
            // 
            // TBExcelDestino
            // 
            TBExcelDestino.Location = new Point(21, 38);
            TBExcelDestino.Margin = new Padding(3, 4, 3, 4);
            TBExcelDestino.Name = "TBExcelDestino";
            TBExcelDestino.Size = new Size(371, 27);
            TBExcelDestino.TabIndex = 6;
            TBExcelDestino.Text = "C:\\IposV3\\IposV3\\CodeGenerator\\GENERADOR\\excelsources\\excelcontrollers_parte1_HS.xlsx";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(102, 123);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(37, 20);
            linkLabel2.TabIndex = 3;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "All -";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(21, 123);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(41, 20);
            linkLabel1.TabIndex = 2;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "All +";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Location = new Point(21, 160);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(743, 377);
            dataGridView1.TabIndex = 1;
            // 
            // bindingSource1
            // 
            bindingSource1.DataMember = "UserTables";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(TBFormatReport);
            tabPage2.Controls.Add(btnFormatReport);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(913, 768);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Paso 2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // TBFormatReport
            // 
            TBFormatReport.Location = new Point(84, 97);
            TBFormatReport.Margin = new Padding(3, 4, 3, 4);
            TBFormatReport.Name = "TBFormatReport";
            TBFormatReport.Size = new Size(468, 27);
            TBFormatReport.TabIndex = 7;
            TBFormatReport.Text = "C:\\IposV3\\IposV3\\IposV3\\Reports\\Sistema\\RECIBOLARGO.frx";
            // 
            // btnFormatReport
            // 
            btnFormatReport.Location = new Point(458, 139);
            btnFormatReport.Name = "btnFormatReport";
            btnFormatReport.Size = new Size(94, 29);
            btnFormatReport.TabIndex = 0;
            btnFormatReport.Text = "Format report";
            btnFormatReport.UseVisualStyleBackColor = true;
            btnFormatReport.Click += btnFormatReport_Click;
            // 
            // bindingSource2
            // 
            bindingSource2.DataMember = "columnas";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormWebClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(921, 801);
            Controls.Add(tabControl1);
            Name = "FormWebClient";
            Text = "FormWebClient";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DSGeneracion dsGeneracion1;
        private BindingSource bindingSource1;
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
        private Button button3;
        private DataGridView dataGridView1;
        private Button btnGenerarExcelParams;
        private TextBox TBExcelDestino2;
        private Button btnGenerarCodigoParametros;
        private Button btnLoadDataFromExcelParametros;
    }
}