
using IposV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IposV3.ViewModels.Models
{
    public class ScreenpagoprovParam : ScreenpagoprovParamGenerated
    {

        public decimal? Montocredito { get; set; }

        public ScreenpagoprovParam():base()
        {

        }

        public ScreenpagoprovParam(BaseParam baseParam): base(baseParam)
        {
            
        }
        public ScreenpagoprovParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {

        }



        /*public ScreenpagoprovParam(long? empresaid, long? sucursalid
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
				  ) : base(empresaid, sucursalid ,Tipotarjetaclave,Tipotarjetanombre,Bancotarjetaclave,Bancotarjetanombre,Referenciatarjeta,Bancochequeclave,Bancochequenombre,Referenciacheque,Bancotransferenciaclave,Bancotransferencianombre,Referenciatransferencia,Observaciones,P_id,Total,Montoefectivo,Tipotarjeta,Montotarjeta,Bancotarjetaid,Montocheque,Bancochequeid,Montotransferencia,Bancotransferenciaid)
        {
		
        }*/




  }
}

