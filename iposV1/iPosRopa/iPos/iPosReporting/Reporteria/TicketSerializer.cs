using iPos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace iPosReporting.Reporteria
{
    public static class TicketSerializer
    {
        private static string message;
        private static Dictionary<string, object> values;
        public static string Message { get => message; set => message = value; }
        public static Dictionary<string, object> Values { get => values; set => values = value; }
        public static List<TextoTicket> GetTicketTexts(string modelPath, Dictionary<string, object> datos)
        {
            try
            {
                List<TextoTicket> ticketTexts = new List<TextoTicket>();

                XmlDocument xmlDocument = new XmlDocument();

                if(LoadXmlDocument(modelPath, ref xmlDocument))
                {
                    List<List<string>> ticketDefinition = GetTicketDefinitionFromXml(ref xmlDocument, datos);

                    if(ticketDefinition.Count > 0)
                    {
                        ticketTexts = GetTicketsTextFromDefinition(ticketDefinition);
                    }
                    else
                    {
                        throw new Exception("Problema al crear la definición del ticket");
                    }
                }
                else
                {
                    throw new Exception("No se pudo cargar el documento modelo");
                }

                return ticketTexts;
            }
            catch(Exception e)
            {
                message = e.Message;
                return null;
            }
        }

        private static List<List<string>> GetTicketDefinitionFromXml(ref XmlDocument xmlDocument, Dictionary<string, object> datos)
        {   
            List<List<string>> definition = new List<List<string>>();

            var reportBands = GetReportBandDefinitionList(ref xmlDocument);

            //var reportBandsList = GetReportBandsList(ref xmlDocument);

            definition = GetDefinition(reportBands, datos);

            return definition;
        }

        private static List<XmlNodeList> GetReportBandsList(ref XmlDocument xmlDocument)
        {
            List<XmlNodeList> reportBands = new List<XmlNodeList>();



            XmlNodeList reportTitleNodes = xmlDocument.SelectNodes("Report/ReportPage/ReportTitleBand/TextObject");
            reportBands.Add(reportTitleNodes);


            XmlNodeList pageHeaderNodes = xmlDocument.SelectNodes("Report/ReportPage/PageHeaderBand/TextObject");
            reportBands.Add(pageHeaderNodes);

            XmlNodeList dataNodes = xmlDocument.SelectNodes("Report/ReportPage/DataBand/TextObject");
            reportBands.Add(dataNodes);

            XmlNodeList resumeNodes = xmlDocument.SelectNodes("Report/ReportPage/DataBand/ChildBand/TextObject");
            reportBands.Add(resumeNodes);

            XmlNodeList pageFooterNodes = xmlDocument.SelectNodes("Report/ReportPage/PageFooterBand/TextObject");
            reportBands.Add(pageFooterNodes);

            return reportBands;
        }


        private static List<XmlNode> GetReportBandDefinitionList(ref XmlDocument xmlDocument)
        {
            List<XmlNode> reportBands = new List<XmlNode>();
            

            XmlNodeList reportTitleNodes = xmlDocument.SelectNodes("//ChildBand");

            foreach (XmlNode node in reportTitleNodes)
                reportBands.Add(node);

            return reportBands;
        }

        private static void obtenerPropiedadesBanda(string bandName, ref bool esMultiple, ref string campoSubdatos, ref string condicionVisible)
        {
            esMultiple = false;
            campoSubdatos = "";
            condicionVisible = "";
            if (bandName == null || bandName.Length == 0)
                return;


            string[] strBufferSplit = bandName.Split(new char[] { '_'});

            if (strBufferSplit.Length < 2)
                return;

            foreach(string str in strBufferSplit)
            {

                if (str.StartsWith("0V0"))
                {
                    condicionVisible = str.Replace("0V0", "");
                }
                else if (str.StartsWith("0M0"))
                {
                    esMultiple = true;
                    campoSubdatos = str.Replace("0M0", "");
                }
            }


        }


        private static List<List<string>> GetDefinition(List<XmlNode> reportBandsList, Dictionary<string, object> datos)
        {
            List<List<string>> definitions = new List<List<string>>();
            List<List<string>> definitionsWithData = new List<List<string>>();
            List<List<string>> finalDefinitions = new List<List<string>>();

            //Dictionary<int, List<List<string>>> keyDefinitions = new Dictionary<int, List<List<string>>>();

            try
            {

                foreach (XmlNode band in reportBandsList)
                {
                    string bandName = nodeAtributeValue(band, "Name", "");

                    IEnumerable<XmlNode> sortedNodes = sortedNodes = band.ChildNodes.Cast<XmlNode>().OrderBy(n => (n.Attributes["Top"] != null ? Decimal.Parse(n.Attributes["Top"].Value) : 0.0m)).ThenBy(n => (n.Attributes["Left"] != null ? Decimal.Parse(n.Attributes["Left"].Value) : 0.0m));

                    //definitions = new List<List<string>>();

                    //aqui vemos si es una banda iterador y cual es el key de los datos que contiene la lista de subdatos
                    bool esMultiple = false;
                    string campoSubdatos = "";
                    string condicionVisible = "";

                    obtenerPropiedadesBanda(bandName, ref esMultiple, ref campoSubdatos, ref condicionVisible);



                    if (esMultiple)
                    {
                        if (datos.ContainsKey(campoSubdatos))
                        {

                            List<Dictionary<string, object>> subDatos = (List<Dictionary<string, object>>)datos[campoSubdatos];

                            foreach (Dictionary<string, object> subDato in subDatos)
                            {


                                for (int i = 0, n = 0; sortedNodes != null && i < sortedNodes.Count(); i = i + n)
                                {
                                    XmlNode item = sortedNodes.ElementAt(i);

                                    string top = item.Attributes["Top"] != null ? item.Attributes["Top"].Value : "0.0";

                                    List<XmlNode> subset = new List<XmlNode>();
                                    subset = band.Cast<XmlNode>().Where(x => top.Equals((x.Attributes["Top"] != null ? x.Attributes["Top"].Value : "0.0")))
                                                                 .ToList();
                                    XmlNode prevNode = null;






                                    for (int j = 0; j < subset.Count; j++)
                                    {

                                        XmlNode xmlNode = subset.ElementAt(j);




                                        if (xmlNode.Name == "TextObject")
                                        {

                                            definitions.Add(GetLeftSpacePaddingDefinition(xmlNode, prevNode, j, subset.Count));

                                            List<String> definition = GetNodeDefinition(xmlNode, j, subset.Count);
                                            definition[0] = textSubstitutedWithData(definition[0], subDato, 1);
                                            definitions.Add(definition);
                                            prevNode = xmlNode;
                                        }


                                        n = subset.Count;
                                    }
                                }
                            }
                        }
                    }

                    else
                    {

                        for (int i = 0, n = 0; sortedNodes != null && i < sortedNodes.Count(); i = i + n)
                        {
                            XmlNode item = sortedNodes.ElementAt(i);

                            string top = item.Attributes["Top"] != null ? item.Attributes["Top"].Value : "0.0";

                            List<XmlNode> subset = new List<XmlNode>();
                            subset = band.Cast<XmlNode>().Where(x => top.Equals((x.Attributes["Top"] != null ? x.Attributes["Top"].Value : "0.0")))
                                                         .ToList();
                            XmlNode prevNode = null;




                            for (int j = 0; j < subset.Count; j++)
                            {

                                XmlNode xmlNode = subset.ElementAt(j);

                                if (xmlNode.Name == "TextObject")
                                {

                                    definitions.Add(GetLeftSpacePaddingDefinition(xmlNode, prevNode, j, subset.Count));

                                    List<String> definition = GetNodeDefinition(xmlNode, j, subset.Count);
                                    definition[0] = textSubstitutedWithData(definition[0], datos, 1);
                                    definitions.Add(definition);

                                    prevNode = xmlNode;
                                }
                            }




                            n = subset.Count;
                        }
                    }




                    
                }




                
            }
            catch(Exception ex)
            {
                return  new List<List<string>>();
            }

            return definitions;
            //return definitionsWithData;
        }

        private static string nodeAtributeValue(XmlNode node, string atributo, string defaultValue)
        {
            if (node.Attributes[atributo] != null)
                return node.Attributes[atributo].Value;

            return defaultValue;
        }


        private static List<string> GetLeftSpacePaddingDefinition(XmlNode node, XmlNode previo, int counter, int count)
        {
            List<string> definition = new List<string>();

            //Fijar tamaño de fuente
            string fontSize = String.Empty;

            if (node.Attributes["Font"] == null)
            {
                fontSize = "Chica";
            }
            else
            {
                int fontSizeNumber = GetFontSize(nodeAtributeValue(node,"Font","0"));

                fontSize = fontSizeNumber <= 10 ? "Chica" : fontSizeNumber <= 14 ? "Grande" : "Grande2";
            }


            //Fijar longitud
            double prevLeft = 0; 
            double prevWidth = 0; 
            double prevRight = 0;

            if (previo != null)
            {
                prevLeft = double.Parse(nodeAtributeValue(previo,"Left","0.0"));
                prevWidth = double.Parse(nodeAtributeValue(previo, "Width", "0.0"));
                prevRight = prevLeft + prevWidth;
            }

            double nodeLeft = double.Parse(nodeAtributeValue(node, "Left","0.0"));
            double spaceWidth = nodeLeft - prevRight;

            string length = String.Empty;
            length = GetLength(fontSize, spaceWidth.ToString());

            //Fijar alineacion
            string align = "Izquierda";

            definition.Add("");
            definition.Add(fontSize);
            definition.Add("N");
            definition.Add("N");
            definition.Add(length);
            definition.Add("N");
            definition.Add(" ");
            definition.Add("N");
            definition.Add(align);

            return definition;

        }


            private static List<string> GetNodeDefinition(XmlNode node, int counter, int count)
        {
            List<string> definition = new List<string>();

            //Fijar texto
            string text = String.Empty;

            if (node.Attributes["Text"] == null)
            {
                text = "";
            }
            else
            {

                text = node.Attributes["Text"].Value.ToString();
            }

            //Fijar tamaño de fuente
            string fontSize = String.Empty;

            if (node.Attributes["Font"] == null)
            {
                fontSize = "Chica";
            }
            else
            {
                int fontSizeNumber = GetFontSize(node.Attributes["Font"].Value);

                fontSize = fontSizeNumber <= 10 ? "Chica" : fontSizeNumber <= 14 ? "Grande" : "Grande2";
            }

            //Fijar saltar linea
            string endLine = (counter == (count - 1)) ? "S" : "N";

            //Fijar centrado
            string centered = "N";
            if (node.Attributes["HorzAlign"] != null)
            {
                string horzAlign = node.Attributes["HorzAlign"].Value;

                switch (horzAlign)
                {
                    case "Center":
                        centered = "S";
                        break;
                    default:
                        break;
                }
            }

            //Fijar longitud
            string length = String.Empty;

            //if (endLine.Equals("S"))
            //{
            //    length = GetMaxLengthByFontSize(fontSize);
            //}
            //else
            //{
                length = GetLength(fontSize, node.Attributes["Width"].Value);
            //}

            //Fijar negrita
            string bold = "N";
            if (node.Attributes["Font"] != null)
            {
                bold = IsBold(SplitFontStyles(node.Attributes["Font"].Value)) ? "S" : "N";
            }

            //Fijar caracter relleno
            string relleno = " ";

            //Fijar subrayado
            string underline = "N";


            //Fijar alineacion
            string align = "Izquierda";

            definition.Add(text);
            definition.Add(fontSize);
            definition.Add(endLine);
            definition.Add(centered);
            definition.Add(length);
            definition.Add(bold);
            definition.Add(relleno);
            definition.Add(underline);
            definition.Add(align);
            
            return definition;
        }

        private static string GetLength(string fontSize, string itemWidth)
        {
            //double cmPerXmlWidth = 37.8;
            //double cmPerChar = 0.5;

            //double nodeWidthProperty = Double.Parse(itemWidth);
            //double cmInField = (nodeWidthProperty / cmPerXmlWidth)+1;

            //int charsInField = 0;

            //if (fontSize.Equals("Grande2"))
            //{
            //    charsInField = (int)Math.Truncate(cmInField);
            //}
            //else
            //{
            //    charsInField = (int)Math.Truncate(cmInField / cmPerChar);
            //}

            //return charsInField.ToString();


            double maxLenChar = (double)ImpresorTicketGenerico.obtenerLongitudLineaXTamanio(fontSize);
            double maxLenPixel = 529.2;
            double nodeWidthProperty = Double.Parse(itemWidth);

            return ((int)(nodeWidthProperty * maxLenChar / maxLenPixel)).ToString();
        }

        private static bool IsBold(string fontStyles)
        {
            return fontStyles.Contains("Bold");
        }

        private static bool IsUnderlined(string fontSyles)
        {
            return fontSyles.Contains("Underline");
        }

        private static string GetMaxLengthByFontSize(string fontSize)
        {
            switch(fontSize)
            {
                case "Chica":
                    return "55";
                default:
                    return "40";
            }
        }
        private static int GetFontSize(string font)
        {

            int fontSize = 0;

            string fontSizeProperty = SplitFontSize(font);

            fontSizeProperty = fontSizeProperty.Trim();

            List<string> cleanedFontSize = fontSizeProperty.Split('p').ToList();

            fontSize = int.Parse(cleanedFontSize[0]);

            return fontSize;
            
        }

        private static string SplitFontSize(string font)
        {
            List<string> splittedValues = font.Split(',').ToList();

            if (splittedValues.Count > 1) return splittedValues[1];
            else return String.Empty;
        }

        private static string SplitFontStyles(string font)
        {
            string[] separators = { "style=" };

            List<string> splittedValues = font.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (splittedValues.Count > 1) return splittedValues[1];
            else return String.Empty;
        }

        private static List<TextoTicket> GetTicketsTextFromDefinition(List<List<string>> definition)
        {
            List<TextoTicket> result = new List<TextoTicket>();

            result = ImpresorTicketGenerico.obtenTextoTicketDesdeDefiniciones(definition).ToList();

            return result;
        }

        private static bool LoadXmlDocument(string path, ref XmlDocument xmlDocument)
        {
            xmlDocument.Load(path);

            return xmlDocument.ChildNodes.Count > 1;
        }


        private static List<string> dataToSubstitute(string texto)
        {
            List<string> retorno = new List<string>();
            

            var pattern = @"\[(.*?)\]";
            var matches = Regex.Matches(texto, pattern);

            foreach (Match m in matches)
            {
                retorno.Add(m.Groups[1].Value);
            }


            return retorno;


        }

        private static string textSubstitutedWithData(string textoTicket, Dictionary<string, object> datos, int line)
        {
            List<string> dataToSubst = dataToSubstitute(textoTicket);
            if(dataToSubst == null || dataToSubst.Count == 0)
            {
                return textoTicket;
            }

            string newTextTicket = textoTicket;

            foreach (string toSubst in dataToSubst)
            {
                if(datos.ContainsKey(toSubst))
                {
                    newTextTicket = newTextTicket.Replace("[" + toSubst + "]", datos[toSubst].ToString());
                }
            }


            return newTextTicket;
        } 

    }
}
