using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPosBusinessEntity
{
    public class CEMIDAPRODBE
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

        private string iDESCRIPTION;
        public string IDESCRIPTION
        {
            get
            {
                return this.iDESCRIPTION;
            }
            set
            {
                this.iDESCRIPTION = value;
                this.isnull["IDESCRIPTION"] = false;
            }
        }

        private string iSHORTDESCRIPTION;
        public string ISHORTDESCRIPTION
        {
            get
            {
                return this.iSHORTDESCRIPTION;
            }
            set
            {
                this.iSHORTDESCRIPTION = value;
                this.isnull["ISHORTDESCRIPTION"] = false;
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

        private string iCARRIERID;
        public string ICARRIERID
        {
            get
            {
                return this.iCARRIERID;
            }
            set
            {
                this.iCARRIERID = value;
                this.isnull["ICARRIERID"] = false;
            }
        }

        private string iCATEGORYID;
        public string ICATEGORYID
        {
            get
            {
                return this.iCATEGORYID;
            }
            set
            {
                this.iCATEGORYID = value;
                this.isnull["ICATEGORYID"] = false;
            }
        }

        private string iTRANSTIPOID;
        public string ITRANSTIPOID
        {
            get
            {
                return this.iTRANSTIPOID;
            }
            set
            {
                this.iTRANSTIPOID = value;
                this.isnull["ITRANSTIPOID"] = false;
            }
        }

        private string iCURRENCYCODE;
        public string ICURRENCYCODE
        {
            get
            {
                return this.iCURRENCYCODE;
            }
            set
            {
                this.iCURRENCYCODE = value;
                this.isnull["ICURRENCYCODE"] = false;
            }
        }

        private string iCURRENCYSYMBOL;
        public string ICURRENCYSYMBOL
        {
            get
            {
                return this.iCURRENCYSYMBOL;
            }
            set
            {
                this.iCURRENCYSYMBOL = value;
                this.isnull["ICURRENCYSYMBOL"] = false;
            }
        }

        private string iDISCOUNTRATE;
        public string IDISCOUNTRATE
        {
            get
            {
                return this.iDISCOUNTRATE;
            }
            set
            {
                this.iDISCOUNTRATE = value;
                this.isnull["IDISCOUNTRATE"] = false;
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

        public CEMIDAPRODBE()
		{
		    isnull=new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);

            isnull.Add("IPRODUCTID", true);

            isnull.Add("IDESCRIPTION", true);

            isnull.Add("ISHORTDESCRIPTION", true);

            isnull.Add("IAMOUNT", true);

            isnull.Add("ICARRIERID", true);

            isnull.Add("ICATEGORYID", true);

            isnull.Add("ITRANSTIPOID", true);

            isnull.Add("ICURRENCYCODE", true);

            isnull.Add("ICURRENCYSYMBOL", true);

            isnull.Add("IDISCOUNTRATE", true);

            isnull.Add("IH2HRESULTCODE", true);
		}

    }
}
