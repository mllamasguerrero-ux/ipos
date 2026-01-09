
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class ClienteParam : ClienteParamGenerated
    {

        public ClienteParam():base()
        {

        }

        public ClienteParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public ClienteParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public ClienteParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

