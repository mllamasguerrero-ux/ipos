using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Net.Mime;
using System.IO;
using System.Web;

namespace iPos
{
    public partial class WFExportarAExcel : IposForm
    {

        private bool m_importacionExitosa;
        private string m_iComentario;
        private string m_nombreArchivoDestino;

        public WFExportarAExcel()
        {
            InitializeComponent();
            m_importacionExitosa = false;
            m_iComentario = "";
            m_nombreArchivoDestino = "";
        }

        private void BTProductos_Click(object sender, EventArgs e)
        {

            SaveFileDialog openFileDialog1 = new SaveFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                m_nombreArchivoDestino = openFileDialog1.FileName;
                m_importacionExitosa = false;
                m_iComentario = "";
                this.BTProductos.Enabled = false;
                progressBar1.Style = ProgressBarStyle.Marquee;
                backgroundWorker1.RunWorkerAsync();
            }

        }



        private void ConvertToXls(System.Data.DataTable table, string ExcelFileName)
        {
            try
            {

                //DataSet dsBook = GetGridViewDataSet();//Get the DataSet from your DataSource
                int rows = table.Rows.Count + 1;
                int cols = table.Columns.Count;

                // string ExcelFileName = Path.Combine(Request.PhysicalApplicationPath, fileName);
                if (File.Exists(ExcelFileName))
                {
                    File.Delete(ExcelFileName);
                }
                StreamWriter writer = new StreamWriter(ExcelFileName, false);
                writer.WriteLine("<?xml version=\"1.0\"?>");
                writer.WriteLine("<?mso-application progid=\"Excel.Sheet\"?>");
                writer.WriteLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
                writer.WriteLine(" xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
                writer.WriteLine(" xmlns:x=\"urn:schemas-microsoft-com:office:excel\"");
                writer.WriteLine(" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\"");
                writer.WriteLine(" xmlns:html=\"http://www.w3.org/TR/REC-html40/\">");
                writer.WriteLine(" <DocumentProperties xmlns=\"urn:schemas-microsoft-com:office:office\">;");
                writer.WriteLine("  <Author>Automated Report Generator Example</Author>");
                writer.WriteLine(string.Format("  <Created>{0}T{1}Z</Created>", DateTime.Now.ToString("yyyy-mm-dd"), DateTime.Now.ToString("HH:MM:SS")));
                writer.WriteLine("  <Company>51aspx.com</Company>");
                writer.WriteLine("  <Version>11.6408</Version>");
                writer.WriteLine(" </DocumentProperties>");
                writer.WriteLine(" <ExcelWorkbook xmlns=\"urn:schemas-microsoft-com:office:excel\">");
                writer.WriteLine("  <WindowHeight>8955</WindowHeight>");
                writer.WriteLine("  <WindowWidth>11355</WindowWidth>");
                writer.WriteLine("  <WindowTopX>480</WindowTopX>");
                writer.WriteLine("  <WindowTopY>15</WindowTopY>");
                writer.WriteLine("  <ProtectStructure>False</ProtectStructure>");
                writer.WriteLine("  <ProtectWindows>False</ProtectWindows>");
                writer.WriteLine(" </ExcelWorkbook>");
                writer.WriteLine(" <Styles>");
                writer.WriteLine("  <Style ss:ID=\"Default\" ss:Name=\"Normal\">");
                writer.WriteLine("   <Alignment ss:Vertical=\"Bottom\"/>");
                writer.WriteLine("   <Borders/>");
                writer.WriteLine("   <Font/>");
                writer.WriteLine("   <Interior/>");
                writer.WriteLine("   <Protection/>");
                writer.WriteLine("  </Style>");
                writer.WriteLine("  <Style ss:ID=\"s21\">");
                writer.WriteLine("   <Alignment ss:Vertical=\"Bottom\" ss:WrapText=\"1\"/>");
                writer.WriteLine("  </Style>");
                writer.WriteLine(" </Styles>");
                writer.WriteLine(" <Worksheet ss:Name=\"productos\">");
                writer.WriteLine(string.Format("  <Table ss:ExpandedColumnCount=\"{0}\" ss:ExpandedRowCount=\"{1}\" x:FullColumns=\"1\"", cols.ToString(), rows.ToString()));
                writer.WriteLine("   x:FullRows=\"1\">");

                //generate title
                writer.WriteLine("<Row>");
                foreach (DataColumn eachCloumn in table.Columns)  // you can write a half columns of table and put the remaining columns in sheet2
                {
                    writer.Write("<Cell ss:StyleID=\"s21\"><Data ss:Type=\"String\">");
                    writer.Write(eachCloumn.ColumnName.ToString());
                    writer.WriteLine("</Data></Cell>");
                }
                writer.WriteLine("</Row>");

                //generate data
                foreach (DataRow eachRow in table.Rows)
                {
                    writer.WriteLine("<Row>");
                    for (int currentRow = 0; currentRow != cols; currentRow++)
                    {
                        writer.Write("<Cell ss:StyleID=\"s21\"><Data ss:Type=\"String\">");
                        writer.Write(eachRow[currentRow].ToString());
                        writer.WriteLine("</Data></Cell>");
                    }
                    writer.WriteLine("</Row>");
                }
                writer.WriteLine("  </Table>");
                writer.WriteLine("  <WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\">");
                writer.WriteLine("   <Selected/>");
                writer.WriteLine("   <Panes>");
                writer.WriteLine("    <Pane>");
                writer.WriteLine("     <Number>3</Number>");
                writer.WriteLine("     <ActiveRow>1</ActiveRow>");
                writer.WriteLine("    </Pane>");
                writer.WriteLine("   </Panes>");
                writer.WriteLine("   <ProtectObjects>False</ProtectObjects>");
                writer.WriteLine("   <ProtectScenarios>False</ProtectScenarios>");
                writer.WriteLine("  </WorksheetOptions>");
                writer.WriteLine(" </Worksheet>");
                writer.WriteLine(" <Worksheet ss:Name=\"Sheet2\">");
                writer.WriteLine("  <WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\">");
                writer.WriteLine("   <ProtectObjects>False</ProtectObjects>");
                writer.WriteLine("   <ProtectScenarios>False</ProtectScenarios>");
                writer.WriteLine("  </WorksheetOptions>");
                writer.WriteLine(" </Worksheet>");
                writer.WriteLine(" <Worksheet ss:Name=\"Sheet3\">");
                writer.WriteLine("  <WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\">");
                writer.WriteLine("   <ProtectObjects>False</ProtectObjects>");
                writer.WriteLine("   <ProtectScenarios>False</ProtectScenarios>");
                writer.WriteLine("  </WorksheetOptions>");
                writer.WriteLine(" </Worksheet>");
                writer.WriteLine("</Workbook>");
                writer.Close();
                //Response.Write("<script language=\"javascript\">" + "alert('" + "convert completed!')" + "</script>");
            }
            catch
            {
                //Response.Write("<script language=\"javascript\">" + "alert('" + "error! " + ex.Message + "')" + "</script>");
            }
        }

        //public static void ExportToSpreadsheet(System.Data.DataTable table, string name)
        //{
        //    HttpContext context = HttpContext.Current;
        //    context.Response.Clear();
        //    foreach (DataColumn column in table.Columns)
        //    {
        //        context.Response.Write(column.ColumnName + ";");
        //    }
        //    context.Response.Write(Environment.NewLine);
        //    foreach (DataRow row in table.Rows)
        //    {
        //        for (int i = 0; i < table.Columns.Count; i++)
        //        {
        //            context.Response.Write(row[i].ToString().Replace(";", string.Empty) + ";");
        //        }
        //        context.Response.Write(Environment.NewLine);
        //    }
        //    context.Response.ContentType = "text/csv";
        //    context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + name + ".csv");
        //    context.Response.End();
        //}




        //public static void ExportarExcelDataTable(System.Data.DataTable dt, string RutaExcel)
        //{
        //    const string FIELDSEPARATOR = ",";
        //    const string ROWSEPARATOR = "\n";
        //    StringBuilder output = new StringBuilder();
        //    // Escribir encabezados    
        //    foreach (DataColumn dc in dt.Columns)
        //    {
        //        output.Append(dc.ColumnName);
        //        output.Append(FIELDSEPARATOR);
        //    }
        //    output.Append(ROWSEPARATOR);
        //    foreach (DataRow item in dt.Rows)
        //    {
        //        foreach (object value in item.ItemArray)
        //        {
        //            output.Append("\"" + value.ToString().Replace('\n', ' ').Replace('\r', ' ')/*.Replace('.', ',')*/ + "\"" );
        //            output.Append(FIELDSEPARATOR);
        //        }
        //        // Escribir una línea de registro        
        //        output.Append(ROWSEPARATOR);
        //    }
        //    // Valor de retorno    
        //    // output.ToString();
        //    StreamWriter sw = new StreamWriter(RutaExcel, false, System.Text.Encoding.GetEncoding("iso-8859-1"));
        //    sw.Write(output.ToString());
        //    sw.Close();
        //}



        // public static bool Excel_FromDataTable(System.Data.DataTable dt,string fileName)
        //{
        //    string strColName = "";
        //    // Create an Excel object and add workbook..
        //    ApplicationClass excel = new ApplicationClass();
        //    try
        //    {

        //        if (File.Exists(fileName))
        //            File.Delete(fileName);

        //        Workbook workbook = excel.Application.Workbooks.Add(true); // true for object template???

        //        // Add column headings...
        //        int iCol = 0;
        //        int iX = 0;
        //        int iRow = 1;



        //        foreach (DataColumn c in dt.Columns)
        //        {
        //            strColName = c.ColumnName;//columnNames[iX];
        //            iX++;
        //            if (strColName == "")
        //                continue;

        //            iCol++;
        //            excel.Cells[iRow, iCol] = /*c.ColumnName*/strColName;
        //        }


        //        // for each row of data...
        //        //int iRow = 2;
        //        foreach (DataRow r in dt.Rows)
        //        {

        //            // add each row's cell data...
        //            iCol = 0;
        //            iX = 0;
        //            foreach (DataColumn c in dt.Columns)
        //            {
        //                strColName = c.ColumnName;//columnNames[iX];
        //                iX++;
        //                if (strColName == "")
        //                    continue;

        //                iCol++;
        //                excel.Cells[iRow + 1, iCol] = r[c.ColumnName];
        //            }
        //            iRow++;
        //        }

        //        // Global missing reference for objects we are not defining...
        //        object missing = System.Reflection.Missing.Value;

        //        // If wanting to Save the workbook...
        //        workbook.SaveAs(fileName,
        //        XlFileFormat.xlXMLSpreadsheet, missing, missing,
        //        false, false, XlSaveAsAccessMode.xlNoChange,
        //        missing, missing, missing, missing, missing);

        //        // If wanting to make Excel visible and activate the worksheet...
        //        excel.Visible = true;
        //        Worksheet worksheet = (Worksheet)excel.ActiveSheet;
        //        ((_Worksheet)worksheet).Activate();

        //        // If wanting excel to shutdown...
        //        ((_Application)excel).Quit();

        //        return true;
        //    }
        //    catch(Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message + ex.StackTrace);

        //        ((_Application)excel).Quit();
        //        return false;
        //    }
        //}

        private void WFExportarAExcel_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            m_importacionExitosa = ExportaProductosAExcel();
        }

        private bool ExportaProductosAExcel()
        {



            this.pRODUCTOS_EXPORTVIEWTableAdapter.Fill(this.dSImportaciones.PRODUCTOS_EXPORTVIEW);

                try
                {
                    //Excel_FromDataTable(this.dSImportaciones.PRODUCTOS_EXPORTVIEW,openFileDialog1.FileName);
                    // ExportarExcelDataTable(this.dSImportaciones.PRODUCTOS_EXPORTVIEW, openFileDialog1.FileName);
                    //ExportToSpreadsheet(this.dSImportaciones.PRODUCTOS_EXPORTVIEW, openFileDialog1.FileName);

                    ConvertToXls(this.dSImportaciones.PRODUCTOS_EXPORTVIEW, m_nombreArchivoDestino);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    return false;
                }

            return true;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            progressBar1.Style = ProgressBarStyle.Blocks;
            this.BTProductos.Enabled = true;
            //ActualizarEstatusBotones();

            if (m_importacionExitosa)
            {
                MessageBox.Show("La exportacion se realizo, porfavor, abra el archivo resultante en excel y reguardelo como archivo xls (office 2003) para que pueda servirle para hacer importaciones de catalogo de produto");
 
            }
            else
            {
                MessageBox.Show(m_iComentario);
            }
        }





    }
}
