
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class GruposucursalParam : GruposucursalParamGenerated
    {

        public GruposucursalParam():base()
        {

        }

        public GruposucursalParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public GruposucursalParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public GruposucursalParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

