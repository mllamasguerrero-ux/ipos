
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CCONTRARECIBOHDRBE
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

        private long iVENDEDORID;
        public long IVENDEDORID
        {
            get
            {
                return this.iVENDEDORID;
            }
            set
            {
                this.iVENDEDORID = value;
                this.isnull["IVENDEDORID"] = false;
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


        private string iOBSERVACIONES;
        public string IOBSERVACIONES
        {
            get
            {
                return this.iOBSERVACIONES;
            }
            set
            {
                this.iOBSERVACIONES = value;
                this.isnull["IOBSERVACIONES"] = false;
            }
        }


        private long iESTATUSPAGOID;
        public long IESTATUSPAGOID
        {
            get
            {
                return this.iESTATUSPAGOID;
            }
            set
            {
                this.iESTATUSPAGOID = value;
                this.isnull["IESTATUSPAGOID"] = false;
            }
        }

        public CCONTRARECIBOHDRBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("IFECHA", true);


            isnull.Add("IPERSONAID", true);


            isnull.Add("IVENDEDORID", true);


            isnull.Add("IESTATUSID", true);


            isnull.Add("ITOTAL", true);


            isnull.Add("IABONO", true);


            isnull.Add("ISALDO", true);


            isnull.Add("IOBSERVACIONES", true);


            isnull.Add("IESTATUSPAGOID", true);
        }



    }
}
