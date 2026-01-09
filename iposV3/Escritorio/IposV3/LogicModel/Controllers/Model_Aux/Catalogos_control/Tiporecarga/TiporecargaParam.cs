
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class TiporecargaParam : TiporecargaParamGenerated
    {

        public TiporecargaParam():base()
        {

        }

        public TiporecargaParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public TiporecargaParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public TiporecargaParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

