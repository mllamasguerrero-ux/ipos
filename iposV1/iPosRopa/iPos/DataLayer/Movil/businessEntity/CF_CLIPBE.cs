
using System;
using System.Collections;

namespace iPosBusinessEntity
{
	public class CF_CLIPBE
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

 	private decimal iSALDO_VENC;
        public decimal ISALDO_VENC
        { 
        	get
        	{
         		return this.iSALDO_VENC;
        	}
        	set
        	{
        		this.iSALDO_VENC= value;
        		this.isnull["ISALDO_VENC"]=false;
        	}
        }

 	private decimal iLIMITE;
        public decimal ILIMITE
        { 
        	get
        	{
         		return this.iLIMITE;
        	}
        	set
        	{
        		this.iLIMITE= value;
        		this.isnull["ILIMITE"]=false;
        	}
        }

 	private decimal iNUMERO;
        public decimal INUMERO
        { 
        	get
        	{
         		return this.iNUMERO;
        	}
        	set
        	{
        		this.iNUMERO= value;
        		this.isnull["INUMERO"]=false;
        	}
        }

 	private decimal iSALDO_US;
        public decimal ISALDO_US
        { 
        	get
        	{
         		return this.iSALDO_US;
        	}
        	set
        	{
        		this.iSALDO_US= value;
        		this.isnull["ISALDO_US"]=false;
        	}
        }

 	private DateTime iALTA;
        public DateTime IALTA
        { 
        	get
        	{
         		return this.iALTA;
        	}
        	set
        	{
        		this.iALTA= value;
        		this.isnull["IALTA"]=false;
        	}
        }

 	private DateTime iULT_COMPRA;
        public DateTime IULT_COMPRA
        { 
        	get
        	{
         		return this.iULT_COMPRA;
        	}
        	set
        	{
        		this.iULT_COMPRA= value;
        		this.isnull["IULT_COMPRA"]=false;
        	}
        }

 	private decimal iUC_CANT;
        public decimal IUC_CANT
        { 
        	get
        	{
         		return this.iUC_CANT;
        	}
        	set
        	{
        		this.iUC_CANT= value;
        		this.isnull["IUC_CANT"]=false;
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

 	private decimal iFACT_PERIO;
        public decimal IFACT_PERIO
        { 
        	get
        	{
         		return this.iFACT_PERIO;
        	}
        	set
        	{
        		this.iFACT_PERIO= value;
        		this.isnull["IFACT_PERIO"]=false;
        	}
        }

 	private decimal iCOMPRAS_P;
        public decimal ICOMPRAS_P
        { 
        	get
        	{
         		return this.iCOMPRAS_P;
        	}
        	set
        	{
        		this.iCOMPRAS_P= value;
        		this.isnull["ICOMPRAS_P"]=false;
        	}
        }

 	private decimal iFACT_ACUM;
        public decimal IFACT_ACUM
        { 
        	get
        	{
         		return this.iFACT_ACUM;
        	}
        	set
        	{
        		this.iFACT_ACUM= value;
        		this.isnull["IFACT_ACUM"]=false;
        	}
        }

 	private decimal iCOMPRAS_A;
        public decimal ICOMPRAS_A
        { 
        	get
        	{
         		return this.iCOMPRAS_A;
        	}
        	set
        	{
        		this.iCOMPRAS_A= value;
        		this.isnull["ICOMPRAS_A"]=false;
        	}
        }

 	private decimal iCHQ_DEVUEL;
        public decimal ICHQ_DEVUEL
        { 
        	get
        	{
         		return this.iCHQ_DEVUEL;
        	}
        	set
        	{
        		this.iCHQ_DEVUEL= value;
        		this.isnull["ICHQ_DEVUEL"]=false;
        	}
        }

 	private decimal iF_VENCIDAS;
        public decimal IF_VENCIDAS
        { 
        	get
        	{
         		return this.iF_VENCIDAS;
        	}
        	set
        	{
        		this.iF_VENCIDAS= value;
        		this.isnull["IF_VENCIDAS"]=false;
        	}
        }

 	private string iCALLE;
        public string ICALLE
        { 
        	get
        	{
         		return this.iCALLE;
        	}
        	set
        	{
        		this.iCALLE= value;
        		this.isnull["ICALLE"]=false;
        	}
        }

 	private string iCOLONIA;
        public string ICOLONIA
        { 
        	get
        	{
         		return this.iCOLONIA;
        	}
        	set
        	{
        		this.iCOLONIA= value;
        		this.isnull["ICOLONIA"]=false;
        	}
        }

 	private string iESTADO;
        public string IESTADO
        { 
        	get
        	{
         		return this.iESTADO;
        	}
        	set
        	{
        		this.iESTADO= value;
        		this.isnull["IESTADO"]=false;
        	}
        }

 	private string iCIUDAD;
        public string ICIUDAD
        { 
        	get
        	{
         		return this.iCIUDAD;
        	}
        	set
        	{
        		this.iCIUDAD= value;
        		this.isnull["ICIUDAD"]=false;
        	}
        }

 	private string iCP;
        public string ICP
        { 
        	get
        	{
         		return this.iCP;
        	}
        	set
        	{
        		this.iCP= value;
        		this.isnull["ICP"]=false;
        	}
        }

 	private string iRFC;
        public string IRFC
        { 
        	get
        	{
         		return this.iRFC;
        	}
        	set
        	{
        		this.iRFC= value;
        		this.isnull["IRFC"]=false;
        	}
        }

 	private string iTELEFONO;
        public string ITELEFONO
        { 
        	get
        	{
         		return this.iTELEFONO;
        	}
        	set
        	{
        		this.iTELEFONO= value;
        		this.isnull["ITELEFONO"]=false;
        	}
        }

 	private string iTELEFONO2;
        public string ITELEFONO2
        { 
        	get
        	{
         		return this.iTELEFONO2;
        	}
        	set
        	{
        		this.iTELEFONO2= value;
        		this.isnull["ITELEFONO2"]=false;
        	}
        }

 	private string iCONTACTO;
        public string ICONTACTO
        { 
        	get
        	{
         		return this.iCONTACTO;
        	}
        	set
        	{
        		this.iCONTACTO= value;
        		this.isnull["ICONTACTO"]=false;
        	}
        }

 	private string iCONTACTO2;
        public string ICONTACTO2
        { 
        	get
        	{
         		return this.iCONTACTO2;
        	}
        	set
        	{
        		this.iCONTACTO2= value;
        		this.isnull["ICONTACTO2"]=false;
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

 	private string iTIPO;
        public string ITIPO
        { 
        	get
        	{
         		return this.iTIPO;
        	}
        	set
        	{
        		this.iTIPO= value;
        		this.isnull["ITIPO"]=false;
        	}
        }

 	private string iCOMODIN;
        public string ICOMODIN
        { 
        	get
        	{
         		return this.iCOMODIN;
        	}
        	set
        	{
        		this.iCOMODIN= value;
        		this.isnull["ICOMODIN"]=false;
        	}
        }

 	private decimal iDIAS;
        public decimal IDIAS
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

 	private decimal iDIASA;
        public decimal IDIASA
        { 
        	get
        	{
         		return this.iDIASA;
        	}
        	set
        	{
        		this.iDIASA= value;
        		this.isnull["IDIASA"]=false;
        	}
        }

 	private decimal iDIASB;
        public decimal IDIASB
        { 
        	get
        	{
         		return this.iDIASB;
        	}
        	set
        	{
        		this.iDIASB= value;
        		this.isnull["IDIASB"]=false;
        	}
        }

 	private string iREVISION;
        public string IREVISION
        { 
        	get
        	{
         		return this.iREVISION;
        	}
        	set
        	{
        		this.iREVISION= value;
        		this.isnull["IREVISION"]=false;
        	}
        }

 	private string iPAGOS;
        public string IPAGOS
        { 
        	get
        	{
         		return this.iPAGOS;
        	}
        	set
        	{
        		this.iPAGOS= value;
        		this.isnull["IPAGOS"]=false;
        	}
        }

 	private string iCLASIFICA;
        public string ICLASIFICA
        { 
        	get
        	{
         		return this.iCLASIFICA;
        	}
        	set
        	{
        		this.iCLASIFICA= value;
        		this.isnull["ICLASIFICA"]=false;
        	}
        }

 	private decimal iDESCUENTO;
        public decimal IDESCUENTO
        { 
        	get
        	{
         		return this.iDESCUENTO;
        	}
        	set
        	{
        		this.iDESCUENTO= value;
        		this.isnull["IDESCUENTO"]=false;
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

 	private string iBLOQUEONOT;
        public string IBLOQUEONOT
        { 
        	get
        	{
         		return this.iBLOQUEONOT;
        	}
        	set
        	{
        		this.iBLOQUEONOT= value;
        		this.isnull["IBLOQUEONOT"]=false;
        	}
        }

 	private string iEFECTIVO;
        public string IEFECTIVO
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

 	private string iCORREO;
        public string ICORREO
        { 
        	get
        	{
         		return this.iCORREO;
        	}
        	set
        	{
        		this.iCORREO= value;
        		this.isnull["ICORREO"]=false;
        	}
        }

 	private DateTime iULT_LLAMAD;
        public DateTime IULT_LLAMAD
        { 
        	get
        	{
         		return this.iULT_LLAMAD;
        	}
        	set
        	{
        		this.iULT_LLAMAD= value;
        		this.isnull["IULT_LLAMAD"]=false;
        	}
        }

 	private DateTime iPROX_LLAMA;
        public DateTime IPROX_LLAMA
        { 
        	get
        	{
         		return this.iPROX_LLAMA;
        	}
        	set
        	{
        		this.iPROX_LLAMA= value;
        		this.isnull["IPROX_LLAMA"]=false;
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

 	private string iCALLE1;
        public string ICALLE1
        { 
        	get
        	{
         		return this.iCALLE1;
        	}
        	set
        	{
        		this.iCALLE1= value;
        		this.isnull["ICALLE1"]=false;
        	}
        }

 	private string iCRUZACON;
        public string ICRUZACON
        { 
        	get
        	{
         		return this.iCRUZACON;
        	}
        	set
        	{
        		this.iCRUZACON= value;
        		this.isnull["ICRUZACON"]=false;
        	}
        }

 	private string iDESGIEPS;
        public string IDESGIEPS
        { 
        	get
        	{
         		return this.iDESGIEPS;
        	}
        	set
        	{
        		this.iDESGIEPS= value;
        		this.isnull["IDESGIEPS"]=false;
        	}
        }

 	private decimal iENDOLARES;
        public decimal IENDOLARES
        { 
        	get
        	{
         		return this.iENDOLARES;
        	}
        	set
        	{
        		this.iENDOLARES= value;
        		this.isnull["IENDOLARES"]=false;
        	}
        }

 	private string iPLANO;
        public string IPLANO
        { 
        	get
        	{
         		return this.iPLANO;
        	}
        	set
        	{
        		this.iPLANO= value;
        		this.isnull["IPLANO"]=false;
        	}
        }

 	private string iEMAIL;
        public string IEMAIL
        { 
        	get
        	{
         		return this.iEMAIL;
        	}
        	set
        	{
        		this.iEMAIL= value;
        		this.isnull["IEMAIL"]=false;
        	}
        }

 	private string iHOMEPAGE;
        public string IHOMEPAGE
        { 
        	get
        	{
         		return this.iHOMEPAGE;
        	}
        	set
        	{
        		this.iHOMEPAGE= value;
        		this.isnull["IHOMEPAGE"]=false;
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

 	private string iMULVEN;
        public string IMULVEN
        { 
        	get
        	{
         		return this.iMULVEN;
        	}
        	set
        	{
        		this.iMULVEN= value;
        		this.isnull["IMULVEN"]=false;
        	}
        }

 	private string iCTA_IEPS;
        public string ICTA_IEPS
        { 
        	get
        	{
         		return this.iCTA_IEPS;
        	}
        	set
        	{
        		this.iCTA_IEPS= value;
        		this.isnull["ICTA_IEPS"]=false;
        	}
        }

 	private string iP_MOVIL;
        public string IP_MOVIL
        { 
        	get
        	{
         		return this.iP_MOVIL;
        	}
        	set
        	{
        		this.iP_MOVIL= value;
        		this.isnull["IP_MOVIL"]=false;
        	}
        }

 	private string iACUMULA;
        public string IACUMULA
        { 
        	get
        	{
         		return this.iACUMULA;
        	}
        	set
        	{
        		this.iACUMULA= value;
        		this.isnull["IACUMULA"]=false;
        	}
        }

 	private decimal iSALDO_GLOB;
        public decimal ISALDO_GLOB
        { 
        	get
        	{
         		return this.iSALDO_GLOB;
        	}
        	set
        	{
        		this.iSALDO_GLOB= value;
        		this.isnull["ISALDO_GLOB"]=false;
        	}
        }

 	private string iUSERNAME;
        public string IUSERNAME
        { 
        	get
        	{
         		return this.iUSERNAME;
        	}
        	set
        	{
        		this.iUSERNAME= value;
        		this.isnull["IUSERNAME"]=false;
        	}
        }

 	private string iID_ALTA;
        public string IID_ALTA
        { 
        	get
        	{
         		return this.iID_ALTA;
        	}
        	set
        	{
        		this.iID_ALTA= value;
        		this.isnull["IID_ALTA"]=false;
        	}
        }

 	private string iCLAVE_EDO;
        public string ICLAVE_EDO
        { 
        	get
        	{
         		return this.iCLAVE_EDO;
        	}
        	set
        	{
        		this.iCLAVE_EDO= value;
        		this.isnull["ICLAVE_EDO"]=false;
        	}
        }

 	private string iCOB_INTERE;
        public string ICOB_INTERE
        { 
        	get
        	{
         		return this.iCOB_INTERE;
        	}
        	set
        	{
        		this.iCOB_INTERE= value;
        		this.isnull["ICOB_INTERE"]=false;
        	}
        }

 	private decimal iPLAZA;
        public decimal IPLAZA
        { 
        	get
        	{
         		return this.iPLAZA;
        	}
        	set
        	{
        		this.iPLAZA= value;
        		this.isnull["IPLAZA"]=false;
        	}
        }

 	private string iCOM_ESP;
        public string ICOM_ESP
        { 
        	get
        	{
         		return this.iCOM_ESP;
        	}
        	set
        	{
        		this.iCOM_ESP= value;
        		this.isnull["ICOM_ESP"]=false;
        	}
        }

 	private decimal iPOR_COME;
        public decimal IPOR_COME
        { 
        	get
        	{
         		return this.iPOR_COME;
        	}
        	set
        	{
        		this.iPOR_COME= value;
        		this.isnull["IPOR_COME"]=false;
        	}
        }

 	private string iL_BLOQUEO;
        public string IL_BLOQUEO
        { 
        	get
        	{
         		return this.iL_BLOQUEO;
        	}
        	set
        	{
        		this.iL_BLOQUEO= value;
        		this.isnull["IL_BLOQUEO"]=false;
        	}
        }

 	private string iVISITA;
        public string IVISITA
        { 
        	get
        	{
         		return this.iVISITA;
        	}
        	set
        	{
        		this.iVISITA= value;
        		this.isnull["IVISITA"]=false;
        	}
        }

 	private string iRUTA;
        public string IRUTA
        { 
        	get
        	{
         		return this.iRUTA;
        	}
        	set
        	{
        		this.iRUTA= value;
        		this.isnull["IRUTA"]=false;
        	}
        }

 	private string iL_DESC;
        public string IL_DESC
        { 
        	get
        	{
         		return this.iL_DESC;
        	}
        	set
        	{
        		this.iL_DESC= value;
        		this.isnull["IL_DESC"]=false;
        	}
        }

 	private string iPOCKET;
        public string IPOCKET
        { 
        	get
        	{
         		return this.iPOCKET;
        	}
        	set
        	{
        		this.iPOCKET= value;
        		this.isnull["IPOCKET"]=false;
        	}
        }

 	private string iCLIEPOCK;
        public string ICLIEPOCK
        { 
        	get
        	{
         		return this.iCLIEPOCK;
        	}
        	set
        	{
        		this.iCLIEPOCK= value;
        		this.isnull["ICLIEPOCK"]=false;
        	}
        }

 	private string iDESCI;
        public string IDESCI
        { 
        	get
        	{
         		return this.iDESCI;
        	}
        	set
        	{
        		this.iDESCI= value;
        		this.isnull["IDESCI"]=false;
        	}
        }

 	private string iBLOQ2;
        public string IBLOQ2
        { 
        	get
        	{
         		return this.iBLOQ2;
        	}
        	set
        	{
        		this.iBLOQ2= value;
        		this.isnull["IBLOQ2"]=false;
        	}
        }

 	private string iDIASP;
        public string IDIASP
        { 
        	get
        	{
         		return this.iDIASP;
        	}
        	set
        	{
        		this.iDIASP= value;
        		this.isnull["IDIASP"]=false;
        	}
        }

 	private decimal iDIASEXTR;
        public decimal IDIASEXTR
        { 
        	get
        	{
         		return this.iDIASEXTR;
        	}
        	set
        	{
        		this.iDIASEXTR= value;
        		this.isnull["IDIASEXTR"]=false;
        	}
        }

 	private string iCOBVENCIDA;
        public string ICOBVENCIDA
        { 
        	get
        	{
         		return this.iCOBVENCIDA;
        	}
        	set
        	{
        		this.iCOBVENCIDA= value;
        		this.isnull["ICOBVENCIDA"]=false;
        	}
        }

 	private string iVENDEDOR2;
        public string IVENDEDOR2
        { 
        	get
        	{
         		return this.iVENDEDOR2;
        	}
        	set
        	{
        		this.iVENDEDOR2= value;
        		this.isnull["IVENDEDOR2"]=false;
        	}
        }

 	private string iCURP;
        public string ICURP
        { 
        	get
        	{
         		return this.iCURP;
        	}
        	set
        	{
        		this.iCURP= value;
        		this.isnull["ICURP"]=false;
        	}
        }

 	private string iAUTORIZA;
        public string IAUTORIZA
        { 
        	get
        	{
         		return this.iAUTORIZA;
        	}
        	set
        	{
        		this.iAUTORIZA= value;
        		this.isnull["IAUTORIZA"]=false;
        	}
        }

 	private string iTIPO_INTER;
        public string ITIPO_INTER
        { 
        	get
        	{
         		return this.iTIPO_INTER;
        	}
        	set
        	{
        		this.iTIPO_INTER= value;
        		this.isnull["ITIPO_INTER"]=false;
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

 	private decimal iDIA;
        public decimal IDIA
        { 
        	get
        	{
         		return this.iDIA;
        	}
        	set
        	{
        		this.iDIA= value;
        		this.isnull["IDIA"]=false;
        	}
        }

 	private decimal iMES;
        public decimal IMES
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

 	private string iBLOQXLIMIT;
        public string IBLOQXLIMIT
        { 
        	get
        	{
         		return this.iBLOQXLIMIT;
        	}
        	set
        	{
        		this.iBLOQXLIMIT= value;
        		this.isnull["IBLOQXLIMIT"]=false;
        	}
        }

 	private string iCOMPANIA;
        public string ICOMPANIA
        { 
        	get
        	{
         		return this.iCOMPANIA;
        	}
        	set
        	{
        		this.iCOMPANIA= value;
        		this.isnull["ICOMPANIA"]=false;
        	}
        }

 	private string iCUENTA;
        public string ICUENTA
        { 
        	get
        	{
         		return this.iCUENTA;
        	}
        	set
        	{
        		this.iCUENTA= value;
        		this.isnull["ICUENTA"]=false;
        	}
        }

 	private string iPATERNO;
        public string IPATERNO
        { 
        	get
        	{
         		return this.iPATERNO;
        	}
        	set
        	{
        		this.iPATERNO= value;
        		this.isnull["IPATERNO"]=false;
        	}
        }

 	private string iMATERNO;
        public string IMATERNO
        { 
        	get
        	{
         		return this.iMATERNO;
        	}
        	set
        	{
        		this.iMATERNO= value;
        		this.isnull["IMATERNO"]=false;
        	}
        }

 	private string iNOMBRES;
        public string INOMBRES
        { 
        	get
        	{
         		return this.iNOMBRES;
        	}
        	set
        	{
        		this.iNOMBRES= value;
        		this.isnull["INOMBRES"]=false;
        	}
        }

 	private string iSERVDOMI;
        public string ISERVDOMI
        { 
        	get
        	{
         		return this.iSERVDOMI;
        	}
        	set
        	{
        		this.iSERVDOMI= value;
        		this.isnull["ISERVDOMI"]=false;
        	}
        }

 	private decimal iLIMITE2;
        public decimal ILIMITE2
        { 
        	get
        	{
         		return this.iLIMITE2;
        	}
        	set
        	{
        		this.iLIMITE2= value;
        		this.isnull["ILIMITE2"]=false;
        	}
        }

 	private decimal iLIMITETEMP;
        public decimal ILIMITETEMP
        { 
        	get
        	{
         		return this.iLIMITETEMP;
        	}
        	set
        	{
        		this.iLIMITETEMP= value;
        		this.isnull["ILIMITETEMP"]=false;
        	}
        }

 	private string iTEMPORADA;
        public string ITEMPORADA
        { 
        	get
        	{
         		return this.iTEMPORADA;
        	}
        	set
        	{
        		this.iTEMPORADA= value;
        		this.isnull["ITEMPORADA"]=false;
        	}
        }

 	private string iLEFECTIVO;
        public string ILEFECTIVO
        { 
        	get
        	{
         		return this.iLEFECTIVO;
        	}
        	set
        	{
        		this.iLEFECTIVO= value;
        		this.isnull["ILEFECTIVO"]=false;
        	}
        }

 	private decimal iSALDO_SISA;
        public decimal ISALDO_SISA
        { 
        	get
        	{
         		return this.iSALDO_SISA;
        	}
        	set
        	{
        		this.iSALDO_SISA= value;
        		this.isnull["ISALDO_SISA"]=false;
        	}
        }

 	private string iEMPRE;
        public string IEMPRE
        { 
        	get
        	{
         		return this.iEMPRE;
        	}
        	set
        	{
        		this.iEMPRE= value;
        		this.isnull["IEMPRE"]=false;
        	}
        }

 	private string iFENOMCL;
        public string IFENOMCL
        { 
        	get
        	{
         		return this.iFENOMCL;
        	}
        	set
        	{
        		this.iFENOMCL= value;
        		this.isnull["IFENOMCL"]=false;
        	}
        }

 	private string iFELOCCL;
        public string IFELOCCL
        { 
        	get
        	{
         		return this.iFELOCCL;
        	}
        	set
        	{
        		this.iFELOCCL= value;
        		this.isnull["IFELOCCL"]=false;
        	}
        }

 	private string iFEREFCL;
        public string IFEREFCL
        { 
        	get
        	{
         		return this.iFEREFCL;
        	}
        	set
        	{
        		this.iFEREFCL= value;
        		this.isnull["IFEREFCL"]=false;
        	}
        }

 	private string iFENUECL;
        public string IFENUECL
        { 
        	get
        	{
         		return this.iFENUECL;
        	}
        	set
        	{
        		this.iFENUECL= value;
        		this.isnull["IFENUECL"]=false;
        	}
        }

 	private string iFENUICL;
        public string IFENUICL
        { 
        	get
        	{
         		return this.iFENUICL;
        	}
        	set
        	{
        		this.iFENUICL= value;
        		this.isnull["IFENUICL"]=false;
        	}
        }

 	private string iFEPAICL;
        public string IFEPAICL
        { 
        	get
        	{
         		return this.iFEPAICL;
        	}
        	set
        	{
        		this.iFEPAICL= value;
        		this.isnull["IFEPAICL"]=false;
        	}
        }

 	private string iMETPAGO;
        public string IMETPAGO
        { 
        	get
        	{
         		return this.iMETPAGO;
        	}
        	set
        	{
        		this.iMETPAGO= value;
        		this.isnull["IMETPAGO"]=false;
        	}
        }

 	private string iCTAPAGO;
        public string ICTAPAGO
        { 
        	get
        	{
         		return this.iCTAPAGO;
        	}
        	set
        	{
        		this.iCTAPAGO= value;
        		this.isnull["ICTAPAGO"]=false;
        	}
        }

 	private string iENVIAXML;
        public string IENVIAXML
        { 
        	get
        	{
         		return this.iENVIAXML;
        	}
        	set
        	{
        		this.iENVIAXML= value;
        		this.isnull["IENVIAXML"]=false;
        	}
        }

 	private long iIDD;
        public long IIDD
        { 
        	get
        	{
         		return this.iIDD;
        	}
        	set
        	{
        		this.iIDD= value;
        		this.isnull["IIDD"]=false;
        	}
        }

 	private string iPROCESADO;
        public string IPROCESADO
        { 
        	get
        	{
         		return this.iPROCESADO;
        	}
        	set
        	{
        		this.iPROCESADO= value;
        		this.isnull["IPROCESADO"]=false;
        	}
        }



        private string iEMAIL2;
        public string IEMAIL2
        {
            get
            {
                return this.iEMAIL2;
            }
            set
            {
                this.iEMAIL2 = value;
                this.isnull["IEMAIL2"] = false;
            }
        }

        public CF_CLIPBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("ICLIENTE",true);
	

			isnull.Add("INOMBRE",true);
	

			isnull.Add("ISALDO",true);
	

			isnull.Add("ISALDO_VENC",true);
	

			isnull.Add("ILIMITE",true);
	

			isnull.Add("INUMERO",true);
	

			isnull.Add("ISALDO_US",true);
	

			isnull.Add("IALTA",true);
	

			isnull.Add("IULT_COMPRA",true);
	

			isnull.Add("IUC_CANT",true);
	

			isnull.Add("INOMBRE2",true);
	

			isnull.Add("IFACT_PERIO",true);
	

			isnull.Add("ICOMPRAS_P",true);
	

			isnull.Add("IFACT_ACUM",true);
	

			isnull.Add("ICOMPRAS_A",true);
	

			isnull.Add("ICHQ_DEVUEL",true);
	

			isnull.Add("IF_VENCIDAS",true);
	

			isnull.Add("ICALLE",true);
	

			isnull.Add("ICOLONIA",true);
	

			isnull.Add("IESTADO",true);
	

			isnull.Add("ICIUDAD",true);
	

			isnull.Add("ICP",true);
	

			isnull.Add("IRFC",true);
	

			isnull.Add("ITELEFONO",true);
	

			isnull.Add("ITELEFONO2",true);
	

			isnull.Add("ICONTACTO",true);
	

			isnull.Add("ICONTACTO2",true);
	

			isnull.Add("IVENDEDOR",true);
	

			isnull.Add("ITIPO",true);
	

			isnull.Add("ICOMODIN",true);
	

			isnull.Add("IDIAS",true);
	

			isnull.Add("IDIASA",true);
	

			isnull.Add("IDIASB",true);
	

			isnull.Add("IREVISION",true);
	

			isnull.Add("IPAGOS",true);
	

			isnull.Add("ICLASIFICA",true);
	

			isnull.Add("IDESCUENTO",true);
	

			isnull.Add("IBLOQUEADO",true);
	

			isnull.Add("IBLOQUEONOT",true);
	

			isnull.Add("IEFECTIVO",true);
	

			isnull.Add("ICORREO",true);
	

			isnull.Add("IULT_LLAMAD",true);
	

			isnull.Add("IPROX_LLAMA",true);
	

			isnull.Add("IID",true);
	

			isnull.Add("IID_FECHA",true);
	

			isnull.Add("IID_HORA",true);
	

			isnull.Add("ICALLE1",true);
	

			isnull.Add("ICRUZACON",true);
	

			isnull.Add("IDESGIEPS",true);
	

			isnull.Add("IENDOLARES",true);
	

			isnull.Add("IPLANO",true);
	

			isnull.Add("IEMAIL",true);
	

			isnull.Add("IHOMEPAGE",true);
	

			isnull.Add("IBWCOLOR",true);
	

			isnull.Add("IMULVEN",true);
	

			isnull.Add("ICTA_IEPS",true);
	

			isnull.Add("IP_MOVIL",true);
	

			isnull.Add("IACUMULA",true);
	

			isnull.Add("ISALDO_GLOB",true);
	

			isnull.Add("IUSERNAME",true);
	

			isnull.Add("IID_ALTA",true);
	

			isnull.Add("ICLAVE_EDO",true);
	

			isnull.Add("ICOB_INTERE",true);
	

			isnull.Add("IPLAZA",true);
	

			isnull.Add("ICOM_ESP",true);
	

			isnull.Add("IPOR_COME",true);
	

			isnull.Add("IL_BLOQUEO",true);
	

			isnull.Add("IVISITA",true);
	

			isnull.Add("IRUTA",true);
	

			isnull.Add("IL_DESC",true);
	

			isnull.Add("IPOCKET",true);
	

			isnull.Add("ICLIEPOCK",true);
	

			isnull.Add("IDESCI",true);
	

			isnull.Add("IBLOQ2",true);
	

			isnull.Add("IDIASP",true);
	

			isnull.Add("IDIASEXTR",true);
	

			isnull.Add("ICOBVENCIDA",true);
	

			isnull.Add("IVENDEDOR2",true);
	

			isnull.Add("ICURP",true);
	

			isnull.Add("IAUTORIZA",true);
	

			isnull.Add("ITIPO_INTER",true);
	

			isnull.Add("IESTRATEGIC",true);
	

			isnull.Add("IESTATUS",true);
	

			isnull.Add("IDIA",true);
	

			isnull.Add("IMES",true);
	

			isnull.Add("IBLOQXLIMIT",true);
	

			isnull.Add("ICOMPANIA",true);
	

			isnull.Add("ICUENTA",true);
	

			isnull.Add("IPATERNO",true);
	

			isnull.Add("IMATERNO",true);
	

			isnull.Add("INOMBRES",true);
	

			isnull.Add("ISERVDOMI",true);
	

			isnull.Add("ILIMITE2",true);
	

			isnull.Add("ILIMITETEMP",true);
	

			isnull.Add("ITEMPORADA",true);
	

			isnull.Add("ILEFECTIVO",true);
	

			isnull.Add("ISALDO_SISA",true);
	

			isnull.Add("IEMPRE",true);
	

			isnull.Add("IFENOMCL",true);
	

			isnull.Add("IFELOCCL",true);
	

			isnull.Add("IFEREFCL",true);
	

			isnull.Add("IFENUECL",true);
	

			isnull.Add("IFENUICL",true);
	

			isnull.Add("IFEPAICL",true);
	

			isnull.Add("IMETPAGO",true);
	

			isnull.Add("ICTAPAGO",true);
	

			isnull.Add("IENVIAXML",true);
	

			isnull.Add("IIDD",true);
	

			isnull.Add("IPROCESADO",true);


            isnull.Add("IEMAIL2", true);

        }

		

	}
}
