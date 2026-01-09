
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CM_DEFCBE
    {
        public Hashtable isnull;

        private string iTEXTO1;
        public string ITEXTO1
        {
            get
            {
                return this.iTEXTO1;
            }
            set
            {
                this.iTEXTO1 = value;
                this.isnull["ITEXTO1"] = false;
            }
        }

        private string iTEXTO2;
        public string ITEXTO2
        {
            get
            {
                return this.iTEXTO2;
            }
            set
            {
                this.iTEXTO2 = value;
                this.isnull["ITEXTO2"] = false;
            }
        }

        private string iTEXTO3;
        public string ITEXTO3
        {
            get
            {
                return this.iTEXTO3;
            }
            set
            {
                this.iTEXTO3 = value;
                this.isnull["ITEXTO3"] = false;
            }
        }

        private string iTEXTO4;
        public string ITEXTO4
        {
            get
            {
                return this.iTEXTO4;
            }
            set
            {
                this.iTEXTO4 = value;
                this.isnull["ITEXTO4"] = false;
            }
        }

        private string iTEXTO5;
        public string ITEXTO5
        {
            get
            {
                return this.iTEXTO5;
            }
            set
            {
                this.iTEXTO5 = value;
                this.isnull["ITEXTO5"] = false;
            }
        }

        private string iTEXTO6;
        public string ITEXTO6
        {
            get
            {
                return this.iTEXTO6;
            }
            set
            {
                this.iTEXTO6 = value;
                this.isnull["ITEXTO6"] = false;
            }
        }

        private string iNUMERO1;
        public string INUMERO1
        {
            get
            {
                return this.iNUMERO1;
            }
            set
            {
                this.iNUMERO1 = value;
                this.isnull["INUMERO1"] = false;
            }
        }

        private string iNUMERO2;
        public string INUMERO2
        {
            get
            {
                return this.iNUMERO2;
            }
            set
            {
                this.iNUMERO2 = value;
                this.isnull["INUMERO2"] = false;
            }
        }

        private string iNUMERO3;
        public string INUMERO3
        {
            get
            {
                return this.iNUMERO3;
            }
            set
            {
                this.iNUMERO3 = value;
                this.isnull["INUMERO3"] = false;
            }
        }

        private string iNUMERO4;
        public string INUMERO4
        {
            get
            {
                return this.iNUMERO4;
            }
            set
            {
                this.iNUMERO4 = value;
                this.isnull["INUMERO4"] = false;
            }
        }

        private string iFECHA1;
        public string IFECHA1
        {
            get
            {
                return this.iFECHA1;
            }
            set
            {
                this.iFECHA1 = value;
                this.isnull["IFECHA1"] = false;
            }
        }

        private string iFECHA2;
        public string IFECHA2
        {
            get
            {
                return this.iFECHA2;
            }
            set
            {
                this.iFECHA2 = value;
                this.isnull["IFECHA2"] = false;
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

        public CM_DEFCBE()
        {
            isnull = new Hashtable();


            isnull.Add("ITEXTO1", true);


            isnull.Add("ITEXTO2", true);


            isnull.Add("ITEXTO3", true);


            isnull.Add("ITEXTO4", true);


            isnull.Add("ITEXTO5", true);


            isnull.Add("ITEXTO6", true);


            isnull.Add("INUMERO1", true);


            isnull.Add("INUMERO2", true);


            isnull.Add("INUMERO3", true);


            isnull.Add("INUMERO4", true);


            isnull.Add("IFECHA1", true);


            isnull.Add("IFECHA2", true);


            isnull.Add("IID", true);


            isnull.Add("IID_FECHA", true);


            isnull.Add("IID_HORA", true);

        }



    }
}
