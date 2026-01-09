
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CDOCTOVISITABE
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


 	private long iDOCTOID;
        public long IDOCTOID
        { 
        	get
        	{
         		return this.iDOCTOID;
        	}
        	set
        	{
        		this.iDOCTOID= value;
        		this.isnull["IDOCTOID"]=false;
        	}
        }

 	private long iCAJAID;
        public long ICAJAID
        { 
        	get
        	{
         		return this.iCAJAID;
        	}
        	set
        	{
        		this.iCAJAID= value;
        		this.isnull["ICAJAID"]=false;
        	}
        }

 	private DateTime iFECHAHORA;
        public DateTime IFECHAHORA
        { 
        	get
        	{
         		return this.iFECHAHORA;
        	}
        	set
        	{
        		this.iFECHAHORA= value;
        		this.isnull["IFECHAHORA"]=false;
        	}
        }

 	private long iUSUARIOID;
        public long IUSUARIOID
        { 
        	get
        	{
         		return this.iUSUARIOID;
        	}
        	set
        	{
        		this.iUSUARIOID= value;
        		this.isnull["IUSUARIOID"]=false;
        	}
        }
		
               public CDOCTOVISITABE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	
	

			isnull.Add("IDOCTOID",true);
	

			isnull.Add("ICAJAID",true);
	

			isnull.Add("IFECHAHORA",true);
	

			isnull.Add("IUSUARIOID",true);
	
		}

		

	}
}
