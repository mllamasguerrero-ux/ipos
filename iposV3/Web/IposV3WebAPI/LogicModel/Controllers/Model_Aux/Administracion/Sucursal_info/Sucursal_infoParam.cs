
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class Sucursal_infoParam : Sucursal_infoParamGenerated
    {

        public Sucursal_infoParam():base()
        {

        }

        public Sucursal_infoParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public Sucursal_infoParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public Sucursal_infoParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

