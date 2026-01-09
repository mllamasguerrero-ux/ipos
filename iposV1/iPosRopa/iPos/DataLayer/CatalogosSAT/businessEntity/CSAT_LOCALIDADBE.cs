
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CSAT_LOCALIDADBE
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

 	private string iCLAVE_LOCALIDAD;
        public string ICLAVE_LOCALIDAD
        { 
        	get
        	{
         		return this.iCLAVE_LOCALIDAD;
        	}
        	set
        	{
        		this.iCLAVE_LOCALIDAD= value;
        		this.isnull["ICLAVE_LOCALIDAD"]=false;
        	}
        }

 	private string iCLAVE_ESTADO;
        public string ICLAVE_ESTADO
        { 
        	get
        	{
         		return this.iCLAVE_ESTADO;
        	}
        	set
        	{
        		this.iCLAVE_ESTADO= value;
        		this.isnull["ICLAVE_ESTADO"]=false;
        	}
        }

 	private string iDESCRIPCION;
        public string IDESCRIPCION
        { 
        	get
        	{
         		return this.iDESCRIPCION;
        	}
        	set
        	{
        		this.iDESCRIPCION= value;
        		this.isnull["IDESCRIPCION"]=false;
        	}
        }
		
               public CSAT_LOCALIDADBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("ICLAVE_LOCALIDAD",true);
	

			isnull.Add("ICLAVE_ESTADO",true);
	

			isnull.Add("IDESCRIPCION",true);
	
		}

		

	}
}
