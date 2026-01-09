
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class ClasificaParam : ClasificaParamGenerated
    {

        public ClasificaParam():base()
        {

        }

        public ClasificaParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public ClasificaParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public ClasificaParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

