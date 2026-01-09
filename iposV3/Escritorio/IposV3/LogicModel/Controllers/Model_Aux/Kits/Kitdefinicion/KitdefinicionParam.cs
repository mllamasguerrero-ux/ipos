
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class KitdefinicionParam : KitdefinicionParamGenerated
    {

        public KitdefinicionParam():base()
        {

        }

        public KitdefinicionParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public KitdefinicionParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public KitdefinicionParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

