
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class PromocionParam : PromocionParamGenerated
    {

        public PromocionParam():base()
        {

        }

        public PromocionParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public PromocionParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public PromocionParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

