
using Newtonsoft.Json;
using System;
using System.Collections;

namespace iPosBusinessEntity
{
    public class CCARTAPORTEMERCANCIABE
    {
        [JsonIgnore]
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

        private string iBIENESTRANSP;
        public string IBIENESTRANSP
        {
            get
            {
                return this.iBIENESTRANSP;
            }
            set
            {
                this.iBIENESTRANSP = value;
                this.isnull["IBIENESTRANSP"] = false;
            }
        }

        private string iCLAVESTCC;
        public string ICLAVESTCC
        {
            get
            {
                return this.iCLAVESTCC;
            }
            set
            {
                this.iCLAVESTCC = value;
                this.isnull["ICLAVESTCC"] = false;
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
                this.iDESCRIPCION = value;
                this.isnull["IDESCRIPCION"] = false;
            }
        }

        private string iCANTIDAD;
        public string ICANTIDAD
        {
            get
            {
                return this.iCANTIDAD;
            }
            set
            {
                this.iCANTIDAD = value;
                this.isnull["ICANTIDAD"] = false;
            }
        }

        private string iCLAVEUNIDAD;
        public string ICLAVEUNIDAD
        {
            get
            {
                return this.iCLAVEUNIDAD;
            }
            set
            {
                this.iCLAVEUNIDAD = value;
                this.isnull["ICLAVEUNIDAD"] = false;
            }
        }

        private string iUNIDAD;
        public string IUNIDAD
        {
            get
            {
                return this.iUNIDAD;
            }
            set
            {
                this.iUNIDAD = value;
                this.isnull["IUNIDAD"] = false;
            }
        }

        private string iDIMENSIONES;
        public string IDIMENSIONES
        {
            get
            {
                return this.iDIMENSIONES;
            }
            set
            {
                this.iDIMENSIONES = value;
                this.isnull["IDIMENSIONES"] = false;
            }
        }

        private string iMATERIALPELIGROSO;
        public string IMATERIALPELIGROSO
        {
            get
            {
                return this.iMATERIALPELIGROSO;
            }
            set
            {
                this.iMATERIALPELIGROSO = value;
                this.isnull["IMATERIALPELIGROSO"] = false;
            }
        }

        private string iCVEMATERIALPELIGROSO;
        public string ICVEMATERIALPELIGROSO
        {
            get
            {
                return this.iCVEMATERIALPELIGROSO;
            }
            set
            {
                this.iCVEMATERIALPELIGROSO = value;
                this.isnull["ICVEMATERIALPELIGROSO"] = false;
            }
        }

        private string iEMBALAJE;
        public string IEMBALAJE
        {
            get
            {
                return this.iEMBALAJE;
            }
            set
            {
                this.iEMBALAJE = value;
                this.isnull["IEMBALAJE"] = false;
            }
        }

        private string iDESCRIPEMBALAJE;
        public string IDESCRIPEMBALAJE
        {
            get
            {
                return this.iDESCRIPEMBALAJE;
            }
            set
            {
                this.iDESCRIPEMBALAJE = value;
                this.isnull["IDESCRIPEMBALAJE"] = false;
            }
        }

        private string iPESOENKG;
        public string IPESOENKG
        {
            get
            {
                return this.iPESOENKG;
            }
            set
            {
                this.iPESOENKG = value;
                this.isnull["IPESOENKG"] = false;
            }
        }

        private string iVALORMERCANCIA;
        public string IVALORMERCANCIA
        {
            get
            {
                return this.iVALORMERCANCIA;
            }
            set
            {
                this.iVALORMERCANCIA = value;
                this.isnull["IVALORMERCANCIA"] = false;
            }
        }

        private string iMONEDA;
        public string IMONEDA
        {
            get
            {
                return this.iMONEDA;
            }
            set
            {
                this.iMONEDA = value;
                this.isnull["IMONEDA"] = false;
            }
        }

        private string iFRACCIONARANCELARIA;
        public string IFRACCIONARANCELARIA
        {
            get
            {
                return this.iFRACCIONARANCELARIA;
            }
            set
            {
                this.iFRACCIONARANCELARIA = value;
                this.isnull["IFRACCIONARANCELARIA"] = false;
            }
        }

        private string iUUIDCOMERCIOEXT;
        public string IUUIDCOMERCIOEXT
        {
            get
            {
                return this.iUUIDCOMERCIOEXT;
            }
            set
            {
                this.iUUIDCOMERCIOEXT = value;
                this.isnull["IUUIDCOMERCIOEXT"] = false;
            }
        }

        private string iUNIDADPESOMERC;
        public string IUNIDADPESOMERC
        {
            get
            {
                return this.iUNIDADPESOMERC;
            }
            set
            {
                this.iUNIDADPESOMERC = value;
                this.isnull["IUNIDADPESOMERC"] = false;
            }
        }

        private string iPESOBRUTO;
        public string IPESOBRUTO
        {
            get
            {
                return this.iPESOBRUTO;
            }
            set
            {
                this.iPESOBRUTO = value;
                this.isnull["IPESOBRUTO"] = false;
            }
        }

        private string iPESONETO;
        public string IPESONETO
        {
            get
            {
                return this.iPESONETO;
            }
            set
            {
                this.iPESONETO = value;
                this.isnull["IPESONETO"] = false;
            }
        }

        private string iPESOTARA;
        public string IPESOTARA
        {
            get
            {
                return this.iPESOTARA;
            }
            set
            {
                this.iPESOTARA = value;
                this.isnull["IPESOTARA"] = false;
            }
        }

        private string iNUMPIEZAS;
        public string INUMPIEZAS
        {
            get
            {
                return this.iNUMPIEZAS;
            }
            set
            {
                this.iNUMPIEZAS = value;
                this.isnull["INUMPIEZAS"] = false;
            }
        }

        private string iCLAVEPRODUCTO;
        public string ICLAVEPRODUCTO
        {
            get
            {
                return this.iCLAVEPRODUCTO;
            }
            set
            {
                this.iCLAVEPRODUCTO = value;
                this.isnull["ICLAVEPRODUCTO"] = false;
            }
        }


        private string iSECTORCOFEPRIS;
        public string ISECTORCOFEPRIS
        {
            get
            {
                return this.iSECTORCOFEPRIS;
            }
            set
            {
                this.iSECTORCOFEPRIS = value;
                this.isnull["ISECTORCOFEPRIS"] = false;
            }
        }

        private string iNOMBREINGREDIENTEACTIVO;
        public string INOMBREINGREDIENTEACTIVO
        {
            get
            {
                return this.iNOMBREINGREDIENTEACTIVO;
            }
            set
            {
                this.iNOMBREINGREDIENTEACTIVO = value;
                this.isnull["INOMBREINGREDIENTEACTIVO"] = false;
            }
        }

        private string iNOMQUIMICO;
        public string INOMQUIMICO
        {
            get
            {
                return this.iNOMQUIMICO;
            }
            set
            {
                this.iNOMQUIMICO = value;
                this.isnull["INOMQUIMICO"] = false;
            }
        }

        private string iDENOMINACIONGENERICAPROD;
        public string IDENOMINACIONGENERICAPROD
        {
            get
            {
                return this.iDENOMINACIONGENERICAPROD;
            }
            set
            {
                this.iDENOMINACIONGENERICAPROD = value;
                this.isnull["IDENOMINACIONGENERICAPROD"] = false;
            }
        }

        private string iDENOMINACIONDISTINTIVAPROD;
        public string IDENOMINACIONDISTINTIVAPROD
        {
            get
            {
                return this.iDENOMINACIONDISTINTIVAPROD;
            }
            set
            {
                this.iDENOMINACIONDISTINTIVAPROD = value;
                this.isnull["IDENOMINACIONDISTINTIVAPROD"] = false;
            }
        }

        private string iFABRICANTE;
        public string IFABRICANTE
        {
            get
            {
                return this.iFABRICANTE;
            }
            set
            {
                this.iFABRICANTE = value;
                this.isnull["IFABRICANTE"] = false;
            }
        }

        private string iFECHACADUCIDAD;
        public string IFECHACADUCIDAD
        {
            get
            {
                return this.iFECHACADUCIDAD;
            }
            set
            {
                this.iFECHACADUCIDAD = value;
                this.isnull["IFECHACADUCIDAD"] = false;
            }
        }

        private string iLOTEMEDICAMENTO;
        public string ILOTEMEDICAMENTO
        {
            get
            {
                return this.iLOTEMEDICAMENTO;
            }
            set
            {
                this.iLOTEMEDICAMENTO = value;
                this.isnull["ILOTEMEDICAMENTO"] = false;
            }
        }

        private string iFORMAFARMACEUTICA;
        public string IFORMAFARMACEUTICA
        {
            get
            {
                return this.iFORMAFARMACEUTICA;
            }
            set
            {
                this.iFORMAFARMACEUTICA = value;
                this.isnull["IFORMAFARMACEUTICA"] = false;
            }
        }

        private string iCONDICIONESESPTRANSP;
        public string ICONDICIONESESPTRANSP
        {
            get
            {
                return this.iCONDICIONESESPTRANSP;
            }
            set
            {
                this.iCONDICIONESESPTRANSP = value;
                this.isnull["ICONDICIONESESPTRANSP"] = false;
            }
        }

        private string iREGISTROSANITARIOFOLIOAUTORIZACION;
        public string IREGISTROSANITARIOFOLIOAUTORIZACION
        {
            get
            {
                return this.iREGISTROSANITARIOFOLIOAUTORIZACION;
            }
            set
            {
                this.iREGISTROSANITARIOFOLIOAUTORIZACION = value;
                this.isnull["IREGISTROSANITARIOFOLIOAUTORIZACION"] = false;
            }
        }

        private string iPERMISOIMPORTACION;
        public string IPERMISOIMPORTACION
        {
            get
            {
                return this.iPERMISOIMPORTACION;
            }
            set
            {
                this.iPERMISOIMPORTACION = value;
                this.isnull["IPERMISOIMPORTACION"] = false;
            }
        }

        private string iFOLIOIMPOVUCEM;
        public string IFOLIOIMPOVUCEM
        {
            get
            {
                return this.iFOLIOIMPOVUCEM;
            }
            set
            {
                this.iFOLIOIMPOVUCEM = value;
                this.isnull["IFOLIOIMPOVUCEM"] = false;
            }
        }

        private string iNUMCAS;
        public string INUMCAS
        {
            get
            {
                return this.iNUMCAS;
            }
            set
            {
                this.iNUMCAS = value;
                this.isnull["INUMCAS"] = false;
            }
        }

        private string iRAZONSOCIALEMPIMP;
        public string IRAZONSOCIALEMPIMP
        {
            get
            {
                return this.iRAZONSOCIALEMPIMP;
            }
            set
            {
                this.iRAZONSOCIALEMPIMP = value;
                this.isnull["IRAZONSOCIALEMPIMP"] = false;
            }
        }

        private string iNUMREGSANPLAGCOFEPRIS;
        public string INUMREGSANPLAGCOFEPRIS
        {
            get
            {
                return this.iNUMREGSANPLAGCOFEPRIS;
            }
            set
            {
                this.iNUMREGSANPLAGCOFEPRIS = value;
                this.isnull["INUMREGSANPLAGCOFEPRIS"] = false;
            }
        }

        private string iDATOSFABRICANTE;
        public string IDATOSFABRICANTE
        {
            get
            {
                return this.iDATOSFABRICANTE;
            }
            set
            {
                this.iDATOSFABRICANTE = value;
                this.isnull["IDATOSFABRICANTE"] = false;
            }
        }

        private string iDATOSFORMULADOR;
        public string IDATOSFORMULADOR
        {
            get
            {
                return this.iDATOSFORMULADOR;
            }
            set
            {
                this.iDATOSFORMULADOR = value;
                this.isnull["IDATOSFORMULADOR"] = false;
            }
        }

        private string iDATOSMAQUILADOR;
        public string IDATOSMAQUILADOR
        {
            get
            {
                return this.iDATOSMAQUILADOR;
            }
            set
            {
                this.iDATOSMAQUILADOR = value;
                this.isnull["IDATOSMAQUILADOR"] = false;
            }
        }

        private string iUSOAUTORIZADO;
        public string IUSOAUTORIZADO
        {
            get
            {
                return this.iUSOAUTORIZADO;
            }
            set
            {
                this.iUSOAUTORIZADO = value;
                this.isnull["IUSOAUTORIZADO"] = false;
            }
        }

        private string iTIPOMATERIA;
        public string ITIPOMATERIA
        {
            get
            {
                return this.iTIPOMATERIA;
            }
            set
            {
                this.iTIPOMATERIA = value;
                this.isnull["ITIPOMATERIA"] = false;
            }
        }

        private string iDESCRIPCIONMATERIA;
        public string IDESCRIPCIONMATERIA
        {
            get
            {
                return this.iDESCRIPCIONMATERIA;
            }
            set
            {
                this.iDESCRIPCIONMATERIA = value;
                this.isnull["IDESCRIPCIONMATERIA"] = false;
            }
        }



        public void FillFromCartaPorteLinea(CCARTAPORTELINEABE line)
        {

            if (!(bool)line.isnull["IBIENESTRANSP"])
                this.IBIENESTRANSP = line.IBIENESTRANSP;

            if (!(bool)line.isnull["ICLAVESTCC"])
                this.ICLAVESTCC = line.ICLAVESTCC;

            if (!(bool)line.isnull["IDESCRIPCION"])
                this.IDESCRIPCION = line.IDESCRIPCION;

            if (!(bool)line.isnull["ICANTIDAD"])
                this.ICANTIDAD = line.ICANTIDAD;

            if (!(bool)line.isnull["ICLAVEUNIDAD"])
                this.ICLAVEUNIDAD = line.ICLAVEUNIDAD;

            if (!(bool)line.isnull["IUNIDAD"])
                this.IUNIDAD = line.IUNIDAD;

            if (!(bool)line.isnull["IDIMENSIONES"])
                this.IDIMENSIONES = line.IDIMENSIONES;

            if (!(bool)line.isnull["IMATERIALPELIGROSO"])
                this.IMATERIALPELIGROSO = line.IMATERIALPELIGROSO;

            if (!(bool)line.isnull["ICVEMATERIALPELIGROSO"])
                this.ICVEMATERIALPELIGROSO = line.ICVEMATERIALPELIGROSO;

            if (!(bool)line.isnull["IEMBALAJE"])
                this.IEMBALAJE = line.IEMBALAJE;

            if (!(bool)line.isnull["IDESCRIPEMBALAJE"])
                this.IDESCRIPEMBALAJE = line.IDESCRIPEMBALAJE;

            if (!(bool)line.isnull["IPESOENKG"])
                this.IPESOENKG = line.IPESOENKG;

            if (!(bool)line.isnull["IVALORMERCANCIA"])
                this.IVALORMERCANCIA = line.IVALORMERCANCIA;

            if (!(bool)line.isnull["IMONEDA"])
                this.IMONEDA = line.IMONEDA;

            if (!(bool)line.isnull["IFRACCIONARANCELARIA"])
                this.IFRACCIONARANCELARIA = line.IFRACCIONARANCELARIA;

            if (!(bool)line.isnull["IUUIDCOMERCIOEXT"])
                this.IUUIDCOMERCIOEXT = line.IUUIDCOMERCIOEXT;

            if (!(bool)line.isnull["IUNIDADPESOMERC"])
                this.IUNIDADPESOMERC = line.IUNIDADPESOMERC;

            if (!(bool)line.isnull["IPESOBRUTO"])
                this.IPESOBRUTO = line.IPESOBRUTO;

            if (!(bool)line.isnull["IPESONETO"])
                this.IPESONETO = line.IPESONETO;

            if (!(bool)line.isnull["IPESOTARA"])
                this.IPESOTARA = line.IPESOTARA;

            if (!(bool)line.isnull["INUMPIEZAS"])
                this.INUMPIEZAS = line.INUMPIEZAS;

            if (!(bool)line.isnull["ICLAVEPRODUCTO"])
                this.ICLAVEPRODUCTO = line.ICLAVEPRODUCTO;

            

        }

        public CCARTAPORTEMERCANCIABE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("IBIENESTRANSP", true);


            isnull.Add("ICLAVESTCC", true);


            isnull.Add("IDESCRIPCION", true);


            isnull.Add("ICANTIDAD", true);


            isnull.Add("ICLAVEUNIDAD", true);


            isnull.Add("IUNIDAD", true);


            isnull.Add("IDIMENSIONES", true);


            isnull.Add("IMATERIALPELIGROSO", true);


            isnull.Add("ICVEMATERIALPELIGROSO", true);


            isnull.Add("IEMBALAJE", true);


            isnull.Add("IDESCRIPEMBALAJE", true);


            isnull.Add("IPESOENKG", true);


            isnull.Add("IVALORMERCANCIA", true);


            isnull.Add("IMONEDA", true);


            isnull.Add("IFRACCIONARANCELARIA", true);


            isnull.Add("IUUIDCOMERCIOEXT", true);


            isnull.Add("IUNIDADPESOMERC", true);


            isnull.Add("IPESOBRUTO", true);


            isnull.Add("IPESONETO", true);


            isnull.Add("IPESOTARA", true);


            isnull.Add("INUMPIEZAS", true);



            isnull.Add("ICLAVEPRODUCTO", true);

            isnull.Add("ISECTORCOFEPRIS", true);
            isnull.Add("INOMBREINGREDIENTEACTIVO", true);
            isnull.Add("INOMQUIMICO", true);
            isnull.Add("IDENOMINACIONGENERICAPROD", true);
            isnull.Add("IDENOMINACIONDISTINTIVAPROD", true);
            isnull.Add("IFABRICANTE", true);
            isnull.Add("IFECHACADUCIDAD", true);
            isnull.Add("ILOTEMEDICAMENTO", true);
            isnull.Add("IFORMAFARMACEUTICA", true);
            isnull.Add("ICONDICIONESESPTRANSP", true);
            isnull.Add("IREGISTROSANITARIOFOLIOAUTORIZACION", true);
            isnull.Add("IPERMISOIMPORTACION", true);
            isnull.Add("IFOLIOIMPOVUCEM", true);
            isnull.Add("INUMCAS", true);
            isnull.Add("IRAZONSOCIALEMPIMP", true);
            isnull.Add("INUMREGSANPLAGCOFEPRIS", true);
            isnull.Add("IDATOSFABRICANTE", true);
            isnull.Add("IDATOSFORMULADOR", true);
            isnull.Add("IDATOSMAQUILADOR", true);
            isnull.Add("IUSOAUTORIZADO", true);
            isnull.Add("ITIPOMATERIA", true);
            isnull.Add("IDESCRIPCIONMATERIA", true);


        }



    }
}
