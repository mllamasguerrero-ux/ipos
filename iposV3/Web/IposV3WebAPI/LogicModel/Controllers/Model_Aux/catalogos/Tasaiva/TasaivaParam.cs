
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class TasaivaParam : TasaivaParamGenerated
    {

        public TasaivaParam():base()
        {

        }

        public TasaivaParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public TasaivaParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public TasaivaParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

