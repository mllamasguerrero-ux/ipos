
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class CuentabancoParam : CuentabancoParamGenerated
    {

        public CuentabancoParam():base()
        {

        }

        public CuentabancoParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public CuentabancoParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public CuentabancoParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

