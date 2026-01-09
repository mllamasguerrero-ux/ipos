using ConexionesBD;
using DataLayer.Catalogos.businessEntity;
using iPosBusinessEntity;
using iPosData;
using iPosReporting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace iPos
{
    public partial class WFRecargaCantidadEmida : IposForm
    {
        long m_ClienteId = DBValues._CLIENTEMOSTRADOR;

        CDOCTOBE m_Docto = null;

        public WFRecargaCantidadEmida()
        {
            InitializeComponent();
            if(m_ClienteId == DBValues._CLIENTEMOSTRADOR)
            {
                LBClienteNombre.Text = "PUBLICO EN GENERAL";
            }

        }


        private CEMIDAREQUESTBE ObtenerDatosCapturados()
        {
            CEMIDAREQUESTBE emidaRequest = new CEMIDAREQUESTBE();

            if(cbCantidadEmida.Text != "")
            {
                emidaRequest.IPRODUCTID = cbCantidadEmida.SelectedValue.ToString();
            }

            if(TBMonto.Text != "")
            {
                emidaRequest.IAMOUNT = TBMonto.Text;
            }

            if(txtNum1.Text != "" && txtNum1.Text.Trim().Length == 10 && txtNum2.Text == txtNum1.Text)
            {
                emidaRequest.IACCOUNTID = txtNum1.Text;
            }

            emidaRequest.IVERSION = "01";

            emidaRequest.ISITEID = DBEmida.ObtenerTerminal();

            CCLERKPAGOSERVICIOD clerkD = new CCLERKPAGOSERVICIOD();
            CCLERKPAGOSERVICIOBE clerkBE = new CCLERKPAGOSERVICIOBE();
            clerkBE.IID = CurrentUserID.CurrentUser.ICLERKPAGOSERVICIOSID;

            clerkBE = clerkD.seleccionarCLERKPAGOSERVICIO(clerkBE, null);

            if(clerkBE != null)
            {
                emidaRequest.ICLERKID = clerkBE.ICLERKID;//MLG TEST EMIDA "34960";
            }
            else
            {

                emidaRequest.ICLERKID = "";
            }

            

            string strCometnario = "";

            int iConsecutivo = DBEmida.ObtenerConsecutivoTerminal(ref strCometnario);
            if (iConsecutivo == -1)
            {
                MessageBox.Show(strCometnario);
            }
            else
            {
                //MessageBox.Show("El consecutivo es " + iConsecutivo.ToString());
                //string version, string siteId, string clerkId, string productId, string accountId, string amount, string invoiceNo, string languageOption)
                emidaRequest.IINVOICENO = iConsecutivo.ToString();
            }

            emidaRequest.ILANGUAGEOPTION = "2";

            emidaRequest.ICOMISION = 0;

            return emidaRequest;
        }


        private bool AgregarBorradorVenta(CEMIDAREQUESTBE emidaReq, ref int auxMovtoId)
        {
            CDOCTOD doctoD = new CDOCTOD();
            m_Docto = null;



            CEMIDAPRODUCTD prodEmidaD = new CEMIDAPRODUCTD();
            CEMIDAPRODEXTBE prodEmidaBE = new CEMIDAPRODEXTBE();
            prodEmidaBE.IPRODUCTID = emidaReq.IPRODUCTID;
            prodEmidaBE.IESSERVICIO = "N";
            prodEmidaBE = prodEmidaD.seleccionarEMIDAPRODUCTxEMIDAPRODUCTID(prodEmidaBE, null);


            if (prodEmidaBE == null)
            {
                MessageBox.Show("El producto emida no existe");
                return false;
            }

            int auxPrdouctId = 0;
            int auxDoctoId = 0;

            CEMIDAREQUESTD eReq = new CEMIDAREQUESTD();
            
            if(!eReq.EMIDA_GETPRODUCTOMOVTO((int)prodEmidaBE.IID, CurrentUserID.CurrentUser.IID, ref auxPrdouctId, null))
            {

                MessageBox.Show("Ocurrio un error al intentar obtener el producto " + eReq.IComentario);
                return false;
            }
            
            
            if (!eReq.EMIDA_GENERARVENTA((int)prodEmidaBE.IID, CurrentUserID.CurrentUser.IID, m_ClienteId, auxPrdouctId, decimal.Parse(emidaReq.IAMOUNT), emidaReq.IID, emidaReq.IINVOICENO, emidaReq.IACCOUNTID,"N", emidaReq.ICOMISION, ref auxDoctoId, ref auxMovtoId, null))
            {
                MessageBox.Show("Ocurrio un error al intentar guardar la venta, asegurese de que no tiene demasiadas ventas pendientes " );
                return false;
            }

            if (m_Docto == null)
            {
                m_Docto = new CDOCTOBE();
                m_Docto.IID = auxDoctoId;
                m_Docto = doctoD.seleccionarDOCTO(m_Docto, null);

                if (m_Docto == null)
                {

                    MessageBox.Show("Ocurrio un error al consultar la venta " + doctoD.IComentario);
                    return false;
                }
            }

            return true;
        }


        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return true;
        }


        private bool ValidateTxtNum()
        {
            if (IsDigitsOnly(txtNum1.Text) && IsDigitsOnly(txtNum2.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string getError51Message(string resp, string h2h)
        {
            if (resp.IndexOf("Invalid Amount", StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                return "Monto Invalido, actualice productos.";
            }
            else if(h2h == "16")
            {
                return "(Número ingresado de otra compañia o no valido para la recarga";
            }
            else if (resp.IndexOf("SITE IS DISABLED", StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                return "Sitio deshabilitado, al parecer el servidor de Emida no esta en funcionamiento, \n Favor de llamar al soporte de Emida: \n Distrito Federal y Área Metropolitana 22823822 \n Desde el Interior del País: 01 800 733 0019 \n Opcion 4 customer service.";
            }
            else if (resp.IndexOf("MERCHANT CREDIT REPORT", StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                return "Fondos Insuficientes, favor de comunicarse con las oficinas centrales de FarmaFree!";
            }
            else if (resp.IndexOf("NOT ACTIVATED Transaccion Duplicada", StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                return "Transacción duplicada, esta operación ya habia sido realizada!";
            }
            else if (resp.IndexOf("NOT ACTIVATED Telefono invalido", StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                return "El número de telefono ingresado no es valido!";
            }
            else if (resp.IndexOf("NOT ACTIVATED NO XML RESPONSE", StringComparison.CurrentCultureIgnoreCase) != -1 ||
                resp.IndexOf("NOT ACTIVATED", StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                return "Proveedor no disponible!";
            }
            else if (resp.IndexOf("Mantenimiento en curso", StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                return "Proveedor no disponible, se encuentra actualmente en mantenimiento!";
            }



            return "Error, favor de actualizar los productos!";
        }


        private bool LlamadoEmida(ref List<CLLAMADOEMIDABE> listLlamados, ref CEMIDAREQUESTBE emidaReq, CCAJABE cajaBE, ref bool revisarResponseCode)
        {

            //MessageBox.Show("El consecutivo es " + iConsecutivo.ToString());
            //string version, string siteId, string clerkId, string productId, string accountId, string amount, string invoiceNo, string languageOption)
            DateTime inicio = DateTime.Now, fin = DateTime.Now;
            CLLAMADOEMIDABE cLlamadoEmidaBE = new CLLAMADOEMIDABE();
            TimeSpan duracion;

            bool bTimeOut = false;

            int numeroIntentos = 4;

            //CEMIDAREQUESTD eReq = new CEMIDAREQUESTD();

            DateTime inicioLook = DateTime.Now, finLook = DateTime.Now;

            CEMIDAREQUESTBE emidaReqLook = new CEMIDAREQUESTBE();

            if (!WSEmida.PinDistSale(ref emidaReq, emidaReq.IVERSION, emidaReq.ISITEID, emidaReq.ICLERKID, emidaReq.IPRODUCTID, emidaReq.IACCOUNTID, emidaReq.IAMOUNT, emidaReq.IINVOICENO, emidaReq.ILANGUAGEOPTION, ref inicio, ref fin, ref bTimeOut, ref inicioLook, ref finLook, ref emidaReqLook, CurrentUserID.CurrentParameters.ITIMEOUTPINDISTSALE))
            {
                duracion = fin - inicio;

                cLlamadoEmidaBE = new CLLAMADOEMIDABE();
                cLlamadoEmidaBE.IINICIO = inicio;
                cLlamadoEmidaBE.IFIN = fin;
                cLlamadoEmidaBE.IDURACION = (int)duracion.TotalMilliseconds;
                cLlamadoEmidaBE.IEMIDAREQUESTID = emidaReq.IID;
                cLlamadoEmidaBE.IOPERACION = "PinDistSale";
                cLlamadoEmidaBE.IPIN = emidaReq.IPIN;
                cLlamadoEmidaBE.IRESPONSECODE = emidaReq.IRESPONSECODE;
                listLlamados.Add(cLlamadoEmidaBE);

               

                return false;
            }


            duracion = fin - inicio;


            //emidaReq.IRESPONSECODE = "32";//deleteme

            cLlamadoEmidaBE = new CLLAMADOEMIDABE();
            cLlamadoEmidaBE.IINICIO = inicio;
            cLlamadoEmidaBE.IFIN = fin;
            cLlamadoEmidaBE.IDURACION = (int)duracion.TotalMilliseconds;
            cLlamadoEmidaBE.IEMIDAREQUESTID = emidaReq.IID;
            cLlamadoEmidaBE.IOPERACION = "PinDistSale";
            cLlamadoEmidaBE.IPIN = emidaReq.IPIN;
            cLlamadoEmidaBE.IRESPONSECODE = emidaReq.IRESPONSECODE;
            listLlamados.Add(cLlamadoEmidaBE);



            if(bTimeOut )
            {
                duracion = finLook - inicioLook;
                cLlamadoEmidaBE = new CLLAMADOEMIDABE();
                cLlamadoEmidaBE.IINICIO = inicioLook;
                cLlamadoEmidaBE.IFIN = finLook;
                cLlamadoEmidaBE.IDURACION = (int)duracion.TotalMilliseconds;
                cLlamadoEmidaBE.IEMIDAREQUESTID = emidaReq.IID;
                cLlamadoEmidaBE.IOPERACION = "LookUpTransactionByInvoice";
                cLlamadoEmidaBE.IPIN = emidaReqLook.IPIN == null ? "" : emidaReqLook.IPIN ;
                cLlamadoEmidaBE.IRESPONSECODE = emidaReqLook.IRESPONSECODE == null ? "" : emidaReqLook.IRESPONSECODE;
                listLlamados.Add(cLlamadoEmidaBE);

                numeroIntentos--;






                emidaReq.IPIN = emidaReqLook.IPIN;
                emidaReq.ICONTROLNO = emidaReqLook.ICONTROLNO;
                emidaReq.ICARRIERCONTROLNO = emidaReqLook.ICARRIERCONTROLNO;
                emidaReq.ICUSTOMERSERVICENO = emidaReqLook.ICUSTOMERSERVICENO;
                emidaReq.ITRANSACTIONDATETIME = emidaReqLook.ITRANSACTIONDATETIME;
                emidaReq.IRESULTCODE = emidaReqLook.IRESULTCODE;
                emidaReq.IRESPONSEMESSAGE = emidaReqLook.IRESPONSEMESSAGE;
                emidaReq.ITRANSACTIONID = emidaReqLook.ITRANSACTIONID;
                emidaReq.IH2HRESULTCODE = emidaReqLook.IH2HRESULTCODE;
                emidaReq.IRESPONSECODE = emidaReqLook.IRESPONSECODE;

            }

            


            int count = 0;
            do
            {
                //emidaReq.IRESPONSECODE = "00"; emidaReq.IH2HRESULTCODE = "294";
                if (emidaReq.IRESPONSECODE == "00")
                {
                    if (emidaReq.IH2HRESULTCODE == "294")
                    {
                        MessageBox.Show("Al parecer la recarga que intentas realizar se encuentra duplicada");
                       // CancelarVentaActual();
                        return false;
                    }

                    

                    return true;
                }
                else if (emidaReq.IRESPONSECODE == "32"  )
                {

                    DateTime cuandoDebeIniciar = fin.AddMilliseconds(10000);
                    if(bTimeOut)
                    {
                        cuandoDebeIniciar = finLook.AddMilliseconds(10000);
                    }
                    /*else if(count == 0)
                    {
                        cuandoDebeIniciar = null;
                    }*/



                    if (bTimeOut)
                        bTimeOut = false;

                    if (!WSEmida.LookUpTransactionByInvoice(ref emidaReq, emidaReq.IVERSION, emidaReq.ISITEID, emidaReq.ICLERKID, emidaReq.IINVOICENO, ref inicio, ref fin, cuandoDebeIniciar))
                    {
                        duracion = fin - inicio;
                        cLlamadoEmidaBE = new CLLAMADOEMIDABE();
                        cLlamadoEmidaBE.IINICIO = inicio;
                        cLlamadoEmidaBE.IFIN = fin;
                        cLlamadoEmidaBE.IDURACION = (int)duracion.TotalMilliseconds;
                        cLlamadoEmidaBE.IEMIDAREQUESTID = emidaReq.IID;
                        cLlamadoEmidaBE.IOPERACION = "LookUpTransactionByInvoice";
                        cLlamadoEmidaBE.IPIN = emidaReq.IPIN == null ? "" : emidaReq.IPIN;
                        cLlamadoEmidaBE.IRESPONSECODE = emidaReq.IRESPONSECODE == null ? "" : emidaReq.IRESPONSECODE;
                        listLlamados.Add(cLlamadoEmidaBE);

                        return false;
                    }


                    duracion = fin - inicio;
                    cLlamadoEmidaBE = new CLLAMADOEMIDABE();
                    cLlamadoEmidaBE.IINICIO = inicio;
                    cLlamadoEmidaBE.IFIN = fin;
                    cLlamadoEmidaBE.IDURACION = (int)duracion.TotalMilliseconds;
                    cLlamadoEmidaBE.IEMIDAREQUESTID = emidaReq.IID;
                    cLlamadoEmidaBE.IOPERACION = "LookUpTransactionByInvoice";
                    cLlamadoEmidaBE.IPIN = emidaReq.IPIN == null ? "" : emidaReq.IPIN;
                    cLlamadoEmidaBE.IRESPONSECODE = emidaReq.IRESPONSECODE == null ? "" : emidaReq.IRESPONSECODE;
                    listLlamados.Add(cLlamadoEmidaBE);

                }
                count++;

                //emidaReq.IRESPONSECODE = "00"; emidaReq.IH2HRESULTCODE = "294";
            }
            while (emidaReq.IRESPONSECODE != "00" && count < numeroIntentos);

            revisarResponseCode = true;

            return emidaReq.IRESPONSECODE == "00";

           /* if (emidaReq.IRESPONSECODE != "00")
            {
                CEMIDARESPCODEBE emidaRespCode = new CEMIDARESPCODEBE();
                emidaRespCode.ICODIGO = int.Parse(emidaReq.IRESPONSECODE);
                emidaRespCode = eReq.seleccionarEMIDARESPCODE(emidaRespCode, null);
                if (emidaRespCode.ICODIGO == 51)
                {

                    string strMensaje51 = getError51Message(emidaReq.IRESPONSEMESSAGE, emidaReq.IH2HRESULTCODE);
                    if (strMensaje51 == "Error, favor de actualizar los productos!")
                    {

                        if (MessageBox.Show("Ocurrio el error con codigo " + emidaRespCode.ICODIGO + ": " + emidaRespCode.IMENSAJECLIENTE + ":\n " + strMensaje51 + " \n ¿Desea actualizar los productos?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            actualizaEmidaProductosYCarriers();
                        }
                    }
                    else
                    {

                        MessageBox.Show("Ocurrio el error con codigo " + emidaRespCode.ICODIGO + ": " + emidaRespCode.IMENSAJECLIENTE + ":\n" + strMensaje51);
                    }
                }
                else
                {
                    MessageBox.Show("Ocurrio el error con codigo " + emidaRespCode.ICODIGO + ": " + emidaRespCode.IMENSAJECLIENTE);
                }

                CancelarVentaActual();
                this.Close();
            }*/

        }



        private void button1_Click(object sender, EventArgs e)
        {
            
            List<CLLAMADOEMIDABE> listLlamados = new List<CLLAMADOEMIDABE>();

            try
            {



                if (!ValidateTxtNum())
                {
                    MessageBox.Show("El campo de teléfono solo puede contener números");
                    this.txtNum1.Focus();
                    return;
                }
                else if (txtNum1.Text == "" || txtNum1.Text.Trim().Length != 10)
                {
                    MessageBox.Show("Porfavor ingrese un numero de 10 digitos , no vacio");
                    return;
                }
                else if (txtNum1.Text != txtNum2.Text)
                {
                    MessageBox.Show("Los números ingresados no coinciden el uno al otro, ingrese un mismo número");
                    return;
                }
                else if (CBCompaniaEmida.Text == "" || CBCompaniaEmida.Text == null)
                {
                    MessageBox.Show("No se pudo cargar los productos de Emida, contacte a soporte!");
                    return;
                }



                CEMIDAREQUESTBE emidaReq = new CEMIDAREQUESTBE();
                emidaReq = ObtenerDatosCapturados();
                emidaReq.IESSERVICIO = "N";
                CEMIDAREQUESTD eReq = new CEMIDAREQUESTD();
                emidaReq = eReq.AgregarEMIDAREQUEST(emidaReq, null);
                int auxMovtoId = 0;


                if (!AgregarBorradorVenta(emidaReq, ref auxMovtoId))
                {
                    return;
                }



                emidaReq.IMOVTOID = auxMovtoId;

                if (!eReq.CambiarEMIDAREQUEST_MOVTOID(emidaReq, null))
                {

                    MessageBox.Show("Ocurrio un error al referenciar el movimiento");
                    return;
                }




                CLLAMADOEMIDAD cLlamadoEmidaD = new CLLAMADOEMIDAD();

                //caja
                long idCaja = CurrentUserID.CurrentCompania.IEM_CAJA;
                CCAJABE cajaBE = new CCAJABE();
                CCAJAD cajaD = new CCAJAD();
                cajaBE.IID = idCaja;
                cajaBE = cajaD.seleccionarCAJA(cajaBE, null);

                if (cajaBE == null)
                {
                    MessageBox.Show("Caja no existe");
                    return;
                }




                bool revisarResponseCode = false;
                bool bRes = LlamadoEmida(ref  listLlamados, ref  emidaReq, cajaBE, ref revisarResponseCode);

                if (!eReq.CambiarEMIDAREQUEST(emidaReq, emidaReq, null))
                {

                    MessageBox.Show("Ocurrio un error al guardar el resultado de la recarga");
                }

                foreach (CLLAMADOEMIDABE cLlamadoEmidaBE in listLlamados)
                {
                    cLlamadoEmidaD.AgregarLLAMADOEMIDAD(cLlamadoEmidaBE, null);
                }
                
                
                if (bRes == true)
                {
                    MessageBox.Show("Recarga realizada con éxito!");
                    
                    WFPagosBasico wp = new WFPagosBasico(m_Docto, cajaBE, false, m_Docto.ITOTAL, null, tipoTransaccionV.t_venta, "N", null, false, true, 0);
                    wp.esRecarga = true;
                    wp.m_bCerrarVenta = true;
                    wp.ShowDialog();
                    if (wp.m_bPagoCompleto)
                    {

                        this.CerrarVenta((wp.m_generarFacturaElectronica && !wp.m_surtidoPostpuesto), wp.m_bPagoPorxCredito, true, false);
                    }

                    wp.Dispose();
                    this.Close();
                }
                else
                {

                    CancelarVentaActual();

                    if (emidaReq.IRESPONSECODE != "00")
                    {
                        CEMIDARESPCODEBE emidaRespCode = new CEMIDARESPCODEBE();
                        emidaRespCode.ICODIGO = int.Parse(emidaReq.IRESPONSECODE);
                        emidaRespCode = eReq.seleccionarEMIDARESPCODE(emidaRespCode, null);
                        if (emidaRespCode.ICODIGO == 51)
                        {

                            string strMensaje51 = getError51Message(emidaReq.IRESPONSEMESSAGE, emidaReq.IH2HRESULTCODE);
                            if (strMensaje51 == "Error, favor de actualizar los productos!")
                            {

                                if (MessageBox.Show("Ocurrio el error con codigo " + emidaRespCode.ICODIGO + ": " + emidaRespCode.IMENSAJECLIENTE + ":\n " + strMensaje51 + " \n ¿Desea actualizar los productos?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    actualizaEmidaProductosYCarriers();
                                }
                            }
                            else
                            {

                                MessageBox.Show("Ocurrio el error con codigo " + emidaRespCode.ICODIGO + ": " + emidaRespCode.IMENSAJECLIENTE + ":\n" + strMensaje51);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ocurrio el error con codigo " + emidaRespCode.ICODIGO + ": " + emidaRespCode.IMENSAJECLIENTE);
                        }

                    }


                    


                }


            }
            catch(Exception exc)
            {
                MessageBox.Show("No se pudo realizar la operación, verifique su conexión a internet o llame a Soporte 12 \n\n Exception: " + exc + exc.Message +  exc.StackTrace);
                CancelarVentaActual();
                this.Close();

            }
            
        }


        private bool CancelarVentaActual()
        {
            CPuntoDeVentaD pvd = new CPuntoDeVentaD();
            if (!pvd.CancelarVenta(m_Docto, CurrentUserID.CurrentUser, null))
            {
                MessageBox.Show("No se pudo cancelar la venta, intente despues" + pvd.IComentario);
                return false;
            }
            return true;
        }

        private void actualizaEmidaProductosYCarriers()
        {
            string strCometnario = "";
            if (!DBEmida.RefrescarEmidaProducts(ref strCometnario) || !DBEmida.RefrescarCarriers(ref strCometnario))
            {
                MessageBox.Show(strCometnario);
            }
            else
            {
                CPARAMETROD parametroD = new CPARAMETROD();
                CPARAMETROBE parametroBE = parametroD.seleccionarPARAMETROActual(null);
                parametroBE.IFECHAACTUALIZACIONEMIDA = DateTime.Today;
                if (!parametroD.CambiarFECHAACTUALIZACIONEMIDA(parametroBE, parametroBE, null))
                {
                    MessageBox.Show(" Error al actualizar la fecha de actualizacion de emida " + parametroD.IComentario);

                }
                else
                {

                    CurrentUserID.CurrentParameters.IFECHAACTUALIZACIONEMIDA = parametroBE.IFECHAACTUALIZACIONEMIDA;
                    MessageBox.Show("Carriers y otra información de recargas ha sido actualizada");
                }



            }
        }

        private void WFRecargaCantidadEmida_Load(object sender, EventArgs e)
        {

            string comentario = "";
            //DBEmida.RefrescarEmidaProductsServicios(ref comentario);

            //DBEmida.RefrescarEmidaComisionesServicios(ref comentario);
            //DBEmida.RefrescarCarriersServicios(ref comentario);


            if (CurrentUserID.CurrentUser.ICLERKPAGOSERVICIOSID == 0)
            {

                MessageBox.Show("Este usuario no tiene clerkid asignado");
                this.Close();
                return;
            }

            if (CurrentUserID.CurrentParameters.IFECHAACTUALIZACIONEMIDA == null || CurrentUserID.CurrentParameters.IFECHAACTUALIZACIONEMIDA.Date < DateTime.Today )
            {
                actualizaEmidaProductosYCarriers();
            }
            this.cARRIERTableAdapter.Fill(this.dSPuntoDeVentaAux2.CARRIER,"N");
            this.cbCantidadEmida.Enabled = true;
            try
            {
                if (CBCompaniaEmida.SelectedValue != null)
                {
                    this.eMIDAPRODUCTTableAdapter.Fill(this.dSPuntoDeVentaAux2.EMIDAPRODUCT, CBCompaniaEmida.SelectedValue.ToString(),"N");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            if (cbCantidadEmida.SelectedValue != null)
            {
                TBMonto.Text = this.eMIDAPRODUCTTableAdapter.GetAmountProduct(cbCantidadEmida.SelectedValue.ToString());
            }
        }

        private void CBCompaniaEmida_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbCantidadEmida.Enabled = true;
            if (CBCompaniaEmida.SelectedValue == null )
                return;

            this.eMIDAPRODUCTTableAdapter.Fill(this.dSPuntoDeVentaAux2.EMIDAPRODUCT,  CBCompaniaEmida.SelectedValue.ToString()  ,"N");

            if(cbCantidadEmida.SelectedValue != null)
                TBMonto.Text = this.eMIDAPRODUCTTableAdapter.GetAmountProduct(cbCantidadEmida.SelectedValue.ToString());
        }

        private void cbCantidadEmida_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TBMonto.Text = this.eMIDAPRODUCTTableAdapter.GetAmountProduct(cbCantidadEmida.SelectedValue.ToString());

            }
            catch
            {
                TBMonto.Text = "1.000";
                return;
            }

        }



        private void SeleccionaCliente()
        {
            iPos.Catalogos.WFClientes look = new iPos.Catalogos.WFClientes();
            look.m_bSelecionarRegistro = true;
            look.ShowDialog();
            
            DataRow dr = look.m_rtnDataRow;

            look.Dispose();
            GC.SuppressFinalize(look);


            if (dr != null)
            {
                LBClienteNombre.Text = dr["NOMBRE"].ToString().Trim();
                m_ClienteId = (long)dr["ID"];
            }

        }

        private void BTCliente_Click(object sender, EventArgs e)
        {
            SeleccionaCliente();
        }





        private void CerrarVenta(bool generarFacturaElectronica, bool bEsCredito, bool bAlreadyClosedInDB, bool bImprimirDoble)
        {

            CPuntoDeVentaD pvd = new CPuntoDeVentaD();

            Boolean bImprimirDoblePorParametroYTipo = CurrentUserID.CurrentParameters.IDOBLECOPIAREMISION != null && CurrentUserID.CurrentParameters.IDOBLECOPIAREMISION.Equals("S") &&
                                                      m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTA && !generarFacturaElectronica && CurrentUserID.CurrentUser.ITICKETLARGO.Equals("S");

            Boolean bReimpresionesConMarca = CurrentUserID.CurrentParameters.IREIMPRESIONESCONMARCA != null && CurrentUserID.CurrentParameters.IREIMPRESIONESCONMARCA.Equals("S");

            if (!bAlreadyClosedInDB)
                pvd.CerrarVenta(m_Docto, null);

            if (bAlreadyClosedInDB || pvd.IComentario == "" || pvd.IComentario == null)
            {


                if (generarFacturaElectronica)
                {
                    imprimirFacturaElectronica();

                    if (bImprimirDoble)
                        imprimirFacturaElectronica();
                }

                if (!generarFacturaElectronica)
                {

                    if ((bImprimirDoble || bImprimirDoblePorParametroYTipo) && CurrentUserID.CurrentUser.ITICKETLARGO.Equals("S"))
                    {
                        PosPrinter.ImprimirTicket(m_Docto.IID, 0, false, false, 2);
                    }
                    else
                    {
                        PosPrinter.ImprimirTicket(m_Docto.IID);
                    }



                    if ((bImprimirDoble || bImprimirDoblePorParametroYTipo) && !CurrentUserID.CurrentUser.ITICKETLARGO.Equals("S"))
                        PosPrinter.ImprimirTicket(m_Docto.IID, 0, false, bReimpresionesConMarca, 1);
                }
                else if (CurrentUserID.CurrentParameters.IRECIBOLARGOCONFACTURA.Equals("S"))
                {

                    imprimirTicketFacturaElectronica();
                }

                // imprimir segun el tipo
                if (m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_TRASPASO_ENVIO)
                {

                    for (int iy = 0; iy < CurrentUserID.CurrentParameters.IDOBLECOPIATRASLADO - 1; iy++)
                    {
                        PosPrinter.ImprimirTicket(m_Docto.IID);
                    }
                }
                else if ((bEsCredito || m_Docto.ITIPODOCTOID == DBValues._DOCTO_TIPO_VENTAAPARTADO) && (CurrentUserID.CurrentUser.ITICKETLARGOCREDITO == null || !CurrentUserID.CurrentUser.ITICKETLARGOCREDITO.Equals("S")))
                {
                    for (int iv = 0; iv < CurrentUserID.CurrentParameters.IDOBLECOPIACREDITO - 1; iv++)
                    {
                        PosPrinter.ImprimirTicket(m_Docto.IID);
                    }
                }




                if (pvd.ContieneRecargas(m_Docto, null))
                {

                    PosPrinter.ImprimirTicket(m_Docto.IID, Ticket._OPCION_IMPRESION_RECARGAS);
                }

                HiloExistencias._IFLAGENVIAREXISTENCIASEVENTOS++;
            }
            else
            {
                MessageBox.Show("ERRORES: " + pvd.IComentario.Replace("%", "\n"));
            }
        }



        private bool imprimirFacturaElectronica()
        {

            bool retorno;

            CDOCTOD doctoD = new CDOCTOD();
            m_Docto = doctoD.seleccionarDOCTO(m_Docto, null);

            if ((bool)m_Docto.isnull["IFOLIOSAT"] || (bool)m_Docto.isnull["IESTATUSDOCTOID"]
                || m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_COMPLETO || m_Docto.IFOLIOSAT <= 0)
            {
                MessageBox.Show("No se puede imprimir la factura electronica , cheque que se haya generado la factura electronica de este registro");
                return false;
            }

           // 2- modifica tmabien el procedimiento donde le pusimos subtitpodoctoid = 17  a subtipodoctoid = 21


            WFFacturaElectronica fe = new WFFacturaElectronica(this.m_Docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_GENERARPDF, null, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);
            return retorno;
        }




        private bool imprimirTicketFacturaElectronica()
        {

            bool retorno;

            CDOCTOD doctoD = new CDOCTOD();
            m_Docto = doctoD.seleccionarDOCTO(m_Docto, null);

            if ((bool)m_Docto.isnull["IFOLIOSAT"] || (bool)m_Docto.isnull["IESTATUSDOCTOID"]
                || m_Docto.IESTATUSDOCTOID != DBValues._DOCTO_ESTATUS_COMPLETO || m_Docto.IFOLIOSAT <= 0)
            {
                MessageBox.Show("No se puede imprimir la factura electronica , cheque que se haya generado la factura electronica de este registro");
                return false;
            }


            WFFacturaElectronica fe = new WFFacturaElectronica(this.m_Docto, CurrentUserID.CurrentParameters, WFFacturaElectronica._MODE_DIALOGO_FACTURA_ELECTRONICA_IMPRIMIRTICKET, null, CurrentUserID.CurrentParameters.IPREGUNTARDATOSENTREGA);
            CUSUARIOSD usuariosD = new CUSUARIOSD(); fe.setDesglosaKits(usuariosD.UsuarioTienePermisos((int)CurrentUserID.CurrentUser.IID, DBTN.DERECHO_DESGLOSE_KITS, null));
            fe.ShowDialog();
            retorno = fe.m_facturacionRealizada;
            fe.Dispose();
            GC.SuppressFinalize(fe);
            return retorno;
        }

        private void txtNum1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void txtNum2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void LBClienteNombre_Click(object sender, EventArgs e)
        {

        }

        private void btnRefreshCarriers_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea actualizar los Carrier y Productos ", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                actualizaEmidaProductosYCarriers();
            }
        }


        /*private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.eMIDAPRODUCTTableAdapter.Fill(this.dSPuntoDeVentaAux2.EMIDAPRODUCT, cARRIERIDToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }*/
        /*public decimal m_dMontoRecarga;
        bool m_bFocus;
        public string m_compania;
        bool m_bSeleccionarCompania;
        decimal m_defaultValue = 1;
        public WFRecargaCantidadEmida( bool bFocus, bool bSeleccionarCompania)
        {
            InitializeComponent();
            m_dMontoRecarga = 0;
            m_bFocus = bFocus;
            m_bSeleccionarCompania = bSeleccionarCompania;

            
        }


        public WFRecargaCantidadEmida(bool bFocus, bool bSeleccionarCompania, decimal defaultValue) : this(bFocus, bSeleccionarCompania)
        {
            m_defaultValue = defaultValue;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            m_dMontoRecarga = decimal.Parse(TBCantidad.Text);
            if (CBCompania.SelectedIndex < 0 && m_bSeleccionarCompania)
            {
                MessageBox.Show("Porfavor seleccione la compañia");
                return;
            }
            else if (CBCompania.SelectedIndex >= 0)
            {
                m_compania = CBCompania.SelectedItem.ToString();
            }
            this.Close();
        }

        private void TBCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            ComboBox cbcarrier = null;

            if (CurrentUserID.CurrentParameters.ISERVICIOSEMIDA != null && CurrentUserID.CurrentParameters.ISERVICIOSEMIDA == "S")
            {
                cbcarrier = CBCompaniaEmida;
            }
            else
            {

                cbcarrier = CBCompania;
            }
            

            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                m_dMontoRecarga = decimal.Parse(TBCantidad.Text);

                if (cbcarrier.SelectedIndex < 0 && m_bSeleccionarCompania)
                {
                    MessageBox.Show("Porfavor seleccione la compañia");
                    return;
                }
                else if (cbcarrier.SelectedIndex >= 0)
                {
                    m_compania = cbcarrier.SelectedItem.ToString();
                }

                this.Close();
            }
        }

        private void WFRecargaCantidadEmida_Load(object sender, EventArgs e)
        {
            

            this.lblCompania.Visible = m_bSeleccionarCompania;

            if (m_bSeleccionarCompania)
            {

                if (CurrentUserID.CurrentParameters.ISERVICIOSEMIDA != null && CurrentUserID.CurrentParameters.ISERVICIOSEMIDA == "S")
                {
                    // TODO: This line of code loads data into the 'dSPuntoDeVentaAux2.CARRIER' table. You can move, or remove it, as needed.
                    this.cARRIERTableAdapter.Fill(this.dSPuntoDeVentaAux2.CARRIER);

                    this.CBCompaniaEmida.Visible = true;
                    this.CBCompania.Visible = false;
                }
                else
                {
                    this.CBCompaniaEmida.Visible = false;
                    this.CBCompania.Visible = true;
                }
            }


            if (m_bFocus)
            {
                this.TBCantidad.Text = this.m_defaultValue.ToString();
                this.TBCantidad.SelectAll();
                
            }
        }

        private void TBCantidad_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if ((e.KeyCode == Keys.Decimal || e.KeyCode == Keys.OemPeriod) && TBCantidad.SelectionLength == TBCantidad.Text.Length)
            {
                TBCantidad.Text = "0.000";
            }
        }*/
    }
}
