
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class TerminalpagoservicioParam : TerminalpagoservicioParamGenerated
    {

        public TerminalpagoservicioParam():base()
        {

        }

        public TerminalpagoservicioParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public TerminalpagoservicioParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public TerminalpagoservicioParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

