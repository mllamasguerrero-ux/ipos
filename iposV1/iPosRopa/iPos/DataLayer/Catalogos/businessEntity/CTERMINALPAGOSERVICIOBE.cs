using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CTERMINALPAGOSERVICIOBE
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

        private string iTERMINAL;
        public string ITERMINAL
        {
            get
            {
                return this.iTERMINAL;
            }
            set
            {
                this.iTERMINAL = value;
                this.isnull["ITERMINAL"] = false;
            }
        }

        private string iSUCURSALCLAVE;
        public string ISUCURSALCLAVE
        {
            get
            {
                return this.iSUCURSALCLAVE;
            }
            set
            {
                this.iSUCURSALCLAVE = value;
                this.isnull["ISUCURSALCLAVE"] = false;
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

        private long iCONSECUTIVO;
        public long ICONSECUTIVO
        {
            get
            {
                return this.iCONSECUTIVO;
            }
            set
            {
                this.iCONSECUTIVO = value;
                this.isnull["ICONSECUTIVO"] = false;
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

        public CTERMINALPAGOSERVICIOBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("ITERMINAL", true);


            isnull.Add("ISUCURSALCLAVE", true);


            isnull.Add("ISUCURSALID", true);


            isnull.Add("ICONSECUTIVO", true);


            isnull.Add("ESSERVICIO", true);
        }



    }
}
