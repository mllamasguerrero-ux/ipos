using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPosBusinessEntity
{
    public class CCARRIERBE
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

        private string iCARRIERID;
        public string ICARRIERID
        {
            get
            {
                return this.iCARRIERID;
            }
            set
            {
                this.iCARRIERID = value;
                this.isnull["ICARRIERID"] = false;
            }
        }

        private string iDESCRIPTION;
        public string IDESCRIPTION
        {
            get
            {
                return this.iDESCRIPTION;
            }
            set
            {
                this.iDESCRIPTION = value;
                this.isnull["IDESCRIPTION"] = false;
            }
        }

        private string iPRODUCTCOUNT;
        public string IPRODUCTCOUNT
        {
            get
            {
                return this.iPRODUCTCOUNT;
            }
            set
            {
                this.iPRODUCTCOUNT = value;
                this.isnull["IPRODUCTCOUNT"] = false;
            }
        }


        private string iESSERVICIO;
        public string IESSERVICIO
        {
            get
            {
                return this.iESSERVICIO;
            }
            set
            {
                this.iESSERVICIO = value;
                this.isnull["IESSERVICIO"] = false;
            }
        }


        public CCARRIERBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("ICARRIERID", true);


            isnull.Add("IDESCRIPTION", true);


            isnull.Add("IPRODUCTCOUNT", true);


            isnull.Add("IESSERVICIO", true);


        }



    }

}
