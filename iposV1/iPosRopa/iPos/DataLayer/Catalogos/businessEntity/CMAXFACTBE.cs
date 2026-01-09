
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CMAXFACTBE
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

 	private int iANIO;
        public int IANIO
        { 
        	get
        	{
         		return this.iANIO;
        	}
        	set
        	{
        		this.iANIO= value;
        		this.isnull["IANIO"]=false;
        	}
        }

 	private int iMES;
        public int IMES
        { 
        	get
        	{
         		return this.iMES;
        	}
        	set
        	{
        		this.iMES= value;
        		this.isnull["IMES"]=false;
        	}
        }

 	private string iLUN_HAY;
        public string ILUN_HAY
        { 
        	get
        	{
         		return this.iLUN_HAY;
        	}
        	set
        	{
        		this.iLUN_HAY= value;
        		this.isnull["ILUN_HAY"]=false;
        	}
        }

 	private decimal iLUN_MAX;
        public decimal ILUN_MAX
        { 
        	get
        	{
         		return this.iLUN_MAX;
        	}
        	set
        	{
        		this.iLUN_MAX= value;
        		this.isnull["ILUN_MAX"]=false;
        	}
        }

 	private string iMAR_HAY;
        public string IMAR_HAY
        { 
        	get
        	{
         		return this.iMAR_HAY;
        	}
        	set
        	{
        		this.iMAR_HAY= value;
        		this.isnull["IMAR_HAY"]=false;
        	}
        }

 	private decimal iMAR_MAX;
        public decimal IMAR_MAX
        { 
        	get
        	{
         		return this.iMAR_MAX;
        	}
        	set
        	{
        		this.iMAR_MAX= value;
        		this.isnull["IMAR_MAX"]=false;
        	}
        }

 	private string iMIE_HAY;
        public string IMIE_HAY
        { 
        	get
        	{
         		return this.iMIE_HAY;
        	}
        	set
        	{
        		this.iMIE_HAY= value;
        		this.isnull["IMIE_HAY"]=false;
        	}
        }

 	private decimal iMIE_MAX;
        public decimal IMIE_MAX
        { 
        	get
        	{
         		return this.iMIE_MAX;
        	}
        	set
        	{
        		this.iMIE_MAX= value;
        		this.isnull["IMIE_MAX"]=false;
        	}
        }

 	private string iJUE_HAY;
        public string IJUE_HAY
        { 
        	get
        	{
         		return this.iJUE_HAY;
        	}
        	set
        	{
        		this.iJUE_HAY= value;
        		this.isnull["IJUE_HAY"]=false;
        	}
        }

 	private decimal iJUE_MAX;
        public decimal IJUE_MAX
        { 
        	get
        	{
         		return this.iJUE_MAX;
        	}
        	set
        	{
        		this.iJUE_MAX= value;
        		this.isnull["IJUE_MAX"]=false;
        	}
        }

 	private string iVIE_HAY;
        public string IVIE_HAY
        { 
        	get
        	{
         		return this.iVIE_HAY;
        	}
        	set
        	{
        		this.iVIE_HAY= value;
        		this.isnull["IVIE_HAY"]=false;
        	}
        }

 	private decimal iVIE_MAX;
        public decimal IVIE_MAX
        { 
        	get
        	{
         		return this.iVIE_MAX;
        	}
        	set
        	{
        		this.iVIE_MAX= value;
        		this.isnull["IVIE_MAX"]=false;
        	}
        }

 	private string iSAB_HAY;
        public string ISAB_HAY
        { 
        	get
        	{
         		return this.iSAB_HAY;
        	}
        	set
        	{
        		this.iSAB_HAY= value;
        		this.isnull["ISAB_HAY"]=false;
        	}
        }

 	private decimal iSAB_MAX;
        public decimal ISAB_MAX
        { 
        	get
        	{
         		return this.iSAB_MAX;
        	}
        	set
        	{
        		this.iSAB_MAX= value;
        		this.isnull["ISAB_MAX"]=false;
        	}
        }

 	private string iDOM_HAY;
        public string IDOM_HAY
        { 
        	get
        	{
         		return this.iDOM_HAY;
        	}
        	set
        	{
        		this.iDOM_HAY= value;
        		this.isnull["IDOM_HAY"]=false;
        	}
        }

 	private decimal iDOM_MAX;
        public decimal IDOM_MAX
        { 
        	get
        	{
         		return this.iDOM_MAX;
        	}
        	set
        	{
        		this.iDOM_MAX= value;
        		this.isnull["IDOM_MAX"]=false;
        	}
        }
		
               public CMAXFACTBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("ISUCURSALCLAVE",true);
	

			isnull.Add("IANIO",true);
	

			isnull.Add("IMES",true);
	

			isnull.Add("ILUN_HAY",true);
	

			isnull.Add("ILUN_MAX",true);
	

			isnull.Add("IMAR_HAY",true);
	

			isnull.Add("IMAR_MAX",true);
	

			isnull.Add("IMIE_HAY",true);
	

			isnull.Add("IMIE_MAX",true);
	

			isnull.Add("IJUE_HAY",true);
	

			isnull.Add("IJUE_MAX",true);
	

			isnull.Add("IVIE_HAY",true);
	

			isnull.Add("IVIE_MAX",true);
	

			isnull.Add("ISAB_HAY",true);
	

			isnull.Add("ISAB_MAX",true);
	

			isnull.Add("IDOM_HAY",true);
	

			isnull.Add("IDOM_MAX",true);
	
		}

		

	}
}
