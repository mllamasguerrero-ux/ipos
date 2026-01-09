
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class AnaquelParam : AnaquelParamGenerated
    {

        public AnaquelParam():base()
        {

        }

        public AnaquelParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public AnaquelParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public AnaquelParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




  }
}

