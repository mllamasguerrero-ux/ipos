
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class VehiculoParam : VehiculoParamGenerated
    {

        public VehiculoParam():base()
        {

        }

        public VehiculoParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public VehiculoParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public VehiculoParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

