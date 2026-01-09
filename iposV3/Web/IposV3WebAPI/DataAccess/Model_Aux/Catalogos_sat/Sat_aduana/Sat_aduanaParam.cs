
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class Sat_aduanaParam : Sat_aduanaParamGenerated
    {

        public Sat_aduanaParam():base()
        {

        }

        public Sat_aduanaParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public Sat_aduanaParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public Sat_aduanaParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

