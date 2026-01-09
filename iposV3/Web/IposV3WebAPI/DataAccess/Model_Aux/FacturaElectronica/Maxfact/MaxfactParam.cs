
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class MaxfactParam : MaxfactParamGenerated
    {

        public MaxfactParam():base()
        {

        }

        public MaxfactParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public MaxfactParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public MaxfactParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

