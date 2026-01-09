
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class GastoadicionalParam : GastoadicionalParamGenerated
    {

        public GastoadicionalParam():base()
        {

        }

        public GastoadicionalParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public GastoadicionalParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public GastoadicionalParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

