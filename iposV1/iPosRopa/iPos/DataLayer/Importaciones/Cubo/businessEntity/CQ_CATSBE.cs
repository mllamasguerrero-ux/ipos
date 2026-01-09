
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CQ_CATSBE
	{
	public Hashtable isnull;

 	private string iCLIENTE;
        public string ICLIENTE
        { 
        	get
        	{
         		return this.iCLIENTE;
        	}
        	set
        	{
        		this.iCLIENTE= value;
        		this.isnull["ICLIENTE"]=false;
        	}
        }

 	private string iNOMBRE;
        public string INOMBRE
        { 
        	get
        	{
         		return this.iNOMBRE;
        	}
        	set
        	{
        		this.iNOMBRE= value;
        		this.isnull["INOMBRE"]=false;
        	}
        }

 	private string iSUCURSAL;
        public string ISUCURSAL
        { 
        	get
        	{
         		return this.iSUCURSAL;
        	}
        	set
        	{
        		this.iSUCURSAL= value;
        		this.isnull["ISUCURSAL"]=false;
        	}
        }

 	private string iIMPORTAR;
        public string IIMPORTAR
        { 
        	get
        	{
         		return this.iIMPORTAR;
        	}
        	set
        	{
        		this.iIMPORTAR= value;
        		this.isnull["IIMPORTAR"]=false;
        	}
        }

 	private string iACTIVA;
        public string IACTIVA
        { 
        	get
        	{
         		return this.iACTIVA;
        	}
        	set
        	{
        		this.iACTIVA= value;
        		this.isnull["IACTIVA"]=false;
        	}
        }

 	private string iBWCOLOR;
        public string IBWCOLOR
        { 
        	get
        	{
         		return this.iBWCOLOR;
        	}
        	set
        	{
        		this.iBWCOLOR= value;
        		this.isnull["IBWCOLOR"]=false;
        	}
        }

 	private string iFINSEMANA;
        public string IFINSEMANA
        { 
        	get
        	{
         		return this.iFINSEMANA;
        	}
        	set
        	{
        		this.iFINSEMANA= value;
        		this.isnull["IFINSEMANA"]=false;
        	}
        }

 	private string iID;
        public string IID
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

 	private DateTime iID_FECHA;
        public DateTime IID_FECHA
        { 
        	get
        	{
         		return this.iID_FECHA;
        	}
        	set
        	{
        		this.iID_FECHA= value;
        		this.isnull["IID_FECHA"]=false;
        	}
        }

 	private string iID_HORA;
        public string IID_HORA
        { 
        	get
        	{
         		return this.iID_HORA;
        	}
        	set
        	{
        		this.iID_HORA= value;
        		this.isnull["IID_HORA"]=false;
        	}
        }

 	private string iSUCU;
        public string ISUCU
        { 
        	get
        	{
         		return this.iSUCU;
        	}
        	set
        	{
        		this.iSUCU= value;
        		this.isnull["ISUCU"]=false;
        	}
        }

 	private string iESTRATEGIC;
        public string IESTRATEGIC
        { 
        	get
        	{
         		return this.iESTRATEGIC;
        	}
        	set
        	{
        		this.iESTRATEGIC= value;
        		this.isnull["IESTRATEGIC"]=false;
        	}
        }

 	private string iBANCOS;
        public string IBANCOS
        { 
        	get
        	{
         		return this.iBANCOS;
        	}
        	set
        	{
        		this.iBANCOS= value;
        		this.isnull["IBANCOS"]=false;
        	}
        }

 	private string iBANCOS2;
        public string IBANCOS2
        { 
        	get
        	{
         		return this.iBANCOS2;
        	}
        	set
        	{
        		this.iBANCOS2= value;
        		this.isnull["IBANCOS2"]=false;
        	}
        }

 	private string iNOMBRE2;
        public string INOMBRE2
        { 
        	get
        	{
         		return this.iNOMBRE2;
        	}
        	set
        	{
        		this.iNOMBRE2= value;
        		this.isnull["INOMBRE2"]=false;
        	}
        }

 	private string iGRUPO;
        public string IGRUPO
        { 
        	get
        	{
         		return this.iGRUPO;
        	}
        	set
        	{
        		this.iGRUPO= value;
        		this.isnull["IGRUPO"]=false;
        	}
        }

 	private string iCOMER;
        public string ICOMER
        { 
        	get
        	{
         		return this.iCOMER;
        	}
        	set
        	{
        		this.iCOMER= value;
        		this.isnull["ICOMER"]=false;
        	}
        }

 	private string iSIS_ANTER;
        public string ISIS_ANTER
        { 
        	get
        	{
         		return this.iSIS_ANTER;
        	}
        	set
        	{
        		this.iSIS_ANTER= value;
        		this.isnull["ISIS_ANTER"]=false;
        	}
        }

 	private string iDESC;
        public string IDESC
        { 
        	get
        	{
         		return this.iDESC;
        	}
        	set
        	{
        		this.iDESC= value;
        		this.isnull["IDESC"]=false;
        	}
        }
		
               public CQ_CATSBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("ICLIENTE",true);
	

			isnull.Add("INOMBRE",true);
	

			isnull.Add("ISUCURSAL",true);
	

			isnull.Add("IIMPORTAR",true);
	

			isnull.Add("IACTIVA",true);
	

			isnull.Add("IBWCOLOR",true);
	

			isnull.Add("IFINSEMANA",true);
	

			isnull.Add("IID",true);
	

			isnull.Add("IID_FECHA",true);
	

			isnull.Add("IID_HORA",true);
	

			isnull.Add("ISUCU",true);
	

			isnull.Add("IESTRATEGIC",true);
	

			isnull.Add("IBANCOS",true);
	

			isnull.Add("IBANCOS2",true);
	

			isnull.Add("INOMBRE2",true);
	

			isnull.Add("IGRUPO",true);
	

			isnull.Add("ICOMER",true);
	

			isnull.Add("ISIS_ANTER",true);
	

			isnull.Add("IDESC",true);
	
		}

		

	}
}
