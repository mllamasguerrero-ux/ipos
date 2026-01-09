
using System;
using System.Collections;
namespace iPosBusinessEntity
{
	public class CMONEDEROMOVTOBE
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

 	private long iMONEDERO;
        public long IMONEDERO
        { 
        	get
        	{
         		return this.iMONEDERO;
        	}
        	set
        	{
        		this.iMONEDERO= value;
        		this.isnull["IMONEDERO"]=false;
        	}
        }

 	private long iTIPOMONEDEROMOVTOID;
        public long ITIPOMONEDEROMOVTOID
        { 
        	get
        	{
         		return this.iTIPOMONEDEROMOVTOID;
        	}
        	set
        	{
        		this.iTIPOMONEDEROMOVTOID= value;
        		this.isnull["ITIPOMONEDEROMOVTOID"]=false;
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

 	private decimal iMONTO;
        public decimal IMONTO
        { 
        	get
        	{
         		return this.iMONTO;
        	}
        	set
        	{
        		this.iMONTO= value;
        		this.isnull["IMONTO"]=false;
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

 	private int iCADUCIDAD;
        public int ICADUCIDAD
        { 
        	get
        	{
         		return this.iCADUCIDAD;
        	}
        	set
        	{
        		this.iCADUCIDAD= value;
        		this.isnull["ICADUCIDAD"]=false;
        	}
        }

 	private decimal iMONTOMONEDERO;
        public decimal IMONTOMONEDERO
        { 
        	get
        	{
         		return this.iMONTOMONEDERO;
        	}
        	set
        	{
        		this.iMONTOMONEDERO= value;
        		this.isnull["IMONTOMONEDERO"]=false;
        	}
        }

 	private DateTime iVIGENCIAMONEDERO;
        public DateTime IVIGENCIAMONEDERO
        { 
        	get
        	{
         		return this.iVIGENCIAMONEDERO;
        	}
        	set
        	{
        		this.iVIGENCIAMONEDERO= value;
        		this.isnull["IVIGENCIAMONEDERO"]=false;
        	}
        }
		
               public CMONEDEROMOVTOBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("IMONEDERO",true);
	

			isnull.Add("ITIPOMONEDEROMOVTOID",true);
	

			isnull.Add("IDOCTOID",true);
	

			isnull.Add("IMONTO",true);
	

			isnull.Add("IFECHA",true);
	

			isnull.Add("ICADUCIDAD",true);
	

			isnull.Add("IMONTOMONEDERO",true);
	

			isnull.Add("IVIGENCIAMONEDERO",true);
	
		}

		

	}
}
