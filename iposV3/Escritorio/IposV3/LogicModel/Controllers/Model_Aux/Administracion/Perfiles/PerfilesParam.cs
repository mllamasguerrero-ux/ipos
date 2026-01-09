
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class PerfilesParam : PerfilesParamGenerated
    {

        public PerfilesParam():base()
        {

        }

        public PerfilesParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public PerfilesParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public PerfilesParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

