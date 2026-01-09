
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class ConfiguracionParam : IposV3.Model.BaseParam
    {


        public ConfiguracionParam() : base()
        {

        }

        public ConfiguracionParam(IposV3.Model.BaseParam baseParam) : this(baseParam.P_empresaid, baseParam.P_sucursalid)
        {

        }
        public ConfiguracionParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

            this.Id = 0;


        }



        public ConfiguracionParam(long? empresaid, long? sucursalid
                    , long? Id
                  ) : base(empresaid, sucursalid)
        {

        }



        public long? Id { get; set; }




    }
}
