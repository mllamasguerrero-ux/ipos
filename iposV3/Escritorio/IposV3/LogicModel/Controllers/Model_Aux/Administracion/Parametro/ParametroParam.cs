
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class ParametroParam : ParametroParamGenerated
    {

        public ParametroParam():base()
        {

        }

        public ParametroParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public ParametroParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public ParametroParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

