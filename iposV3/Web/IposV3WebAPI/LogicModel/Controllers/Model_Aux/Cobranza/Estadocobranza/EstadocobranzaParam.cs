
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class EstadocobranzaParam : EstadocobranzaParamGenerated
    {

        public EstadocobranzaParam():base()
        {

        }

        public EstadocobranzaParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public EstadocobranzaParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public EstadocobranzaParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

