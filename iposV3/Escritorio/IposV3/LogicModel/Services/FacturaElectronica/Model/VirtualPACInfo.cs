using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Services.FacturaElectronica
{
    public class VirtualPACInfo
    {
        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private string servidor;
        public string Servidor
        {
            get { return servidor; }
            set { servidor = value; }
        }



        public VirtualPACInfo(string usuario, string servidor)
        {
            this.usuario = usuario;
            this.servidor = servidor;
        }
    }
}
