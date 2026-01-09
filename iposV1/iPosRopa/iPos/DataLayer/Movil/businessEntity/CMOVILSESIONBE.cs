
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CMOVILSESIONBE
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

 	private string iVENDEDORCLAVE;
        public string IVENDEDORCLAVE
        { 
        	get
        	{
         		return this.iVENDEDORCLAVE;
        	}
        	set
        	{
        		this.iVENDEDORCLAVE= value;
        		this.isnull["IVENDEDORCLAVE"]=false;
        	}
        }

 	private DateTime iFECHAINICIOVENTA;
        public DateTime IFECHAINICIOVENTA
        { 
        	get
        	{
         		return this.iFECHAINICIOVENTA;
        	}
        	set
        	{
        		this.iFECHAINICIOVENTA= value;
        		this.isnull["IFECHAINICIOVENTA"]=false;
        	}
        }

 	private DateTime iFECHAINICIOCOBRA;
        public DateTime IFECHAINICIOCOBRA
        { 
        	get
        	{
         		return this.iFECHAINICIOCOBRA;
        	}
        	set
        	{
        		this.iFECHAINICIOCOBRA= value;
        		this.isnull["IFECHAINICIOCOBRA"]=false;
        	}
        }

 	private long iFOLIOINICIOVENTA;
        public long IFOLIOINICIOVENTA
        { 
        	get
        	{
         		return this.iFOLIOINICIOVENTA;
        	}
        	set
        	{
        		this.iFOLIOINICIOVENTA= value;
        		this.isnull["IFOLIOINICIOVENTA"]=false;
        	}
        }

 	private long iFOLIOINICIOCOBRA;
        public long IFOLIOINICIOCOBRA
        { 
        	get
        	{
         		return this.iFOLIOINICIOCOBRA;
        	}
        	set
        	{
        		this.iFOLIOINICIOCOBRA= value;
        		this.isnull["IFOLIOINICIOCOBRA"]=false;
        	}
        }

 	private DateTime iFECHAFINVENTA;
        public DateTime IFECHAFINVENTA
        { 
        	get
        	{
         		return this.iFECHAFINVENTA;
        	}
        	set
        	{
        		this.iFECHAFINVENTA= value;
        		this.isnull["IFECHAFINVENTA"]=false;
        	}
        }

 	private DateTime iFECHAFINCOBRA;
        public DateTime IFECHAFINCOBRA
        { 
        	get
        	{
         		return this.iFECHAFINCOBRA;
        	}
        	set
        	{
        		this.iFECHAFINCOBRA= value;
        		this.isnull["IFECHAFINCOBRA"]=false;
        	}
        }

 	private long iFOLIOFINVENTA;
        public long IFOLIOFINVENTA
        { 
        	get
        	{
         		return this.iFOLIOFINVENTA;
        	}
        	set
        	{
        		this.iFOLIOFINVENTA= value;
        		this.isnull["IFOLIOFINVENTA"]=false;
        	}
        }

 	private long iFOLIOFINCOBRA;
        public long IFOLIOFINCOBRA
        { 
        	get
        	{
         		return this.iFOLIOFINCOBRA;
        	}
        	set
        	{
        		this.iFOLIOFINCOBRA= value;
        		this.isnull["IFOLIOFINCOBRA"]=false;
        	}
        }
		
               public CMOVILSESIONBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("IVENDEDORCLAVE",true);
	

			isnull.Add("IFECHAINICIOVENTA",true);
	

			isnull.Add("IFECHAINICIOCOBRA",true);
	

			isnull.Add("IFOLIOINICIOVENTA",true);
	

			isnull.Add("IFOLIOINICIOCOBRA",true);
	

			isnull.Add("IFECHAFINVENTA",true);
	

			isnull.Add("IFECHAFINCOBRA",true);
	

			isnull.Add("IFOLIOFINVENTA",true);
	

			isnull.Add("IFOLIOFINCOBRA",true);
	
		}

		

	}
}
