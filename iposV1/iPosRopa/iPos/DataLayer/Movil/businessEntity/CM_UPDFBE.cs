
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CM_UPDFBE
	{
	public Hashtable isnull;

 	private string iVENDEDOR;
        public string IVENDEDOR
        { 
        	get
        	{
         		return this.iVENDEDOR;
        	}
        	set
        	{
        		this.iVENDEDOR= value;
        		this.isnull["IVENDEDOR"]=false;
        	}
        }

 	private string iDIA;
        public string IDIA
        { 
        	get
        	{
         		return this.iDIA;
        	}
        	set
        	{
        		this.iDIA= value;
        		this.isnull["IDIA"]=false;
        	}
        }

 	private string iESTADO;
        public string IESTADO
        { 
        	get
        	{
         		return this.iESTADO;
        	}
        	set
        	{
        		this.iESTADO= value;
        		this.isnull["IESTADO"]=false;
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
		
               public CM_UPDFBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IVENDEDOR",true);
	

			isnull.Add("IDIA",true);
	

			isnull.Add("IESTADO",true);
	

			isnull.Add("IID",true);
	

			isnull.Add("IID_FECHA",true);
	

			isnull.Add("IID_HORA",true);
	
		}

		

	}
}
