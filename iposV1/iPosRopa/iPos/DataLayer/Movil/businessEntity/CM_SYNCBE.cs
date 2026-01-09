using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPosBusinessEntity
{

    public class CM_SYNCBE
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

        private string iVENDCLAVE;
        public string IVENDCLAVE
        {
            get
            {
                return this.iVENDCLAVE;
            }
            set
            {
                this.iVENDCLAVE = value;
                this.isnull["IVENDCLAVE"] = false;
            }
        }


        private long iESTATUSENVIOSUC;
        public long IESTATUSENVIOSUC
        {
            get
            {
                return this.iESTATUSENVIOSUC;
            }
            set
            {
                this.iESTATUSENVIOSUC = value;
                this.isnull["IESTATUSENVIOSUC"] = false;
            }
        }

        
        private DateTime iFECHAULTENVIOSUC;
        public DateTime IFECHAULTENVIOSUC
        {
            get
            {
                return this.iFECHAULTENVIOSUC;
            }
            set
            {
                this.iFECHAULTENVIOSUC = value;
                this.isnull["IFECHAULTENVIOSUC"] = false;
            }
        }
        
        public CM_SYNCBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IVENDCLAVE", true);


            isnull.Add("IESTATUSENVIOSUC", true);


            isnull.Add("IFECHAULTENVIOSUC", true);

        }



    }
}
