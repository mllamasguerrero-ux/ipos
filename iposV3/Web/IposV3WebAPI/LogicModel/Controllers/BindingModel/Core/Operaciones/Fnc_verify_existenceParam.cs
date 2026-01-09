
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model;
using MvvmFramework;
using System.Xml.Serialization;

namespace BindingModels
{
    public class Fnc_verify_existenceParam : BaseParam
    {

        public Fnc_verify_existenceParam():base()
        {

        }

        public Fnc_verify_existenceParam(BaseParam baseParam): this(baseParam.P_empresaid, baseParam.P_sucursalid)
        {
            
        }
        public Fnc_verify_existenceParam(long? empresaid, long? sucursalid) : base(empresaid, sucursalid)
        {
		
		this.P_lote = "";
		
		this.P_ignorealmacen = BoolCN.N;
		
		this.P_ignorelote = BoolCN.N;
		
		this.P_ignoreenprocesosalida = BoolCN.N;
		
		this.P_ignoreparaarmar = BoolCN.N;
		
		this.P_onlyverify = BoolCN.N;
		
		this.P_cantidad = 0.0m;
	
		this.P_productoid = 0;
		
		this.P_tipodoctoid = 0;
		
		this.P_almacenid = 0;
		
		this.P_movtorefid = 0;
	
		this.P_fechavence = DateTime.Today;
	

        }



        public Fnc_verify_existenceParam(long? empresaid, long? sucursalid
    				,string? P_lote
    				,BoolCN P_ignorealmacen
    				,BoolCN P_ignorelote
    				,BoolCN P_ignoreenprocesosalida
    				,BoolCN P_ignoreparaarmar
    				,BoolCN P_onlyverify
    				,long? P_productoid
    				,decimal? P_cantidad
    				,long? P_tipodoctoid
    				,long? P_almacenid
    				,DateTimeOffset? P_fechavence
    				,long? P_movtorefid
				  ) : base(empresaid, sucursalid)
        {

		this.P_productoid = P_productoid;

		this.P_cantidad = P_cantidad;

		this.P_tipodoctoid = P_tipodoctoid;

		this.P_almacenid = P_almacenid;

		this.P_lote = P_lote;

		this.P_fechavence = P_fechavence;

		this.P_ignorealmacen = P_ignorealmacen;

		this.P_ignorelote = P_ignorelote;

		this.P_ignoreenprocesosalida = P_ignoreenprocesosalida;

		this.P_ignoreparaarmar = P_ignoreparaarmar;

		this.P_onlyverify = P_onlyverify;

		this.P_movtorefid = P_movtorefid;

        }



    public string? P_lote { get; set; }  

    public BoolCN P_ignorealmacen { get; set; }  

    public BoolCN P_ignorelote { get; set; }  

    public BoolCN P_ignoreenprocesosalida { get; set; }  

    public BoolCN P_ignoreparaarmar { get; set; }  

    public BoolCN P_onlyverify { get; set; }  

    public long? P_productoid { get; set; }  

    public decimal? P_cantidad { get; set; }  

    public long? P_tipodoctoid { get; set; }  

    public long? P_almacenid { get; set; }  

    public DateTimeOffset? P_fechavence { get; set; }  

    public long? P_movtorefid { get; set; }  




  }
}

