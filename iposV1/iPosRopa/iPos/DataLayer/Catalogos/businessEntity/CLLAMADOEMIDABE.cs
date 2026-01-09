using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Catalogos.businessEntity
{
    public class CLLAMADOEMIDABE
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

        private string iOPERACION;
        public string IOPERACION
        {
            get
            {
                return this.iOPERACION;
            }
            set
            {
                this.iOPERACION = value;
                this.isnull["IOPERACION"] = false;
            }
        }

        private long iEMIDAREQUESTID;
        public long IEMIDAREQUESTID
        {
            get
            {
                return this.iEMIDAREQUESTID;
            }
            set
            {
                this.iEMIDAREQUESTID = value;
                this.isnull["IEMIDAREQUESTID"] = false;
            }
        }

        private string iREFERENCIA;
        public string IREFERENCIA
        {
            get
            {
                return this.iREFERENCIA;
            }
            set
            {
                this.iREFERENCIA = value;
                this.isnull["IREFERENCIA"] = false;
            }
        }

        private long iSUCURSALID;
        public long ISUCURSALID
        {
            get
            {
                return this.iSUCURSALID;
            }
            set
            {
                this.iSUCURSALID = value;
                this.isnull["ISUCURSALID"] = false;
            }
        }

        private long iUSUARIOID;
        public long IUSUARIOID
        {
            get
            {
                return this.iUSUARIOID;
            }
            set
            {
                this.iUSUARIOID = value;
                this.isnull["IUSUARIOID"] = false;
            }
        }

        private long iTERMINALID;
        public long ITERMINALID
        {
            get
            {
                return this.iTERMINALID;
            }
            set
            {
                this.iTERMINALID = value;
                this.isnull["ITERMINALID"] = false;
            }
        }

        private DateTime iINICIO;
        public DateTime IINICIO
        {
            get
            {
                return this.iINICIO;
            }
            set
            {
                this.iINICIO = value;
                this.isnull["IINICIO"] = false;
            }
        }

        private DateTime iFIN;
        public DateTime IFIN
        {
            get
            {
                return this.iFIN;
            }
            set
            {
                this.iFIN = value;
                this.isnull["IFIN"] = false;
            }
        }

        private int iDURACION;
        public int IDURACION
        {
            get
            {
                return this.iDURACION;
            }
            set
            {
                this.iDURACION = value;
                this.isnull["IDURACION"] = false;
            }
        }


        private string iRESPONSECODE;
        public string IRESPONSECODE
        {
            get
            {
                return this.iRESPONSECODE;
            }
            set
            {
                this.iRESPONSECODE = value;
                this.isnull["IRESPONSECODE"] = false;
            }
        }

        private string iPIN;
        public string IPIN
        {
            get
            {
                return this.iPIN;
            }
            set
            {
                this.iPIN = value;
                this.isnull["IPIN"] = false;
            }
        }



        public CLLAMADOEMIDABE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("IOPERACION", true);


            isnull.Add("IEMIDAREQUESTID", true);


            isnull.Add("IREFERENCIA", true);


            isnull.Add("ISUCURSALID", true);


            isnull.Add("IUSUARIOID", true);


            isnull.Add("ITERMINALID", true);


            isnull.Add("IINICIO", true);


            isnull.Add("IFIN", true);


            isnull.Add("IDURACION", true);


            isnull.Add("IRESPONSECODE", true);


            isnull.Add("IPIN", true);

        }

    }
}
