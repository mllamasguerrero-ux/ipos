
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.Model
{
    public class ParametroParamGenerated : BaseParam
    {

        public ParametroParamGenerated():base()
        {

        }

        public ParametroParamGenerated(BaseParam baseParam): this(baseParam.P_empresaid, baseParam.P_sucursalid)
        {
            
        }
        public ParametroParamGenerated(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {
		
		this.EmpresaId = 0;
		
		this.SucursalId = 0;
		
		this.Id = 0;
	

        }



        public ParametroParamGenerated(long? empresaid, long? sucursalid
    				,long? EmpresaId
    				,long? SucursalId
    				,long? Id
				  ) : base(empresaid, sucursalid)
        {

        }



    public long? EmpresaId { get; set; }  

    public long? SucursalId { get; set; }  

    public long? Id { get; set; }  

    public string? FormatoticketcortoClave { get; set; }  

    public string? FormatoticketcortoNombre { get; set; }  

    public string? FormatofactelectClave { get; set; }  

    public string? FormatofactelectNombre { get; set; }  

    public string? TiposeleccioncatalogosatClave { get; set; }  

    public string? TiposeleccioncatalogosatNombre { get; set; }  

    public string? PvcolorearClave { get; set; }  

    public string? PvcolorearNombre { get; set; }  

    public string? ScreenconfigClave { get; set; }  

    public string? ScreenconfigNombre { get; set; }  

    public string? TipovendedormovilClave { get; set; }  

    public string? TipovendedormovilNombre { get; set; }  

    public string? TiposyncmovilClave { get; set; }  

    public string? TiposyncmovilNombre { get; set; }  




  }
}

