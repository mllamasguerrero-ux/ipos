
using System;
using System.Collections;

namespace iPosBusinessEntity
{
    public class CPAGODOCTOSATBE
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

        private long iDOCTOPAGOID;
        public long IDOCTOPAGOID
        {
            get
            {
                return this.iDOCTOPAGOID;
            }
            set
            {
                this.iDOCTOPAGOID = value;
                this.isnull["IDOCTOPAGOID"] = false;
            }
        }

        private long iPAGOSATID;
        public long IPAGOSATID
        {
            get
            {
                return this.iPAGOSATID;
            }
            set
            {
                this.iPAGOSATID = value;
                this.isnull["IPAGOSATID"] = false;
            }
        }

        private string iIDDOCUMENTO;
        public string IIDDOCUMENTO
        {
            get
            {
                return this.iIDDOCUMENTO;
            }
            set
            {
                this.iIDDOCUMENTO = value;
                this.isnull["IIDDOCUMENTO"] = false;
            }
        }

        private string iSERIE;
        public string ISERIE
        {
            get
            {
                return this.iSERIE;
            }
            set
            {
                this.iSERIE = value;
                this.isnull["ISERIE"] = false;
            }
        }

        private string iFOLIO;
        public string IFOLIO
        {
            get
            {
                return this.iFOLIO;
            }
            set
            {
                this.iFOLIO = value;
                this.isnull["IFOLIO"] = false;
            }
        }

        private string iMONEDADR;
        public string IMONEDADR
        {
            get
            {
                return this.iMONEDADR;
            }
            set
            {
                this.iMONEDADR = value;
                this.isnull["IMONEDADR"] = false;
            }
        }

        private string iTIPOCAMBIODR;
        public string ITIPOCAMBIODR
        {
            get
            {
                return this.iTIPOCAMBIODR;
            }
            set
            {
                this.iTIPOCAMBIODR = value;
                this.isnull["ITIPOCAMBIODR"] = false;
            }
        }

        private string iMETODODEPAGODR;
        public string IMETODODEPAGODR
        {
            get
            {
                return this.iMETODODEPAGODR;
            }
            set
            {
                this.iMETODODEPAGODR = value;
                this.isnull["IMETODODEPAGODR"] = false;
            }
        }

        private int iNUMPARCIALIDAD;
        public int INUMPARCIALIDAD
        {
            get
            {
                return this.iNUMPARCIALIDAD;
            }
            set
            {
                this.iNUMPARCIALIDAD = value;
                this.isnull["INUMPARCIALIDAD"] = false;
            }
        }

        private decimal iIMPSALDOANT;
        public decimal IIMPSALDOANT
        {
            get
            {
                return this.iIMPSALDOANT;
            }
            set
            {
                this.iIMPSALDOANT = value;
                this.isnull["IIMPSALDOANT"] = false;
            }
        }

        private decimal iIMPPAGADO;
        public decimal IIMPPAGADO
        {
            get
            {
                return this.iIMPPAGADO;
            }
            set
            {
                this.iIMPPAGADO = value;
                this.isnull["IIMPPAGADO"] = false;
            }
        }

        private decimal iIMPSALDOINSOLUTO;
        public decimal IIMPSALDOINSOLUTO
        {
            get
            {
                return this.iIMPSALDOINSOLUTO;
            }
            set
            {
                this.iIMPSALDOINSOLUTO = value;
                this.isnull["IIMPSALDOINSOLUTO"] = false;
            }
        }


        private string iOBJETOIMPDR;
        public string IOBJETOIMPDR
        {
            get
            {
                return this.iOBJETOIMPDR;
            }
            set
            {
                this.iOBJETOIMPDR = value;
                this.isnull["IOBJETOIMPDR"] = false;
            }
        }


        public CPAGODOCTOSATBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("IDOCTOPAGOID", true);


            isnull.Add("IPAGOSATID", true);


            isnull.Add("IIDDOCUMENTO", true);


            isnull.Add("ISERIE", true);


            isnull.Add("IFOLIO", true);


            isnull.Add("IMONEDADR", true);


            isnull.Add("ITIPOCAMBIODR", true);


            isnull.Add("IMETODODEPAGODR", true);


            isnull.Add("INUMPARCIALIDAD", true);


            isnull.Add("IIMPSALDOANT", true);


            isnull.Add("IIMPPAGADO", true);


            isnull.Add("IIMPSALDOINSOLUTO", true);

            isnull.Add("IOBJETOIMPDR", true);

        }



    }
}
