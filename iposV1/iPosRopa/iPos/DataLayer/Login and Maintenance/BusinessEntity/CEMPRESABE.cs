
using System;
using System.Collections;
namespace iPosBusinessEntity
{
	public class CEMPRESABE
	{
	public Hashtable isnull;
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
 	private string iCALLE;
        public string ICALLE
        { 
        	get
        	{
         		return this.iCALLE;
        	}
        	set
        	{
        		this.iCALLE= value;
        		this.isnull["ICALLE"]=false;
        	}
        }
 	private string iCOLONIA;
        public string ICOLONIA
        { 
        	get
        	{
         		return this.iCOLONIA;
        	}
        	set
        	{
        		this.iCOLONIA= value;
        		this.isnull["ICOLONIA"]=false;
        	}
        }
 	private string iLOCALIDAD;
        public string ILOCALIDAD
        { 
        	get
        	{
         		return this.iLOCALIDAD;
        	}
        	set
        	{
        		this.iLOCALIDAD= value;
        		this.isnull["ILOCALIDAD"]=false;
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
 	private string iCP;
        public string ICP
        { 
        	get
        	{
         		return this.iCP;
        	}
        	set
        	{
        		this.iCP= value;
        		this.isnull["ICP"]=false;
        	}
        }
 	private string iTELEFONO;
        public string ITELEFONO
        { 
        	get
        	{
         		return this.iTELEFONO;
        	}
        	set
        	{
        		this.iTELEFONO= value;
        		this.isnull["ITELEFONO"]=false;
        	}
        }
 	private string iFAX;
        public string IFAX
        { 
        	get
        	{
         		return this.iFAX;
        	}
        	set
        	{
        		this.iFAX= value;
        		this.isnull["IFAX"]=false;
        	}
        }
 	private string iCORREOE;
        public string ICORREOE
        { 
        	get
        	{
         		return this.iCORREOE;
        	}
        	set
        	{
        		this.iCORREOE= value;
        		this.isnull["ICORREOE"]=false;
        	}
        }
 	private string iPAGINAWEB;
        public string IPAGINAWEB
        { 
        	get
        	{
         		return this.iPAGINAWEB;
        	}
        	set
        	{
        		this.iPAGINAWEB= value;
        		this.isnull["IPAGINAWEB"]=false;
        	}
        }
 	private string iRFC;
        public string IRFC
        { 
        	get
        	{
         		return this.iRFC;
        	}
        	set
        	{
        		this.iRFC= value;
        		this.isnull["IRFC"]=false;
        	}
        }
        private string iLISTA_PRECIO_DEF;
        public string ILISTA_PRECIO_DEF
        {
            get
            {
                return this.iLISTA_PRECIO_DEF;
            }
            set
            {
                this.iLISTA_PRECIO_DEF = value;
                this.isnull["ILISTA_PRECIO_DEF"] = false;
            }
        }
        private decimal iIMP_PROD_DEF;
        public decimal IIMP_PROD_DEF
        {
            get
            {
                return this.iIMP_PROD_DEF;
            }
            set
            {
                this.iIMP_PROD_DEF = value;
                this.isnull["IIMP_PROD_DEF"] = false;
            }
        }
        private string iESTADO_DEF;
        public string IESTADO_DEF
        {
            get
            {
                return this.iESTADO_DEF;
            }
            set
            {
                this.iESTADO_DEF = value;
                this.isnull["IESTADO_DEF"] = false;
            }
        }


        private string iSUCURSAL;
        public string ISUCURSAL
        {
            get
            {
                return this.iSUCURSAL;
            }
            set
            {
                this.iSUCURSAL = value;
                this.isnull["ISUCURSAL"] = false;
            }
        }



               public CEMPRESABE()
		{
		isnull=new Hashtable();
	
			isnull.Add("INOMBRE",true);
	
			isnull.Add("ICALLE",true);
	
			isnull.Add("ICOLONIA",true);
	
			isnull.Add("ILOCALIDAD",true);
	
			isnull.Add("IESTADO",true);
	
			isnull.Add("ICP",true);
	
			isnull.Add("ITELEFONO",true);
	
			isnull.Add("IFAX",true);
	
			isnull.Add("ICORREOE",true);
	
			isnull.Add("IPAGINAWEB",true);
	
			isnull.Add("IRFC",true);
            isnull.Add("ILISTA_PRECIO_DEF", true);
            isnull.Add("IIMP_PROD_DEF", true);
            isnull.Add("IESTADO_DEF", true);
            isnull.Add("ISUCURSAL", true);

	
		}
		
	}
}
