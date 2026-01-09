
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CQ_LINEBE
	{
	public Hashtable isnull;

 	private string iLINEA;
        public string ILINEA
        { 
        	get
        	{
         		return this.iLINEA;
        	}
        	set
        	{
        		this.iLINEA= value;
        		this.isnull["ILINEA"]=false;
        	}
        }

 	private string iNOMBRE;
        public string INOMBRE
        { 
        	get
        	{
         		return this.iNOMBRE;
        	}
        	set
        	{
        		this.iNOMBRE= value;
        		this.isnull["INOMBRE"]=false;
        	}
        }

 	private double iCANTIDAD;
        public double ICANTIDAD
        { 
        	get
        	{
         		return this.iCANTIDAD;
        	}
        	set
        	{
        		this.iCANTIDAD= value;
        		this.isnull["ICANTIDAD"]=false;
        	}
        }

 	private double iIMPORTE;
        public double IIMPORTE
        { 
        	get
        	{
         		return this.iIMPORTE;
        	}
        	set
        	{
        		this.iIMPORTE= value;
        		this.isnull["IIMPORTE"]=false;
        	}
        }

 	private string iPLAZO;
        public string IPLAZO
        { 
        	get
        	{
         		return this.iPLAZO;
        	}
        	set
        	{
        		this.iPLAZO= value;
        		this.isnull["IPLAZO"]=false;
        	}
        }

 	private string iID;
        public string IID
        { 
        	get
        	{
         		return this.iID;
        	}
        	set
        	{
        		this.iID= value;
        		this.isnull["IID"]=false;
        	}
        }

 	private DateTime iID_FECHA;
        public DateTime IID_FECHA
        { 
        	get
        	{
         		return this.iID_FECHA;
        	}
        	set
        	{
        		this.iID_FECHA= value;
        		this.isnull["IID_FECHA"]=false;
        	}
        }

 	private string iID_HORA;
        public string IID_HORA
        { 
        	get
        	{
         		return this.iID_HORA;
        	}
        	set
        	{
        		this.iID_HORA= value;
        		this.isnull["IID_HORA"]=false;
        	}
        }

 	private string iESTRATEGIC;
        public string IESTRATEGIC
        { 
        	get
        	{
         		return this.iESTRATEGIC;
        	}
        	set
        	{
        		this.iESTRATEGIC= value;
        		this.isnull["IESTRATEGIC"]=false;
        	}
        }

 	private string iPCLIENTE;
        public string IPCLIENTE
        { 
        	get
        	{
         		return this.iPCLIENTE;
        	}
        	set
        	{
        		this.iPCLIENTE= value;
        		this.isnull["IPCLIENTE"]=false;
        	}
        }

 	private string iPPRODUCTO;
        public string IPPRODUCTO
        { 
        	get
        	{
         		return this.iPPRODUCTO;
        	}
        	set
        	{
        		this.iPPRODUCTO= value;
        		this.isnull["IPPRODUCTO"]=false;
        	}
        }

 	private string iPVENDEDOR;
        public string IPVENDEDOR
        { 
        	get
        	{
         		return this.iPVENDEDOR;
        	}
        	set
        	{
        		this.iPVENDEDOR= value;
        		this.isnull["IPVENDEDOR"]=false;
        	}
        }

 	private string iPMARCA;
        public string IPMARCA
        { 
        	get
        	{
         		return this.iPMARCA;
        	}
        	set
        	{
        		this.iPMARCA= value;
        		this.isnull["IPMARCA"]=false;
        	}
        }

 	private string iPPROVEEDOR;
        public string IPPROVEEDOR
        { 
        	get
        	{
         		return this.iPPROVEEDOR;
        	}
        	set
        	{
        		this.iPPROVEEDOR= value;
        		this.isnull["IPPROVEEDOR"]=false;
        	}
        }

 	private string iPCIUDAD;
        public string IPCIUDAD
        { 
        	get
        	{
         		return this.iPCIUDAD;
        	}
        	set
        	{
        		this.iPCIUDAD= value;
        		this.isnull["IPCIUDAD"]=false;
        	}
        }
		
               public CQ_LINEBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("ILINEA",true);
	

			isnull.Add("INOMBRE",true);
	

			isnull.Add("ICANTIDAD",true);
	

			isnull.Add("IIMPORTE",true);
	

			isnull.Add("IPLAZO",true);
	

			isnull.Add("IID",true);
	

			isnull.Add("IID_FECHA",true);
	

			isnull.Add("IID_HORA",true);
	

			isnull.Add("IESTRATEGIC",true);
	

			isnull.Add("IPCLIENTE",true);
	

			isnull.Add("IPPRODUCTO",true);
	

			isnull.Add("IPVENDEDOR",true);
	

			isnull.Add("IPMARCA",true);
	

			isnull.Add("IPPROVEEDOR",true);
	

			isnull.Add("IPCIUDAD",true);
	
		}

		

	}
}
