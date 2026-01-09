using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPosBusinessEntity
{
    public class CM_PLAZOBE
    {
        public Hashtable isnull;

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

        private string iCOMISIONST;
        public string ICOMISIONST
        {
            get
            {
                return this.iCOMISIONST;
            }
            set
            {
                this.iCOMISIONST = value;
                this.isnull["ICOMISIONST"] = false;
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

        private int iDIAS;
        public int IDIAS
        {
            get
            {
                return this.iDIAS;
            }
            set
            {
                this.iDIAS = value;
                this.isnull["IDIAS"] = false;
            }
        }

        public CM_PLAZOBE()
        {
            isnull = new Hashtable();

            isnull.Add("IACTIVO", true);

            isnull.Add("ICLAVE", true);


            isnull.Add("INOMBRE", true);


            isnull.Add("ICOMISIONST", true);


            isnull.Add("ILEYENDA", true);

            isnull.Add("IDIAS", true);
        }

    }
}
