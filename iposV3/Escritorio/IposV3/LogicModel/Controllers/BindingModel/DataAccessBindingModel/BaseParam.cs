using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class BaseParam
    {

        public BaseParam()
        {
        }

        public BaseParam(long? empresaid, long? sucursalid)
        {
            P_empresaid = empresaid;
            P_sucursalid = sucursalid;
        }
        
        public long? P_empresaid { get; set; }

        public long? P_sucursalid { get; set; }


        public string? P_activo { get; set; }
    }
}
