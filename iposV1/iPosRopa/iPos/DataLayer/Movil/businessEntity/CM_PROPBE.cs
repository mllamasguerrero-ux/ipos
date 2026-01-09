using System;
using System.Collections;
namespace iPosBusinessEntity
{
	public class CM_PROPBE
	{
	public Hashtable isnull;

 	private string iPRODUCTO;
        public string IPRODUCTO
        { 
        	get
        	{
         		return this.iPRODUCTO;
        	}
        	set
        	{
        		this.iPRODUCTO= value;
        		this.isnull["IPRODUCTO"]=false;
        	}
        }

 	private string iDESC1;
        public string IDESC1
        { 
        	get
        	{
         		return this.iDESC1;
        	}
        	set
        	{
        		this.iDESC1= value;
        		this.isnull["IDESC1"]=false;
        	}
        }

 	private Decimal iEXIS1;
        public Decimal IEXIS1
        { 
        	get
        	{
         		return this.iEXIS1;
        	}
        	set
        	{
        		this.iEXIS1= value;
        		this.isnull["IEXIS1"]=false;
        	}
        }

 	private Decimal iBOTCAJA;
        public Decimal IBOTCAJA
        { 
        	get
        	{
         		return this.iBOTCAJA;
        	}
        	set
        	{
        		this.iBOTCAJA= value;
        		this.isnull["IBOTCAJA"]=false;
        	}
        }

 	private Decimal iPRECIO1;
        public Decimal IPRECIO1
        { 
        	get
        	{
         		return this.iPRECIO1;
        	}
        	set
        	{
        		this.iPRECIO1= value;
        		this.isnull["IPRECIO1"]=false;
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

 	private Decimal iPRECIO2;
        public Decimal IPRECIO2
        { 
        	get
        	{
         		return this.iPRECIO2;
        	}
        	set
        	{
        		this.iPRECIO2= value;
        		this.isnull["IPRECIO2"]=false;
        	}
        }

 	private Decimal iDESCUENTO;
        public Decimal IDESCUENTO
        { 
        	get
        	{
         		return this.iDESCUENTO;
        	}
        	set
        	{
        		this.iDESCUENTO= value;
        		this.isnull["IDESCUENTO"]=false;
        	}
        }

 	private Decimal iP_UTL1;
        public Decimal IP_UTL1
        { 
        	get
        	{
         		return this.iP_UTL1;
        	}
        	set
        	{
        		this.iP_UTL1= value;
        		this.isnull["IP_UTL1"]=false;
        	}
        }

 	private Decimal iP_UTL2;
        public Decimal IP_UTL2
        { 
        	get
        	{
         		return this.iP_UTL2;
        	}
        	set
        	{
        		this.iP_UTL2= value;
        		this.isnull["IP_UTL2"]=false;
        	}
        }

 	private Decimal iP_UTL3;
        public Decimal IP_UTL3
        { 
        	get
        	{
         		return this.iP_UTL3;
        	}
        	set
        	{
        		this.iP_UTL3= value;
        		this.isnull["IP_UTL3"]=false;
        	}
        }

 	private Decimal iP_UTL4;
        public Decimal IP_UTL4
        { 
        	get
        	{
         		return this.iP_UTL4;
        	}
        	set
        	{
        		this.iP_UTL4= value;
        		this.isnull["IP_UTL4"]=false;
        	}
        }

 	private Decimal iP_UTL5;
        public Decimal IP_UTL5
        { 
        	get
        	{
         		return this.iP_UTL5;
        	}
        	set
        	{
        		this.iP_UTL5= value;
        		this.isnull["IP_UTL5"]=false;
        	}
        }

 	private Decimal iP_UTL6;
        public Decimal IP_UTL6
        { 
        	get
        	{
         		return this.iP_UTL6;
        	}
        	set
        	{
        		this.iP_UTL6= value;
        		this.isnull["IP_UTL6"]=false;
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
		
               public CM_PROPBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IPRODUCTO",true);
	

			isnull.Add("IDESC1",true);
	

			isnull.Add("IEXIS1",true);
	

			isnull.Add("IBOTCAJA",true);
	

			isnull.Add("IPRECIO1",true);
	

			isnull.Add("IPLAZO",true);
	

			isnull.Add("IPRECIO2",true);
	

			isnull.Add("IDESCUENTO",true);
	

			isnull.Add("IP_UTL1",true);
	

			isnull.Add("IP_UTL2",true);
	

			isnull.Add("IP_UTL3",true);
	

			isnull.Add("IP_UTL4",true);
	

			isnull.Add("IP_UTL5",true);
	

			isnull.Add("IP_UTL6",true);
	

			isnull.Add("IID",true);
	

			isnull.Add("IID_FECHA",true);
	

			isnull.Add("IID_HORA",true);
	
		}

		

	}
}
