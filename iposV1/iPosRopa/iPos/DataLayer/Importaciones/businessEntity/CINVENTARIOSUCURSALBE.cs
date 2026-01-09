

using System;
using System.Collections;
namespace iPosBusinessEntity
{
	public class CINVENTARIOSUCURSALBE
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

 	private long iSUCURSALID;
        public long ISUCURSALID
        { 
        	get
        	{
         		return this.iSUCURSALID;
        	}
        	set
        	{
        		this.iSUCURSALID= value;
        		this.isnull["ISUCURSALID"]=false;
        	}
        }

 	private string iSUCURSALCLAVE;
        public string ISUCURSALCLAVE
        { 
        	get
        	{
         		return this.iSUCURSALCLAVE;
        	}
        	set
        	{
        		this.iSUCURSALCLAVE= value;
        		this.isnull["ISUCURSALCLAVE"]=false;
        	}
        }

 	private long iALMACENID;
        public long IALMACENID
        { 
        	get
        	{
         		return this.iALMACENID;
        	}
        	set
        	{
        		this.iALMACENID= value;
        		this.isnull["IALMACENID"]=false;
        	}
        }

 	private string iALMACENCLAVE;
        public string IALMACENCLAVE
        { 
        	get
        	{
         		return this.iALMACENCLAVE;
        	}
        	set
        	{
        		this.iALMACENCLAVE= value;
        		this.isnull["IALMACENCLAVE"]=false;
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

 	private string iPRODUCTOCLAVE;
        public string IPRODUCTOCLAVE
        { 
        	get
        	{
         		return this.iPRODUCTOCLAVE;
        	}
        	set
        	{
        		this.iPRODUCTOCLAVE= value;
        		this.isnull["IPRODUCTOCLAVE"]=false;
        	}
        }

 	private TimeSpan iHORA;
        public TimeSpan IHORA
        { 
        	get
        	{
         		return this.iHORA;
        	}
        	set
        	{
        		this.iHORA= value;
        		this.isnull["IHORA"]=false;
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

 	private decimal iCANTIDAD;
        public decimal ICANTIDAD
        { 
        	get
        	{
         		return this.iCANTIDAD;
        	}
        	set
        	{
        		this.iCANTIDAD= value;
        		this.isnull["ICANTIDAD"]=false;
        	}
        }

 	private decimal iCOSTO;
        public decimal ICOSTO
        { 
        	get
        	{
         		return this.iCOSTO;
        	}
        	set
        	{
        		this.iCOSTO= value;
        		this.isnull["ICOSTO"]=false;
        	}
        }

 	private decimal iCOSTOULTIMO;
        public decimal ICOSTOULTIMO
        { 
        	get
        	{
         		return this.iCOSTOULTIMO;
        	}
        	set
        	{
        		this.iCOSTOULTIMO= value;
        		this.isnull["ICOSTOULTIMO"]=false;
        	}
        }

 	private decimal iCOSTOPROMEDIO;
        public decimal ICOSTOPROMEDIO
        { 
        	get
        	{
         		return this.iCOSTOPROMEDIO;
        	}
        	set
        	{
        		this.iCOSTOPROMEDIO= value;
        		this.isnull["ICOSTOPROMEDIO"]=false;
        	}
        }

 	private DateTime iULTIMAFECHACOMPRA;
        public DateTime IULTIMAFECHACOMPRA
        { 
        	get
        	{
         		return this.iULTIMAFECHACOMPRA;
        	}
        	set
        	{
        		this.iULTIMAFECHACOMPRA= value;
        		this.isnull["IULTIMAFECHACOMPRA"]=false;
        	}
        }

 	private DateTime iULTIMAFECHAVENTA;
        public DateTime IULTIMAFECHAVENTA
        { 
        	get
        	{
         		return this.iULTIMAFECHAVENTA;
        	}
        	set
        	{
        		this.iULTIMAFECHAVENTA= value;
        		this.isnull["IULTIMAFECHAVENTA"]=false;
        	}
        }
		
               public CINVENTARIOSUCURSALBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("ISUCURSALID",true);
	

			isnull.Add("ISUCURSALCLAVE",true);
	

			isnull.Add("IALMACENID",true);
	

			isnull.Add("IALMACENCLAVE",true);
	

			isnull.Add("IPRODUCTOID",true);
	

			isnull.Add("IPRODUCTOCLAVE",true);
	

			isnull.Add("IHORA",true);
	

			isnull.Add("IFECHA",true);
	

			isnull.Add("ICANTIDAD",true);
	

			isnull.Add("ICOSTO",true);
	

			isnull.Add("ICOSTOULTIMO",true);
	

			isnull.Add("ICOSTOPROMEDIO",true);
	

			isnull.Add("IULTIMAFECHACOMPRA",true);
	

			isnull.Add("IULTIMAFECHAVENTA",true);
	
		}

		

	}
}
