using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using iPosBusinessEntity;
using iPosData;
using System.Threading;

namespace iPos
{
    public class WSEmida
    {
        //static string endPoint = "https://ws.mobilmex.com:9448/soap/servlet/rpcrouter";
        static string endPontServicios = "https://ws.terecargamos.com:8448/soap/servlet/rpcrouter";

        //static string endPontServicios = "https://ws.terecargamos.com:8448/soap/webServices.wsdl";
        static string endPoint = "https://ws.terecargamos.com:8448/soap/servlet/rpcrouter";




        static bool servicePointManagerProtocolSet = false;


        public static List<CCARRIERBE> GetCarrierList( string version, string terminalId, string transTypeId, string carrierId, string categoryId, string productId)
        {

            //string version, string terminalId, string transTypeId, string carrierId, string categoryId, string productId
            WebRequest request = WebRequest.Create(endPoint);
            request.Timeout = 10000;
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "POST";

            byte[] byteArray = Encoding.UTF8.GetBytes(@"<?xml version=""1.0"" encoding=""utf-8""?>
                    <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
                    <soap:Body>
                        <GetCarrierList xmlns=""urn:debisys-soap-services"">
                            <version xsi:type=""xsd:string"">" + version + @"</version> 
                            <terminalId xsi:type=""xsd:string"">" + terminalId + @"</terminalId> 
                            <transTypeId xsi:type=""xsd:string"">" + transTypeId + @"</transTypeId> 
                            <carrierId xsi:type=""xsd:string"">" + carrierId + @"</carrierId> 
                            <categoryId xsi:type=""xsd:string"">" + categoryId + @"</categoryId> 
                            <productId xsi:type=""xsd:string"">" + productId + @"</productId> 
                        </GetCarrierList>
                    </soap:Body>
                    </soap:Envelope>");

            request.ContentType = "text/xml";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            DateTime Aux1Tiempo = DateTime.Now;
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(responseFromServer);

            string soap2 = doc.LastChild.InnerText;

            XmlDocument doc2 = new XmlDocument();
            doc2.LoadXml(soap2);

            List<CCARRIERBE> listCarrier = new List<CCARRIERBE>();
            CCARRIERBE carrier = new CCARRIERBE();
            XmlNodeList nodes = doc2.SelectNodes("GetCarrierListResponse/Carrier");
            foreach(XmlNode node in nodes)
            {
               carrier = new CCARRIERBE();
               carrier.ICARRIERID =  node.SelectSingleNode("CarrierId").LastChild.InnerText;
               carrier.IDESCRIPTION = node.SelectSingleNode("Description").LastChild.InnerText;
               carrier.IPRODUCTCOUNT = node.SelectSingleNode("ProductCount").LastChild.InnerText;

               listCarrier.Add(carrier);
            }

            return listCarrier;
        }

        public static List<CEMIDAPRODBE> GetProductList(string version, string terminalId, string transTypeId, string carrierId, string categoryId, string productId)
        {

            //string version, string terminalId, string transTypeId, string carrierId, string categoryId, string productId
            WebRequest request = WebRequest.Create(endPoint);
            request.Timeout = 1000;
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(@"<?xml version=""1.0"" encoding=""utf-8""?>
                    <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
                    <soap:Body>
                        <GetProductList xmlns=""urn:debisys-soap-services"">
                            <version xsi:type=""xsd:string"">" + version + @"</version> 
                            <terminalId xsi:type=""xsd:string"">" + terminalId + @"</terminalId> 
                            <transTypeId xsi:type=""xsd:string"">" + transTypeId + @"</transTypeId> 
                            <carrierId xsi:type=""xsd:string"">" + carrierId + @"</carrierId> 
                            <categoryId xsi:type=""xsd:string"">" + categoryId + @"</categoryId> 
                            <productId xsi:type=""xsd:string"">" + productId + @"</productId> 
                        </GetProductList>
                    </soap:Body>
                    </soap:Envelope>");

            request.ContentType = "text/xml";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            DateTime Aux1Tiempo = DateTime.Now;
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(responseFromServer);

            string soap2 = doc.LastChild.InnerText;

            XmlDocument doc2 = new XmlDocument();
            doc2.LoadXml(soap2);

            List<CEMIDAPRODBE> listProduct = new List<CEMIDAPRODBE>();
            CEMIDAPRODBE emidaProduct = new CEMIDAPRODBE();
            XmlNodeList nodes = doc2.SelectNodes("GetProductListResponse/Product");
            foreach (XmlNode node in nodes)
            {
                emidaProduct = new CEMIDAPRODBE();

                if (node.SelectSingleNode("ProductId") != null)
                {

                    emidaProduct.IPRODUCTID = node.SelectSingleNode("ProductId").LastChild.InnerText;
                }
                if (node.SelectSingleNode("Description") != null)
                {

                    emidaProduct.IDESCRIPTION = node.SelectSingleNode("Description").LastChild.InnerText;
                }
                if (node.SelectSingleNode("ShortDescription") != null)
                {

                    emidaProduct.ISHORTDESCRIPTION = node.SelectSingleNode("ShortDescription").LastChild.InnerText;
                }
                if (node.SelectSingleNode("Amount") != null)
                {

                    emidaProduct.IAMOUNT = node.SelectSingleNode("Amount").LastChild.InnerText;
                }
                if (node.SelectSingleNode("CarrierId") != null)
                {

                    emidaProduct.ICARRIERID = node.SelectSingleNode("CarrierId").LastChild.InnerText;
                }
                if (node.SelectSingleNode("CategoryId") != null)
                {

                    emidaProduct.ICATEGORYID = node.SelectSingleNode("CategoryId").LastChild.InnerText;
                }
                if (node.SelectSingleNode("TransTypeId") != null)
                {

                    emidaProduct.ITRANSTIPOID = node.SelectSingleNode("TransTypeId").LastChild.InnerText;
                }
                if (node.SelectSingleNode("CurrencyCode") != null)
                {

                    emidaProduct.ICURRENCYCODE = node.SelectSingleNode("CurrencyCode").LastChild.InnerText;
                }
                if (node.SelectSingleNode("CurrencySymbol") != null)
                {

                    emidaProduct.ICURRENCYSYMBOL = node.SelectSingleNode("CurrencySymbol").LastChild.InnerText;
                }
                if (node.SelectSingleNode("DiscountRate") != null)
                {

                    emidaProduct.IDISCOUNTRATE = node.SelectSingleNode("DiscountRate").LastChild.InnerText;
                }


                listProduct.Add(emidaProduct);
            }

            return listProduct;
        }


        public static List<CEMIDAPRODEXTBE> GetProductListExt(string version, string terminalId, string transTypeId, string carrierId, string categoryId, string productId)
        {

            //string version, string terminalId, string transTypeId, string carrierId, string categoryId, string productId
            //WebRequest request = WebRequest.Create(endPoint);
            WebRequest request = getWebRequest(endPoint);
            request.Timeout = 2000;
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "POST";
            string strSend = @"<?xml version=""1.0"" encoding=""utf-8""?>
                    <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
                    <soap:Body>
                        <GetProductListExt xmlns=""urn:debisys-soap-services"">
                            <version xsi:type=""xsd:string"">" + version + @"</version> 
                            <terminalId xsi:type=""xsd:string"">" + terminalId + @"</terminalId> 
                            <transTypeId xsi:type=""xsd:string"">" + transTypeId + @"</transTypeId> 
                            <carrierId xsi:type=""xsd:string"">" + carrierId + @"</carrierId> 
                            <categoryId xsi:type=""xsd:string"">" + categoryId + @"</categoryId> 
                            <productId xsi:type=""xsd:string"">" + productId + @"</productId> 
                        </GetProductListExt>
                    </soap:Body>
                    </soap:Envelope>";


            //MessageBox.Show(strSend);

            byte[] byteArray = Encoding.UTF8.GetBytes(strSend);



            request.ContentType = "text/xml";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            DateTime Aux1Tiempo = DateTime.Now;
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(responseFromServer);

            string soap2 = doc.LastChild.InnerText;

            //MessageBox.Show(soap2);

            XmlDocument doc2 = new XmlDocument();
            doc2.LoadXml(soap2);

            List<CEMIDAPRODEXTBE> listProduct = new List<CEMIDAPRODEXTBE>();
            CEMIDAPRODEXTBE emidaProduct = new CEMIDAPRODEXTBE();
            XmlNodeList nodes = doc2.SelectNodes("GetProductListResponse/Product");
            string strNodo = "";
            try
            {
                foreach (XmlNode node in nodes)
                {
                    emidaProduct = new CEMIDAPRODEXTBE();

                    if (node.SelectSingleNode("ProductId") != null)
                    {

                        emidaProduct.IPRODUCTID = node.SelectSingleNode("ProductId").LastChild.InnerText;
                        strNodo = emidaProduct.IPRODUCTID;
                    }
                    if (node.SelectSingleNode("Description") != null)
                    {

                        emidaProduct.IDESCRIPTION = node.SelectSingleNode("Description").LastChild.InnerText;
                    }
                    if (node.SelectSingleNode("ShortDescription") != null)
                    {

                        emidaProduct.ISHORTDESCRIPTION = node.SelectSingleNode("ShortDescription").LastChild.InnerText;
                    }
                    if (node.SelectSingleNode("Amount") != null)
                    {

                        emidaProduct.IAMOUNT = node.SelectSingleNode("Amount").LastChild.InnerText;
                    }
                    if (node.SelectSingleNode("CarrierId") != null)
                    {

                        emidaProduct.ICARRIERID = node.SelectSingleNode("CarrierId").LastChild.InnerText;
                    }
                    if (node.SelectSingleNode("CategoryId") != null)
                    {

                        emidaProduct.ICATEGORYID = node.SelectSingleNode("CategoryId").LastChild.InnerText;
                    }
                    if (node.SelectSingleNode("TransTypeId") != null)
                    {

                        emidaProduct.ITRANSTIPOID = node.SelectSingleNode("TransTypeId").LastChild.InnerText;
                    }
                    if (node.SelectSingleNode("CurrencyCode") != null)
                    {

                        emidaProduct.ICURRENCYCODE = node.SelectSingleNode("CurrencyCode").LastChild.InnerText;
                    }
                    if (node.SelectSingleNode("CurrencySymbol") != null)
                    {

                        emidaProduct.ICURRENCYSYMBOL = node.SelectSingleNode("CurrencySymbol").LastChild.InnerText;
                    }
                    if (node.SelectSingleNode("DiscountRate") != null)
                    {

                        emidaProduct.IDISCOUNTRATE = node.SelectSingleNode("DiscountRate").LastChild.InnerText;
                    }
                    if (node.SelectSingleNode("Reference") != null && node.SelectSingleNode("Reference").LastChild != null)
                    {

                        emidaProduct.IREFERENCE = node.SelectSingleNode("Reference").LastChild.InnerText;
                    }

                    listProduct.Add(emidaProduct);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return listProduct;
        }


        public static WebRequest getWebRequest(string endPoint)
        {
            if (!servicePointManagerProtocolSet)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                servicePointManagerProtocolSet = true;
            }

            HttpWebRequest webRequest = (HttpWebRequest) HttpWebRequest.Create(endPoint);
            //Setting KeepAlive to false
            webRequest.KeepAlive = false;
            return webRequest;
        }



        public static bool PinDistSale(ref CEMIDAREQUESTBE emidaRequest, string version, string siteId, string clerkId, string productId, string accountId, string amount, string invoiceNo, string languageOption, ref DateTime inicio, ref DateTime fin, ref bool bTimeOut, ref DateTime inicioLook, ref DateTime finLook, ref CEMIDAREQUESTBE reqLook, int timeOut)
        {

            try
            {
                //string version, string terminalId, string transTypeId, string carrierId, string categoryId, string productId
                //WebRequest request = WebRequest.Create(endPoint);
                //WebRequest request = getWebRequest(endPoint);
                //request.Timeout = timeOut;//CurrentUserID.CurrentParameters.ITIMEOUTPINDISTSALE;//40000;
                //request.Credentials = CredentialCache.DefaultCredentials;
                //request.Method = "POST";

                string strSend = @"<?xml version=""1.0"" encoding=""utf-8""?>
                    <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
                    <soap:Body>
                        <PinDistSale xmlns=""urn:debisys-soap-services"">
                            <version xsi:type=""xsd:string"">" + version + @"</version> 
                            <SiteId xsi:type=""xsd:string"">" + siteId + @"</SiteId> 
                            <ClerkId xsi:type=""xsd:string"">" + clerkId + @"</ClerkId> 
                            <ProductId xsi:type=""xsd:string"">" + productId + @"</ProductId> 
                            <AccountId xsi:type=""xsd:string"">" + accountId + @"</AccountId> 
                            <Amount xsi:type=""xsd:string"">" + amount + @"</Amount> 
                            <InvoiceNo xsi:type=""xsd:string"">" + invoiceNo + @"</InvoiceNo> 
                            <LanguageOption xsi:type=""xsd:string"">" + languageOption + @"</LanguageOption> 
                        </PinDistSale>
                    </soap:Body>
                    </soap:Envelope>";

                //MessageBox.Show(strSend);

                byte[] byteArray = Encoding.UTF8.GetBytes(strSend);
                string responseFromServer = WSEmidaRequest.Request(byteArray, endPoint, timeOut, CredentialCache.DefaultCredentials, "POST");

                /*request.ContentType = "text/xml";

                inicio = DateTime.Now;
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                fin = DateTime.Now;
                WebResponse response = request.GetResponse();
                fin = DateTime.Now;
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();*/

                //var emidaService = new EmidaTestService.webServicesClient();
                //string responseFromServer = emidaService.PinDistSale(version, siteId, clerkId, productId, accountId, amount, invoiceNo, languageOption);


                // Console.WriteLine("2 " + Aux2Tiempo.ToString("HH:mm:ss.fff") + " 0 " + Aux0Tiempo.ToString("HH:mm:ss.fff") + " 1 " + Aux1Tiempo.ToString("HH:mm:ss.fff") + " 3 " + Aux3Tiempo.ToString("HH:mm:ss.fff"));

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(responseFromServer);

                string soap2 = doc.LastChild.InnerText;

                Console.WriteLine("Test emida Pindstsale: " + DateTime.Now.ToString("mm:ss.fff") + " inicio - fin " + inicio.ToString("mm:ss.fff") + " - " + fin.ToString("mm:ss.fff") + " " + soap2);
                //MessageBox.Show(soap2);

                XmlDocument doc2 = new XmlDocument();
                doc2.LoadXml(soap2);

                //List<CEMIDAREQUESTBE> listEmida = new List<CEMIDAREQUESTBE>();
                // CEMIDAREQUESTBE emidaRequest = new CEMIDAREQUESTBE();
                XmlNodeList nodes = doc2.SelectNodes("PinDistSaleResponse");
                string strNodo = "";
                try
                {
                    foreach (XmlNode node in nodes)
                    {
                        //emidaRequest = new CEMIDAREQUESTBE();

                        if (node.SelectSingleNode("Version") != null)
                        {

                            emidaRequest.IVERSION = node.SelectSingleNode("Version").LastChild.InnerText;
                            strNodo = emidaRequest.IVERSION;
                        }
                        if (node.SelectSingleNode("InvoiceNo") != null)
                        {

                            emidaRequest.IINVOICENO = node.SelectSingleNode("InvoiceNo").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("ResponseCode") != null)
                        {

                            emidaRequest.IRESPONSECODE = node.SelectSingleNode("ResponseCode").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("Pin") != null)
                        {

                            emidaRequest.IPIN = node.SelectSingleNode("Pin").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("ControlNo") != null)
                        {

                            emidaRequest.ICONTROLNO = node.SelectSingleNode("ControlNo").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("CarrierControlNo") != null && node.SelectSingleNode("CarrierControlNo").LastChild != null)
                        {

                            emidaRequest.ICARRIERCONTROLNO = node.SelectSingleNode("CarrierControlNo").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("CustomerServiceNo") != null && node.SelectSingleNode("CustomerServiceNo").LastChild != null)
                        {

                            emidaRequest.ICUSTOMERSERVICENO = node.SelectSingleNode("CustomerServiceNo").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("TransactionDateTime") != null)
                        {

                            emidaRequest.ITRANSACTIONDATETIME = node.SelectSingleNode("TransactionDateTime").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("H2H_RESULT_CODE") != null)
                        {

                            emidaRequest.IH2HRESULTCODE = node.SelectSingleNode("H2H_RESULT_CODE").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("ResultCode") != null)
                        {

                            emidaRequest.IRESULTCODE = node.SelectSingleNode("ResultCode").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("ResponseMessage") != null && node.SelectSingleNode("ResponseMessage").LastChild != null)
                        {

                            emidaRequest.IRESPONSEMESSAGE = node.SelectSingleNode("ResponseMessage").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("TransactionId") != null)
                        {

                            emidaRequest.ITRANSACTIONID = node.SelectSingleNode("TransactionId").LastChild.InnerText;
                        }

                        //listEmida.Add(emidaRequest);

                        //emidaRequest.IRESPONSECODE = "32";
                        return true;
                    }
                }
                catch (Exception ex)
                {

                    if (fin == inicio)
                        fin = DateTime.Now;
                    MessageBox.Show("Algo ocurrio mal a la hora de conectarse con el servidor de Emida, verifique su conexión a internet y llame a soporte. 5 " + ex + ex.Message + ex.StackTrace);
                    return false;
                }
            }
            catch (WebException e)
            {
                // Thread.Sleep(2000);

                if (fin == inicio)
                    fin = DateTime.Now;




                if (e.Status == WebExceptionStatus.Timeout)
                {
                    // Handle timeout exception
                    bTimeOut = true;
                    LookUpTransactionByInvoice(ref reqLook, version, siteId, clerkId, invoiceNo, ref inicioLook, ref finLook, null);
                    return true;
                }
                else
                {

                    if (fin == inicio)
                        fin = DateTime.Now;
                    MessageBox.Show("Algo ocurrio mal a la hora de conectarse con el servidor de Emida, verifique su conexión a internet y llame a soporte. 6 " + e + e.Message + e.StackTrace);
                    return false;
                }
            }
            catch (Exception ex)
            {

                if (fin == inicio)
                    fin = DateTime.Now;
                MessageBox.Show("Algo ocurrio mal a la hora de conectarse con el servidor de Emida, verifique su conexión a internet y llame a soporte. 7 " + ex + ex.Message + ex.StackTrace);
                return false;
            }

            return true;
        }


        public static bool PinDistSale2(ref CEMIDAREQUESTBE emidaRequest, string version, string siteId, string clerkId, string productId, string accountId, string amount, string invoiceNo, string languageOption, ref DateTime inicio, ref DateTime fin, ref bool bTimeOut, ref DateTime inicioLook, ref DateTime finLook, ref CEMIDAREQUESTBE reqLook, int timeOut)
        {

            try
            {
                //string version, string terminalId, string transTypeId, string carrierId, string categoryId, string productId
                //WebRequest request = WebRequest.Create(endPoint);
                WebRequest request = getWebRequest(endPoint);
                request.Timeout = timeOut;//CurrentUserID.CurrentParameters.ITIMEOUTPINDISTSALE;//40000;
                request.Credentials = CredentialCache.DefaultCredentials;
                request.Method = "POST";

                string strSend = @"<?xml version=""1.0"" encoding=""utf-8""?>
                    <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
                    <soap:Body>
                        <PinDistSale xmlns=""urn:debisys-soap-services"">
                            <version xsi:type=""xsd:string"">" + version + @"</version> 
                            <SiteId xsi:type=""xsd:string"">" + siteId + @"</SiteId> 
                            <ClerkId xsi:type=""xsd:string"">" + clerkId + @"</ClerkId> 
                            <ProductId xsi:type=""xsd:string"">" + productId + @"</ProductId> 
                            <AccountId xsi:type=""xsd:string"">" + accountId + @"</AccountId> 
                            <Amount xsi:type=""xsd:string"">" + amount + @"</Amount> 
                            <InvoiceNo xsi:type=""xsd:string"">" + invoiceNo + @"</InvoiceNo> 
                            <LanguageOption xsi:type=""xsd:string"">" + languageOption + @"</LanguageOption> 
                        </PinDistSale>
                    </soap:Body>
                    </soap:Envelope>";

                //MessageBox.Show(strSend);

                byte[] byteArray = Encoding.UTF8.GetBytes(strSend);

                request.ContentType = "text/xml";

                inicio = DateTime.Now;
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                fin = DateTime.Now;
                WebResponse response = request.GetResponse();
                fin = DateTime.Now;
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();


                // Console.WriteLine("2 " + Aux2Tiempo.ToString("HH:mm:ss.fff") + " 0 " + Aux0Tiempo.ToString("HH:mm:ss.fff") + " 1 " + Aux1Tiempo.ToString("HH:mm:ss.fff") + " 3 " + Aux3Tiempo.ToString("HH:mm:ss.fff"));

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(responseFromServer);

                string soap2 = doc.LastChild.InnerText;

                Console.WriteLine("Test emida Pindstsale: " + DateTime.Now.ToString("mm:ss.fff") + " inicio - fin " + inicio.ToString("mm:ss.fff") + " - " + fin.ToString("mm:ss.fff") + " " + soap2);
                //MessageBox.Show(soap2);

                XmlDocument doc2 = new XmlDocument();
                doc2.LoadXml(soap2);

                //List<CEMIDAREQUESTBE> listEmida = new List<CEMIDAREQUESTBE>();
                // CEMIDAREQUESTBE emidaRequest = new CEMIDAREQUESTBE();
                XmlNodeList nodes = doc2.SelectNodes("PinDistSaleResponse");
                string strNodo = "";
                try
                {
                    foreach (XmlNode node in nodes)
                    {
                        //emidaRequest = new CEMIDAREQUESTBE();

                        if (node.SelectSingleNode("Version") != null)
                        {

                            emidaRequest.IVERSION = node.SelectSingleNode("Version").LastChild.InnerText;
                            strNodo = emidaRequest.IVERSION;
                        }
                        if (node.SelectSingleNode("InvoiceNo") != null)
                        {

                            emidaRequest.IINVOICENO = node.SelectSingleNode("InvoiceNo").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("ResponseCode") != null)
                        {

                            emidaRequest.IRESPONSECODE = node.SelectSingleNode("ResponseCode").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("Pin") != null)
                        {

                            emidaRequest.IPIN = node.SelectSingleNode("Pin").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("ControlNo") != null)
                        {

                            emidaRequest.ICONTROLNO = node.SelectSingleNode("ControlNo").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("CarrierControlNo") != null && node.SelectSingleNode("CarrierControlNo").LastChild != null)
                        {

                            emidaRequest.ICARRIERCONTROLNO = node.SelectSingleNode("CarrierControlNo").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("CustomerServiceNo") != null && node.SelectSingleNode("CustomerServiceNo").LastChild != null)
                        {

                            emidaRequest.ICUSTOMERSERVICENO = node.SelectSingleNode("CustomerServiceNo").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("TransactionDateTime") != null)
                        {

                            emidaRequest.ITRANSACTIONDATETIME = node.SelectSingleNode("TransactionDateTime").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("H2H_RESULT_CODE") != null)
                        {

                            emidaRequest.IH2HRESULTCODE = node.SelectSingleNode("H2H_RESULT_CODE").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("ResultCode") != null)
                        {

                            emidaRequest.IRESULTCODE = node.SelectSingleNode("ResultCode").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("ResponseMessage") != null && node.SelectSingleNode("ResponseMessage").LastChild != null)
                        {

                            emidaRequest.IRESPONSEMESSAGE = node.SelectSingleNode("ResponseMessage").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("TransactionId") != null)
                        {

                            emidaRequest.ITRANSACTIONID = node.SelectSingleNode("TransactionId").LastChild.InnerText;
                        }

                        //listEmida.Add(emidaRequest);

                        //emidaRequest.IRESPONSECODE = "32";
                        return true;
                    }
                }
                catch (Exception ex)
                {

                    if (fin == inicio)
                        fin = DateTime.Now;
                    MessageBox.Show("Algo ocurrio mal a la hora de conectarse con el servidor de Emida, verifique su conexión a internet y llame a soporte. 5 "  +  ex + ex.Message + ex.StackTrace);
                    return false;
                }
            }
            catch (WebException e)
            {
               // Thread.Sleep(2000);

                if (fin == inicio)
                    fin = DateTime.Now;


                

                if (e.Status == WebExceptionStatus.Timeout)
                {
                    // Handle timeout exception
                    bTimeOut = true;
                    LookUpTransactionByInvoice(ref reqLook, version, siteId, clerkId, invoiceNo, ref inicioLook, ref  finLook, null);
                    return true;
                }
                else
                {

                    if (fin == inicio)
                        fin = DateTime.Now;
                    MessageBox.Show("Algo ocurrio mal a la hora de conectarse con el servidor de Emida, verifique su conexión a internet y llame a soporte. 6 "  +  e + e.Message + e.StackTrace);
                    return false;
                }
            }
            catch(Exception ex)
            {

                if (fin == inicio)
                    fin = DateTime.Now;
                MessageBox.Show("Algo ocurrio mal a la hora de conectarse con el servidor de Emida, verifique su conexión a internet y llame a soporte. 7 " + ex + ex.Message + ex.StackTrace);
                return false;
            }

            return true;
        }

        public static bool LookUpTransactionByInvoice(ref CEMIDAREQUESTBE emidaRequest, string version, string terminalId, string clerkId, string invoiceNo, ref DateTime inicio, ref DateTime fin, DateTime? cuandoDebeIniciar)
        {
            try
            {
                WebRequest request = WebRequest.Create(endPoint);
                request.Timeout = 100000;// CurrentUserID.CurrentParameters.ITIMEOUTLOOKUP;//10000;
                request.Credentials = CredentialCache.DefaultCredentials;
                request.Method = "POST";

                byte[] byteArray = Encoding.UTF8.GetBytes(@"<?xml version=""1.0"" encoding=""utf-8""?>
                        <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
                        <soap:Body>
                            <LookUpTransactionByInvocieNo xmlns=""urn:debisys-soap-services"">
                                <version xsi:type=""xsd:string"">" + version + @"</version> 
                                <terminalId xsi:type=""xsd:string"">" + terminalId + @"</terminalId> 
                                <clerkId xsi:type=""xsd:string"">" + clerkId + @"</clerkId> 
                                <invoiceNo xsi:type=""xsd:string"">" + invoiceNo + @"</invoiceNo> 
                            </LookUpTransactionByInvocieNo>
                        </soap:Body>
                     </soap:Envelope>");

                request.ContentType = "text/xml";
                request.ContentLength = byteArray.Length;



                while (cuandoDebeIniciar != null && (cuandoDebeIniciar.Value - DateTime.Now).TotalMilliseconds > 0)
                {
                    Thread.Sleep(10);
                }
                inicio = DateTime.Now;


                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();


                /*
                inicio = DateTime.Now;
                fin = DateTime.Now;
                Console.WriteLine("Test emida: " + DateTime.Now.ToString("mm:ss.fff") + " inicio - fin " + inicio.ToString("mm:ss.fff") + " - " + fin.ToString("mm:ss.fff") );

                emidaRequest.IRESPONSECODE = "32";
                return true;*/



                
                fin = DateTime.Now;
                WebResponse response = request.GetResponse();
                fin = DateTime.Now;

                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(responseFromServer);

                string soap2 = doc.LastChild.InnerText;

                Console.WriteLine("Test emida: " + DateTime.Now.ToString("mm:ss.fff") + " inicio - fin " + inicio.ToString("mm:ss.fff") + " - " +  fin.ToString("mm:ss.fff") + " "  + soap2);

                XmlDocument doc2 = new XmlDocument();
                doc2.LoadXml(soap2);

                //List<CEMIDAREQUESTBE> listEmida = new List<CEMIDAREQUESTBE>();
                // CEMIDAREQUESTBE emidaRequest = new CEMIDAREQUESTBE();
                XmlNodeList nodes = doc2.SelectNodes("PinDistSaleResponse");
                string strNodo = "";
                try
                {
                    foreach (XmlNode node in nodes)
                    {
                        //emidaRequest = new CEMIDAREQUESTBE();

                        if (node.SelectSingleNode("Version") != null)
                        {

                            emidaRequest.IVERSION = node.SelectSingleNode("Version").LastChild.InnerText;
                            strNodo = emidaRequest.IVERSION;
                        }
                        if (node.SelectSingleNode("InvoiceNo") != null)
                        {

                            emidaRequest.IINVOICENO = node.SelectSingleNode("InvoiceNo").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("ResponseCode") != null)
                        {

                            emidaRequest.IRESPONSECODE = node.SelectSingleNode("ResponseCode").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("Pin") != null)
                        {

                            emidaRequest.IPIN = node.SelectSingleNode("Pin").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("ControlNo") != null && node.SelectSingleNode("ControlNo").LastChild != null)
                        {

                            emidaRequest.ICONTROLNO = node.SelectSingleNode("ControlNo").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("CarrierControlNo") != null && node.SelectSingleNode("CarrierControlNo").LastChild != null)
                        {

                            emidaRequest.ICARRIERCONTROLNO = node.SelectSingleNode("CarrierControlNo").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("CustomerServiceNo") != null && node.SelectSingleNode("CustomerServiceNo").LastChild != null)
                        {

                            emidaRequest.ICUSTOMERSERVICENO = node.SelectSingleNode("CustomerServiceNo").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("TransactionDateTime") != null && node.SelectSingleNode("TransactionDateTime").LastChild != null)
                        {

                            emidaRequest.ITRANSACTIONDATETIME = node.SelectSingleNode("TransactionDateTime").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("H2H_RESULT_CODE") != null && node.SelectSingleNode("H2H_RESULT_CODE").LastChild != null)
                        {

                            emidaRequest.IH2HRESULTCODE = node.SelectSingleNode("H2H_RESULT_CODE").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("ResultCode") != null && node.SelectSingleNode("ResultCode").LastChild != null)
                        {

                            emidaRequest.IRESULTCODE = node.SelectSingleNode("ResultCode").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("ResponseMessage") != null && node.SelectSingleNode("ResponseMessage").LastChild != null)
                        {

                            emidaRequest.IRESPONSEMESSAGE = node.SelectSingleNode("ResponseMessage").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("TransactionId") != null && node.SelectSingleNode("TransactionId").LastChild != null)
                        {

                            emidaRequest.ITRANSACTIONID = node.SelectSingleNode("TransactionId").LastChild.InnerText;
                        }

                        //listEmida.Add(emidaRequest);
                    }
                }
                catch (Exception ex)
                {
                    if (fin == inicio)
                        fin = DateTime.Now;
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            catch(Exception ex)
            {
                if (fin == inicio)
                    fin = DateTime.Now;

                MessageBox.Show(ex.Message);
                return false;

            }

            return true;
        }






        public static List<CEMIDACOMISIONBE> GetProductUFee(string version,  string productId)
        {

            //string version, string terminalId, string transTypeId, string carrierId, string categoryId, string productId
            WebRequest request = WebRequest.Create(endPoint);
            request.Timeout = 10000;
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(@"<?xml version=""1.0"" encoding=""utf-8""?>
                    <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
                    <soap:Body>
                        <GetProductUFee xmlns=""urn:debisys-soap-services"">
                            <version xsi:type=""xsd:string"">" + version + @"</version>  
                            <productId xsi:type=""xsd:string"">" + productId + @"</productId> 
                        </GetProductUFee>
                    </soap:Body>
                    </soap:Envelope>");

            request.ContentType = "text/xml";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            DateTime Aux1Tiempo = DateTime.Now;
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(responseFromServer);

            string soap2 = doc.LastChild.InnerText;

            XmlDocument doc2 = new XmlDocument();
            doc2.LoadXml(soap2);

            List<CEMIDACOMISIONBE> listProduct = new List<CEMIDACOMISIONBE>();
            CEMIDACOMISIONBE emidaProduct = new CEMIDACOMISIONBE();
            XmlNodeList nodes = doc2.SelectNodes("GetProductUFeeResponse");
            string strNodo = "";
            try
            {
                foreach (XmlNode node in nodes)
                {
                    emidaProduct = new CEMIDACOMISIONBE();


                    if (node.SelectSingleNode("Version") != null)
                    {

                        emidaProduct.IVERSIONEMIDA = node.SelectSingleNode("Version").LastChild.InnerText;
                    }



                    if (node.SelectSingleNode("ResponseCode") != null)
                    {

                        emidaProduct.IRESPONSECODE = node.SelectSingleNode("ResponseCode").LastChild.InnerText;
                    }


                    if (node.SelectSingleNode("ProductId") != null)
                    {

                        emidaProduct.IPRODUCTID = node.SelectSingleNode("ProductId").LastChild.InnerText;
                        strNodo = emidaProduct.IPRODUCTID;
                    }


                    if (node.SelectSingleNode("ProductDescription") != null)
                    {

                        emidaProduct.IPRODUCTDESCRIPTION = node.SelectSingleNode("ProductDescription").LastChild.InnerText;
                    }
                    if (node.SelectSingleNode("ProductUFee") != null)
                    {

                        emidaProduct.IPRODUCTUFEE = node.SelectSingleNode("ProductUFee").LastChild.InnerText;
                    }
                    

                    listProduct.Add(emidaProduct);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

            return listProduct;
        }



        public static string xmlConCaracteresDeEscape(string xmlOriginal)
        {
            int currentIndex = 0;
            string xmlBuffer = xmlOriginal;
            while (xmlBuffer.IndexOf('&', currentIndex) >= 0)
            {
                int indiceCaracterEscape = xmlBuffer.IndexOf('&', currentIndex);
                string strBufferAntes = xmlBuffer.Substring(0, indiceCaracterEscape);
                string strBufferDespues = xmlBuffer.Substring(indiceCaracterEscape + 1);

                if (!strBufferDespues.StartsWith("amp;")  && !strBufferDespues.StartsWith("gt;") && !strBufferDespues.StartsWith("lt;") && !strBufferDespues.StartsWith("apos;")  && !strBufferDespues.StartsWith("quot;")  )
                    strBufferDespues = "&amp;" + strBufferDespues;
                else
                    strBufferDespues = "&" + strBufferDespues;

                xmlBuffer = strBufferAntes + strBufferDespues;
                currentIndex = indiceCaracterEscape + 1;
            }

            return xmlBuffer;
        }

        public static bool BillpaymentUserFee(ref CEMIDAREQUESTBE emidaRequest, string version, string siteId, string clerkId, string productId, string accountId, string amount, string invoiceNo, string languageOption, ref DateTime inicio, ref DateTime fin, ref bool bTimeOut, ref DateTime inicioLook, ref DateTime finLook, ref CEMIDAREQUESTBE reqLook, int timeOut)
        {

            try
            {
                //string version, string terminalId, string transTypeId, string carrierId, string categoryId, string productId
                WebRequest request = WebRequest.Create(endPontServicios);
                request.Timeout = timeOut;//CurrentUserID.CurrentParameters.ITIMEOUTPINDISTSALE;//40000;
                request.Credentials = CredentialCache.DefaultCredentials;
                request.Method = "POST";

                string strSend = @"<?xml version=""1.0"" encoding=""utf-8""?>
                    <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
                    <soap:Body>
                        <BillPaymentUserFee xmlns=""urn:debisys-soap-services"">
                            <version xsi:type=""xsd:string"">" + version + @"</version> 
                            <terminalId xsi:type=""xsd:string"">" + siteId + @"</terminalId> 
                            <ClerkId xsi:type=""xsd:string"">" + clerkId + @"</ClerkId> 
                            <ProductId xsi:type=""xsd:string"">" + productId + @"</ProductId> 
                            <Amount xsi:type=""xsd:string"">" + amount + @"</Amount> 
                            <AccountId xsi:type=""xsd:string"">" + accountId + @"</AccountId> 
                            <InvoiceNo xsi:type=""xsd:string"">" + invoiceNo + @"</InvoiceNo> 
                            <LanguageOption xsi:type=""xsd:string"">" + languageOption + @"</LanguageOption> 
                        </BillPaymentUserFee>
                    </soap:Body>
                    </soap:Envelope>";

                //MessageBox.Show(strSend);

                byte[] byteArray = Encoding.UTF8.GetBytes(strSend);

                request.ContentType = "text/xml";

                inicio = DateTime.Now;
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                fin = DateTime.Now;
                WebResponse response = request.GetResponse();
                fin = DateTime.Now;
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();


                // Console.WriteLine("2 " + Aux2Tiempo.ToString("HH:mm:ss.fff") + " 0 " + Aux0Tiempo.ToString("HH:mm:ss.fff") + " 1 " + Aux1Tiempo.ToString("HH:mm:ss.fff") + " 3 " + Aux3Tiempo.ToString("HH:mm:ss.fff"));



                XmlDocument doc = new XmlDocument();
                doc.LoadXml(responseFromServer);

                string soap2 = doc.LastChild.InnerText;

                //en caso de querer verificar los ampersand usar esta funcion
                //soap2 = xmlConCaracteresDeEscape(soap2);

                Console.WriteLine("Test emida Pindstsale: " + DateTime.Now.ToString("mm:ss.fff") + " inicio - fin " + inicio.ToString("mm:ss.fff") + " - " + fin.ToString("mm:ss.fff") + " " + soap2);
                //MessageBox.Show(soap2);

                XmlDocument doc2 = new XmlDocument();
                doc2.LoadXml(soap2);

                //List<CEMIDAREQUESTBE> listEmida = new List<CEMIDAREQUESTBE>();
                // CEMIDAREQUESTBE emidaRequest = new CEMIDAREQUESTBE();
                XmlNodeList nodes = doc2.SelectNodes("BillPaymentUserFeeResponse");
                string strNodo = "";
                try
                {
                    foreach (XmlNode node in nodes)
                    {
                        //emidaRequest = new CEMIDAREQUESTBE();

                        if (node.SelectSingleNode("Version") != null)
                        {

                            emidaRequest.IVERSION = node.SelectSingleNode("Version").LastChild.InnerText;
                            strNodo = emidaRequest.IVERSION;
                        }
                        if (node.SelectSingleNode("InvoiceNo") != null)
                        {

                            emidaRequest.IINVOICENO = node.SelectSingleNode("InvoiceNo").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("ResponseCode") != null)
                        {

                            emidaRequest.IRESPONSECODE = node.SelectSingleNode("ResponseCode").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("Pin") != null)
                        {

                            emidaRequest.IPIN = node.SelectSingleNode("Pin").LastChild.InnerText;
                        }
                        /*if (node.SelectSingleNode("ControlNo") != null)
                        {

                            emidaRequest.ICONTROLNO = node.SelectSingleNode("ControlNo").LastChild.InnerText;
                        }*/
                        if (node.SelectSingleNode("CarrierControlNo") != null && node.SelectSingleNode("CarrierControlNo").LastChild != null)
                        {

                            emidaRequest.ICARRIERCONTROLNO = node.SelectSingleNode("CarrierControlNo").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("CustomerServiceNo") != null && node.SelectSingleNode("CustomerServiceNo").LastChild != null)
                        {

                            emidaRequest.ICUSTOMERSERVICENO = node.SelectSingleNode("CustomerServiceNo").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("TransactionDateTime") != null)
                        {

                            emidaRequest.ITRANSACTIONDATETIME = node.SelectSingleNode("TransactionDateTime").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("H2H_RESULT_CODE") != null)
                        {

                            emidaRequest.IH2HRESULTCODE = node.SelectSingleNode("H2H_RESULT_CODE").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("ResultCode") != null)
                        {

                            emidaRequest.IRESULTCODE = node.SelectSingleNode("ResultCode").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("ResponseMessage") != null && node.SelectSingleNode("ResponseMessage").LastChild != null)
                        {

                            emidaRequest.IRESPONSEMESSAGE = node.SelectSingleNode("ResponseMessage").LastChild.InnerText;
                        }
                        if (node.SelectSingleNode("TransactionId") != null)
                        {

                            emidaRequest.ITRANSACTIONID = node.SelectSingleNode("TransactionId").LastChild.InnerText;
                        }

                        //listEmida.Add(emidaRequest);

                        //emidaRequest.IRESPONSECODE = "32";
                        return true;
                    }
                }
                catch (Exception ex)
                {

                    if (fin == inicio)
                        fin = DateTime.Now;
                    MessageBox.Show("Algo ocurrio mal a la hora de conectarse con el servidor de Emida, verifique su conexión a internet y llame a soporte. 8 " + ex + ex.Message + ex.StackTrace);
                    return false;
                }
            }
            catch (WebException e)
            {
                // Thread.Sleep(2000);

                if (fin == inicio)
                    fin = DateTime.Now;




                if (e.Status == WebExceptionStatus.Timeout)
                {
                    // Handle timeout exception
                    bTimeOut = true;
                    LookUpTransactionByInvoice(ref reqLook, version, siteId, clerkId, invoiceNo, ref inicioLook, ref  finLook, null);
                    return true;
                }
                else
                {

                    if (fin == inicio)
                        fin = DateTime.Now;
                    MessageBox.Show("Algo ocurrio mal a la hora de conectarse con el servidor de Emida, verifique su conexión a internet y llame a soporte. 9 " + e + e.Message + e.StackTrace);
                    return false;
                }
            }
            catch (Exception ex)
            {

                if (fin == inicio)
                    fin = DateTime.Now;
                MessageBox.Show("Algo ocurrio mal a la hora de conectarse con el servidor de Emida, verifique su conexión a internet y llame a soporte. 10 " +  ex + ex.Message + ex.StackTrace);
                return false;
            }

            return true;
        }


    }
}
