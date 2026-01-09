
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CM_CATSBE
    {
        public Hashtable isnull;

        private string iCLIENTE;
        public string ICLIENTE
        {
            get
            {
                return this.iCLIENTE;
            }
            set
            {
                this.iCLIENTE = value;
                this.isnull["ICLIENTE"] = false;
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

        private string iSUCURSAL;
        public string ISUCURSAL
        {
            get
            {
                return this.iSUCURSAL;
            }
            set
            {
                this.iSUCURSAL = value;
                this.isnull["ISUCURSAL"] = false;
            }
        }

        private bool iIMPORTAR;
        public bool IIMPORTAR
        {
            get
            {
                return this.iIMPORTAR;
            }
            set
            {
                this.iIMPORTAR = value;
                this.isnull["IIMPORTAR"] = false;
            }
        }

        private string iACTIVA;
        public string IACTIVA
        {
            get
            {
                return this.iACTIVA;
            }
            set
            {
                this.iACTIVA = value;
                this.isnull["IACTIVA"] = false;
            }
        }

        private string iBWCOLOR;
        public string IBWCOLOR
        {
            get
            {
                return this.iBWCOLOR;
            }
            set
            {
                this.iBWCOLOR = value;
                this.isnull["IBWCOLOR"] = false;
            }
        }

        private string iFINSEMANA;
        public string IFINSEMANA
        {
            get
            {
                return this.iFINSEMANA;
            }
            set
            {
                this.iFINSEMANA = value;
                this.isnull["IFINSEMANA"] = false;
            }
        }

        private string iID;
        public string IID
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

        private string iSUCU;
        public string ISUCU
        {
            get
            {
                return this.iSUCU;
            }
            set
            {
                this.iSUCU = value;
                this.isnull["ISUCU"] = false;
            }
        }

        private string iESTRATEGIC;
        public string IESTRATEGIC
        {
            get
            {
                return this.iESTRATEGIC;
            }
            set
            {
                this.iESTRATEGIC = value;
                this.isnull["IESTRATEGIC"] = false;
            }
        }

        private string iNOMBRE2;
        public string INOMBRE2
        {
            get
            {
                return this.iNOMBRE2;
            }
            set
            {
                this.iNOMBRE2 = value;
                this.isnull["INOMBRE2"] = false;
            }
        }

        private string iGRUPO;
        public string IGRUPO
        {
            get
            {
                return this.iGRUPO;
            }
            set
            {
                this.iGRUPO = value;
                this.isnull["IGRUPO"] = false;
            }
        }

        private string iCOMER;
        public string ICOMER
        {
            get
            {
                return this.iCOMER;
            }
            set
            {
                this.iCOMER = value;
                this.isnull["ICOMER"] = false;
            }
        }

        private double iPRECIOT;
        public double IPRECIOT
        {
            get
            {
                return this.iPRECIOT;
            }
            set
            {
                this.iPRECIOT = value;
                this.isnull["IPRECIOT"] = false;
            }
        }

        private double iMAXDOCP;
        public double IMAXDOCP
        {
            get
            {
                return this.iMAXDOCP;
            }
            set
            {
                this.iMAXDOCP = value;
                this.isnull["IMAXDOCP"] = false;
            }
        }


        private string iESMATRIZ;
        public string IESMATRIZ
        {
            get
            {
                return this.iESMATRIZ;
            }
            set
            {
                this.iESMATRIZ = value;
                this.isnull["IESMATRIZ"] = false;
            }
        }


        private double iCOSTOREC;
        public double ICOSTOREC
        {
            get
            {
                return this.iCOSTOREC;
            }
            set
            {
                this.iCOSTOREC = value;
                this.isnull["ICOSTOREC"] = false;
            }
        }


        private double iPRECENV;
        public double IPRECENV
        {
            get
            {
                return this.iPRECENV;
            }
            set
            {
                this.iPRECENV = value;
                this.isnull["IPRECENV"] = false;
            }
        }



        private string iSHOWREAL;
        public string ISHOWREAL
        {
            get
            {
                return this.iSHOWREAL;
            }
            set
            {
                this.iSHOWREAL = value;
                this.isnull["ISHOWREAL"] = false;
            }
        }


        private string iPROVEE;
        public string IPROVEE
        {
            get
            {
                return this.iPROVEE;
            }
            set
            {
                this.iPROVEE = value;
                this.isnull["IPROVEE"] = false;
            }
        }


        private string iSURTIDOR;
        public string ISURTIDOR
        {
            get
            {
                return this.iSURTIDOR;
            }
            set
            {
                this.iSURTIDOR = value;
                this.isnull["ISURTIDOR"] = false;
            }
        }


        private double iPORCPREC;
        public double IPORCPREC
        {
            get
            {
                return this.iPORCPREC;
            }
            set
            {
                this.iPORCPREC = value;
                this.isnull["IPORCPREC"] = false;
            }
        }



        private string iPRECXDES;
        public string IPRECXDES
        {
            get
            {
                return this.iPRECXDES;
            }
            set
            {
                this.iPRECXDES = value;
                this.isnull["IPRECXDES"] = false;
            }
        }


        private string iPREFXDES;
        public string IPREFXDES
        {
            get
            {
                return this.iPREFXDES;
            }
            set
            {
                this.iPREFXDES = value;
                this.isnull["IPREFXDES"] = false;
            }
        }


        private string iRESPBD;
        public string IRESPBD
        {
            get
            {
                return this.iRESPBD;
            }
            set
            {
                this.iRESPBD = value;
                this.isnull["IRESPBD"] = false;
            }
        }

        
        private string iESFRANQ;
        public string IESFRANQ
        {
            get
            {
                return this.iESFRANQ;
            }
            set
            {
                this.iESFRANQ = value;
                this.isnull["IESFRANQ"] = false;
            }
        }



        private string iBANCO;
        public string IBANCO
        {
            get
            {
                return this.iBANCO;
            }
            set
            {
                this.iBANCO = value;
                this.isnull["IBANCO"] = false;
            }
        }


        private string iCUENTA;
        public string ICUENTA
        {
            get
            {
                return this.iCUENTA;
            }
            set
            {
                this.iCUENTA = value;
                this.isnull["ICUENTA"] = false;
            }
        }


        private string iCTAPOLI;
        public string ICTAPOLI
        {
            get
            {
                return this.iCTAPOLI;
            }
            set
            {
                this.iCTAPOLI = value;
                this.isnull["ICTAPOLI"] = false;
            }
        }



        private string iLSTPREC;
        public string ILSTPREC
        {
            get
            {
                return this.iLSTPREC;
            }
            set
            {
                this.iLSTPREC = value;
                this.isnull["ILSTPREC"] = false;
            }
        }



        private string iEMPPROV;
        public string IEMPPROV
        {
            get
            {
                return this.iEMPPROV;
            }
            set
            {
                this.iEMPPROV = value;
                this.isnull["IEMPPROV"] = false;
            }
        }



        private string iIMNUPROD;
        public string IIMNUPROD
        {
            get
            {
                return this.iIMNUPROD;
            }
            set
            {
                this.iIMNUPROD = value;
                this.isnull["IIMNUPROD"] = false;
            }
        }

        public CM_CATSBE()
        {
            isnull = new Hashtable();


            isnull.Add("ICLIENTE", true);


            isnull.Add("INOMBRE", true);


            isnull.Add("ISUCURSAL", true);


            isnull.Add("IIMPORTAR", true);


            isnull.Add("IACTIVA", true);


            isnull.Add("IBWCOLOR", true);


            isnull.Add("IFINSEMANA", true);


            isnull.Add("IID", true);


            isnull.Add("IID_FECHA", true);


            isnull.Add("IID_HORA", true);


            isnull.Add("ISUCU", true);


            isnull.Add("IESTRATEGIC", true);


            isnull.Add("INOMBRE2", true);


            isnull.Add("IGRUPO", true);


            isnull.Add("ICOMER", true);


            isnull.Add("IPRECIOT", true);


            isnull.Add("IMAXDOCP", true);

            isnull.Add("IESMATRIZ", true);

            isnull.Add("ICOSTOREC", true);

            isnull.Add("IPRECENV", true);

            isnull.Add("ISHOWREAL", true);

            isnull.Add("IPROVEE", true);

            isnull.Add("ISURTIDOR", true);

            isnull.Add("IPORCPREC", true);

            isnull.Add("IPRECXDES", true);

            isnull.Add("IPREFXDES", true);

            isnull.Add("IRESPBD", true);

            isnull.Add("IESFRANQ", true);

            isnull.Add("IBANCO", true);

            isnull.Add("ICUENTA", true);

            isnull.Add("ICTAPOLI", true);
            
            isnull.Add("ILSTPREC", true);

            isnull.Add("IEMPPROV", true);

            isnull.Add("IIMNUPROD", true);
            






        }



    }
}
