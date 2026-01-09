
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class DoctoParam : DoctoParamGenerated
    {

        public DoctoParam():base()
        {

        }

        public DoctoParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public DoctoParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public DoctoParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

