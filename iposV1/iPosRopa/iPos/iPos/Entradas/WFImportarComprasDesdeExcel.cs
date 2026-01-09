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
    public partial class WFImportarComprasDesdeExcel : IposForm
    {

        public bool m_importacionExitosa = false;
        public string m_iComentario;

        public List<Dictionary<string, object>> m_datos = new List<Dictionary<string, object>>();

        public WFImportarComprasDesdeExcel()
        {
            InitializeComponent();
            m_importacionExitosa = false;
            m_iComentario = "";
        }

        private void BTImpCatalogos_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
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
                //MessageBox.Show("EL catalogo ha sido importado");
               
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


            try
            {
                m_datos = new List<Dictionary<string, object>>();

                while (dr.Read())
                {
                    Dictionary<string, object> item = new Dictionary<string, object>();

                    if (dr["CLAVE"] != System.DBNull.Value)
                    {
                        item.Add("CLAVE", (dr["CLAVE"]).ToString().Trim());
                    }
                    else
                    {
                        dr.Close();
                        return false;
                    }


                    if (dr["CANTIDAD"] != System.DBNull.Value)
                    {
                        item.Add("CANTIDAD", decimal.Parse(dr["CANTIDAD"].ToString()));
                    }
                    else
                    {
                        item.Add("CANTIDAD", 0);
                    }

                    if (dr["PRECIOUSD"] != System.DBNull.Value)
                    {
                        item.Add("PRECIOUSD", decimal.Parse(dr["PRECIOUSD"].ToString()));
                    }
                    else
                    {
                        item.Add("PRECIOUSD", decimal.Parse("0"));
                    }

                    try
                    {

                        if (dr["PRECIONORMAL"] != System.DBNull.Value)
                        {
                            item.Add("PRECIONORMAL", decimal.Parse(dr["PRECIONORMAL"].ToString()));
                        }
                    }
                    catch
                    {

                    }


                    try
                    {

                        if (dr["LOTE"] != System.DBNull.Value && dr["LOTE"].ToString().Trim().Length > 0)
                        {
                            item.Add("LOTE", (dr["LOTE"]).ToString().Trim());
                        }
                    }
                    catch
                    {

                    }



                    DateTime? fechaVence = null;
                    try
                    {


                        if (dr["FECHAVENCE"] != System.DBNull.Value && dr["FECHAVENCE"].ToString().Trim().Length > 0)
                        {
                            fechaVence = DateTime.Parse(dr["FECHAVENCE"].ToString());
                        }


                    }
                    catch(Exception ex)
                    {
                        try
                        {

                            if (dr["FECHAVENCE"] != System.DBNull.Value && dr["FECHAVENCE"].ToString().Trim().Length > 0)
                            {
                                fechaVence = (DateTime)dr["FECHAVENCE"];
                            }
                        }
                        catch (Exception ex2)
                        {

                        }
                    }
                    item.Add("FECHAVENCE", fechaVence);

                    m_datos.Add(item);

                }

                dr.Close();


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
