
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class EstadopagocontrareciboParam : EstadopagocontrareciboParamGenerated
    {

        public EstadopagocontrareciboParam():base()
        {

        }

        public EstadopagocontrareciboParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public EstadopagocontrareciboParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public EstadopagocontrareciboParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

