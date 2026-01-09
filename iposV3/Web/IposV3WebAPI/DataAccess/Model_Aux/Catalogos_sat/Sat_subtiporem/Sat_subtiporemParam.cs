
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class Sat_subtiporemParam : Sat_subtiporemParamGenerated
    {

        public Sat_subtiporemParam():base()
        {

        }

        public Sat_subtiporemParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public Sat_subtiporemParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public Sat_subtiporemParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

