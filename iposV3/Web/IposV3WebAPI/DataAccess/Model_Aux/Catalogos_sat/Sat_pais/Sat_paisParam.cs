
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class Sat_paisParam : Sat_paisParamGenerated
    {

        public Sat_paisParam():base()
        {

        }

        public Sat_paisParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public Sat_paisParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public Sat_paisParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

