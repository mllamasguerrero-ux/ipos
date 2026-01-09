
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class Motivo_camfecParam : Motivo_camfecParamGenerated
    {

        public Motivo_camfecParam():base()
        {

        }

        public Motivo_camfecParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public Motivo_camfecParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public Motivo_camfecParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

