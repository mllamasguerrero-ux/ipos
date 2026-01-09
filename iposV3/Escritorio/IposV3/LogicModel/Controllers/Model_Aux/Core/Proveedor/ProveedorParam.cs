
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class ProveedorParam : ProveedorParamGenerated
    {

        public ProveedorParam():base()
        {

        }

        public ProveedorParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public ProveedorParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public ProveedorParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

