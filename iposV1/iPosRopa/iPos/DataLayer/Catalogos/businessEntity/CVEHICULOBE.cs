
using System;
using System.Collections;

namespace iPosBusinessEntity
{
    public class CVEHICULOBE
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

        private long iSAT_TIPOPERMISOID;
        public long ISAT_TIPOPERMISOID
        {
            get
            {
                return this.iSAT_TIPOPERMISOID;
            }
            set
            {
                this.iSAT_TIPOPERMISOID = value;
                this.isnull["ISAT_TIPOPERMISOID"] = false;
            }
        }

        private string iNUMPERMISOSCT;
        public string INUMPERMISOSCT
        {
            get
            {
                return this.iNUMPERMISOSCT;
            }
            set
            {
                this.iNUMPERMISOSCT = value;
                this.isnull["INUMPERMISOSCT"] = false;
            }
        }

        private long iSAT_CONFIGAUTOTRANSPORTEID;
        public long ISAT_CONFIGAUTOTRANSPORTEID
        {
            get
            {
                return this.iSAT_CONFIGAUTOTRANSPORTEID;
            }
            set
            {
                this.iSAT_CONFIGAUTOTRANSPORTEID = value;
                this.isnull["ISAT_CONFIGAUTOTRANSPORTEID"] = false;
            }
        }

        private string iPLACAVM;
        public string IPLACAVM
        {
            get
            {
                return this.iPLACAVM;
            }
            set
            {
                this.iPLACAVM = value;
                this.isnull["IPLACAVM"] = false;
            }
        }

        private string iANIOMODELOVM;
        public string IANIOMODELOVM
        {
            get
            {
                return this.iANIOMODELOVM;
            }
            set
            {
                this.iANIOMODELOVM = value;
                this.isnull["IANIOMODELOVM"] = false;
            }
        }

        private string iASEGURARESPCIVIL;
        public string IASEGURARESPCIVIL
        {
            get
            {
                return this.iASEGURARESPCIVIL;
            }
            set
            {
                this.iASEGURARESPCIVIL = value;
                this.isnull["IASEGURARESPCIVIL"] = false;
            }
        }

        private string iPOLIZARESPCIVIL;
        public string IPOLIZARESPCIVIL
        {
            get
            {
                return this.iPOLIZARESPCIVIL;
            }
            set
            {
                this.iPOLIZARESPCIVIL = value;
                this.isnull["IPOLIZARESPCIVIL"] = false;
            }
        }

        private string iASEGURAMEDAMBIENTE;
        public string IASEGURAMEDAMBIENTE
        {
            get
            {
                return this.iASEGURAMEDAMBIENTE;
            }
            set
            {
                this.iASEGURAMEDAMBIENTE = value;
                this.isnull["IASEGURAMEDAMBIENTE"] = false;
            }
        }

        private string iPOLIZAMEDAMBIENTE;
        public string IPOLIZAMEDAMBIENTE
        {
            get
            {
                return this.iPOLIZAMEDAMBIENTE;
            }
            set
            {
                this.iPOLIZAMEDAMBIENTE = value;
                this.isnull["IPOLIZAMEDAMBIENTE"] = false;
            }
        }

        private string iASEGURACARGA;
        public string IASEGURACARGA
        {
            get
            {
                return this.iASEGURACARGA;
            }
            set
            {
                this.iASEGURACARGA = value;
                this.isnull["IASEGURACARGA"] = false;
            }
        }

        private string iPOLIZACARGA;
        public string IPOLIZACARGA
        {
            get
            {
                return this.iPOLIZACARGA;
            }
            set
            {
                this.iPOLIZACARGA = value;
                this.isnull["IPOLIZACARGA"] = false;
            }
        }

        private string iPRIMASEGURO;
        public string IPRIMASEGURO
        {
            get
            {
                return this.iPRIMASEGURO;
            }
            set
            {
                this.iPRIMASEGURO = value;
                this.isnull["IPRIMASEGURO"] = false;
            }
        }

        private long iSAT_SUBTIPOREM1ID;
        public long ISAT_SUBTIPOREM1ID
        {
            get
            {
                return this.iSAT_SUBTIPOREM1ID;
            }
            set
            {
                this.iSAT_SUBTIPOREM1ID = value;
                this.isnull["ISAT_SUBTIPOREM1ID"] = false;
            }
        }

        private string iPLACA1;
        public string IPLACA1
        {
            get
            {
                return this.iPLACA1;
            }
            set
            {
                this.iPLACA1 = value;
                this.isnull["IPLACA1"] = false;
            }
        }

        private long iSAT_SUBTIPOREM2ID;
        public long ISAT_SUBTIPOREM2ID
        {
            get
            {
                return this.iSAT_SUBTIPOREM2ID;
            }
            set
            {
                this.iSAT_SUBTIPOREM2ID = value;
                this.isnull["ISAT_SUBTIPOREM2ID"] = false;
            }
        }

        private string iPLACA2;
        public string IPLACA2
        {
            get
            {
                return this.iPLACA2;
            }
            set
            {
                this.iPLACA2 = value;
                this.isnull["IPLACA2"] = false;
            }
        }


        private long iDUENIOID;
        public long IDUENIOID
        {
            get
            {
                return this.iDUENIOID;
            }
            set
            {
                this.iDUENIOID = value;
                this.isnull["IDUENIOID"] = false;
            }
        }


        private long iPESOBRUTOVEHICULAR;
        public long IPESOBRUTOVEHICULAR
        {
            get
            {
                return this.iPESOBRUTOVEHICULAR;
            }
            set
            {
                this.iPESOBRUTOVEHICULAR = value;
                this.isnull["IPESOBRUTOVEHICULAR"] = false;
            }
        }

        public CVEHICULOBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("ISAT_TIPOPERMISOID", true);


            isnull.Add("INUMPERMISOSCT", true);


            isnull.Add("ISAT_CONFIGAUTOTRANSPORTEID", true);


            isnull.Add("IPLACAVM", true);


            isnull.Add("IANIOMODELOVM", true);


            isnull.Add("IASEGURARESPCIVIL", true);


            isnull.Add("IPOLIZARESPCIVIL", true);


            isnull.Add("IASEGURAMEDAMBIENTE", true);


            isnull.Add("IPOLIZAMEDAMBIENTE", true);


            isnull.Add("IASEGURACARGA", true);


            isnull.Add("IPOLIZACARGA", true);


            isnull.Add("IPRIMASEGURO", true);


            isnull.Add("ISAT_SUBTIPOREM1ID", true);


            isnull.Add("IPLACA1", true);


            isnull.Add("ISAT_SUBTIPOREM2ID", true);


            isnull.Add("IPLACA2", true);


            isnull.Add("IDUENIOID", true);

            isnull.Add("IPESOBRUTOVEHICULAR", true);

        }



    }
}
