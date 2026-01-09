
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class Sat_matpeligrosoParam : Sat_matpeligrosoParamGenerated
    {

        public Sat_matpeligrosoParam():base()
        {

        }

        public Sat_matpeligrosoParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public Sat_matpeligrosoParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public Sat_matpeligrosoParam(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid ,Id,EmpresaId,SucursalId)
        {
		
        }*/




  }
}

