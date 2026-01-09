
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CCONTRARECIBODTLBE
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

        private DateTime iFECHAVENCE;
        public DateTime IFECHAVENCE
        {
            get
            {
                return this.iFECHAVENCE;
            }
            set
            {
                this.iFECHAVENCE = value;
                this.isnull["IFECHAVENCE"] = false;
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
                this.iFOLIO = value;
                this.isnull["IFOLIO"] = false;
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
                this.iSERIE = value;
                this.isnull["ISERIE"] = false;
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

        private long iESTATUSID;
        public long IESTATUSID
        {
            get
            {
                return this.iESTATUSID;
            }
            set
            {
                this.iESTATUSID = value;
                this.isnull["IESTATUSID"] = false;
            }
        }

        private decimal iTOTALDOCTO;
        public decimal ITOTALDOCTO
        {
            get
            {
                return this.iTOTALDOCTO;
            }
            set
            {
                this.iTOTALDOCTO = value;
                this.isnull["ITOTALDOCTO"] = false;
            }
        }

        private decimal iABONODOCTO;
        public decimal IABONODOCTO
        {
            get
            {
                return this.iABONODOCTO;
            }
            set
            {
                this.iABONODOCTO = value;
                this.isnull["IABONODOCTO"] = false;
            }
        }

        private decimal iSALDODOCTO;
        public decimal ISALDODOCTO
        {
            get
            {
                return this.iSALDODOCTO;
            }
            set
            {
                this.iSALDODOCTO = value;
                this.isnull["ISALDODOCTO"] = false;
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
                this.iTOTAL = value;
                this.isnull["ITOTAL"] = false;
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
                this.iABONO = value;
                this.isnull["IABONO"] = false;
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
                this.iSALDO = value;
                this.isnull["ISALDO"] = false;
            }
        }

        public CCONTRARECIBODTLBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("ICONTRARECIBOID", true);


            isnull.Add("IDOCTOID", true);


            isnull.Add("IFECHA", true);


            isnull.Add("IFECHAVENCE", true);


            isnull.Add("IFOLIO", true);


            isnull.Add("ISERIE", true);


            isnull.Add("IFOLIOSAT", true);


            isnull.Add("ISERIESAT", true);


            isnull.Add("IESTATUSID", true);


            isnull.Add("ITOTALDOCTO", true);


            isnull.Add("IABONODOCTO", true);


            isnull.Add("ISALDODOCTO", true);


            isnull.Add("ITOTAL", true);


            isnull.Add("IABONO", true);


            isnull.Add("ISALDO", true);

        }



    }
}
