
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class BancoParam : BancoParamGenerated
    {

        public BancoParam():base()
        {

        }

        public BancoParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public BancoParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public BancoParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

