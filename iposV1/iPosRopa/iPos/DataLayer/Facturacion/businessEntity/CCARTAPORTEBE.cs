
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;

namespace iPosBusinessEntity
{
    public class CCARTAPORTEBE
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

        private string iTRANSPINTERNAC;
        public string ITRANSPINTERNAC
        {
            get
            {
                return this.iTRANSPINTERNAC;
            }
            set
            {
                this.iTRANSPINTERNAC = value;
                this.isnull["ITRANSPINTERNAC"] = false;
            }
        }

        private string iENTRADASALIDAMERC;
        public string IENTRADASALIDAMERC
        {
            get
            {
                return this.iENTRADASALIDAMERC;
            }
            set
            {
                this.iENTRADASALIDAMERC = value;
                this.isnull["IENTRADASALIDAMERC"] = false;
            }
        }

        private string iPAISORIGENDESTINO;
        public string IPAISORIGENDESTINO
        {
            get
            {
                return this.iPAISORIGENDESTINO;
            }
            set
            {
                this.iPAISORIGENDESTINO = value;
                this.isnull["IPAISORIGENDESTINO"] = false;
            }
        }

        private string iVIAENTRADASALIDA;
        public string IVIAENTRADASALIDA
        {
            get
            {
                return this.iVIAENTRADASALIDA;
            }
            set
            {
                this.iVIAENTRADASALIDA = value;
                this.isnull["IVIAENTRADASALIDA"] = false;
            }
        }

        private string iTOTALDISTREC;
        public string ITOTALDISTREC
        {
            get
            {
                return this.iTOTALDISTREC;
            }
            set
            {
                this.iTOTALDISTREC = value;
                this.isnull["ITOTALDISTREC"] = false;
            }
        }


        




        public List<CCARTAPORTEUBICACIONBE> iCARTAPORTEUBICACIONList;
        public List<CCARTAPORTEUBICACIONBE> ICARTAPORTEUBICACIONList
        {
            get
            {
                return this.iCARTAPORTEUBICACIONList;
            }
            set
            {
                this.iCARTAPORTEUBICACIONList = value;
            }
        }



        public CCARTAPORTEAUTOTRANSPBE iCCARTAPORTEAUTOTRANSPBE;
        public CCARTAPORTEAUTOTRANSPBE ICCARTAPORTEAUTOTRANSPBE
        {
            get
            {
                return this.iCCARTAPORTEAUTOTRANSPBE;
            }
            set
            {
                this.iCCARTAPORTEAUTOTRANSPBE = value;
            }
        }


        public CCARTAPORTETOTALMERCANCIASBE iCARTAPORTETOTALMERCANCIAS;
        public CCARTAPORTETOTALMERCANCIASBE ICARTAPORTETOTALMERCANCIAS
        {
            get
            {
                return this.iCARTAPORTETOTALMERCANCIAS;
            }
            set
            {
                this.iCARTAPORTETOTALMERCANCIAS = value;
            }
        }

        public List<CCARTAPORTEMERCANCIABE> iCARTAPORTEMERCANCIAList;
        public List<CCARTAPORTEMERCANCIABE> ICARTAPORTEMERCANCIAList
        {
            get
            {
                return this.iCARTAPORTEMERCANCIAList;
            }
            set
            {
                this.iCARTAPORTEMERCANCIAList = value;
            }
        }


        public CCARTAPORTECANTTRANSPBE iCARTAPORTECANTTRANSP;
        public CCARTAPORTECANTTRANSPBE ICARTAPORTECANTTRANSP
        {
            get
            {
                return this.iCARTAPORTECANTTRANSP;
            }
            set
            {
                this.iCARTAPORTECANTTRANSP = value;
            }
        }



        public List<CCARTAPORTETRANSPTIPOFIGURABE> iCARTAPORTETRANSPTIPOFIGURAList;
        public List<CCARTAPORTETRANSPTIPOFIGURABE> ICARTAPORTETRANSPTIPOFIGURAList
        {
            get
            {
                return this.iCARTAPORTETRANSPTIPOFIGURAList;
            }
            set
            {
                this.iCARTAPORTETRANSPTIPOFIGURAList = value;
            }
        }


        public CCARTAPORTEAUTOTRANSPBE iCARTAPORTEAUTOTRANSPBE;
        public CCARTAPORTEAUTOTRANSPBE ICARTAPORTEAUTOTRANSPBE
        {
            get
            {
                return this.iCARTAPORTEAUTOTRANSPBE;
            }
            set
            {
                this.iCARTAPORTEAUTOTRANSPBE = value;
            }
        }



        private string iIDCCP;
        public string IIDCCP
        {
            get
            {
                return this.iIDCCP;
            }
            set
            {
                this.iIDCCP = value;
                this.isnull["IIDCCP"] = false;
            }
        }

        private string iREGISTROITSMO;
        public string IREGISTROITSMO
        {
            get
            {
                return this.iREGISTROITSMO;
            }
            set
            {
                this.iREGISTROITSMO = value;
                this.isnull["IREGISTROITSMO"] = false;
            }
        }

        private string iUBICACIONPOLOORIGEN;
        public string IUBICACIONPOLOORIGEN
        {
            get
            {
                return this.iUBICACIONPOLOORIGEN;
            }
            set
            {
                this.iUBICACIONPOLOORIGEN = value;
                this.isnull["IUBICACIONPOLOORIGEN"] = false;
            }
        }

        private string iUBICACIONPOLODESTINO;
        public string IUBICACIONPOLODESTINO
        {
            get
            {
                return this.iUBICACIONPOLODESTINO;
            }
            set
            {
                this.iUBICACIONPOLODESTINO = value;
                this.isnull["IUBICACIONPOLODESTINO"] = false;
            }
        }

        public void FillFromCartaPorteLinea(CCARTAPORTELINEABE line)
        {

            if (!(bool)line.isnull["ITRANSPINTERNAC"])
                this.ITRANSPINTERNAC = line.ITRANSPINTERNAC;

            if (!(bool)line.isnull["IENTRADASALIDAMERC"])
                this.IENTRADASALIDAMERC = line.IENTRADASALIDAMERC;

            if (!(bool)line.isnull["IPAISORIGENDESTINO"])
                this.IPAISORIGENDESTINO = line.IPAISORIGENDESTINO;

            if (!(bool)line.isnull["IVIAENTRADASALIDA"])
                this.IVIAENTRADASALIDA = line.IVIAENTRADASALIDA;

            if (!(bool)line.isnull["ITOTALDISTREC"])
                this.ITOTALDISTREC = line.ITOTALDISTREC;
            
            this.IIDCCP = GenerarIDCCP();

        }


        public CCARTAPORTEBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("ITRANSPINTERNAC", true);


            isnull.Add("IENTRADASALIDAMERC", true);


            isnull.Add("IPAISORIGENDESTINO", true);


            isnull.Add("IVIAENTRADASALIDA", true);


            isnull.Add("ITOTALDISTREC", true);

            isnull.Add("IIDCCP", true);
            isnull.Add("IREGISTROITSMO", true);
            isnull.Add("IUBICACIONPOLOORIGEN", true);
            isnull.Add("IUBICACIONPOLODESTINO", true);

        }

        public string GenerarIDCCP()
        {
            // 1. Genera un Guid estándar
            Guid myGuid = Guid.NewGuid();

            string cccGuid = "CCC"  + myGuid.ToString().Substring(3);

            return cccGuid;
        }



    }
}
