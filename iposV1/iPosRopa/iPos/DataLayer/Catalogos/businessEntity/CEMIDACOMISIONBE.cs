using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPosBusinessEntity
{
	public class CEMIDACOMISIONBE
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

 	private string iVERSIONEMIDA;
        public string IVERSIONEMIDA
        { 
        	get
        	{
         		return this.iVERSIONEMIDA;
        	}
        	set
        	{
        		this.iVERSIONEMIDA= value;
        		this.isnull["IVERSIONEMIDA"]=false;
        	}
        }

 	private string iRESPONSECODE;
        public string IRESPONSECODE
        { 
        	get
        	{
         		return this.iRESPONSECODE;
        	}
        	set
        	{
        		this.iRESPONSECODE= value;
        		this.isnull["IRESPONSECODE"]=false;
        	}
        }

 	private string iPRODUCTID;
        public string IPRODUCTID
        { 
        	get
        	{
         		return this.iPRODUCTID;
        	}
        	set
        	{
        		this.iPRODUCTID= value;
        		this.isnull["IPRODUCTID"]=false;
        	}
        }

 	private string iPRODUCTDESCRIPTION;
        public string IPRODUCTDESCRIPTION
        { 
        	get
        	{
         		return this.iPRODUCTDESCRIPTION;
        	}
        	set
        	{
        		this.iPRODUCTDESCRIPTION= value;
        		this.isnull["IPRODUCTDESCRIPTION"]=false;
        	}
        }

 	private string iPRODUCTUFEE;
        public string IPRODUCTUFEE
        { 
        	get
        	{
         		return this.iPRODUCTUFEE;
        	}
        	set
        	{
        		this.iPRODUCTUFEE= value;
        		this.isnull["IPRODUCTUFEE"]=false;
        	}
        }
		
               public CEMIDACOMISIONBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("IVERSIONEMIDA",true);
	

			isnull.Add("IRESPONSECODE",true);
	

			isnull.Add("IPRODUCTID",true);
	

			isnull.Add("IPRODUCTDESCRIPTION",true);
	

			isnull.Add("IPRODUCTUFEE",true);
	
		}

		

	}
}
