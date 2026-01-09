
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class SyncParamGenerated : BaseParam
    {

        public SyncParamGenerated():base()
        {

        }

        public SyncParamGenerated(BaseParam baseParam): this(baseParam.P_empresaid, baseParam.P_sucursalid)
        {
            
        }
        public SyncParamGenerated(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {
		
		this.Id = 0;
	

        }



        public SyncParamGenerated(long? empresaid, long? sucursalid
    				,long? Id
				  ) : base(empresaid, sucursalid)
        {

		this.Id = Id;

        }



    public long? Id { get; set; }  




  }
}

