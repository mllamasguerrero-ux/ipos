using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPosBusinessEntity
{
    public class CM_CATSYNCBE
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

        private string iPATHNAME;
        public string IPATHNAME
        {
            get
            {
                return this.iPATHNAME;
            }
            set
            {
                this.iPATHNAME = value;
                this.isnull["IPATHNAME"] = false;
            }
        }

        private object iFECHAULTSYNC;
        public object IFECHAULTSYNC
        {
            get
            {
                return this.iFECHAULTSYNC;
            }
            set
            {
                this.iFECHAULTSYNC = value;
                this.isnull["IFECHAULTSYNC"] = false;
            }
        }

        private object iFECHAULTREQ;
        public object IFECHAULTREQ
        {
            get
            {
                return this.iFECHAULTREQ;
            }
            set
            {
                this.iFECHAULTREQ = value;
                this.isnull["IFECHAULTREQ"] = false;
            }
        }

        private object iFECHACAMPREC;
        public object IFECHACAMPREC
        {
            get
            {
                return this.iFECHACAMPREC;
            }
            set
            {
                this.iFECHACAMPREC = value;
                this.isnull["IFECHACAMPREC"] = false;
            }
        }

        public CM_CATSYNCBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IPATHNAME", true);


            isnull.Add("IFECHAULTSYNC", true);


            isnull.Add("IFECHAULTREQ", true);


            isnull.Add("IFECHACAMPREC", true);

        }



    }
}
