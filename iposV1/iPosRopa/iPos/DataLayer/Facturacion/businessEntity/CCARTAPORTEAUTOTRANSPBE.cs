
using Newtonsoft.Json;
using System;
using System.Collections;

namespace iPosBusinessEntity
{
    public class CCARTAPORTEAUTOTRANSPBE
    {
        [JsonIgnore]
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

        private string iPERMSCT;
        public string IPERMSCT
        {
            get
            {
                return this.iPERMSCT;
            }
            set
            {
                this.iPERMSCT = value;
                this.isnull["IPERMSCT"] = false;
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

        private string iCONFIGVEHICULAR;
        public string ICONFIGVEHICULAR
        {
            get
            {
                return this.iCONFIGVEHICULAR;
            }
            set
            {
                this.iCONFIGVEHICULAR = value;
                this.isnull["ICONFIGVEHICULAR"] = false;
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

        private string iSUBTIPOREM1;
        public string ISUBTIPOREM1
        {
            get
            {
                return this.iSUBTIPOREM1;
            }
            set
            {
                this.iSUBTIPOREM1 = value;
                this.isnull["ISUBTIPOREM1"] = false;
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

        private string iSUBTIPOREM2;
        public string ISUBTIPOREM2
        {
            get
            {
                return this.iSUBTIPOREM2;
            }
            set
            {
                this.iSUBTIPOREM2 = value;
                this.isnull["ISUBTIPOREM2"] = false;
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


        private string iPESOBRUTOVEHICULAR;
        public string IPESOBRUTOVEHICULAR
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


        public void FillFromCartaPorteLinea(CCARTAPORTELINEABE line)
        {

            if (!(bool)line.isnull["IPERMSCT"])
                this.IPERMSCT = line.IPERMSCT;

            if (!(bool)line.isnull["INUMPERMISOSCT"])
                this.INUMPERMISOSCT = line.INUMPERMISOSCT;

            if (!(bool)line.isnull["ICONFIGVEHICULAR"])
                this.ICONFIGVEHICULAR = line.ICONFIGVEHICULAR;

            if (!(bool)line.isnull["IPLACAVM"])
                this.IPLACAVM = line.IPLACAVM;

            if (!(bool)line.isnull["IANIOMODELOVM"])
                this.IANIOMODELOVM = line.IANIOMODELOVM;

            if (!(bool)line.isnull["IASEGURARESPCIVIL"])
                this.IASEGURARESPCIVIL = line.IASEGURARESPCIVIL;

            if (!(bool)line.isnull["IPOLIZARESPCIVIL"])
                this.IPOLIZARESPCIVIL = line.IPOLIZARESPCIVIL;

            if (!(bool)line.isnull["IASEGURAMEDAMBIENTE"])
                this.IASEGURAMEDAMBIENTE = line.IASEGURAMEDAMBIENTE;

            if (!(bool)line.isnull["IPOLIZAMEDAMBIENTE"])
                this.IPOLIZAMEDAMBIENTE = line.IPOLIZAMEDAMBIENTE;

            if (!(bool)line.isnull["IASEGURACARGA"])
                this.IASEGURACARGA = line.IASEGURACARGA;

            if (!(bool)line.isnull["IPOLIZACARGA"])
                this.IPOLIZACARGA = line.IPOLIZACARGA;

            if (!(bool)line.isnull["IPRIMASEGURO"])
                this.IPRIMASEGURO = line.IPRIMASEGURO;

            if (!(bool)line.isnull["ISUBTIPOREM1"])
                this.ISUBTIPOREM1 = line.ISUBTIPOREM1;

            if (!(bool)line.isnull["IPLACA1"])
                this.IPLACA1 = line.IPLACA1;

            if (!(bool)line.isnull["ISUBTIPOREM2"])
                this.ISUBTIPOREM2 = line.ISUBTIPOREM2;

            if (!(bool)line.isnull["IPLACA2"])
                this.IPLACA2 = line.IPLACA2;

            if (!(bool)line.isnull["IPESOBRUTOVEHICULAR"])
                this.IPESOBRUTOVEHICULAR = line.IPESOBRUTOVEHICULAR.ToString("D");
            
        }



        public CCARTAPORTEAUTOTRANSPBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("IPERMSCT", true);


            isnull.Add("INUMPERMISOSCT", true);


            isnull.Add("ICONFIGVEHICULAR", true);


            isnull.Add("IPLACAVM", true);


            isnull.Add("IANIOMODELOVM", true);


            isnull.Add("IASEGURARESPCIVIL", true);


            isnull.Add("IPOLIZARESPCIVIL", true);


            isnull.Add("IASEGURAMEDAMBIENTE", true);


            isnull.Add("IPOLIZAMEDAMBIENTE", true);


            isnull.Add("IASEGURACARGA", true);


            isnull.Add("IPOLIZACARGA", true);


            isnull.Add("IPRIMASEGURO", true);


            isnull.Add("ISUBTIPOREM1", true);


            isnull.Add("IPLACA1", true);


            isnull.Add("ISUBTIPOREM2", true);


            isnull.Add("IPLACA2", true);

        }



    }
}
