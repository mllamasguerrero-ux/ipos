
using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.ViewModels.Models
{
    public class ScreenpagonotacreditoParamGenerated : BaseParam
    {

        public ScreenpagonotacreditoParamGenerated():this(null, null)
        {

        }

        public ScreenpagonotacreditoParamGenerated(BaseParam baseParam): this(baseParam.P_empresaid, baseParam.P_sucursalid)
        {
            
        }
        public ScreenpagonotacreditoParamGenerated(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {
		
		this.Observaciones = "";
		
		this.Aplicarcreditoautomatico = "N";
		
		this.Generarfacturaelectronica = "N";
		
		this.Total = 0.0m;
		
		this.Montoefectivo = 0.0m;
		
		this.Montocreditoautomatico = 0.0m;
	
		this.P_id = 0;
	

        }



        public ScreenpagonotacreditoParamGenerated(long? empresaid, long? sucursalid
    				,string Observaciones
    				,string Aplicarcreditoautomatico
    				,string Generarfacturaelectronica
    				,long? P_id
    				,decimal? Total
    				,decimal? Montoefectivo
    				,decimal? Montocreditoautomatico
				  ) : base(empresaid, sucursalid)
        {

		this.P_id = P_id;

		this.Total = Total;

		this.Montoefectivo = Montoefectivo;

		this.Observaciones = Observaciones;

		this.Aplicarcreditoautomatico = Aplicarcreditoautomatico;

		this.Montocreditoautomatico = Montocreditoautomatico;

		this.Generarfacturaelectronica = Generarfacturaelectronica;

        }



    public string Observaciones { get; set; }  

    public string Aplicarcreditoautomatico { get; set; }  

    public string Generarfacturaelectronica { get; set; }  

    public long? P_id { get; set; }  

    public decimal? Total { get; set; }  

    public decimal? Montoefectivo { get; set; }  

    public decimal? Montocreditoautomatico { get; set; }  




  }
}

