
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class LineaParamGenerated : BaseParam
    {

        public LineaParamGenerated():base()
        {

        }

        public LineaParamGenerated(BaseParam baseParam): this(baseParam.P_empresaid, baseParam.P_sucursalid)
        {
            
        }
        public LineaParamGenerated(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {
		
		this.Id = 0;
	

        }



        public LineaParamGenerated(long? empresaid, long? sucursalid
    				,long? Id
				  ) : base(empresaid, sucursalid)
        {

		this.Id = Id;

        }



    public long? Id { get; set; }  




  }
}

