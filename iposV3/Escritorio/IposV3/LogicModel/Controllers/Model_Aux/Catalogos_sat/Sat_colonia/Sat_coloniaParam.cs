
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class Sat_coloniaParam : Sat_coloniaParamGenerated
    {

        public Sat_coloniaParam():base()
        {

        }

        public Sat_coloniaParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public Sat_coloniaParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public Sat_coloniaParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

