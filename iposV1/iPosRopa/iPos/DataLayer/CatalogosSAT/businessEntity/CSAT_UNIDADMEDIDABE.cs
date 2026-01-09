
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CSAT_UNIDADMEDIDABE
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

 	private string iSAT_NOMBRE;
        public string ISAT_NOMBRE
        { 
        	get
        	{
         		return this.iSAT_NOMBRE;
        	}
        	set
        	{
        		this.iSAT_NOMBRE= value;
        		this.isnull["ISAT_NOMBRE"]=false;
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

 	private string iSAT_SIMBOLO;
        public string ISAT_SIMBOLO
        { 
        	get
        	{
         		return this.iSAT_SIMBOLO;
        	}
        	set
        	{
        		this.iSAT_SIMBOLO= value;
        		this.isnull["ISAT_SIMBOLO"]=false;
        	}
        }
		
               public CSAT_UNIDADMEDIDABE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("ISAT_CLAVE",true);
	

			isnull.Add("ISAT_NOMBRE",true);
	

			isnull.Add("ISAT_DESCRIPCION",true);
	

			isnull.Add("ISAT_FECHAINICIO",true);
	

			isnull.Add("ISAT_FECHAFIN",true);
	

			isnull.Add("ISAT_SIMBOLO",true);
	
		}

		

	}
}
