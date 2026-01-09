
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CPROD_DEF_CARACTERISTICASBE
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

        public CPROD_DEF_CARACTERISTICASBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


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

        }



    }
}
