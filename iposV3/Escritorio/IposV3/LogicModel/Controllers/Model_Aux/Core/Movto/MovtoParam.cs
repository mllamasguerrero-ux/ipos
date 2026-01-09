
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class MovtoParam : MovtoParamGenerated
    {

        public MovtoParam():base()
        {

        }

        public MovtoParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public MovtoParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public MovtoParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

