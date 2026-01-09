
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class SyncParam : SyncParamGenerated
    {

        public SyncParam():base()
        {

        }

        public SyncParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public SyncParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public SyncParam(long? empresaid, long? sucursalid
    				,long? Id
				  ) : base(empresaid, sucursalid ,Id)
        {
		
        }*/




  }
}

