
using Newtonsoft.Json;
using System;
using System.Collections;

namespace iPosBusinessEntity
{
    public class CCARTAPORTECANTTRANSPBE
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

        private string iCANTIDAD;
        public string ICANTIDAD
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

        private string iIDORIGEN;
        public string IIDORIGEN
        {
            get
            {
                return this.iIDORIGEN;
            }
            set
            {
                this.iIDORIGEN = value;
                this.isnull["IIDORIGEN"] = false;
            }
        }

        private string iIDDESTINO;
        public string IIDDESTINO
        {
            get
            {
                return this.iIDDESTINO;
            }
            set
            {
                this.iIDDESTINO = value;
                this.isnull["IIDDESTINO"] = false;
            }
        }

        private string iCVESTRANSPORTE;
        public string ICVESTRANSPORTE
        {
            get
            {
                return this.iCVESTRANSPORTE;
            }
            set
            {
                this.iCVESTRANSPORTE = value;
                this.isnull["ICVESTRANSPORTE"] = false;
            }
        }


        public void FillFromCartaPorteLinea(CCARTAPORTELINEABE line)
        {

            if (!(bool)line.isnull["ICANTIDAD"])
                this.ICANTIDAD = line.ICANTIDAD;

            if (!(bool)line.isnull["IIDORIGEN"])
                this.IIDORIGEN = line.IIDORIGEN;

            if (!(bool)line.isnull["IIDDESTINO"])
                this.IIDDESTINO = line.IIDDESTINO;

            if (!(bool)line.isnull["ICVESTRANSPORTE"])
                this.ICVESTRANSPORTE = line.ICVESTRANSPORTE;

        }

        public CCARTAPORTECANTTRANSPBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("ICANTIDAD", true);


            isnull.Add("IIDORIGEN", true);


            isnull.Add("IIDDESTINO", true);


            isnull.Add("ICVESTRANSPORTE", true);

        }



    }
}
