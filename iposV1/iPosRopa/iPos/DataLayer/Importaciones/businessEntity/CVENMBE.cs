
using System;
using System.Collections;

namespace iPosBusinessEntity
{
    public class CVENMBE
    {
        public Hashtable isnull;

        private string iVENTA;
        public string IVENTA
        {
            get
            {
                return this.iVENTA;
            }
            set
            {
                this.iVENTA = value;
                this.isnull["IVENTA"] = false;
            }
        }

        private string iCLIENTE;
        public string ICLIENTE
        {
            get
            {
                return this.iCLIENTE;
            }
            set
            {
                this.iCLIENTE = value;
                this.isnull["ICLIENTE"] = false;
            }
        }

        private string iESTATUS;
        public string IESTATUS
        {
            get
            {
                return this.iESTATUS;
            }
            set
            {
                this.iESTATUS = value;
                this.isnull["IESTATUS"] = false;
            }
        }

        private DateTime iPEDIDO;
        public DateTime IPEDIDO
        {
            get
            {
                return this.iPEDIDO;
            }
            set
            {
                this.iPEDIDO = value;
                this.isnull["IPEDIDO"] = false;
            }
        }

        private string iFACTURA;
        public string IFACTURA
        {
            get
            {
                return this.iFACTURA;
            }
            set
            {
                this.iFACTURA = value;
                this.isnull["IFACTURA"] = false;
            }
        }

        private DateTime iF_FACTURA;
        public DateTime IF_FACTURA
        {
            get
            {
                return this.iF_FACTURA;
            }
            set
            {
                this.iF_FACTURA = value;
                this.isnull["IF_FACTURA"] = false;
            }
        }

        private string iVENDEDOR;
        public string IVENDEDOR
        {
            get
            {
                return this.iVENDEDOR;
            }
            set
            {
                this.iVENDEDOR = value;
                this.isnull["IVENDEDOR"] = false;
            }
        }

        private decimal iSUMA;
        public decimal ISUMA
        {
            get
            {
                return this.iSUMA;
            }
            set
            {
                this.iSUMA = value;
                this.isnull["ISUMA"] = false;
            }
        }

        private decimal iIMPUESTO;
        public decimal IIMPUESTO
        {
            get
            {
                return this.iIMPUESTO;
            }
            set
            {
                this.iIMPUESTO = value;
                this.isnull["IIMPUESTO"] = false;
            }
        }

        private decimal iIMPUESTO2;
        public decimal IIMPUESTO2
        {
            get
            {
                return this.iIMPUESTO2;
            }
            set
            {
                this.iIMPUESTO2 = value;
                this.isnull["IIMPUESTO2"] = false;
            }
        }

        private decimal iTOTAL;
        public decimal ITOTAL
        {
            get
            {
                return this.iTOTAL;
            }
            set
            {
                this.iTOTAL = value;
                this.isnull["ITOTAL"] = false;
            }
        }

        private decimal iSALDO;
        public decimal ISALDO
        {
            get
            {
                return this.iSALDO;
            }
            set
            {
                this.iSALDO = value;
                this.isnull["ISALDO"] = false;
            }
        }

        private decimal iSUCURSAL;
        public decimal ISUCURSAL
        {
            get
            {
                return this.iSUCURSAL;
            }
            set
            {
                this.iSUCURSAL = value;
                this.isnull["ISUCURSAL"] = false;
            }
        }

        private decimal iDESCUENTO;
        public decimal IDESCUENTO
        {
            get
            {
                return this.iDESCUENTO;
            }
            set
            {
                this.iDESCUENTO = value;
                this.isnull["IDESCUENTO"] = false;
            }
        }

        private decimal iDESC_PPP1;
        public decimal IDESC_PPP1
        {
            get
            {
                return this.iDESC_PPP1;
            }
            set
            {
                this.iDESC_PPP1 = value;
                this.isnull["IDESC_PPP1"] = false;
            }
        }

        private decimal iDESC_PPP2;
        public decimal IDESC_PPP2
        {
            get
            {
                return this.iDESC_PPP2;
            }
            set
            {
                this.iDESC_PPP2 = value;
                this.isnull["IDESC_PPP2"] = false;
            }
        }

        private decimal iDESC_PPP3;
        public decimal IDESC_PPP3
        {
            get
            {
                return this.iDESC_PPP3;
            }
            set
            {
                this.iDESC_PPP3 = value;
                this.isnull["IDESC_PPP3"] = false;
            }
        }

        private decimal iDESCUENTO1;
        public decimal IDESCUENTO1
        {
            get
            {
                return this.iDESCUENTO1;
            }
            set
            {
                this.iDESCUENTO1 = value;
                this.isnull["IDESCUENTO1"] = false;
            }
        }

        private decimal iDESCUENTO2;
        public decimal IDESCUENTO2
        {
            get
            {
                return this.iDESCUENTO2;
            }
            set
            {
                this.iDESCUENTO2 = value;
                this.isnull["IDESCUENTO2"] = false;
            }
        }

        private decimal iDESCUENTO3;
        public decimal IDESCUENTO3
        {
            get
            {
                return this.iDESCUENTO3;
            }
            set
            {
                this.iDESCUENTO3 = value;
                this.isnull["IDESCUENTO3"] = false;
            }
        }

        private decimal iA_CUENTA;
        public decimal IA_CUENTA
        {
            get
            {
                return this.iA_CUENTA;
            }
            set
            {
                this.iA_CUENTA = value;
                this.isnull["IA_CUENTA"] = false;
            }
        }

        private decimal iCOMISION;
        public decimal ICOMISION
        {
            get
            {
                return this.iCOMISION;
            }
            set
            {
                this.iCOMISION = value;
                this.isnull["ICOMISION"] = false;
            }
        }

        private decimal iCOMISION_U;
        public decimal ICOMISION_U
        {
            get
            {
                return this.iCOMISION_U;
            }
            set
            {
                this.iCOMISION_U = value;
                this.isnull["ICOMISION_U"] = false;
            }
        }

        private decimal iCOMISION_E;
        public decimal ICOMISION_E
        {
            get
            {
                return this.iCOMISION_E;
            }
            set
            {
                this.iCOMISION_E = value;
                this.isnull["ICOMISION_E"] = false;
            }
        }

        private DateTime iPAGO;
        public DateTime IPAGO
        {
            get
            {
                return this.iPAGO;
            }
            set
            {
                this.iPAGO = value;
                this.isnull["IPAGO"] = false;
            }
        }

        private string iTIPO_PAGO;
        public string ITIPO_PAGO
        {
            get
            {
                return this.iTIPO_PAGO;
            }
            set
            {
                this.iTIPO_PAGO = value;
                this.isnull["ITIPO_PAGO"] = false;
            }
        }

        private string iNOTA1;
        public string INOTA1
        {
            get
            {
                return this.iNOTA1;
            }
            set
            {
                this.iNOTA1 = value;
                this.isnull["INOTA1"] = false;
            }
        }

        private string iNOTA2;
        public string INOTA2
        {
            get
            {
                return this.iNOTA2;
            }
            set
            {
                this.iNOTA2 = value;
                this.isnull["INOTA2"] = false;
            }
        }

        private string iNOTA3;
        public string INOTA3
        {
            get
            {
                return this.iNOTA3;
            }
            set
            {
                this.iNOTA3 = value;
                this.isnull["INOTA3"] = false;
            }
        }

        private decimal iCREDITO;
        public decimal ICREDITO
        {
            get
            {
                return this.iCREDITO;
            }
            set
            {
                this.iCREDITO = value;
                this.isnull["ICREDITO"] = false;
            }
        }

        private string iMES;
        public string IMES
        {
            get
            {
                return this.iMES;
            }
            set
            {
                this.iMES = value;
                this.isnull["IMES"] = false;
            }
        }

        private decimal iCOSTO;
        public decimal ICOSTO
        {
            get
            {
                return this.iCOSTO;
            }
            set
            {
                this.iCOSTO = value;
                this.isnull["ICOSTO"] = false;
            }
        }

        private decimal iCOSTOUS;
        public decimal ICOSTOUS
        {
            get
            {
                return this.iCOSTOUS;
            }
            set
            {
                this.iCOSTOUS = value;
                this.isnull["ICOSTOUS"] = false;
            }
        }

        private decimal iREMISION;
        public decimal IREMISION
        {
            get
            {
                return this.iREMISION;
            }
            set
            {
                this.iREMISION = value;
                this.isnull["IREMISION"] = false;
            }
        }

        private DateTime iF_REMISION;
        public DateTime IF_REMISION
        {
            get
            {
                return this.iF_REMISION;
            }
            set
            {
                this.iF_REMISION = value;
                this.isnull["IF_REMISION"] = false;
            }
        }

        private string iTODOUS;
        public string ITODOUS
        {
            get
            {
                return this.iTODOUS;
            }
            set
            {
                this.iTODOUS = value;
                this.isnull["ITODOUS"] = false;
            }
        }

        private string iENDOLARES;
        public string IENDOLARES
        {
            get
            {
                return this.iENDOLARES;
            }
            set
            {
                this.iENDOLARES = value;
                this.isnull["IENDOLARES"] = false;
            }
        }

        private decimal iTC;
        public decimal ITC
        {
            get
            {
                return this.iTC;
            }
            set
            {
                this.iTC = value;
                this.isnull["ITC"] = false;
            }
        }

        private decimal iSUMAUS;
        public decimal ISUMAUS
        {
            get
            {
                return this.iSUMAUS;
            }
            set
            {
                this.iSUMAUS = value;
                this.isnull["ISUMAUS"] = false;
            }
        }

        private decimal iIMPUESTOUS;
        public decimal IIMPUESTOUS
        {
            get
            {
                return this.iIMPUESTOUS;
            }
            set
            {
                this.iIMPUESTOUS = value;
                this.isnull["IIMPUESTOUS"] = false;
            }
        }

        private decimal iTOTALUS;
        public decimal ITOTALUS
        {
            get
            {
                return this.iTOTALUS;
            }
            set
            {
                this.iTOTALUS = value;
                this.isnull["ITOTALUS"] = false;
            }
        }

        private decimal iA_CUENTAUS;
        public decimal IA_CUENTAUS
        {
            get
            {
                return this.iA_CUENTAUS;
            }
            set
            {
                this.iA_CUENTAUS = value;
                this.isnull["IA_CUENTAUS"] = false;
            }
        }

        private decimal iSALDO_US;
        public decimal ISALDO_US
        {
            get
            {
                return this.iSALDO_US;
            }
            set
            {
                this.iSALDO_US = value;
                this.isnull["ISALDO_US"] = false;
            }
        }

        private string iENTREGA;
        public string IENTREGA
        {
            get
            {
                return this.iENTREGA;
            }
            set
            {
                this.iENTREGA = value;
                this.isnull["IENTREGA"] = false;
            }
        }

        private string iSURTIDO;
        public string ISURTIDO
        {
            get
            {
                return this.iSURTIDO;
            }
            set
            {
                this.iSURTIDO = value;
                this.isnull["ISURTIDO"] = false;
            }
        }

        private string iCONDICION;
        public string ICONDICION
        {
            get
            {
                return this.iCONDICION;
            }
            set
            {
                this.iCONDICION = value;
                this.isnull["ICONDICION"] = false;
            }
        }

        private string iCONDICION2;
        public string ICONDICION2
        {
            get
            {
                return this.iCONDICION2;
            }
            set
            {
                this.iCONDICION2 = value;
                this.isnull["ICONDICION2"] = false;
            }
        }

        private decimal iNUMERO;
        public decimal INUMERO
        {
            get
            {
                return this.iNUMERO;
            }
            set
            {
                this.iNUMERO = value;
                this.isnull["INUMERO"] = false;
            }
        }

        private decimal iNCREDITOPP;
        public decimal INCREDITOPP
        {
            get
            {
                return this.iNCREDITOPP;
            }
            set
            {
                this.iNCREDITOPP = value;
                this.isnull["INCREDITOPP"] = false;
            }
        }

        private decimal iNCIVA;
        public decimal INCIVA
        {
            get
            {
                return this.iNCIVA;
            }
            set
            {
                this.iNCIVA = value;
                this.isnull["INCIVA"] = false;
            }
        }

        private decimal iNCTOTAL;
        public decimal INCTOTAL
        {
            get
            {
                return this.iNCTOTAL;
            }
            set
            {
                this.iNCTOTAL = value;
                this.isnull["INCTOTAL"] = false;
            }
        }

        private string iORIGEN;
        public string IORIGEN
        {
            get
            {
                return this.iORIGEN;
            }
            set
            {
                this.iORIGEN = value;
                this.isnull["IORIGEN"] = false;
            }
        }

        private string iEXPORTADO;
        public string IEXPORTADO
        {
            get
            {
                return this.iEXPORTADO;
            }
            set
            {
                this.iEXPORTADO = value;
                this.isnull["IEXPORTADO"] = false;
            }
        }

        private string iPLANO;
        public string IPLANO
        {
            get
            {
                return this.iPLANO;
            }
            set
            {
                this.iPLANO = value;
                this.isnull["IPLANO"] = false;
            }
        }

        private string iMONEDA;
        public string IMONEDA
        {
            get
            {
                return this.iMONEDA;
            }
            set
            {
                this.iMONEDA = value;
                this.isnull["IMONEDA"] = false;
            }
        }

        private string iEXPORTADOC;
        public string IEXPORTADOC
        {
            get
            {
                return this.iEXPORTADOC;
            }
            set
            {
                this.iEXPORTADOC = value;
                this.isnull["IEXPORTADOC"] = false;
            }
        }

        private string iCAJERO;
        public string ICAJERO
        {
            get
            {
                return this.iCAJERO;
            }
            set
            {
                this.iCAJERO = value;
                this.isnull["ICAJERO"] = false;
            }
        }

        private string iHORAFACT;
        public string IHORAFACT
        {
            get
            {
                return this.iHORAFACT;
            }
            set
            {
                this.iHORAFACT = value;
                this.isnull["IHORAFACT"] = false;
            }
        }

        private decimal iSUMAX;
        public decimal ISUMAX
        {
            get
            {
                return this.iSUMAX;
            }
            set
            {
                this.iSUMAX = value;
                this.isnull["ISUMAX"] = false;
            }
        }

        private decimal iIMPUESTOX;
        public decimal IIMPUESTOX
        {
            get
            {
                return this.iIMPUESTOX;
            }
            set
            {
                this.iIMPUESTOX = value;
                this.isnull["IIMPUESTOX"] = false;
            }
        }

        private decimal iTOTALX;
        public decimal ITOTALX
        {
            get
            {
                return this.iTOTALX;
            }
            set
            {
                this.iTOTALX = value;
                this.isnull["ITOTALX"] = false;
            }
        }

        private string iID;
        public string IID
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

        private DateTime iID_FECHA;
        public DateTime IID_FECHA
        {
            get
            {
                return this.iID_FECHA;
            }
            set
            {
                this.iID_FECHA = value;
                this.isnull["IID_FECHA"] = false;
            }
        }

        private string iID_HORA;
        public string IID_HORA
        {
            get
            {
                return this.iID_HORA;
            }
            set
            {
                this.iID_HORA = value;
                this.isnull["IID_HORA"] = false;
            }
        }

        private string iV_PROMO;
        public string IV_PROMO
        {
            get
            {
                return this.iV_PROMO;
            }
            set
            {
                this.iV_PROMO = value;
                this.isnull["IV_PROMO"] = false;
            }
        }

        private decimal iTOTAL2;
        public decimal ITOTAL2
        {
            get
            {
                return this.iTOTAL2;
            }
            set
            {
                this.iTOTAL2 = value;
                this.isnull["ITOTAL2"] = false;
            }
        }

        private decimal iVALE;
        public decimal IVALE
        {
            get
            {
                return this.iVALE;
            }
            set
            {
                this.iVALE = value;
                this.isnull["IVALE"] = false;
            }
        }

        private decimal iEFECTIVO;
        public decimal IEFECTIVO
        {
            get
            {
                return this.iEFECTIVO;
            }
            set
            {
                this.iEFECTIVO = value;
                this.isnull["IEFECTIVO"] = false;
            }
        }

        private decimal iCHEQUE;
        public decimal ICHEQUE
        {
            get
            {
                return this.iCHEQUE;
            }
            set
            {
                this.iCHEQUE = value;
                this.isnull["ICHEQUE"] = false;
            }
        }

        private decimal iTARJETA;
        public decimal ITARJETA
        {
            get
            {
                return this.iTARJETA;
            }
            set
            {
                this.iTARJETA = value;
                this.isnull["ITARJETA"] = false;
            }
        }

        private decimal iNUM_VALE;
        public decimal INUM_VALE
        {
            get
            {
                return this.iNUM_VALE;
            }
            set
            {
                this.iNUM_VALE = value;
                this.isnull["INUM_VALE"] = false;
            }
        }

        private decimal iDESCUENTOV;
        public decimal IDESCUENTOV
        {
            get
            {
                return this.iDESCUENTOV;
            }
            set
            {
                this.iDESCUENTOV = value;
                this.isnull["IDESCUENTOV"] = false;
            }
        }

        private DateTime iFECHA_2;
        public DateTime IFECHA_2
        {
            get
            {
                return this.iFECHA_2;
            }
            set
            {
                this.iFECHA_2 = value;
                this.isnull["IFECHA_2"] = false;
            }
        }

        private string iVCOMISION;
        public string IVCOMISION
        {
            get
            {
                return this.iVCOMISION;
            }
            set
            {
                this.iVCOMISION = value;
                this.isnull["IVCOMISION"] = false;
            }
        }

        public CVENMBE()
        {
            isnull = new Hashtable();


            isnull.Add("IVENTA", true);


            isnull.Add("ICLIENTE", true);


            isnull.Add("IESTATUS", true);


            isnull.Add("IPEDIDO", true);


            isnull.Add("IFACTURA", true);


            isnull.Add("IF_FACTURA", true);


            isnull.Add("IVENDEDOR", true);


            isnull.Add("ISUMA", true);


            isnull.Add("IIMPUESTO", true);


            isnull.Add("IIMPUESTO2", true);


            isnull.Add("ITOTAL", true);


            isnull.Add("ISALDO", true);


            isnull.Add("ISUCURSAL", true);


            isnull.Add("IDESCUENTO", true);


            isnull.Add("IDESC_PPP1", true);


            isnull.Add("IDESC_PPP2", true);


            isnull.Add("IDESC_PPP3", true);


            isnull.Add("IDESCUENTO1", true);


            isnull.Add("IDESCUENTO2", true);


            isnull.Add("IDESCUENTO3", true);


            isnull.Add("IA_CUENTA", true);


            isnull.Add("ICOMISION", true);


            isnull.Add("ICOMISION_U", true);


            isnull.Add("ICOMISION_E", true);


            isnull.Add("IPAGO", true);


            isnull.Add("ITIPO_PAGO", true);


            isnull.Add("INOTA1", true);


            isnull.Add("INOTA2", true);


            isnull.Add("INOTA3", true);


            isnull.Add("ICREDITO", true);


            isnull.Add("IMES", true);


            isnull.Add("ICOSTO", true);


            isnull.Add("ICOSTOUS", true);


            isnull.Add("IREMISION", true);


            isnull.Add("IF_REMISION", true);


            isnull.Add("ITODOUS", true);


            isnull.Add("IENDOLARES", true);


            isnull.Add("ITC", true);


            isnull.Add("ISUMAUS", true);


            isnull.Add("IIMPUESTOUS", true);


            isnull.Add("ITOTALUS", true);


            isnull.Add("IA_CUENTAUS", true);


            isnull.Add("ISALDO_US", true);


            isnull.Add("IENTREGA", true);


            isnull.Add("ISURTIDO", true);


            isnull.Add("ICONDICION", true);


            isnull.Add("ICONDICION2", true);


            isnull.Add("INUMERO", true);


            isnull.Add("INCREDITOPP", true);


            isnull.Add("INCIVA", true);


            isnull.Add("INCTOTAL", true);


            isnull.Add("IORIGEN", true);


            isnull.Add("IEXPORTADO", true);


            isnull.Add("IPLANO", true);


            isnull.Add("IMONEDA", true);


            isnull.Add("IEXPORTADOC", true);


            isnull.Add("ICAJERO", true);


            isnull.Add("IHORAFACT", true);


            isnull.Add("ISUMAX", true);


            isnull.Add("IIMPUESTOX", true);


            isnull.Add("ITOTALX", true);


            isnull.Add("IID", true);


            isnull.Add("IID_FECHA", true);


            isnull.Add("IID_HORA", true);


            isnull.Add("IV_PROMO", true);


            isnull.Add("ITOTAL2", true);


            isnull.Add("IVALE", true);


            isnull.Add("IEFECTIVO", true);


            isnull.Add("ICHEQUE", true);


            isnull.Add("ITARJETA", true);


            isnull.Add("INUM_VALE", true);


            isnull.Add("IDESCUENTOV", true);


            isnull.Add("IFECHA_2", true);


            isnull.Add("IVCOMISION", true);

        }



    }
}
