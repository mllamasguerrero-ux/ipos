using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSGetProducta4App.DAO.businessEntity
{
    public class InvMovilContainerResponse
    {
        private InvMovilDocto invMovilDocto;
        private List<InventarioMovilMovto> inventarioMovilMovto;

        public InvMovilDocto InvMovilDocto { get => invMovilDocto; set => invMovilDocto = value; }
        public List<InventarioMovilMovto> InventarioMovilMovto { get => inventarioMovilMovto; set => inventarioMovilMovto = value; }
    }
}