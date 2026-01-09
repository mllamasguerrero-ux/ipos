using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using iPosData;
using iPosBusinessEntity;
using FirebirdSql.Data.FirebirdClient;
using FlatTabControl;
using iPosReporting;
using System.Diagnostics;
using DataLayer.Importaciones;
using System.IO;

namespace iPos
{
    public partial class WFConsultaOrdenesCompra : Form
    {
        CDOCTOBE m_Docto;
        long m_ClienteId = 0;
        public WFConsultaOrdenesCompra()
        {
            InitializeComponent();
            m_Docto = new CDOCTOBE();
        }

        private void BtnListaTransacciones_Click(object sender, EventArgs e)
        {
            SeleccionarTransaccion();
        }


        private void SeleccionarTransaccion()
        {

            WFLOOKUPCOMPRAS look = new WFLOOKUPCOMPRAS((int)DBValues._DOCTO_ESTATUS_COMPLETO, (int)DBValues._DOCTO_TIPO_ORDEN_COMPRA);
            look.m_preTodosLosCajeros = true;
            look.m_preCorteActual = false;
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                m_Docto = new CDOCTOBE();
                m_Docto.IID = int.Parse(dr[0].ToString());
                CDOCTOD vData = new CDOCTOD();
                m_Docto = vData.seleccionarDOCTO(m_Docto, null);

                if (m_Docto.ITIPODOCTOID != DBValues._DOCTO_TIPO_ORDEN_COMPRA)
                {
                    MessageBox.Show("El registro no es de una orden de compra");
                    m_Docto = new CDOCTOBE();
                    return;
                }

                m_ClienteId = m_Docto.IPERSONAID;

                this.dSEntradasAux.RECEPCIONESORDENCOMPRAPORORDEN.Clear();
                this.dSEntradasAux.DETALLERECEPCIONES.Clear();
                llenarDatosPersona();
                llenarDatosTransaccion(false);
                LlenarGrid();


                TBTransacccion.Text = m_Docto.IFOLIO.ToString("N0");
            }
        }


        public void llenarDatosPersona()
        {
            limpiarDatosPersona();


            CPERSONAD personaD = new CPERSONAD();
            CPERSONABE personaBE = new CPERSONABE();
            personaBE.IID = m_ClienteId;
            personaBE = personaD.seleccionarPERSONA(personaBE, null);
            if (personaBE != null)
            {

                lbClieCiudad.Text = ((bool)personaBE.isnull["ICIUDAD"]) ? "" : personaBE.ICIUDAD;
                lbClieColonia.Text = ((bool)personaBE.isnull["ICOLONIA"]) ? "" : personaBE.ICOLONIA;
                lbClieCP.Text = ((bool)personaBE.isnull["ICODIGOPOSTAL"]) ? "" : personaBE.ICODIGOPOSTAL;
                lbClieDom.Text = ((bool)personaBE.isnull["IDOMICILIO"]) ? "" : personaBE.IDOMICILIO;
                lbClieEstado.Text = ((bool)personaBE.isnull["IESTADO"]) ? "" : personaBE.IESTADO;
                lbClieNombre.Text = ((bool)personaBE.isnull["INOMBRE"]) ? "" : personaBE.INOMBRE;
                lbClieRFC.Text = ((bool)personaBE.isnull["IRFC"]) ? "" : personaBE.IRFC;
                lbClieTel.Text = ((bool)personaBE.isnull["ITELEFONO1"]) ? "" : personaBE.ITELEFONO1;

                LBCliente.Text = personaBE.ICLAVE;

            }

        }



        public void limpiarDatosPersona()
        {

            lbClieCiudad.Text = "";
            lbClieColonia.Text = "";
            lbClieCP.Text = "";
            lbClieDom.Text = "";
            lbClieEstado.Text = "";
            lbClieNombre.Text = "";
            lbClieRFC.Text = "";
            lbClieTel.Text = "";
        }

        public void limpiarDatosTransaccion()
        {

            this.lblFolio.Text = "";
            this.lblFecha.Text = "";
            this.lblTotal.Text = "";

        }

        public void llenarDatosTransaccion(bool bGetfromdb)
        {
            limpiarDatosTransaccion();
            if (bGetfromdb)
            {
                CDOCTOD vData = new CDOCTOD();
                m_Docto = vData.seleccionarDOCTO(m_Docto, null);
            }

            if (!(bool)m_Docto.isnull["IID"])
            {
                if (!(bool)m_Docto.isnull["IFOLIO"])
                {
                    this.lblFolio.Text = m_Docto.IFOLIO.ToString();
                }
                if (!(bool)m_Docto.isnull["IFECHA"])
                {
                    this.lblFecha.Text = m_Docto.IFECHA.ToString("dd/MM/yyyy");
                }
                if (!(bool)m_Docto.isnull["ITOTAL"])
                {
                    this.lblTotal.Text = m_Docto.ITOTAL.ToString("N2");
                }

            }
        }

        private void TBTransacccion_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (TBTransacccion.Text.Trim() == "")
                {
                    SeleccionarTransaccion();
                }
                else
                {
                    rECEPCIONESORDENCOMPRAPORORDENDataGridView.Focus();
                }
            }
        }

        private void TBTransacccion_Validated(object sender, EventArgs e)
        {


            if (TBTransacccion.Text.Trim() == "")
            {
                limpiarDatosPersona();
                limpiarDatosTransaccion();
                this.dSEntradasAux.RECEPCIONESORDENCOMPRAPORORDEN.Clear();
                this.dSEntradasAux.DETALLERECEPCIONES.Clear();
            }
        }

        private void TBTransacccion_Validating(object sender, CancelEventArgs e)
        {


            if (TBTransacccion.Text.Trim() == "")
                return;

            int folio = 0;

            CDOCTOD vData = new CDOCTOD();
            if (int.TryParse(TBTransacccion.Text.Trim(), out folio))
            {
                m_Docto = new CDOCTOBE();
                m_Docto.IFOLIO = folio;
                m_Docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_ORDEN_COMPRA;
                m_Docto = vData.SeleccionarXTIPOYFOLIO(m_Docto, null);

                if (m_Docto != null)
                {

                    m_ClienteId = m_Docto.IPERSONAID;
                    llenarDatosPersona();
                    llenarDatosTransaccion(false);
                    LlenarGrid();
                }
                else
                {
                    MessageBox.Show("El registro no existe");

                    e.Cancel = true;
                }

            }
        }

        private void LlenarGrid()
        {
            try
            {
                this.rECEPCIONESORDENCOMPRAPORORDENTableAdapter.Fill(this.dSEntradasAux.RECEPCIONESORDENCOMPRAPORORDEN, (int)m_Docto.IID, m_Docto.IFECHA);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void LlenaDetalles(long doctoId)
        {
            try
            {
                this.dETALLERECEPCIONESTableAdapter.Fill(this.dSEntradasAux.DETALLERECEPCIONES, (int)doctoId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void rECEPCIONESORDENCOMPRAPORORDENDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex < 0)
                    return;

                long lDoctoId = long.Parse(rECEPCIONESORDENCOMPRAPORORDENDataGridView.Rows[e.RowIndex].Cells["DOCTOID"].Value.ToString());
                LlenaDetalles(lDoctoId);
            }
            catch
            {
            }
        }

        private void rECEPCIONESORDENCOMPRAPORORDENDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                if (rECEPCIONESORDENCOMPRAPORORDENDataGridView.Columns[e.ColumnIndex].Name == "DGIMPRIMIR")
                {
                    CUSUARIOSD usuariosD = new CUSUARIOSD();
                    Boolean usuarioTienePermisoDesgloseKit = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null);
                    long dgDoctoId = (long)rECEPCIONESORDENCOMPRAPORORDENDataGridView.Rows[e.RowIndex].Cells["DOCTOID"].Value;

                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                    dictionary.Add("pdoctoid", dgDoctoId);
                    dictionary.Add("usaDatosDeEntregaCuandoExista", "N");
                    dictionary.Add("desglosekits", usuarioTienePermisoDesgloseKit ? "S" : "N");
                    dictionary.Add("creadoPorUserId", 0);
                    string strReporte = "recibolargo.frx";


                    iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.deusuario), dictionary);
                    rp.ShowDialog();
                    rp.Dispose();
                    GC.SuppressFinalize(rp);
                }
            }
        }

    }
}
