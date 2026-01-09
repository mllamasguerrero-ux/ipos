
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class CamporeferenciaprecioParam : CamporeferenciaprecioParamGenerated
    {

        public CamporeferenciaprecioParam():base()
        {

        }

        public CamporeferenciaprecioParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public CamporeferenciaprecioParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public CamporeferenciaprecioParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

