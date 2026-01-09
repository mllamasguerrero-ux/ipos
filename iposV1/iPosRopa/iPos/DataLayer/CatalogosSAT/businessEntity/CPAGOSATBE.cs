
using System;
using System.Collections;

namespace iPosBusinessEntity
{
    public class CPAGOSATBE
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

        private long iDOCTOSATID;
        public long IDOCTOSATID
        {
            get
            {
                return this.iDOCTOSATID;
            }
            set
            {
                this.iDOCTOSATID = value;
                this.isnull["IDOCTOSATID"] = false;
            }
        }

        private DateTime iFECHAPAGO;
        public DateTime IFECHAPAGO
        {
            get
            {
                return this.iFECHAPAGO;
            }
            set
            {
                this.iFECHAPAGO = value;
                this.isnull["IFECHAPAGO"] = false;
            }
        }

        private string iFORMADEPAGOP;
        public string IFORMADEPAGOP
        {
            get
            {
                return this.iFORMADEPAGOP;
            }
            set
            {
                this.iFORMADEPAGOP = value;
                this.isnull["IFORMADEPAGOP"] = false;
            }
        }

        private string iMONEDAP;
        public string IMONEDAP
        {
            get
            {
                return this.iMONEDAP;
            }
            set
            {
                this.iMONEDAP = value;
                this.isnull["IMONEDAP"] = false;
            }
        }

        private decimal iTIPOCAMBIOP;
        public decimal ITIPOCAMBIOP
        {
            get
            {
                return this.iTIPOCAMBIOP;
            }
            set
            {
                this.iTIPOCAMBIOP = value;
                this.isnull["ITIPOCAMBIOP"] = false;
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
                this.iMONTO = value;
                this.isnull["IMONTO"] = false;
            }
        }

        private string iNUMOPERACION;
        public string INUMOPERACION
        {
            get
            {
                return this.iNUMOPERACION;
            }
            set
            {
                this.iNUMOPERACION = value;
                this.isnull["INUMOPERACION"] = false;
            }
        }

        private string iRFCEMISORCTAORD;
        public string IRFCEMISORCTAORD
        {
            get
            {
                return this.iRFCEMISORCTAORD;
            }
            set
            {
                this.iRFCEMISORCTAORD = value;
                this.isnull["IRFCEMISORCTAORD"] = false;
            }
        }

        private string iNOMBANCOORDEXT;
        public string INOMBANCOORDEXT
        {
            get
            {
                return this.iNOMBANCOORDEXT;
            }
            set
            {
                this.iNOMBANCOORDEXT = value;
                this.isnull["INOMBANCOORDEXT"] = false;
            }
        }

        private string iCTAORDENANTE;
        public string ICTAORDENANTE
        {
            get
            {
                return this.iCTAORDENANTE;
            }
            set
            {
                this.iCTAORDENANTE = value;
                this.isnull["ICTAORDENANTE"] = false;
            }
        }

        private string iRFCEMISORCTABEN;
        public string IRFCEMISORCTABEN
        {
            get
            {
                return this.iRFCEMISORCTABEN;
            }
            set
            {
                this.iRFCEMISORCTABEN = value;
                this.isnull["IRFCEMISORCTABEN"] = false;
            }
        }

        private string iCTABENEFICIARIO;
        public string ICTABENEFICIARIO
        {
            get
            {
                return this.iCTABENEFICIARIO;
            }
            set
            {
                this.iCTABENEFICIARIO = value;
                this.isnull["ICTABENEFICIARIO"] = false;
            }
        }

        private string iTIPOCADPAGO;
        public string ITIPOCADPAGO
        {
            get
            {
                return this.iTIPOCADPAGO;
            }
            set
            {
                this.iTIPOCADPAGO = value;
                this.isnull["ITIPOCADPAGO"] = false;
            }
        }

        private string iCERTPAGO;
        public string ICERTPAGO
        {
            get
            {
                return this.iCERTPAGO;
            }
            set
            {
                this.iCERTPAGO = value;
                this.isnull["ICERTPAGO"] = false;
            }
        }

        private string iCADPAGO;
        public string ICADPAGO
        {
            get
            {
                return this.iCADPAGO;
            }
            set
            {
                this.iCADPAGO = value;
                this.isnull["ICADPAGO"] = false;
            }
        }

        private string iSELLOPAGO;
        public string ISELLOPAGO
        {
            get
            {
                return this.iSELLOPAGO;
            }
            set
            {
                this.iSELLOPAGO = value;
                this.isnull["ISELLOPAGO"] = false;
            }
        }

        public CPAGOSATBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("IDOCTOSATID", true);


            isnull.Add("IFECHAPAGO", true);


            isnull.Add("IFORMADEPAGOP", true);


            isnull.Add("IMONEDAP", true);


            isnull.Add("ITIPOCAMBIOP", true);


            isnull.Add("IMONTO", true);


            isnull.Add("INUMOPERACION", true);


            isnull.Add("IRFCEMISORCTAORD", true);


            isnull.Add("INOMBANCOORDEXT", true);


            isnull.Add("ICTAORDENANTE", true);


            isnull.Add("IRFCEMISORCTABEN", true);


            isnull.Add("ICTABENEFICIARIO", true);


            isnull.Add("ITIPOCADPAGO", true);


            isnull.Add("ICERTPAGO", true);


            isnull.Add("ICADPAGO", true);


            isnull.Add("ISELLOPAGO", true);

        }



    }
}
