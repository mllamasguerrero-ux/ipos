
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CLOTESIMPORTADOSBE
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

        private string iPEDIMENTO;
        public string IPEDIMENTO
        {
            get
            {
                return this.iPEDIMENTO;
            }
            set
            {
                this.iPEDIMENTO = value;
                this.isnull["IPEDIMENTO"] = false;
            }
        }

        private DateTime iFECHAIMPORTACION;
        public DateTime IFECHAIMPORTACION
        {
            get
            {
                return this.iFECHAIMPORTACION;
            }
            set
            {
                this.iFECHAIMPORTACION = value;
                this.isnull["IFECHAIMPORTACION"] = false;
            }
        }

        private string iADUANA;
        public string IADUANA
        {
            get
            {
                return this.iADUANA;
            }
            set
            {
                this.iADUANA = value;
                this.isnull["IADUANA"] = false;
            }
        }

        private decimal iTIPOCAMBIO;
        public decimal ITIPOCAMBIO
        {
            get
            {
                return this.iTIPOCAMBIO;
            }
            set
            {
                this.iTIPOCAMBIO = value;
                this.isnull["ITIPOCAMBIO"] = false;
            }
        }

        private long iSATADUANAID;
        public long ISATADUANAID
        {
            get
            {
                return this.iSATADUANAID;
            }
            set
            {
                this.iSATADUANAID = value;
                this.isnull["ISATADUANAID"] = false;
            }
        }

        public CLOTESIMPORTADOSBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("IPEDIMENTO", true);


            isnull.Add("IFECHAIMPORTACION", true);


            isnull.Add("IADUANA", true);


            isnull.Add("ITIPOCAMBIO", true);

            isnull.Add("ISATADUANAID", true);

        }



    }
}
