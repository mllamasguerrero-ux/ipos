using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CM_DERBE
    {
        public Hashtable isnull;


        private string iCLAVE;
        public string ICLAVE
        {
            get
            {
                return this.iCLAVE;
            }
            set
            {
                this.iCLAVE = value;
                this.isnull["ICLAVE"] = false;
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

        public CM_DERBE()
        {
            isnull = new Hashtable();
            isnull.Add("ICLAVE", true);
            isnull.Add("INOMBRE", true);

        }


    }
}
