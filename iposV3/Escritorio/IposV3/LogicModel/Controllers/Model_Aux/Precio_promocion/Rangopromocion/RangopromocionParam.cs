
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class RangopromocionParam : RangopromocionParamGenerated
    {

        public RangopromocionParam():base()
        {

        }

        public RangopromocionParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public RangopromocionParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public RangopromocionParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

