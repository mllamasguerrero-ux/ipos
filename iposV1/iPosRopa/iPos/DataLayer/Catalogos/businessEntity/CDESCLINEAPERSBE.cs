

using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CDESCLINEAPERSBE
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

        private long iPERSONAID;
        public long IPERSONAID
        {
            get
            {
                return this.iPERSONAID;
            }
            set
            {
                this.iPERSONAID = value;
                this.isnull["IPERSONAID"] = false;
            }
        }

        private long iLINEAID;
        public long ILINEAID
        {
            get
            {
                return this.iLINEAID;
            }
            set
            {
                this.iLINEAID = value;
                this.isnull["ILINEAID"] = false;
            }
        }

        private decimal iDESCUENTO;
        public decimal IDESCUENTO
        {
            get
            {
                return this.iDESCUENTO;
            }
            set
            {
                this.iDESCUENTO = value;
                this.isnull["IDESCUENTO"] = false;
            }
        }

        public CDESCLINEAPERSBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("IPERSONAID", true);


            isnull.Add("ILINEAID", true);


            isnull.Add("IDESCUENTO", true);

        }



    }
}
