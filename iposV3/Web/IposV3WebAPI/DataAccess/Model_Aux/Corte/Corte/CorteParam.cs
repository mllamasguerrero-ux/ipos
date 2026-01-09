
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class CorteParam : CorteParamGenerated
    {

        public CorteParam():base()
        {

        }

        public CorteParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public CorteParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public CorteParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

