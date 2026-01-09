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
    public partial class Form1 : Form
    {
        GeneratorFromEntities _generatorFromEntities;
        RealCodeGenerator _realCodeGenerator;


        public Form1()
        {
            InitializeComponent();

            _generatorFromEntities = new GeneratorFromEntities(this.dsGeneracion1);
            _realCodeGenerator = new RealCodeGenerator(dsGeneracion1, excelWebCustomCtrls1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _generatorFromEntities.loadEntityClasses();
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
            _generatorFromEntities.generarExcel(TBExcelDestino.Text);
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
            _realCodeGenerator.GenerarCodigo("EXCEL", "IposV3", TBCarpetaDestino2.Text, TBExcelDestino.Text);
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
            foreach(string table in tables)
            {

                //Use named capturing groups to make life easier
                var pattern = "&quot;((?<tabla>" + table + ").(?<campo>.\\w+))&quot;";

                //newLine = Regex.Replace(newLine, pattern, replacePattern, RegexOptions.IgnoreCase);
                newLine = Regex.Replace(newLine, pattern, 
                                               m => $"&quot;{m.Groups[2].Value}.{m.Groups[3].Value.ToLower()}&quot;" ,
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

    }

}