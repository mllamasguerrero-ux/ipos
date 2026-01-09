
using System;
using System.Collections;

namespace iPosBusinessEntity
{
    public class CSTRMULTIPAGOSBANCOMERBE
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

        private string iGUIA_CIE;
        public string IGUIA_CIE
        {
            get
            {
                return this.iGUIA_CIE;
            }
            set
            {
                this.iGUIA_CIE = value;
                this.isnull["IGUIA_CIE"] = false;
            }
        }

        private string iIMPORTEUDIS;
        public string IIMPORTEUDIS
        {
            get
            {
                return this.iIMPORTEUDIS;
            }
            set
            {
                this.iIMPORTEUDIS = value;
                this.isnull["IIMPORTEUDIS"] = false;
            }
        }

        private string iNUMTARJETAII;
        public string INUMTARJETAII
        {
            get
            {
                return this.iNUMTARJETAII;
            }
            set
            {
                this.iNUMTARJETAII = value;
                this.isnull["INUMTARJETAII"] = false;
            }
        }

        private string iRAZON_SOCIAL;
        public string IRAZON_SOCIAL
        {
            get
            {
                return this.iRAZON_SOCIAL;
            }
            set
            {
                this.iRAZON_SOCIAL = value;
                this.isnull["IRAZON_SOCIAL"] = false;
            }
        }

        private string iREFERENCIA_RESPUESTA;
        public string IREFERENCIA_RESPUESTA
        {
            get
            {
                return this.iREFERENCIA_RESPUESTA;
            }
            set
            {
                this.iREFERENCIA_RESPUESTA = value;
                this.isnull["IREFERENCIA_RESPUESTA"] = false;
            }
        }

        public CSTRMULTIPAGOSBANCOMERBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("IGUIA_CIE", true);


            isnull.Add("IIMPORTEUDIS", true);


            isnull.Add("INUMTARJETAII", true);


            isnull.Add("IRAZON_SOCIAL", true);


            isnull.Add("IREFERENCIA_RESPUESTA", true);

        }



    }
}
