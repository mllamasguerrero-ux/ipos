
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class RutaembarqueParam : RutaembarqueParamGenerated
    {

        public RutaembarqueParam():base()
        {

        }

        public RutaembarqueParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public RutaembarqueParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public RutaembarqueParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

