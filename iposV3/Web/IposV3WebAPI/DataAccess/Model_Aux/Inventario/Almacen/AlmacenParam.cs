
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class AlmacenParam : AlmacenParamGenerated
    {

        public AlmacenParam():base()
        {

        }

        public AlmacenParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public AlmacenParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public AlmacenParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

