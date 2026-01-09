
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class GrupousuarioParam : GrupousuarioParamGenerated
    {

        public GrupousuarioParam():base()
        {

        }

        public GrupousuarioParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public GrupousuarioParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public GrupousuarioParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

