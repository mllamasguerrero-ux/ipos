using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPosBusinessEntity;
using iPosData;
using System.Collections;
using FirebirdSql.Data.FirebirdClient;

namespace iPos.Movil
{
    public partial class WFBitacoraAddMovil : IposForm
    {
        long currentDoctoId = 0;
        

        public WFBitacoraAddMovil()
        {
            InitializeComponent();
        }

        




        private void btnGenerarBitacora_Click(object sender, EventArgs e)
        {

            if (this.COBRADORIDTextBox.Text == "")
            {
                MessageBox.Show("Seleccione un cobrador");
                return;
            }

            if(this.dSMovil4.VENTASCOBRANZAMOVIL.Rows.Count == 0)
            {

                MessageBox.Show("Por favor seleccione al menos un detalle");
                return;
            }


            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;

            try
            {


                fConn.Open();
                fTrans = fConn.BeginTransaction();

                CBITACOBRANZAD cobranzaD = new CBITACOBRANZAD();
                CBITACOBRANZABE cobranzaBE = new CBITACOBRANZABE();
                cobranzaBE.ICOBRADORID = Int64.Parse(this.COBRADORIDTextBox.DbValue.ToString());
                cobranzaBE.IFECHA = FECHATextBox.Value;

                long iResult = cobranzaD.BITACOBRANZAGENERAR(cobranzaBE, false,  fTrans);
                if (iResult == DBValues._ERRORCODE_BITACORA_YAEXISTE * -1)
                {
                    if (MessageBox.Show("Ya hay registros existentes para esa fecha. Desea generar uno nuevo ? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        iResult = cobranzaD.BITACOBRANZAGENERAR(cobranzaBE, true, fTrans);
                    }
                    else
                    {

                        fTrans.Rollback();
                        fConn.Close();
                        return;
                    }
                }

                if (iResult > 0)
                {
                    cobranzaBE.IID = iResult;
                    //m_cobranzaBE = cobranzaD.seleccionarBITACOBRANZA(cobranzaBE, null);
                    //bitId = iResult;
                    //opc = "Cambiar";
                    //ReCargar();


                    foreach (DSMovil4.VENTASCOBRANZAMOVILRow row in dSMovil4.VENTASCOBRANZAMOVIL)
                    {

                        CBITACOBRANZADETD cobranzaDETD = new CBITACOBRANZADETD();

                        CBITACOBRANZADETBE m_cobranzaDetBE = new CBITACOBRANZADETBE();
                        m_cobranzaDetBE.IBITCOBRANZAID = cobranzaBE.IID;
                        m_cobranzaDetBE.IFECHA = cobranzaBE.IFECHA;
                        m_cobranzaDetBE.ICOBRADORID = cobranzaBE.ICOBRADORID;
                        m_cobranzaDetBE.IESTADO = 1;

                        CDOCTOD vData = new CDOCTOD();
                        CDOCTOBE docto = new CDOCTOBE();
                        docto.IID = row.DOCTOID;
                        docto = vData.seleccionarDOCTO(docto, fTrans);

                        if (docto != null)
                        {

                            CPERSONAD personaD = new CPERSONAD();
                            CPERSONABE personaBE = new CPERSONABE();
                            personaBE.IID = docto.IPERSONAID;
                            personaBE = personaD.seleccionarPERSONA(personaBE, fTrans);

                            m_cobranzaDetBE.IDOCTOID = docto.IID;
                            m_cobranzaDetBE.IPERSONAID = docto.IPERSONAID;
                            m_cobranzaDetBE.ISALDO = docto.ISALDO;
                            m_cobranzaDetBE.IFECHAVENCE = docto.IVENCE;
                            m_cobranzaDetBE.IDIAPAGOS = personaBE.IPAGOS;


                            if (cobranzaDETD.BITACOBRANZAAGREGARDETALLE(m_cobranzaDetBE, fTrans) == null)
                            {
                                fTrans.Rollback();
                                fConn.Close();

                                MessageBox.Show("Error: " + cobranzaDETD.IComentario);
                                return;

                            }
                        }
                    }

                    MessageBox.Show("El registro se agrego con exito");

                    fTrans.Commit();
                    fConn.Close();

                    imprimirCobranza(cobranzaBE);

                    this.Close();
                }
                else
                {

                    fTrans.Rollback();
                    fConn.Close();
                    MessageBox.Show("Error: " + cobranzaD.IComentario);
                }
            }
            catch(Exception ex)
            {

            }


        }

        private void LlenarGrid()
        {
            try
            {

                string soloVencidos = CBSoloVencidos.Checked ? "S" : "N";
                int vendedorId = 0;
                try
                {
                    vendedorId = int.Parse(this.COBRADORIDTextBox.DbValue.ToString());

                }
                catch
                {
                    MessageBox.Show("Seleccione un vendedor valido");
                    return;
                }

                string sLunes = LUNESTextBox.Checked ? "S" : "N";
                string sMartes = MARTESTextBox.Checked ? "S" : "N";
                string sMiercoles = MIERCOLESTextBox.Checked ? "S" : "N";
                string sJueves = JUEVESTextBox.Checked ? "S" : "N";
                string sViernes = VIERNESTextBox.Checked ? "S" : "N";
                string sSabado = SABADOTextBox.Checked ? "S" : "N";
                string sDomingo = DOMINGOTextBox.Checked ? "S" : "N";


                this.vENTASCOBRANZAMOVILTableAdapter.Fill(this.dSMovil4.VENTASCOBRANZAMOVIL,soloVencidos, vendedorId, sLunes, sMartes, sMiercoles, sJueves, sViernes, sSabado, sDomingo);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }


        private void SeleccionarTransaccionPorDocto(CDOCTOBE docto)
        {

            CPERSONAD personaD = new CPERSONAD();
            CPERSONABE personaBE = new CPERSONABE();
            personaBE.IID = docto.IPERSONAID;
            personaBE = personaD.seleccionarPERSONA(personaBE, null);
            

            TBTransacccion.Text = docto.IFOLIO.ToString();

            llenarDatosPersona(personaBE);
            llenarDatosTransaccion(docto);

            currentDoctoId = docto.IID;

        }


        private void SeleccionarTransaccion()
        {

            int tipoDoctoParaLista = 0;

            WFSaldosListaTransacciones look = new WFSaldosListaTransacciones((int)DBValues._DOCTO_ESTATUS_COMPLETO, tipoDoctoParaLista);
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {



                CDOCTOBE docto = new CDOCTOBE();
                docto.IID = int.Parse(dr[0].ToString());
                CDOCTOD vData = new CDOCTOD();
                docto = vData.seleccionarDOCTO(docto, null);


                SeleccionarTransaccionPorDocto(docto);



            }
        }



        public void llenarDatosPersona(CPERSONABE personaBE)
        {
            limpiarDatosPersona();

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

            LBCliente.Text = "";
        }

        public void limpiarDatosTransaccion()
        {

            this.lblFolio.Text = "";
            this.lblFecha.Text = "";
            this.lblTotal.Text = "";
            this.lblSaldo.Text = "";
            this.lblFolioFacturado.Text = "";

            currentDoctoId = 0;

        }

        public void llenarDatosTransaccion(CDOCTOBE m_Docto)
        {
            limpiarDatosTransaccion();


            if (m_Docto != null && !(bool)m_Docto.isnull["IID"])
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
                if (!(bool)m_Docto.isnull["ISALDO"])
                {
                    this.lblSaldo.Text = m_Docto.ISALDO.ToString();
                }
                if (!(bool)m_Docto.isnull["IFOLIOORIGENFACTURADO"])
                {
                    this.lblFolioFacturado.Text = m_Docto.IFOLIOORIGENFACTURADO.ToString();
                }

            }
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if ( TBTransacccion.Text.Trim().Length > 0)
            {

                DSMovil4.VENTASCOBRANZAMOVILRow newRow = this.dSMovil4.VENTASCOBRANZAMOVIL.NewVENTASCOBRANZAMOVILRow();
                //newRow.CLIENTEAPELLIDOS

                bool contains = this.dSMovil4.VENTASCOBRANZAMOVIL.AsEnumerable().Any(row => row.RowState != DataRowState.Deleted && currentDoctoId == row.Field<long>("DOCTOID"));


                if (!contains)
                {
                    try
                    {
                        this.iNDIVIDUAL_COBRANZATableAdapter.Fill(this.dSMovil4.INDIVIDUAL_COBRANZA, (int)currentDoctoId);
                        if (this.dSMovil4.INDIVIDUAL_COBRANZA.Count > 0)
                        {
                            AppendIndividualCobranzaToVENTASCOBRANZAMOVIL();
                            limpiarDatosPersona();
                            limpiarDatosTransaccion();
                        }

                    }
                    catch (System.Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("La transaccion ya esta agregada");
                }



            }
        }

        public void AppendIndividualCobranzaToVENTASCOBRANZAMOVIL()
        {

            DataTable dtSource = this.dSMovil4.INDIVIDUAL_COBRANZA;
            DataTable dtDestination = this.dSMovil4.VENTASCOBRANZAMOVIL;
            

            if (dtSource.Rows.Count > 0)
            {
                // cloned to get the structure of source

                for (int i = 0; i < dtSource.Rows.Count; i++)
                {
                    dtDestination.ImportRow(dtSource.Rows[i]);
                }
            }
        }


        private void bITACOBRANZADETDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {

                if (bITACOBRANZADETDataGridView.Columns[e.ColumnIndex].Name == "DGELIMINAR")
                {

                    //if (MessageBox.Show("Realmente quiere eliminar el detalle de la bitacora?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //{
                        DataRow row = ((DataRowView)bITACOBRANZADETDataGridView.CurrentRow.DataBoundItem).Row ;
                        row.Delete();
                    //}

                }
            }
        }

        

        private void WFBitacoraAddMovil_Load(object sender, EventArgs e)
        {
            
        }
        

        private void BtnListaTransacciones_Click(object sender, EventArgs e)
        {
            SeleccionarTransaccion();
        }

        private void TBTransacccion_Validating(object sender, CancelEventArgs e)
        {

            if (TBTransacccion.Text.Trim() == "")
                return;

            int folio = 0;
            currentDoctoId = 0;

            CDOCTOD vData = new CDOCTOD();
            if (int.TryParse(TBTransacccion.Text.Trim(), out folio))
            {


                CDOCTOBE docto = new CDOCTOBE();
                docto.IFOLIO = folio;
                docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_VENTA;
                docto = vData.SeleccionarXTIPOYFOLIO(docto, null);

                if (docto != null)
                {

                    this.SeleccionarTransaccionPorDocto(docto);
                }
                else
                {

                    MessageBox.Show("El registro no existe " + vData.IComentario);

                    e.Cancel = true;
                }

            }

        }

        private void TBTransacccion_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void TBTransacccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TBTransacccion.Text.Trim() == "")
                {
                    SeleccionarTransaccion();
                }
                else
                {
                    btnAddDetail.Focus();
                }
            }
        }

        private void imprimirCobranza(CBITACOBRANZABE cobranzaBE)
        {
            if (cobranzaBE != null && cobranzaBE.IID != 0)
            {

                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("pbitacoracobranzaid", cobranzaBE.IID);

                string strReporte = "BitacoraCobranza.frx";

                iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
                rp.ShowDialog();
                rp.Dispose();
                GC.SuppressFinalize(rp);
            }
        }

       
        
        

        private void btnEnlistarVentasConSaldo_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        
    }
}
