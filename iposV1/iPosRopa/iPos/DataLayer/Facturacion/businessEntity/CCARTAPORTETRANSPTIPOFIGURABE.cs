
using Newtonsoft.Json;
using System;
using System.Collections;

namespace iPosBusinessEntity
{
    public class CCARTAPORTETRANSPTIPOFIGURABE
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

        private string iTIPOFIGURA;
        public string ITIPOFIGURA
        {
            get
            {
                return this.iTIPOFIGURA;
            }
            set
            {
                this.iTIPOFIGURA = value;
                this.isnull["ITIPOFIGURA"] = false;
            }
        }

        private string iRFCFIGURA;
        public string IRFCFIGURA
        {
            get
            {
                return this.iRFCFIGURA;
            }
            set
            {
                this.iRFCFIGURA = value;
                this.isnull["IRFCFIGURA"] = false;
            }
        }

        private string iNUMLICENCIA;
        public string INUMLICENCIA
        {
            get
            {
                return this.iNUMLICENCIA;
            }
            set
            {
                this.iNUMLICENCIA = value;
                this.isnull["INUMLICENCIA"] = false;
            }
        }

        private string iNOMBREFIGURA;
        public string INOMBREFIGURA
        {
            get
            {
                return this.iNOMBREFIGURA;
            }
            set
            {
                this.iNOMBREFIGURA = value;
                this.isnull["INOMBREFIGURA"] = false;
            }
        }

        private string iNUMREGIDTRIBFIGURA;
        public string INUMREGIDTRIBFIGURA
        {
            get
            {
                return this.iNUMREGIDTRIBFIGURA;
            }
            set
            {
                this.iNUMREGIDTRIBFIGURA = value;
                this.isnull["INUMREGIDTRIBFIGURA"] = false;
            }
        }

        private string iRESIDENCIAFISCALFIGURA;
        public string IRESIDENCIAFISCALFIGURA
        {
            get
            {
                return this.iRESIDENCIAFISCALFIGURA;
            }
            set
            {
                this.iRESIDENCIAFISCALFIGURA = value;
                this.isnull["IRESIDENCIAFISCALFIGURA"] = false;
            }
        }

        private string iPARTETRANSPORTE;
        public string IPARTETRANSPORTE
        {
            get
            {
                return this.iPARTETRANSPORTE;
            }
            set
            {
                this.iPARTETRANSPORTE = value;
                this.isnull["IPARTETRANSPORTE"] = false;
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

        private string iLOCALIDAD;
        public string ILOCALIDAD
        {
            get
            {
                return this.iLOCALIDAD;
            }
            set
            {
                this.iLOCALIDAD = value;
                this.isnull["ILOCALIDAD"] = false;
            }
        }

        private string iREFERENCIA;
        public string IREFERENCIA
        {
            get
            {
                return this.iREFERENCIA;
            }
            set
            {
                this.iREFERENCIA = value;
                this.isnull["IREFERENCIA"] = false;
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

        private string iPAIS;
        public string IPAIS
        {
            get
            {
                return this.iPAIS;
            }
            set
            {
                this.iPAIS = value;
                this.isnull["IPAIS"] = false;
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


        public void FillFromCartaPorteLinea(CCARTAPORTELINEABE line)
        {

            if (!(bool)line.isnull["ITIPOFIGURA"])
                this.ITIPOFIGURA = line.ITIPOFIGURA;

            if (!(bool)line.isnull["IRFCFIGURA"])
                this.IRFCFIGURA = line.IRFCFIGURA;

            if (!(bool)line.isnull["INUMLICENCIA"])
                this.INUMLICENCIA = line.INUMLICENCIA;

            if (!(bool)line.isnull["INOMBREFIGURA"])
                this.INOMBREFIGURA = line.INOMBREFIGURA;

            if (!(bool)line.isnull["INUMREGIDTRIBFIGURA"])
                this.INUMREGIDTRIBFIGURA = line.INUMREGIDTRIBFIGURA;

            if (!(bool)line.isnull["IRESIDENCIAFISCALFIGURA"])
                this.IRESIDENCIAFISCALFIGURA = line.IRESIDENCIAFISCALFIGURA;

            if (!(bool)line.isnull["IPARTETRANSPORTE"])
                this.IPARTETRANSPORTE = line.IPARTETRANSPORTE;

            if (!(bool)line.isnull["ICALLE"])
                this.ICALLE = line.ICALLE;

            if (!(bool)line.isnull["INUMEROEXTERIOR"])
                this.INUMEROEXTERIOR = line.INUMEROEXTERIOR;

            if (!(bool)line.isnull["INUMEROINTERIOR"])
                this.INUMEROINTERIOR = line.INUMEROINTERIOR;

            if (!(bool)line.isnull["ICOLONIA"])
                this.ICOLONIA = line.ICOLONIA;

            if (!(bool)line.isnull["ILOCALIDAD"])
                this.ILOCALIDAD = line.ILOCALIDAD;

            if (!(bool)line.isnull["IREFERENCIA"])
                this.IREFERENCIA = line.IREFERENCIA;

            if (!(bool)line.isnull["IMUNICIPIO"])
                this.IMUNICIPIO = line.IMUNICIPIO;

            if (!(bool)line.isnull["IESTADO"])
                this.IESTADO = line.IESTADO;

            if (!(bool)line.isnull["IPAIS"])
                this.IPAIS = line.IPAIS;

            if (!(bool)line.isnull["ICODIGOPOSTAL"])
                this.ICODIGOPOSTAL = line.ICODIGOPOSTAL;

        }

        public CCARTAPORTETRANSPTIPOFIGURABE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("ITIPOFIGURA", true);


            isnull.Add("IRFCFIGURA", true);


            isnull.Add("INUMLICENCIA", true);


            isnull.Add("INOMBREFIGURA", true);


            isnull.Add("INUMREGIDTRIBFIGURA", true);


            isnull.Add("IRESIDENCIAFISCALFIGURA", true);


            isnull.Add("IPARTETRANSPORTE", true);


            isnull.Add("ICALLE", true);


            isnull.Add("INUMEROEXTERIOR", true);


            isnull.Add("INUMEROINTERIOR", true);


            isnull.Add("ICOLONIA", true);


            isnull.Add("ILOCALIDAD", true);


            isnull.Add("IREFERENCIA", true);


            isnull.Add("IMUNICIPIO", true);


            isnull.Add("IESTADO", true);


            isnull.Add("IPAIS", true);


            isnull.Add("ICODIGOPOSTAL", true);

        }



    }
}
