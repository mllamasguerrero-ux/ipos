
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CM_CHGPBE
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

 	private string iTIPO;
        public string ITIPO
        { 
        	get
        	{
         		return this.iTIPO;
        	}
        	set
        	{
        		this.iTIPO= value;
        		this.isnull["ITIPO"]=false;
        	}
        }

 	private string iBANCO;
        public string IBANCO
        { 
        	get
        	{
         		return this.iBANCO;
        	}
        	set
        	{
        		this.iBANCO= value;
        		this.isnull["IBANCO"]=false;
        	}
        }

 	private string iID_NUM;
        public string IID_NUM
        { 
        	get
        	{
         		return this.iID_NUM;
        	}
        	set
        	{
        		this.iID_NUM= value;
        		this.isnull["IID_NUM"]=false;
        	}
        }

 	private decimal iIMPORTE;
        public decimal IIMPORTE
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

 	private DateTime iF_DEPOSITO;
        public DateTime IF_DEPOSITO
        { 
        	get
        	{
         		return this.iF_DEPOSITO;
        	}
        	set
        	{
        		this.iF_DEPOSITO= value;
        		this.isnull["IF_DEPOSITO"]=false;
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




		
               public CM_CHGPBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IPAGO",true);
	

			isnull.Add("IFECHA",true);
	

			isnull.Add("ITIPO",true);
	

			isnull.Add("IBANCO",true);
	

			isnull.Add("IID_NUM",true);
	

			isnull.Add("IIMPORTE",true);
	

			isnull.Add("ISALDO",true);
	

			isnull.Add("IINTERESES",true);
	

			isnull.Add("IF_DEPOSITO",true);
	

			isnull.Add("IID",true);
	

			isnull.Add("IID_FECHA",true);
	

			isnull.Add("IID_HORA",true);

        }

		

	}
}
