
using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.ViewModels.Models
{
    public class ScreenpagovendeduriaParamGenerated : BaseParam
    {

        public ScreenpagovendeduriaParamGenerated(): this(null, null)
        {

        }

        public ScreenpagovendeduriaParamGenerated(BaseParam baseParam): this(baseParam.P_empresaid, baseParam.P_sucursalid)
        {
            
        }
        public ScreenpagovendeduriaParamGenerated(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {
		
		this.Tipotarjetaclave = "";
		
		this.Tipotarjetanombre = "";
		
		this.Bancotarjetaclave = "";
		
		this.Bancotarjetanombre = "";
		
		this.Referenciatarjeta = "";
		
		this.Bancochequeclave = "";
		
		this.Bancochequenombre = "";
		
		this.Referenciacheque = "";
		
		this.Numeromonedero = "";
		
		this.Bancotransferenciaclave = "";
		
		this.Bancotransferencianombre = "";
		
		this.Referenciatransferencia = "";
		
		this.Observaciones = "";
		
		this.Usocfdiclave = "";
		
		this.Usocfdinombre = "";
		
		this.Generarfacturaelectronica = "N";
		
		this.Surtidohastaalmacen = "N";
		
		this.Marcarpararevision = "N";
		
		this.Total = 0.0m;
		
		this.Montoefectivo = 0.0m;
		
		this.Montotarjeta = 0.0m;
		
		this.Montocheque = 0.0m;
		
		this.Montovale = 0.0m;
		
		this.Montocambio = 0.0m;
		
		this.Montomonedero = 0.0m;
		
		this.Montotransferencia = 0.0m;
		
		this.Montocreditoautomatico = 0.0m;
		
		this.Montocomprarelacionada = 0.0m;
		
		this.Montootros = 0.0m;
	
		this.P_id = 0;
		
		this.Tipotarjeta = 0;
		
		this.Bancotarjetaid = 0;
		
		this.Bancochequeid = 0;
		
		this.Bancotransferenciaid = 0;
		
		this.Usocfdiid = 0;
	

        }



        public ScreenpagovendeduriaParamGenerated(long? empresaid, long? sucursalid
    				,string Tipotarjetaclave
    				,string Tipotarjetanombre
    				,string Bancotarjetaclave
    				,string Bancotarjetanombre
    				,string Referenciatarjeta
    				,string Bancochequeclave
    				,string Bancochequenombre
    				,string Referenciacheque
    				,string Numeromonedero
    				,string Bancotransferenciaclave
    				,string Bancotransferencianombre
    				,string Referenciatransferencia
    				,string Observaciones
    				,string Generarfacturaelectronica
    				,string Usocfdiclave
    				,string Usocfdinombre
    				,string Surtidohastaalmacen
    				,string Marcarpararevision
    				,long? P_id
    				,decimal? Total
    				,decimal? Montoefectivo
    				,long? Tipotarjeta
    				,decimal? Montotarjeta
    				,long? Bancotarjetaid
    				,decimal? Montocheque
    				,long? Bancochequeid
    				,decimal? Montovale
    				,decimal? Montocambio
    				,decimal? Montomonedero
    				,decimal? Montotransferencia
    				,long? Bancotransferenciaid
    				,decimal? Montocreditoautomatico
    				,decimal? Montocomprarelacionada
    				,decimal? Montootros
    				,long? Usocfdiid
				  ) : base(empresaid, sucursalid)
        {

		this.P_id = P_id;

		this.Total = Total;

		this.Montoefectivo = Montoefectivo;

		this.Tipotarjeta = Tipotarjeta;

		this.Tipotarjetaclave = Tipotarjetaclave;

		this.Tipotarjetanombre = Tipotarjetanombre;

		this.Montotarjeta = Montotarjeta;

		this.Bancotarjetaid = Bancotarjetaid;

		this.Bancotarjetaclave = Bancotarjetaclave;

		this.Bancotarjetanombre = Bancotarjetanombre;

		this.Referenciatarjeta = Referenciatarjeta;

		this.Montocheque = Montocheque;

		this.Bancochequeid = Bancochequeid;

		this.Bancochequeclave = Bancochequeclave;

		this.Bancochequenombre = Bancochequenombre;

		this.Referenciacheque = Referenciacheque;

		this.Montovale = Montovale;

		this.Montocambio = Montocambio;

		this.Montomonedero = Montomonedero;

		this.Numeromonedero = Numeromonedero;

		this.Montotransferencia = Montotransferencia;

		this.Bancotransferenciaid = Bancotransferenciaid;

		this.Bancotransferenciaclave = Bancotransferenciaclave;

		this.Bancotransferencianombre = Bancotransferencianombre;

		this.Referenciatransferencia = Referenciatransferencia;

		this.Montocreditoautomatico = Montocreditoautomatico;

		this.Montocomprarelacionada = Montocomprarelacionada;

		this.Montootros = Montootros;

		this.Observaciones = Observaciones;

		this.Generarfacturaelectronica = Generarfacturaelectronica;

		this.Usocfdiid = Usocfdiid;

		this.Usocfdiclave = Usocfdiclave;

		this.Usocfdinombre = Usocfdinombre;

		this.Surtidohastaalmacen = Surtidohastaalmacen;

		this.Marcarpararevision = Marcarpararevision;

        }



    public string Tipotarjetaclave { get; set; }  

    public string Tipotarjetanombre { get; set; }  

    public string Bancotarjetaclave { get; set; }  

    public string Bancotarjetanombre { get; set; }  

    public string Referenciatarjeta { get; set; }  

    public string Bancochequeclave { get; set; }  

    public string Bancochequenombre { get; set; }  

    public string Referenciacheque { get; set; }  

    public string Numeromonedero { get; set; }  

    public string Bancotransferenciaclave { get; set; }  

    public string Bancotransferencianombre { get; set; }  

    public string Referenciatransferencia { get; set; }  

    public string Observaciones { get; set; }  

    public string Generarfacturaelectronica { get; set; }  

    public string Usocfdiclave { get; set; }  

    public string Usocfdinombre { get; set; }  

    public string Surtidohastaalmacen { get; set; }  

    public string Marcarpararevision { get; set; }  

    public long? P_id { get; set; }  

    public decimal? Total { get; set; }  

    public decimal? Montoefectivo { get; set; }  

    public long? Tipotarjeta { get; set; }  

    public decimal? Montotarjeta { get; set; }  

    public long? Bancotarjetaid { get; set; }  

    public decimal? Montocheque { get; set; }  

    public long? Bancochequeid { get; set; }  

    public decimal? Montovale { get; set; }  

    public decimal? Montocambio { get; set; }  

    public decimal? Montomonedero { get; set; }  

    public decimal? Montotransferencia { get; set; }  

    public long? Bancotransferenciaid { get; set; }  

    public decimal? Montocreditoautomatico { get; set; }  

    public decimal? Montocomprarelacionada { get; set; }  

    public decimal? Montootros { get; set; }  

    public long? Usocfdiid { get; set; }  




  }
}

