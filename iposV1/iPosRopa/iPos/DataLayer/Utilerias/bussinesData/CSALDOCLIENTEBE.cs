using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Utilerias.bussinesData
{
    public class CSALDOCLIENTEBE
    {
        private string iCLIENTECLAVE;
        public string ICLIENTECLAVE
        {
            get
            {
                return this.iCLIENTECLAVE;
            }
            set
            {
                this.iCLIENTECLAVE = value;
            }
        }

        private string iPRODUCTOCLAVE;
        public string IPRODUCTOCLAVE
        {
            get
            {
                return this.iPRODUCTOCLAVE;
            }
            set
            {
                this.iPRODUCTOCLAVE = value;
            }
        }

        private long iCANTIDAD;
        public long ICANTIDAD
        {
            get
            {
                return this.iCANTIDAD;
            }
            set
            {
                this.iCANTIDAD = value;
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
            }
        }

        private string iREFERENCIASISTEMAANT;
        public string IREFERENCIASISTEMAANT
        {
            get
            {
                return this.iREFERENCIASISTEMAANT;
            }
            set
            {
                this.iREFERENCIASISTEMAANT = value;
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
            }
        }

        private DateTime iFECHAVENCE;
        public DateTime IFECHAVENCE
        {
            get
            {
                return this.iFECHAVENCE;
            }
            set
            {
                this.iFECHAVENCE = value;
            }
        }
    }
}
