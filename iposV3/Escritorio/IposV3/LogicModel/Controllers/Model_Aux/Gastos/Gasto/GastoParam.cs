
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class GastoParam : GastoParamGenerated
    {

        public GastoParam():base()
        {

        }

        public GastoParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public GastoParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public GastoParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

