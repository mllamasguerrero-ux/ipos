using IposV3.Model;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Windows.Controls;
using System.Xml.Linq;
using System.Configuration;
using System.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.DirectoryServices.ActiveDirectory;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodeGenerator
{
    public partial class FormWebClient : Form
    {
        GeneratorFromEntities _generatorFromEntities;
        RealCodeGenerator _realCodeGenerator;


        public FormWebClient()
        {
            InitializeComponent();


            codigoNoGeneradoDeDiseno();


            _generatorFromEntities = new GeneratorFromEntities(this.dsGeneracion1);
            _realCodeGenerator = new RealCodeGenerator(dsGeneracion1, excelWebCustomCtrls1);
        }

        private void codigoNoGeneradoDeDiseno()
        {

            this.dsGeneracion1 = new CodeGenerator.DSGeneracion();

            this.bindingSource1.DataMember = "UserTables";
            this.bindingSource1.DataSource = this.dsGeneracion1;
            // 
            // dsGeneracion1
            // 
            this.dsGeneracion1.DataSetName = "DSGeneracion";
            this.dsGeneracion1.Namespace = "http://tempuri.org/DSGeneracion.xsd";
            this.dsGeneracion1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 



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



            this.excelWebCustomCtrls1 = new CodeGenerator.ExcelWebCustomCtrls();

            this.excelWebCustomCtrls1.DataSetName = "ExcelWebCustomCtrls";
            this.excelWebCustomCtrls1.Namespace = "http://tempuri.org/ExcelWebCustomCtrls.xsd";
            this.excelWebCustomCtrls1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _generatorFromEntities.loadControllerClasses();
            this.btnGenerarExcel.Enabled = true;
            this.btnGenerarCodigo.Enabled = false;

        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            foreach (DataRow dr in this.dsGeneracion1.UserTables.Rows)
            {
                dr["cb"] = true;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            foreach (DataRow dr in this.dsGeneracion1.UserTables.Rows)
            {
                dr["cb"] = false;
            }
        }

        private void btnGenerarExcel_Click(object sender, EventArgs e)
        {
            _generatorFromEntities.generarExcelControllers(TBExcelDestino.Text);
        }

        private void btnExaminarExcel_Click(object sender, EventArgs e)
        {

            if ((this.openFileDialog1.ShowDialog() == DialogResult.OK))
            {
                TBExcelDestino.Text = this.openFileDialog1.FileName;
            }
        }

        private void btnLoadDataFromIntermediateExcel_Click(object sender, EventArgs e)
        {

            _generatorFromEntities.LoadTableInfoFromExcel(TBExcelDestino.Text);

            this.btnGenerarExcel.Enabled = false;
            this.btnGenerarCodigo.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {


            if ((this.folderBrowserDialog1.ShowDialog() == DialogResult.OK))
            {
                TBCarpetaDestino2.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnGenerarCodigo_Click(object sender, EventArgs e)
        {
            _realCodeGenerator.GenerarCodigo("EXCEL", "IposV3", TBCarpetaDestino2.Text, TBExcelDestino.Text, "controladores");
        }

        private void btnGenerarCodigoParametros_Click(object sender, EventArgs e)
        {
            _realCodeGenerator.GenerarCodigo("EXCEL", "IposV3", TBCarpetaDestino2.Text, TBExcelDestino2.Text, "parametroscontroladores");
        }

        private void btnFormatReport_Click(object sender, EventArgs e)
        {
            List<string> tables = new List<string>()
            { "REC_MASTER", "REC_DETAIL", "CUPONES", "REC_SUMATORIAS"};


            string inputFileName = TBFormatReport.Text;
            string outputFileName = TBFormatReport.Text + ".test";
            using (var outputFile = new StreamWriter(outputFileName))
            {
                foreach (var line in File.ReadLines(inputFileName))
                {

                    outputFile.WriteLine(strFormattedForNewFastReport2(strFormattedForNewFastReport(line, tables), tables));
                }
            }


            //var strTest = strFormattedForNewFastReport2(" aaa bbb \"[REC_MASTER.CAMPO_1]\"   ddd    fff  \"[REC_MASTER.CAMPO_2]\" ggg ", tables);
            //Console.WriteLine(strTest);
        }

        private string strFormattedForNewFastReport(string str, List<string> tables)
        {

            string newLine = str;
            foreach (string table in tables)
            {

                //Use named capturing groups to make life easier
                var pattern = "&quot;((?<tabla>" + table + ").(?<campo>.\\w+))&quot;";

                //newLine = Regex.Replace(newLine, pattern, replacePattern, RegexOptions.IgnoreCase);
                newLine = Regex.Replace(newLine, pattern,
                                               m => $"&quot;{m.Groups[2].Value}.{m.Groups[3].Value.ToLower()}&quot;",
                                               RegexOptions.None);


            }


            return newLine;

        }

        private string strFormattedForNewFastReport2(string str, List<string> tables)
        {

            string newLine = str;
            foreach (string table in tables)
            {

                //Use named capturing groups to make life easier
                var pattern = "\\[((?<tabla>" + table + ").(?<campo>.\\w+))\\]";

                //newLine = Regex.Replace(newLine, pattern, replacePattern, RegexOptions.IgnoreCase);
                newLine = Regex.Replace(newLine, pattern,
                                               m => $"[{m.Groups[2].Value}.{m.Groups[3].Value.ToLower()}]",
                                               RegexOptions.None);


            }


            return newLine;

        }

        private void button3_Click(object sender, EventArgs e)
        {

            _generatorFromEntities.loadParameterControllerClasses();
            this.btnGenerarExcelParams.Enabled = true;
            this.btnGenerarCodigo.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            _generatorFromEntities.generarExcelParameterControllers(TBExcelDestino2.Text);
        }

        private void btnLoadDataFromExcelParametros_Click(object sender, EventArgs e)
        {

            _generatorFromEntities.LoadTableInfoFromExcel(TBExcelDestino2.Text);

            this.btnGenerarExcelParams.Enabled = false;
            this.btnGenerarCodigoParametros.Enabled = true;

        }
    }

}