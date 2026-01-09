
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class MonedaParam : MonedaParamGenerated
    {

        public MonedaParam():base()
        {

        }

        public MonedaParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public MonedaParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public MonedaParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

