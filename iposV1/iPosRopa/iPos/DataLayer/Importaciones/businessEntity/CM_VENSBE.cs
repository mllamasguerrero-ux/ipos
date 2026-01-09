
using System;
using System.Collections;
namespace iPosBusinessEntity
{
	public class CM_VENSBE
	{
	public Hashtable isnull;

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

 	private string iESTATUS;
        public string IESTATUS
        { 
        	get
        	{
         		return this.iESTATUS;
        	}
        	set
        	{
        		this.iESTATUS= value;
        		this.isnull["IESTATUS"]=false;
        	}
        }

 	private string iESTATUS2;
        public string IESTATUS2
        { 
        	get
        	{
         		return this.iESTATUS2;
        	}
        	set
        	{
        		this.iESTATUS2= value;
        		this.isnull["IESTATUS2"]=false;
        	}
        }

 	private string iNOTA1;
        public string INOTA1
        { 
        	get
        	{
         		return this.iNOTA1;
        	}
        	set
        	{
        		this.iNOTA1= value;
        		this.isnull["INOTA1"]=false;
        	}
        }

 	private string iNOTA2;
        public string INOTA2
        { 
        	get
        	{
         		return this.iNOTA2;
        	}
        	set
        	{
        		this.iNOTA2= value;
        		this.isnull["INOTA2"]=false;
        	}
        }

 	private string iPLAZOS;
        public string IPLAZOS
        { 
        	get
        	{
         		return this.iPLAZOS;
        	}
        	set
        	{
        		this.iPLAZOS= value;
        		this.isnull["IPLAZOS"]=false;
        	}
        }

 	private string iSUGERIDOS;
        public string ISUGERIDOS
        { 
        	get
        	{
         		return this.iSUGERIDOS;
        	}
        	set
        	{
        		this.iSUGERIDOS= value;
        		this.isnull["ISUGERIDOS"]=false;
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

 	private DateTime iF_FACTURA;
        public DateTime IF_FACTURA
        { 
        	get
        	{
         		return this.iF_FACTURA;
        	}
        	set
        	{
        		this.iF_FACTURA= value;
        		this.isnull["IF_FACTURA"]=false;
        	}
        }
		
               public CM_VENSBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IVENTA",true);
	

			isnull.Add("ICLIENTE",true);
	

			isnull.Add("IESTATUS",true);
	

			isnull.Add("IESTATUS2",true);
	

			isnull.Add("INOTA1",true);
	

			isnull.Add("INOTA2",true);
	

			isnull.Add("IPLAZOS",true);
	

			isnull.Add("ISUGERIDOS",true);
	

			isnull.Add("IID",true);
	

			isnull.Add("IID_FECHA",true);
	

			isnull.Add("IID_HORA",true);
	

			isnull.Add("IF_FACTURA",true);
	
		}

		

	}
}
