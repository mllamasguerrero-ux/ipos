using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace iPosBusinessEntity
{
	public class CINVMOVINVENTARIOSSUCURSALBE
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

 	private string iLOTE;
        public string ILOTE
        { 
        	get
        	{
         		return this.iLOTE;
        	}
        	set
        	{
        		this.iLOTE= value;
        		this.isnull["ILOTE"]=false;
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
		
               public CINVMOVINVENTARIOSSUCURSALBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("IALMACENCLAVE",true);
	

			isnull.Add("ICLAVE",true);
	

			isnull.Add("ILOTE",true);
	

			isnull.Add("IFECHAVENCE",true);
	

			isnull.Add("ICANTIDAD",true);
	

			isnull.Add("ISUCURSALCLAVE",true);
	
		}

		

	}
}
