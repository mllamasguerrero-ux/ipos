using DataLayer;
using FirebirdSql.Data.FirebirdClient;
using iPos.Catalogos;
using iPosData;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iPos.Contabilidad
{
    public partial class WFGenerarPolizas : Form
    {
        //private Contabilidad.DSContabilidad dSContabilidad = new Contabilidad.DSContabilidad();

        bool m_bDerechoPolizaPVC = false;

        bool m_flagCondensado = false;

        public WFGenerarPolizas()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                dtpEnd.Visible = true;
            }
            else
            {
                dtpEnd.Visible = false;
            }
        }

        public string space(int numeroEspacios)
        {
            string spaces = "";
            for(int i = 0; i < numeroEspacios; i++)
            {
                spaces += " ";
            }
            return spaces;
        }

        private void btnGeneratePolizas_Click(object sender, EventArgs e)
        {
           
            CrearPoliza();
        }


        private void CrearPoliza()
        {
            DateTime fechaInicial = this.dtpBegin.Value.Date;
            DateTime fechaFinal = checkBox1.Checked ? this.dtpEnd.Value.Date : this.dtpBegin.Value.Date;

            string folderName = "";

            int result = (int)this.folderBrowserDialog1.ShowDialog();
            if (result == (int)System.Windows.Forms.FolderBrowserResult.OK)
            {
                folderName = this.folderBrowserDialog1.SelectedPath;
            }
            else
            {
                return;
            }
            
            for(DateTime date = fechaInicial; date.Date <= fechaFinal; date = date.AddDays(1))
            {

                LlenarDatosHdr(date);


                //ORIG string pathAndName = folderName + @"\Poliza" + date.ToString("yyyyMMdd") + ".txt";
                string pathAndName = m_flagCondensado ? folderName + @"\Poliza" + "PRUEBA" + ".txt"
                                        : folderName + @"\Poliza" + date.ToString("yyyyMMdd") + ".txt";

                //string pathAndName = @"C:\temporal\polizas\test.txt";

                if ( m_bDerechoPolizaPVC )
                {

                    LlenarDatosPVC(date);
                    //AQUI SE HARIA EL CODIGO DE LO DE PVC
                    using (StreamWriter sw = new StreamWriter(pathAndName))
                    {

                        if ( this.dSContabilidad1.POLIZALINEA_HDR.Rows.Count > 0)
                        {
                            iPos.Contabilidad.DSContabilidad.POLIZALINEA_HDRRow drh = (iPos.Contabilidad.DSContabilidad.POLIZALINEA_HDRRow)this.dSContabilidad1.POLIZALINEA_HDR.Rows[0];
                            //string strBufferHdr = "P " + date.ToString("yyyyMMdd") + " 3 " + drh.CUENTAEMPRESA + " 1 000 Poliza ventas del dia " + date.ToString("dd/MM/yyyy");
                            string strBufferHdr = "P " + date.ToString("yyyyMMdd") + " 3 00000001 1 000 Poliza ventas del dia " + date.ToString("dd/MM/yyyy") + "                                                                     01 2   ";
                            sw.WriteLine(strBufferHdr);
                        }



                        foreach (iPos.Contabilidad.DSContabilidad.POLIZALINEA_DET_PVCRow dr in this.dSContabilidad1.POLIZALINEA_DET_PVC.Rows)
                        {
                            string strBuffer = "M " + dr.NUMCUENTA.PadRight(20) + " " + dr.LEYENDA.PadRight(/*6*/10) + " " + dr.TIPOENTRADA.ToString() + " " + dr.MONTO.ToString("###0.00").Replace(",", "").PadLeft(16) + " 000             0.00                                                               ";
                            sw.WriteLine(strBuffer);
                        }


                    }
                }
                else //SI NO TIENE EL DERECHO SE HACE NORMAL
                {


                    LlenarDatos(date);
                    //ORIG using (StreamWriter sw = new StreamWriter(pathAndName))
                    using (StreamWriter sw = new StreamWriter(pathAndName, m_flagCondensado))
                    {
                        //ORIG if ( this.dSContabilidad1.POLIZALINEA_HDR.Rows.Count > 0)
                        if (!m_flagCondensado && this.dSContabilidad1.POLIZALINEA_HDR.Rows.Count > 0)
                        {
                            iPos.Contabilidad.DSContabilidad.POLIZALINEA_HDRRow drh = (iPos.Contabilidad.DSContabilidad.POLIZALINEA_HDRRow)this.dSContabilidad1.POLIZALINEA_HDR.Rows[0];

                            string cuentaEmpresaSucursal = drh.CUENTAEMPRESA;
                            if(cuentaEmpresaSucursal  == null ||  cuentaEmpresaSucursal.Trim().Length == 0)
                            {
                                cuentaEmpresaSucursal = "00000001";
                            }
                            else
                            {
                                int iCuentaSuc = 0;
                                if(int.TryParse(cuentaEmpresaSucursal, out iCuentaSuc))
                                {
                                    iCuentaSuc += date.Day;

                                    cuentaEmpresaSucursal = iCuentaSuc.ToString().PadLeft(8, '0');

                                }
                            }

                            string strBufferHdr = "P " + date.ToString("yyyyMMdd") + " 1 " + cuentaEmpresaSucursal + " 1 000 Poliza ventas del dia " + date.ToString("dd/MM/yyyy") + "                                                                     01 2   ";
                            sw.WriteLine(strBufferHdr);
                        }



                        foreach (iPos.Contabilidad.DSContabilidad.POLIZALINEA_DETRow dr in this.dSContabilidad1.POLIZALINEA_DET.Rows)
                        {
                            //ORIG string strBuffer = "M " + dr.NUMCUENTA.PadRight(20) + " " + dr.LEYENDA.PadRight(/*6*/10) + " " + dr.TIPOENTRADA.ToString() + " " + dr.MONTO.ToString("###0.00").Replace(",", "").PadLeft(16) + " 000             0.00                                                               ";
                            string strBuffer = m_flagCondensado ? date.ToString("yyyyMMdd") + " " +  dr.NUMCUENTA.PadRight(20) + "  " + dr.LEYENDA.PadRight(/*6*/10) + "    " + dr.TIPOENTRADA.ToString() + "   " + dr.MONTO.ToString("###0.00").Replace(",", "").PadLeft(16)
                                              : "M " + dr.NUMCUENTA.PadRight(20) + " " + dr.LEYENDA.PadRight(/*6*/10) + " " + dr.TIPOENTRADA.ToString() + " " + dr.MONTO.ToString("###0.00").Replace(",", "").PadLeft(16) + " 000             0.00                                                               ";
                            sw.WriteLine(strBuffer);
                        }


                    }
                }
            }


            MessageBox.Show("Se exportaron los archivos de poliza");
        }


        private void LlenarDatos(DateTime fecha)
        {
            try
            {
                this.pOLIZALINEA_DETTableAdapter.Fill(this.dSContabilidad1.POLIZALINEA_DET, fecha);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void LlenarDatosPVC(DateTime fecha)
        {
            try
            {
                this.pOLIZALINEA_DET_PVCTableAdapter.Fill(this.dSContabilidad1.POLIZALINEA_DET_PVC, fecha);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void LlenarDatosHdr(DateTime fecha)
        {
            try
            {
                this.pOLIZALINEA_HDRTableAdapter.Fill(this.dSContabilidad1.POLIZALINEA_HDR, fecha);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void WFGenerarPolizas_Load(object sender, EventArgs e)
        {
              CUSUARIOSD usuariosD = new CUSUARIOSD();
              if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_CUENTAS_PVC, null))//SI EL USUARIO TIENE EL DERECHO DE PVC 
              {
                  m_bDerechoPolizaPVC = true;
              }
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            CrearPolizaPDF();
        }

        private void CrearPolizaPDF()
        {
            DateTime fechaInicial = this.dtpBegin.Value.Date;
            DateTime fechaFinal = checkBox1.Checked ? this.dtpEnd.Value.Date : this.dtpBegin.Value.Date;

            string folderName = "";

            if (CurrentUserID.CurrentParameters.IRUTAPOLIZAPDF != null && CurrentUserID.CurrentParameters.IRUTAPOLIZAPDF.Trim().Length > 0)
            {
                folderName = CurrentUserID.CurrentParameters.IRUTAPOLIZAPDF;
            }
            else
            {

                int result = (int)this.folderBrowserDialog1.ShowDialog();
                if (result == (int)System.Windows.Forms.FolderBrowserResult.OK)
                {
                    folderName = this.folderBrowserDialog1.SelectedPath;
                }
                else
                {
                    return;
                }
            }

            for (DateTime date = fechaInicial; date.Date <= fechaFinal; date = date.AddDays(1))
            {
                

                string pathAndName = folderName + @"\Poliza" + date.ToString("yyyyMMdd") + ".pdf";
                //string pathAndName = @"C:\temporal\polizas\test.txt";

                if (m_bDerechoPolizaPVC)
                {

                    MessageBox.Show("Esto aun no esta implementado");
                }
                else //SI NO TIENE EL DERECHO SE HACE NORMAL
                {
                    FastReport.Report report1 = new FastReport.Report();
                    report1.Load(FastReportsConfig.getPathForFile("PolizaDet.frx", FastReportsTipoFile.desistema));
                    report1.Dictionary.Connections[0].ConnectionString = ConexionesBD.ConexionBD.ConexionBase;
                    report1.SetParameterValue("US_ID", CurrentUserID.CurrentUser.IID);
                    report1.SetParameterValue("US_NAME", CurrentUserID.CurrentUser.INOMBRE);
                    report1.SetParameterValue("fecha", date);

                    if (report1.Prepare())
                    {

                        FastReport.Export.Pdf.PDFExport pdfExport = null;
                        pdfExport = new FastReport.Export.Pdf.PDFExport();
                        
                        pdfExport.Export(report1, pathAndName);

                        System.Diagnostics.Process.Start(pathAndName);

                    }



                }
                MessageBox.Show("Se exportaron los archivos de poliza");
            }


        }

        /*exportar ingresuc*/

        public bool ExportarListaAExcel(string archivoExcel, ref string comentario)
        {

            string excelConnection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivoExcel + ";Extended Properties=\"Excel 8.0;HDR=YES;MAXSCANROWS=15;READONLY=FALSE\"";

            DateTime fechaInicial = this.dtpBegin.Value.Date;
            DateTime fechaFinal = checkBox1.Checked ? this.dtpEnd.Value.Date : this.dtpBegin.Value.Date;


            comentario = "";
            //FbParameter auxPar;
            System.Collections.ArrayList parts;
            String CmdTxt;
            FbParameter[] arParms;
            /**/
            FbDataReader dr = null;
            FbConnection pcn = null;
            FbParameter auxPar;

            try
            {



                System.Collections.ArrayList oleParts = new ArrayList();
                OleDbParameter[] oleArParms = new OleDbParameter[oleParts.Count];
                oleParts.CopyTo(oleArParms, 0);
                String oleCmdTxt = @"DROP TABLE [Hoja1$] ; ";

                try
                {
                    OleDbHelper.ExecuteNonQuery(excelConnection, CommandType.Text, oleCmdTxt, oleArParms);
                }
                catch
                {

                }

                oleCmdTxt = @"CREATE TABLE [Hoja1] (SUCURSAL VARCHAR, F_FACTURA DATE, SUMA DECIMAL, IEPS8 DECIMAL, IEPS20 DECIMAL, CERVE DECIMAL, REFES DECIMAL, CERVE26 DECIMAL, IEPS26 DECIMAL, ALCOH DECIMAL, OTROS DECIMAL, IEPS30 DECIMAL, IEPS50 DECIMAL, ALCOH53 DECIMAL, IEPS53 DECIMAL, IVA DECIMAL, TOTAL DECIMAL, EST VARCHAR, DESC_ VARCHAR ); ";
                OleDbHelper.ExecuteNonQuery(excelConnection, CommandType.Text, oleCmdTxt, oleArParms);

                OleDbParameter oleAuxPar;

                oleCmdTxt = "INSERT INTO [Hoja1] (SUCURSAL, F_FACTURA, SUMA, IEPS8, IEPS20, CERVE, REFES, CERVE26, IEPS26, ALCOH, OTROS, IEPS30, IEPS50, ALCOH53, IEPS53, IVA, TOTAL, EST, DESC_) VALUES (@SUCURSAL, @F_FACTURA, @SUMA, @IEPS8, @IEPS20, @CERVE, @REFES, @CERVE26, @IEPS26, @ALCOH, @OTROS, @IEPS30, @IEPS50, @ALCOH53, @IEPS53, @IVA, @TOTAL, @EST, @DESC_)";



                parts = new ArrayList();

                auxPar = new FbParameter("@FECHAINICIO", FbDbType.Date);
                auxPar.Value = fechaInicial;
                parts.Add(auxPar);

                auxPar = new FbParameter("@FECHAFIN", FbDbType.Date);
                auxPar.Value = fechaFinal;
                parts.Add(auxPar);


                CmdTxt = @"INGRESUC_QUERY";

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                dr = SqlHelper.ExecuteReader(ConexionesBD.ConexionBD.ConexionString(), CommandType.StoredProcedure, CmdTxt, out pcn, arParms);


                while (dr.Read())
                {
                    oleParts = new ArrayList();




                    if (dr["SUCURSAL"] != System.DBNull.Value)
                    {

                        oleAuxPar = new OleDbParameter("@SUCURSAL", OleDbType.VarChar);
                        oleAuxPar.Value = ((string)(dr["SUCURSAL"])).Trim();
                        oleParts.Add(oleAuxPar);

                    }

                    if (dr["F_FACTURA"] != System.DBNull.Value)
                    {

                        oleAuxPar = new OleDbParameter("@F_FACTURA", OleDbType.Date);
                        oleAuxPar.Value = ((DateTime)(dr["F_FACTURA"]));
                        oleParts.Add(oleAuxPar);

                    }

                    if (dr["SUMA"] != System.DBNull.Value)
                    {

                        oleAuxPar = new OleDbParameter("@SUMA", OleDbType.Decimal);
                        oleAuxPar.Value = ((decimal)(dr["SUMA"]));
                        oleParts.Add(oleAuxPar);

                    }

                    if (dr["IEPS8"] != System.DBNull.Value)
                    {

                        oleAuxPar = new OleDbParameter("@IEPS8", OleDbType.Decimal);
                        oleAuxPar.Value = ((decimal)(dr["IEPS8"]));
                        oleParts.Add(oleAuxPar);

                    }

                    if (dr["IEPS20"] != System.DBNull.Value)
                    {

                        oleAuxPar = new OleDbParameter("@IEPS20", OleDbType.Decimal);
                        oleAuxPar.Value = ((decimal)(dr["IEPS20"]));
                        oleParts.Add(oleAuxPar);

                    }

                    if (dr["CERVE"] != System.DBNull.Value)
                    {

                        oleAuxPar = new OleDbParameter("@CERVE", OleDbType.Decimal);
                        oleAuxPar.Value = ((decimal)(dr["CERVE"]));
                        oleParts.Add(oleAuxPar);

                    }

                    if (dr["REFES"] != System.DBNull.Value)
                    {

                        oleAuxPar = new OleDbParameter("@REFES", OleDbType.Decimal);
                        oleAuxPar.Value = ((decimal)(dr["REFES"]));
                        oleParts.Add(oleAuxPar);

                    }

                    if (dr["CERVE26"] != System.DBNull.Value)
                    {

                        oleAuxPar = new OleDbParameter("@CERVE26", OleDbType.Decimal);
                        oleAuxPar.Value = ((decimal)(dr["CERVE26"]));
                        oleParts.Add(oleAuxPar);

                    }

                    if (dr["IEPS26"] != System.DBNull.Value)
                    {

                        oleAuxPar = new OleDbParameter("@IEPS26", OleDbType.Decimal);
                        oleAuxPar.Value = ((decimal)(dr["IEPS26"]));
                        oleParts.Add(oleAuxPar);

                    }

                    if (dr["ALCOH"] != System.DBNull.Value)
                    {

                        oleAuxPar = new OleDbParameter("@ALCOH", OleDbType.Decimal);
                        oleAuxPar.Value = ((decimal)(dr["ALCOH"]));
                        oleParts.Add(oleAuxPar);

                    }

                    if (dr["OTROS"] != System.DBNull.Value)
                    {

                        oleAuxPar = new OleDbParameter("@OTROS", OleDbType.Decimal);
                        oleAuxPar.Value = ((decimal)(dr["OTROS"]));
                        oleParts.Add(oleAuxPar);

                    }

                    if (dr["IEPS30"] != System.DBNull.Value)
                    {

                        oleAuxPar = new OleDbParameter("@IEPS30", OleDbType.Decimal);
                        oleAuxPar.Value = ((decimal)(dr["IEPS30"]));
                        oleParts.Add(oleAuxPar);

                    }

                    if (dr["IEPS50"] != System.DBNull.Value)
                    {

                        oleAuxPar = new OleDbParameter("@IEPS50", OleDbType.Decimal);
                        oleAuxPar.Value = ((decimal)(dr["IEPS50"]));
                        oleParts.Add(oleAuxPar);

                    }

                    if (dr["ALCOH53"] != System.DBNull.Value)
                    {

                        oleAuxPar = new OleDbParameter("@ALCOH53", OleDbType.Decimal);
                        oleAuxPar.Value = ((decimal)(dr["ALCOH53"]));
                        oleParts.Add(oleAuxPar);

                    }

                    if (dr["IEPS53"] != System.DBNull.Value)
                    {

                        oleAuxPar = new OleDbParameter("@IEPS53", OleDbType.Decimal);
                        oleAuxPar.Value = ((decimal)(dr["IEPS53"]));
                        oleParts.Add(oleAuxPar);

                    }

                    if (dr["IVA"] != System.DBNull.Value)
                    {

                        oleAuxPar = new OleDbParameter("@IVA", OleDbType.Decimal);
                        oleAuxPar.Value = ((decimal)(dr["IVA"]));
                        oleParts.Add(oleAuxPar);

                    }

                    if (dr["TOTAL"] != System.DBNull.Value)
                    {

                        oleAuxPar = new OleDbParameter("@TOTAL", OleDbType.Decimal);
                        oleAuxPar.Value = ((decimal)(dr["TOTAL"]));
                        oleParts.Add(oleAuxPar);

                    }

                    if (dr["EST"] != System.DBNull.Value)
                    {

                        oleAuxPar = new OleDbParameter("@EST", OleDbType.VarChar);
                        oleAuxPar.Value = ((string)(dr["EST"])).Trim();
                        oleParts.Add(oleAuxPar);

                    }

                    if (dr["DESC_"] != System.DBNull.Value)
                    {

                        oleAuxPar = new OleDbParameter("@DESC_", OleDbType.VarChar);
                        oleAuxPar.Value = ((string)(dr["DESC_"])).Trim();
                        oleParts.Add(oleAuxPar);

                    }


                    oleArParms = new OleDbParameter[oleParts.Count];
                    oleParts.CopyTo(oleArParms, 0);

                    OleDbHelper.ExecuteNonQuery(excelConnection, CommandType.Text, oleCmdTxt, oleArParms);




                }
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                return true;
            }
            catch (Exception e)
            {
                Microsoft.ApplicationBlocks.Data.SqlHelper.CloseReader(dr, pcn);
                comentario = e.Message + e.StackTrace;
                return false;
            }


        }

        private void btnExportarIngresuc_Click(object sender, EventArgs e)
        {
            string comentario = "";

            string fileExcel = "";

            SaveFileDialog openFileDialog1 = new SaveFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileExcel = openFileDialog1.FileName;
            }
            else
            {
                return;
            }

            if (!ExportarListaAExcel(fileExcel, ref comentario))
            {
                MessageBox.Show("Error " +  comentario);
            }
            else
            {
                MessageBox.Show("se exporto");
            }
        }
    }
}
