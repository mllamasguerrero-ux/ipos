
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class PlazoParam : PlazoParamGenerated
    {

        public PlazoParam():base()
        {

        }

        public PlazoParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public PlazoParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public PlazoParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

