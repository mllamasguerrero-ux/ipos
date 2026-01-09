using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPosBusinessEntity
{
    public class CEMIDARESPCODEBE
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

        private int iCODIGO;
        public int ICODIGO
        {
            get
            {
                return this.iCODIGO;
            }
            set
            {
                this.iCODIGO = value;
                this.isnull["ICODIGO"] = false;
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

        private string iNOTAS;
        public string INOTAS
        {
            get
            {
                return this.iNOTAS;
            }
            set
            {
                this.iNOTAS = value;
                this.isnull["INOTAS"] = false;
            }
        }

        private string iMENSAJECLIENTE;
        public string IMENSAJECLIENTE
        {
            get
            {
                return this.iMENSAJECLIENTE;
            }
            set
            {
                this.iMENSAJECLIENTE = value;
                this.isnull["IMENSAJECLIENTE"] = false;
            }
        }

        public CEMIDARESPCODEBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("ICODIGO", true);


            isnull.Add("IDESCRIPCION", true);


            isnull.Add("INOTAS", true);

            isnull.Add("IMENSAJECLIENTE", true);
        }
    }
}
