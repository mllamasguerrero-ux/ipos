
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CARCHIVOSADJUNTOSBE
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

        private int iHORASDETRABAJO;
        public int IHORASDETRABAJO
        {
            get
            {
                return this.iHORASDETRABAJO;
            }
            set
            {
                this.iHORASDETRABAJO = value;
                this.isnull["IHORASDETRABAJO"] = false;
            }
        }

        private DateTime iFECHADECREACION;
        public DateTime IFECHADECREACION
        {
            get
            {
                return this.iFECHADECREACION;
            }
            set
            {
                this.iFECHADECREACION = value;
                this.isnull["IFECHADECREACION"] = false;
            }
        }

        private DateTime iFECHA;
        public DateTime IFECHA
        {
            get
            {
                return this.iFECHA;
            }
            set
            {
                this.iFECHA = value;
                this.isnull["IFECHA"] = false;
            }
        }

        private string iRUTAARCHIVO;
        public string IRUTAARCHIVO
        {
            get
            {
                return this.iRUTAARCHIVO;
            }
            set
            {
                this.iRUTAARCHIVO = value;
                this.isnull["IRUTAARCHIVO"] = false;
            }
        }

        private string iNOMBREARCHIVO;
        public string INOMBREARCHIVO
        {
            get
            {
                return this.iNOMBREARCHIVO;
            }
            set
            {
                this.iNOMBREARCHIVO = value;
                this.isnull["INOMBREARCHIVO"] = false;
            }
        }

        public CARCHIVOSADJUNTOSBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("IDOCTOID", true);


            isnull.Add("IHORASDETRABAJO", true);


            isnull.Add("IFECHADECREACION", true);


            isnull.Add("IFECHA", true);


            isnull.Add("IRUTAARCHIVO", true);


            isnull.Add("INOMBREARCHIVO", true);

        }



    }
}
