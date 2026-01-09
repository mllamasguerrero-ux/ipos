
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CSAT_TASACUOTABE
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

 	private string iSAT_RANGOFIJO;
        public string ISAT_RANGOFIJO
        { 
        	get
        	{
         		return this.iSAT_RANGOFIJO;
        	}
        	set
        	{
        		this.iSAT_RANGOFIJO= value;
        		this.isnull["ISAT_RANGOFIJO"]=false;
        	}
        }

 	private decimal iSAT_VALORMINIMO;
        public decimal ISAT_VALORMINIMO
        { 
        	get
        	{
         		return this.iSAT_VALORMINIMO;
        	}
        	set
        	{
        		this.iSAT_VALORMINIMO= value;
        		this.isnull["ISAT_VALORMINIMO"]=false;
        	}
        }

 	private decimal iSAT_VALORMAXIMO;
        public decimal ISAT_VALORMAXIMO
        { 
        	get
        	{
         		return this.iSAT_VALORMAXIMO;
        	}
        	set
        	{
        		this.iSAT_VALORMAXIMO= value;
        		this.isnull["ISAT_VALORMAXIMO"]=false;
        	}
        }

 	private string iSAT_IMPUESTO;
        public string ISAT_IMPUESTO
        { 
        	get
        	{
         		return this.iSAT_IMPUESTO;
        	}
        	set
        	{
        		this.iSAT_IMPUESTO= value;
        		this.isnull["ISAT_IMPUESTO"]=false;
        	}
        }

 	private string iSAT_FACTOR;
        public string ISAT_FACTOR
        { 
        	get
        	{
         		return this.iSAT_FACTOR;
        	}
        	set
        	{
        		this.iSAT_FACTOR= value;
        		this.isnull["ISAT_FACTOR"]=false;
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
		
               public CSAT_TASACUOTABE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("ISAT_RANGOFIJO",true);
	

			isnull.Add("ISAT_VALORMINIMO",true);
	

			isnull.Add("ISAT_VALORMAXIMO",true);
	

			isnull.Add("ISAT_IMPUESTO",true);
	

			isnull.Add("ISAT_FACTOR",true);
	

			isnull.Add("ISAT_TRASLADO",true);
	

			isnull.Add("ISAT_RETENCION",true);
	

			isnull.Add("ISAT_FECHAINICIO",true);
	

			isnull.Add("ISAT_FECHAFIN",true);
	
		}

		

	}
}
