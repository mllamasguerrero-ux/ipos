using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Threading;

namespace iPos
{
    public class WSEmidaRequest
    {



        static bool servicePointManagerProtocolSet = false;
        public static WebRequest getWebRequest(string endPoint)
        {
            if (!servicePointManagerProtocolSet)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
                servicePointManagerProtocolSet = true;
            }

            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(endPoint);
            //Setting KeepAlive to false
            webRequest.KeepAlive = false;
            return webRequest;
        }


        public static string Request(byte[] byteArray, string endPoint, int timeOut, ICredentials credentials, string method)
        {

            //string version, string terminalId, string transTypeId, string carrierId, string categoryId, string productId
            WebRequest request = getWebRequest(endPoint); //;WebRequest.Create(endPoint);
            request.Timeout = timeOut;
            request.Credentials = credentials;
            request.Method = method;
            

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
            return responseFromServer;
        }
        


    }
}
