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
using iPosReporting;

namespace iPos.Guia
{
    public partial class WFGuiasEdicion : Form
    {

        CGUIABE m_guiaBE = null;
        CGUIADETALLEBE m_guiaDetBE = null;

        public string opc;
        public long guiaId = 0;

        public WFGuiasEdicion()
        {
            InitializeComponent();
            opc = "Agregar";
            m_guiaBE = new CGUIABE();
            m_guiaDetBE = new CGUIADETALLEBE();
        }


        public WFGuiasEdicion(string popc, long pguiaId)
            : this()
        {
            opc = popc;
            guiaId = pguiaId;
        }


        private void LlenarGrid()
        {
            try
            {
                if (m_guiaBE == null || m_guiaBE.IID == 0)
                    return;

                this.gUIADETALLE_TableAdapter.Fill(this.dSGuia.GUIADETALLE_, (int)m_guiaBE.IID);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }


        private void HabilitarGuiaPaqueteriaEdicion()
        {
            if(this.opc == "Consultar")
            {
                GUIAPAQUETERIATextBox.Enabled = false;
            }

            if(TIPOENTREGAIDComboBox.SelectedIndex >= 0)
            {
                
                long TIPOENTREGAID = long.Parse(TIPOENTREGAIDComboBox.SelectedDataValue.ToString());
                if(TIPOENTREGAID == DBValues._TIPOENTREGA_PORPAQUETERIA)
                {
                    GUIAPAQUETERIATextBox.Enabled = true;
                }
                else
                {

                    GUIAPAQUETERIATextBox.Enabled = false;
                    GUIAPAQUETERIATextBox.Text = "";
                }
            }

            

            

        }


        private void SeleccionarTransaccionPorDocto(CDOCTOBE docto)
        {

            CPERSONAD personaD = new CPERSONAD();
            CPERSONABE personaBE = new CPERSONABE();
            personaBE.IID = docto.IPERSONAID;
            personaBE = personaD.seleccionarPERSONA(personaBE, null);

            m_guiaDetBE.IDOCTOID = docto.IID;
            /*m_guiaDetBE.IPERSONAID = docto.IPERSONAID;
            m_guiaDetBE.ISALDO = docto.ISALDO;
            m_guiaDetBE.IFECHAVENCE = docto.IVENCE;
            m_guiaDetBE.IDIAPAGOS = personaBE.IPAGOS;*/

            TBTransacccion.Text = docto.IFOLIO.ToString();

            llenarDatosPersona(personaBE);
            llenarDatosTransaccion(docto);

        }

        private void SeleccionarTransaccion()
        {


            WFGuiasAsignarVentas look = new WFGuiasAsignarVentas();
            look.ShowDialog();

            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);

            if (dr != null)
            {
                m_guiaDetBE = new CGUIADETALLEBE();
                m_guiaDetBE.IGUIAID = m_guiaBE.IID;
                m_guiaDetBE.IESTADOGUIAID = DBValues._ESTADO_GUIA_NOASIGNADO;



                CDOCTOBE docto = new CDOCTOBE();
                docto.IID = int.Parse(dr[0].ToString());
                CDOCTOD vData = new CDOCTOD();
                docto = vData.seleccionarDOCTO(docto, null);

                if (docto != null)
                {

                    if (docto.IESTADOGUIAID != 0)
                    {
                        MessageBox.Show("Esa transaccion ya ha sido enviada en otro control de embarque");
                        return;
                    }
                    SeleccionarTransaccionPorDocto(docto);
                }




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

        private void BtnListaTransacciones_Click(object sender, EventArgs e)
        {
            SeleccionarTransaccion();
        }

        private bool obtenerDatosGuia()
        {
            if (m_guiaBE == null)
            {
                m_guiaBE = new CGUIABE();
            }

            if (this.ENCARGADOIDTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Seleccione un encargado valido");
                return false;
            }

            if (this.TIPOENTREGAIDComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un tipo de entrega valido");
                return false;
            }


            m_guiaBE.ICAJEROID = CurrentUserID.CurrentUser.IID;
            m_guiaBE.INOTA = TBNota.Text;
            m_guiaBE.INOTARECEPCION = NOTARECEPCIONTextBox.Text;
            m_guiaBE.IENCARGADOGUIAID = Int64.Parse(this.ENCARGADOIDTextBox.DbValue.ToString());
            m_guiaBE.IGUIAPAQUETERIA = GUIAPAQUETERIATextBox.Text;
            m_guiaBE.ITIPOENTREGAID = long.Parse(TIPOENTREGAIDComboBox.SelectedDataValue.ToString());


            if (this.VEHICULOIDTextBox.Text != "")
            {
                m_guiaBE.IVEHICULOID = Int64.Parse(this.VEHICULOIDTextBox.DbValue.ToString());
            }
            else
            {

                MessageBox.Show("Seleccione un vehiculo");
                return false;
            }

            m_guiaBE.IFECHA = FECHAHORATextBox.Value;
            m_guiaBE.IFECHAHORA = FECHAHORATextBox.Value;
            m_guiaBE.IFECHAESTIMADAREC = HORAESTIMADRECTextBox.Value;
            m_guiaBE.IHORAESTIMADREC = HORAESTIMADRECTextBox.Value;

            if((HORAESTIMADRECTextBox.Value - FECHAHORATextBox.Value ).TotalMinutes <= 0)
            {

                if (MessageBox.Show("La fecha/hora de salida es la misma que la fecha/hora de llegada, o la fecha de llegada es menor que la de salida. Desea continuar?",
                                    "Advertencia",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.No)
                {
                    return false;
                }
            }

            return true;
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (m_guiaDetBE != null && TBTransacccion.Text.Trim().Length > 0)
            {
                if (obtenerDatosGuia())
                {

                    CGUIADETALLED guiaDETD = new CGUIADETALLED();





                    FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                    FbTransaction fTrans = null;
                    try
                    {

                        fConn.Open();
                        fTrans = fConn.BeginTransaction();
                        m_guiaDetBE.IESTADOGUIAID = DBValues._ESTADO_GUIA_ENVIADA;

                        //ante cualquier return o error
                        if (!guiaDETD.GUIADETALLE_INSERT(ref m_guiaDetBE, ref m_guiaBE, fTrans))
                        {
                            fTrans.Rollback();
                            fConn.Close();

                            MessageBox.Show("Ocurrio un eror al agregar el registro " + guiaDETD.IComentario);
                            return;
                        }


                        //en caso de exito
                        fTrans.Commit();


                        LlenarGrid();
                        LBCliente.Text = "";
                        TBTransacccion.Text = "";
                        limpiarDatosPersona();
                        limpiarDatosTransaccion();
                        MessageBox.Show("Se agrego el registro");
                        TBTransacccion.Focus();



                        IDEmbarqueLabel.Text = m_guiaBE.IID.ToString();
                        this.opc = "Cambiar";
                        this.ReCargar();
                        fConn.Close();

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






                    m_guiaDetBE = null;
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }



        public void ReCargar()
        {

            if (this.opc != "Agregar" && this.opc != "")
            {
                btnCancelar.Visible = false;
                TBNota.Enabled = false;
                NOTARECEPCIONTextBox.Enabled = false;
                ENCARGADOIDTextBox.Enabled = false;
                ENCARGADOButton.Enabled = false;
                FECHATextBox.Enabled = false;
                TIPOENTREGAIDComboBox.Enabled = false;
                GUIAPAQUETERIATextBox.Enabled = false;
                FECHAHORATextBox.Enabled = false;
                HORAESTIMADRECTextBox.Enabled = false;
                VEHICULOIDTextBox.Enabled = false;

                btnGuardar.Visible = false;


                if (this.opc == "Consultar")
                {
                    this.pnlAddVenta.Visible = false;
                    this.gUIADETALLE_DataGridView.Columns["DGELIMINAR"].Visible = false;
                    this.gUIADETALLE_DataGridView.Columns["DGRECIBIR"].Visible = false;
                    btnRecibir.Visible = false;
                    btnCartaCorte.Visible = false;

                }
                else if (this.opc == "Cambiar")
                {
                    this.pnlAddVenta.Visible = true;
                    this.gUIADETALLE_DataGridView.Columns["DGELIMINAR"].Visible = true;
                    this.gUIADETALLE_DataGridView.Columns["DGRECIBIR"].Visible = true;
                    btnRecibir.Visible = false;
                    btnCartaCorte.Visible = true;
                    btnCancelar.Visible = true;
                    btnGuardar.Visible = true;
                    this.TBNota.Enabled = true;
                    this.NOTARECEPCIONTextBox.Enabled = false;
                    VEHICULOIDTextBox.Enabled = true;
                    HabilitarGuiaPaqueteriaEdicion();
                }
                else if (this.opc == "Recibir")
                {
                    this.pnlAddVenta.Visible = false;
                    this.NOTARECEPCIONTextBox.Enabled = true;
                    this.gUIADETALLE_DataGridView.Columns["DGELIMINAR"].Visible = false;
                    this.gUIADETALLE_DataGridView.Columns["DGRECIBIR"].Visible = true;
                    btnRecibir.Visible = true;
                    btnCartaCorte.Visible = false;
                }
                else if (this.opc == "CartaCorte")
                {
                    this.pnlAddVenta.Visible = false;
                    this.gUIADETALLE_DataGridView.Columns["DGELIMINAR"].Visible = false;
                    this.gUIADETALLE_DataGridView.Columns["DGRECIBIR"].Visible = true;
                    btnCartaCorte.Visible = true;
                    btnRecibir.Visible = false;
                }
                LlenarDatosDeBase();
                this.ENCARGADOIDTextBox.Enabled = false;
                this.ENCARGADOButton.Enabled = false;
            }
            else if (this.opc == "Agregar")
            {
                btnCancelar.Visible = false;
                this.TBNota.Enabled = true;
                ENCARGADOIDTextBox.Enabled = true;
                ENCARGADOButton.Enabled = true;
                FECHATextBox.Enabled = true;
                TIPOENTREGAIDComboBox.Enabled = true;
                GUIAPAQUETERIATextBox.Enabled = true;

                FECHAHORATextBox.Enabled = true;
                HORAESTIMADRECTextBox.Enabled = true;
                VEHICULOIDTextBox.Enabled = true;

                this.gUIADETALLE_DataGridView.Columns["DGELIMINAR"].Visible = false;
                this.gUIADETALLE_DataGridView.Columns["DGRECIBIR"].Visible = false;
                btnRecibir.Visible = false;
                btnCartaCorte.Visible = false;
            }
        }



        public void LlenarDatosDeBase()
        {
            try
            {
                if (guiaId != 0)
                {
                    CGUIABE guiaBE = new CGUIABE();
                    CGUIAD guiaD = new CGUIAD();
                    guiaBE.IID = guiaId;
                    guiaBE = guiaD.seleccionarGUIA(guiaBE, null);

                    if (guiaBE != null)
                    {
                        m_guiaBE = guiaBE;
                        IDEmbarqueLabel.Text = m_guiaBE.IID.ToString();
                        FECHATextBox.Value = guiaBE.IFECHA;
                        string strBuffer = "";
                        if (!(bool)guiaBE.isnull["IENCARGADOGUIAID"])
                        {
                            this.ENCARGADOIDTextBox.DbValue = guiaBE.IENCARGADOGUIAID.ToString();
                            this.ENCARGADOIDTextBox.MostrarErrores = false;
                            this.ENCARGADOIDTextBox.MValidarEntrada(out strBuffer, 1);
                            this.ENCARGADOIDTextBox.MostrarErrores = true;
                        }
                        else
                        {
                            this.ENCARGADOIDTextBox.Text = "";
                        }

                        if (!(bool)guiaBE.isnull["IESTADOGUIAID"])
                        {
                            this.ESTADOTextBox.SelectedDataDisplaying = guiaBE.IESTADOGUIAID.ToString();
                        }
                        else
                        {
                            this.ESTADOTextBox.Text = "";
                        }

                        if (!(bool)guiaBE.isnull["INOTA"])
                        {
                            this.TBNota.Text = guiaBE.INOTA.ToString();
                        }
                        else
                        {
                            this.TBNota.Text = "";
                        }

                        if (!(bool)guiaBE.isnull["IGUIAPAQUETERIA"])
                        {
                            this.GUIAPAQUETERIATextBox.Text = guiaBE.IGUIAPAQUETERIA.ToString();
                        }
                        else
                        {
                            this.GUIAPAQUETERIATextBox.Text = "";
                        }

                        if (!(bool)guiaBE.isnull["IVEHICULOID"])
                        {
                            this.VEHICULOIDTextBox.DbValue = guiaBE.IVEHICULOID.ToString();
                            this.VEHICULOIDTextBox.MostrarErrores = false;
                            this.VEHICULOIDTextBox.MValidarEntrada(out strBuffer, 1);
                            this.VEHICULOIDTextBox.MostrarErrores = true;
                        }
                        else
                        {
                            this.VEHICULOIDTextBox.Text = "";
                        }


                        try
                        {
                            if (!(bool)guiaBE.isnull["IFECHAHORA"])
                            {
                                this.FECHAHORATextBox.Value = guiaBE.IFECHAHORA;
                            }
                        }
                        catch
                        {
                        }


                        try
                        {
                            if (!(bool)guiaBE.isnull["IHORAESTIMADREC"])
                            {
                                this.HORAESTIMADRECTextBox.Value = guiaBE.IHORAESTIMADREC;
                            }
                        }
                        catch
                        {
                        }

                        if (!(bool)guiaBE.isnull["INOTARECEPCION"])
                        {
                            this.NOTARECEPCIONTextBox.Text = guiaBE.INOTARECEPCION.ToString();
                        }
                        else
                        {
                            this.NOTARECEPCIONTextBox.Text = "";
                        }


                        LlenarGrid();
                        limpiarDatosPersona();
                        limpiarDatosTransaccion();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WFGuiasEdicion_Load(object sender, EventArgs e)
        {
            TIPOENTREGAIDComboBox.llenarDatos();
            ESTADOTextBox.llenarDatos();
            ReCargar();
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
                if (!recibirCambios(fTrans, ref strComentario))
                {
                    fTrans.Rollback();
                    fConn.Close();

                    MessageBox.Show("Problema al llevar a cabo el proceso, llame a soporte." + strComentario);
                    return;
                }
                else
                {
                    fTrans.Commit();
                    fConn.Close();


                    MessageBox.Show("Proceso finalizado con exito");
                    LlenarGrid();
                    //this.Close();
                }
            }
            catch
            {
                try
                {
                    fTrans.Rollback();
                    fConn.Close();
                }
                catch
                {
                    fTrans.Rollback();
                    fConn.Close();
                }

            }
            finally
            {
                fConn.Close();
            }
        }

        private void gUIADETALLE_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (gUIADETALLE_DataGridView.Columns[e.ColumnIndex].Name == "DGELIMINAR")
                {
                    if (MessageBox.Show("Realmente desea eliminar el pedido?",
                                        "Confirmacion",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        long guiaDetalleId = long.Parse(gUIADETALLE_DataGridView.Rows[e.RowIndex].Cells["DGID"].Value.ToString());
                        CGUIADETALLED guiaDetalleDao = new CGUIADETALLED();
                        CGUIADETALLEBE guiaDetalle = new CGUIADETALLEBE();
                        guiaDetalle.IID = guiaDetalleId;

                        FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                        FbTransaction fTrans = null;
                        try
                        {
                            fConn.Open();
                            fTrans = fConn.BeginTransaction();

                            //ante cualquier return o error

                            if (!guiaDetalleDao.GUIADETALLE_DELETE(guiaDetalle, m_guiaBE, null))
                            {
                                fTrans.Rollback();
                                fConn.Close();

                                MessageBox.Show("Problema al llevar a cabo el proceso, llame a soporte." + guiaDetalleDao.IComentario);

                                return;
                            }
                            else
                            {
                                fTrans.Commit();
                                fConn.Close();
                                LlenarGrid();
                                MessageBox.Show("Proceso finalizado con exito");
                            }
                        }
                        catch
                        {
                            try
                            {
                                fTrans.Rollback();
                                fConn.Close();
                            }
                            catch
                            {
                                fTrans.Rollback();
                                fConn.Close();
                            }

                        }
                        finally
                        {
                            fConn.Close();
                        }
                    }

                }
                else if (gUIADETALLE_DataGridView.Columns[e.ColumnIndex].Name == "DGREIMPRIMIRCARTAPORTE")
                {
                    if(gUIADETALLE_DataGridView.Rows[e.RowIndex].Cells["DGCARTAPORTEID"].Value != null &&
                        gUIADETALLE_DataGridView.Rows[e.RowIndex].Cells["DGCARTAPORTEID"].Value != DBNull.Value )
                    {
                        try
                        {
                            long doctoId = long.Parse(gUIADETALLE_DataGridView.Rows[e.RowIndex].Cells["DGDOCTOID"].Value.ToString());
                            long cartaPorteId = long.Parse(gUIADETALLE_DataGridView.Rows[e.RowIndex].Cells["DGCARTAPORTEID"].Value.ToString());

                            if(cartaPorteId != 0)
                            {
                                imprimirComprobanteTraslado(doctoId);
                            }
                        }
                        catch {
                            MessageBox.Show("Asegurese que la carta porte de este documento ya haya sido realizada");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Asegurese que la carta porte de este documento ya haya sido realizada");
                    }

                    
                }
                else if (gUIADETALLE_DataGridView.Columns[e.ColumnIndex].Name == "DGRECIBIR")
                {

                    if (int.Parse(gUIADETALLE_DataGridView.Rows[e.RowIndex].Cells["DGRECIBIR"].Value.ToString()) == 1)
                    {
                        pnlFirma.Visible = true;

                        if (
                            gUIADETALLE_DataGridView.Rows[e.RowIndex].Cells["DGFIRMAIMAGEN"].Value != null &&
                            gUIADETALLE_DataGridView.Rows[e.RowIndex].Cells["DGFIRMAIMAGEN"].Value != DBNull.Value &&
                            gUIADETALLE_DataGridView.Rows[e.RowIndex].Cells["DGFIRMAIMAGEN"].Value.ToString() != "")
                        {

                            lblNoFirmasRegistradas.Visible = false;
                            FIRMAIMAGENPictureBox.Visible = true;
                            string clienteFirmaImagen = gUIADETALLE_DataGridView.Rows[e.RowIndex].Cells["DGFIRMAIMAGEN"].Value.ToString();
                            string imagePath = CurrentUserID.CurrentParameters.IRUTAFIRMAIMAGENES + "\\" + clienteFirmaImagen;
                            try
                            {
                                if (clienteFirmaImagen != "")
                                {

                                    FIRMAIMAGENPictureBox.Image = Image.FromFile(imagePath);
                                }
                            }
                            catch
                            {
                            }

                        }
                        else
                        {
                            lblNoFirmasRegistradas.Visible = true;
                            FIRMAIMAGENPictureBox.Visible = false;
                        }
                    }
                    else
                    {
                        pnlFirma.Visible = false;
                    }
                }
                else if (gUIADETALLE_DataGridView.Columns[e.ColumnIndex].Name == "DGNOTADETALLE")
                {

                    var notaGuardada = gUIADETALLE_DataGridView.Rows[e.RowIndex].Cells["DGNOTA"].Value?.ToString() ?? "";

                    WFNotaGuiaDocto notaGuiaDocto = new WFNotaGuiaDocto(notaGuardada);
                    notaGuiaDocto.ShowDialog();

                    string strNotaGuiaDocto = notaGuiaDocto.strNota.Trim();

                    notaGuiaDocto.Dispose();
                    GC.SuppressFinalize(notaGuiaDocto);


                    if (strNotaGuiaDocto != null && strNotaGuiaDocto.Trim().Length > 0)
                    {
                        long doctoId = long.Parse(gUIADETALLE_DataGridView.Rows[e.RowIndex].Cells["DGDOCTOID"].Value.ToString());
                        CDOCTOD doctoD = new CDOCTOD();
                        doctoD.CambiarDOCTONOTASET(doctoId, DBValues._TIPODOCTONOTA_RECEPCIONEMBARQUE, DateTime.Now, CurrentUserID.CurrentUser.IID, strNotaGuiaDocto, null);
                        
                        gUIADETALLE_DataGridView.Rows[e.RowIndex].Cells["DGNOTA"].Value = strNotaGuiaDocto;

                    }
                }
            }
        }

        public bool recibirCambios(FbTransaction transaction, ref string comentario)
        {
            CGUIADETALLED guiaDetalleDao = new CGUIADETALLED();
            CGUIADETALLEBE guiaDetalle = new CGUIADETALLEBE();
            CGUIABE guia = new CGUIABE();
            CGUIAD guiaD = new CGUIAD();
            try
            {

                
                guia.IID = guiaId;
                guia.INOTARECEPCION = NOTARECEPCIONTextBox.Text;

                if (!guiaD.CambiarNotaRecepcionGUIAD(guia, guia, null))
                {

                    MessageBox.Show("Ocurrio un error " + guiaD.IComentario);
                    return false;
                }

                foreach (DataGridViewRow dataRow in this.gUIADETALLE_DataGridView.Rows)
                {
                    guiaDetalle.IID = (long)dataRow.Cells["DGID"].Value;

                    if (dataRow.Cells["DGRECIBIR"].Value != null &&
                        dataRow.Cells["DGRECIBIR"].Value != DBNull.Value &&
                        ((int)dataRow.Cells["DGRECIBIR"].Value == 1))
                    {
                        guiaDetalle.IESTADOGUIAID = DBValues._ESTADO_GUIA_RECIBIDA;
                    }
                    else
                    {
                        guiaDetalle.IESTADOGUIAID = DBValues._ESTADO_GUIA_ENVIADA;

                    }
                    guia.ICAJEROID = CurrentUserID.CurrentUser.IID;
                    if(!guiaDetalleDao.GUIADETALLE_RECIBIR(guiaDetalle, guia, transaction))
                    {
                        comentario = guiaDetalleDao.IComentario;
                        Console.WriteLine(comentario);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                comentario = "Problema al recibir: " + ex.Message;
                return false;
            }
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Realmente desea cancelar la guia?",
                                "Confirmacion",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CGUIAD guiaDao = new CGUIAD();

                FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
                FbTransaction fTrans = null;
                try
                {
                    fConn.Open();
                    fTrans = fConn.BeginTransaction();

                    //ante cualquier return o error

                    if (!guiaDao.GUIA_CANCEL(m_guiaBE, null))
                    {
                        fTrans.Rollback();
                        fConn.Close();

                        MessageBox.Show("Problema al llevar a cabo el proceso, llame a soporte.");
                        return;
                    }
                    else
                    {
                        fTrans.Commit();
                        fConn.Close();
                        MessageBox.Show("Proceso finalizado con exito");
                        this.Close();
                    }
                }
                catch
                {
                    try
                    {
                        fTrans.Rollback();
                        fConn.Close();
                    }
                    catch
                    {
                        fTrans.Rollback();
                        fConn.Close();
                    }

                }
                finally
                {
                    fConn.Close();
                }
            }

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("guiaid", m_guiaBE.IID);

            string strReporte = "ReporteGuias.frx";

            iPos.Login_and_Maintenance.WFReporteShowing rp = new Login_and_Maintenance.WFReporteShowing(FastReportsConfig.getPathForFile(strReporte, FastReportsTipoFile.desistema), dictionary);
            rp.ShowDialog();
            rp.Dispose();
            GC.SuppressFinalize(rp);
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if(obtenerDatosGuia())
            {

                CGUIAD guiaD = new CGUIAD();
                if (m_guiaBE.IID == 0)
                {

                    if (gUIADETALLE_DataGridView.RowCount == 0)
                    {
                        MessageBox.Show("Ingrese por lo menos una transaccion a enviar");
                        return ;
                    }
                    

                    if (!guiaD.GUIA_INSERT(ref m_guiaBE, null))
                    {
                        MessageBox.Show("Ocurrio un problema con la guia " + guiaD.IComentario);
                    }
                    else
                    {


                        IDEmbarqueLabel.Text = m_guiaBE.IID.ToString();
                        this.opc = "Cambiar";
                        this.ReCargar();
                        MessageBox.Show("La guia se ha guardado");

                    }
                }
                else
                {

                    if (!guiaD.CambiarEditablesGUIAD(m_guiaBE, m_guiaBE, null))
                    {
                        MessageBox.Show("Ocurrio un problema con la guia " + guiaD.IComentario);
                    }
                    else
                    {
                        MessageBox.Show("La guia se ha guardado");
                    }
                }
            }
        }

        private void TIPOENTREGAIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.HabilitarGuiaPaqueteriaEdicion();
            
        }

        private void TBTransacccion_Validating(object sender, CancelEventArgs e)
        {


            if (TBTransacccion.Text.Trim() == "")
                return;

            int folio = 0;

            CDOCTOD vData = new CDOCTOD();
            if (int.TryParse(TBTransacccion.Text.Trim(), out folio))
            {

                m_guiaDetBE = new CGUIADETALLEBE();
                m_guiaDetBE.IGUIAID = m_guiaBE.IID;
                m_guiaDetBE.IESTADOGUIAID = DBValues._ESTADO_GUIA_NOASIGNADO;


                CDOCTOBE docto = new CDOCTOBE();
                docto.IFOLIO = folio;
                docto.ITIPODOCTOID = DBValues._DOCTO_TIPO_VENTA;
                docto = vData.SeleccionarXTIPOYFOLIO(docto, null);

                if (docto != null)
                {


                    if (docto.IESTADOGUIAID != 0)
                    {
                        MessageBox.Show("Esa transaccion ya ha sido enviada en otro control de embarque");
                        e.Cancel = true;
                    }
                    this.SeleccionarTransaccionPorDocto(docto);
                }
                else
                {

                    MessageBox.Show("El registro no existe " + vData.IComentario);

                    e.Cancel = true;
                }

            }

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

        private void btnGenerarCartaPorte(object sender, EventArgs e)
        {
            
            try
            {

                foreach (DataGridViewRow dataRow in this.gUIADETALLE_DataGridView.Rows)
                {

                    if (dataRow.Cells["DGRECIBIR"].Value != null &&
                        dataRow.Cells["DGRECIBIR"].Value != DBNull.Value &&
                        ((int)dataRow.Cells["DGRECIBIR"].Value == 1) &&

                        dataRow.Cells["DGCARTAPORTEID"].Value != null &&
                        dataRow.Cells["DGCARTAPORTEID"].Value != DBNull.Value &&
                        ((long)dataRow.Cells["DGCARTAPORTEID"].Value > 0))
                    {
                        MessageBox.Show("Solo seleccione ventas que no tengan ya registrada la carta porte ");
                        return;
                    }
                }

                foreach (DataGridViewRow dataRow in this.gUIADETALLE_DataGridView.Rows)
                {

                    if (dataRow.Cells["DGRECIBIR"].Value != null &&
                        dataRow.Cells["DGRECIBIR"].Value != DBNull.Value &&
                        ((int)dataRow.Cells["DGRECIBIR"].Value == 1))
                    {

                        var guiaDetalleId = (long)dataRow.Cells["DGID"].Value;
                        var doctoId = (long)dataRow.Cells["DGDOCTOID"].Value;

                        if (generarComprobanteTraslado(doctoId))
                        {
                            imprimirComprobanteTraslado(doctoId);
                        }
                    }
                }


                LlenarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private bool generarComprobanteTraslado(long doctoId)
        {

            bool retorno = false;

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            CDOCTOBE docto = new CDOCTOBE();
            CDOCTOD doctoD = new CDOCTOD();
            docto.IID = doctoId;
            docto = doctoD.seleccionarDOCTO(docto, null);

            CDOCTOPAGOBE pagoTemporal = new CDOCTOPAGOBE();
            CDOCTOPAGOD doctoPagoD = new CDOCTOPAGOD();

            pagoTemporal = doctoPagoD.seleccionarPrimerDOCTOPAGO(docto, null);

            iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_COMPROBTRASL, null, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.m_vendedorId = CurrentUserID.CurrentUser.IID;
            fe.m_generarCartaPorte = true;
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);

            return retorno;

        }



        private bool imprimirComprobanteTraslado(long doctoId)
        {

            bool retorno = false;

            CUSUARIOSD usuariosD = new CUSUARIOSD();
            CDOCTOBE docto = new CDOCTOBE();
            CDOCTOD doctoD = new CDOCTOD();
            docto.IID = doctoId;
            docto = doctoD.seleccionarDOCTO(docto, null);

            CDOCTOPAGOBE pagoTemporal = new CDOCTOPAGOBE();
            CDOCTOPAGOD doctoPagoD = new CDOCTOPAGOD();

            pagoTemporal = doctoPagoD.seleccionarPrimerDOCTOPAGO(docto, null);

            iPosReporting.WFFacturaElectronica fe = new iPosReporting.WFFacturaElectronica(docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_GENPDF_COMPROBTRASL, null, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.m_vendedorId = CurrentUserID.CurrentUser.IID;
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);

            return retorno;

        }
        

        private void gUIADETALLE_DataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {


            int columnIndex = gUIADETALLE_DataGridView.CurrentCell.ColumnIndex;
            int rowIndex = gUIADETALLE_DataGridView.CurrentCell.RowIndex;

            string columnName = gUIADETALLE_DataGridView.Columns[columnIndex].Name;


            // Abort validation if cell is not in the CompanyName column.
            if (!columnName.Equals("DGRECIBIR")) return;

            var dgw = (DataGridView)sender;
            dgw.CommitEdit(DataGridViewDataErrorContexts.Commit);
            
        }
    }
}
