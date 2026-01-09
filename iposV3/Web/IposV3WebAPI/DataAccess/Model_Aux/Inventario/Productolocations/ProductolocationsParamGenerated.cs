
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class ProductolocationsParamGenerated : BaseParam
    {

        public ProductolocationsParamGenerated():base()
        {

        }

        public ProductolocationsParamGenerated(BaseParam baseParam): this(baseParam.P_empresaid, baseParam.P_sucursalid)
        {
            
        }
        public ProductolocationsParamGenerated(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {
		
		this.EmpresaId = 0;
		
		this.SucursalId = 0;
		
		this.Id = 0;
	

        }



        public ProductolocationsParamGenerated(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid)
        {

		this.EmpresaId = EmpresaId;

		this.SucursalId = SucursalId;

		this.Id = Id;

        }



    public long? EmpresaId { get; set; }  

    public long? SucursalId { get; set; }  

    public long? Id { get; set; }  




  }
}

