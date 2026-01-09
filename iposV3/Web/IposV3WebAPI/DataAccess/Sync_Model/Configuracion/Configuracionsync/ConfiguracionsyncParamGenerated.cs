
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model.Syncr
{
    public class ConfiguracionsyncParamGenerated : BaseParam
    {

        public ConfiguracionsyncParamGenerated():base()
        {

        }

        public ConfiguracionsyncParamGenerated(BaseParam baseParam): this(baseParam.P_empresaid, baseParam.P_sucursalid)
        {
            
        }
        public ConfiguracionsyncParamGenerated(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {
		
		this.Id = 0;
	

        }



        public ConfiguracionsyncParamGenerated(long? empresaid, long? sucursalid
    				,long? Id
				  ) : base(empresaid, sucursalid)
        {

		this.Id = Id;

        }



    public long? Id { get; set; }  




  }
}

