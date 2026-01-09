
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CTEMP_FILTRO_REPOBE
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

 	private string iNOMBRE_REPORTE;
        public string INOMBRE_REPORTE
        { 
        	get
        	{
         		return this.iNOMBRE_REPORTE;
        	}
        	set
        	{
        		this.iNOMBRE_REPORTE= value;
        		this.isnull["INOMBRE_REPORTE"]=false;
        	}
        }

 	private string iGRUPO_REPORTE;
        public string IGRUPO_REPORTE
        { 
        	get
        	{
         		return this.iGRUPO_REPORTE;
        	}
        	set
        	{
        		this.iGRUPO_REPORTE= value;
        		this.isnull["IGRUPO_REPORTE"]=false;
        	}
        }

 	private string iFILTRO_TEXTO;
        public string IFILTRO_TEXTO
        { 
        	get
        	{
         		return this.iFILTRO_TEXTO;
        	}
        	set
        	{
        		this.iFILTRO_TEXTO= value;
        		this.isnull["IFILTRO_TEXTO"]=false;
        	}
        }

 	private long iFILTRO_ID;
        public long IFILTRO_ID
        { 
        	get
        	{
         		return this.iFILTRO_ID;
        	}
        	set
        	{
        		this.iFILTRO_ID= value;
        		this.isnull["IFILTRO_ID"]=false;
        	}
        }

 	private int iFILTRO_INTEGER;
        public int IFILTRO_INTEGER
        { 
        	get
        	{
         		return this.iFILTRO_INTEGER;
        	}
        	set
        	{
        		this.iFILTRO_INTEGER= value;
        		this.isnull["IFILTRO_INTEGER"]=false;
        	}
        }
		
               public CTEMP_FILTRO_REPOBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("INOMBRE_REPORTE",true);
	

			isnull.Add("IGRUPO_REPORTE",true);
	

			isnull.Add("IFILTRO_TEXTO",true);
	

			isnull.Add("IFILTRO_ID",true);
	

			isnull.Add("IFILTRO_INTEGER",true);
	
		}

		

	}
}
