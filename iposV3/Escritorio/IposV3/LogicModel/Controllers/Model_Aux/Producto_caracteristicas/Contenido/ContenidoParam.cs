
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class ContenidoParam : ContenidoParamGenerated
    {

        public ContenidoParam():base()
        {

        }

        public ContenidoParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public ContenidoParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public ContenidoParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

