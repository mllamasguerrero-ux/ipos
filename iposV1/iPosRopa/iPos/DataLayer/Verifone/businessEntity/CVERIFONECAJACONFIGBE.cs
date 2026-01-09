

using System;
using System.Collections;

namespace iPosBusinessEntity
{
    public class CVERIFONECAJACONFIGBE
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

        private long iCAJAID;
        public long ICAJAID
        {
            get
            {
                return this.iCAJAID;
            }
            set
            {
                this.iCAJAID = value;
                this.isnull["ICAJAID"] = false;
            }
        }

        private string iUSERID;
        public string IUSERID
        {
            get
            {
                return this.iUSERID;
            }
            set
            {
                this.iUSERID = value;
                this.isnull["IUSERID"] = false;
            }
        }

        private string iCONTRASENA;
        public string ICONTRASENA
        {
            get
            {
                return this.iCONTRASENA;
            }
            set
            {
                this.iCONTRASENA = value;
                this.isnull["ICONTRASENA"] = false;
            }
        }

        private string iSHIFTNUMBER;
        public string ISHIFTNUMBER
        {
            get
            {
                return this.iSHIFTNUMBER;
            }
            set
            {
                this.iSHIFTNUMBER = value;
                this.isnull["ISHIFTNUMBER"] = false;
            }
        }

        private string iMERCHANTID;
        public string IMERCHANTID
        {
            get
            {
                return this.iMERCHANTID;
            }
            set
            {
                this.iMERCHANTID = value;
                this.isnull["IMERCHANTID"] = false;
            }
        }

        private string iOPERATORLOCALE;
        public string IOPERATORLOCALE
        {
            get
            {
                return this.iOPERATORLOCALE;
            }
            set
            {
                this.iOPERATORLOCALE = value;
                this.isnull["IOPERATORLOCALE"] = false;
            }
        }

        private string iDEVICECONNECTIONTYPEKEY;
        public string IDEVICECONNECTIONTYPEKEY
        {
            get
            {
                return this.iDEVICECONNECTIONTYPEKEY;
            }
            set
            {
                this.iDEVICECONNECTIONTYPEKEY = value;
                this.isnull["IDEVICECONNECTIONTYPEKEY"] = false;
            }
        }

        private string iDEVICEADDRESSKEY;
        public string IDEVICEADDRESSKEY
        {
            get
            {
                return this.iDEVICEADDRESSKEY;
            }
            set
            {
                this.iDEVICEADDRESSKEY = value;
                this.isnull["IDEVICEADDRESSKEY"] = false;
            }
        }

        public CVERIFONECAJACONFIGBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("ICAJAID", true);


            isnull.Add("IUSERID", true);


            isnull.Add("ICONTRASENA", true);


            isnull.Add("ISHIFTNUMBER", true);


            isnull.Add("IMERCHANTID", true);


            isnull.Add("IOPERATORLOCALE", true);


            isnull.Add("IDEVICECONNECTIONTYPEKEY", true);


            isnull.Add("IDEVICEADDRESSKEY", true);

            this.IACTIVO = "N";

        }



    }
}
