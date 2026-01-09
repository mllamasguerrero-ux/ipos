
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class MensajenivelurgenciaParam : MensajenivelurgenciaParamGenerated
    {

        public MensajenivelurgenciaParam():base()
        {

        }

        public MensajenivelurgenciaParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public MensajenivelurgenciaParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public MensajenivelurgenciaParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

