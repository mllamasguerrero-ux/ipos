
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class FormapagoParam : FormapagoParamGenerated
    {

        public FormapagoParam():base()
        {

        }

        public FormapagoParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public FormapagoParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public FormapagoParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

