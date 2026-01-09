
using Newtonsoft.Json;
using System;
using System.Collections;

namespace iPosBusinessEntity
{
    public class CCARTAPORTEUBICACIONBE
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

        private string iTIPOUBICACION;
        public string ITIPOUBICACION
        {
            get
            {
                return this.iTIPOUBICACION;
            }
            set
            {
                this.iTIPOUBICACION = value;
                this.isnull["ITIPOUBICACION"] = false;
            }
        }

        private string iIDUBICACION;
        public string IIDUBICACION
        {
            get
            {
                return this.iIDUBICACION;
            }
            set
            {
                this.iIDUBICACION = value;
                this.isnull["IIDUBICACION"] = false;
            }
        }

        private string iRFCREMITENTEDESTINATARIO;
        public string IRFCREMITENTEDESTINATARIO
        {
            get
            {
                return this.iRFCREMITENTEDESTINATARIO;
            }
            set
            {
                this.iRFCREMITENTEDESTINATARIO = value;
                this.isnull["IRFCREMITENTEDESTINATARIO"] = false;
            }
        }

        private string iNOMBREREMITENTEDESTINATARIO;
        public string INOMBREREMITENTEDESTINATARIO
        {
            get
            {
                return this.iNOMBREREMITENTEDESTINATARIO;
            }
            set
            {
                this.iNOMBREREMITENTEDESTINATARIO = value;
                this.isnull["INOMBREREMITENTEDESTINATARIO"] = false;
            }
        }

        private string iNUMREGIDTRIB;
        public string INUMREGIDTRIB
        {
            get
            {
                return this.iNUMREGIDTRIB;
            }
            set
            {
                this.iNUMREGIDTRIB = value;
                this.isnull["INUMREGIDTRIB"] = false;
            }
        }

        private string iRESIDENCIAFISCAL;
        public string IRESIDENCIAFISCAL
        {
            get
            {
                return this.iRESIDENCIAFISCAL;
            }
            set
            {
                this.iRESIDENCIAFISCAL = value;
                this.isnull["IRESIDENCIAFISCAL"] = false;
            }
        }

        private string iNUMESTACION;
        public string INUMESTACION
        {
            get
            {
                return this.iNUMESTACION;
            }
            set
            {
                this.iNUMESTACION = value;
                this.isnull["INUMESTACION"] = false;
            }
        }

        private string iNOMBREESTACION;
        public string INOMBREESTACION
        {
            get
            {
                return this.iNOMBREESTACION;
            }
            set
            {
                this.iNOMBREESTACION = value;
                this.isnull["INOMBREESTACION"] = false;
            }
        }

        private string iNAVEGACIONTRAFICO;
        public string INAVEGACIONTRAFICO
        {
            get
            {
                return this.iNAVEGACIONTRAFICO;
            }
            set
            {
                this.iNAVEGACIONTRAFICO = value;
                this.isnull["INAVEGACIONTRAFICO"] = false;
            }
        }

        private string iFECHAHORASALIDALLEGADA;
        public string IFECHAHORASALIDALLEGADA
        {
            get
            {
                return this.iFECHAHORASALIDALLEGADA;
            }
            set
            {
                this.iFECHAHORASALIDALLEGADA = value;
                this.isnull["IFECHAHORASALIDALLEGADA"] = false;
            }
        }

        private string iTIPOESTACION;
        public string ITIPOESTACION
        {
            get
            {
                return this.iTIPOESTACION;
            }
            set
            {
                this.iTIPOESTACION = value;
                this.isnull["ITIPOESTACION"] = false;
            }
        }

        private string iDISTANCIARECORRIDA;
        public string IDISTANCIARECORRIDA
        {
            get
            {
                return this.iDISTANCIARECORRIDA;
            }
            set
            {
                this.iDISTANCIARECORRIDA = value;
                this.isnull["IDISTANCIARECORRIDA"] = false;
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

            if (!(bool)line.isnull["ITIPOUBICACION"])
                this.ITIPOUBICACION = line.ITIPOUBICACION;

            if (!(bool)line.isnull["IIDUBICACION"])
                this.IIDUBICACION = line.IIDUBICACION;

            if (!(bool)line.isnull["IRFCREMITENTEDESTINATARIO"])
                this.IRFCREMITENTEDESTINATARIO = line.IRFCREMITENTEDESTINATARIO;

            if (!(bool)line.isnull["INOMBREREMITENTEDESTINATARIO"])
                this.INOMBREREMITENTEDESTINATARIO = line.INOMBREREMITENTEDESTINATARIO;

            if (!(bool)line.isnull["INUMREGIDTRIB"])
                this.INUMREGIDTRIB = line.INUMREGIDTRIB;

            if (!(bool)line.isnull["IRESIDENCIAFISCAL"])
                this.IRESIDENCIAFISCAL = line.IRESIDENCIAFISCAL;

            if (!(bool)line.isnull["INUMESTACION"])
                this.INUMESTACION = line.INUMESTACION;

            if (!(bool)line.isnull["INOMBREESTACION"])
                this.INOMBREESTACION = line.INOMBREESTACION;

            if (!(bool)line.isnull["INAVEGACIONTRAFICO"])
                this.INAVEGACIONTRAFICO = line.INAVEGACIONTRAFICO;

            if (!(bool)line.isnull["IFECHAHORASALIDALLEGADA"])
                this.IFECHAHORASALIDALLEGADA = line.IFECHAHORASALIDALLEGADA;

            if (!(bool)line.isnull["ITIPOESTACION"])
                this.ITIPOESTACION = line.ITIPOESTACION;

            if (!(bool)line.isnull["IDISTANCIARECORRIDA"])
                this.IDISTANCIARECORRIDA = line.IDISTANCIARECORRIDA;

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

        public CCARTAPORTEUBICACIONBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("ITIPOUBICACION", true);


            isnull.Add("IIDUBICACION", true);


            isnull.Add("IRFCREMITENTEDESTINATARIO", true);


            isnull.Add("INOMBREREMITENTEDESTINATARIO", true);


            isnull.Add("INUMREGIDTRIB", true);


            isnull.Add("IRESIDENCIAFISCAL", true);


            isnull.Add("INUMESTACION", true);


            isnull.Add("INOMBREESTACION", true);


            isnull.Add("INAVEGACIONTRAFICO", true);


            isnull.Add("IFECHAHORASALIDALLEGADA", true);


            isnull.Add("ITIPOESTACION", true);


            isnull.Add("IDISTANCIARECORRIDA", true);


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
