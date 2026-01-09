
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CQUOTABE
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

        private int iANIO;
        public int IANIO
        {
            get
            {
                return this.iANIO;
            }
            set
            {
                this.iANIO = value;
                this.isnull["IANIO"] = false;
            }
        }

        private int iMES;
        public int IMES
        {
            get
            {
                return this.iMES;
            }
            set
            {
                this.iMES = value;
                this.isnull["IMES"] = false;
            }
        }

        private decimal iQUOTA;
        public decimal IQUOTA
        {
            get
            {
                return this.iQUOTA;
            }
            set
            {
                this.iQUOTA = value;
                this.isnull["IQUOTA"] = false;
            }
        }

        private decimal iLOGRO;
        public decimal ILOGRO
        {
            get
            {
                return this.iLOGRO;
            }
            set
            {
                this.iLOGRO = value;
                this.isnull["ILOGRO"] = false;
            }
        }

        private decimal iUTILIDAD;
        public decimal IUTILIDAD
        {
            get
            {
                return this.iUTILIDAD;
            }
            set
            {
                this.iUTILIDAD = value;
                this.isnull["IUTILIDAD"] = false;
            }
        }

        public CQUOTABE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("IVENDEDORID", true);


            isnull.Add("IANIO", true);


            isnull.Add("IMES", true);


            isnull.Add("IQUOTA", true);


            isnull.Add("ILOGRO", true);


            isnull.Add("IUTILIDAD", true);

        }



    }
}
