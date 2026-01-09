
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CINVMOVPRODLOCATIONBE
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

 	private string iANAQUEL;
        public string IANAQUEL
        { 
        	get
        	{
         		return this.iANAQUEL;
        	}
        	set
        	{
        		this.iANAQUEL= value;
        		this.isnull["IANAQUEL"]=false;
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
		
               public CINVMOVPRODLOCATIONBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("ISUCURSALCLAVE",true);
	

			isnull.Add("IALMACENCLAVE",true);
	

			isnull.Add("IANAQUEL",true);
	

			isnull.Add("ILOCALIDAD",true);
	

			isnull.Add("IPRODUCTOCLAVE",true);
	
		}

		

	}
}
