
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace iPosBusinessEntity
{
    public class PPCCompraAMatriz
    {

        private long dOCTOID;
        private long mOVTOID;
        private string fACTURA;
        private short pARTIDA;
        private string pRODUCTOCLAVE;
        private string dESCRIPCION1;
        private string mARCACLAVE;
        private string lINEACLAVE;
        private decimal cANTIDAD;
        private string lOTE;
        private decimal pRECIO;
        private decimal tOTAL;
        private DateTime fECHA;
        private decimal iMPORTE;
        private decimal cOSTO;
        private string sUCURSALCLAVE;
        private decimal dESCUENTO;
        private string dESCRIPCION2;
        private string pROVEEDORCLAVE;
        private DateTime fECHAVENCE;
        private string uSUARIOCLAVE;
        
        public long DOCTOID { get => dOCTOID; set => dOCTOID = value; }
        
        public long MOVTOID { get => mOVTOID; set => mOVTOID = value; }
        
        public string FACTURA { get => fACTURA; set => fACTURA = value; }
        
        public short PARTIDA { get => pARTIDA; set => pARTIDA = value; }
        
        public string PRODUCTOCLAVE { get => pRODUCTOCLAVE; set => pRODUCTOCLAVE = value; }
        
        public string DESCRIPCION1 { get => dESCRIPCION1; set => dESCRIPCION1 = value; }
        
        public string MARCACLAVE { get => mARCACLAVE; set => mARCACLAVE = value; }
        
        public string LINEACLAVE { get => lINEACLAVE; set => lINEACLAVE = value; }
        
        public decimal CANTIDAD { get => cANTIDAD; set => cANTIDAD = value; }
        
        public string LOTE { get => lOTE; set => lOTE = value; }
        
        public decimal PRECIO { get => pRECIO; set => pRECIO = value; }
        
        public decimal TOTAL { get => tOTAL; set => tOTAL = value; }
        
        public DateTime FECHA { get => fECHA; set => fECHA = value; }
        
        public decimal IMPORTE { get => iMPORTE; set => iMPORTE = value; }
        
        public decimal COSTO { get => cOSTO; set => cOSTO = value; }
        
        public string SUCURSALCLAVE { get => sUCURSALCLAVE; set => sUCURSALCLAVE = value; }
        
        public decimal DESCUENTO { get => dESCUENTO; set => dESCUENTO = value; }
        
        public string DESCRIPCION2 { get => dESCRIPCION2; set => dESCRIPCION2 = value; }
        
        public string PROVEEDORCLAVE { get => pROVEEDORCLAVE; set => pROVEEDORCLAVE = value; }
        
        public DateTime FECHAVENCE { get => fECHAVENCE; set => fECHAVENCE = value; }
        
        public string USUARIOCLAVE { get => uSUARIOCLAVE; set => uSUARIOCLAVE = value; }


    }
}