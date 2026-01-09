using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;

namespace iPosBusinessEntity
{
    public class CMPRODBE
    {
        public Hashtable isnull;

        private string iPRODUCTO;
        public string IPRODUCTO
        {
            get
            {
                return this.iPRODUCTO;
            }
            set
            {
                this.iPRODUCTO = value;
                this.isnull["IPRODUCTO"] = false;
            }
        }

        private string iDESC1;
        public string IDESC1
        {
            get
            {
                return this.iDESC1;
            }
            set
            {
                this.iDESC1 = value;
                this.isnull["IDESC1"] = false;
            }
        }

        private decimal iPRECIO1;
        public decimal IPRECIO1
        {
            get
            {
                return this.iPRECIO1;
            }
            set
            {
                this.iPRECIO1 = value;
                this.isnull["IPRECIO1"] = false;
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

        private decimal iU_EMPAQUE;
        public decimal IU_EMPAQUE
        {
            get
            {
                return this.iU_EMPAQUE;
            }
            set
            {
                this.iU_EMPAQUE = value;
                this.isnull["IU_EMPAQUE"] = false;
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

        private string iUNIDAD;
        public string IUNIDAD
        {
            get
            {
                return this.iUNIDAD;
            }
            set
            {
                this.iUNIDAD = value;
                this.isnull["IUNIDAD"] = false;
            }
        }

        private string iSERIE;
        public string ISERIE
        {
            get
            {
                return this.iSERIE;
            }
            set
            {
                this.iSERIE = value;
                this.isnull["ISERIE"] = false;
            }
        }

        private string iLOTE;
        public string ILOTE
        {
            get
            {
                return this.iLOTE;
            }
            set
            {
                this.iLOTE = value;
                this.isnull["ILOTE"] = false;
            }
        }

        private string iPROVEEDOR;
        public string IPROVEEDOR
        {
            get
            {
                return this.iPROVEEDOR;
            }
            set
            {
                this.iPROVEEDOR = value;
                this.isnull["IPROVEEDOR"] = false;
            }
        }

        private string iPROVEEDOR2;
        public string IPROVEEDOR2
        {
            get
            {
                return this.iPROVEEDOR2;
            }
            set
            {
                this.iPROVEEDOR2 = value;
                this.isnull["IPROVEEDOR2"] = false;
            }
        }

        private string iLINEA;
        public string ILINEA
        {
            get
            {
                return this.iLINEA;
            }
            set
            {
                this.iLINEA = value;
                this.isnull["ILINEA"] = false;
            }
        }

        private string iMARCA;
        public string IMARCA
        {
            get
            {
                return this.iMARCA;
            }
            set
            {
                this.iMARCA = value;
                this.isnull["IMARCA"] = false;
            }
        }

        private string iDESC2;
        public string IDESC2
        {
            get
            {
                return this.iDESC2;
            }
            set
            {
                this.iDESC2 = value;
                this.isnull["IDESC2"] = false;
            }
        }

        private string iDESC3;
        public string IDESC3
        {
            get
            {
                return this.iDESC3;
            }
            set
            {
                this.iDESC3 = value;
                this.isnull["IDESC3"] = false;
            }
        }

        private decimal iPRECIO2;
        public decimal IPRECIO2
        {
            get
            {
                return this.iPRECIO2;
            }
            set
            {
                this.iPRECIO2 = value;
                this.isnull["IPRECIO2"] = false;
            }
        }

        private decimal iPRECIO3;
        public decimal IPRECIO3
        {
            get
            {
                return this.iPRECIO3;
            }
            set
            {
                this.iPRECIO3 = value;
                this.isnull["IPRECIO3"] = false;
            }
        }

        private decimal iPRECIO4;
        public decimal IPRECIO4
        {
            get
            {
                return this.iPRECIO4;
            }
            set
            {
                this.iPRECIO4 = value;
                this.isnull["IPRECIO4"] = false;
            }
        }

        private decimal iPRECIO5;
        public decimal IPRECIO5
        {
            get
            {
                return this.iPRECIO5;
            }
            set
            {
                this.iPRECIO5 = value;
                this.isnull["IPRECIO5"] = false;
            }
        }

        private decimal iPRECIO6;
        public decimal IPRECIO6
        {
            get
            {
                return this.iPRECIO6;
            }
            set
            {
                this.iPRECIO6 = value;
                this.isnull["IPRECIO6"] = false;
            }
        }

        private decimal iPRECIO7;
        public decimal IPRECIO7
        {
            get
            {
                return this.iPRECIO7;
            }
            set
            {
                this.iPRECIO7 = value;
                this.isnull["IPRECIO7"] = false;
            }
        }

        private string iCODIGO;
        public string ICODIGO
        {
            get
            {
                return this.iCODIGO;
            }
            set
            {
                this.iCODIGO = value;
                this.isnull["ICODIGO"] = false;
            }
        }

        private decimal iCARGOS_U;
        public decimal ICARGOS_U
        {
            get
            {
                return this.iCARGOS_U;
            }
            set
            {
                this.iCARGOS_U = value;
                this.isnull["ICARGOS_U"] = false;
            }
        }

        private decimal iCOSTO_REPO;
        public decimal ICOSTO_REPO
        {
            get
            {
                return this.iCOSTO_REPO;
            }
            set
            {
                this.iCOSTO_REPO = value;
                this.isnull["ICOSTO_REPO"] = false;
            }
        }

        private string iIMPRIMIR;
        public string IIMPRIMIR
        {
            get
            {
                return this.iIMPRIMIR;
            }
            set
            {
                this.iIMPRIMIR = value;
                this.isnull["IIMPRIMIR"] = false;
            }
        }

        private string iINVENTARIO;
        public string IINVENTARIO
        {
            get
            {
                return this.iINVENTARIO;
            }
            set
            {
                this.iINVENTARIO = value;
                this.isnull["IINVENTARIO"] = false;
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

        private string iNEGATIVOS;
        public string INEGATIVOS
        {
            get
            {
                return this.iNEGATIVOS;
            }
            set
            {
                this.iNEGATIVOS = value;
                this.isnull["INEGATIVOS"] = false;
            }
        }

        private string iCOMODIN;
        public string ICOMODIN
        {
            get
            {
                return this.iCOMODIN;
            }
            set
            {
                this.iCOMODIN = value;
                this.isnull["ICOMODIN"] = false;
            }
        }

        private decimal iLIMITE1;
        public decimal ILIMITE1
        {
            get
            {
                return this.iLIMITE1;
            }
            set
            {
                this.iLIMITE1 = value;
                this.isnull["ILIMITE1"] = false;
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

        private decimal iLIMITE2;
        public decimal ILIMITE2
        {
            get
            {
                return this.iLIMITE2;
            }
            set
            {
                this.iLIMITE2 = value;
                this.isnull["ILIMITE2"] = false;
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

        private string iKIT;
        public string IKIT
        {
            get
            {
                return this.iKIT;
            }
            set
            {
                this.iKIT = value;
                this.isnull["IKIT"] = false;
            }
        }

        private decimal iPIEZAS;
        public decimal IPIEZAS
        {
            get
            {
                return this.iPIEZAS;
            }
            set
            {
                this.iPIEZAS = value;
                this.isnull["IPIEZAS"] = false;
            }
        }

        private string iLPIEZAS;
        public string ILPIEZAS
        {
            get
            {
                return this.iLPIEZAS;
            }
            set
            {
                this.iLPIEZAS = value;
                this.isnull["ILPIEZAS"] = false;
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

        private string iPROMOCION;
        public string IPROMOCION
        {
            get
            {
                return this.iPROMOCION;
            }
            set
            {
                this.iPROMOCION = value;
                this.isnull["IPROMOCION"] = false;
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

        private string iSUSTITUTO;
        public string ISUSTITUTO
        {
            get
            {
                return this.iSUSTITUTO;
            }
            set
            {
                this.iSUSTITUTO = value;
                this.isnull["ISUSTITUTO"] = false;
            }
        }

        private string iCBARRAS;
        public string ICBARRAS
        {
            get
            {
                return this.iCBARRAS;
            }
            set
            {
                this.iCBARRAS = value;
                this.isnull["ICBARRAS"] = false;
            }
        }

        private decimal iEMPAQUE;
        public decimal IEMPAQUE
        {
            get
            {
                return this.iEMPAQUE;
            }
            set
            {
                this.iEMPAQUE = value;
                this.isnull["IEMPAQUE"] = false;
            }
        }

        private decimal iPESO;
        public decimal IPESO
        {
            get
            {
                return this.iPESO;
            }
            set
            {
                this.iPESO = value;
                this.isnull["IPESO"] = false;
            }
        }

        private decimal iPRECIO8;
        public decimal IPRECIO8
        {
            get
            {
                return this.iPRECIO8;
            }
            set
            {
                this.iPRECIO8 = value;
                this.isnull["IPRECIO8"] = false;
            }
        }

        private decimal iPRECIO9;
        public decimal IPRECIO9
        {
            get
            {
                return this.iPRECIO9;
            }
            set
            {
                this.iPRECIO9 = value;
                this.isnull["IPRECIO9"] = false;
            }
        }

        private decimal iU_CAJA;
        public decimal IU_CAJA
        {
            get
            {
                return this.iU_CAJA;
            }
            set
            {
                this.iU_CAJA = value;
                this.isnull["IU_CAJA"] = false;
            }
        }

        private string iCUENTA;
        public string ICUENTA
        {
            get
            {
                return this.iCUENTA;
            }
            set
            {
                this.iCUENTA = value;
                this.isnull["ICUENTA"] = false;
            }
        }

        private decimal iRANKING;
        public decimal IRANKING
        {
            get
            {
                return this.iRANKING;
            }
            set
            {
                this.iRANKING = value;
                this.isnull["IRANKING"] = false;
            }
        }

        private string iTIPOABC;
        public string ITIPOABC
        {
            get
            {
                return this.iTIPOABC;
            }
            set
            {
                this.iTIPOABC = value;
                this.isnull["ITIPOABC"] = false;
            }
        }

        private string iTRAFICO;
        public string ITRAFICO
        {
            get
            {
                return this.iTRAFICO;
            }
            set
            {
                this.iTRAFICO = value;
                this.isnull["ITRAFICO"] = false;
            }
        }

        private string iUNIDAD2;
        public string IUNIDAD2
        {
            get
            {
                return this.iUNIDAD2;
            }
            set
            {
                this.iUNIDAD2 = value;
                this.isnull["IUNIDAD2"] = false;
            }
        }

        private decimal iU_VENTA2;
        public decimal IU_VENTA2
        {
            get
            {
                return this.iU_VENTA2;
            }
            set
            {
                this.iU_VENTA2 = value;
                this.isnull["IU_VENTA2"] = false;
            }
        }

        private decimal iVOLUMEN;
        public decimal IVOLUMEN
        {
            get
            {
                return this.iVOLUMEN;
            }
            set
            {
                this.iVOLUMEN = value;
                this.isnull["IVOLUMEN"] = false;
            }
        }

        private decimal iABO;
        public decimal IABO
        {
            get
            {
                return this.iABO;
            }
            set
            {
                this.iABO = value;
                this.isnull["IABO"] = false;
            }
        }

        private string iLOC;
        public string ILOC
        {
            get
            {
                return this.iLOC;
            }
            set
            {
                this.iLOC = value;
                this.isnull["ILOC"] = false;
            }
        }

        private decimal iCOSTO_ULTI;
        public decimal ICOSTO_ULTI
        {
            get
            {
                return this.iCOSTO_ULTI;
            }
            set
            {
                this.iCOSTO_ULTI = value;
                this.isnull["ICOSTO_ULTI"] = false;
            }
        }

        private decimal iCOSTOULTUS;
        public decimal ICOSTOULTUS
        {
            get
            {
                return this.iCOSTOULTUS;
            }
            set
            {
                this.iCOSTOULTUS = value;
                this.isnull["ICOSTOULTUS"] = false;
            }
        }

        private decimal iC_P_I;
        public decimal IC_P_I
        {
            get
            {
                return this.iC_P_I;
            }
            set
            {
                this.iC_P_I = value;
                this.isnull["IC_P_I"] = false;
            }
        }

        private decimal iC_R_I;
        public decimal IC_R_I
        {
            get
            {
                return this.iC_R_I;
            }
            set
            {
                this.iC_R_I = value;
                this.isnull["IC_R_I"] = false;
            }
        }

        private decimal iC_U_I;
        public decimal IC_U_I
        {
            get
            {
                return this.iC_U_I;
            }
            set
            {
                this.iC_U_I = value;
                this.isnull["IC_U_I"] = false;
            }
        }

        private decimal iCOSTOREPUS;
        public decimal ICOSTOREPUS
        {
            get
            {
                return this.iCOSTOREPUS;
            }
            set
            {
                this.iCOSTOREPUS = value;
                this.isnull["ICOSTOREPUS"] = false;
            }
        }

        private decimal iORDEN;
        public decimal IORDEN
        {
            get
            {
                return this.iORDEN;
            }
            set
            {
                this.iORDEN = value;
                this.isnull["IORDEN"] = false;
            }
        }

        private DateTime iFORDEN;
        public DateTime IFORDEN
        {
            get
            {
                return this.iFORDEN;
            }
            set
            {
                this.iFORDEN = value;
                this.isnull["IFORDEN"] = false;
            }
        }

        private decimal iAPARTAKIT;
        public decimal IAPARTAKIT
        {
            get
            {
                return this.iAPARTAKIT;
            }
            set
            {
                this.iAPARTAKIT = value;
                this.isnull["IAPARTAKIT"] = false;
            }
        }

        private DateTime iFMAXDIA;
        public DateTime IFMAXDIA
        {
            get
            {
                return this.iFMAXDIA;
            }
            set
            {
                this.iFMAXDIA = value;
                this.isnull["IFMAXDIA"] = false;
            }
        }

        private decimal iPZACAJA;
        public decimal IPZACAJA
        {
            get
            {
                return this.iPZACAJA;
            }
            set
            {
                this.iPZACAJA = value;
                this.isnull["IPZACAJA"] = false;
            }
        }

        private string iCEMPAQUE;
        public string ICEMPAQUE
        {
            get
            {
                return this.iCEMPAQUE;
            }
            set
            {
                this.iCEMPAQUE = value;
                this.isnull["ICEMPAQUE"] = false;
            }
        }

        private string iMAYOXKG;
        public string IMAYOXKG
        {
            get
            {
                return this.iMAYOXKG;
            }
            set
            {
                this.iMAYOXKG = value;
                this.isnull["IMAYOXKG"] = false;
            }
        }

        private DateTime iFCAMBIO;
        public DateTime IFCAMBIO
        {
            get
            {
                return this.iFCAMBIO;
            }
            set
            {
                this.iFCAMBIO = value;
                this.isnull["IFCAMBIO"] = false;
            }
        }

        private decimal iINIMAYO;
        public decimal IINIMAYO
        {
            get
            {
                return this.iINIMAYO;
            }
            set
            {
                this.iINIMAYO = value;
                this.isnull["IINIMAYO"] = false;
            }
        }

        private string iPLUG;
        public string IPLUG
        {
            get
            {
                return this.iPLUG;
            }
            set
            {
                this.iPLUG = value;
                this.isnull["IPLUG"] = false;
            }
        }

        private decimal iIVA;
        public decimal IIVA
        {
            get
            {
                return this.iIVA;
            }
            set
            {
                this.iIVA = value;
                this.isnull["IIVA"] = false;
            }
        }

        private decimal iIEPS;
        public decimal IIEPS
        {
            get
            {
                return this.iIEPS;
            }
            set
            {
                this.iIEPS = value;
                this.isnull["IIEPS"] = false;
            }
        }

        private decimal iEXIS1;
        public decimal IEXIS1
        {
            get
            {
                return this.iEXIS1;
            }
            set
            {
                this.iEXIS1 = value;
                this.isnull["IEXIS1"] = false;
            }
        }

        private decimal iEXIS5;
        public decimal IEXIS5
        {
            get
            {
                return this.iEXIS5;
            }
            set
            {
                this.iEXIS5 = value;
                this.isnull["IEXIS5"] = false;
            }
        }

        private decimal iBOTCAJA;
        public decimal IBOTCAJA
        {
            get
            {
                return this.iBOTCAJA;
            }
            set
            {
                this.iBOTCAJA = value;
                this.isnull["IBOTCAJA"] = false;
            }
        }

        private string iPLAZO;
        public string IPLAZO
        {
            get
            {
                return this.iPLAZO;
            }
            set
            {
                this.iPLAZO = value;
                this.isnull["IPLAZO"] = false;
            }
        }

        private string iPROD_PROMO;
        public string IPROD_PROMO
        {
            get
            {
                return this.iPROD_PROMO;
            }
            set
            {
                this.iPROD_PROMO = value;
                this.isnull["IPROD_PROMO"] = false;
            }
        }

        private decimal iMARGEN;
        public decimal IMARGEN
        {
            get
            {
                return this.iMARGEN;
            }
            set
            {
                this.iMARGEN = value;
                this.isnull["IMARGEN"] = false;
            }
        }

        private decimal iMPRECIO4;
        public decimal IMPRECIO4
        {
            get
            {
                return this.iMPRECIO4;
            }
            set
            {
                this.iMPRECIO4 = value;
                this.isnull["IMPRECIO4"] = false;
            }
        }

        private decimal iCPRECIO4;
        public decimal ICPRECIO4
        {
            get
            {
                return this.iCPRECIO4;
            }
            set
            {
                this.iCPRECIO4 = value;
                this.isnull["ICPRECIO4"] = false;
            }
        }

        private decimal iTPRECIO4;
        public decimal ITPRECIO4
        {
            get
            {
                return this.iTPRECIO4;
            }
            set
            {
                this.iTPRECIO4 = value;
                this.isnull["ITPRECIO4"] = false;
            }
        }

        private decimal iAPRECIO4;
        public decimal IAPRECIO4
        {
            get
            {
                return this.iAPRECIO4;
            }
            set
            {
                this.iAPRECIO4 = value;
                this.isnull["IAPRECIO4"] = false;
            }
        }

        private string iCVETASAIVA;
        public string ICVETASAIVA
        {
            get
            {
                return this.iCVETASAIVA;
            }
            set
            {
                this.iCVETASAIVA = value;
                this.isnull["ICVETASAIVA"] = false;
            }
        }

        public CMPRODBE()
        {
            isnull = new Hashtable();


            isnull.Add("IPRODUCTO", true);


            isnull.Add("IDESC1", true);


            isnull.Add("IPRECIO1", true);


            isnull.Add("IDESCUENTO1", true);


            isnull.Add("IU_EMPAQUE", true);


            isnull.Add("IMONEDA", true);


            isnull.Add("IUNIDAD", true);


            isnull.Add("ISERIE", true);


            isnull.Add("ILOTE", true);


            isnull.Add("IPROVEEDOR", true);


            isnull.Add("IPROVEEDOR2", true);


            isnull.Add("ILINEA", true);


            isnull.Add("IMARCA", true);


            isnull.Add("IDESC2", true);


            isnull.Add("IDESC3", true);


            isnull.Add("IPRECIO2", true);


            isnull.Add("IPRECIO3", true);


            isnull.Add("IPRECIO4", true);


            isnull.Add("IPRECIO5", true);


            isnull.Add("IPRECIO6", true);


            isnull.Add("IPRECIO7", true);


            isnull.Add("ICODIGO", true);


            isnull.Add("ICARGOS_U", true);


            isnull.Add("ICOSTO_REPO", true);


            isnull.Add("IIMPRIMIR", true);


            isnull.Add("IINVENTARIO", true);


            isnull.Add("IIMPUESTO", true);


            isnull.Add("INEGATIVOS", true);


            isnull.Add("ICOMODIN", true);


            isnull.Add("ILIMITE1", true);


            isnull.Add("IDESCUENTO2", true);


            isnull.Add("ILIMITE2", true);


            isnull.Add("IDESCUENTO3", true);


            isnull.Add("IKIT", true);


            isnull.Add("IPIEZAS", true);


            isnull.Add("ILPIEZAS", true);


            isnull.Add("ICOMISION", true);


            isnull.Add("ICOMISION_E", true);


            isnull.Add("IPROMOCION", true);


            isnull.Add("IID", true);


            isnull.Add("IID_FECHA", true);


            isnull.Add("IID_HORA", true);


            isnull.Add("ISUSTITUTO", true);


            isnull.Add("ICBARRAS", true);


            isnull.Add("IEMPAQUE", true);


            isnull.Add("IPESO", true);


            isnull.Add("IPRECIO8", true);


            isnull.Add("IPRECIO9", true);


            isnull.Add("IU_CAJA", true);


            isnull.Add("ICUENTA", true);


            isnull.Add("IRANKING", true);


            isnull.Add("ITIPOABC", true);


            isnull.Add("ITRAFICO", true);


            isnull.Add("IUNIDAD2", true);


            isnull.Add("IU_VENTA2", true);


            isnull.Add("IVOLUMEN", true);


            isnull.Add("IABO", true);


            isnull.Add("ILOC", true);


            isnull.Add("ICOSTO_ULTI", true);


            isnull.Add("ICOSTOULTUS", true);


            isnull.Add("IC_P_I", true);


            isnull.Add("IC_R_I", true);


            isnull.Add("IC_U_I", true);


            isnull.Add("ICOSTOREPUS", true);


            isnull.Add("IORDEN", true);


            isnull.Add("IFORDEN", true);


            isnull.Add("IAPARTAKIT", true);


            isnull.Add("IFMAXDIA", true);


            isnull.Add("IPZACAJA", true);


            isnull.Add("ICEMPAQUE", true);


            isnull.Add("IMAYOXKG", true);


            isnull.Add("IFCAMBIO", true);


            isnull.Add("IINIMAYO", true);


            isnull.Add("IPLUG", true);


            isnull.Add("IIVA", true);


            isnull.Add("IIEPS", true);


            isnull.Add("IEXIS1", true);


            isnull.Add("IEXIS5", true);


            isnull.Add("IBOTCAJA", true);


            isnull.Add("IPLAZO", true);


            isnull.Add("IPROD_PROMO", true);


            isnull.Add("IMARGEN", true);


            isnull.Add("IMPRECIO4", true);


            isnull.Add("ICPRECIO4", true);


            isnull.Add("ITPRECIO4", true);


            isnull.Add("IAPRECIO4", true);

            isnull.Add("ICVETASAIVA", true);

        }



    }
}
