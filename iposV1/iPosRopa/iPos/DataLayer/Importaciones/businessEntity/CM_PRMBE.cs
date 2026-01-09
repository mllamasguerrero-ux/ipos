using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CM_PRMBE
    {
        public Hashtable isnull;

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

        private string iNOMBRE;
        public string INOMBRE
        {
            get
            {
                return this.iNOMBRE;
            }
            set
            {
                this.iNOMBRE = value;
                this.isnull["INOMBRE"] = false;
            }
        }
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

        private DateTime iID_FECHA;
        public DateTime IID_FECHA
        {
            get
            {
                return this.iID_FECHA;
            }
            set
            {
                this.iID_FECHA = value;
                this.isnull["IID_FECHA"] = false;
            }
        }

        private string iID_HORA;
        public string IID_HORA
        {
            get
            {
                return this.iID_HORA;
            }
            set
            {
                this.iID_HORA = value;
                this.isnull["IID_HORA"] = false;
            }
        }

        private string iDESCRIP;
        public string IDESCRIP
        {
            get
            {
                return this.iDESCRIP;
            }
            set
            {
                this.iDESCRIP = value;
                this.isnull["IDESCRIP"] = false;
            }
        }

        private string iSUCURSAL;
        public string ISUCURSAL
        {
            get { return iSUCURSAL; }
            set { iSUCURSAL = value; this.isnull["ISUCURSAL"] = false; }
        }

        private decimal iCANTIDAD;
        public decimal ICANTIDAD
        {
            get { return iCANTIDAD; }
            set { iCANTIDAD = value; this.isnull["ICANTIDAD"] = false; }
        }

        private string iPRODUCTO;
        public string IPRODUCTO
        {
            get { return iPRODUCTO; }
            set { iPRODUCTO = value; isnull["IPRODUCTO"] = false; }
        }

        private decimal iUTILIDAD;
        public decimal IUTILIDAD
        {
            get { return iUTILIDAD; }
            set { iUTILIDAD = value; isnull["IUTILIDAD"] = false; }
        }

        private decimal iCANTLLEV;
        public decimal ICANTLLEV
        {
            get { return iCANTLLEV; }
            set { iCANTLLEV = value; isnull["ICANTLLEV"] = false; }
        }

        private decimal iIMPORTE;
        public decimal IIMPORTE
        {
            get { return iIMPORTE; }
            set { iIMPORTE = value; isnull["IIMPORTE"] = false; }
        }

        private decimal iPORCDESC;
        public decimal IPORCDESC
        {
            get { return iPORCDESC; }
            set { iPORCDESC = value; isnull["IPORCDESC"] = false; }
        }

        private string iTIPOPROM;
        public string ITIPOPROM
        {
            get { return iTIPOPROM; }
            set { iTIPOPROM = value; isnull["ITIPOPROM"] = false; }
        }

        private string iRANGPROM;
        public string IRANGPROM
        {
            get { return iRANGPROM; }
            set { iRANGPROM = value; isnull["IRANGPROM"] = false; }
        }

        private string iLINEA;

        public string ILINEA
        {
            get { return iLINEA; }
            set { iLINEA = value; isnull["ILINEA"] = false; }
        }

        private DateTime iFECHAINI;
        public DateTime IFECHAINI
        {
            get { return iFECHAINI; }
            set { iFECHAINI = value; isnull["IFECHAINI"] = false; }
        }

        private DateTime iFECHAFIN;
        public DateTime IFECHAFIN
        {
            get { return iFECHAFIN; }
            set { iFECHAFIN = value; isnull["IFECHAFIN"] = false; }
        }

        private string iLUNES;
        public string ILUNES
        {
            get { return iLUNES; }
            set { iLUNES = value; isnull["ILUNES"] = false; }
        }

        private string iMARTES;
        public string IMARTES
        {
            get { return iMARTES; }
            set { iMARTES = value; isnull["IMARTES"] = false; }
        }

        private string iMIERCOLES;
        public string IMIERCOLES
        {
            get { return iMIERCOLES; }
            set { iMIERCOLES = value; isnull["IMIERCOLES"] = false; }
        }

        private string iJUEVES;
        public string IJUEVES
        {
            get { return iJUEVES; }
            set { iJUEVES = value; isnull["IJUEVES"] = false; }
        }

        private string iVIERNES;
        public string IVIERNES
        {
            get { return iVIERNES; }
            set { iVIERNES = value; isnull["IVIERNES"] = false; }
        }

        private string iSABADO;
        public string ISABADO
        {
            get { return iSABADO; }
            set { iSABADO = value; isnull["ISABADO"] = false; }
        }

        private string iDOMINGO;
        public string IDOMINGO
        {
            get { return iDOMINGO; }
            set { iDOMINGO = value; isnull["IDOMINGO"] = false; }
        }

        private decimal iPORIMPO;
        public decimal IPORIMPO
        {
            get { return iPORIMPO; }
            set { iPORIMPO = value; isnull["IPORIMPO"] = false; }
        }

        private string iMONEDERO;
        public string IMONEDERO
        {
            get { return iMONEDERO; }
            set { iMONEDERO = value; isnull["IMONEDERO"] = false; }
        }

        private string iACTIVO;
        public string IACTIVO
        {
            get { return iACTIVO; }
            set { iACTIVO = value; isnull["IACTIVO"] = false; }
        }


        private string iMULTDET;
        public string IMULTDET
        {
            get { return iMULTDET; }
            set { iMULTDET = value; isnull["IMULTDET"] = false; }
        }


        private string iDESCMTD;
        public string IDESCMTD
        {
            get { return iDESCMTD; }
            set { iDESCMTD = value; isnull["IDESCMTD"] = false; }
        }


        public CM_PRMBE()
        {
            isnull = new Hashtable();

            isnull.Add("ICLAVE", true);

            isnull.Add("INOMBRE", true);

            isnull.Add("IID", true);

            isnull.Add("IID_FECHA", true);

            isnull.Add("IID_HORA", true);

            isnull.Add("IDESCRIP", true);

            isnull.Add("ISUCURSAL", true);

            isnull.Add("ICANTIDAD", true);

            isnull.Add("IPRODUCTO", true);

            isnull.Add("IUTILIDAD", true);

            isnull.Add("ICANTLLEV", true);

            isnull.Add("IIMPORTE", true);

            isnull.Add("IPORCDESC", true);

            isnull.Add("ITIPOPROM", true);

            isnull.Add("IRANGPROM", true);

            isnull.Add("ILINEA", true);

            isnull.Add("IFECHAINI", true);

            isnull.Add("IFECHAFIN", true);

            isnull.Add("ILUNES", true);

            isnull.Add("IMARTES", true);

            isnull.Add("IMIERCOLES", true);

            isnull.Add("IJUEVES", true);

            isnull.Add("IVIERNES", true);

            isnull.Add("ISABADO", true);

            isnull.Add("IDOMINGO", true);

            isnull.Add("IPORIMPO", true);

            isnull.Add("IMONEDERO", true);

            isnull.Add("IACTIVO", true);

            isnull.Add("IMULTDET", true);

            isnull.Add("IDESCMTD", true);
        }



    }
}
