
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class TipotransaccionParam : TipotransaccionParamGenerated
    {

        public TipotransaccionParam():base()
        {

        }

        public TipotransaccionParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public TipotransaccionParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public TipotransaccionParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

