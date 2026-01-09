
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model.Syncr
{
    public class TableinfoParam : TableinfoParamGenerated
    {

        public TableinfoParam():base()
        {

        }

        public TableinfoParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public TableinfoParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public TableinfoParam(long? empresaid, long? sucursalid
    				,long? Id
				  ) : base(empresaid, sucursalid ,Id)
        {
		
        }*/




  }
}

