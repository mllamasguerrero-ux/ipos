
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class ListaprecioParam : ListaprecioParamGenerated
    {

        public ListaprecioParam():base()
        {

        }

        public ListaprecioParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public ListaprecioParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public ListaprecioParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

