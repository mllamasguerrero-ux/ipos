
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CINCIDENCIABE
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

 	private long iTIPOINCIDENCIAID;
        public long ITIPOINCIDENCIAID
        { 
        	get
        	{
         		return this.iTIPOINCIDENCIAID;
        	}
        	set
        	{
        		this.iTIPOINCIDENCIAID= value;
        		this.isnull["ITIPOINCIDENCIAID"]=false;
        	}
        }

 	private object iFECHAHORA;
        public object IFECHAHORA
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

 	private long iVENDEDORID;
        public long IVENDEDORID
        { 
        	get
        	{
         		return this.iVENDEDORID;
        	}
        	set
        	{
        		this.iVENDEDORID= value;
        		this.isnull["IVENDEDORID"]=false;
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

 	private long iMOVTOID;
        public long IMOVTOID
        { 
        	get
        	{
         		return this.iMOVTOID;
        	}
        	set
        	{
        		this.iMOVTOID= value;
        		this.isnull["IMOVTOID"]=false;
        	}
        }

 	private long iPRODUCTOID;
        public long IPRODUCTOID
        { 
        	get
        	{
         		return this.iPRODUCTOID;
        	}
        	set
        	{
        		this.iPRODUCTOID= value;
        		this.isnull["IPRODUCTOID"]=false;
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

 	private decimal iCANTIDAD1;
        public decimal ICANTIDAD1
        { 
        	get
        	{
         		return this.iCANTIDAD1;
        	}
        	set
        	{
        		this.iCANTIDAD1= value;
        		this.isnull["ICANTIDAD1"]=false;
        	}
        }

 	private decimal iCANTIDAD2;
        public decimal ICANTIDAD2
        { 
        	get
        	{
         		return this.iCANTIDAD2;
        	}
        	set
        	{
        		this.iCANTIDAD2= value;
        		this.isnull["ICANTIDAD2"]=false;
        	}
        }
		
               public CINCIDENCIABE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("ITIPOINCIDENCIAID",true);
	

			isnull.Add("IFECHAHORA",true);
	

			isnull.Add("IVENDEDORID",true);
	

			isnull.Add("IDOCTOID",true);
	

			isnull.Add("IMOVTOID",true);
	

			isnull.Add("IPRODUCTOID",true);
	

			isnull.Add("INOTA1",true);
	

			isnull.Add("INOTA2",true);
	

			isnull.Add("ICANTIDAD1",true);
	

			isnull.Add("ICANTIDAD2",true);
	
		}

		

	}
}
