
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class TiporecargaParamGenerated : BaseParam
    {

        public TiporecargaParamGenerated():base()
        {

        }

        public TiporecargaParamGenerated(BaseParam baseParam): this(baseParam.P_empresaid, baseParam.P_sucursalid)
        {
            
        }
        public TiporecargaParamGenerated(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {
		
		this.Id = 0;
		
		this.EmpresaId = 0;
		
		this.SucursalId = 0;
	

        }



        public TiporecargaParamGenerated(long? empresaid, long? sucursalid
    				,long? Id
    				,long? EmpresaId
    				,long? SucursalId
				  ) : base(empresaid, sucursalid)
        {

		this.Id = Id;

		this.EmpresaId = EmpresaId;

		this.SucursalId = SucursalId;

        }



    public long? Id { get; set; }  

    public long? EmpresaId { get; set; }  

    public long? SucursalId { get; set; }  




  }
}

