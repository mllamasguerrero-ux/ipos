using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DataLayer;
using iPosData;
using System.Collections;
using System.Data.OleDb;
using iPosBusinessEntity;
using FirebirdSql.Data.FirebirdClient;

namespace iPos
{
    public partial class WFImportarListaPrecioDesdeExcel : IposForm
    {

        public bool m_importacionExitosa = false;
        public string m_iComentario;
        public long m_listaPrecioId = 0;

        public List<CLISTAPRECIODETALLEBE> m_datos = new List<CLISTAPRECIODETALLEBE>();

        public WFImportarListaPrecioDesdeExcel()
        {
            InitializeComponent();
            m_importacionExitosa = false;
            m_iComentario = "";
        }

        public WFImportarListaPrecioDesdeExcel(long listaPrecioId):this()
        {
            m_listaPrecioId = listaPrecioId;
        }


        private void BTImpCatalogos_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Excel files (*.xls)|*.xls| Excel files 2007 (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.TBImpCatalogos.Text = openFileDialog1.FileName;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void BTEnviar_Click(object sender, EventArgs e)
        {        
            if (this.TBImpCatalogos.Text != "")
            {
                m_importacionExitosa = false;
                m_iComentario = "";
                progressBar1.Style = ProgressBarStyle.Marquee;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string comentario = "";
            if (ImportarCompraFromExcel(this.TBImpCatalogos.Text, ref  comentario))
                {
                    m_importacionExitosa = true; 
                }
                else
                {
                   m_iComentario = "No se pudo importar el catalogo " + comentario;
                }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            progressBar1.Style = ProgressBarStyle.Blocks;
            if (m_importacionExitosa)
            {
                MessageBox.Show("EL catalogo ha sido importado");
               
                /*WFProductoCambioPrecio wfp = new WFProductoCambioPrecio();
                wfp.ShowDialog();*/

                this.Close();
            }
            else
            {
                MessageBox.Show(m_iComentario);
            }
        }





        public bool ImportarCompraFromExcel(string archivoExcel, ref string comentario)
        {
            string excelConnection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivoExcel + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;MAXSCANROWS=15;READONLY=FALSE\"";
            System.Collections.ArrayList parts = new ArrayList();
            //OleDbParameter auxPar;
            String CmdTxt = @"select * from [Hoja1$] ";
            OleDbParameter[] arParms = new OleDbParameter[parts.Count];
            parts.CopyTo(arParms, 0);
            OleDbDataReader dr;
            dr = OleDbHelper.ExecuteReader(excelConnection, CommandType.Text, CmdTxt, arParms);



            List<CLISTAPRECIODETALLEBE> lista = new List<CLISTAPRECIODETALLEBE>();

            Boolean desgloseIeps = CurrentUserID.CurrentParameters.IDESGLOSEIEPS != null && CurrentUserID.CurrentParameters.IDESGLOSEIEPS.Equals("S");


            CLISTAPRECIODETALLED listaPrecioD = new CLISTAPRECIODETALLED();

            try
            {
                if (!listaPrecioD.DesactivarxListaPrecio(m_listaPrecioId, null))
                {
                    m_iComentario = listaPrecioD.IComentario;
                    return false;
                }

                m_datos = new List<CLISTAPRECIODETALLEBE>();


                while (dr.Read())
                {
                    CLISTAPRECIODETALLEBE item = new CLISTAPRECIODETALLEBE();
                    item.ILISTAPRECIOID = m_listaPrecioId;


                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        item.IPRODUCTOCLAVE = (dr["CLAVE"]).ToString().Trim();
                    }
                    else
                    {
                        return false;
                    }


                    CPRODUCTOBE prod = new CPRODUCTOBE();
                    CPRODUCTOD prodD = new CPRODUCTOD();

                    prod.ICLAVE = item.IPRODUCTOCLAVE;
                    prod = prodD.seleccionarPRODUCTOxCLAVE(prod, null);

                    if(prod == null)
                    {

                        //dr.Close();
                        m_iComentario = "Hay un producto inexistente";
                        continue;
                    }

                    item.IPRODUCTOID = prod.IID;

                    if (dr["PRECIO1"] != System.DBNull.Value)
                    {

                        if (CBPrecioConImpuesto.Checked)
                        {
                            decimal precioBuffer = decimal.Parse(dr["PRECIO1"].ToString());
                            item.IPRECIO1 = Math.Round((precioBuffer / ((1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100)))), 2);
                        }
                        else
                        {

                            item.IPRECIO1 = decimal.Parse(dr["PRECIO1"].ToString());
                        }
                    }
                    else
                    {
                        item.IPRECIO1 = 0.0m;
                    }


                    if (dr["PRECIO2"] != System.DBNull.Value)
                    {
                        if (CBPrecioConImpuesto.Checked)
                        {
                            decimal precioBuffer = decimal.Parse(dr["PRECIO2"].ToString());
                            item.IPRECIO2 = Math.Round((precioBuffer / ((1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100)))), 2);
                        }
                        else
                        {

                            item.IPRECIO2 = decimal.Parse(dr["PRECIO2"].ToString());
                        }
                    }
                    else
                    {
                        item.IPRECIO2 = 0.0m;
                    }


                    if (dr["PRECIO3"] != System.DBNull.Value)
                    {
                        if (CBPrecioConImpuesto.Checked)
                        {
                            decimal precioBuffer = decimal.Parse(dr["PRECIO3"].ToString());
                            item.IPRECIO3 = Math.Round((precioBuffer / ((1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100)))), 2);
                        }
                        else
                        {

                            item.IPRECIO3 = decimal.Parse(dr["PRECIO3"].ToString());
                        }
                    }
                    else
                    {
                        item.IPRECIO3 = 0.0m;
                    }

                    if (dr["PRECIO4"] != System.DBNull.Value)
                    {
                        if (CBPrecioConImpuesto.Checked)
                        {
                            decimal precioBuffer = decimal.Parse(dr["PRECIO4"].ToString());
                            item.IPRECIO4 = Math.Round((precioBuffer / ((1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100)))), 2);
                        }
                        else
                        {

                            item.IPRECIO4 = decimal.Parse(dr["PRECIO4"].ToString());
                        }
                    }
                    else
                    {
                        item.IPRECIO4 = 0.0m;
                    }

                    if (dr["PRECIO5"] != System.DBNull.Value)
                    {

                        if (CBPrecioConImpuesto.Checked)
                        {
                            decimal precioBuffer = decimal.Parse(dr["PRECIO5"].ToString());
                            item.IPRECIO5 = Math.Round((precioBuffer / ((1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100)))), 2);
                        }
                        else
                        {

                            item.IPRECIO5 = decimal.Parse(dr["PRECIO5"].ToString());
                        }
                    }
                    else
                    {
                        item.IPRECIO5 = 0.0m;
                    }


                    try
                    {
                        if (dr["COSTOREP"] != System.DBNull.Value)
                        {

                            if (CBPrecioConImpuesto.Checked)
                            {
                                decimal precioBuffer = decimal.Parse(dr["COSTOREP"].ToString());
                                item.ICOSTOREPOSICION = Math.Round((precioBuffer / ((1 + ((desgloseIeps ? prod.ITASAIEPS : 0) / 100)) * (1 + (prod.ITASAIVA / 100)))), 2);
                            }
                            else
                            {

                                item.ICOSTOREPOSICION = decimal.Parse(dr["COSTOREP"].ToString());
                            }
                        }
                        else
                        {
                            item.ICOSTOREPOSICION = prod.ICOSTOREPOSICION;
                        }
                    }
                    catch {
                        item.ICOSTOREPOSICION = prod.ICOSTOREPOSICION;
                    }

                    try
                    {
                        if (dr["TIENEVIG"] != System.DBNull.Value)
                        {

                            item.ITIENEVIG = dr["TIENEVIG"].ToString();
                        }
                        else
                        {
                            item.ITIENEVIG = "N";
                        }
                    }
                    catch { }


                    try
                    {
                        if (dr["FECHAVIG"] != System.DBNull.Value)
                        {

                            item.IFECHAVIG = (DateTime)dr["FECHAVIG"];
                        }
                        else
                        {
                            item.IFECHAVIG = DateTime.Today.AddYears(10);
                        }
                    }
                    catch { }



                    item.IACTIVO = "S";
                    item.ILISTAPRECIOID = m_listaPrecioId;


                    if (listaPrecioD.AgregarOCambiarLISTAPRECIODETALLED(item, null) == null)
                    {

                        m_iComentario = listaPrecioD.IComentario;
                        return false;
                    }

                }

                dr.Close();




                if (!listaPrecioD.BorrarInactivosxListaPrecio(m_listaPrecioId, null))
                {

                    m_iComentario = listaPrecioD.IComentario;
                    return false;
                }
                
                return true;


            }
            catch (Exception ex)
            {
                comentario = ex.Message + ex.StackTrace;
                return false;
            }
            finally
            {
            }

            return true;

        }


    }
}
