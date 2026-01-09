using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPosBusinessEntity
{
    public class CDOMICILIOBE
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

        private string iCALLE;
        public string ICALLE
        {
            get
            {
                return this.iCALLE;
            }
            set
            {
                this.iCALLE = value;
                this.isnull["ICALLE"] = false;
            }
        }

        private string iNUMEROEXTERIOR;
        public string INUMEROEXTERIOR
        {
            get
            {
                return this.iNUMEROEXTERIOR;
            }
            set
            {
                this.iNUMEROEXTERIOR = value;
                this.isnull["INUMEROEXTERIOR"] = false;
            }
        }

        private string iNUMEROINTERIOR;
        public string INUMEROINTERIOR
        {
            get
            {
                return this.iNUMEROINTERIOR;
            }
            set
            {
                this.iNUMEROINTERIOR = value;
                this.isnull["INUMEROINTERIOR"] = false;
            }
        }

        private string iCOLONIA;
        public string ICOLONIA
        {
            get
            {
                return this.iCOLONIA;
            }
            set
            {
                this.iCOLONIA = value;
                this.isnull["ICOLONIA"] = false;
            }
        }

        private string iMUNICIPIO;
        public string IMUNICIPIO
        {
            get
            {
                return this.iMUNICIPIO;
            }
            set
            {
                this.iMUNICIPIO = value;
                this.isnull["IMUNICIPIO"] = false;
            }
        }

        private string iESTADO;
        public string IESTADO
        {
            get
            {
                return this.iESTADO;
            }
            set
            {
                this.iESTADO = value;
                this.isnull["IESTADO"] = false;
            }
        }

        private string iCODIGOPOSTAL;
        public string ICODIGOPOSTAL
        {
            get
            {
                return this.iCODIGOPOSTAL;
            }
            set
            {
                this.iCODIGOPOSTAL = value;
                this.isnull["ICODIGOPOSTAL"] = false;
            }
        }

        private long iSAT_COLONIAID;
        public long ISAT_COLONIAID
        {
            get
            {
                return this.iSAT_COLONIAID;
            }
            set
            {
                this.iSAT_COLONIAID = value;
                this.isnull["ISAT_COLONIAID"] = false;
            }
        }

        private long iSAT_LOCALIDADID;
        public long ISAT_LOCALIDADID
        {
            get
            {
                return this.iSAT_LOCALIDADID;
            }
            set
            {
                this.iSAT_LOCALIDADID = value;
                this.isnull["ISAT_LOCALIDADID"] = false;
            }
        }

        private long iSAT_MUNICIPIOID;
        public long ISAT_MUNICIPIOID
        {
            get
            {
                return this.iSAT_MUNICIPIOID;
            }
            set
            {
                this.iSAT_MUNICIPIOID = value;
                this.isnull["ISAT_MUNICIPIOID"] = false;
            }
        }

        private decimal iDISTANCIA;
        public decimal IDISTANCIA
        {
            get
            {
                return this.iDISTANCIA;
            }
            set
            {
                this.iDISTANCIA = value;
                this.isnull["IDISTANCIA"] = false;
            }
        }

        private string iREFERENCIADOM;
        public string IREFERENCIADOM
        {
            get
            {
                return this.iREFERENCIADOM;
            }
            set
            {
                this.iREFERENCIADOM = value;
                this.isnull["IREFERENCIADOM"] = false;
            }
        }

        private double iLATITUD;
        public double ILATITUD
        {
            get
            {
                return this.iLATITUD;
            }
            set
            {
                this.iLATITUD = value;
                this.isnull["ILATITUD"] = false;
            }
        }

        private double iLONGITUD;
        public double ILONGITUD
        {
            get
            {
                return this.iLONGITUD;
            }
            set
            {
                this.iLONGITUD = value;
                this.isnull["ILONGITUD"] = false;
            }
        }

        private long iPERSONAID;
        public long IPERSONAID
        {
            get
            {
                return this.iPERSONAID;
            }
            set
            {
                this.iPERSONAID = value;
                this.isnull["IPERSONAID"] = false;
            }
        }

        private int iORDEN;
        public int IORDEN
        {
            get
            {
                return this.iORDEN;
            }
            set
            {
                this.iORDEN = value;
                this.isnull["IORDEN"] = false;
            }
        }

        private string iPREDETERMINADO;
        public string IPREDETERMINADO
        {
            get
            {
                return this.iPREDETERMINADO;
            }
            set
            {
                this.iPREDETERMINADO = value;
                this.isnull["IPREDETERMINADO"] = false;
            }
        }

        public CDOMICILIOBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("ICALLE", true);


            isnull.Add("INUMEROEXTERIOR", true);


            isnull.Add("INUMEROINTERIOR", true);


            isnull.Add("ICOLONIA", true);


            isnull.Add("IMUNICIPIO", true);


            isnull.Add("IESTADO", true);


            isnull.Add("ICODIGOPOSTAL", true);


            isnull.Add("ISAT_COLONIAID", true);


            isnull.Add("ISAT_LOCALIDADID", true);


            isnull.Add("ISAT_MUNICIPIOID", true);


            isnull.Add("IDISTANCIA", true);


            isnull.Add("IREFERENCIADOM", true);


            isnull.Add("ILATITUD", true);


            isnull.Add("ILONGITUD", true);


            isnull.Add("IPERSONAID", true);


            isnull.Add("IORDEN", true);


            isnull.Add("IPREDETERMINADO", true);

        }



    }
}
