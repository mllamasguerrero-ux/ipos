using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iPosBusinessEntity;
using iPosData;
using FirebirdSql.Data.FirebirdClient;
using System.Windows.Forms;

namespace iPos
{
    public class DBEmida
    {
        public static bool RefrescarCarriers(ref string strComentario)
        {

            strComentario = "";

            long idCaja = CurrentUserID.CurrentCompania.IEM_CAJA;
            CCAJABE cajaBE = new CCAJABE();
            CCAJAD cajaD = new CCAJAD();
            cajaBE.IID = idCaja;
            cajaBE = cajaD.seleccionarCAJA(cajaBE, null);

            if(cajaBE == null)
            {
                strComentario = "Caja no existe";
                return false;
            }

            if(cajaBE.ITERMINAL == null || cajaBE.ITERMINAL.Trim().Equals(""))
            {
                strComentario = "No tiene asociada una terminal de pago de servicios";
                return false;
            }

            List<CCARRIERBE> listCarrier = new List<CCARRIERBE>();
            try
            {
                 listCarrier = WSEmida.GetCarrierList("01", cajaBE.ITERMINAL, "", "", "", "");

            }
            catch(Exception e)
            {
                MessageBox.Show("No se pudieron obtener y actualizar los carriers del servidor de Emida, verifique su conexión a internet o llame a soporte! 1 " + e + e.Message + e.StackTrace);
                return false;
            }

            if(listCarrier == null)
            {

                strComentario = "Ocurrio un erro al obtener los carriers";
                return false;
            }

            CCARRIERD carrierD = new CCARRIERD();

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            try
            {

                fConn.Open();
                fTrans = fConn.BeginTransaction();

                if(!carrierD.DesactivarTodosCARRIERD("N",fTrans))
                {

                    fTrans.Rollback();
                    fConn.Close();
                    strComentario += carrierD.IComentario;
                    return false;
                }

                foreach (CCARRIERBE carrier in listCarrier)
                {

                    CCARRIERBE buffer = new CCARRIERBE();
                    buffer.ICARRIERID = carrier.ICARRIERID;
                    buffer.IESSERVICIO = "N";

                    buffer = carrierD.seleccionarCARRIERxCARRIERID(buffer, fTrans);
                    if (buffer != null)
                    {

                        CCARRIERBE buffer2 = carrier;
                        buffer2.IID = buffer.IID;
                        buffer2.IACTIVO = "S";
                        buffer2.IESSERVICIO = "N";

                        if (!carrierD.CambiarCARRIERD(buffer2, buffer2, fTrans))
                        {
                            fTrans.Rollback();
                            fConn.Close();
                            strComentario += carrierD.IComentario;
                            return false;
                        }

                    }
                    else
                    {

                        CCARRIERBE buffer2 = carrier;
                        buffer2.IACTIVO = "S";
                        buffer2.IESSERVICIO = "N";

                        if (carrierD.AgregarCARRIERD(buffer2, fTrans) == null)
                        {
                            fTrans.Rollback();
                            fConn.Close();
                            strComentario += carrierD.IComentario;
                            return false;
                        }
                    }


                }

                fTrans.Commit();
                fConn.Close();
            }
            catch(Exception ex)
            {

                fTrans.Rollback();
                fConn.Close();
                strComentario += ex.Message;
                return false;
            }
            finally
            {

                fConn.Close();
            }

            return true;

        }




        public static bool RefrescarCarriersServicios(ref string strComentario)
        {

            strComentario = "";

            long idCaja = CurrentUserID.CurrentCompania.IEM_CAJA;
            CCAJABE cajaBE = new CCAJABE();
            CCAJAD cajaD = new CCAJAD();
            cajaBE.IID = idCaja;
            cajaBE = cajaD.seleccionarCAJA(cajaBE, null);

            if (cajaBE == null)
            {
                strComentario = "Caja no existe";
                return false;
            }

            if (cajaBE.ITERMINALSERVICIOS == null || cajaBE.ITERMINALSERVICIOS.Trim().Equals(""))
            {
                strComentario = "No tiene asociada una terminal de pago de servicios";
                return false;
            }

            List<CCARRIERBE> listCarrier = new List<CCARRIERBE>();
            try
            {
                listCarrier = WSEmida.GetCarrierList("01", cajaBE.ITERMINALSERVICIOS, "", "", "", "");

            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudieron obtener y actualizar los carriers del servidor de Emida, verifique su conexión a internet o llame a soporte! 2 " + e + e.Message + e.StackTrace);
                return false;
            }

            if (listCarrier == null)
            {

                strComentario = "Ocurrio un erro al obtener los carriers";
                return false;
            }

            CCARRIERD carrierD = new CCARRIERD();

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            try
            {

                fConn.Open();
                fTrans = fConn.BeginTransaction();

                if (!carrierD.DesactivarTodosCARRIERD("S", fTrans))
                {

                    fTrans.Rollback();
                    fConn.Close();
                    strComentario += carrierD.IComentario;
                    return false;
                }

                foreach (CCARRIERBE carrier in listCarrier)
                {

                    CCARRIERBE buffer = new CCARRIERBE();
                    buffer.ICARRIERID = carrier.ICARRIERID;
                    buffer.IESSERVICIO = "S";

                    buffer = carrierD.seleccionarCARRIERxCARRIERID(buffer, fTrans);
                    if (buffer != null)
                    {

                        CCARRIERBE buffer2 = carrier;
                        buffer2.IID = buffer.IID;
                        buffer2.IACTIVO = "S";
                        buffer2.IESSERVICIO = "S";

                        if (!carrierD.CambiarCARRIERD(buffer2, buffer2, fTrans))
                        {
                            fTrans.Rollback();
                            fConn.Close();
                            strComentario += carrierD.IComentario;
                            return false;
                        }

                    }
                    else
                    {

                        CCARRIERBE buffer2 = carrier;
                        buffer2.IACTIVO = "S";
                        buffer2.IESSERVICIO = "S";

                        if (carrierD.AgregarCARRIERD(buffer2, fTrans) == null)
                        {
                            fTrans.Rollback();
                            fConn.Close();
                            strComentario += carrierD.IComentario;
                            return false;
                        }
                    }


                }

                fTrans.Commit();
                fConn.Close();
            }
            catch (Exception ex)
            {

                fTrans.Rollback();
                fConn.Close();
                strComentario += ex.Message;
                return false;
            }
            finally
            {

                fConn.Close();
            }

            return true;

        }


        public static string ObtenerTerminal()
        {
            long idCaja = CurrentUserID.CurrentCompania.IEM_CAJA;
            CCAJABE cajaBE = new CCAJABE();
            CCAJAD cajaD = new CCAJAD();
            cajaBE.IID = idCaja;
            cajaBE = cajaD.seleccionarCAJA(cajaBE, null);

            return cajaBE.ITERMINAL;
        }



        public static string ObtenerTerminalServicio()
        {
            long idCaja = CurrentUserID.CurrentCompania.IEM_CAJA;
            CCAJABE cajaBE = new CCAJABE();
            CCAJAD cajaD = new CCAJAD();
            cajaBE.IID = idCaja;
            cajaBE = cajaD.seleccionarCAJA(cajaBE, null);

            return cajaBE.ITERMINALSERVICIOS;
        }

        public static int ObtenerConsecutivoTerminal(ref string strComentario)
        {
            CCAJABE cajaBE = new CCAJABE();
            cajaBE.ITERMINAL = DBEmida.ObtenerTerminal();

            if (cajaBE == null)
            {
                strComentario = "Caja no existe";
                return -1;
            }

            if (cajaBE.ITERMINAL == null || cajaBE.ITERMINAL.Trim().Equals(""))
            {
                strComentario = "No tiene asociada una terminal de pago de servicios";
                return -1;
            }

            
            CEMIDAREQUESTD reqD = new CEMIDAREQUESTD();
            int iConsecutivo = -1;

            if(reqD.TERMINAL_CONSECUTIVO(cajaBE.ITERMINAL, ref iConsecutivo, null))
            {
                return iConsecutivo;
            }
            else
            {
                strComentario = reqD.IComentario;
                return -1;
            }
        }



        public static int ObtenerConsecutivoTerminalServicio(ref string strComentario)
        {
            CCAJABE cajaBE = new CCAJABE();
            cajaBE.ITERMINALSERVICIOS = DBEmida.ObtenerTerminalServicio();

            if (cajaBE == null)
            {
                strComentario = "Caja no existe";
                return -1;
            }

            if (cajaBE.ITERMINALSERVICIOS == null || cajaBE.ITERMINALSERVICIOS.Trim().Equals(""))
            {
                strComentario = "No tiene asociada una terminal de pago de servicios";
                return -1;
            }


            CEMIDAREQUESTD reqD = new CEMIDAREQUESTD();
            int iConsecutivo = -1;

            if (reqD.TERMINALSERVICIO_CONSECUTIVO(cajaBE.ITERMINALSERVICIOS, ref iConsecutivo, null))
            {
                return iConsecutivo;
            }
            else
            {
                strComentario = reqD.IComentario;
                return -1;
            }
        }


        public static bool RefrescarEmidaProducts(ref string strComentario)
        {

            strComentario = "";

            long idCaja = CurrentUserID.CurrentCompania.IEM_CAJA;
            CCAJABE cajaBE = new CCAJABE();
            CCAJAD cajaD = new CCAJAD();
            cajaBE.IID = idCaja;
            cajaBE = cajaD.seleccionarCAJA(cajaBE, null);

            if (cajaBE == null)
            {
                strComentario = "Caja no existe";
                return false;
            }

            if (cajaBE.ITERMINAL == null || cajaBE.ITERMINAL.Trim().Equals(""))
            {
                strComentario = "No tiene asociada una terminal de pago de servicios";
                return false;
            }

            List<CEMIDAPRODEXTBE> listEmidaProducts = new List<CEMIDAPRODEXTBE>();

            try
            {
                listEmidaProducts = WSEmida.GetProductListExt("01", cajaBE.ITERMINAL, "", "", "", "");
            }
            catch(Exception e)
            {
                MessageBox.Show("No se pudo obtener y actualizar la lista de productos de Emida del serviodr de Emida, verifique su conexión a internet o llame a soporte 3 " + e + e.Message + e.StackTrace);
                return false;
            }

            if (listEmidaProducts == null)
            {

                strComentario = "Ocurrio un erro al obtener los carriers";
                return false;
            }

            CEMIDAPRODUCTD emidaProductD = new CEMIDAPRODUCTD();

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            try
            {

                fConn.Open();
                fTrans = fConn.BeginTransaction();

                if (!emidaProductD.DesactivarTodosEMIDAPRODUCTD("N",fTrans))
                {

                    fTrans.Rollback();
                    fConn.Close();
                    strComentario += emidaProductD.IComentario;
                    return false;
                }

                foreach (CEMIDAPRODEXTBE emidaProduct in listEmidaProducts)
                {

                    CEMIDAPRODEXTBE buffer = new CEMIDAPRODEXTBE();
                    buffer.IPRODUCTID = emidaProduct.IPRODUCTID;
                    buffer.IESSERVICIO = "N";

                    buffer = emidaProductD.seleccionarEMIDAPRODUCTxEMIDAPRODUCTID(buffer, fTrans);
                    if (buffer != null)
                    {

                        CEMIDAPRODEXTBE buffer2 = emidaProduct;
                        buffer2.IID = buffer.IID;
                        buffer2.IACTIVO = "S";
                        buffer2.IESSERVICIO = "N";
                        

                        if (!emidaProductD.CambiarEMIDAPRODUCTD(buffer2, buffer2, fTrans))
                        {
                            fTrans.Rollback();
                            fConn.Close();
                            strComentario += emidaProductD.IComentario;
                            return false;
                        }

                    }
                    else
                    {

                        CEMIDAPRODEXTBE buffer2 = emidaProduct;
                        buffer2.IACTIVO = "S";
                        buffer2.IESSERVICIO = "N";

                        if (emidaProductD.AgregarEMIDAPRODUCTD(buffer2, fTrans) == null)
                        {
                            fTrans.Rollback();
                            fConn.Close();
                            strComentario += emidaProductD.IComentario;
                            return false;
                        }
                    }


                }

                fTrans.Commit();
                fConn.Close();
            }
            catch (Exception ex)
            {

                fTrans.Rollback();
                fConn.Close();
                strComentario += ex.Message;
                return false;
            }
            finally
            {

                fConn.Close();
            }

            return true;

        }




        public static bool RefrescarEmidaProductsServicios(ref string strComentario)
        {

            strComentario = "";

            long idCaja = CurrentUserID.CurrentCompania.IEM_CAJA;
            CCAJABE cajaBE = new CCAJABE();
            CCAJAD cajaD = new CCAJAD();
            cajaBE.IID = idCaja;
            cajaBE = cajaD.seleccionarCAJA(cajaBE, null);

            if (cajaBE == null)
            {
                strComentario = "Caja no existe";
                return false;
            }

            if (cajaBE.ITERMINALSERVICIOS == null || cajaBE.ITERMINALSERVICIOS.Trim().Equals(""))
            {
                strComentario = "No tiene asociada una terminal de pago de servicios";
                return false;
            }

            List<CEMIDAPRODEXTBE> listEmidaProducts = new List<CEMIDAPRODEXTBE>();

            try
            {
                listEmidaProducts = WSEmida.GetProductListExt("01", cajaBE.ITERMINALSERVICIOS, "", "", "", "");
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo obtener y actualizar la lista de productos de Emida del serviodr de Emida, verifique su conexión a internet o llame a soporte 4 " + e + e.Message + e.StackTrace);
                return false;
            }

            if (listEmidaProducts == null)
            {

                strComentario = "Ocurrio un erro al obtener los carriers";
                return false;
            }

            CEMIDAPRODUCTD emidaProductD = new CEMIDAPRODUCTD();

            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            try
            {

                fConn.Open();
                fTrans = fConn.BeginTransaction();

                if (!emidaProductD.DesactivarTodosEMIDAPRODUCTD("S",fTrans))
                {

                    fTrans.Rollback();
                    fConn.Close();
                    strComentario += emidaProductD.IComentario;
                    return false;
                }

                foreach (CEMIDAPRODEXTBE emidaProduct in listEmidaProducts)
                {

                    CEMIDAPRODEXTBE buffer = new CEMIDAPRODEXTBE();
                    buffer.IPRODUCTID = emidaProduct.IPRODUCTID;
                    buffer.IESSERVICIO = "S";

                    buffer = emidaProductD.seleccionarEMIDAPRODUCTxEMIDAPRODUCTID(buffer, fTrans);
                    if (buffer != null)
                    {

                        CEMIDAPRODEXTBE buffer2 = emidaProduct;
                        buffer2.IID = buffer.IID;
                        buffer2.IACTIVO = "S";
                        buffer2.IESSERVICIO = "S";


                        if (!emidaProductD.CambiarEMIDAPRODUCTD(buffer2, buffer2, fTrans))
                        {
                            fTrans.Rollback();
                            fConn.Close();
                            strComentario += emidaProductD.IComentario;
                            return false;
                        }

                    }
                    else
                    {

                        CEMIDAPRODEXTBE buffer2 = emidaProduct;
                        buffer2.IACTIVO = "S";
                        buffer2.IESSERVICIO = "S";

                        if (emidaProductD.AgregarEMIDAPRODUCTD(buffer2, fTrans) == null)
                        {
                            fTrans.Rollback();
                            fConn.Close();
                            strComentario += emidaProductD.IComentario;
                            return false;
                        }
                    }


                }

                fTrans.Commit();
                fConn.Close();
            }
            catch (Exception ex)
            {

                fTrans.Rollback();
                fConn.Close();
                strComentario += ex.Message;
                return false;
            }
            finally
            {

                fConn.Close();
            }

            return true;

        }




        public static bool RefrescarEmidaComisionesServicios(ref string strComentario)
        {


            strComentario = "";

            long idCaja = CurrentUserID.CurrentCompania.IEM_CAJA;
            CCAJABE cajaBE = new CCAJABE();
            CCAJAD cajaD = new CCAJAD();
            cajaBE.IID = idCaja;
            cajaBE = cajaD.seleccionarCAJA(cajaBE, null);

            if (cajaBE == null)
            {
                strComentario = "Caja no existe";
                return false;
            }

            if (cajaBE.ITERMINALSERVICIOS == null || cajaBE.ITERMINALSERVICIOS.Trim().Equals(""))
            {
                strComentario = "No tiene asociada una terminal de pago de servicios";
                return false;
            }

            List<CEMIDAPRODEXTBE> listEmidaProducts = new List<CEMIDAPRODEXTBE>();
            CEMIDAPRODUCTD emidaProductD = new CEMIDAPRODUCTD();


            listEmidaProducts = emidaProductD.seleccionarEMIDAPRODUCTListPorESSERVICIO("S", null);

            if (listEmidaProducts == null || listEmidaProducts.Count == 0)
                return true;


            CEMIDACOMISIOND emidaComisionD = new CEMIDACOMISIOND();



            FbConnection fConn = new FbConnection(ConexionesBD.ConexionBD.ConexionString());
            FbTransaction fTrans = null;
            try
            {

                fConn.Open();
                fTrans = fConn.BeginTransaction();

                if (!emidaComisionD.DesactivarTodosEMIDACOMISIOND(fTrans))
                {

                    fTrans.Rollback();
                    fConn.Close();
                    strComentario += emidaProductD.IComentario;
                    return false;
                }

                foreach (CEMIDAPRODEXTBE emidaProduct in listEmidaProducts)
                {


                    List<CEMIDACOMISIONBE> comisionBEList =  WSEmida.GetProductUFee("01", emidaProduct.IPRODUCTID);
                    if (comisionBEList == null || comisionBEList.Count == 0)
                        continue;

                    CEMIDACOMISIONBE comisionBE = comisionBEList[0];



                    CEMIDACOMISIONBE buffer = new CEMIDACOMISIONBE();
                    buffer.IPRODUCTID = comisionBE.IPRODUCTID;

                    buffer = emidaComisionD.seleccionarEMIDACOMISIONxEMIDAPRODUCTID(buffer, fTrans);
                    if (buffer != null)
                    {

                        CEMIDACOMISIONBE buffer2 = comisionBE;
                        buffer2.IID = buffer.IID;
                        buffer2.IACTIVO = "S";


                        if (!emidaComisionD.CambiarEMIDACOMISIOND(buffer2, buffer2, fTrans))
                        {
                            fTrans.Rollback();
                            fConn.Close();
                            strComentario += emidaComisionD.IComentario;
                            return false;
                        }

                    }
                    else
                    {

                        CEMIDACOMISIONBE buffer2 = comisionBE;
                        buffer2.IACTIVO = "S";


                        if (emidaComisionD.AgregarEMIDACOMISIOND(buffer2, fTrans) == null)
                        {
                            fTrans.Rollback();
                            fConn.Close();
                            strComentario += emidaComisionD.IComentario;
                            return false;
                        }
                    }


                }

                fTrans.Commit();
                fConn.Close();
            }
            catch (Exception ex)
            {

                fTrans.Rollback();
                fConn.Close();
                strComentario += ex.Message;
                return false;
            }
            finally
            {

                fConn.Close();
            }

            return true;

        }


    }
}
