
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class CuentaParam : CuentaParamGenerated
    {

        public CuentaParam():base()
        {

        }

        public CuentaParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public CuentaParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public CuentaParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

