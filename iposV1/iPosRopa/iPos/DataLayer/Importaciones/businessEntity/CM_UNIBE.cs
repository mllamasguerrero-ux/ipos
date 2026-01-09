
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CM_UNIBE
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


        private decimal iCANTDEC;
        public decimal ICANTDEC
        {
            get
            {
                return this.iCANTDEC;
            }
            set
            {
                this.iCANTDEC = value;
                this.isnull["ICANTDEC"] = false;
            }
        }

        private string iCLAVESAT;
        public string ICLAVESAT
        {
            get
            {
                return this.iCLAVESAT;
            }
            set
            {
                this.iCLAVESAT = value;
                this.isnull["ICLAVESAT"] = false;
            }
        }

        public CM_UNIBE()
        {
            isnull = new Hashtable();


            isnull.Add("ICLAVE", true);


            isnull.Add("INOMBRE", true);



            isnull.Add("IID", true);


            isnull.Add("IID_FECHA", true);


            isnull.Add("IID_HORA", true);


            isnull.Add("ICANTDEC", true);


            isnull.Add("ICLAVESAT", true);

        }



    }
}
