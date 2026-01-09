
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model.Syncr
{
    public class V_field_infoParam : V_field_infoParamGenerated
    {

        public V_field_infoParam():base()
        {

        }

        public V_field_infoParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public V_field_infoParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public V_field_infoParam(long? empresaid, long? sucursalid
    				,string P_tablename
    				,string P_schemaname
				  ) : base(empresaid, sucursalid ,P_tablename,P_schemaname)
        {
		
        }*/




  }
}

