
using System;
using System.Collections;

namespace iPosBusinessEntity
{
    public class CBANCOMERPARAMBE
    {


        public CREQUESTBANCOMERBE ClsRequest = new CREQUESTBANCOMERBE();
        public CRESPONSEBANCOMERBE ClsResponse = new CRESPONSEBANCOMERBE();
        public CSTRUCPTOSBANCOMERBE Pts = new CSTRUCPTOSBANCOMERBE();

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
                this.iID = value;
                this.isnull["IID"] = false;
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
                this.iACTIVO = value;
                this.isnull["IACTIVO"] = false;
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
                this.iCREADO = value;
                this.isnull["ICREADO"] = false;
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
                this.iCREADOPOR_USERID = value;
                this.isnull["ICREADOPOR_USERID"] = false;
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
                this.iMODIFICADO = value;
                this.isnull["IMODIFICADO"] = false;
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
                this.iMODIFICADOPOR_USERID = value;
                this.isnull["IMODIFICADOPOR_USERID"] = false;
            }
        }

        private string iAID;
        public string IAID
        {
            get
            {
                return this.iAID;
            }
            set
            {
                this.iAID = value;
                this.isnull["IAID"] = false;
            }
        }

        private short iAMEX;
        public short IAMEX
        {
            get
            {
                return this.iAMEX;
            }
            set
            {
                this.iAMEX = value;
                this.isnull["IAMEX"] = false;
            }
        }

        private string iBANCOMER;
        public string IBANCOMER
        {
            get
            {
                return this.iBANCOMER;
            }
            set
            {
                this.iBANCOMER = value;
                this.isnull["IBANCOMER"] = false;
            }
        }

        private string iBITCAMPANAS;
        public string IBITCAMPANAS
        {
            get
            {
                return this.iBITCAMPANAS;
            }
            set
            {
                this.iBITCAMPANAS = value;
                this.isnull["IBITCAMPANAS"] = false;
            }
        }

        private string iCAMPANAAUTORIZACION;
        public string ICAMPANAAUTORIZACION
        {
            get
            {
                return this.iCAMPANAAUTORIZACION;
            }
            set
            {
                this.iCAMPANAAUTORIZACION = value;
                this.isnull["ICAMPANAAUTORIZACION"] = false;
            }
        }

        private string iCAMPANAREFERENCIA;
        public string ICAMPANAREFERENCIA
        {
            get
            {
                return this.iCAMPANAREFERENCIA;
            }
            set
            {
                this.iCAMPANAREFERENCIA = value;
                this.isnull["ICAMPANAREFERENCIA"] = false;
            }
        }

        private long iCAMPANAREFERENCIANUM;
        public long ICAMPANAREFERENCIANUM
        {
            get
            {
                return this.iCAMPANAREFERENCIANUM;
            }
            set
            {
                this.iCAMPANAREFERENCIANUM = value;
                this.isnull["ICAMPANAREFERENCIANUM"] = false;
            }
        }

        private string iCARDREQUEST;
        public string ICARDREQUEST
        {
            get
            {
                return this.iCARDREQUEST;
            }
            set
            {
                this.iCARDREQUEST = value;
                this.isnull["ICARDREQUEST"] = false;
            }
        }

        private int iCARDTIPO;
        public int ICARDTIPO
        {
            get
            {
                return this.iCARDTIPO;
            }
            set
            {
                this.iCARDTIPO = value;
                this.isnull["ICARDTIPO"] = false;
            }
        }

        private string iPROMOCIONES;
        public string IPROMOCIONES
        {
            get
            {
                return this.iPROMOCIONES;
            }
            set
            {
                this.iPROMOCIONES = value;
                this.isnull["IPROMOCIONES"] = false;
            }
        }

        private string iCLIENTE_CMP_COMERCIO;
        public string ICLIENTE_CMP_COMERCIO
        {
            get
            {
                return this.iCLIENTE_CMP_COMERCIO;
            }
            set
            {
                this.iCLIENTE_CMP_COMERCIO = value;
                this.isnull["ICLIENTE_CMP_COMERCIO"] = false;
            }
        }

        private string iCLIENTE_TDC_STOCK;
        public string ICLIENTE_TDC_STOCK
        {
            get
            {
                return this.iCLIENTE_TDC_STOCK;
            }
            set
            {
                this.iCLIENTE_TDC_STOCK = value;
                this.isnull["ICLIENTE_TDC_STOCK"] = false;
            }
        }

        private long iCLSREQUESTID;
        public long ICLSREQUESTID
        {
            get
            {
                return this.iCLSREQUESTID;
            }
            set
            {
                this.iCLSREQUESTID = value;
                this.isnull["ICLSREQUESTID"] = false;
            }
        }

        private long iCLSRESPONSEID;
        public long ICLSRESPONSEID
        {
            get
            {
                return this.iCLSRESPONSEID;
            }
            set
            {
                this.iCLSRESPONSEID = value;
                this.isnull["ICLSRESPONSEID"] = false;
            }
        }

        private string iCODIGO_BENEFICIO1;
        public string ICODIGO_BENEFICIO1
        {
            get
            {
                return this.iCODIGO_BENEFICIO1;
            }
            set
            {
                this.iCODIGO_BENEFICIO1 = value;
                this.isnull["ICODIGO_BENEFICIO1"] = false;
            }
        }

        private string iCODIGO_BENEFICIO2;
        public string ICODIGO_BENEFICIO2
        {
            get
            {
                return this.iCODIGO_BENEFICIO2;
            }
            set
            {
                this.iCODIGO_BENEFICIO2 = value;
                this.isnull["ICODIGO_BENEFICIO2"] = false;
            }
        }

        private string iCODIGO_BENEFICIO3;
        public string ICODIGO_BENEFICIO3
        {
            get
            {
                return this.iCODIGO_BENEFICIO3;
            }
            set
            {
                this.iCODIGO_BENEFICIO3 = value;
                this.isnull["ICODIGO_BENEFICIO3"] = false;
            }
        }

        private string iCODIGO_BENEFICIO4;
        public string ICODIGO_BENEFICIO4
        {
            get
            {
                return this.iCODIGO_BENEFICIO4;
            }
            set
            {
                this.iCODIGO_BENEFICIO4 = value;
                this.isnull["ICODIGO_BENEFICIO4"] = false;
            }
        }

        private string iCODIGO_BENEFICIO5;
        public string ICODIGO_BENEFICIO5
        {
            get
            {
                return this.iCODIGO_BENEFICIO5;
            }
            set
            {
                this.iCODIGO_BENEFICIO5 = value;
                this.isnull["ICODIGO_BENEFICIO5"] = false;
            }
        }

        private string iCODIGO_BENEFICIO6;
        public string ICODIGO_BENEFICIO6
        {
            get
            {
                return this.iCODIGO_BENEFICIO6;
            }
            set
            {
                this.iCODIGO_BENEFICIO6 = value;
                this.isnull["ICODIGO_BENEFICIO6"] = false;
            }
        }

        private string iCODIGO_BENEFICIO7;
        public string ICODIGO_BENEFICIO7
        {
            get
            {
                return this.iCODIGO_BENEFICIO7;
            }
            set
            {
                this.iCODIGO_BENEFICIO7 = value;
                this.isnull["ICODIGO_BENEFICIO7"] = false;
            }
        }

        private string iCOMERCIO_CMP_COMERCIO;
        public string ICOMERCIO_CMP_COMERCIO
        {
            get
            {
                return this.iCOMERCIO_CMP_COMERCIO;
            }
            set
            {
                this.iCOMERCIO_CMP_COMERCIO = value;
                this.isnull["ICOMERCIO_CMP_COMERCIO"] = false;
            }
        }

        private string iCOMERCIO_TDC_STOCK;
        public string ICOMERCIO_TDC_STOCK
        {
            get
            {
                return this.iCOMERCIO_TDC_STOCK;
            }
            set
            {
                this.iCOMERCIO_TDC_STOCK = value;
                this.isnull["ICOMERCIO_TDC_STOCK"] = false;
            }
        }

        private string iCOMISION1;
        public string ICOMISION1
        {
            get
            {
                return this.iCOMISION1;
            }
            set
            {
                this.iCOMISION1 = value;
                this.isnull["ICOMISION1"] = false;
            }
        }

        private string iCOMISION2;
        public string ICOMISION2
        {
            get
            {
                return this.iCOMISION2;
            }
            set
            {
                this.iCOMISION2 = value;
                this.isnull["ICOMISION2"] = false;
            }
        }

        private string iCOMISION3;
        public string ICOMISION3
        {
            get
            {
                return this.iCOMISION3;
            }
            set
            {
                this.iCOMISION3 = value;
                this.isnull["ICOMISION3"] = false;
            }
        }

        private string iCOMISION4;
        public string ICOMISION4
        {
            get
            {
                return this.iCOMISION4;
            }
            set
            {
                this.iCOMISION4 = value;
                this.isnull["ICOMISION4"] = false;
            }
        }

        private string iCOMISION5;
        public string ICOMISION5
        {
            get
            {
                return this.iCOMISION5;
            }
            set
            {
                this.iCOMISION5 = value;
                this.isnull["ICOMISION5"] = false;
            }
        }

        private string iCOMISION6;
        public string ICOMISION6
        {
            get
            {
                return this.iCOMISION6;
            }
            set
            {
                this.iCOMISION6 = value;
                this.isnull["ICOMISION6"] = false;
            }
        }

        private string iCOMISION7;
        public string ICOMISION7
        {
            get
            {
                return this.iCOMISION7;
            }
            set
            {
                this.iCOMISION7 = value;
                this.isnull["ICOMISION7"] = false;
            }
        }

        private string iCREDITODEBITO;
        public string ICREDITODEBITO
        {
            get
            {
                return this.iCREDITODEBITO;
            }
            set
            {
                this.iCREDITODEBITO = value;
                this.isnull["ICREDITODEBITO"] = false;
            }
        }

        private string iCRIPTOGRAMA;
        public string ICRIPTOGRAMA
        {
            get
            {
                return this.iCRIPTOGRAMA;
            }
            set
            {
                this.iCRIPTOGRAMA = value;
                this.isnull["ICRIPTOGRAMA"] = false;
            }
        }

        private string iECOUPNUMBER;
        public string IECOUPNUMBER
        {
            get
            {
                return this.iECOUPNUMBER;
            }
            set
            {
                this.iECOUPNUMBER = value;
                this.isnull["IECOUPNUMBER"] = false;
            }
        }

        private string iFACTOREXP;
        public string IFACTOREXP
        {
            get
            {
                return this.iFACTOREXP;
            }
            set
            {
                this.iFACTOREXP = value;
                this.isnull["IFACTOREXP"] = false;
            }
        }

        private string iFIRMAAUTOGRAFA;
        public string IFIRMAAUTOGRAFA
        {
            get
            {
                return this.iFIRMAAUTOGRAFA;
            }
            set
            {
                this.iFIRMAAUTOGRAFA = value;
                this.isnull["IFIRMAAUTOGRAFA"] = false;
            }
        }

        private string iFIRMAELECTRONICA;
        public string IFIRMAELECTRONICA
        {
            get
            {
                return this.iFIRMAELECTRONICA;
            }
            set
            {
                this.iFIRMAELECTRONICA = value;
                this.isnull["IFIRMAELECTRONICA"] = false;
            }
        }

        private string iFIRMAQPS;
        public string IFIRMAQPS
        {
            get
            {
                return this.iFIRMAQPS;
            }
            set
            {
                this.iFIRMAQPS = value;
                this.isnull["IFIRMAQPS"] = false;
            }
        }

        private string iGUIA_CIE;
        public string IGUIA_CIE
        {
            get
            {
                return this.iGUIA_CIE;
            }
            set
            {
                this.iGUIA_CIE = value;
                this.isnull["IGUIA_CIE"] = false;
            }
        }

        private string iIDTOKEN12;
        public string IIDTOKEN12
        {
            get
            {
                return this.iIDTOKEN12;
            }
            set
            {
                this.iIDTOKEN12 = value;
                this.isnull["IIDTOKEN12"] = false;
            }
        }

        private string iIDTOKEN13;
        public string IIDTOKEN13
        {
            get
            {
                return this.iIDTOKEN13;
            }
            set
            {
                this.iIDTOKEN13 = value;
                this.isnull["IIDTOKEN13"] = false;
            }
        }

        private string iIDTOKEN16;
        public string IIDTOKEN16
        {
            get
            {
                return this.iIDTOKEN16;
            }
            set
            {
                this.iIDTOKEN16 = value;
                this.isnull["IIDTOKEN16"] = false;
            }
        }

        private string iIDTOKENR7;
        public string IIDTOKENR7
        {
            get
            {
                return this.iIDTOKENR7;
            }
            set
            {
                this.iIDTOKENR7 = value;
                this.isnull["IIDTOKENR7"] = false;
            }
        }

        private string iIDTOKENR8;
        public string IIDTOKENR8
        {
            get
            {
                return this.iIDTOKENR8;
            }
            set
            {
                this.iIDTOKENR8 = value;
                this.isnull["IIDTOKENR8"] = false;
            }
        }

        private string iIMPORTE_BENEFICIO;
        public string IIMPORTE_BENEFICIO
        {
            get
            {
                return this.iIMPORTE_BENEFICIO;
            }
            set
            {
                this.iIMPORTE_BENEFICIO = value;
                this.isnull["IIMPORTE_BENEFICIO"] = false;
            }
        }

        private string iIMPORTE_UDIS;
        public string IIMPORTE_UDIS
        {
            get
            {
                return this.iIMPORTE_UDIS;
            }
            set
            {
                this.iIMPORTE_UDIS = value;
                this.isnull["IIMPORTE_UDIS"] = false;
            }
        }

        private string iINDICADOR_CAMBIO_PLAZO;
        public string IINDICADOR_CAMBIO_PLAZO
        {
            get
            {
                return this.iINDICADOR_CAMBIO_PLAZO;
            }
            set
            {
                this.iINDICADOR_CAMBIO_PLAZO = value;
                this.isnull["IINDICADOR_CAMBIO_PLAZO"] = false;
            }
        }

        private string iINDICADOR_DE_AVISO;
        public string IINDICADOR_DE_AVISO
        {
            get
            {
                return this.iINDICADOR_DE_AVISO;
            }
            set
            {
                this.iINDICADOR_DE_AVISO = value;
                this.isnull["IINDICADOR_DE_AVISO"] = false;
            }
        }

        private string iINDICAODR_DE_BENEFICIO;
        public string IINDICAODR_DE_BENEFICIO
        {
            get
            {
                return this.iINDICAODR_DE_BENEFICIO;
            }
            set
            {
                this.iINDICAODR_DE_BENEFICIO = value;
                this.isnull["IINDICAODR_DE_BENEFICIO"] = false;
            }
        }

        private string iISFOLIO;
        public string IISFOLIO
        {
            get
            {
                return this.iISFOLIO;
            }
            set
            {
                this.iISFOLIO = value;
                this.isnull["IISFOLIO"] = false;
            }
        }

        private string iISOFFLINE;
        public string IISOFFLINE
        {
            get
            {
                return this.iISOFFLINE;
            }
            set
            {
                this.iISOFFLINE = value;
                this.isnull["IISOFFLINE"] = false;
            }
        }

        private string iLEYENDA;
        public string ILEYENDA
        {
            get
            {
                return this.iLEYENDA;
            }
            set
            {
                this.iLEYENDA = value;
                this.isnull["ILEYENDA"] = false;
            }
        }

        private string iMACADDALTERNATIVA;
        public string IMACADDALTERNATIVA
        {
            get
            {
                return this.iMACADDALTERNATIVA;
            }
            set
            {
                this.iMACADDALTERNATIVA = value;
                this.isnull["IMACADDALTERNATIVA"] = false;
            }
        }

        private string iMENSAJE_BASE_CHEQUE;
        public string IMENSAJE_BASE_CHEQUE
        {
            get
            {
                return this.iMENSAJE_BASE_CHEQUE;
            }
            set
            {
                this.iMENSAJE_BASE_CHEQUE = value;
                this.isnull["IMENSAJE_BASE_CHEQUE"] = false;
            }
        }

        private string iMENSAJE_BASE_CONTINUOS;
        public string IMENSAJE_BASE_CONTINUOS
        {
            get
            {
                return this.iMENSAJE_BASE_CONTINUOS;
            }
            set
            {
                this.iMENSAJE_BASE_CONTINUOS = value;
                this.isnull["IMENSAJE_BASE_CONTINUOS"] = false;
            }
        }

        private string iMENSAJE_CLIENTE;
        public string IMENSAJE_CLIENTE
        {
            get
            {
                return this.iMENSAJE_CLIENTE;
            }
            set
            {
                this.iMENSAJE_CLIENTE = value;
                this.isnull["IMENSAJE_CLIENTE"] = false;
            }
        }

        private string iMENSAJE_CLIENTE_EMISRO;
        public string IMENSAJE_CLIENTE_EMISRO
        {
            get
            {
                return this.iMENSAJE_CLIENTE_EMISRO;
            }
            set
            {
                this.iMENSAJE_CLIENTE_EMISRO = value;
                this.isnull["IMENSAJE_CLIENTE_EMISRO"] = false;
            }
        }

        private string iMENSAJE_COMERCIO;
        public string IMENSAJE_COMERCIO
        {
            get
            {
                return this.iMENSAJE_COMERCIO;
            }
            set
            {
                this.iMENSAJE_COMERCIO = value;
                this.isnull["IMENSAJE_COMERCIO"] = false;
            }
        }

        private string iMODOINGRESO;
        public string IMODOINGRESO
        {
            get
            {
                return this.iMODOINGRESO;
            }
            set
            {
                this.iMODOINGRESO = value;
                this.isnull["IMODOINGRESO"] = false;
            }
        }

        private string iMONTO_BENEFICIO_MULTIPLE1;
        public string IMONTO_BENEFICIO_MULTIPLE1
        {
            get
            {
                return this.iMONTO_BENEFICIO_MULTIPLE1;
            }
            set
            {
                this.iMONTO_BENEFICIO_MULTIPLE1 = value;
                this.isnull["IMONTO_BENEFICIO_MULTIPLE1"] = false;
            }
        }

        private string iMONTO_BENEFICIO_SIMPLE1;
        public string IMONTO_BENEFICIO_SIMPLE1
        {
            get
            {
                return this.iMONTO_BENEFICIO_SIMPLE1;
            }
            set
            {
                this.iMONTO_BENEFICIO_SIMPLE1 = value;
                this.isnull["IMONTO_BENEFICIO_SIMPLE1"] = false;
            }
        }

        private string iMONTO_CHEQUE_ACTUAL;
        public string IMONTO_CHEQUE_ACTUAL
        {
            get
            {
                return this.iMONTO_CHEQUE_ACTUAL;
            }
            set
            {
                this.iMONTO_CHEQUE_ACTUAL = value;
                this.isnull["IMONTO_CHEQUE_ACTUAL"] = false;
            }
        }

        private string iMONTO_CHEQUE_ANTERIOR;
        public string IMONTO_CHEQUE_ANTERIOR
        {
            get
            {
                return this.iMONTO_CHEQUE_ANTERIOR;
            }
            set
            {
                this.iMONTO_CHEQUE_ANTERIOR = value;
                this.isnull["IMONTO_CHEQUE_ANTERIOR"] = false;
            }
        }

        private string iMONTO_CHEQUE_REDIMIDOS;
        public string IMONTO_CHEQUE_REDIMIDOS
        {
            get
            {
                return this.iMONTO_CHEQUE_REDIMIDOS;
            }
            set
            {
                this.iMONTO_CHEQUE_REDIMIDOS = value;
                this.isnull["IMONTO_CHEQUE_REDIMIDOS"] = false;
            }
        }

        private string iMONTO_CONTINUOS_ACTUAL;
        public string IMONTO_CONTINUOS_ACTUAL
        {
            get
            {
                return this.iMONTO_CONTINUOS_ACTUAL;
            }
            set
            {
                this.iMONTO_CONTINUOS_ACTUAL = value;
                this.isnull["IMONTO_CONTINUOS_ACTUAL"] = false;
            }
        }

        private string iMONTO_CONTINUOS_ANTERIOR;
        public string IMONTO_CONTINUOS_ANTERIOR
        {
            get
            {
                return this.iMONTO_CONTINUOS_ANTERIOR;
            }
            set
            {
                this.iMONTO_CONTINUOS_ANTERIOR = value;
                this.isnull["IMONTO_CONTINUOS_ANTERIOR"] = false;
            }
        }

        private string iMONTO_CONTINUOS_REDIMIDOS;
        public string IMONTO_CONTINUOS_REDIMIDOS
        {
            get
            {
                return this.iMONTO_CONTINUOS_REDIMIDOS;
            }
            set
            {
                this.iMONTO_CONTINUOS_REDIMIDOS = value;
                this.isnull["IMONTO_CONTINUOS_REDIMIDOS"] = false;
            }
        }

        private string iMONTO_MULTIPLE2;
        public string IMONTO_MULTIPLE2
        {
            get
            {
                return this.iMONTO_MULTIPLE2;
            }
            set
            {
                this.iMONTO_MULTIPLE2 = value;
                this.isnull["IMONTO_MULTIPLE2"] = false;
            }
        }

        private string iMONTO_MULTIPLE3;
        public string IMONTO_MULTIPLE3
        {
            get
            {
                return this.iMONTO_MULTIPLE3;
            }
            set
            {
                this.iMONTO_MULTIPLE3 = value;
                this.isnull["IMONTO_MULTIPLE3"] = false;
            }
        }

        private string iMONTO_MULTIPLE4;
        public string IMONTO_MULTIPLE4
        {
            get
            {
                return this.iMONTO_MULTIPLE4;
            }
            set
            {
                this.iMONTO_MULTIPLE4 = value;
                this.isnull["IMONTO_MULTIPLE4"] = false;
            }
        }

        private string iMONTO_MULTIPLE5;
        public string IMONTO_MULTIPLE5
        {
            get
            {
                return this.iMONTO_MULTIPLE5;
            }
            set
            {
                this.iMONTO_MULTIPLE5 = value;
                this.isnull["IMONTO_MULTIPLE5"] = false;
            }
        }

        private string iMONTO_MULTIPLE6;
        public string IMONTO_MULTIPLE6
        {
            get
            {
                return this.iMONTO_MULTIPLE6;
            }
            set
            {
                this.iMONTO_MULTIPLE6 = value;
                this.isnull["IMONTO_MULTIPLE6"] = false;
            }
        }

        private string iMONTO_MULTIPLE7;
        public string IMONTO_MULTIPLE7
        {
            get
            {
                return this.iMONTO_MULTIPLE7;
            }
            set
            {
                this.iMONTO_MULTIPLE7 = value;
                this.isnull["IMONTO_MULTIPLE7"] = false;
            }
        }

        private string iMONTO_SIMPLE2;
        public string IMONTO_SIMPLE2
        {
            get
            {
                return this.iMONTO_SIMPLE2;
            }
            set
            {
                this.iMONTO_SIMPLE2 = value;
                this.isnull["IMONTO_SIMPLE2"] = false;
            }
        }

        private string iMONTO_SIMPLE3;
        public string IMONTO_SIMPLE3
        {
            get
            {
                return this.iMONTO_SIMPLE3;
            }
            set
            {
                this.iMONTO_SIMPLE3 = value;
                this.isnull["IMONTO_SIMPLE3"] = false;
            }
        }

        private string iMONTO_SIMPLE4;
        public string IMONTO_SIMPLE4
        {
            get
            {
                return this.iMONTO_SIMPLE4;
            }
            set
            {
                this.iMONTO_SIMPLE4 = value;
                this.isnull["IMONTO_SIMPLE4"] = false;
            }
        }

        private string iMONTO_SIMPLE5;
        public string IMONTO_SIMPLE5
        {
            get
            {
                return this.iMONTO_SIMPLE5;
            }
            set
            {
                this.iMONTO_SIMPLE5 = value;
                this.isnull["IMONTO_SIMPLE5"] = false;
            }
        }

        private string iMONTO_SIMPLE6;
        public string IMONTO_SIMPLE6
        {
            get
            {
                return this.iMONTO_SIMPLE6;
            }
            set
            {
                this.iMONTO_SIMPLE6 = value;
                this.isnull["IMONTO_SIMPLE6"] = false;
            }
        }

        private string iMONTO_SIMPLE7;
        public string IMONTO_SIMPLE7
        {
            get
            {
                return this.iMONTO_SIMPLE7;
            }
            set
            {
                this.iMONTO_SIMPLE7 = value;
                this.isnull["IMONTO_SIMPLE7"] = false;
            }
        }

        private string iNOAUTORIZACION;
        public string INOAUTORIZACION
        {
            get
            {
                return this.iNOAUTORIZACION;
            }
            set
            {
                this.iNOAUTORIZACION = value;
                this.isnull["INOAUTORIZACION"] = false;
            }
        }

        private string iNOMBREAPLICACION;
        public string INOMBREAPLICACION
        {
            get
            {
                return this.iNOMBREAPLICACION;
            }
            set
            {
                this.iNOMBREAPLICACION = value;
                this.isnull["INOMBREAPLICACION"] = false;
            }
        }

        private string iNOMBRECLIENTE;
        public string INOMBRECLIENTE
        {
            get
            {
                return this.iNOMBRECLIENTE;
            }
            set
            {
                this.iNOMBRECLIENTE = value;
                this.isnull["INOMBRECLIENTE"] = false;
            }
        }

        private string iNUMERO_DE_BENEFICIOS;
        public string INUMERO_DE_BENEFICIOS
        {
            get
            {
                return this.iNUMERO_DE_BENEFICIOS;
            }
            set
            {
                this.iNUMERO_DE_BENEFICIOS = value;
                this.isnull["INUMERO_DE_BENEFICIOS"] = false;
            }
        }

        private string iNUMEROTARJETA;
        public string INUMEROTARJETA
        {
            get
            {
                return this.iNUMEROTARJETA;
            }
            set
            {
                this.iNUMEROTARJETA = value;
                this.isnull["INUMEROTARJETA"] = false;
            }
        }

        private string iNUMTARJETAII;
        public string INUMTARJETAII
        {
            get
            {
                return this.iNUMTARJETAII;
            }
            set
            {
                this.iNUMTARJETAII = value;
                this.isnull["INUMTARJETAII"] = false;
            }
        }

        private long iPAGOSMULTIPAGOSID;
        public long IPAGOSMULTIPAGOSID
        {
            get
            {
                return this.iPAGOSMULTIPAGOSID;
            }
            set
            {
                this.iPAGOSMULTIPAGOSID = value;
                this.isnull["IPAGOSMULTIPAGOSID"] = false;
            }
        }

        private string iPESOSREDIMIDOS;
        public string IPESOSREDIMIDOS
        {
            get
            {
                return this.iPESOSREDIMIDOS;
            }
            set
            {
                this.iPESOSREDIMIDOS = value;
                this.isnull["IPESOSREDIMIDOS"] = false;
            }
        }

        private string iPESOSSALDOANTERIOR;
        public string IPESOSSALDOANTERIOR
        {
            get
            {
                return this.iPESOSSALDOANTERIOR;
            }
            set
            {
                this.iPESOSSALDOANTERIOR = value;
                this.isnull["IPESOSSALDOANTERIOR"] = false;
            }
        }

        private string iPESOSSALDODISPONIBLE;
        public string IPESOSSALDODISPONIBLE
        {
            get
            {
                return this.iPESOSSALDODISPONIBLE;
            }
            set
            {
                this.iPESOSSALDODISPONIBLE = value;
                this.isnull["IPESOSSALDODISPONIBLE"] = false;
            }
        }

        private string iPESOSSALDODISPONINLEEXP;
        public string IPESOSSALDODISPONINLEEXP
        {
            get
            {
                return this.iPESOSSALDODISPONINLEEXP;
            }
            set
            {
                this.iPESOSSALDODISPONINLEEXP = value;
                this.isnull["IPESOSSALDODISPONINLEEXP"] = false;
            }
        }

        private string iPESOSSALDOREDIMIDOSEXP;
        public string IPESOSSALDOREDIMIDOSEXP
        {
            get
            {
                return this.iPESOSSALDOREDIMIDOSEXP;
            }
            set
            {
                this.iPESOSSALDOREDIMIDOSEXP = value;
                this.isnull["IPESOSSALDOREDIMIDOSEXP"] = false;
            }
        }

        private string iPINPAD_USO;
        public string IPINPAD_USO
        {
            get
            {
                return this.iPINPAD_USO;
            }
            set
            {
                this.iPINPAD_USO = value;
                this.isnull["IPINPAD_USO"] = false;
            }
        }

        private string iPOOLADJUSTTYPE;
        public string IPOOLADJUSTTYPE
        {
            get
            {
                return this.iPOOLADJUSTTYPE;
            }
            set
            {
                this.iPOOLADJUSTTYPE = value;
                this.isnull["IPOOLADJUSTTYPE"] = false;
            }
        }

        private string iPOOLID;
        public string IPOOLID
        {
            get
            {
                return this.iPOOLID;
            }
            set
            {
                this.iPOOLID = value;
                this.isnull["IPOOLID"] = false;
            }
        }

        private string iPOOLNUMBER;
        public string IPOOLNUMBER
        {
            get
            {
                return this.iPOOLNUMBER;
            }
            set
            {
                this.iPOOLNUMBER = value;
                this.isnull["IPOOLNUMBER"] = false;
            }
        }

        private string iPOOLUNITLABEL;
        public string IPOOLUNITLABEL
        {
            get
            {
                return this.iPOOLUNITLABEL;
            }
            set
            {
                this.iPOOLUNITLABEL = value;
                this.isnull["IPOOLUNITLABEL"] = false;
            }
        }

        private long iPUNTOSID;
        public long IPUNTOSID
        {
            get
            {
                return this.iPUNTOSID;
            }
            set
            {
                this.iPUNTOSID = value;
                this.isnull["IPUNTOSID"] = false;
            }
        }

        private string iPUNTOSREDIMIDOS;
        public string IPUNTOSREDIMIDOS
        {
            get
            {
                return this.iPUNTOSREDIMIDOS;
            }
            set
            {
                this.iPUNTOSREDIMIDOS = value;
                this.isnull["IPUNTOSREDIMIDOS"] = false;
            }
        }

        private string iPUNTOSSALDOANTERIOR;
        public string IPUNTOSSALDOANTERIOR
        {
            get
            {
                return this.iPUNTOSSALDOANTERIOR;
            }
            set
            {
                this.iPUNTOSSALDOANTERIOR = value;
                this.isnull["IPUNTOSSALDOANTERIOR"] = false;
            }
        }

        private string iPUNTOSSALDODISPONIBLE;
        public string IPUNTOSSALDODISPONIBLE
        {
            get
            {
                return this.iPUNTOSSALDODISPONIBLE;
            }
            set
            {
                this.iPUNTOSSALDODISPONIBLE = value;
                this.isnull["IPUNTOSSALDODISPONIBLE"] = false;
            }
        }

        private string iPUNTOSSALDODISPONIBLEEXP;
        public string IPUNTOSSALDODISPONIBLEEXP
        {
            get
            {
                return this.iPUNTOSSALDODISPONIBLEEXP;
            }
            set
            {
                this.iPUNTOSSALDODISPONIBLEEXP = value;
                this.isnull["IPUNTOSSALDODISPONIBLEEXP"] = false;
            }
        }

        private string iPUNTOSSALDOREDIMIDOSEXP;
        public string IPUNTOSSALDOREDIMIDOSEXP
        {
            get
            {
                return this.iPUNTOSSALDOREDIMIDOSEXP;
            }
            set
            {
                this.iPUNTOSSALDOREDIMIDOSEXP = value;
                this.isnull["IPUNTOSSALDOREDIMIDOSEXP"] = false;
            }
        }

        private string iR8_CODIGO_LEYENDA;
        public string IR8_CODIGO_LEYENDA
        {
            get
            {
                return this.iR8_CODIGO_LEYENDA;
            }
            set
            {
                this.iR8_CODIGO_LEYENDA = value;
                this.isnull["IR8_CODIGO_LEYENDA"] = false;
            }
        }

        private string iR8_LEYENDA;
        public string IR8_LEYENDA
        {
            get
            {
                return this.iR8_LEYENDA;
            }
            set
            {
                this.iR8_LEYENDA = value;
                this.isnull["IR8_LEYENDA"] = false;
            }
        }

        private string iRAZON_SOCIAL;
        public string IRAZON_SOCIAL
        {
            get
            {
                return this.iRAZON_SOCIAL;
            }
            set
            {
                this.iRAZON_SOCIAL = value;
                this.isnull["IRAZON_SOCIAL"] = false;
            }
        }

        private string iREFERENCIA_RESPUESTA;
        public string IREFERENCIA_RESPUESTA
        {
            get
            {
                return this.iREFERENCIA_RESPUESTA;
            }
            set
            {
                this.iREFERENCIA_RESPUESTA = value;
                this.isnull["IREFERENCIA_RESPUESTA"] = false;
            }
        }

        private string iREFERENCIAAFIN;
        public string IREFERENCIAAFIN
        {
            get
            {
                return this.iREFERENCIAAFIN;
            }
            set
            {
                this.iREFERENCIAAFIN = value;
                this.isnull["IREFERENCIAAFIN"] = false;
            }
        }

        private string iREQUEST;
        public string IREQUEST
        {
            get
            {
                return this.iREQUEST;
            }
            set
            {
                this.iREQUEST = value;
                this.isnull["IREQUEST"] = false;
            }
        }

        private int iRESPDLL;
        public int IRESPDLL
        {
            get
            {
                return this.iRESPDLL;
            }
            set
            {
                this.iRESPDLL = value;
                this.isnull["IRESPDLL"] = false;
            }
        }

        private string iRESPONSE;
        public string IRESPONSE
        {
            get
            {
                return this.iRESPONSE;
            }
            set
            {
                this.iRESPONSE = value;
                this.isnull["IRESPONSE"] = false;
            }
        }

        private string iSEGMENTNUMBER;
        public string ISEGMENTNUMBER
        {
            get
            {
                return this.iSEGMENTNUMBER;
            }
            set
            {
                this.iSEGMENTNUMBER = value;
                this.isnull["ISEGMENTNUMBER"] = false;
            }
        }

        private string iTBINES;
        public string ITBINES
        {
            get
            {
                return this.iTBINES;
            }
            set
            {
                this.iTBINES = value;
                this.isnull["ITBINES"] = false;
            }
        }

        private string iTIPO_BENEFICIO1;
        public string ITIPO_BENEFICIO1
        {
            get
            {
                return this.iTIPO_BENEFICIO1;
            }
            set
            {
                this.iTIPO_BENEFICIO1 = value;
                this.isnull["ITIPO_BENEFICIO1"] = false;
            }
        }

        private string iTIPO_BENEFICIO2;
        public string ITIPO_BENEFICIO2
        {
            get
            {
                return this.iTIPO_BENEFICIO2;
            }
            set
            {
                this.iTIPO_BENEFICIO2 = value;
                this.isnull["ITIPO_BENEFICIO2"] = false;
            }
        }

        private string iTIPO_BENEFICIO3;
        public string ITIPO_BENEFICIO3
        {
            get
            {
                return this.iTIPO_BENEFICIO3;
            }
            set
            {
                this.iTIPO_BENEFICIO3 = value;
                this.isnull["ITIPO_BENEFICIO3"] = false;
            }
        }

        private string iTIPO_BENEFICIO4;
        public string ITIPO_BENEFICIO4
        {
            get
            {
                return this.iTIPO_BENEFICIO4;
            }
            set
            {
                this.iTIPO_BENEFICIO4 = value;
                this.isnull["ITIPO_BENEFICIO4"] = false;
            }
        }

        private string iTIPO_BENEFICIO5;
        public string ITIPO_BENEFICIO5
        {
            get
            {
                return this.iTIPO_BENEFICIO5;
            }
            set
            {
                this.iTIPO_BENEFICIO5 = value;
                this.isnull["ITIPO_BENEFICIO5"] = false;
            }
        }

        private string iTIPO_BENEFICIO6;
        public string ITIPO_BENEFICIO6
        {
            get
            {
                return this.iTIPO_BENEFICIO6;
            }
            set
            {
                this.iTIPO_BENEFICIO6 = value;
                this.isnull["ITIPO_BENEFICIO6"] = false;
            }
        }

        private string iTIPO_BENEFICIO7;
        public string ITIPO_BENEFICIO7
        {
            get
            {
                return this.iTIPO_BENEFICIO7;
            }
            set
            {
                this.iTIPO_BENEFICIO7 = value;
                this.isnull["ITIPO_BENEFICIO7"] = false;
            }
        }

        private string iTIPO_RESPUESTA1;
        public string ITIPO_RESPUESTA1
        {
            get
            {
                return this.iTIPO_RESPUESTA1;
            }
            set
            {
                this.iTIPO_RESPUESTA1 = value;
                this.isnull["ITIPO_RESPUESTA1"] = false;
            }
        }

        private string iTIPO_RESPUESTA2;
        public string ITIPO_RESPUESTA2
        {
            get
            {
                return this.iTIPO_RESPUESTA2;
            }
            set
            {
                this.iTIPO_RESPUESTA2 = value;
                this.isnull["ITIPO_RESPUESTA2"] = false;
            }
        }

        private string iTIPO_RESPUESTA3;
        public string ITIPO_RESPUESTA3
        {
            get
            {
                return this.iTIPO_RESPUESTA3;
            }
            set
            {
                this.iTIPO_RESPUESTA3 = value;
                this.isnull["ITIPO_RESPUESTA3"] = false;
            }
        }

        private string iTIPO_RESPUESTA4;
        public string ITIPO_RESPUESTA4
        {
            get
            {
                return this.iTIPO_RESPUESTA4;
            }
            set
            {
                this.iTIPO_RESPUESTA4 = value;
                this.isnull["ITIPO_RESPUESTA4"] = false;
            }
        }

        private string iTIPO_RESPUESTA5;
        public string ITIPO_RESPUESTA5
        {
            get
            {
                return this.iTIPO_RESPUESTA5;
            }
            set
            {
                this.iTIPO_RESPUESTA5 = value;
                this.isnull["ITIPO_RESPUESTA5"] = false;
            }
        }

        private string iTIPO_RESPUESTA6;
        public string ITIPO_RESPUESTA6
        {
            get
            {
                return this.iTIPO_RESPUESTA6;
            }
            set
            {
                this.iTIPO_RESPUESTA6 = value;
                this.isnull["ITIPO_RESPUESTA6"] = false;
            }
        }

        private string iTIPO_RESPUESTA7;
        public string ITIPO_RESPUESTA7
        {
            get
            {
                return this.iTIPO_RESPUESTA7;
            }
            set
            {
                this.iTIPO_RESPUESTA7 = value;
                this.isnull["ITIPO_RESPUESTA7"] = false;
            }
        }

        private string iTIPOPOS;
        public string ITIPOPOS
        {
            get
            {
                return this.iTIPOPOS;
            }
            set
            {
                this.iTIPOPOS = value;
                this.isnull["ITIPOPOS"] = false;
            }
        }

        private string iTNXCONPUNTOS;
        public string ITNXCONPUNTOS
        {
            get
            {
                return this.iTNXCONPUNTOS;
            }
            set
            {
                this.iTNXCONPUNTOS = value;
                this.isnull["ITNXCONPUNTOS"] = false;
            }
        }

        private string iTOPERADOR;
        public string ITOPERADOR
        {
            get
            {
                return this.iTOPERADOR;
            }
            set
            {
                this.iTOPERADOR = value;
                this.isnull["ITOPERADOR"] = false;
            }
        }

        private string iVALTIPOCARD;
        public string IVALTIPOCARD
        {
            get
            {
                return this.iVALTIPOCARD;
            }
            set
            {
                this.iVALTIPOCARD = value;
                this.isnull["IVALTIPOCARD"] = false;
            }
        }

        private string iVIGENCIAPROMOCIONESEXP;
        public string IVIGENCIAPROMOCIONESEXP
        {
            get
            {
                return this.iVIGENCIAPROMOCIONESEXP;
            }
            set
            {
                this.iVIGENCIAPROMOCIONESEXP = value;
                this.isnull["IVIGENCIAPROMOCIONESEXP"] = false;
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
                this.iDOCTOID = value;
                this.isnull["IDOCTOID"] = false;
            }
        }
        
        
        private long iDOCTOPAGOID;
        public long IDOCTOPAGOID
        {
            get
            {
                return this.iDOCTOPAGOID;
            }
            set
            {
                this.iDOCTOPAGOID = value;
                this.isnull["IDOCTOPAGOID"] = false;
            }
        }



        private string iTIPOTRANSACCION;
        public string ITIPOTRANSACCION
        {
            get
            {
                return this.iTIPOTRANSACCION;
            }
            set
            {
                this.iTIPOTRANSACCION = value;
                this.isnull["ITIPOTRANSACCION"] = false;
            }
        }


        
        private long iESTADOTRANSACCIONID;
        public long IESTADOTRANSACCIONID
        {
            get
            {
                return this.iESTADOTRANSACCIONID;
            }
            set
            {
                this.iESTADOTRANSACCIONID = value;
                this.isnull["IESTADOTRANSACCIONID"] = false;
            }
        }


        private long iREFID;
        public long IREFID
        {
            get
            {
                return this.iREFID;
            }
            set
            {
                this.iREFID = value;
                this.isnull["IREFID"] = false;
            }
        }
        


        public CBANCOMERPARAMBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("IAID", true);


            isnull.Add("IAMEX", true);


            isnull.Add("IBANCOMER", true);


            isnull.Add("IBITCAMPANAS", true);


            isnull.Add("ICAMPANAAUTORIZACION", true);


            isnull.Add("ICAMPANAREFERENCIA", true);


            isnull.Add("ICAMPANAREFERENCIANUM", true);


            isnull.Add("ICARDREQUEST", true);


            isnull.Add("ICARDTIPO", true);


            isnull.Add("IPROMOCIONES", true);


            isnull.Add("ICLIENTE_CMP_COMERCIO", true);


            isnull.Add("ICLIENTE_TDC_STOCK", true);


            isnull.Add("ICLSREQUESTID", true);


            isnull.Add("ICLSRESPONSEID", true);


            isnull.Add("ICODIGO_BENEFICIO1", true);


            isnull.Add("ICODIGO_BENEFICIO2", true);


            isnull.Add("ICODIGO_BENEFICIO3", true);


            isnull.Add("ICODIGO_BENEFICIO4", true);


            isnull.Add("ICODIGO_BENEFICIO5", true);


            isnull.Add("ICODIGO_BENEFICIO6", true);


            isnull.Add("ICODIGO_BENEFICIO7", true);


            isnull.Add("ICOMERCIO_CMP_COMERCIO", true);


            isnull.Add("ICOMERCIO_TDC_STOCK", true);


            isnull.Add("ICOMISION1", true);


            isnull.Add("ICOMISION2", true);


            isnull.Add("ICOMISION3", true);


            isnull.Add("ICOMISION4", true);


            isnull.Add("ICOMISION5", true);


            isnull.Add("ICOMISION6", true);


            isnull.Add("ICOMISION7", true);


            isnull.Add("ICREDITODEBITO", true);


            isnull.Add("ICRIPTOGRAMA", true);


            isnull.Add("IECOUPNUMBER", true);


            isnull.Add("IFACTOREXP", true);


            isnull.Add("IFIRMAAUTOGRAFA", true);


            isnull.Add("IFIRMAELECTRONICA", true);


            isnull.Add("IFIRMAQPS", true);


            isnull.Add("IGUIA_CIE", true);


            isnull.Add("IIDTOKEN12", true);


            isnull.Add("IIDTOKEN13", true);


            isnull.Add("IIDTOKEN16", true);


            isnull.Add("IIDTOKENR7", true);


            isnull.Add("IIDTOKENR8", true);


            isnull.Add("IIMPORTE_BENEFICIO", true);


            isnull.Add("IIMPORTE_UDIS", true);


            isnull.Add("IINDICADOR_CAMBIO_PLAZO", true);


            isnull.Add("IINDICADOR_DE_AVISO", true);


            isnull.Add("IINDICAODR_DE_BENEFICIO", true);


            isnull.Add("IISFOLIO", true);


            isnull.Add("IISOFFLINE", true);


            isnull.Add("ILEYENDA", true);


            isnull.Add("IMACADDALTERNATIVA", true);


            isnull.Add("IMENSAJE_BASE_CHEQUE", true);


            isnull.Add("IMENSAJE_BASE_CONTINUOS", true);


            isnull.Add("IMENSAJE_CLIENTE", true);


            isnull.Add("IMENSAJE_CLIENTE_EMISRO", true);


            isnull.Add("IMENSAJE_COMERCIO", true);


            isnull.Add("IMODOINGRESO", true);


            isnull.Add("IMONTO_BENEFICIO_MULTIPLE1", true);


            isnull.Add("IMONTO_BENEFICIO_SIMPLE1", true);


            isnull.Add("IMONTO_CHEQUE_ACTUAL", true);


            isnull.Add("IMONTO_CHEQUE_ANTERIOR", true);


            isnull.Add("IMONTO_CHEQUE_REDIMIDOS", true);


            isnull.Add("IMONTO_CONTINUOS_ACTUAL", true);


            isnull.Add("IMONTO_CONTINUOS_ANTERIOR", true);


            isnull.Add("IMONTO_CONTINUOS_REDIMIDOS", true);


            isnull.Add("IMONTO_MULTIPLE2", true);


            isnull.Add("IMONTO_MULTIPLE3", true);


            isnull.Add("IMONTO_MULTIPLE4", true);


            isnull.Add("IMONTO_MULTIPLE5", true);


            isnull.Add("IMONTO_MULTIPLE6", true);


            isnull.Add("IMONTO_MULTIPLE7", true);


            isnull.Add("IMONTO_SIMPLE2", true);


            isnull.Add("IMONTO_SIMPLE3", true);


            isnull.Add("IMONTO_SIMPLE4", true);


            isnull.Add("IMONTO_SIMPLE5", true);


            isnull.Add("IMONTO_SIMPLE6", true);


            isnull.Add("IMONTO_SIMPLE7", true);


            isnull.Add("INOAUTORIZACION", true);


            isnull.Add("INOMBREAPLICACION", true);


            isnull.Add("INOMBRECLIENTE", true);


            isnull.Add("INUMERO_DE_BENEFICIOS", true);


            isnull.Add("INUMEROTARJETA", true);


            isnull.Add("INUMTARJETAII", true);


            isnull.Add("IPAGOSMULTIPAGOSID", true);


            isnull.Add("IPESOSREDIMIDOS", true);


            isnull.Add("IPESOSSALDOANTERIOR", true);


            isnull.Add("IPESOSSALDODISPONIBLE", true);


            isnull.Add("IPESOSSALDODISPONINLEEXP", true);


            isnull.Add("IPESOSSALDOREDIMIDOSEXP", true);


            isnull.Add("IPINPAD_USO", true);


            isnull.Add("IPOOLADJUSTTYPE", true);


            isnull.Add("IPOOLID", true);


            isnull.Add("IPOOLNUMBER", true);


            isnull.Add("IPOOLUNITLABEL", true);


            isnull.Add("IPUNTOSID", true);


            isnull.Add("IPUNTOSREDIMIDOS", true);


            isnull.Add("IPUNTOSSALDOANTERIOR", true);


            isnull.Add("IPUNTOSSALDODISPONIBLE", true);


            isnull.Add("IPUNTOSSALDODISPONIBLEEXP", true);


            isnull.Add("IPUNTOSSALDOREDIMIDOSEXP", true);


            isnull.Add("IR8_CODIGO_LEYENDA", true);


            isnull.Add("IR8_LEYENDA", true);


            isnull.Add("IRAZON_SOCIAL", true);


            isnull.Add("IREFERENCIA_RESPUESTA", true);


            isnull.Add("IREFERENCIAAFIN", true);


            isnull.Add("IREQUEST", true);


            isnull.Add("IRESPDLL", true);


            isnull.Add("IRESPONSE", true);


            isnull.Add("ISEGMENTNUMBER", true);


            isnull.Add("ITBINES", true);


            isnull.Add("ITIPO_BENEFICIO1", true);


            isnull.Add("ITIPO_BENEFICIO2", true);


            isnull.Add("ITIPO_BENEFICIO3", true);


            isnull.Add("ITIPO_BENEFICIO4", true);


            isnull.Add("ITIPO_BENEFICIO5", true);


            isnull.Add("ITIPO_BENEFICIO6", true);


            isnull.Add("ITIPO_BENEFICIO7", true);


            isnull.Add("ITIPO_RESPUESTA1", true);


            isnull.Add("ITIPO_RESPUESTA2", true);


            isnull.Add("ITIPO_RESPUESTA3", true);


            isnull.Add("ITIPO_RESPUESTA4", true);


            isnull.Add("ITIPO_RESPUESTA5", true);


            isnull.Add("ITIPO_RESPUESTA6", true);


            isnull.Add("ITIPO_RESPUESTA7", true);


            isnull.Add("ITIPOPOS", true);


            isnull.Add("ITNXCONPUNTOS", true);


            isnull.Add("ITOPERADOR", true);


            isnull.Add("IVALTIPOCARD", true);


            isnull.Add("IVIGENCIAPROMOCIONESEXP", true);


            isnull.Add("IDOCTOID", true);
            isnull.Add("IDOCTOPAGOID", true);
            isnull.Add("ITIPOTRANSACCION", true);
            isnull.Add("IESTADOTRANSACCIONID", true);
            isnull.Add("IREFID", true);


        }


        



    }
}
