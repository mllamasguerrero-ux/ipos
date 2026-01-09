
using System;
using System.Collections;
namespace iPosBusinessEntity
{
	public class CM_VENPBE
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

 	private Decimal iTOTAL;
        public Decimal ITOTAL
        { 
        	get
        	{
         		return this.iTOTAL;
        	}
        	set
        	{
        		this.iTOTAL= value;
        		this.isnull["ITOTAL"]=false;
        	}
        }

 	private string iAUTOCRED;
        public string IAUTOCRED
        { 
        	get
        	{
         		return this.iAUTOCRED;
        	}
        	set
        	{
        		this.iAUTOCRED= value;
        		this.isnull["IAUTOCRED"]=false;
        	}
        }

 	private string iCONTADO;
        public string ICONTADO
        { 
        	get
        	{
         		return this.iCONTADO;
        	}
        	set
        	{
        		this.iCONTADO= value;
        		this.isnull["ICONTADO"]=false;
        	}
        }



        private string iPROCESADO;
        public string IPROCESADO
        {
            get
            {
                return this.iPROCESADO;
            }
            set
            {
                this.iPROCESADO = value;
                this.isnull["IPROCESADO"] = false;
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
		
               public CM_VENPBE()
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
	

			isnull.Add("ITOTAL",true);
	

			isnull.Add("IAUTOCRED",true);
	

			isnull.Add("ICONTADO",true);
	

			isnull.Add("IID",true);
	

			isnull.Add("IID_FECHA",true);
	

			isnull.Add("IID_HORA",true);

            isnull.Add("IPROCESADO", true);
	
		}

		

	}
}
