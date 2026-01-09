
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CMONTOBILLETESLOGBE
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

 	private long iMONTOBILLETESID;
        public long IMONTOBILLETESID
        { 
        	get
        	{
         		return this.iMONTOBILLETESID;
        	}
        	set
        	{
        		this.iMONTOBILLETESID= value;
        		this.isnull["IMONTOBILLETESID"]=false;
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

 	private decimal iSALDOFINALANTERIOR;
        public decimal ISALDOFINALANTERIOR
        { 
        	get
        	{
         		return this.iSALDOFINALANTERIOR;
        	}
        	set
        	{
        		this.iSALDOFINALANTERIOR= value;
        		this.isnull["ISALDOFINALANTERIOR"]=false;
        	}
        }

 	private decimal iSALDOFINALNUEVO;
        public decimal ISALDOFINALNUEVO
        { 
        	get
        	{
         		return this.iSALDOFINALNUEVO;
        	}
        	set
        	{
        		this.iSALDOFINALNUEVO= value;
        		this.isnull["ISALDOFINALNUEVO"]=false;
        	}
        }

 	private DateTime iFECHACAMBIO;
        public DateTime IFECHACAMBIO
        { 
        	get
        	{
         		return this.iFECHACAMBIO;
        	}
        	set
        	{
        		this.iFECHACAMBIO= value;
        		this.isnull["IFECHACAMBIO"]=false;
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
		
               public CMONTOBILLETESLOGBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("IMONTOBILLETESID",true);
	

			isnull.Add("INOTA",true);
	

			isnull.Add("ISALDOFINALANTERIOR",true);
	

			isnull.Add("ISALDOFINALNUEVO",true);
	

			isnull.Add("IFECHACAMBIO",true);
	

			isnull.Add("IUSUARIOID",true);
	
		}

		

	}
}
