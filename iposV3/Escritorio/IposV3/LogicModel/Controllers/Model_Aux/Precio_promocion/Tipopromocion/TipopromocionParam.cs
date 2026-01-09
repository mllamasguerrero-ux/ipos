
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class TipopromocionParam : TipopromocionParamGenerated
    {

        public TipopromocionParam():base()
        {

        }

        public TipopromocionParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public TipopromocionParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public TipopromocionParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

