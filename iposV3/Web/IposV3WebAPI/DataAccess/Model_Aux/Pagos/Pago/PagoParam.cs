
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class PagoParam : PagoParamGenerated
    {

        public PagoParam():base()
        {

        }

        public PagoParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public PagoParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public PagoParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

