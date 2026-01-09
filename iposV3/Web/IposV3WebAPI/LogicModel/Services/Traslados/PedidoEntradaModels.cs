using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Services
{

    public class DoctoPedidoEntradaTrans : DoctoProvTrans
    {
    }


    public class MovtoPedidoEntradaTrans : MovtoProvTrans
    {
        public decimal Cantidadsurtida { get; set; }
    }
}
