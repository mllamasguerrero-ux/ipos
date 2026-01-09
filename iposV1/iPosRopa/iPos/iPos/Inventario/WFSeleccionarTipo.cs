using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosData;
using iPosBusinessEntity;
using ConexionesBD;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.ApplicationBlocks.Data;
using System.Collections;

namespace iPos
{
    public partial class WFSeleccionarTipo : IposForm
    {
        long m_doctoId;
        string m_sCadenaConexion;


        //string[] m_columnTitlesExcel = new string[] {   "",	
        //                                                "",	
        //                                                "PRODUCTO",	
        //                                                "DESCRIPCION",	
        //                                                "LOTE",
        //                                                "FECHA VENCIMIENTO",	
        //                                                "CANT. TEORICA",	
        //                                                "CANT. FISICA",	
        //                                                "CANT. DIFERENCIA",	
        //                                                "",	
        //                                                ""    };

        public WFSeleccionarTipo()
        {
            InitializeComponent();
            m_doctoId = 0;
            m_sCadenaConexion = ConexionBD.ConexionString();
        }

        public WFSeleccionarTipo(long doctoId):
            this()
        {
            m_doctoId = doctoId;
        }

        private void BTContinuar_Click(object sender, EventArgs e)
        {

            if (RBCompleto.Checked || RBParcialProducto.Checked)
            {
                if (!GenerarInventarioCompleto())
                    return ;
            }


            WFListaDiferencias li = new WFListaDiferencias(m_doctoId);
            li.ShowDialog();
            li.Dispose();
            this.Close();
        }

        private bool GenerarInventarioCompleto()
        {
            FbConnection fConn = new FbConnection(this.m_sCadenaConexion);
            FbTransaction fTrans = null;

            try
            {
                fConn.Open();
                fTrans = fConn.BeginTransaction();

                ArrayList parts = new ArrayList();
                FbParameter auxPar;

                auxPar = new FbParameter("@DOCTOID", FbDbType.BigInt);
                auxPar.Value = m_doctoId;
                parts.Add(auxPar);


                auxPar = new FbParameter("@PERSONAID", FbDbType.BigInt);
                auxPar.Value = CurrentUserID.CurrentUser.IID;
                parts.Add(auxPar);

                auxPar = new FbParameter("@SUBTIPODOCTOID", FbDbType.BigInt);
                auxPar.Value = RBParcialProducto.Checked ? 9 : 4;
                parts.Add(auxPar);



                auxPar = new FbParameter("@ERRORCODE", FbDbType.Integer);
                auxPar.Direction = ParameterDirection.Output;
                parts.Add(auxPar);


                string commandText = @"INVFIS_GEN_COMPLETO";

                FbParameter[] arParms = new FbParameter[parts.Count];
                parts.CopyTo(arParms, 0);

                SqlHelper.ExecuteNonQuery(this.m_sCadenaConexion, CommandType.StoredProcedure, commandText, arParms);




                if (!(arParms[arParms.Length - 1].Value == System.DBNull.Value))
                {
                    if ((int)arParms[arParms.Length - 1].Value != 0)
                    {

                        fTrans.Rollback();
                        fConn.Close();

                        string strMensajeErr = CERRORCODED.ObtenerMensajeError((long)((int)arParms[arParms.Length - 1].Value), this.m_sCadenaConexion, null);
                        MessageBox.Show("Hubo un error : " + strMensajeErr);
                        return false;
                    }
                }


                fTrans.Commit();
                fConn.Close();

                return true;

            }
            catch (Exception e)
            {
                fTrans.Rollback();
                fConn.Close();

                MessageBox.Show(e.Message + e.StackTrace);
                return false;
            }
            finally
            {
                fConn.Close();
            }

        }

        private void WFSeleccionarTipo_Load(object sender, EventArgs e)
        {
            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            doctoBE.IID = m_doctoId;
            doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);
            if (!(bool)doctoBE.isnull["ISUBTIPODOCTOID"])
            {
                if (doctoBE.ISUBTIPODOCTOID == 4)
                {
                    RBCompleto.Checked = true;
                    RBParcial.Checked = false;
                    RBParcial.Enabled = false;
                }
            }
        }






    }
}
