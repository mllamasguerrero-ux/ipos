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
using Microsoft.ApplicationBlocks.Data;

namespace iPos
{
    public partial class WFExportarListaPrecioDesdeExcel : IposForm
    {

        public bool m_importacionExitosa = false;
        public string m_iComentario;
        public long m_listaPrecioId = 0;

        public List<CLISTAPRECIODETALLEBE> m_datos = new List<CLISTAPRECIODETALLEBE>();

        public WFExportarListaPrecioDesdeExcel()
        {
            InitializeComponent();
            m_importacionExitosa = false;
            m_iComentario = "";
        }

        public WFExportarListaPrecioDesdeExcel(long listaPrecioId):this()
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
            if (ExportarListaAExcel(this.TBImpCatalogos.Text, ref  comentario))
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
                MessageBox.Show("EL catalogo ha sido exportado");
               
                /*WFProductoCambioPrecio wfp = new WFProductoCambioPrecio();
                wfp.ShowDialog();*/

                this.Close();
            }
            else
            {
                MessageBox.Show(m_iComentario);
            }
        }





        public bool ExportarListaAExcel(string archivoExcel, ref string comentario)
        {
            CM_LPDTBE fbItem = new CM_LPDTBE();

            CM_LPDTD m_dbfD = new CM_LPDTD();
            CM_LPDTBE m_dbfBE = new CM_LPDTBE();

            string excelConnection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivoExcel + ";Extended Properties=\"Excel 8.0;HDR=YES;MAXSCANROWS=15;READONLY=FALSE\"";


            
            m_iComentario = "";
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
                
                oleCmdTxt = @"CREATE TABLE [Hoja1$] (CLAVE VARCHAR, PRECIO1 DECIMAL, PRECIO2 DECIMAL, PRECIO3 DECIMAL, PRECIO4 DECIMAL,  PRECIO5 DECIMAL, COSTOREP DECIMAL, TIENEVIG VARCHAR, FECHAVIG DATE); ";
                OleDbHelper.ExecuteNonQuery(excelConnection, CommandType.Text, oleCmdTxt, oleArParms);

                OleDbParameter oleAuxPar;

                oleCmdTxt = "INSERT INTO [Hoja1$] (CLAVE, PRECIO1, PRECIO2, PRECIO3, PRECIO4, PRECIO5, COSTOREP, TIENEVIG , FECHAVIG) VALUES (@CLAVE, @PRECIO1, @PRECIO2, @PRECIO3, @PRECIO4, @PRECIO5, @COSTOREP, @TIENEVIG , @FECHAVIG)";
                


                parts = new ArrayList();

                auxPar = new FbParameter("@LISTAPRECIOID", FbDbType.BigInt);
                auxPar.Value = this.m_listaPrecioId;
                parts.Add(auxPar);


                CmdTxt = @"SELECT LISTAPRECIO.CLAVE LISTA, PRODUCTO.CLAVE PRODUCTO, LISTAPRECIODETALLE.PRECIO1, 
                        LISTAPRECIODETALLE.PRECIO2,  LISTAPRECIODETALLE.PRECIO3, LISTAPRECIODETALLE.PRECIO4,  LISTAPRECIODETALLE.PRECIO5,
                        LISTAPRECIODETALLE.COSTOREPOSICION, LISTAPRECIODETALLE.TIENEVIG, LISTAPRECIODETALLE.FECHAVIG
                        from LISTAPRECIODETALLE LEFT JOIN PRODUCTO ON PRODUCTO.ID = LISTAPRECIODETALLE.PRODUCTOID
                        LEFT JOIN LISTAPRECIO ON LISTAPRECIO.ID = LISTAPRECIODETALLE.LISTAPRECIOID
                        WHERE LISTAPRECIODETALLE.LISTAPRECIOID = @LISTAPRECIOID";

                arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);
                
                    dr = SqlHelper.ExecuteReader(ConexionesBD.ConexionBD.ConexionString(), CommandType.Text, CmdTxt, out pcn, arParms);
              

                while (dr.Read())
                {
                    oleParts = new ArrayList();
                    


                    if (dr["PRODUCTO"] != System.DBNull.Value)
                    {

                        oleAuxPar = new OleDbParameter("@CLAVE", OleDbType.VarChar);
                        oleAuxPar.Value = ((string)(dr["PRODUCTO"])).Trim();
                        oleParts.Add(oleAuxPar);

                    }


                    if (dr["PRECIO1"] != System.DBNull.Value)
                    {
                        oleAuxPar = new OleDbParameter("@PRECIO1", OleDbType.Decimal);
                        oleAuxPar.Value = (decimal)(dr["PRECIO1"]);
                        oleParts.Add(oleAuxPar);
                    }

                    if (dr["PRECIO2"] != System.DBNull.Value)
                    {
                        oleAuxPar = new OleDbParameter("@PRECIO2", OleDbType.Decimal);
                        oleAuxPar.Value = (decimal)(dr["PRECIO2"]);
                        oleParts.Add(oleAuxPar);
                    }

                    if (dr["PRECIO3"] != System.DBNull.Value)
                    {
                        oleAuxPar = new OleDbParameter("@PRECIO3", OleDbType.Decimal);
                        oleAuxPar.Value = (decimal)(dr["PRECIO3"]);
                        oleParts.Add(oleAuxPar);
                    }

                    if (dr["PRECIO4"] != System.DBNull.Value)
                    {
                        oleAuxPar = new OleDbParameter("@PRECIO4", OleDbType.Decimal);
                        oleAuxPar.Value = (decimal)(dr["PRECIO4"]);
                        oleParts.Add(oleAuxPar);
                    }

                    if (dr["PRECIO5"] != System.DBNull.Value)
                    {
                        oleAuxPar = new OleDbParameter("@PRECIO5", OleDbType.Decimal);
                        oleAuxPar.Value = (decimal)(dr["PRECIO5"]);
                        oleParts.Add(oleAuxPar);
                    }



                    if (dr["COSTOREPOSICION"] != System.DBNull.Value)
                    {
                        oleAuxPar = new OleDbParameter("@COSTOREP", OleDbType.Decimal);
                        oleAuxPar.Value = (decimal)(dr["COSTOREPOSICION"]);
                        oleParts.Add(oleAuxPar);
                    }

                    if (dr["TIENEVIG"] != System.DBNull.Value)
                    {
                        oleAuxPar = new OleDbParameter("@TIENEVIG", OleDbType.VarChar);
                        oleAuxPar.Value = (String)(dr["TIENEVIG"]);
                        oleParts.Add(oleAuxPar);
                    }



                    if (dr["FECHAVIG"] != System.DBNull.Value)
                    {

                        oleAuxPar = new OleDbParameter("@FECHAVIG", OleDbType.Date);
                        oleAuxPar.Value = (DateTime)dr["FECHAVIG"];
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
                m_iComentario = e.Message + e.StackTrace;
                return false;
            }


        }

        

    }
}
