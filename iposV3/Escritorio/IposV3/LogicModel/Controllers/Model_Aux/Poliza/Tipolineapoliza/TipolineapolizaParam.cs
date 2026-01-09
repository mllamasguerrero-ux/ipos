
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class TipolineapolizaParam : TipolineapolizaParamGenerated
    {

        public TipolineapolizaParam():base()
        {

        }

        public TipolineapolizaParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public TipolineapolizaParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public TipolineapolizaParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

