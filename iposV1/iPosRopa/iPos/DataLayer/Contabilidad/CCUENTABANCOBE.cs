
using System;
using System.Collections;

namespace iPosBusinessEntity
{
    public class CCUENTABANCOBE
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

        private long iBANCOID;
        public long IBANCOID
        {
            get
            {
                return this.iBANCOID;
            }
            set
            {
                this.iBANCOID = value;
                this.isnull["IBANCOID"] = false;
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

        private string iRFC;
        public string IRFC
        {
            get
            {
                return this.iRFC;
            }
            set
            {
                this.iRFC = value;
                this.isnull["IRFC"] = false;
            }
        }

        private string iNOCUENTA;
        public string INOCUENTA
        {
            get
            {
                return this.iNOCUENTA;
            }
            set
            {
                this.iNOCUENTA = value;
                this.isnull["INOCUENTA"] = false;
            }
        }


        private string iPREDETERMINADA;
        public string IPREDETERMINADA
        {
            get
            {
                return this.iPREDETERMINADA;
            }
            set
            {
                this.iPREDETERMINADA = value;
                this.isnull["IPREDETERMINADA"] = false;
            }
        }

        public CCUENTABANCOBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("IBANCOID", true);


            isnull.Add("INOMBRE", true);


            isnull.Add("IRFC", true);


            isnull.Add("INOCUENTA", true);

            isnull.Add("IPREDETERMINADA", true);

        }



    }
}
