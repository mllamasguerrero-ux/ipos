
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class AreaParam : AreaParamGenerated
    {

        public AreaParam():base()
        {

        }

        public AreaParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public AreaParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public AreaParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

