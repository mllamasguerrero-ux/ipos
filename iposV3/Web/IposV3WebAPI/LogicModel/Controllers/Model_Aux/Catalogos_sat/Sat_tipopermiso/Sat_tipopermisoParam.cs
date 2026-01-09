
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class Sat_tipopermisoParam : Sat_tipopermisoParamGenerated
    {

        public Sat_tipopermisoParam():base()
        {

        }

        public Sat_tipopermisoParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public Sat_tipopermisoParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public Sat_tipopermisoParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

