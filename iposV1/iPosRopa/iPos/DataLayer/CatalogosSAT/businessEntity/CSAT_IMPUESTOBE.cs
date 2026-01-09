
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CSAT_IMPUESTOBE
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

 	private string iSAT_CLAVE;
        public string ISAT_CLAVE
        { 
        	get
        	{
         		return this.iSAT_CLAVE;
        	}
        	set
        	{
        		this.iSAT_CLAVE= value;
        		this.isnull["ISAT_CLAVE"]=false;
        	}
        }

 	private string iSAT_DESCRIPCION;
        public string ISAT_DESCRIPCION
        { 
        	get
        	{
         		return this.iSAT_DESCRIPCION;
        	}
        	set
        	{
        		this.iSAT_DESCRIPCION= value;
        		this.isnull["ISAT_DESCRIPCION"]=false;
        	}
        }

 	private string iSAT_RETENCION;
        public string ISAT_RETENCION
        { 
        	get
        	{
         		return this.iSAT_RETENCION;
        	}
        	set
        	{
        		this.iSAT_RETENCION= value;
        		this.isnull["ISAT_RETENCION"]=false;
        	}
        }

 	private string iSAT_TRASLADO;
        public string ISAT_TRASLADO
        { 
        	get
        	{
         		return this.iSAT_TRASLADO;
        	}
        	set
        	{
        		this.iSAT_TRASLADO= value;
        		this.isnull["ISAT_TRASLADO"]=false;
        	}
        }

 	private string iSAT_LOCALFEDERAL;
        public string ISAT_LOCALFEDERAL
        { 
        	get
        	{
         		return this.iSAT_LOCALFEDERAL;
        	}
        	set
        	{
        		this.iSAT_LOCALFEDERAL= value;
        		this.isnull["ISAT_LOCALFEDERAL"]=false;
        	}
        }

 	private string iSAT_ENTIDADAPLICA;
        public string ISAT_ENTIDADAPLICA
        { 
        	get
        	{
         		return this.iSAT_ENTIDADAPLICA;
        	}
        	set
        	{
        		this.iSAT_ENTIDADAPLICA= value;
        		this.isnull["ISAT_ENTIDADAPLICA"]=false;
        	}
        }
		
               public CSAT_IMPUESTOBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("ISAT_CLAVE",true);
	

			isnull.Add("ISAT_DESCRIPCION",true);
	

			isnull.Add("ISAT_RETENCION",true);
	

			isnull.Add("ISAT_TRASLADO",true);
	

			isnull.Add("ISAT_LOCALFEDERAL",true);
	

			isnull.Add("ISAT_ENTIDADAPLICA",true);
	
		}

		

	}
}
