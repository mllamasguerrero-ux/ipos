
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CM_VISIBE
	{
	public Hashtable isnull;

 	private double iVISITA;
        public double IVISITA
        { 
        	get
        	{
         		return this.iVISITA;
        	}
        	set
        	{
        		this.iVISITA= value;
        		this.isnull["IVISITA"]=false;
        	}
        }

 	private string iCLIENTE;
        public string ICLIENTE
        { 
        	get
        	{
         		return this.iCLIENTE;
        	}
        	set
        	{
        		this.iCLIENTE= value;
        		this.isnull["ICLIENTE"]=false;
        	}
        }

 	private string iHIZOPEDIDO;
        public string IHIZOPEDIDO
        { 
        	get
        	{
         		return this.iHIZOPEDIDO;
        	}
        	set
        	{
        		this.iHIZOPEDIDO= value;
        		this.isnull["IHIZOPEDIDO"]=false;
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

 	private string iINICIA;
        public string IINICIA
        { 
        	get
        	{
         		return this.iINICIA;
        	}
        	set
        	{
        		this.iINICIA= value;
        		this.isnull["IINICIA"]=false;
        	}
        }

 	private string iFINALIZA;
        public string IFINALIZA
        { 
        	get
        	{
         		return this.iFINALIZA;
        	}
        	set
        	{
        		this.iFINALIZA= value;
        		this.isnull["IFINALIZA"]=false;
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
		
               public CM_VISIBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IVISITA",true);
	

			isnull.Add("ICLIENTE",true);
	

			isnull.Add("IHIZOPEDIDO",true);
	

			isnull.Add("IFECHA",true);
	

			isnull.Add("IINICIA",true);
	

			isnull.Add("IFINALIZA",true);
	

			isnull.Add("IID",true);
	

			isnull.Add("IID_FECHA",true);
	

			isnull.Add("IID_HORA",true);
	
		}

		

	}
}
