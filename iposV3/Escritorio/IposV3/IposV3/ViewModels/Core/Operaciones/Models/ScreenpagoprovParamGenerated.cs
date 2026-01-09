
using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.ViewModels.Models
{
    public class ScreenpagoprovParamGenerated : BaseParam
    {

        public ScreenpagoprovParamGenerated(): this(null, null)
        {

        }

        public ScreenpagoprovParamGenerated(BaseParam baseParam): this(baseParam.P_empresaid, baseParam.P_sucursalid)
        {
            
        }
        public ScreenpagoprovParamGenerated(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {
		
		this.Tipotarjetaclave = "";
		
		this.Tipotarjetanombre = "";
		
		this.Bancotarjetaclave = "";
		
		this.Bancotarjetanombre = "";
		
		this.Referenciatarjeta = "";
		
		this.Bancochequeclave = "";
		
		this.Bancochequenombre = "";
		
		this.Referenciacheque = "";
		
		this.Bancotransferenciaclave = "";
		
		this.Bancotransferencianombre = "";
		
		this.Referenciatransferencia = "";
		
		this.Observaciones = "";
		
		this.Total = 0.0m;
		
		this.Montoefectivo = 0.0m;
		
		this.Montotarjeta = 0.0m;
		
		this.Montocheque = 0.0m;
		
		this.Montotransferencia = 0.0m;
	
		this.P_id = 0;
		
		this.Tipotarjeta = 0;
		
		this.Bancotarjetaid = 0;
		
		this.Bancochequeid = 0;
		
		this.Bancotransferenciaid = 0;
	

        }



        public ScreenpagoprovParamGenerated(long? empresaid, long? sucursalid
    				,string Tipotarjetaclave
    				,string Tipotarjetanombre
    				,string Bancotarjetaclave
    				,string Bancotarjetanombre
    				,string Referenciatarjeta
    				,string Bancochequeclave
    				,string Bancochequenombre
    				,string Referenciacheque
    				,string Bancotransferenciaclave
    				,string Bancotransferencianombre
    				,string Referenciatransferencia
    				,string Observaciones
    				,long? P_id
    				,decimal? Total
    				,decimal? Montoefectivo
    				,long? Tipotarjeta
    				,decimal? Montotarjeta
    				,long? Bancotarjetaid
    				,decimal? Montocheque
    				,long? Bancochequeid
    				,decimal? Montotransferencia
    				,long? Bancotransferenciaid
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

		this.Montotransferencia = Montotransferencia;

		this.Bancotransferenciaid = Bancotransferenciaid;

		this.Bancotransferenciaclave = Bancotransferenciaclave;

		this.Bancotransferencianombre = Bancotransferencianombre;

		this.Referenciatransferencia = Referenciatransferencia;

		this.Observaciones = Observaciones;

        }



    public string Tipotarjetaclave { get; set; }  

    public string Tipotarjetanombre { get; set; }  

    public string Bancotarjetaclave { get; set; }  

    public string Bancotarjetanombre { get; set; }  

    public string Referenciatarjeta { get; set; }  

    public string Bancochequeclave { get; set; }  

    public string Bancochequenombre { get; set; }  

    public string Referenciacheque { get; set; }  

    public string Bancotransferenciaclave { get; set; }  

    public string Bancotransferencianombre { get; set; }  

    public string Referenciatransferencia { get; set; }  

    public string Observaciones { get; set; }  

    public long? P_id { get; set; }  

    public decimal? Total { get; set; }  

    public decimal? Montoefectivo { get; set; }  

    public long? Tipotarjeta { get; set; }  

    public decimal? Montotarjeta { get; set; }  

    public long? Bancotarjetaid { get; set; }  

    public decimal? Montocheque { get; set; }  

    public long? Bancochequeid { get; set; }  

    public decimal? Montotransferencia { get; set; }  

    public long? Bancotransferenciaid { get; set; }  




  }
}

