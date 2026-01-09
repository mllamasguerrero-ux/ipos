
using System;
using System.Collections;

namespace iPosBusinessEntity
{
    public class CPROMOCIONBE
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

        private object iMEMO;
        public object IMEMO
        {
            get
            {
                return this.iMEMO;
            }
            set
            {
                this.iMEMO = value;
                this.isnull["IMEMO"] = false;
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

        private string iPROMOCION;
        public string IPROMOCION
        {
            get
            {
                return this.iPROMOCION;
            }
            set
            {
                this.iPROMOCION = value;
                this.isnull["IPROMOCION"] = false;
            }
        }

        private decimal iCANTIDAD;
        public decimal ICANTIDAD
        {
            get
            {
                return this.iCANTIDAD;
            }
            set
            {
                this.iCANTIDAD = value;
                this.isnull["ICANTIDAD"] = false;
            }
        }

        private long iPRODUCTOID;
        public long IPRODUCTOID
        {
            get
            {
                return this.iPRODUCTOID;
            }
            set
            {
                this.iPRODUCTOID = value;
                this.isnull["IPRODUCTOID"] = false;
            }
        }

        private decimal iUTILIDAD;
        public decimal IUTILIDAD
        {
            get
            {
                return this.iUTILIDAD;
            }
            set
            {
                this.iUTILIDAD = value;
                this.isnull["IUTILIDAD"] = false;
            }
        }

        private decimal iCANTIDADLLEVATE;
        public decimal ICANTIDADLLEVATE
        {
            get
            {
                return this.iCANTIDADLLEVATE;
            }
            set
            {
                this.iCANTIDADLLEVATE = value;
                this.isnull["ICANTIDADLLEVATE"] = false;
            }
        }

        private decimal iIMPORTE;
        public decimal IIMPORTE
        {
            get
            {
                return this.iIMPORTE;
            }
            set
            {
                this.iIMPORTE = value;
                this.isnull["IIMPORTE"] = false;
            }
        }

        private decimal iPORCENTAJEDESCUENTO;
        public decimal IPORCENTAJEDESCUENTO
        {
            get
            {
                return this.iPORCENTAJEDESCUENTO;
            }
            set
            {
                this.iPORCENTAJEDESCUENTO = value;
                this.isnull["IPORCENTAJEDESCUENTO"] = false;
            }
        }

        private long iTIPOPROMOCIONID;
        public long ITIPOPROMOCIONID
        {
            get
            {
                return this.iTIPOPROMOCIONID;
            }
            set
            {
                this.iTIPOPROMOCIONID = value;
                this.isnull["ITIPOPROMOCIONID"] = false;
            }
        }

        private long iRANGOPROMOCIONID;
        public long IRANGOPROMOCIONID
        {
            get
            {
                return this.iRANGOPROMOCIONID;
            }
            set
            {
                this.iRANGOPROMOCIONID = value;
                this.isnull["IRANGOPROMOCIONID"] = false;
            }
        }

        private long iLINEAID;
        public long ILINEAID
        {
            get
            {
                return this.iLINEAID;
            }
            set
            {
                this.iLINEAID = value;
                this.isnull["ILINEAID"] = false;
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

        private string iLUNES;
        public string ILUNES
        {
            get
            {
                return this.iLUNES;
            }
            set
            {
                this.iLUNES = value;
                this.isnull["ILUNES"] = false;
            }
        }

        private string iMARTES;
        public string IMARTES
        {
            get
            {
                return this.iMARTES;
            }
            set
            {
                this.iMARTES = value;
                this.isnull["IMARTES"] = false;
            }
        }

        private string iMIERCOLES;
        public string IMIERCOLES
        {
            get
            {
                return this.iMIERCOLES;
            }
            set
            {
                this.iMIERCOLES = value;
                this.isnull["IMIERCOLES"] = false;
            }
        }

        private string iJUEVES;
        public string IJUEVES
        {
            get
            {
                return this.iJUEVES;
            }
            set
            {
                this.iJUEVES = value;
                this.isnull["IJUEVES"] = false;
            }
        }

        private string iVIERNES;
        public string IVIERNES
        {
            get
            {
                return this.iVIERNES;
            }
            set
            {
                this.iVIERNES = value;
                this.isnull["IVIERNES"] = false;
            }
        }

        private string iSABADO;
        public string ISABADO
        {
            get
            {
                return this.iSABADO;
            }
            set
            {
                this.iSABADO = value;
                this.isnull["ISABADO"] = false;
            }
        }

        private string iDOMINGO;
        public string IDOMINGO
        {
            get
            {
                return this.iDOMINGO;
            }
            set
            {
                this.iDOMINGO = value;
                this.isnull["IDOMINGO"] = false;
            }
        }

        private decimal iPORIMPORTE;
        public decimal IPORIMPORTE
        {
            get
            {
                return this.iPORIMPORTE;
            }
            set
            {
                this.iPORIMPORTE = value;
                this.isnull["IPORIMPORTE"] = false;
            }
        }

        private string iENMONEDERO;
        public string IENMONEDERO
        {
            get
            {
                return this.iENMONEDERO;
            }
            set
            {
                this.iENMONEDERO = value;
                this.isnull["IENMONEDERO"] = false;
            }
        }


        private string iIMAGEN;
        public string IIMAGEN
        {
            get
            {
                return this.iIMAGEN;
            }
            set
            {
                this.iIMAGEN = value;
                this.isnull["IIMAGEN"] = false;
            }
        }



        private string iMOSTRARDATOSCLIENTE;
        public string IMOSTRARDATOSCLIENTE
        {
            get
            {
                return this.iMOSTRARDATOSCLIENTE;
            }
            set
            {
                this.iMOSTRARDATOSCLIENTE = value;
                this.isnull["IMOSTRARDATOSCLIENTE"] = false;
            }
        }



        private string iESMULTIDETALLE;
        public string IESMULTIDETALLE
        {
            get
            {
                return this.iESMULTIDETALLE;
            }
            set
            {
                this.iESMULTIDETALLE = value;
                this.isnull["IESMULTIDETALLE"] = false;
            }
        }



        private string iDESCMULTIDETALLE;
        public string IDESCMULTIDETALLE
        {
            get
            {
                return this.iDESCMULTIDETALLE;
            }
            set
            {
                this.iDESCMULTIDETALLE = value;
                this.isnull["IDESCMULTIDETALLE"] = false;
            }
        }


        public CPROMOCIONBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("ICLAVE", true);


            isnull.Add("INOMBRE", true);


            isnull.Add("IDESCRIPCION", true);


            isnull.Add("IMEMO", true);


            isnull.Add("ISUCURSALID", true);


            isnull.Add("IPROMOCION", true);


            isnull.Add("ICANTIDAD", true);


            isnull.Add("IPRODUCTOID", true);


            isnull.Add("IUTILIDAD", true);


            isnull.Add("ICANTIDADLLEVATE", true);


            isnull.Add("IIMPORTE", true);


            isnull.Add("IPORCENTAJEDESCUENTO", true);


            isnull.Add("ITIPOPROMOCIONID", true);


            isnull.Add("IRANGOPROMOCIONID", true);


            isnull.Add("ILINEAID", true);


            isnull.Add("IFECHAINICIO", true);


            isnull.Add("IFECHAFIN", true);


            isnull.Add("ILUNES", true);


            isnull.Add("IMARTES", true);


            isnull.Add("IMIERCOLES", true);


            isnull.Add("IJUEVES", true);


            isnull.Add("IVIERNES", true);


            isnull.Add("ISABADO", true);


            isnull.Add("IDOMINGO", true);


            isnull.Add("IPORIMPORTE", true);


            isnull.Add("IENMONEDERO", true);

            isnull.Add("IIMAGEN", true);

            isnull.Add("IMOSTRARDATOSCLIENTE", true);

            isnull.Add("IESMULTIDETALLE", true);

            isnull.Add("IDESCMULTIDETALLE", true);


        }



    }
}
