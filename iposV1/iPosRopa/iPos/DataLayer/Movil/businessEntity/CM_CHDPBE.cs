
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CM_CHDPBE
	{
	public Hashtable isnull;

 	private string iPAGO;
        public string IPAGO
        { 
        	get
        	{
         		return this.iPAGO;
        	}
        	set
        	{
        		this.iPAGO= value;
        		this.isnull["IPAGO"]=false;
        	}
        }

 	private DateTime iFECHA;
        public DateTime IFECHA
        { 
        	get
        	{
         		return this.iFECHA;
        	}
        	set
        	{
        		this.iFECHA= value;
        		this.isnull["IFECHA"]=false;
        	}
        }

 	private string iVENTA;
        public string IVENTA
        { 
        	get
        	{
         		return this.iVENTA;
        	}
        	set
        	{
        		this.iVENTA= value;
        		this.isnull["IVENTA"]=false;
        	}
        }

 	private decimal iCARGO;
        public decimal ICARGO
        { 
        	get
        	{
         		return this.iCARGO;
        	}
        	set
        	{
        		this.iCARGO= value;
        		this.isnull["ICARGO"]=false;
        	}
        }

 	private decimal iABONO;
        public decimal IABONO
        { 
        	get
        	{
         		return this.iABONO;
        	}
        	set
        	{
        		this.iABONO= value;
        		this.isnull["IABONO"]=false;
        	}
        }

 	private decimal iSALDO;
        public decimal ISALDO
        { 
        	get
        	{
         		return this.iSALDO;
        	}
        	set
        	{
        		this.iSALDO= value;
        		this.isnull["ISALDO"]=false;
        	}
        }

 	private decimal iINTERESES;
        public decimal IINTERESES
        { 
        	get
        	{
         		return this.iINTERESES;
        	}
        	set
        	{
        		this.iINTERESES= value;
        		this.isnull["IINTERESES"]=false;
        	}
        }

 	private int iNUMERO;
        public int INUMERO
        { 
        	get
        	{
         		return this.iNUMERO;
        	}
        	set
        	{
        		this.iNUMERO= value;
        		this.isnull["INUMERO"]=false;
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
		
               public CM_CHDPBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IPAGO",true);
	

			isnull.Add("IFECHA",true);
	

			isnull.Add("IVENTA",true);
	

			isnull.Add("ICARGO",true);
	

			isnull.Add("IABONO",true);
	

			isnull.Add("ISALDO",true);
	

			isnull.Add("IINTERESES",true);
	

			isnull.Add("INUMERO",true);
	

			isnull.Add("IID",true);
	

			isnull.Add("IID_FECHA",true);
	

			isnull.Add("IID_HORA",true);
	
		}

		

	}
}
