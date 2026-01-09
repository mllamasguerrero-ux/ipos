
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CSAT_CLAVEUNIDADPESOBE
	{
	public Hashtable isnull;

 	private long iID;
        public long IID
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

 	private string iACTIVO;
        public string IACTIVO
        { 
        	get
        	{
         		return this.iACTIVO;
        	}
        	set
        	{
        		this.iACTIVO= value;
        		this.isnull["IACTIVO"]=false;
        	}
        }

 	private object iCREADO;
        public object ICREADO
        { 
        	get
        	{
         		return this.iCREADO;
        	}
        	set
        	{
        		this.iCREADO= value;
        		this.isnull["ICREADO"]=false;
        	}
        }

 	private long iCREADOPOR_USERID;
        public long ICREADOPOR_USERID
        { 
        	get
        	{
         		return this.iCREADOPOR_USERID;
        	}
        	set
        	{
        		this.iCREADOPOR_USERID= value;
        		this.isnull["ICREADOPOR_USERID"]=false;
        	}
        }

 	private object iMODIFICADO;
        public object IMODIFICADO
        { 
        	get
        	{
         		return this.iMODIFICADO;
        	}
        	set
        	{
        		this.iMODIFICADO= value;
        		this.isnull["IMODIFICADO"]=false;
        	}
        }

 	private long iMODIFICADOPOR_USERID;
        public long IMODIFICADOPOR_USERID
        { 
        	get
        	{
         		return this.iMODIFICADOPOR_USERID;
        	}
        	set
        	{
        		this.iMODIFICADOPOR_USERID= value;
        		this.isnull["IMODIFICADOPOR_USERID"]=false;
        	}
        }

 	private string iCLAVE;
        public string ICLAVE
        { 
        	get
        	{
         		return this.iCLAVE;
        	}
        	set
        	{
        		this.iCLAVE= value;
        		this.isnull["ICLAVE"]=false;
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

 	private string iDESCRIPCION;
        public string IDESCRIPCION
        { 
        	get
        	{
         		return this.iDESCRIPCION;
        	}
        	set
        	{
        		this.iDESCRIPCION= value;
        		this.isnull["IDESCRIPCION"]=false;
        	}
        }

 	private string iNOTA;
        public string INOTA
        { 
        	get
        	{
         		return this.iNOTA;
        	}
        	set
        	{
        		this.iNOTA= value;
        		this.isnull["INOTA"]=false;
        	}
        }

 	private DateTime iFECHAINICIO;
        public DateTime IFECHAINICIO
        { 
        	get
        	{
         		return this.iFECHAINICIO;
        	}
        	set
        	{
        		this.iFECHAINICIO= value;
        		this.isnull["IFECHAINICIO"]=false;
        	}
        }

 	private DateTime iFECHAFIN;
        public DateTime IFECHAFIN
        { 
        	get
        	{
         		return this.iFECHAFIN;
        	}
        	set
        	{
        		this.iFECHAFIN= value;
        		this.isnull["IFECHAFIN"]=false;
        	}
        }

 	private string iSIMBOLO;
        public string ISIMBOLO
        { 
        	get
        	{
         		return this.iSIMBOLO;
        	}
        	set
        	{
        		this.iSIMBOLO= value;
        		this.isnull["ISIMBOLO"]=false;
        	}
        }

 	private string iBANDERA;
        public string IBANDERA
        { 
        	get
        	{
         		return this.iBANDERA;
        	}
        	set
        	{
        		this.iBANDERA= value;
        		this.isnull["IBANDERA"]=false;
        	}
        }
		
               public CSAT_CLAVEUNIDADPESOBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("ICLAVE",true);
	

			isnull.Add("INOMBRE",true);
	

			isnull.Add("IDESCRIPCION",true);
	

			isnull.Add("INOTA",true);
	

			isnull.Add("IFECHAINICIO",true);
	

			isnull.Add("IFECHAFIN",true);
	

			isnull.Add("ISIMBOLO",true);
	

			isnull.Add("IBANDERA",true);
	
		}

		

	}
}
