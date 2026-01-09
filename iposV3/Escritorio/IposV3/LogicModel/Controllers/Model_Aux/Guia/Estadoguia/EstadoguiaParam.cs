
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class EstadoguiaParam : EstadoguiaParamGenerated
    {

        public EstadoguiaParam():base()
        {

        }

        public EstadoguiaParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public EstadoguiaParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public EstadoguiaParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

