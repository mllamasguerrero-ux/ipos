
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class SubtipoclienteParam : SubtipoclienteParamGenerated
    {

        public SubtipoclienteParam():base()
        {

        }

        public SubtipoclienteParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public SubtipoclienteParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public SubtipoclienteParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

