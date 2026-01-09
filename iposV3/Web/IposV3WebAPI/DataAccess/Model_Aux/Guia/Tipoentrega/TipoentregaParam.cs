
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class TipoentregaParam : TipoentregaParamGenerated
    {

        public TipoentregaParam():base()
        {

        }

        public TipoentregaParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public TipoentregaParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public TipoentregaParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

