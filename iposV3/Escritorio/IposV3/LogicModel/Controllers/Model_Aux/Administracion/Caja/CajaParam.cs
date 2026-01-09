
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class CajaParam : CajaParamGenerated
    {

        public CajaParam():base()
        {

        }

        public CajaParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public CajaParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public CajaParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

