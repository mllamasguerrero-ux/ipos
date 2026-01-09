
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CSAT_PRODUCTOSERVICIOBE
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

 	private string iSAT_CLAVEPRODSERV;
        public string ISAT_CLAVEPRODSERV
        { 
        	get
        	{
         		return this.iSAT_CLAVEPRODSERV;
        	}
        	set
        	{
        		this.iSAT_CLAVEPRODSERV= value;
        		this.isnull["ISAT_CLAVEPRODSERV"]=false;
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

 	private DateTime iSAT_FECHAINICIO;
        public DateTime ISAT_FECHAINICIO
        { 
        	get
        	{
         		return this.iSAT_FECHAINICIO;
        	}
        	set
        	{
        		this.iSAT_FECHAINICIO= value;
        		this.isnull["ISAT_FECHAINICIO"]=false;
        	}
        }

 	private DateTime iSAT_FECHAFIN;
        public DateTime ISAT_FECHAFIN
        { 
        	get
        	{
         		return this.iSAT_FECHAFIN;
        	}
        	set
        	{
        		this.iSAT_FECHAFIN= value;
        		this.isnull["ISAT_FECHAFIN"]=false;
        	}
        }

 	private string iSAT_IVATRASLADADO;
        public string ISAT_IVATRASLADADO
        { 
        	get
        	{
         		return this.iSAT_IVATRASLADADO;
        	}
        	set
        	{
        		this.iSAT_IVATRASLADADO= value;
        		this.isnull["ISAT_IVATRASLADADO"]=false;
        	}
        }

 	private string iSAT_IEPSTRASLADADO;
        public string ISAT_IEPSTRASLADADO
        { 
        	get
        	{
         		return this.iSAT_IEPSTRASLADADO;
        	}
        	set
        	{
        		this.iSAT_IEPSTRASLADADO= value;
        		this.isnull["ISAT_IEPSTRASLADADO"]=false;
        	}
        }

 	private string iSAT_COMPLEMENTO;
        public string ISAT_COMPLEMENTO
        { 
        	get
        	{
         		return this.iSAT_COMPLEMENTO;
        	}
        	set
        	{
        		this.iSAT_COMPLEMENTO= value;
        		this.isnull["ISAT_COMPLEMENTO"]=false;
        	}
        }
		
               public CSAT_PRODUCTOSERVICIOBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("ISAT_CLAVEPRODSERV",true);
	

			isnull.Add("ISAT_DESCRIPCION",true);
	

			isnull.Add("ISAT_FECHAINICIO",true);
	

			isnull.Add("ISAT_FECHAFIN",true);
	

			isnull.Add("ISAT_IVATRASLADADO",true);
	

			isnull.Add("ISAT_IEPSTRASLADADO",true);
	

			isnull.Add("ISAT_COMPLEMENTO",true);
	
		}

		

	}
}
