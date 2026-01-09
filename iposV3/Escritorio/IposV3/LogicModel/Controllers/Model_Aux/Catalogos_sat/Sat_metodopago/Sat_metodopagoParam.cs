
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class Sat_metodopagoParam : Sat_metodopagoParamGenerated
    {

        public Sat_metodopagoParam():base()
        {

        }

        public Sat_metodopagoParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public Sat_metodopagoParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public Sat_metodopagoParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

