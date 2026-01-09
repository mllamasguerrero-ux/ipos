
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CM_TASABE
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

        private double iTASA;
        public double ITASA
        {
            get
            {
                return this.iTASA;
            }
            set
            {
                this.iTASA = value;
                this.isnull["ITASA"] = false;
            }
        }

        private DateTime iFECHAINI;
        public DateTime IFECHAINI
        {
            get
            {
                return this.iFECHAINI;
            }
            set
            {
                this.iFECHAINI = value;
                this.isnull["IFECHAINI"] = false;
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

        private DateTime iID_FECHA;
        public DateTime IID_FECHA
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

        public CM_TASABE()
        {
            isnull = new Hashtable();


            isnull.Add("ICLAVE", true);


            isnull.Add("INOMBRE", true);


            isnull.Add("ITASA", true);


            isnull.Add("IFECHAINI", true);


            isnull.Add("IID", true);


            isnull.Add("IID_FECHA", true);


            isnull.Add("IID_HORA", true);

        }



    }
}
