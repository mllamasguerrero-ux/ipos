
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model.Syncr
{
    public class ConfiguracionsyncParam : ConfiguracionsyncParamGenerated
    {

        public ConfiguracionsyncParam():base()
        {

        }

        public ConfiguracionsyncParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public ConfiguracionsyncParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public ConfiguracionsyncParam(long? empresaid, long? sucursalid
    				,long? Id
				  ) : base(empresaid, sucursalid ,Id)
        {
		
        }*/




  }
}

