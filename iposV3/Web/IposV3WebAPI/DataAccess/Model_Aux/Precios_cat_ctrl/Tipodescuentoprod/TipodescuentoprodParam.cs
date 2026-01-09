
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class TipodescuentoprodParam : TipodescuentoprodParamGenerated
    {

        public TipodescuentoprodParam():base()
        {

        }

        public TipodescuentoprodParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public TipodescuentoprodParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public TipodescuentoprodParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

