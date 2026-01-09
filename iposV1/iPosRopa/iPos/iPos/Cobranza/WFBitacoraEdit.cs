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

namespace iPos.Cobranza
{
    public partial class WFBitacoraEdit : IposForm
    {
        CBITACOBRANZABE m_cobranzaBE = null;
        CBITACOBRANZADETBE m_cobranzaDetBE = null;

        public string opc;
        public long bitId = 0;

        public WFBitacoraEdit()
        {
            InitializeComponent();
            opc = "Agregar";
        }

        public WFBitacoraEdit(string popc, long pbitId)
            : this()
        {
            opc = popc;
            bitId = pbitId;
        }





        private void btnGenerarBitacora_Click(object sender, EventArgs e)
        {

            if (this.COBRADORIDTextBox.Text == "")
            {
                MessageBox.Show("Seleccione un cobrador");
                return;
            }

            CBITACOBRANZAD cobranzaD = new CBITACOBRANZAD();
            CBITACOBRANZABE cobranzaBE = new CBITACOBRANZABE();
            cobranzaBE.ICOBRADORID = Int64.Parse(this.COBRADORIDTextBox.DbValue.ToString());
            cobranzaBE.IFECHA = FECHATextBox.Value;
            cobranzaBE.INOTARECEPCION = NOTARECEPCIONTextBox.Text;

            long iResult = cobranzaD.BITACOBRANZAGENERAR(cobranzaBE, false,  null);
            if (iResult == DBValues._ERRORCODE_BITACORA_YAEXISTE * -1)
            {
                if (MessageBox.Show("Ya hay registros existentes para esa fecha. Desea generar uno nuevo ? ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    iResult = cobranzaD.BITACOBRANZAGENERAR(cobranzaBE, true, null);
                }
            }

            if (iResult > 0)
            {
                //cobranzaBE.IID = iResult;
                //m_cobranzaBE = cobranzaD.seleccionarBITACOBRANZA(cobranzaBE, null);
                bitId = iResult;
                opc = "Cambiar";
                ReCargar();
                MessageBox.Show("El registro se agrego con exito");
            }
            else
            {
                MessageBox.Show("Error: " + cobranzaD.IComentario);
            }

        }

        private void LlenarGrid()
        {
            try
            {
                if (m_cobranzaBE == null || m_cobranzaBE.IID == 0)
                    return;

                this.bITACOBRANZADETTableAdapter.Fill(this.dSCobranza.BITACOBRANZADET, (int)m_cobranzaBE.IID);
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

            m_cobranzaDetBE.IDOCTOID = docto.IID;
            m_cobranzaDetBE.IPERSONAID = docto.IPERSONAID;
            m_cobranzaDetBE.ISALDO = docto.ISALDO;
            m_cobranzaDetBE.IFECHAVENCE = docto.IVENCE;
            m_cobranzaDetBE.IDIAPAGOS = personaBE.IPAGOS;

            TBTransacccion.Text = docto.IFOLIO.ToString();

            llenarDatosPersona(personaBE);
            llenarDatosTransaccion(docto);

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
                m_cobranzaDetBE = new CBITACOBRANZADETBE();
                m_cobranzaDetBE.IBITCOBRANZAID = m_cobranzaBE.IID;
                m_cobranzaDetBE.IFECHA = m_cobranzaBE.IFECHA;
                m_cobranzaDetBE.ICOBRADORID = m_cobranzaBE.ICOBRADORID;
                m_cobranzaDetBE.IESTADO = 1;



                CDOCTOBE docto = new CDOCTOBE();
                docto.IID = int.Parse(dr[0].ToString());
                CDOCTOD vData = new CDOCTOD();
                docto = vData.seleccionarDOCTO(docto, null);


                SeleccionarTransaccionPorDocto(docto);
                /*CPERSONAD personaD = new CPERSONAD();
                CPERSONABE personaBE = new CPERSONABE();
                personaBE.IID = docto.IPERSONAID;
                personaBE = personaD.seleccionarPERSONA(personaBE, null);

                m_cobranzaDetBE.IDOCTOID = docto.IID;
                m_cobranzaDetBE.IPERSONAID = docto.IPERSONAID;
                m_cobranzaDetBE.ISALDO = docto.ISALDO;
                m_cobranzaDetBE.IFECHAVENCE = docto.IVENCE;
                m_cobranzaDetBE.IDIAPAGOS = personaBE.IPAGOS;

                TBTransacccion.Text = docto.IFOLIO.ToString();

                llenarDatosPersona(personaBE);
                llenarDatosTransaccion(docto);*/



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
        }

        public void limpiarDatosTransaccion()
        {

            this.lblFolio.Text = "";
            this.lblFecha.Text = "";
            this.lblTotal.Text = "";
            this.lblSaldo.Text = "";
            this.lblFolioFacturado.Text = "";

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
            if (m_cobranzaDetBE != null && TBTransacccion.Text.Trim().Length > 0)
            {


                CBITACOBRANZADETD cobranzaDETD = new CBITACOBRANZADETD();
                if (cobranzaDETD.BITACOBRANZAAGREGARDETALLE(m_cobranzaDetBE, null) != null)
                {
                    LlenarGrid();
                    LBCliente.Text = "";
                    TBTransacccion.Text = "";
                    limpiarDatosPersona();
                    limpiarDatosTransaccion();
                    MessageBox.Show("Se agrego el registro");
                    TBTransacccion.Focus();
                }
                else
                {
                    MessageBox.Show("Ocurrio un eror al agregar el registro");
                    return;
                }

                m_cobranzaDetBE = null;
            }
        }

        private void bITACOBRANZADETDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {

                if (bITACOBRANZADETDataGridView.Columns[e.ColumnIndex].Name == "DGELIMINAR")
                {

                    if (MessageBox.Show("Realmente quiere eliminar el detalle de la bitacora?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        long BID = long.Parse(bITACOBRANZADETDataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                        CBITACOBRANZADETD cobranzaDETD = new CBITACOBRANZADETD();
                        CBITACOBRANZADETBE cobranzaDETBE = new CBITACOBRANZADETBE();
                        cobranzaDETBE.IID = BID;
                        if (cobranzaDETD.BITACOBRANZAELIMINARDETALLE(cobranzaDETBE, null))
                        {

                            LlenarGrid();
                            MessageBox.Show("Se elimino el registro");
                        }
                        else
                        {
                            MessageBox.Show("Ocurrio un error y no se pudo eliminar el registro");
                        }
                    }

                }
            }
        }


        public void ReCargar()
        {

            if (this.opc != "Agregar" && this.opc != "")
            {
                btnGenerarBitacora.Visible = false;
                NOTARECEPCIONTextBox.Enabled = false;
                if (this.opc == "Consultar")
                {
                    this.pnlAddVenta.Visible = false;
                    this.bITACOBRANZADETDataGridView.Columns["DGELIMINAR"].Visible = false;
                    this.bITACOBRANZADETDataGridView.Columns["DGRECIBIR"].Visible = false;
                    btnRecibir.Visible = false;

                }
                else if (this.opc == "Recibir")
                {
                    this.pnlAddVenta.Visible = false;
                    this.NOTARECEPCIONTextBox.Enabled = true;
                    this.bITACOBRANZADETDataGridView.Columns["DGELIMINAR"].Visible = false;
                    this.bITACOBRANZADETDataGridView.Columns["DGRECIBIR"].Visible = true;
                    btnRecibir.Visible = true;
                }
                else
                {
                    this.pnlAddVenta.Visible = true;
                    this.bITACOBRANZADETDataGridView.Columns["DGELIMINAR"].Visible = true;
                    this.bITACOBRANZADETDataGridView.Columns["DGRECIBIR"].Visible = false;
                    btnRecibir.Visible = false;
                }
                LlenarDatosDeBase();
                this.FECHATextBox.Enabled = false;
                this.COBRADORIDTextBox.Enabled = false;
            }

            else if (this.opc == "Agregar")
            {
                btnGenerarBitacora.Visible = true;
                this.pnlAddVenta.Visible = false;
                this.FECHATextBox.Enabled = true;
                this.COBRADORIDTextBox.Enabled = true;
                this.bITACOBRANZADETDataGridView.Columns["DGELIMINAR"].Visible = false;
            }
        }

        private void WFBitacoraEdit_Load(object sender, EventArgs e)
        {

            ESTADOTextBox.llenarDatos();
            ReCargar();
        }

        public void LlenarDatosDeBase()
        {
            if (bitId != 0)
            {
                CBITACOBRANZABE bitCobranzaBE = new CBITACOBRANZABE();
                CBITACOBRANZAD bitCobranzaD = new CBITACOBRANZAD();
                bitCobranzaBE.IID = bitId;
                bitCobranzaBE = bitCobranzaD.seleccionarBITACOBRANZA(bitCobranzaBE, null);

                if (bitCobranzaBE != null)
                {
                    m_cobranzaBE = bitCobranzaBE;
                    FECHATextBox.Value = bitCobranzaBE.IFECHA;
                    string strBuffer = "";
                    if (!(bool)bitCobranzaBE.isnull["ICOBRADORID"])
                    {
                        this.COBRADORIDTextBox.DbValue = bitCobranzaBE.ICOBRADORID.ToString();
                        this.COBRADORIDTextBox.MostrarErrores = false;
                        this.COBRADORIDTextBox.MValidarEntrada(out strBuffer, 1);
                        this.COBRADORIDTextBox.MostrarErrores = true;
                    }
                    else
                    {
                        this.COBRADORIDTextBox.Text = "";
                    }

                    if (!(bool)bitCobranzaBE.isnull["IESTADO"])
                    {
                        this.ESTADOTextBox.SelectedDataDisplaying = bitCobranzaBE.IESTADO.ToString();
                    }
                    else
                    {
                        this.ESTADOTextBox.Text = "";
                    }

                    this.NOTARECEPCIONTextBox.Text = (bool)bitCobranzaBE.isnull["INOTARECEPCION"] ? "" : bitCobranzaBE.INOTARECEPCION;


                    LlenarGrid();
                    limpiarDatosPersona();
                    limpiarDatosTransaccion();
                }
            }
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

            CDOCTOD vData = new CDOCTOD();
            if (int.TryParse(TBTransacccion.Text.Trim(), out folio))
            {

                m_cobranzaDetBE = new CBITACOBRANZADETBE();
                m_cobranzaDetBE.IBITCOBRANZAID = m_cobranzaBE.IID;
                m_cobranzaDetBE.IFECHA = m_cobranzaBE.IFECHA;
                m_cobranzaDetBE.ICOBRADORID = m_cobranzaBE.ICOBRADORID;
                m_cobranzaDetBE.IESTADO = 1;


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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (m_cobranzaBE != null && m_cobranzaBE.IID != 0)
            {

                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("pbitacoracobranzaid", m_cobranzaBE.IID);

                string strReporte = "BitacoraCobranza.frx";

                iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
                rp.ShowDialog();
                rp.Dispose();
                GC.SuppressFinalize(rp);
            }
        }

        private void btnRecibir_Click(object sender, EventArgs e)
        {
                    FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                    FbTransaction fTrans = null;
                    try
                    {

                        fConn.Open();
                        fTrans = fConn.BeginTransaction();


                        string strComentario = "";
                        //ante cualquier return o error
                        if(!SaveChangesRecibidos(fTrans, ref strComentario))
                       {
                            fTrans.Rollback();
                            fConn.Close();

                            MessageBox.Show("Algo salio mal, no se pudo recibir la bitacora(S)" +  strComentario);
                            //comentario = "Error tal " ;
                           // bError = true;
                            return;
                       }

                      
                        //en caso de exito
                        fTrans.Commit();
                        fConn.Close();
                        this.Close();
                    }
                    catch
                    {
                        try
                        {
                            fTrans.Rollback();
                        }
                        catch { }

                        fConn.Close();
                    }
                    finally
                    {
                        fConn.Close();
                    }

        }

        public Boolean SaveChangesRecibidos(FbTransaction fTrans, ref string comentario)
        {
            /* CUSUARIO_PERFILBE oUPerBe = new CUSUARIO_PERFILBE();
             CUSUARIO_PERFILD oUPerD = new CUSUARIO_PERFILD();
             if (iUserId == -1)
             {
                 return false;
             }*/
            CBITACOBRANZAD cbitad = new CBITACOBRANZAD();
            try
            {

                
                CBITACOBRANZABE bitacoraCobranzaBE = new CBITACOBRANZABE();
                bitacoraCobranzaBE.IID = bitId;
                bitacoraCobranzaBE.INOTARECEPCION = NOTARECEPCIONTextBox.Text;

                if (!cbitad.CambiarBITACOBRANZA_NOTARECEPCION(bitacoraCobranzaBE, bitacoraCobranzaBE, null))
                {

                    MessageBox.Show("Ocurrio un error " + cbitad.IComentario);
                    return false;
                }

                /* oUPerBe.IUP_PERSONAID = iUserId;
                 oUPerD.BorrarPerfilesDeUsuario(oUPerBe, fTrans);*/
                foreach (DataGridViewRow dataRow in this.bITACOBRANZADETDataGridView.Rows)
                {
                    if (
                        dataRow.Cells["DGRECIBIR"].Value != null
                        && dataRow.Cells["DGRECIBIR"].Value != DBNull.Value
                        && ((int)dataRow.Cells["DGRECIBIR"].Value == 1))
                    {
                        cbitad.BITACORACOBRANZADET_RECIBIR((long)dataRow.Cells["DGID"].Value, bitId, DBValues._ESTADO_COBRANZA_TERMINADA, (long)CurrentUserID.CurrentUser.IID, fTrans);
                        
                    }
                    else
                    {
                        cbitad.BITACORACOBRANZADET_RECIBIR((long)dataRow.Cells["DGID"].Value, bitId, DBValues._ESTADO_COBRANZA_ENPROCESO, (long)CurrentUserID.CurrentUser.IID, fTrans);
                        
                    }
                }
            }
            catch (Exception ex)
            {

                comentario = ex.Message;
                return false;
            }
            return true;
        }

    }
}
