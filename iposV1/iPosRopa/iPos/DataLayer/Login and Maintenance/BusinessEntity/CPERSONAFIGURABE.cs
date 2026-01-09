
using System;
using System.Collections;

namespace iPosBusinessEntity
{
    public class CPERSONAFIGURABE
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

        private long iPERSONAID;
        public long IPERSONAID
        {
            get
            {
                return this.iPERSONAID;
            }
            set
            {
                this.iPERSONAID = value;
                this.isnull["IPERSONAID"] = false;
            }
        }

        private long iSAT_FIGURATRANSPORTEID;
        public long ISAT_FIGURATRANSPORTEID
        {
            get
            {
                return this.iSAT_FIGURATRANSPORTEID;
            }
            set
            {
                this.iSAT_FIGURATRANSPORTEID = value;
                this.isnull["ISAT_FIGURATRANSPORTEID"] = false;
            }
        }

        private string iNUMLICENCIA;
        public string INUMLICENCIA
        {
            get
            {
                return this.iNUMLICENCIA;
            }
            set
            {
                this.iNUMLICENCIA = value;
                this.isnull["INUMLICENCIA"] = false;
            }
        }

        private string iNUMREGIDTRIB;
        public string INUMREGIDTRIB
        {
            get
            {
                return this.iNUMREGIDTRIB;
            }
            set
            {
                this.iNUMREGIDTRIB = value;
                this.isnull["INUMREGIDTRIB"] = false;
            }
        }

        private string iRESIDENCIAFISCAL;
        public string IRESIDENCIAFISCAL
        {
            get
            {
                return this.iRESIDENCIAFISCAL;
            }
            set
            {
                this.iRESIDENCIAFISCAL = value;
                this.isnull["IRESIDENCIAFISCAL"] = false;
            }
        }

        private long iSAT_PARTETRANSPORTEID;
        public long ISAT_PARTETRANSPORTEID
        {
            get
            {
                return this.iSAT_PARTETRANSPORTEID;
            }
            set
            {
                this.iSAT_PARTETRANSPORTEID = value;
                this.isnull["ISAT_PARTETRANSPORTEID"] = false;
            }
        }

        public CPERSONAFIGURABE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("IPERSONAID", true);


            isnull.Add("ISAT_FIGURATRANSPORTEID", true);


            isnull.Add("INUMLICENCIA", true);


            isnull.Add("INUMREGIDTRIB", true);


            isnull.Add("IRESIDENCIAFISCAL", true);


            isnull.Add("ISAT_PARTETRANSPORTEID", true);

        }



    }
}
