
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CCAJABE
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

        private DateTime iFECHACORTE;
        public DateTime IFECHACORTE
        {
            get
            {
                return this.iFECHACORTE;
            }
            set
            {
                this.iFECHACORTE = value;
                this.isnull["IFECHACORTE"] = false;
            }
        }

        private long iCORTEID;
        public long ICORTEID
        {
            get
            {
                return this.iCORTEID;
            }
            set
            {
                this.iCORTEID = value;
                this.isnull["ICORTEID"] = false;
            }
        }

        private long iCAJEROID;
        public long ICAJEROID
        {
            get
            {
                return this.iCAJEROID;
            }
            set
            {
                this.iCAJEROID = value;
                this.isnull["ICAJEROID"] = false;
            }
        }

        private long iTURNOID;
        public long ITURNOID
        {
            get
            {
                return this.iTURNOID;
            }
            set
            {
                this.iTURNOID = value;
                this.isnull["ITURNOID"] = false;
            }
        }

        private string iNOMBREIMPRESORA;
        public string INOMBREIMPRESORA
        {
            get
            {
                return this.iNOMBREIMPRESORA;
            }
            set
            {
                this.iNOMBREIMPRESORA = value;
                this.isnull["INOMBREIMPRESORA"] = false;
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




        private string iTERMINALSERVICIOS;
        public string ITERMINALSERVICIOS
        {
            get
            {
                return this.iTERMINALSERVICIOS;
            }
            set
            {
                this.iTERMINALSERVICIOS = value;
                this.isnull["ITERMINALSERVICIOS"] = false;
            }
        }

        private long iNUMEROTERMINALBANCOMER;
        public long INUMEROTERMINALBANCOMER
        {
            get
            {
                return this.iNUMEROTERMINALBANCOMER;
            }
            set
            {
                this.iNUMEROTERMINALBANCOMER = value;
                this.isnull["INUMEROTERMINALBANCOMER"] = false;
            }
        }

        private string iNOMBRECERTIFICADOBANCOMER;
        public string INOMBRECERTIFICADOBANCOMER
        {
            get
            {
                return this.iNOMBRECERTIFICADOBANCOMER;
            }
            set
            {
                this.iNOMBRECERTIFICADOBANCOMER = value;
                this.isnull["INOMBRECERTIFICADOBANCOMER"] = false;
            }
        }

        private string iAFILIACIONBANCOMER;
        public string IAFILIACIONBANCOMER
        {
            get
            {
                return this.iAFILIACIONBANCOMER;
            }
            set
            {
                this.iAFILIACIONBANCOMER = value;
                this.isnull["IAFILIACIONBANCOMER"] = false;
            }
        }


        private string iIMPRESORACOMANDA;
        public string IIMPRESORACOMANDA
        {
            get
            {
                return this.iIMPRESORACOMANDA;
            }
            set
            {
                this.iIMPRESORACOMANDA = value;
                this.isnull["IIMPRESORACOMANDA"] = false;
            }
        }

        public CCAJABE()
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


            isnull.Add("IFECHACORTE", true);


            isnull.Add("ICORTEID", true);


            isnull.Add("ICAJEROID", true);


            isnull.Add("ITURNOID", true);


            isnull.Add("INOMBREIMPRESORA", true);


            isnull.Add("ITERMINAL", true);


            isnull.Add("ITERMINALSERVICIOS", true);


            isnull.Add("INUMEROTERMINALBANCOMER", true);


            isnull.Add("INOMBRECERTIFICADOBANCOMER", true);

            isnull.Add("IAFILIACIONBANCOMER", true);

            isnull.Add("IIMPRESORACOMANDA", true);

        }



    }
}
