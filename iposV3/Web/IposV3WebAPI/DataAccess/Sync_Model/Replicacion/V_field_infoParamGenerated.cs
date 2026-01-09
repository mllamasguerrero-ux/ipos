
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model.Syncr
{
    public class V_field_infoParamGenerated : BaseParam
    {

        public V_field_infoParamGenerated():base()
        {

        }

        public V_field_infoParamGenerated(BaseParam baseParam): this(baseParam.P_empresaid, baseParam.P_sucursalid)
        {
            
        }
        public V_field_infoParamGenerated(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {
		
		this.P_tablename = "";
		
		this.P_schemaname = "";
		

        }



        public V_field_infoParamGenerated(long? empresaid, long? sucursalid
    				,string? P_tablename
    				,string? P_schemaname
				  ) : base(empresaid, sucursalid)
        {

		this.P_tablename = P_tablename;

		this.P_schemaname = P_schemaname;

        }



    public string? P_tablename { get; set; }  

    public string? P_schemaname { get; set; }  




  }
}

