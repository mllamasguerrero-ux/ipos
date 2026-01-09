
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class LineaParam : LineaParamGenerated
    {

        public LineaParam():base()
        {

        }

        public LineaParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public LineaParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        public LineaParam(long? empresaid, long? sucursalid
    				,long? Id
				  ) : base(empresaid, sucursalid ,Id)
        {
		
        }




  }
}

