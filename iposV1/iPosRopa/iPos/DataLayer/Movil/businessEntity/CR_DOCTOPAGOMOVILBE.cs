
using System;
using System.Collections;

namespace iPosBusinessEntity
{
    public class CR_DOCTOPAGOMOVILBE
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

        private long iPAGOMOVILID;
        public long IPAGOMOVILID
        {
            get
            {
                return this.iPAGOMOVILID;
            }
            set
            {
                this.iPAGOMOVILID = value;
                this.isnull["IPAGOMOVILID"] = false;
            }
        }

        private long iCOBRANZAID;
        public long ICOBRANZAID
        {
            get
            {
                return this.iCOBRANZAID;
            }
            set
            {
                this.iCOBRANZAID = value;
                this.isnull["ICOBRANZAID"] = false;
            }
        }

        private long iESTATUS;
        public long IESTATUS
        {
            get
            {
                return this.iESTATUS;
            }
            set
            {
                this.iESTATUS = value;
                this.isnull["IESTATUS"] = false;
            }
        }

        private DateTime iFECHA;
        public DateTime IFECHA
        {
            get
            {
                return this.iFECHA;
            }
            set
            {
                this.iFECHA = value;
                this.isnull["IFECHA"] = false;
            }
        }

        private object iFECHAHORA;
        public object IFECHAHORA
        {
            get
            {
                return this.iFECHAHORA;
            }
            set
            {
                this.iFECHAHORA = value;
                this.isnull["IFECHAHORA"] = false;
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

        private string iREVERTIDO;
        public string IREVERTIDO
        {
            get
            {
                return this.iREVERTIDO;
            }
            set
            {
                this.iREVERTIDO = value;
                this.isnull["IREVERTIDO"] = false;
            }
        }

        private long iR_DOCTOPAGOMOVILREFID;
        public long IR_DOCTOPAGOMOVILREFID
        {
            get
            {
                return this.iR_DOCTOPAGOMOVILREFID;
            }
            set
            {
                this.iR_DOCTOPAGOMOVILREFID = value;
                this.isnull["IR_DOCTOPAGOMOVILREFID"] = false;
            }
        }

        private long iTIPOPAGOID;
        public long ITIPOPAGOID
        {
            get
            {
                return this.iTIPOPAGOID;
            }
            set
            {
                this.iTIPOPAGOID = value;
                this.isnull["ITIPOPAGOID"] = false;
            }
        }

        private string iVENTACOBRANZA;
        public string IVENTACOBRANZA
        {
            get
            {
                return this.iVENTACOBRANZA;
            }
            set
            {
                this.iVENTACOBRANZA = value;
                this.isnull["IVENTACOBRANZA"] = false;
            }
        }

        private decimal iSALDOANTERIOR;
        public decimal ISALDOANTERIOR
        {
            get
            {
                return this.iSALDOANTERIOR;
            }
            set
            {
                this.iSALDOANTERIOR = value;
                this.isnull["ISALDOANTERIOR"] = false;
            }
        }

        private decimal iSALDONUEVO;
        public decimal ISALDONUEVO
        {
            get
            {
                return this.iSALDONUEVO;
            }
            set
            {
                this.iSALDONUEVO = value;
                this.isnull["ISALDONUEVO"] = false;
            }
        }

        private decimal iSALDOPAGO;
        public decimal ISALDOPAGO
        {
            get
            {
                return this.iSALDOPAGO;
            }
            set
            {
                this.iSALDOPAGO = value;
                this.isnull["ISALDOPAGO"] = false;
            }
        }

        public CR_DOCTOPAGOMOVILBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("IPAGOMOVILID", true);


            isnull.Add("ICOBRANZAID", true);


            isnull.Add("IESTATUS", true);


            isnull.Add("IFECHA", true);


            isnull.Add("IFECHAHORA", true);


            isnull.Add("ICORTEID", true);


            isnull.Add("IIMPORTE", true);


            isnull.Add("IREVERTIDO", true);


            isnull.Add("IR_DOCTOPAGOMOVILREFID", true);


            isnull.Add("ITIPOPAGOID", true);


            isnull.Add("IVENTACOBRANZA", true);


            isnull.Add("ISALDOANTERIOR", true);


            isnull.Add("ISALDONUEVO", true);


            isnull.Add("ISALDOPAGO", true);

        }



    }
}
