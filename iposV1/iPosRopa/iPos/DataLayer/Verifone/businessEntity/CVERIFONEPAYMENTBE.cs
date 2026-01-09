
using System;
using System.Collections;

namespace iPosBusinessEntity
{
    public class CVERIFONEPAYMENTBE
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

        private string iAPPSPECIFICDATA;
        public string IAPPSPECIFICDATA
        {
            get
            {
                return this.iAPPSPECIFICDATA;
            }
            set
            {
                this.iAPPSPECIFICDATA = value;
                this.isnull["IAPPSPECIFICDATA"] = false;
            }
        }

        private string iINVOICEID;
        public string IINVOICEID
        {
            get
            {
                return this.iINVOICEID;
            }
            set
            {
                this.iINVOICEID = value;
                this.isnull["IINVOICEID"] = false;
            }
        }

        private string iSESSIONID;
        public string ISESSIONID
        {
            get
            {
                return this.iSESSIONID;
            }
            set
            {
                this.iSESSIONID = value;
                this.isnull["ISESSIONID"] = false;
            }
        }

        private string iPAYMENTID;
        public string IPAYMENTID
        {
            get
            {
                return this.iPAYMENTID;
            }
            set
            {
                this.iPAYMENTID = value;
                this.isnull["IPAYMENTID"] = false;
            }
        }
        

        private string iMENSAJE;
        public string IMENSAJE
        {
            get
            {
                return this.iMENSAJE;
            }
            set
            {
                this.iMENSAJE = value;
                this.isnull["IMENSAJE"] = false;
            }
        }

        private int iSTATUS;
        public int ISTATUS
        {
            get
            {
                return this.iSTATUS;
            }
            set
            {
                this.iSTATUS = value;
                this.isnull["ISTATUS"] = false;
            }
        }

        private string iOPERACION;
        public string IOPERACION
        {
            get
            {
                return this.iOPERACION;
            }
            set
            {
                this.iOPERACION = value;
                this.isnull["IOPERACION"] = false;
            }
        }

        private string iAUTHCODE;
        public string IAUTHCODE
        {
            get
            {
                return this.iAUTHCODE;
            }
            set
            {
                this.iAUTHCODE = value;
                this.isnull["IAUTHCODE"] = false;
            }
        }

        private string iTERMINAL;
        public string ITERMINAL
        {
            get
            {
                return this.iTERMINAL;
            }
            set
            {
                this.iTERMINAL = value;
                this.isnull["ITERMINAL"] = false;
            }
        }

        private string iAFILIACION;
        public string IAFILIACION
        {
            get
            {
                return this.iAFILIACION;
            }
            set
            {
                this.iAFILIACION = value;
                this.isnull["IAFILIACION"] = false;
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

        private string iCARDBRAND;
        public string ICARDBRAND
        {
            get
            {
                return this.iCARDBRAND;
            }
            set
            {
                this.iCARDBRAND = value;
                this.isnull["ICARDBRAND"] = false;
            }
        }

        private string iCARDTYPE;
        public string ICARDTYPE
        {
            get
            {
                return this.iCARDTYPE;
            }
            set
            {
                this.iCARDTYPE = value;
                this.isnull["ICARDTYPE"] = false;
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

        public CVERIFONEPAYMENTBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("IDOCTOPAGOID", true);


            isnull.Add("IAPPSPECIFICDATA", true);


            isnull.Add("IINVOICEID", true);


            isnull.Add("ISESSIONID", true);


            isnull.Add("IPAYMENTID", true);
            


            isnull.Add("IMENSAJE", true);


            isnull.Add("ISTATUS", true);


            isnull.Add("IOPERACION", true);


            isnull.Add("IAUTHCODE", true);


            isnull.Add("ITERMINAL", true);


            isnull.Add("IAFILIACION", true);


            isnull.Add("IAID", true);


            isnull.Add("ICARDBRAND", true);


            isnull.Add("ICARDTYPE", true);


            isnull.Add("IMONTO", true);


            isnull.Add("IDOCTOID", true);


            isnull.Add("ITIPOTRANSACCION", true);


            isnull.Add("IESTADOTRANSACCIONID", true);


            isnull.Add("IREFID", true);

        }



    }
}
