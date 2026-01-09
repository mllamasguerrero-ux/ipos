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
using FirebirdSql.Data.FirebirdClient;
using FlatTabControl;
using iPosReporting;

namespace iPos
{
    public partial class WFContraRecibos : IposForm
    {

        CCONTRARECIBOHDRBE m_contrarecibo = new CCONTRARECIBOHDRBE();

        public long m_PersonaId = 0;

        public WFContraRecibos()
        {
            InitializeComponent();
        }



        public WFContraRecibos(long contrareciboid):this()
        {
            m_contrarecibo = new CCONTRARECIBOHDRBE();
            m_contrarecibo.IID = contrareciboid;
        }

        private void BTCliente_Click(object sender, EventArgs e)
        {
            iPos.Catalogos.WFClientes look = new iPos.Catalogos.WFClientes();
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                this.LBCliente.Text = dr["CLAVE"].ToString().Trim();
                m_PersonaId = (long)dr["ID"];

                llenarDatosPersona();
            }
        }



        public void llenarDatosPersona()
        {
            CPERSONAD clienteD = new CPERSONAD();
            CPERSONABE clienteBE = new CPERSONABE();
            clienteBE.IID = m_PersonaId;
            clienteBE = clienteD.seleccionarPERSONA(clienteBE, null);
            if (clienteBE != null)
            {

                lbClieCiudad.Text = ((bool)clienteBE.isnull["ICIUDAD"]) ? "" : clienteBE.ICIUDAD;
                lbClieColonia.Text = ((bool)clienteBE.isnull["ICOLONIA"]) ? "" : clienteBE.ICOLONIA;
                lbClieCP.Text = ((bool)clienteBE.isnull["ICODIGOPOSTAL"]) ? "" : clienteBE.ICODIGOPOSTAL;
                lbClieDom.Text = ((bool)clienteBE.isnull["IDOMICILIO"]) ? "" : clienteBE.IDOMICILIO;
                lbClieEstado.Text = ((bool)clienteBE.isnull["IESTADO"]) ? "" : clienteBE.IESTADO;
                lbClieNombre.Text = ((bool)clienteBE.isnull["INOMBRE"]) ? "" : clienteBE.INOMBRE;
                lbClieRFC.Text = ((bool)clienteBE.isnull["IRFC"]) ? "" : clienteBE.IRFC;
                lbClieTel.Text = ((bool)clienteBE.isnull["ITELEFONO1"]) ? "" : clienteBE.ITELEFONO1;

                LBCliente.Text = clienteBE.ICLAVE;

            }
            else
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

            //LlenaGrid();
            //this.tRANSACCIONES_LISTA_CONSALDOSTableAdapter.Fill(this.dSPuntoDeVentaAux.TRANSACCIONES_LISTA_CONSALDOS, this.m_tipodoctoId, this.m_statusdocto, "N", 0, clienteBE.IID, DateTime.Parse("1980-01-01"));

        }

        private void BtnListaTransacciones_Click(object sender, EventArgs e)
        {
            SeleccionarTransaccion();
        }


        private void AgregarListDocto(List<long> listId )
        {
            CCONTRARECIBOHDRD contrareciboD = new CCONTRARECIBOHDRD();
            CCONTRARECIBODTLD contrareciboDtlD = new CCONTRARECIBODTLD();
            CDOCTOD doctoD = new CDOCTOD();

            if (listId != null && listId.Count > 0)
            {

                if (m_contrarecibo == null /*|| m_contrarecibo.IID == null*/ || m_contrarecibo.IID == 0)
                {


                    CCONTRARECIBOHDRBE contrareciboBE = new CCONTRARECIBOHDRBE();
                    contrareciboBE.IPERSONAID = m_PersonaId;
                    contrareciboBE.IVENDEDORID = CurrentUserID.CurrentUser.IID;
                    contrareciboBE.IFECHA = DateTime.Today;
                    contrareciboBE.IOBSERVACIONES = TBNota.Text;
                    contrareciboBE.IESTATUSID = DBValues._DOCTO_ESTATUS_BORRADOR;

                    if (this.ESTATUSPAGOIDTextBox.Text != "")
                    {
                        contrareciboBE.IESTATUSPAGOID = long.Parse(this.ESTATUSPAGOIDTextBox.SelectedValue.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Debe especificar un estatus de pago");
                        return;
                    }


                    long contrareciboId = 0;

                    bool res = contrareciboD.CONTRARECIBO_INSERT(contrareciboBE, ref contrareciboId, null);
                    if (res)
                    {
                        contrareciboBE.IID = contrareciboId;
                        m_contrarecibo = contrareciboBE;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el header de contrarecibo " + contrareciboD.IComentario);
                        return;
                    }
                }

                foreach (long doctoId in listId)
                {

                    CCONTRARECIBODTLBE contrareciboDtlBE = new CCONTRARECIBODTLBE();
                    CDOCTOBE doctoBE = new CDOCTOBE();

                    doctoBE.IID = doctoId;
                    doctoBE = doctoD.seleccionarDOCTO(doctoBE, null);

                    if (doctoBE != null)
                    {
                        contrareciboDtlBE.IDOCTOID = doctoBE.IID;
                        contrareciboDtlBE.IESTATUSID = DBValues._DOCTO_ESTATUS_BORRADOR;
                        contrareciboDtlBE.IFOLIO = doctoBE.IFOLIO;
                        contrareciboDtlBE.IFOLIOSAT = doctoBE.IFOLIOSAT;
                        contrareciboDtlBE.ISERIE = doctoBE.ISERIE;
                        contrareciboDtlBE.ISERIESAT = doctoBE.ISERIESAT;
                        contrareciboDtlBE.ITOTALDOCTO = doctoBE.ITOTAL;
                        contrareciboDtlBE.IABONODOCTO = doctoBE.IABONO;
                        contrareciboDtlBE.ISALDODOCTO = doctoBE.ISALDO;
                        contrareciboDtlBE.ITOTAL = doctoBE.ISALDO;
                        contrareciboDtlBE.IABONO = 0;
                        contrareciboDtlBE.ISALDO = doctoBE.ISALDO;
                        contrareciboDtlBE.IFECHA = doctoBE.IFECHA;
                        contrareciboDtlBE.IFECHAVENCE = doctoBE.IVENCE;

                        long contrareciboDtlId = 0;
                        long contrareciboId = 0;
                        bool res = contrareciboDtlD.CONTRARECIBODETAIL_INSERT(contrareciboDtlBE, m_contrarecibo, ref contrareciboId, ref contrareciboDtlId, null);
                        if (!res)
                        {

                            MessageBox.Show("No se pudo agregar el detalle de contrarecibo " + contrareciboDtlD.IComentario);
                            return;
                        }

                    }

                }

                setEstatusBotones();
                this.ObtenerTotal();
                LlenarGrid();


            }
        }


        private void SeleccionarTransaccion()
        {

            if (m_PersonaId != 0)
            {

                WFRecibosListaTransacciones look = new WFRecibosListaTransacciones((int)DBValues._DOCTO_ESTATUS_COMPLETO, 0, m_PersonaId);
                look.ShowDialog();

                List<long> listId = look.m_selectedTransactions;
                AgregarListDocto(listId );

                look.Dispose();
                GC.SuppressFinalize(look);


            }
        }

        private void LlenarGrid()
        {
            try
            {
                if (m_contrarecibo != null && m_contrarecibo.IID != 0 /*null*/)
                {

                    this.cONTRARECIBODTLTableAdapter.Fill(this.dSCobranza.CONTRARECIBODTL, (int)m_contrarecibo.IID);
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void cONTRARECIBODTLDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                if (cONTRARECIBODTLDataGridView.Columns[e.ColumnIndex].Name == "DGELIMINAR")
                {

                    if (m_contrarecibo != null && m_contrarecibo.IESTATUSID == 0 && m_contrarecibo.IID != 0)
                    {
                        if (MessageBox.Show("Realmente desea eliminar este detalle del contrarecibo ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            long dtlId = long.Parse(cONTRARECIBODTLDataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());

                            CCONTRARECIBODTLD contrareciboDtlD = new CCONTRARECIBODTLD();
                            CCONTRARECIBODTLBE contrareciboDtlBE = new CCONTRARECIBODTLBE();
                            contrareciboDtlBE.IID = dtlId;
                            if (!contrareciboDtlD.CONTRARECIBODETAIL_DELETE(contrareciboDtlBE, null))
                            {

                                MessageBox.Show("No se pudo eliminar el detalle de contrarecibo " + contrareciboDtlD.IComentario);
                                return;
                            }

                            this.ObtenerTotal();
                            LlenarGrid();


                        }
                    }
                }
            }
        }

        private void BTGUARDAR_Click(object sender, EventArgs e)
        {
            if(m_contrarecibo != null && m_contrarecibo.IESTATUSID == 0 && m_contrarecibo.IID != 0)
            {
                m_contrarecibo.IOBSERVACIONES = TBNota.Text;

                if (this.ESTATUSPAGOIDTextBox.Text != "")
                {
                    m_contrarecibo.IESTATUSPAGOID = long.Parse(this.ESTATUSPAGOIDTextBox.SelectedValue.ToString());
                }
                else
                {
                    MessageBox.Show("Debe especificar un estatus de pago");
                    return;
                }

                if (MessageBox.Show("Esta seguro que ya quiere registrar el contrarecibo ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CCONTRARECIBOHDRD contrareciboHdrD = new CCONTRARECIBOHDRD();
                    if (!contrareciboHdrD.CONTRARECIBOHEADER_SAVE(m_contrarecibo, null))
                    {

                        MessageBox.Show("No se pudo registrar el header de contrarecibo " + contrareciboHdrD.IComentario);
                        return;
                    }

                    m_contrarecibo.IESTATUSID = 1;
                    Imprimir();
                    this.Close();
                }
            }
        }

        private void BTCancelar_Click(object sender, EventArgs e)
        {

            if (m_contrarecibo != null && m_contrarecibo.IESTATUSID < 2 && m_contrarecibo.IID != 0)
            {

                if (MessageBox.Show("Esta seguro que quiere eliminar el contrarecibo ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CCONTRARECIBOHDRD contrareciboHdrD = new CCONTRARECIBOHDRD();

                    if(m_contrarecibo.IESTATUSID == 0)
                    {

                        if (!contrareciboHdrD.CONTRARECIBOHEADER_DELETE(m_contrarecibo, null))
                        {

                            MessageBox.Show("No se pudo eliminar el header de contrarecibo " + contrareciboHdrD.IComentario);
                            return;
                        }
                        PrepararNuevaEntrada();
                        this.Close();
                    }
                    else if (m_contrarecibo.IESTATUSID == 1)
                    {

                        if (!contrareciboHdrD.CONTRARECIBOHEADER_CANCEL(m_contrarecibo, null))
                        {

                            MessageBox.Show("No se pudo eliminar el header de contrarecibo " + contrareciboHdrD.IComentario);
                            return;
                        }
                        PrepararNuevaEntrada();
                        this.Close();
                    }

                }
            }
        }


        private void PrepararNuevaEntrada()
        {
            
            m_contrarecibo = new CCONTRARECIBOHDRBE();
            m_PersonaId = 0;
            this.dSCobranza.CONTRARECIBODTL.Clear();
            TBNota.Text = "";
            LBCliente.Text = "";

            lbClieCiudad.Text = "";
            lbClieColonia.Text = "";
            lbClieCP.Text = "";
            lbClieDom.Text = "";
            lbClieEstado.Text = "";
            lbClieNombre.Text = "";
            lbClieRFC.Text = "";
            lbClieTel.Text = "";

        }


        private void ObtenerTotal()
        {

            if (m_contrarecibo != null && m_contrarecibo.IID != 0)
            {
                CCONTRARECIBOHDRD contrareciboD = new CCONTRARECIBOHDRD();
                CCONTRARECIBOHDRBE contrareciboBE = new CCONTRARECIBOHDRBE();
                contrareciboBE.IID = m_contrarecibo.IID;

                contrareciboBE = contrareciboD.seleccionarCONTRARECIBOHDR(contrareciboBE, null);
                if (contrareciboBE != null)
                {
                    m_contrarecibo.ITOTAL = contrareciboBE.ITOTAL;
                    LBTotal.Text = m_contrarecibo.ITOTAL.ToString("N2");
                }
            }
        }

        private void ObtenerDatosDeBase()
        {
            if (m_contrarecibo != null && m_contrarecibo.IID != 0)
            {
                CCONTRARECIBOHDRD contrareciboD = new CCONTRARECIBOHDRD();
                CCONTRARECIBOHDRBE contrareciboBE = new CCONTRARECIBOHDRBE();
                contrareciboBE.IID = m_contrarecibo.IID;

                contrareciboBE = contrareciboD.seleccionarCONTRARECIBOHDR(contrareciboBE, null);
                if(contrareciboBE != null)
                {
                    m_contrarecibo = contrareciboBE;
                    m_PersonaId = m_contrarecibo.IPERSONAID;
                    TBNota.Text = m_contrarecibo.IOBSERVACIONES;

                    if (!(bool)m_contrarecibo.isnull["IESTATUSPAGOID"])
                    {
                        this.ESTATUSPAGOIDTextBox.SelectedDataValue = m_contrarecibo.IESTATUSPAGOID.ToString();
                    }
                    else
                    {
                        ESTATUSPAGOIDTextBox.SelectedIndex = -1;
                    }


                    llenarDatosPersona();

                    LBTotal.Text = m_contrarecibo.ITOTAL.ToString("N2");


                    LlenarGrid();
                }
            }
        }


        private void setEstatusBotones()
        {
            if(m_contrarecibo != null && m_contrarecibo.IESTATUSID == 0 )
            {
                btnCambiarEstatusPago.Enabled = true;
                BtnListaTransacciones.Enabled = true;
                btnImprimir.Enabled = false;
                TBNota.Enabled = true;
                TBTransacccion.Enabled = true;
                if(m_contrarecibo.IID != 0)
                {
                    BTGUARDAR.Enabled = true;
                    BTCancelar.Enabled = true;
                    BTCliente.Enabled = false;
                    
                }
                else
                {
                    btnCambiarEstatusPago.Enabled = false;
                    BTCancelar.Enabled = false;
                    BTCliente.Enabled = false;
                    BTCliente.Enabled = true;
                }
            }
            else if(m_contrarecibo != null && m_contrarecibo.IESTATUSID == 0 )
            {

                TBNota.Enabled = false;
                TBTransacccion.Enabled = false;
                BtnListaTransacciones.Enabled = false;
                btnImprimir.Enabled = true;
                BTGUARDAR.Enabled = false;
                BTCancelar.Enabled = true;
                BTCliente.Enabled = false;
                cONTRARECIBODTLDataGridView.ReadOnly = true;
            }
            else if(m_contrarecibo != null && m_contrarecibo.IESTATUSID == 2 )
            {

                TBNota.Enabled = false;
                TBTransacccion.Enabled = false;
                BtnListaTransacciones.Enabled = false;
                btnImprimir.Enabled = false;
                BTGUARDAR.Enabled = false;
                BTCancelar.Enabled = false;
                BTCliente.Enabled = false;
                cONTRARECIBODTLDataGridView.ReadOnly = true;
            }
        }

        private void WFContraRecibos_Load(object sender, EventArgs e)
        {

            ESTATUSPAGOIDTextBox.llenarDatos();
            this.ESTATUSPAGOIDTextBox.SelectedDataValue = DBValues._CONTRARECIBO_ESTATUSPAGO_SINPAGAR.ToString();

            if (m_contrarecibo != null && m_contrarecibo.IID != 0)
            {
                ObtenerDatosDeBase();
            }
            setEstatusBotones();

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Imprimir();
        }


        private void Imprimir()
        {
            if (m_contrarecibo != null && m_contrarecibo.IID != 0)
            {

                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("pcontrareciboid", m_contrarecibo.IID);

                string strReporte = "ContraRecibo.frx";

                iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
                rp.ShowDialog();
                rp.Dispose();
                GC.SuppressFinalize(rp);
            }

        }


        private bool bRefocusTransaccion = false;
        private void TBTransacccion_Validating(object sender, CancelEventArgs e)
        {
            if (TBTransacccion.Text.Trim() == "")
                return;

            if(this.m_PersonaId == 0)
            {
                MessageBox.Show("Seleccione primero el cliente");
                return;
            }

            int folio = 0;

            CDOCTOD vData = new CDOCTOD();
            CDOCTOBE m_Docto = new CDOCTOBE();
            CCONTRARECIBODTLD contrareciboD = new CCONTRARECIBODTLD();

            if (int.TryParse(TBTransacccion.Text.Trim(), out folio))
            {
                m_Docto = new CDOCTOBE();
                m_Docto.IFOLIO = folio;
                m_Docto.ITIPODOCTOID = 21;
                m_Docto = vData.SeleccionarXTIPOYFOLIO(m_Docto, null);

                if (m_Docto != null)
                {

                    if(m_Docto.ICONTRARECIBOID > 0)
                    {

                        MessageBox.Show("El folio ya se agrego en otro contrarecibo, una transaccion solo puede estar relacionada a un contrarecibo");
                        e.Cancel = true;
                        return;
                    }

                    if(m_Docto.IPERSONAID == this.m_PersonaId)
                    {
                        List<long> listId = new List<long>();
                        listId.Add(m_Docto.IID);
                        AgregarListDocto(listId);
                        bRefocusTransaccion = true;
                    }
                    
                }
                else
                {
                    MessageBox.Show("El registro no existe o no corresponde al cliente seleccionado");
                    e.Cancel = true;
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
                    this.cONTRARECIBODTLDataGridView.Focus();
                }
            }
        }

        private void TBTransacccion_Validated(object sender, EventArgs e)
        {
            if (bRefocusTransaccion)
            {
                TBTransacccion.Text = "";
                TBTransacccion.Focus();
                bRefocusTransaccion = false;
            }
        }

        private void btnCambiarEstatusPago_Click(object sender, EventArgs e)
        {

            if (m_contrarecibo != null && m_contrarecibo.IESTATUSID < 2 && m_contrarecibo.IID != 0)
            {

                CCONTRARECIBOHDRD contrareciboHdrD = new CCONTRARECIBOHDRD();

                if (this.ESTATUSPAGOIDTextBox.Text != "")
                {
                    m_contrarecibo.IESTATUSPAGOID = long.Parse(this.ESTATUSPAGOIDTextBox.SelectedValue.ToString());
                }
                else
                {
                    MessageBox.Show("Debe especificar un estatus de pago");
                    return;
                }
                if (!contrareciboHdrD.CambiarEstatusPagoCONTRARECIBOHDRD(m_contrarecibo, m_contrarecibo, null))
                    {

                        MessageBox.Show("No se pudo cambiar el estatus de pago de contrarecibo " + contrareciboHdrD.IComentario);
                        return;
                    }
                MessageBox.Show("Se ha cambiado el estatus de pago");
            }
        }
    }
}
