
using Newtonsoft.Json;
using System;
using System.Collections;

namespace iPosBusinessEntity
{
    public class CCARTAPORTETOTALMERCANCIASBE
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

        private string iPESOBRUTOTOTAL;
        public string IPESOBRUTOTOTAL
        {
            get
            {
                return this.iPESOBRUTOTOTAL;
            }
            set
            {
                this.iPESOBRUTOTOTAL = value;
                this.isnull["IPESOBRUTOTOTAL"] = false;
            }
        }

        private string iUNIDADPESO;
        public string IUNIDADPESO
        {
            get
            {
                return this.iUNIDADPESO;
            }
            set
            {
                this.iUNIDADPESO = value;
                this.isnull["IUNIDADPESO"] = false;
            }
        }

        private string iPESONETOTOTAL;
        public string IPESONETOTOTAL
        {
            get
            {
                return this.iPESONETOTOTAL;
            }
            set
            {
                this.iPESONETOTOTAL = value;
                this.isnull["IPESONETOTOTAL"] = false;
            }
        }

        private string iNUMTOTALMERCANCIAS;
        public string INUMTOTALMERCANCIAS
        {
            get
            {
                return this.iNUMTOTALMERCANCIAS;
            }
            set
            {
                this.iNUMTOTALMERCANCIAS = value;
                this.isnull["INUMTOTALMERCANCIAS"] = false;
            }
        }

        private string iCARGOPORTASACION;
        public string ICARGOPORTASACION
        {
            get
            {
                return this.iCARGOPORTASACION;
            }
            set
            {
                this.iCARGOPORTASACION = value;
                this.isnull["ICARGOPORTASACION"] = false;
            }
        }


        public void FillFromCartaPorteLinea(CCARTAPORTELINEABE line)
        {

            if (!(bool)line.isnull["IPESOBRUTOTOTAL"])
                this.IPESOBRUTOTOTAL = line.IPESOBRUTOTOTAL;

            if (!(bool)line.isnull["IUNIDADPESO"])
                this.IUNIDADPESO = line.IUNIDADPESO;

            if (!(bool)line.isnull["IPESONETOTOTAL"])
                this.IPESONETOTOTAL = line.IPESONETOTOTAL;

            if (!(bool)line.isnull["INUMTOTALMERCANCIAS"])
                this.INUMTOTALMERCANCIAS = line.INUMTOTALMERCANCIAS;

            if (!(bool)line.isnull["ICARGOPORTASACION"])
                this.ICARGOPORTASACION = line.ICARGOPORTASACION;

        }

        public CCARTAPORTETOTALMERCANCIASBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("IPESOBRUTOTOTAL", true);


            isnull.Add("IUNIDADPESO", true);


            isnull.Add("IPESONETOTOTAL", true);


            isnull.Add("INUMTOTALMERCANCIAS", true);


            isnull.Add("ICARGOPORTASACION", true);

        }



    }
}
