using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPosBusinessEntity
{
    public class EstatusInventario
    {
        private int doctoId;
        private string sucursalClave;
        private string status;

        public int DoctoId { get => doctoId; set => doctoId = value; }
        public string SucursalClave { get => sucursalClave; set => sucursalClave = value; }
        public string Status { get => status; set => status = value; }
    }
}
