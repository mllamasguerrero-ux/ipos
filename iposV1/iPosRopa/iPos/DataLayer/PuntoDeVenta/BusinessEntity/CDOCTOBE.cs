
using System;
using System.Collections;
namespace iPosBusinessEntity
{
	public class CDOCTOBE
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

 	private long iALMACENID;
        public long IALMACENID
        { 
        	get
        	{
         		return this.iALMACENID;
        	}
        	set
        	{
        		this.iALMACENID= value;
        		this.isnull["IALMACENID"]=false;
        	}
        }

 	private long iSUCURSALID;
        public long ISUCURSALID
        { 
        	get
        	{
         		return this.iSUCURSALID;
        	}
        	set
        	{
        		this.iSUCURSALID= value;
        		this.isnull["ISUCURSALID"]=false;
        	}
        }

 	private long iTIPODOCTOID;
        public long ITIPODOCTOID
        { 
        	get
        	{
         		return this.iTIPODOCTOID;
        	}
        	set
        	{
        		this.iTIPODOCTOID= value;
        		this.isnull["ITIPODOCTOID"]=false;
        	}
        }

 	private long iESTATUSDOCTOID;
        public long IESTATUSDOCTOID
        { 
        	get
        	{
         		return this.iESTATUSDOCTOID;
        	}
        	set
        	{
        		this.iESTATUSDOCTOID= value;
        		this.isnull["IESTATUSDOCTOID"]=false;
        	}
        }

 	private long iESTATUSDOCTOPAGOID;
        public long IESTATUSDOCTOPAGOID
        { 
        	get
        	{
         		return this.iESTATUSDOCTOPAGOID;
        	}
        	set
        	{
        		this.iESTATUSDOCTOPAGOID= value;
        		this.isnull["IESTATUSDOCTOPAGOID"]=false;
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

 	private long iCAJEROID;
        public long ICAJEROID
        { 
        	get
        	{
         		return this.iCAJEROID;
        	}
        	set
        	{
        		this.iCAJEROID= value;
        		this.isnull["ICAJEROID"]=false;
        	}
        }

 	private long iVENDEDORID;
        public long IVENDEDORID
        { 
        	get
        	{
         		return this.iVENDEDORID;
        	}
        	set
        	{
        		this.iVENDEDORID= value;
        		this.isnull["IVENDEDORID"]=false;
        	}
        }

 	private long iCORTEID;
        public long ICORTEID
        { 
        	get
        	{
         		return this.iCORTEID;
        	}
        	set
        	{
        		this.iCORTEID= value;
        		this.isnull["ICORTEID"]=false;
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
                this.iFECHA = value;
                this.isnull["IFECHA"] = false;
            }
        }

        private DateTime iFECHAHORA;
        public DateTime IFECHAHORA
        {
            get
            {
                return this.iFECHAHORA;
            }
            set
            {
                this.iFECHAHORA = value;
                this.isnull["IFECHAHORA"] = false;
            }
        }


 	private string iSERIE;
        public string ISERIE
        { 
        	get
        	{
         		return this.iSERIE;
        	}
        	set
        	{
        		this.iSERIE= value;
        		this.isnull["ISERIE"]=false;
        	}
        }

 	private int iFOLIO;
        public int IFOLIO
        { 
        	get
        	{
         		return this.iFOLIO;
        	}
        	set
        	{
        		this.iFOLIO= value;
        		this.isnull["IFOLIO"]=false;
        	}
        }

 	private short iPLAZO;
        public short IPLAZO
        { 
        	get
        	{
         		return this.iPLAZO;
        	}
        	set
        	{
        		this.iPLAZO= value;
        		this.isnull["IPLAZO"]=false;
        	}
        }

 	private DateTime iVENCE;
        public DateTime IVENCE
        { 
        	get
        	{
         		return this.iVENCE;
        	}
        	set
        	{
        		this.iVENCE= value;
        		this.isnull["IVENCE"]=false;
        	}
        }

 	private string iREFERENCIA;
        public string IREFERENCIA
        { 
        	get
        	{
         		return this.iREFERENCIA;
        	}
        	set
        	{
        		this.iREFERENCIA= value;
        		this.isnull["IREFERENCIA"]=false;
        	}
        }

 	private string iREFERENCIAS;
        public string IREFERENCIAS
        { 
        	get
        	{
         		return this.iREFERENCIAS;
        	}
        	set
        	{
        		this.iREFERENCIAS= value;
        		this.isnull["IREFERENCIAS"]=false;
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

 	private string iOBSERVACION;
        public string IOBSERVACION
        { 
        	get
        	{
         		return this.iOBSERVACION;
        	}
        	set
        	{
        		this.iOBSERVACION= value;
        		this.isnull["IOBSERVACION"]=false;
        	}
        }

 	private string iOBSERVACIONES;
        public string IOBSERVACIONES
        { 
        	get
        	{
         		return this.iOBSERVACIONES;
        	}
        	set
        	{
        		this.iOBSERVACIONES= value;
        		this.isnull["IOBSERVACIONES"]=false;
        	}
        }

 	private decimal iIMPORTE;
        public decimal IIMPORTE
        { 
        	get
        	{
         		return this.iIMPORTE;
        	}
        	set
        	{
        		this.iIMPORTE= value;
        		this.isnull["IIMPORTE"]=false;
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

 	private decimal iSUBTOTAL;
        public decimal ISUBTOTAL
        { 
        	get
        	{
         		return this.iSUBTOTAL;
        	}
        	set
        	{
        		this.iSUBTOTAL= value;
        		this.isnull["ISUBTOTAL"]=false;
        	}
        }

 	private decimal iIVA;
        public decimal IIVA
        { 
        	get
        	{
         		return this.iIVA;
        	}
        	set
        	{
        		this.iIVA= value;
        		this.isnull["IIVA"]=false;
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

 	private decimal iCARGO;
        public decimal ICARGO
        { 
        	get
        	{
         		return this.iCARGO;
        	}
        	set
        	{
        		this.iCARGO= value;
        		this.isnull["ICARGO"]=false;
        	}
        }

 	private decimal iABONO;
        public decimal IABONO
        { 
        	get
        	{
         		return this.iABONO;
        	}
        	set
        	{
        		this.iABONO= value;
        		this.isnull["IABONO"]=false;
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

 	private long iCAJAID;
        public long ICAJAID
        { 
        	get
        	{
         		return this.iCAJAID;
        	}
        	set
        	{
        		this.iCAJAID= value;
        		this.isnull["ICAJAID"]=false;
        	}
        }



        private long iDOCTOREFID;
        public long IDOCTOREFID
        {
            get
            {
                return this.iDOCTOREFID;
            }
            set
            {
                this.iDOCTOREFID = value;
                this.isnull["IDOCTOREFID"] = false;
            }
        }




        private long iSUCURSALTID;
        public long ISUCURSALTID
        {
            get
            {
                return this.iSUCURSALTID;
            }
            set
            {
                this.iSUCURSALTID = value;
                this.isnull["ISUCURSALTID"] = false;
            }
        }
        private string iTRANREGSERVER;
        public string ITRANREGSERVER
        {
            get
            {
                return this.iTRANREGSERVER;
            }
            set
            {
                this.iTRANREGSERVER = value;
                this.isnull["ITRANREGSERVER"] = false;
            }
        }




        private long iORIGENFISCALID;
        public long IORIGENFISCALID
        {
            get
            {
                return this.iORIGENFISCALID;
            }
            set
            {
                this.iORIGENFISCALID = value;
                this.isnull["IORIGENFISCALID"] = false;
            }
        }

        private int iFOLIOORIGENFACTURADO;
        public int IFOLIOORIGENFACTURADO
        {
            get
            {
                return this.iFOLIOORIGENFACTURADO;
            }
            set
            {
                this.iFOLIOORIGENFACTURADO = value;
                this.isnull["IFOLIOORIGENFACTURADO"] = false;
            }
        }

        private decimal iMONTOORIGENFACTURADO;
        public decimal IMONTOORIGENFACTURADO
        {
            get
            {
                return this.iMONTOORIGENFACTURADO;
            }
            set
            {
                this.iMONTOORIGENFACTURADO = value;
                this.isnull["IMONTOORIGENFACTURADO"] = false;
            }
        }

        private long iVENDEDORFINAL;
        public long IVENDEDORFINAL
        {
            get
            {
                return this.iVENDEDORFINAL;
            }
            set
            {
                this.iVENDEDORFINAL = value;
                this.isnull["IVENDEDORFINAL"] = false;
            }
        }


        private string iAPLICADOREF;
        public string IAPLICADOREF
        {
            get
            {
                return this.iAPLICADOREF;
            }
            set
            {
                this.iAPLICADOREF = value;
                this.isnull["IAPLICADOREF"] = false;
            }
        }




        private string iMERCANCIAENTREGADA;
        public string IMERCANCIAENTREGADA
        {
            get
            {
                return this.iMERCANCIAENTREGADA;
            }
            set
            {
                this.iMERCANCIAENTREGADA = value;
                this.isnull["IMERCANCIAENTREGADA"] = false;
            }
        }


        private long iPERSONAAPARTADOID;
        public long IPERSONAAPARTADOID
        {
            get
            {
                return this.iPERSONAAPARTADOID;
            }
            set
            {
                this.iPERSONAAPARTADOID = value;
                this.isnull["IPERSONAAPARTADOID"] = false;
            }
        }



        private string iTIMBRADOUUID;
        public string ITIMBRADOUUID
        {
            get
            {
                return this.iTIMBRADOUUID;
            }
            set
            {
                this.iTIMBRADOUUID = value;
                this.isnull["ITIMBRADOUUID"] = false;
            }
        }
        private string iTIMBRADOCERTSAT;
        public string ITIMBRADOCERTSAT
        {
            get
            {
                return this.iTIMBRADOCERTSAT;
            }
            set
            {
                this.iTIMBRADOCERTSAT = value;
                this.isnull["ITIMBRADOCERTSAT"] = false;
            }
        }
        private string iTIMBRADOFECHA;
        public string ITIMBRADOFECHA
        {
            get
            {
                return this.iTIMBRADOFECHA;
            }
            set
            {
                this.iTIMBRADOFECHA = value;
                this.isnull["ITIMBRADOFECHA"] = false;
            }
        }




        private string iTIMBRADOSELLOSAT;
        public string ITIMBRADOSELLOSAT
        {
            get
            {
                return this.iTIMBRADOSELLOSAT;
            }
            set
            {
                this.iTIMBRADOSELLOSAT = value;
                this.isnull["ITIMBRADOSELLOSAT"] = false;
            }
        }


        private string iTIMBRADOSELLOCFDI;
        public string ITIMBRADOSELLOCFDI
        {
            get
            {
                return this.iTIMBRADOSELLOCFDI;
            }
            set
            {
                this.iTIMBRADOSELLOCFDI = value;
                this.isnull["ITIMBRADOSELLOCFDI"] = false;
            }
        }


        private string iSERIESAT;
        public string ISERIESAT
        {
            get
            {
                return this.iSERIESAT;
            }
            set
            {
                this.iSERIESAT = value;
                this.isnull["ISERIESAT"] = false;
            }
        }

        private int iFOLIOSAT;
        public int IFOLIOSAT
        {
            get
            {
                return this.iFOLIOSAT;
            }
            set
            {
                this.iFOLIOSAT = value;
                this.isnull["IFOLIOSAT"] = false;
            }
        }


        private long iDOCTOPAGOSAT;
        public long IDOCTOPAGOSAT
        {
            get
            {
                return this.iDOCTOPAGOSAT;
            }
            set
            {
                this.iDOCTOPAGOSAT = value;
                this.isnull["IDOCTOPAGOSAT"] = false;
            }
        }



        private string iESAPARTADO;
        public string IESAPARTADO
        {
            get
            {
                return this.iESAPARTADO;
            }
            set
            {
                this.iESAPARTADO = value;
                this.isnull["IESAPARTADO"] = false;
            }
        }

        private string iESFACTURAELECTRONICA;
        public string IESFACTURAELECTRONICA
        {
            get
            {
                return this.iESFACTURAELECTRONICA;
            }
            set
            {
                this.iESFACTURAELECTRONICA = value;
                this.isnull["IESFACTURAELECTRONICA"] = false;
            }
        }


        private string iTRASLADOAFTP;
        public string ITRASLADOAFTP
        {
            get
            {
                return this.iTRASLADOAFTP;
            }
            set
            {
                this.iTRASLADOAFTP = value;
                this.isnull["ITRASLADOAFTP"] = false;
            }
        }




        private long iSUBTIPODOCTOID;
        public long ISUBTIPODOCTOID
        {
            get
            {
                return this.iSUBTIPODOCTOID;
            }
            set
            {
                this.iSUBTIPODOCTOID = value;
                this.isnull["ISUBTIPODOCTOID"] = false;
            }
        }



        private DateTime iFECHAINI;
        public DateTime IFECHAINI
        {
            get
            {
                return this.iFECHAINI;
            }
            set
            {
                this.iFECHAINI = value;
                this.isnull["IFECHAINI"] = false;
            }
        }


        private DateTime iFECHAFIN;
        public DateTime IFECHAFIN
        {
            get
            {
                return this.iFECHAFIN;
            }
            set
            {
                this.iFECHAFIN = value;
                this.isnull["IFECHAFIN"] = false;
            }
        }



        private long iSUPERVISORID;
        public long ISUPERVISORID
        {
            get
            {
                return this.iSUPERVISORID;
            }
            set
            {
                this.iSUPERVISORID = value;
                this.isnull["ISUPERVISORID"] = false;
            }
        }



        private string iUSARDATOSENTREGA;
        public string IUSARDATOSENTREGA
        {
            get
            {
                return this.iUSARDATOSENTREGA;
            }
            set
            {
                this.iUSARDATOSENTREGA = value;
                this.isnull["IUSARDATOSENTREGA"] = false;
            }
        }



        private decimal iISRRETENIDO;
        public decimal IISRRETENIDO
        {
            get
            {
                return this.iISRRETENIDO;
            }
            set
            {
                this.iISRRETENIDO = value;
                this.isnull["IISRRETENIDO"] = false;
            }
        }



        private decimal iIVARETENIDO;
        public decimal IIVARETENIDO
        {
            get
            {
                return this.iIVARETENIDO;
            }
            set
            {
                this.iIVARETENIDO = value;
                this.isnull["IIVARETENIDO"] = false;
            }
        }


        private long iMONEDAID;
        public long IMONEDAID
        {
            get
            {
                return this.iMONEDAID;
            }
            set
            {
                this.iMONEDAID = value;
                this.isnull["IMONEDAID"] = false;
            }
        }


        private decimal iTIPOCAMBIO;
        public decimal ITIPOCAMBIO
        {
            get
            {
                return this.iTIPOCAMBIO;
            }
            set
            {
                this.iTIPOCAMBIO = value;
                this.isnull["ITIPOCAMBIO"] = false;
            }
        }



        private decimal iIEPS;
        public decimal IIEPS
        {
            get
            {
                return this.iIEPS;
            }
            set
            {
                this.iIEPS = value;
                this.isnull["IIEPS"] = false;
            }
        }

        private decimal iIMPUESTO;
        public decimal IIMPUESTO
        {
            get
            {
                return this.iIMPUESTO;
            }
            set
            {
                this.iIMPUESTO = value;
                this.isnull["IIMPUESTO"] = false;
            }
        }





        private decimal iTOTALANTICIPO;
        public decimal ITOTALANTICIPO
        {
            get
            {
                return this.iTOTALANTICIPO;
            }
            set
            {
                this.iTOTALANTICIPO = value;
                this.isnull["ITOTALANTICIPO"] = false;
            }
        }


        private long iESTATUSANTICIPOID;
        public long IESTATUSANTICIPOID
        {
            get
            {
                return this.iESTATUSANTICIPOID;
            }
            set
            {
                this.iESTATUSANTICIPOID = value;
                this.isnull["IESTATUSANTICIPOID"] = false;
            }
        }


        private DateTime iFECHAFACTURA;
        public DateTime IFECHAFACTURA
        {
            get
            {
                return this.iFECHAFACTURA;
            }
            set
            {
                this.iFECHAFACTURA = value;
                this.isnull["IFECHAFACTURA"] = false;
            }
        }


        private string iNOTAPAGO;
        public string INOTAPAGO
        {
            get
            {
                return this.iNOTAPAGO;
            }
            set
            {
                this.iNOTAPAGO = value;
                this.isnull["INOTAPAGO"] = false;
            }
        }


        private string iMANEJORECETA;
        public string IMANEJORECETA
        {
            get
            {
                return this.iMANEJORECETA;
            }
            set
            {
                this.iMANEJORECETA = value;
                this.isnull["IMANEJORECETA"] = false;
            }
        }


        private string iMOVILPLAZOS;
        public string IMOVILPLAZOS
        {
            get
            {
                return this.iMOVILPLAZOS;
            }
            set
            {
                this.iMOVILPLAZOS = value;
                this.isnull["IMOVILPLAZOS"] = false;
            }
        }



        private string iMOVILCONTADO;
        public string IMOVILCONTADO
        {
            get
            {
                return this.iMOVILCONTADO;
            }
            set
            {
                this.iMOVILCONTADO = value;
                this.isnull["IMOVILCONTADO"] = false;
            }
        }



        private string iTIMBRADOCANCELADO;
        public string ITIMBRADOCANCELADO
        {
            get
            {
                return this.iTIMBRADOCANCELADO;
            }
            set
            {
                this.iTIMBRADOCANCELADO = value;
                this.isnull["ITIMBRADOCANCELADO"] = false;
            }
        }


        private DateTime iTIMBRADOFECHACANCELACION;
        public DateTime ITIMBRADOFECHACANCELACION
        {
            get
            {
                return this.iTIMBRADOFECHACANCELACION;
            }
            set
            {
                this.iTIMBRADOFECHACANCELACION = value;
                this.isnull["ITIMBRADOFECHACANCELACION"] = false;
            }
        }



        private string iTIMBRADOUUIDCANCELACION;
        public string ITIMBRADOUUIDCANCELACION
        {
            get
            {
                return this.iTIMBRADOUUIDCANCELACION;
            }
            set
            {
                this.iTIMBRADOUUIDCANCELACION = value;
                this.isnull["ITIMBRADOUUIDCANCELACION"] = false;
            }
        }



        private DateTime iTIMBRADOFECHAFACTURA;
        public DateTime ITIMBRADOFECHAFACTURA
        {
            get
            {
                return this.iTIMBRADOFECHAFACTURA;
            }
            set
            {
                this.iTIMBRADOFECHAFACTURA = value;
                this.isnull["ITIMBRADOFECHAFACTURA"] = false;
            }
        }



        private long iALMACENTID;
        public long IALMACENTID
        {
            get
            {
                return this.iALMACENTID;
            }
            set
            {
                this.iALMACENTID = value;
                this.isnull["IALMACENTID"] = false;
            }
        }



        private decimal iTOTALCONREBAJA;
        public decimal ITOTALCONREBAJA
        {
            get
            {
                return this.iTOTALCONREBAJA;
            }
            set
            {
                this.iTOTALCONREBAJA = value;
                this.isnull["ITOTALCONREBAJA"] = false;
            }
        }


        private decimal iMONTOREBAJA;
        public decimal IMONTOREBAJA
        {
            get
            {
                return this.iMONTOREBAJA;
            }
            set
            {
                this.iMONTOREBAJA = value;
                this.isnull["IMONTOREBAJA"] = false;
            }
        }




        private string iPROCESOSURTIDO;
        public string IPROCESOSURTIDO
        {
            get
            {
                return this.iPROCESOSURTIDO;
            }
            set
            {
                this.iPROCESOSURTIDO = value;
                this.isnull["IPROCESOSURTIDO"] = false;
            }
        }





        private DateTime iPENDMAXFECHA;
        public DateTime IPENDMAXFECHA
        {
            get
            {
                return this.iPENDMAXFECHA;
            }
            set
            {
                this.iPENDMAXFECHA = value;
                this.isnull["IPENDMAXFECHA"] = false;
            }
        }



        private long iESTADOSURTIDOID;
        public long IESTADOSURTIDOID
        {
            get
            {
                return this.iESTADOSURTIDOID;
            }
            set
            {
                this.iESTADOSURTIDOID = value;
                this.isnull["IESTADOSURTIDOID"] = false;
            }
        }



        private long iFACTCONSID;
        public long IFACTCONSID
        {
            get
            {
                return this.iFACTCONSID;
            }
            set
            {
                this.iFACTCONSID = value;
                this.isnull["IFACTCONSID"] = false;
            }
        }



        private long iDEVCONSID;
        public long IDEVCONSID
        {
            get
            {
                return this.iDEVCONSID;
            }
            set
            {
                this.iDEVCONSID = value;
                this.isnull["IDEVCONSID"] = false;
            }
        }




        private long iTIPODESCUENTOVALE;
        public long ITIPODESCUENTOVALE
        {
            get
            {
                return this.iTIPODESCUENTOVALE;
            }
            set
            {
                this.iTIPODESCUENTOVALE = value;
                this.isnull["ITIPODESCUENTOVALE"] = false;
            }
        }



        private long iMONTOBILLETESID;
        public long IMONTOBILLETESID
        {
            get
            {
                return this.iMONTOBILLETESID;
            }
            set
            {
                this.iMONTOBILLETESID = value;
                this.isnull["IMONTOBILLETESID"] = false;
            }
        }



        private string iPAGOCONTARJETA;
        public string IPAGOCONTARJETA
        {
            get
            {
                return this.iPAGOCONTARJETA;
            }
            set
            {
                this.iPAGOCONTARJETA = value;
                this.isnull["IPAGOCONTARJETA"] = false;
            }
        }



        private decimal iCOMISIONPAGOTARJETA;
        public decimal ICOMISIONPAGOTARJETA
        {
            get
            {
                return this.iCOMISIONPAGOTARJETA;
            }
            set
            {
                this.iCOMISIONPAGOTARJETA = value;
                this.isnull["ICOMISIONPAGOTARJETA"] = false;
            }
        }



        private string iTIMBRADOFORMAPAGOSAT;
        public string ITIMBRADOFORMAPAGOSAT
        {
            get
            {
                return this.iTIMBRADOFORMAPAGOSAT;
            }
            set
            {
                this.iTIMBRADOFORMAPAGOSAT = value;
                this.isnull["ITIMBRADOFORMAPAGOSAT"] = false;
            }
        }



        private long iVENTAFUTUID;
        public long IVENTAFUTUID
        {
            get
            {
                return this.iVENTAFUTUID;
            }
            set
            {
                this.iVENTAFUTUID = value;
                this.isnull["IVENTAFUTUID"] = false;
            }
        }




        private long iRUTAEMBARQUEID;
        public long IRUTAEMBARQUEID
        {
            get
            {
                return this.iRUTAEMBARQUEID;
            }
            set
            {
                this.iRUTAEMBARQUEID = value;
                this.isnull["IRUTAEMBARQUEID"] = false;
            }
        }

        private long iESTADOGUIAID;
        public long IESTADOGUIAID
        {
            get
            {
                return this.iESTADOGUIAID;
            }
            set
            {
                this.iESTADOGUIAID = value;
                this.isnull["IESTADOGUIAID"] = false;
            }
        }


        private long iGUIAID;
        public long IGUIAID
        {
            get
            {
                return this.iGUIAID;
            }
            set
            {
                this.iGUIAID = value;
                this.isnull["IGUIAID"] = false;
            }
        }



        private string iPAGOBANCOMERAPLICADO;
        public string IPAGOBANCOMERAPLICADO
        {
            get
            {
                return this.iPAGOBANCOMERAPLICADO;
            }
            set
            {
                this.iPAGOBANCOMERAPLICADO = value;
                this.isnull["IPAGOBANCOMERAPLICADO"] = false;
            }
        }



        private string iPAGOACREDITO;
        public string IPAGOACREDITO
        {
            get
            {
                return this.iPAGOACREDITO;
            }
            set
            {
                this.iPAGOACREDITO = value;
                this.isnull["IPAGOACREDITO"] = false;
            }
        }


        private string iORDENCOMPRA;
        public string IORDENCOMPRA
        {
            get
            {
                return this.iORDENCOMPRA;
            }
            set
            {
                this.iORDENCOMPRA = value;
                this.isnull["IORDENCOMPRA"] = false;
            }
        }


        private long iLOTEIMPORTADO;
        public long ILOTEIMPORTADO
        {
            get
            {
                return this.iLOTEIMPORTADO;
            }
            set
            {
                this.iLOTEIMPORTADO = value;
                this.isnull["ILOTEIMPORTADO"] = false;
            }
        }



        private long iVENDEDOREJECUTIVOID;
        public long IVENDEDOREJECUTIVOID
        {
            get
            {
                return this.iVENDEDOREJECUTIVOID;
            }
            set
            {
                this.iVENDEDOREJECUTIVOID = value;
                this.isnull["IVENDEDOREJECUTIVOID"] = false;
            }
        }




        private long iDOCTOPLAZOORIGENID;
        public long IDOCTOPLAZOORIGENID
        {
            get
            {
                return this.iDOCTOPLAZOORIGENID;
            }
            set
            {
                this.iDOCTOPLAZOORIGENID = value;
                this.isnull["IDOCTOPLAZOORIGENID"] = false;
            }
        }


        private long iDOCTOIMPORTADOID;
        public long IDOCTOIMPORTADOID
        {
            get
            {
                return this.iDOCTOIMPORTADOID;
            }
            set
            {
                this.iDOCTOIMPORTADOID = value;
                this.isnull["IDOCTOIMPORTADOID"] = false;
            }
        }


        private long iAUTORIZOALERTAID;
        public long IAUTORIZOALERTAID
        {
            get
            {
                return this.iAUTORIZOALERTAID;
            }
            set
            {
                this.iAUTORIZOALERTAID = value;
                this.isnull["IAUTORIZOALERTAID"] = false;
            }
        }


        private long iPAGOSAT;
        public long IPAGOSAT
        {
            get
            {
                return this.iPAGOSAT;
            }
            set
            {
                this.iPAGOSAT = value;
                this.isnull["IPAGOSAT"] = false;
            }
        }


        private long iSAT_USOCFDIID;
        public long ISAT_USOCFDIID
        {
            get
            {
                return this.iSAT_USOCFDIID;
            }
            set
            {
                this.iSAT_USOCFDIID = value;
                this.isnull["ISAT_USOCFDIID"] = false;
            }
        }



        private long iDOCTOSUSTITUTOID;
        public long IDOCTOSUSTITUTOID
        {
            get
            {
                return this.iDOCTOSUSTITUTOID;
            }
            set
            {
                this.iDOCTOSUSTITUTOID = value;
                this.isnull["IDOCTOSUSTITUTOID"] = false;
            }
        }



        private long iDOCTOASUSTITUIRID;
        public long IDOCTOASUSTITUIRID
        {
            get
            {
                return this.iDOCTOASUSTITUIRID;
            }
            set
            {
                this.iDOCTOASUSTITUIRID = value;
                this.isnull["IDOCTOASUSTITUIRID"] = false;
            }
        }




        private long iCFDIID;
        public long ICFDIID
        {
            get
            {
                return this.iCFDIID;
            }
            set
            {
                this.iCFDIID = value;
                this.isnull["ICFDIID"] = false;
            }
        }



        private string iKITDESGLOSADO;
        public string IKITDESGLOSADO
        {
            get
            {
                return this.iKITDESGLOSADO;
            }
            set
            {
                this.iKITDESGLOSADO = value;
                this.isnull["IKITDESGLOSADO"] = false;
            }
        }


        private long iPLAZOID;
        public long IPLAZOID
        {
            get
            {
                return this.iPLAZOID;
            }
            set
            {
                this.iPLAZOID = value;
                this.isnull["IPLAZOID"] = false;
            }
        }


        private string iESSERVDOMICILIO;
        public string IESSERVDOMICILIO
        {
            get
            {
                return this.iESSERVDOMICILIO;
            }
            set
            {
                this.iESSERVDOMICILIO = value;
                this.isnull["IESSERVDOMICILIO"] = false;
            }
        }


        private decimal iABONONOAPLICADO;
        public decimal IABONONOAPLICADO
        {
            get
            {
                return this.iABONONOAPLICADO;
            }
            set
            {
                this.iABONONOAPLICADO = value;
                this.isnull["IABONONOAPLICADO"] = false;
            }
        }




        private decimal iCOMISION;
        public decimal ICOMISION
        {
            get
            {
                return this.iCOMISION;
            }
            set
            {
                this.iCOMISION = value;
                this.isnull["ICOMISION"] = false;
            }
        }


        private long iESTADOREVISADOID;
        public long IESTADOREVISADOID
        {
            get
            {
                return this.iESTADOREVISADOID;
            }
            set
            {
                this.iESTADOREVISADOID = value;
                this.isnull["IESTADOREVISADOID"] = false;
            }
        }



        private decimal iCOMISIONPAGOTARJETADEB;
        public decimal ICOMISIONPAGOTARJETADEB
        {
            get
            {
                return this.iCOMISIONPAGOTARJETADEB;
            }
            set
            {
                this.iCOMISIONPAGOTARJETADEB = value;
                this.isnull["ICOMISIONPAGOTARJETADEB"] = false;
            }
        }


        private long iCONTRARECIBOID;
        public long ICONTRARECIBOID
        {
            get
            {
                return this.iCONTRARECIBOID;
            }
            set
            {
                this.iCONTRARECIBOID = value;
                this.isnull["ICONTRARECIBOID"] = false;
            }
        }

        private long iESTADOREBAJA;
        public long IESTADOREBAJA
        {
            get
            {
                return this.iESTADOREBAJA;
            }
            set
            {
                this.iESTADOREBAJA = value;
                this.isnull["IESTADOREBAJA"] = false;
            }
        }


        private long iTIPODIFERENCIAINVENTARIOID;
        public long ITIPODIFERENCIAINVENTARIOID
        {
            get
            {
                return this.iTIPODIFERENCIAINVENTARIOID;
            }
            set
            {
                this.iTIPODIFERENCIAINVENTARIOID = value;
                this.isnull["ITIPODIFERENCIAINVENTARIOID"] = false;
            }
        }



        private decimal iUTILIDAD;
        public decimal IUTILIDAD
        {
            get
            {
                return this.iUTILIDAD;
            }
            set
            {
                this.iUTILIDAD = value;
                this.isnull["IUTILIDAD"] = false;
            }
        }


        private string iPAGOVERIFONEAPLICADO;
        public string IPAGOVERIFONEAPLICADO
        {
            get
            {
                return this.iPAGOVERIFONEAPLICADO;
            }
            set
            {
                this.iPAGOVERIFONEAPLICADO = value;
                this.isnull["IPAGOVERIFONEAPLICADO"] = false;
            }
        }



        private string iESVENTAESPECIAL;
        public string IESVENTAESPECIAL
        {
            get
            {
                return this.iESVENTAESPECIAL;
            }
            set
            {
                this.iESVENTAESPECIAL = value;
                this.isnull["IESVENTAESPECIAL"] = false;
            }
        }


        private string iCOTI_ENRUTADA;
        public string ICOTI_ENRUTADA
        {
            get
            {
                return this.iCOTI_ENRUTADA;
            }
            set
            {
                this.iCOTI_ENRUTADA = value;
                this.isnull["ICOTI_ENRUTADA"] = false;
            }
        }


        private long iDOM_ENTREGAID;
        public long IDOM_ENTREGAID
        {
            get
            {
                return this.iDOM_ENTREGAID;
            }
            set
            {
                this.iDOM_ENTREGAID = value;
                this.isnull["IDOM_ENTREGAID"] = false;
            }
        }

        public CDOCTOBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IID",true);
	

			isnull.Add("IACTIVO",true);
	

			isnull.Add("ICREADO",true);
	

			isnull.Add("ICREADOPOR_USERID",true);
	

			isnull.Add("IMODIFICADO",true);
	

			isnull.Add("IMODIFICADOPOR_USERID",true);
	

			isnull.Add("IALMACENID",true);
	

			isnull.Add("ISUCURSALID",true);
	

			isnull.Add("ITIPODOCTOID",true);
	

			isnull.Add("IESTATUSDOCTOID",true);
	

			isnull.Add("IESTATUSDOCTOPAGOID",true);
	

			isnull.Add("IPERSONAID",true);
	

			isnull.Add("ICAJEROID",true);
	

			isnull.Add("IVENDEDORID",true);
	

			isnull.Add("ICORTEID",true);
	

			isnull.Add("IFECHA",true);
	

			isnull.Add("IFECHAHORA",true);
	

			isnull.Add("ISERIE",true);
	

			isnull.Add("IFOLIO",true);
	

			isnull.Add("IPLAZO",true);
	

			isnull.Add("IVENCE",true);
	

			isnull.Add("IREFERENCIA",true);
	

			isnull.Add("IREFERENCIAS",true);
	

			isnull.Add("IDESCRIPCION",true);
	

			isnull.Add("IOBSERVACION",true);
	

			isnull.Add("IOBSERVACIONES",true);
	

			isnull.Add("IIMPORTE",true);
	

			isnull.Add("IDESCUENTO",true);
	

			isnull.Add("ISUBTOTAL",true);
	

			isnull.Add("IIVA",true);
	

			isnull.Add("ITOTAL",true);
	

			isnull.Add("ICARGO",true);
	

			isnull.Add("IABONO",true);
	

			isnull.Add("ISALDO",true);
	

			isnull.Add("ICAJAID",true);


            isnull.Add("IDOCTOREFID", true);


            isnull.Add("ISUCURSALTID", true);
                   

            isnull.Add("ITRANREGSERVER", true);
                   

            isnull.Add("IORIGENFISCALID", true);


            isnull.Add("IFOLIOORIGENFACTURADO", true);


            isnull.Add("IMONTOORIGENFACTURADO", true);


            isnull.Add("IVENDEDORFINAL", true);

            isnull.Add("IAPLICADOREF", true);

            isnull.Add("IMERCANCIAENTREGADA", true);

            isnull.Add("IPERSONAAPARTADOID", true);

            isnull.Add("ITIMBRADOUUID", true);
            isnull.Add("ITIMBRADOCERTSAT", true);
            isnull.Add("ITIMBRADOFECHA", true);

            isnull.Add("ITIMBRADOSELLOCFDI", true);
            isnull.Add("ITIMBRADOSELLOSAT", true);




            isnull.Add("ISERIESAT", true);
            isnull.Add("IFOLIOSAT", true);

            isnull.Add("IDOCTOPAGOSAT", true);
            isnull.Add("IESAPARTADO", true);
            isnull.Add("IESFACTURAELECTRONICA", true);

            isnull.Add("ITRASLADOAFTP", true);

            isnull.Add("ISUBTIPODOCTOID", true);

            isnull.Add("IFECHAINI", true);

            isnull.Add("IFECHAFIN", true);

            isnull.Add("ISUPERVISORID", true);

            isnull.Add("IUSARDATOSENTREGA", true);



            isnull.Add("IISRRETENIDO", true);

            isnull.Add("IIVARETENIDO", true);

            isnull.Add("IMONEDAID", true);

            isnull.Add("ITIPOCAMBIO", true);
                   
            isnull.Add("IIMPUESTO", true);

            isnull.Add("IIEPS", true);

            isnull.Add("ITOTALANTICIPO", true);

            isnull.Add("IESTATUSANTICIPOID", true);


            isnull.Add("IFECHAFACTURA", true);
            isnull.Add("INOTAPAGO", true);

            isnull.Add("IMANEJORECETA", true);

            isnull.Add("IMOVILPLAZOS", true);

            isnull.Add("IMOVILCONTADO", true);

            isnull.Add("ITIMBRADOCANCELADO", true);
            isnull.Add("ITIMBRADOFECHACANCELACION", true);
            isnull.Add("ITIMBRADOUUIDCANCELACION", true);
            isnull.Add("ITIMBRADOFECHAFACTURA", true);


            isnull.Add("IALMACENTID", true);

            isnull.Add("ITOTALCONREBAJA", true);

            isnull.Add("IMONTOREBAJA", true);

            isnull.Add("IPROCESOSURTIDO", true);

            isnull.Add("IPENDMAXFECHA", true);

            isnull.Add("IESTADOSURTIDOID", true);

            isnull.Add("IFACTCONSID", true);

            isnull.Add("IDEVCONSID", true);

            isnull.Add("ITIPODESCUENTOVALE", true);

            isnull.Add("IMONTOBILLETESID", true);

            isnull.Add("IPAGOCONTARJETA", true);

            isnull.Add("ICOMISIONPAGOTARJETA", true);

            isnull.Add("ITIMBRADOFORMAPAGOSAT", true);

            isnull.Add("IVENTAFUTUID", true);

            isnull.Add("IRUTAEMBARQUEID", true);

            isnull.Add("IESTADOGUIAID", true);

            isnull.Add("IGUIAID", true);

            isnull.Add("IPAGOBANCOMERAPLICADO", true);

            isnull.Add("IPAGOACREDITO", true);

            isnull.Add("IORDENCOMPRA", true);


            isnull.Add("ILOTEIMPORTADO", true);

            isnull.Add("IVENDEDOREJECUTIVOID", true);

            isnull.Add("IDOCTOPLAZOORIGENID", true);


            isnull.Add("IDOCTOIMPORTADOID", true);

            isnull.Add("IAUTORIZOALERTAID", true);

            isnull.Add("IPAGOSAT", true);


            isnull.Add("ISAT_USOCFDIID", true);

            isnull.Add("IDOCTOSUSTITUTOID", true);
            isnull.Add("IDOCTOASUSTITUIRID", true);


            isnull.Add("ICFDIID", true);


            isnull.Add("IKITDESGLOSADO", true);

            isnull.Add("IPLAZOID", true);

            isnull.Add("IESSERVDOMICILIO", true);

            isnull.Add("IABONONOAPLICADO", true);


            isnull.Add("ICOMISION", true);

            isnull.Add("IESTADOREVISADOID", true);

            isnull.Add("ICOMISIONPAGOTARJETADEB", true);

            isnull.Add("ICONTRARECIBOID", true);

            isnull.Add("IESTADOREBAJA", true);

            isnull.Add("ITIPODIFERENCIAINVENTARIOID", true);

            isnull.Add("IUTILIDAD", true);

            isnull.Add("IPAGOVERIFONEAPLICADO", true);

            isnull.Add("IESVENTAESPECIAL", true);

            isnull.Add("ICOTI_ENRUTADA", true);

            isnull.Add("IDOM_ENTREGAID", true);


        }

		

	}
}
