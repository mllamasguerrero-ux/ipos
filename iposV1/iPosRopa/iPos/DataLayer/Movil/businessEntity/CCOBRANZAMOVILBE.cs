using System;
using System.Collections;
namespace iPosBusinessEntity
{
	public class CCOBRANZAMOVILBE
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

 	private string iCOBRANZA;
        public string ICOBRANZA
        { 
        	get
        	{
         		return this.iCOBRANZA;
        	}
        	set
        	{
        		this.iCOBRANZA= value;
        		this.isnull["ICOBRANZA"]=false;
        	}
        }

 	private string iVENDEDOR;
        public string IVENDEDOR
        { 
        	get
        	{
         		return this.iVENDEDOR;
        	}
        	set
        	{
        		this.iVENDEDOR= value;
        		this.isnull["IVENDEDOR"]=false;
        	}
        }

 	private string iVENTA;
        public string IVENTA
        { 
        	get
        	{
         		return this.iVENTA;
        	}
        	set
        	{
        		this.iVENTA= value;
        		this.isnull["IVENTA"]=false;
        	}
        }

 	private string iEMPRESA;
        public string IEMPRESA
        { 
        	get
        	{
         		return this.iEMPRESA;
        	}
        	set
        	{
        		this.iEMPRESA= value;
        		this.isnull["IEMPRESA"]=false;
        	}
        }

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

 	private string iFACTURA;
        public string IFACTURA
        { 
        	get
        	{
         		return this.iFACTURA;
        	}
        	set
        	{
        		this.iFACTURA= value;
        		this.isnull["IFACTURA"]=false;
        	}
        }

 	private string iESTATUS;
        public string IESTATUS
        { 
        	get
        	{
         		return this.iESTATUS;
        	}
        	set
        	{
        		this.iESTATUS= value;
        		this.isnull["IESTATUS"]=false;
        	}
        }

 	private string iOBS;
        public string IOBS
        { 
        	get
        	{
         		return this.iOBS;
        	}
        	set
        	{
        		this.iOBS= value;
        		this.isnull["IOBS"]=false;
        	}
        }

 	private DateTime iF_FACTURA;
        public DateTime IF_FACTURA
        { 
        	get
        	{
         		return this.iF_FACTURA;
        	}
        	set
        	{
        		this.iF_FACTURA= value;
        		this.isnull["IF_FACTURA"]=false;
        	}
        }

 	private DateTime iF_PAGO;
        public DateTime IF_PAGO
        { 
        	get
        	{
         		return this.iF_PAGO;
        	}
        	set
        	{
        		this.iF_PAGO= value;
        		this.isnull["IF_PAGO"]=false;
        	}
        }

 	private int iDIAS;
        public int IDIAS
        { 
        	get
        	{
         		return this.iDIAS;
        	}
        	set
        	{
        		this.iDIAS= value;
        		this.isnull["IDIAS"]=false;
        	}
        }

 	private decimal iTOTAL;
        public decimal ITOTAL
        { 
        	get
        	{
         		return this.iTOTAL;
        	}
        	set
        	{
        		this.iTOTAL= value;
        		this.isnull["ITOTAL"]=false;
        	}
        }

 	private decimal iA_CUENTA;
        public decimal IA_CUENTA
        { 
        	get
        	{
         		return this.iA_CUENTA;
        	}
        	set
        	{
        		this.iA_CUENTA= value;
        		this.isnull["IA_CUENTA"]=false;
        	}
        }

 	private decimal iSALDO;
        public decimal ISALDO
        { 
        	get
        	{
         		return this.iSALDO;
        	}
        	set
        	{
        		this.iSALDO= value;
        		this.isnull["ISALDO"]=false;
        	}
        }

 	private decimal iINT_COB;
        public decimal IINT_COB
        { 
        	get
        	{
         		return this.iINT_COB;
        	}
        	set
        	{
        		this.iINT_COB= value;
        		this.isnull["IINT_COB"]=false;
        	}
        }

 	private decimal iINTERESES;
        public decimal IINTERESES
        { 
        	get
        	{
         		return this.iINTERESES;
        	}
        	set
        	{
        		this.iINTERESES= value;
        		this.isnull["IINTERESES"]=false;
        	}
        }

 	private decimal iIMPOR_NETO;
        public decimal IIMPOR_NETO
        { 
        	get
        	{
         		return this.iIMPOR_NETO;
        	}
        	set
        	{
        		this.iIMPOR_NETO= value;
        		this.isnull["IIMPOR_NETO"]=false;
        	}
        }

 	private decimal iPAGO;
        public decimal IPAGO
        { 
        	get
        	{
         		return this.iPAGO;
        	}
        	set
        	{
        		this.iPAGO= value;
        		this.isnull["IPAGO"]=false;
        	}
        }

 	private decimal iEFECTIVO;
        public decimal IEFECTIVO
        { 
        	get
        	{
         		return this.iEFECTIVO;
        	}
        	set
        	{
        		this.iEFECTIVO= value;
        		this.isnull["IEFECTIVO"]=false;
        	}
        }

 	private decimal iDIFERENCIA;
        public decimal IDIFERENCIA
        { 
        	get
        	{
         		return this.iDIFERENCIA;
        	}
        	set
        	{
        		this.iDIFERENCIA= value;
        		this.isnull["IDIFERENCIA"]=false;
        	}
        }

 	private decimal iIMP_CHEQUE;
        public decimal IIMP_CHEQUE
        { 
        	get
        	{
         		return this.iIMP_CHEQUE;
        	}
        	set
        	{
        		this.iIMP_CHEQUE= value;
        		this.isnull["IIMP_CHEQUE"]=false;
        	}
        }

 	private string iBANCO;
        public string IBANCO
        { 
        	get
        	{
         		return this.iBANCO;
        	}
        	set
        	{
        		this.iBANCO= value;
        		this.isnull["IBANCO"]=false;
        	}
        }

 	private int iNUM_CHEQ;
        public int INUM_CHEQ
        { 
        	get
        	{
         		return this.iNUM_CHEQ;
        	}
        	set
        	{
        		this.iNUM_CHEQ= value;
        		this.isnull["INUM_CHEQ"]=false;
        	}
        }

 	private decimal iINTERES;
        public decimal IINTERES
        { 
        	get
        	{
         		return this.iINTERES;
        	}
        	set
        	{
        		this.iINTERES= value;
        		this.isnull["IINTERES"]=false;
        	}
        }

 	private decimal iCAPITAL;
        public decimal ICAPITAL
        { 
        	get
        	{
         		return this.iCAPITAL;
        	}
        	set
        	{
        		this.iCAPITAL= value;
        		this.isnull["ICAPITAL"]=false;
        	}
        }

 	private string iOLLA;
        public string IOLLA
        { 
        	get
        	{
         		return this.iOLLA;
        	}
        	set
        	{
        		this.iOLLA= value;
        		this.isnull["IOLLA"]=false;
        	}
        }

 	private string iBLOQUEADO;
        public string IBLOQUEADO
        { 
        	get
        	{
         		return this.iBLOQUEADO;
        	}
        	set
        	{
        		this.iBLOQUEADO= value;
        		this.isnull["IBLOQUEADO"]=false;
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

 	private string iLLEVAR;
        public string ILLEVAR
        { 
        	get
        	{
         		return this.iLLEVAR;
        	}
        	set
        	{
        		this.iLLEVAR= value;
        		this.isnull["ILLEVAR"]=false;
        	}
        }

 	private decimal iSALDOMOVIL;
        public decimal ISALDOMOVIL
        { 
        	get
        	{
         		return this.iSALDOMOVIL;
        	}
        	set
        	{
        		this.iSALDOMOVIL= value;
        		this.isnull["ISALDOMOVIL"]=false;
        	}
        }

 	private decimal iABONOSMOVIL;
        public decimal IABONOSMOVIL
        { 
        	get
        	{
         		return this.iABONOSMOVIL;
        	}
        	set
        	{
        		this.iABONOSMOVIL= value;
        		this.isnull["IABONOSMOVIL"]=false;
        	}
        }

 	private long iPERSONAID;
        public long IPERSONAID
        { 
        	get
        	{
         		return this.iPERSONAID;
        	}
        	set
        	{
        		this.iPERSONAID= value;
        		this.isnull["IPERSONAID"]=false;
        	}
        }
		
               public CCOBRANZAMOVILBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("ICOBRANZA",true);
	

			isnull.Add("IVENDEDOR",true);
	

			isnull.Add("IVENTA",true);
	

			isnull.Add("IEMPRESA",true);
	

			isnull.Add("ICLIENTE",true);
	

			isnull.Add("INOMBRE",true);
	

			isnull.Add("IFACTURA",true);
	

			isnull.Add("IESTATUS",true);
	

			isnull.Add("IOBS",true);
	

			isnull.Add("IF_FACTURA",true);
	

			isnull.Add("IF_PAGO",true);
	

			isnull.Add("IDIAS",true);
	

			isnull.Add("ITOTAL",true);
	

			isnull.Add("IA_CUENTA",true);
	

			isnull.Add("ISALDO",true);
	

			isnull.Add("IINT_COB",true);
	

			isnull.Add("IINTERESES",true);
	

			isnull.Add("IIMPOR_NETO",true);
	

			isnull.Add("IPAGO",true);
	

			isnull.Add("IEFECTIVO",true);
	

			isnull.Add("IDIFERENCIA",true);
	

			isnull.Add("IIMP_CHEQUE",true);
	

			isnull.Add("IBANCO",true);
	

			isnull.Add("INUM_CHEQ",true);
	

			isnull.Add("IINTERES",true);
	

			isnull.Add("ICAPITAL",true);
	

			isnull.Add("IOLLA",true);
	

			isnull.Add("IBLOQUEADO",true);
	

			isnull.Add("IFECHA",true);
	

			isnull.Add("ILLEVAR",true);
	

			isnull.Add("ISALDOMOVIL",true);
	

			isnull.Add("IABONOSMOVIL",true);
	

			isnull.Add("IPERSONAID",true);
	
		}

		

	}
}
