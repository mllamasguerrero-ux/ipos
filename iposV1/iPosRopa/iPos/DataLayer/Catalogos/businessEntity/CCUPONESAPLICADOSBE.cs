using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CCUPONESAPLICADOSBE
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

        private long iDOCTOID;
        public long IDOCTOID
        {
            get
            {
                return this.iDOCTOID;
            }
            set
            {
                this.iDOCTOID = value;
                this.isnull["IDOCTOID"] = false;
            }
        }

        private long iPROMOCIONCUPONID;
        public long IPROMOCIONCUPONID
        {
            get
            {
                return this.iPROMOCIONCUPONID;
            }
            set
            {
                this.iPROMOCIONCUPONID = value;
                this.isnull["IPROMOCIONCUPONID"] = false;
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

        private string iLEYENDA;
        public string ILEYENDA
        {
            get
            {
                return this.iLEYENDA;
            }
            set
            {
                this.iLEYENDA = value;
                this.isnull["ILEYENDA"] = false;
            }
        }

        public CCUPONESAPLICADOSBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("IDOCTOID", true);


            isnull.Add("IPROMOCIONCUPONID", true);


            isnull.Add("ICANTIDAD", true);

            isnull.Add("ILEYENDA", true);

        }



    }
}
