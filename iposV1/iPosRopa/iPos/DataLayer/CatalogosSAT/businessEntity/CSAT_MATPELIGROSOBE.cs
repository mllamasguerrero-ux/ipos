
using System;
using System.Collections;

namespace iPosBusinessEntity
{
    public class CSAT_MATPELIGROSOBE
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

        private string iDESCRIPCION;
        public string IDESCRIPCION
        {
            get
            {
                return this.iDESCRIPCION;
            }
            set
            {
                this.iDESCRIPCION = value;
                this.isnull["IDESCRIPCION"] = false;
            }
        }

        private string iCLASE;
        public string ICLASE
        {
            get
            {
                return this.iCLASE;
            }
            set
            {
                this.iCLASE = value;
                this.isnull["ICLASE"] = false;
            }
        }

        private string iPELIGRO_SECUNDARIO;
        public string IPELIGRO_SECUNDARIO
        {
            get
            {
                return this.iPELIGRO_SECUNDARIO;
            }
            set
            {
                this.iPELIGRO_SECUNDARIO = value;
                this.isnull["IPELIGRO_SECUNDARIO"] = false;
            }
        }

        private string iNOMBRE_TECNICO;
        public string INOMBRE_TECNICO
        {
            get
            {
                return this.iNOMBRE_TECNICO;
            }
            set
            {
                this.iNOMBRE_TECNICO = value;
                this.isnull["INOMBRE_TECNICO"] = false;
            }
        }

        private DateTime iFECHAINICIO;
        public DateTime IFECHAINICIO
        {
            get
            {
                return this.iFECHAINICIO;
            }
            set
            {
                this.iFECHAINICIO = value;
                this.isnull["IFECHAINICIO"] = false;
            }
        }

        private DateTime iFECHAFIN;
        public DateTime IFECHAFIN
        {
            get
            {
                return this.iFECHAFIN;
            }
            set
            {
                this.iFECHAFIN = value;
                this.isnull["IFECHAFIN"] = false;
            }
        }

        public CSAT_MATPELIGROSOBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("ICLAVE", true);


            isnull.Add("IDESCRIPCION", true);


            isnull.Add("ICLASE", true);


            isnull.Add("IPELIGRO_SECUNDARIO", true);


            isnull.Add("INOMBRE_TECNICO", true);


            isnull.Add("IFECHAINICIO", true);


            isnull.Add("IFECHAFIN", true);

        }



    }
}
