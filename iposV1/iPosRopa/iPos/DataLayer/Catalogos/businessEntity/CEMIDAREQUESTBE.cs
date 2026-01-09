using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPosBusinessEntity
{
    public class CEMIDAREQUESTBE
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

        private string iVERSION;
        public string IVERSION
        {
            get
            {
                return this.iVERSION;
            }
            set
            {
                this.iVERSION = value;
                this.isnull["IVERSION"] = false;
            }
        }

        private string iSITEID;
        public string ISITEID
        {
            get
            {
                return this.iSITEID;
            }
            set
            {
                this.iSITEID = value;
                this.isnull["ISITEID"] = false;
            }
        }

        private string iCLERKID;
        public string ICLERKID
        {
            get
            {
                return this.iCLERKID;
            }
            set
            {
                this.iCLERKID = value;
                this.isnull["ICLERKID"] = false;
            }
        }

        private string iPRODUCTID;
        public string IPRODUCTID
        {
            get
            {
                return this.iPRODUCTID;
            }
            set
            {
                this.iPRODUCTID = value;
                this.isnull["IPRODUCTID"] = false;
            }
        }

        private string iACCOUNTID;
        public string IACCOUNTID
        {
            get
            {
                return this.iACCOUNTID;
            }
            set
            {
                this.iACCOUNTID = value;
                this.isnull["IACCOUNTID"] = false;
            }
        }

        private string iAMOUNT;
        public string IAMOUNT
        {
            get
            {
                return this.iAMOUNT;
            }
            set
            {
                this.iAMOUNT = value;
                this.isnull["IAMOUNT"] = false;
            }
        }

        private string iINVOICENO;
        public string IINVOICENO
        {
            get
            {
                return this.iINVOICENO;
            }
            set
            {
                this.iINVOICENO = value;
                this.isnull["IINVOICENO"] = false;
            }
        }

        private string iLANGUAGEOPTION;
        public string ILANGUAGEOPTION
        {
            get
            {
                return this.iLANGUAGEOPTION;
            }
            set
            {
                this.iLANGUAGEOPTION = value;
                this.isnull["ILANGUAGEOPTION"] = false;
            }
        }

        private string iRESPONSECODE;
        public string IRESPONSECODE
        {
            get
            {
                return this.iRESPONSECODE;
            }
            set
            {
                this.iRESPONSECODE = value;
                this.isnull["IRESPONSECODE"] = false;
            }
        }

        private string iPIN;
        public string IPIN
        {
            get
            {
                return this.iPIN;
            }
            set
            {
                this.iPIN = value;
                this.isnull["IPIN"] = false;
            }
        }

        private string iCONTROLNO;
        public string ICONTROLNO
        {
            get
            {
                return this.iCONTROLNO;
            }
            set
            {
                this.iCONTROLNO = value;
                this.isnull["ICONTROLNO"] = false;
            }
        }

        private string iCARRIERCONTROLNO;
        public string ICARRIERCONTROLNO
        {
            get
            {
                return this.iCARRIERCONTROLNO;
            }
            set
            {
                this.iCARRIERCONTROLNO = value;
                this.isnull["ICARRIERCONTROLNO"] = false;
            }
        }

        private string iCUSTOMERSERVICENO;
        public string ICUSTOMERSERVICENO
        {
            get
            {
                return this.iCUSTOMERSERVICENO;
            }
            set
            {
                this.iCUSTOMERSERVICENO = value;
                this.isnull["ICUSTOMERSERVICENO"] = false;
            }
        }

        private string iTRANSACTIONDATETIME;
        public string ITRANSACTIONDATETIME
        {
            get
            {
                return this.iTRANSACTIONDATETIME;
            }
            set
            {
                this.iTRANSACTIONDATETIME = value;
                this.isnull["ITRANSACTIONDATETIME"] = false;
            }
        }

        private string iRESULTCODE;
        public string IRESULTCODE
        {
            get
            {
                return this.iRESULTCODE;
            }
            set
            {
                this.iRESULTCODE = value;
                this.isnull["IRESULTCODE"] = false;
            }
        }

        private string iRESPONSEMESSAGE;
        public string IRESPONSEMESSAGE
        {
            get
            {
                return this.iRESPONSEMESSAGE;
            }
            set
            {
                this.iRESPONSEMESSAGE = value;
                this.isnull["IRESPONSEMESSAGE"] = false;
            }
        }

        private string iTRANSACTIONID;
        public string ITRANSACTIONID
        {
            get
            {
                return this.iTRANSACTIONID;
            }
            set
            {
                this.iTRANSACTIONID = value;
                this.isnull["ITRANSACTIONID"] = false;
            }
        }

        private string iH2HRESULTCODE;
        public string IH2HRESULTCODE
        {
            get
            {
                return this.iH2HRESULTCODE;
            }
            set
            {
                this.iH2HRESULTCODE = value;
                this.isnull["IH2HRESULTCODE"] = false;
            }
        }



        private long iMOVTOID;
        public long IMOVTOID
        {
            get
            {
                return this.iMOVTOID;
            }
            set
            {
                this.iMOVTOID = value;
                this.isnull["IMOVTOID"] = false;
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



        private string iESSERVICIO;
        public string IESSERVICIO
        {
            get
            {
                return this.iESSERVICIO;
            }
            set
            {
                this.iESSERVICIO = value;
                this.isnull["IESSERVICIO"] = false;
            }
        }



        public CEMIDAREQUESTBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("IVERSION", true);


            isnull.Add("ISITEID", true);


            isnull.Add("ICLERKID", true);


            isnull.Add("IPRODUCTID", true);


            isnull.Add("IACCOUNTID", true);


            isnull.Add("IAMOUNT", true);


            isnull.Add("IINVOICENO", true);


            isnull.Add("ILANGUAGEOPTION", true);


            isnull.Add("IRESPONSECODE", true);


            isnull.Add("IPIN", true);


            isnull.Add("ICONTROLNO", true);


            isnull.Add("ICARRIERCONTROLNO", true);


            isnull.Add("ICUSTOMERSERVICENO", true);


            isnull.Add("ITRANSACTIONDATETIME", true);


            isnull.Add("IRESULTCODE", true);


            isnull.Add("IRESPONSEMESSAGE", true);


            isnull.Add("ITRANSACTIONID", true);


            isnull.Add("IH2HRESULTCODE", true);

            isnull.Add("IMOVTOID", true);

            isnull.Add("ICOMISION", true);

            isnull.Add("IESSERVICIO", true);

        }
    }
}
