
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class Motivo_devolucionParam : Motivo_devolucionParamGenerated
    {

        public Motivo_devolucionParam():base()
        {

        }

        public Motivo_devolucionParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public Motivo_devolucionParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public Motivo_devolucionParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

