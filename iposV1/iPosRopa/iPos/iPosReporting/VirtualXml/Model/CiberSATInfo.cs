using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPosReporting.VirtualXml.Model
{
    public class CiberSATInfo
    {
        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private string llave;

        public string Llave
        {
            get { return llave; }
            set { llave = value; }
        }

        public CiberSATInfo(string usuario, string llave)
        {
            this.usuario = usuario;
            this.llave = llave;
        }
    }
}
