
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CVISITABE
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

        private DateTime iHORAINICIO;
        public DateTime IHORAINICIO
        { 
        	get
        	{
         		return this.iHORAINICIO;
        	}
        	set
        	{
        		this.iHORAINICIO= value;
        		this.isnull["IHORAINICIO"]=false;
        	}
        }

        private DateTime iHORAFIN;
        public DateTime IHORAFIN
        { 
        	get
        	{
         		return this.iHORAFIN;
        	}
        	set
        	{
        		this.iHORAFIN= value;
        		this.isnull["IHORAFIN"]=false;
        	}
        }

 	private long iPERSONAID;
        public long IPERSONAID
        { 
        	get
        	{
         		return this.iPERSONAID;
        	}
        	set
        	{
        		this.iPERSONAID= value;
        		this.isnull["IPERSONAID"]=false;
        	}
        }

 	private string iPERSONACLAVE;
        public string IPERSONACLAVE
        { 
        	get
        	{
         		return this.iPERSONACLAVE;
        	}
        	set
        	{
        		this.iPERSONACLAVE= value;
        		this.isnull["IPERSONACLAVE"]=false;
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

 	private string iENVIADOWS;
        public string IENVIADOWS
        { 
        	get
        	{
         		return this.iENVIADOWS;
        	}
        	set
        	{
        		this.iENVIADOWS= value;
        		this.isnull["IENVIADOWS"]=false;
        	}
        }
		
               public CVISITABE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("IFECHA",true);
	

			isnull.Add("IHORAINICIO",true);
	

			isnull.Add("IHORAFIN",true);
	

			isnull.Add("IPERSONAID",true);
	

			isnull.Add("IPERSONACLAVE",true);
	

			isnull.Add("IHIZOPEDIDO",true);
	

			isnull.Add("IENVIADOWS",true);
	
		}

		

	}
}
