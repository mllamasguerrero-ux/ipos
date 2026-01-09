
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CM_MERCHBE
    {
        public Hashtable isnull;

        private string iMERCHANT;
        public string IMERCHANT
        {
            get
            {
                return this.iMERCHANT;
            }
            set
            {
                this.iMERCHANT = value;
                this.isnull["IMERCHANT"] = false;
            }
        }

        private string iSUCCLAVE;
        public string ISUCCLAVE
        {
            get
            {
                return this.iSUCCLAVE;
            }
            set
            {
                this.iSUCCLAVE = value;
                this.isnull["ISUCCLAVE"] = false;
            }
        }

        private string iESSERV;
        public string IESSERV
        {
            get
            {
                return this.iESSERV;
            }
            set
            {
                this.iESSERV = value;
                this.isnull["IESSERV"] = false;
            }
        }


        private string iID;
        public string IID
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

        private string iID_FECHA;
        public string IID_FECHA
        {
            get
            {
                return this.iID_FECHA;
            }
            set
            {
                this.iID_FECHA = value;
                this.isnull["IID_FECHA"] = false;
            }
        }

        private string iID_HORA;
        public string IID_HORA
        {
            get
            {
                return this.iID_HORA;
            }
            set
            {
                this.iID_HORA = value;
                this.isnull["IID_HORA"] = false;
            }
        }

        public CM_MERCHBE()
        {
            isnull = new Hashtable();


            isnull.Add("IMERCHANT", true);


            isnull.Add("ISUCCLAVE", true);

            isnull.Add("IESSERV", true);


            isnull.Add("IID", true);


            isnull.Add("IID_FECHA", true);


            isnull.Add("IID_HORA", true);

        }



    }
}
