
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class TasaiepsParam : TasaiepsParamGenerated
    {

        public TasaiepsParam():base()
        {

        }

        public TasaiepsParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public TasaiepsParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public TasaiepsParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

