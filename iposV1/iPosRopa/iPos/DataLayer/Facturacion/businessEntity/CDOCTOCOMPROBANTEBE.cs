
using System;
using System.Collections;

namespace iPosBusinessEntity
{
    public class CDOCTOCOMPROBANTEBE
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

        private long iDOCTOID;
        public long IDOCTOID
        {
            get
            {
                return this.iDOCTOID;
            }
            set
            {
                this.iDOCTOID = value;
                this.isnull["IDOCTOID"] = false;
            }
        }

        private string iTIPOCOMPROBANTE;
        public string ITIPOCOMPROBANTE
        {
            get
            {
                return this.iTIPOCOMPROBANTE;
            }
            set
            {
                this.iTIPOCOMPROBANTE = value;
                this.isnull["ITIPOCOMPROBANTE"] = false;
            }
        }

        private string iTIMBRADOUUID;
        public string ITIMBRADOUUID
        {
            get
            {
                return this.iTIMBRADOUUID;
            }
            set
            {
                this.iTIMBRADOUUID = value;
                this.isnull["ITIMBRADOUUID"] = false;
            }
        }

        private string iTIMBRADOFECHA;
        public string ITIMBRADOFECHA
        {
            get
            {
                return this.iTIMBRADOFECHA;
            }
            set
            {
                this.iTIMBRADOFECHA = value;
                this.isnull["ITIMBRADOFECHA"] = false;
            }
        }

        private string iTIMBRADOCERTSAT;
        public string ITIMBRADOCERTSAT
        {
            get
            {
                return this.iTIMBRADOCERTSAT;
            }
            set
            {
                this.iTIMBRADOCERTSAT = value;
                this.isnull["ITIMBRADOCERTSAT"] = false;
            }
        }

        private string iTIMBRADOSELLOSAT;
        public string ITIMBRADOSELLOSAT
        {
            get
            {
                return this.iTIMBRADOSELLOSAT;
            }
            set
            {
                this.iTIMBRADOSELLOSAT = value;
                this.isnull["ITIMBRADOSELLOSAT"] = false;
            }
        }

        private string iTIMBRADOSELLOCFDI;
        public string ITIMBRADOSELLOCFDI
        {
            get
            {
                return this.iTIMBRADOSELLOCFDI;
            }
            set
            {
                this.iTIMBRADOSELLOCFDI = value;
                this.isnull["ITIMBRADOSELLOCFDI"] = false;
            }
        }



        private string iSERIESAT;
        public string ISERIESAT
        {
            get
            {
                return this.iSERIESAT;
            }
            set
            {
                this.iSERIESAT = value;
                this.isnull["ISERIESAT"] = false;
            }
        }


        private int iFOLIOSAT;
        public int IFOLIOSAT
        {
            get
            {
                return this.iFOLIOSAT;
            }
            set
            {
                this.iFOLIOSAT = value;
                this.isnull["IFOLIOSAT"] = false;
            }
        }


        public CDOCTOCOMPROBANTEBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("IDOCTOID", true);


            isnull.Add("ITIPOCOMPROBANTE", true);


            isnull.Add("ITIMBRADOUUID", true);


            isnull.Add("ITIMBRADOFECHA", true);


            isnull.Add("ITIMBRADOCERTSAT", true);


            isnull.Add("ITIMBRADOSELLOSAT", true);


            isnull.Add("ITIMBRADOSELLOCFDI", true);


            isnull.Add("IFOLIOSAT", true);


            isnull.Add("ISERIESAT", true);

        }



    }
}
