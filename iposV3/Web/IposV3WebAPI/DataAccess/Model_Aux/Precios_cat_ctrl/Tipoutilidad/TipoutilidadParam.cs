
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class TipoutilidadParam : TipoutilidadParamGenerated
    {

        public TipoutilidadParam():base()
        {

        }

        public TipoutilidadParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public TipoutilidadParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public TipoutilidadParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

