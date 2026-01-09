using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPosReporting.VirtualXml.Model
{
    public class Addenda
    {
        private string xml;

        public string Xml
        {
            get { return xml; }
            set { xml = value; }
        }

        private string texto;

        public string Texto
        {
            get { return texto; }
            set { texto = value; }
        }

        public Addenda()
        {

        }
    }
}
