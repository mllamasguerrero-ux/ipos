
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class MerchantpagoservicioParam : MerchantpagoservicioParamGenerated
    {

        public MerchantpagoservicioParam():base()
        {

        }

        public MerchantpagoservicioParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public MerchantpagoservicioParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public MerchantpagoservicioParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

