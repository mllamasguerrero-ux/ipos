
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class MovtogastosadicParam : MovtogastosadicParamGenerated
    {

        public MovtogastosadicParam():base()
        {

        }

        public MovtogastosadicParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public MovtogastosadicParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }

        public MovtogastosadicParam(long? empresaid, long? sucursalid, long? doctoId) : base(empresaid, sucursalid)
        {
            DoctoId = doctoId;
        }


        public long? DoctoId { get; set; }

        /*public MovtogastosadicParam(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid ,EmpresaId,SucursalId,Id)
        {
		
        }*/




    }
}

