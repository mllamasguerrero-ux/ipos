
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class EstadopaisParam : EstadopaisParamGenerated
    {

        public EstadopaisParam():base()
        {

        }

        public EstadopaisParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public EstadopaisParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public EstadopaisParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

