
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class GuiaParam : GuiaParamGenerated
    {

        public GuiaParam():base()
        {

        }

        public GuiaParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public GuiaParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public GuiaParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

