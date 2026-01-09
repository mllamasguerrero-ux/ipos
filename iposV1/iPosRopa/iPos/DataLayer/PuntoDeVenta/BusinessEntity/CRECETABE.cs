
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CRECETABE
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

        private string iNOMBRE;
        public string INOMBRE
        {
            get
            {
                return this.iNOMBRE;
            }
            set
            {
                this.iNOMBRE = value;
                this.isnull["INOMBRE"] = false;
            }
        }

        private string iCEDULA;
        public string ICEDULA
        {
            get
            {
                return this.iCEDULA;
            }
            set
            {
                this.iCEDULA = value;
                this.isnull["ICEDULA"] = false;
            }
        }

        private string iRECETANUMERO;
        public string IRECETANUMERO
        {
            get
            {
                return this.iRECETANUMERO;
            }
            set
            {
                this.iRECETANUMERO = value;
                this.isnull["IRECETANUMERO"] = false;
            }
        }

        private long iMEDICOID;
        public long IMEDICOID
        {
            get
            {
                return this.iMEDICOID;
            }
            set
            {
                this.iMEDICOID = value;
                this.isnull["IMEDICOID"] = false;
            }
        }

        private long iVENTAID;
        public long IVENTAID
        {
            get
            {
                return this.iVENTAID;
            }
            set
            {
                this.iVENTAID = value;
                this.isnull["IVENTAID"] = false;
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


        private string iRETENIDA;
        public string IRETENIDA
        {
            get
            {
                return this.iRETENIDA;
            }
            set
            {
                this.iRETENIDA = value;
                this.isnull["IRETENIDA"] = false;
            }
        }

        public CRECETABE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("INOMBRE", true);


            isnull.Add("ICEDULA", true);


            isnull.Add("IRECETANUMERO", true);


            isnull.Add("IMEDICOID", true);


            isnull.Add("IVENTAID", true);

            isnull.Add("IFOLIO", true);

            isnull.Add("IRETENIDA", true);

        }



    }
}
