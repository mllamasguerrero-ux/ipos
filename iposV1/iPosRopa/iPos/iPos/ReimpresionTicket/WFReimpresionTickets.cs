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

namespace iPos
{
    public partial class WFReimpresionTickets : IposForm
    {

        public bool m_bPagoVerifoneHabilitado = false;

        bool m_bTieneDerechoAAbrirVentasCerradas = false;

        public WFReimpresionTickets()
        {
            InitializeComponent();
        }

        private void WFReimpresionTickets_Load(object sender, EventArgs e)
        {
            

            this.BTReImprimirVoucher.Visible = false;

            this.CBCajero.llenarDatos();
            this.CBTipoCorte.SelectedIndex = 0;


            CUSUARIOSD usuariosD = new CUSUARIOSD();

            this.m_bPagoVerifoneHabilitado = iPos.CurrentUserID.CurrentVerifoneCajaConfig.IACTIVO == "S" &&
                usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_PAGO_TERMINAL_VERIFONE, null);


            m_bTieneDerechoAAbrirVentasCerradas = usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_ABRIR_VENTASCERRADAS, null);


            this.btnReinicializaVerifone.Visible = m_bPagoVerifoneHabilitado;

            this.BTSeleccionar.Visible = m_bTieneDerechoAAbrirVentasCerradas;

        }

        private void BTSeleccionar_Click(object sender, EventArgs e)
        {
            if(CBTipoTran.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor seleccione primero el tipo de transaccion");
                return;
            }

            switch(CBTipoTran.SelectedItem.ToString())
            {
                case "Venta Cerrada":
                    {
                        WFLookUpTransacciones wfl = new WFLookUpTransacciones(DBValues._DOCTO_ESTATUS_COMPLETO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_VENTA);
                        wfl.ShowDialog();

                        DataRow dr = wfl.m_rtnDataRow;

                        wfl.Dispose();
                        GC.SuppressFinalize(wfl);

                        if (dr != null)
                        {
                            this.TBFolio.Text = dr[15].ToString();
                        }
                        BTReImprimir.Visible = true;
                    }
                    break;


                case "Venta Cancelada":
                    {
                        WFLookUpTransacciones wfl = new WFLookUpTransacciones(DBValues._DOCTO_ESTATUS_CANCELADA, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_VENTA);
                        wfl.ShowDialog();

                        DataRow dr = wfl.m_rtnDataRow;

                        wfl.Dispose();
                        GC.SuppressFinalize(wfl);

                        if (dr != null)
                        {
                            this.TBFolio.Text = dr[15].ToString();
                        }

                    }
                    break;


                case "Traslados Envio":
                    {
                        WFLookUpTransacciones wfl = new WFLookUpTransacciones(DBValues._DOCTO_ESTATUS_COMPLETO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_TRASPASO_ENVIO);
                        wfl.ShowDialog();

                        DataRow dr = wfl.m_rtnDataRow;

                        wfl.Dispose();
                        GC.SuppressFinalize(wfl);


                        if (dr != null)
                        {
                            this.TBFolio.Text = dr[15].ToString();
                        }

                    }
                    break;





                case "Traslados Recepcion":
                    {
                        WFLookUpTransacciones wfl = new WFLookUpTransacciones(DBValues._DOCTO_ESTATUS_COMPLETO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_TRASPASO_REC);
                        wfl.ShowDialog();

                        DataRow dr = wfl.m_rtnDataRow;

                        wfl.Dispose();
                        GC.SuppressFinalize(wfl);


                        if (dr != null)
                        {
                            this.TBFolio.Text = dr[15].ToString();
                        }

                    }
                    break;



                case "Compra":
                    {
                        WFLookUpTransacciones wfl = new WFLookUpTransacciones(DBValues._DOCTO_ESTATUS_COMPLETO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_COMPRA);
                        wfl.ShowDialog();

                        DataRow dr = wfl.m_rtnDataRow;

                        wfl.Dispose();
                        GC.SuppressFinalize(wfl);


                        if (dr != null)
                        {
                            this.TBFolio.Text = dr[15].ToString();
                        }

                    }
                    break;


                case "Devolucion de traslado enviado":
                    {
                        WFLookUpTransacciones wfl = new WFLookUpTransacciones(DBValues._DOCTO_ESTATUS_COMPLETO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_TRASPASO_ENVIO_DEVO);
                        wfl.ShowDialog();

                        DataRow dr = wfl.m_rtnDataRow;

                        wfl.Dispose();
                        GC.SuppressFinalize(wfl);


                        if (dr != null)
                        {
                            this.TBFolio.Text = dr[15].ToString();
                        }

                    }
                    break;


                case "Devolucion de pedido enviado":
                    {
                        WFLookUpTransacciones wfl = new WFLookUpTransacciones(DBValues._DOCTO_ESTATUS_COMPLETO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_PEDIDO_ENVIO_DEVO);
                        wfl.ShowDialog();

                        DataRow dr = wfl.m_rtnDataRow;

                        wfl.Dispose();
                        GC.SuppressFinalize(wfl);


                        if (dr != null)
                        {
                            this.TBFolio.Text = dr[15].ToString();
                        }

                    }
                    break;



                case "Pedido Recepcion":
                    {
                        WFLookUpTransacciones wfl = new WFLookUpTransacciones(DBValues._DOCTO_ESTATUS_COMPLETO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_PEDIDO_COMPRA);
                        wfl.ShowDialog();

                        DataRow dr = wfl.m_rtnDataRow;

                        wfl.Dispose();
                        GC.SuppressFinalize(wfl);


                        if (dr != null)
                        {
                            this.TBFolio.Text = dr[15].ToString();
                        }

                    }
                    break;


                case "Venta a Futuro":
                    {
                        WFLookUpTransacciones wfl = new WFLookUpTransacciones(DBValues._DOCTO_ESTATUS_COMPLETO, iPos.CurrentUserID.CurrentCompania.IEM_CAJA, DBValues._DOCTO_TIPO_VENTA_FUTURO);
                        wfl.ShowDialog();

                        DataRow dr = wfl.m_rtnDataRow;

                        wfl.Dispose();
                        GC.SuppressFinalize(wfl);


                        if (dr != null)
                        {
                            this.TBFolio.Text = dr[15].ToString();
                        }

                    }
                    break;

                default: break;
            }
        }

        private void BTReImprimir_Click(object sender, EventArgs e)
        {
            CDOCTOD doctoD = new CDOCTOD();
            CDOCTOBE doctoBE = new CDOCTOBE();
            long lPrintOption = 0;

            try
            {

            doctoBE.IFOLIO = int.Parse(this.TBFolio.Text.ToString());

            switch(CBTipoTran.SelectedItem.ToString())
            {
                case "Venta Cerrada":
                    doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_VENTA;
                    break;


                case "Venta Cancelada":
                    doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_VENTA;
                    break;


                case "Traslados Envio":
                    doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_TRASPASO_ENVIO;
                    break;


                case "Traslados Recepcion":
                    doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_TRASPASO_REC;
                    break;



                case "Pedido Recepcion":
                    doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_PEDIDO_COMPRA;
                    break;


                case "Devolucion de traslado enviado":
                    doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_TRASPASO_ENVIO_DEVO;
                    break;


                case "Devolucion de pedido enviado":
                    doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_PEDIDO_ENVIO_DEVO;
                    break;

                case "Compra":
                    lPrintOption = Ticket._OPCION_IMPRESION_COMPRA;
                    doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_COMPRA;
                    break;

                case "Venta a Futuro":
                    doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_VENTA_FUTURO;
                    break;

                default: break;
            }

            }
            catch
            {
                return;
            }

            doctoBE = doctoD.SeleccionarXTIPOYFOLIO(doctoBE, null);

            if (doctoBE == null)
            {
                MessageBox.Show("Folio no encontrado");
                return;
            }


            //si es importacion de compra que la opcion sea de compra recepcion
            if(doctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_COMPRA && 
                (doctoBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_COMPRAIMPORTADA ||
                 doctoBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_COMPRARECORDEN ||
                 doctoBE.ISUBTIPODOCTOID == DBValues._DOCTO_SUBTIPO_COMPRAPEDIDO ))
            {
                lPrintOption = Ticket._OPCION_IMPRESION_COMPRA_RECEPCION;
            }


            try
            {
                PosPrinter.ImprimirTicket(doctoBE.IID, lPrintOption);

                //si es una compra ademas tenemos que imprimir el ticket de devolucion
                if (doctoBE.ITIPODOCTOID == DBValues._DOCTO_TIPO_PEDIDO_COMPRA)
                    PosPrinter.ImprimirTicket(doctoBE.IID, Ticket._OPCION_IMPRESION_COMPRA_DEVOLUCION);


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        private void BTReimprimirCorte_Click(object sender, EventArgs e)
        {

            if (CBCajero.SelectedIndex < 0)
                return;

            CCORTED corteD = new CCORTED();
            CCORTEBE corteBE = new CCORTEBE();
            corteBE.IFECHACORTE = DTPCorte.Value.Date;
            corteBE.ICAJEROID = long.Parse(CBCajero.SelectedValue.ToString());

            corteBE = corteD.seleccionarCORTEXDIAyCAJERO(corteBE, null);

            if (corteBE == null)
            {
                MessageBox.Show("El corte no existe");
                return;
            }

            WFImpresionCorte ic = new WFImpresionCorte(corteBE.IID);
            if(CBTipoCorte.SelectedIndex == 1)
                ic.m_iOpcion = ImpresionCorteOption.MontoBilletes;
            else if (CBTipoCorte.SelectedIndex == 2)
                ic.m_iOpcion = ImpresionCorteOption.Apertura;


            ic.ShowDialog();


            if (ic.m_bTicketImpreso)
                MessageBox.Show("El ticket se imprimio");

            ic.Dispose();
            GC.SuppressFinalize(ic);

        }

        private void DTPCorte_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BTReImprimirVoucher_Click(object sender, EventArgs e)
        {
            CUSUARIOSD usuariosD = new CUSUARIOSD();
            if (usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, (int)DBValues._DERECHO_REIMPRIMIR_VOUCHER, null))
            {
                CDOCTOD doctoD = new CDOCTOD();
                CDOCTOBE doctoBE = new CDOCTOBE();

                try
                {
                    doctoBE.IFOLIO = int.Parse(this.TBFolio.Text.ToString());
                    doctoBE.ITIPODOCTOID = DBValues._DOCTO_TIPO_VENTA;
                    doctoBE = doctoD.SeleccionarXTIPOYFOLIO(doctoBE, null);

                    if (doctoBE == null)
                    {
                        MessageBox.Show("Folio no encontrado");
                        return;
                    }

                    if (doctoBE.IPAGOBANCOMERAPLICADO == "S")
                    {

                        CBANCOMERPARAMBE bufferBanc = new CBANCOMERPARAMBE();
                        CBANCOMERPARAMD bancomerParamD = new CBANCOMERPARAMD();

                        bufferBanc.IDOCTOID = doctoBE.IID;
                        bufferBanc.ITIPOTRANSACCION = "001";
                        bufferBanc.IESTADOTRANSACCIONID = 1;
                        List<CBANCOMERPARAMBE> listaPagosSimple =
                            bancomerParamD.seleccionarBANCOMERPARAM_PORDOCTO_Simple(bufferBanc, null);
                        if (listaPagosSimple == null || listaPagosSimple.Count == 0)
                        {
                            MessageBox.Show("No se encontró el voucher en la base de datos");
                        }
                        else
                        {
                            for (int i = 0; i < listaPagosSimple.Count; i++)
                            {
                                PagoBancomerHelper.ImprimirVoucher(listaPagosSimple.ElementAt(i).IID, true, true);
                            }
                        }
                    }
                    else if(doctoBE.IPAGOVERIFONEAPLICADO == "S")
                    {

                        CVERIFONEPAYMENTBE bufferBanc = new CVERIFONEPAYMENTBE();
                        CVERIFONEPAYMENTD verifonePaymentD = new CVERIFONEPAYMENTD();

                        bufferBanc.IDOCTOID = doctoBE.IID;
                        bufferBanc.ITIPOTRANSACCION = "001";
                        bufferBanc.IESTADOTRANSACCIONID = 1;
                        List<CVERIFONEPAYMENTBE> listaPagosSimple =
                            verifonePaymentD.seleccionarVERIFONEPAYMENT_PORDOCTO_Simple(bufferBanc, null);
                        if (listaPagosSimple == null || listaPagosSimple.Count == 0)
                        {
                            MessageBox.Show("No se encontró el voucher en la base de datos");
                        }
                        else
                        {
                            for (int i = 0; i < listaPagosSimple.Count; i++)
                            {
                                PagoVerifoneHelper.ImprimirVoucher(listaPagosSimple.ElementAt(i).IID, false, true);
                            }
                        }

                    }

                }
                catch
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("No cuenta con el permiso de reimpresión de vouchers");
            }

           
        }

        private void CBTipoTran_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            string selectedOp = (string)comboBox.SelectedItem;

            if(selectedOp == "Venta Cerrada")
            {
                BTReImprimirVoucher.Visible = true;
            }
            else
            {
                BTReImprimirVoucher.Visible = false;
            }
        }

        private void btnReinicializaVerifone_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Realmente desea reinicializar la terminal verifone? .  ",
                                "Confirmacion",
                                MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            PagoVerifoneHelper.PreparaPinPad(true);
        }
    }
}
