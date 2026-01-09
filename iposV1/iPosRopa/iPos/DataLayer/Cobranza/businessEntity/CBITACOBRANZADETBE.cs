
using System;
using System.Collections;
namespace iPosBusinessEntity
{
	public class CBITACOBRANZADETBE
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

 	private long iBITCOBRANZAID;
        public long IBITCOBRANZAID
        { 
        	get
        	{
         		return this.iBITCOBRANZAID;
        	}
        	set
        	{
        		this.iBITCOBRANZAID= value;
        		this.isnull["IBITCOBRANZAID"]=false;
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

 	private long iCOBRADORID;
        public long ICOBRADORID
        { 
        	get
        	{
         		return this.iCOBRADORID;
        	}
        	set
        	{
        		this.iCOBRADORID= value;
        		this.isnull["ICOBRADORID"]=false;
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

 	private decimal iSALDO;
        public decimal ISALDO
        { 
        	get
        	{
         		return this.iSALDO;
        	}
        	set
        	{
        		this.iSALDO= value;
        		this.isnull["ISALDO"]=false;
        	}
        }

 	private DateTime iFECHAVENCE;
        public DateTime IFECHAVENCE
        { 
        	get
        	{
         		return this.iFECHAVENCE;
        	}
        	set
        	{
        		this.iFECHAVENCE= value;
        		this.isnull["IFECHAVENCE"]=false;
        	}
        }

 	private string iDIAPAGOS;
        public string IDIAPAGOS
        { 
        	get
        	{
         		return this.iDIAPAGOS;
        	}
        	set
        	{
        		this.iDIAPAGOS= value;
        		this.isnull["IDIAPAGOS"]=false;
        	}
        }

 	private decimal iABONO;
        public decimal IABONO
        { 
        	get
        	{
         		return this.iABONO;
        	}
        	set
        	{
        		this.iABONO= value;
        		this.isnull["IABONO"]=false;
        	}
        }

 	private long iDOCTOPAGOID;
        public long IDOCTOPAGOID
        { 
        	get
        	{
         		return this.iDOCTOPAGOID;
        	}
        	set
        	{
        		this.iDOCTOPAGOID= value;
        		this.isnull["IDOCTOPAGOID"]=false;
        	}
        }

 	private long iESTADO;
        public long IESTADO
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

 	private string iOBSERVACIONES;
        public string IOBSERVACIONES
        { 
        	get
        	{
         		return this.iOBSERVACIONES;
        	}
        	set
        	{
        		this.iOBSERVACIONES= value;
        		this.isnull["IOBSERVACIONES"]=false;
        	}
        }

 	private DateTime iNUEVAFECHACOBRO;
        public DateTime INUEVAFECHACOBRO
        { 
        	get
        	{
         		return this.iNUEVAFECHACOBRO;
        	}
        	set
        	{
        		this.iNUEVAFECHACOBRO= value;
        		this.isnull["INUEVAFECHACOBRO"]=false;
        	}
        }
		
               public CBITACOBRANZADETBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("IBITCOBRANZAID",true);
	

			isnull.Add("IFECHA",true);
	

			isnull.Add("ICOBRADORID",true);
	

			isnull.Add("IPERSONAID",true);
	

			isnull.Add("IDOCTOID",true);
	

			isnull.Add("ISALDO",true);
	

			isnull.Add("IFECHAVENCE",true);
	

			isnull.Add("IDIAPAGOS",true);
	

			isnull.Add("IABONO",true);
	

			isnull.Add("IDOCTOPAGOID",true);
	

			isnull.Add("IESTADO",true);
	

			isnull.Add("IOBSERVACIONES",true);
	

			isnull.Add("INUEVAFECHACOBRO",true);
	
		}

		

	}
}
