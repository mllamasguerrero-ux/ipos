
using System;
using System.Collections;

namespace iPosBusinessEntity
{
    public class CRESPONSEBANCOMERBE
    {

        public CENCABEZADORESPONSEBANCOMERBE C00_Encabezado = new CENCABEZADORESPONSEBANCOMERBE();

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

        private string iCODTRANSACTION;
        public string ICODTRANSACTION
        {
            get
            {
                return this.iCODTRANSACTION;
            }
            set
            {
                this.iCODTRANSACTION = value;
                this.isnull["ICODTRANSACTION"] = false;
            }
        }

        private string iTERMINAL;
        public string ITERMINAL
        {
            get
            {
                return this.iTERMINAL;
            }
            set
            {
                this.iTERMINAL = value;
                this.isnull["ITERMINAL"] = false;
            }
        }

        private string iSESSION;
        public string ISESSION
        {
            get
            {
                return this.iSESSION;
            }
            set
            {
                this.iSESSION = value;
                this.isnull["ISESSION"] = false;
            }
        }

        private string iSECUENCIA;
        public string ISECUENCIA
        {
            get
            {
                return this.iSECUENCIA;
            }
            set
            {
                this.iSECUENCIA = value;
                this.isnull["ISECUENCIA"] = false;
            }
        }

        private string iCODIGORESPUESTA;
        public string ICODIGORESPUESTA
        {
            get
            {
                return this.iCODIGORESPUESTA;
            }
            set
            {
                this.iCODIGORESPUESTA = value;
                this.isnull["ICODIGORESPUESTA"] = false;
            }
        }

        private string iNOAUTORIZACION;
        public string INOAUTORIZACION
        {
            get
            {
                return this.iNOAUTORIZACION;
            }
            set
            {
                this.iNOAUTORIZACION = value;
                this.isnull["INOAUTORIZACION"] = false;
            }
        }

        private string iAFILIACION;
        public string IAFILIACION
        {
            get
            {
                return this.iAFILIACION;
            }
            set
            {
                this.iAFILIACION = value;
                this.isnull["IAFILIACION"] = false;
            }
        }

        private string iFILLER1;
        public string IFILLER1
        {
            get
            {
                return this.iFILLER1;
            }
            set
            {
                this.iFILLER1 = value;
                this.isnull["IFILLER1"] = false;
            }
        }

        private string iIMPORTE;
        public string IIMPORTE
        {
            get
            {
                return this.iIMPORTE;
            }
            set
            {
                this.iIMPORTE = value;
                this.isnull["IIMPORTE"] = false;
            }
        }

        private string iFILLER2;
        public string IFILLER2
        {
            get
            {
                return this.iFILLER2;
            }
            set
            {
                this.iFILLER2 = value;
                this.isnull["IFILLER2"] = false;
            }
        }

        private string iTARJETA;
        public string ITARJETA
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

        private string iCVEOPERADOR;
        public string ICVEOPERADOR
        {
            get
            {
                return this.iCVEOPERADOR;
            }
            set
            {
                this.iCVEOPERADOR = value;
                this.isnull["ICVEOPERADOR"] = false;
            }
        }

        private string iFILLER3;
        public string IFILLER3
        {
            get
            {
                return this.iFILLER3;
            }
            set
            {
                this.iFILLER3 = value;
                this.isnull["IFILLER3"] = false;
            }
        }

        private string iFOLIO;
        public string IFOLIO
        {
            get
            {
                return this.iFOLIO;
            }
            set
            {
                this.iFOLIO = value;
                this.isnull["IFOLIO"] = false;
            }
        }

        private string iLONGLEYENDA;
        public string ILONGLEYENDA
        {
            get
            {
                return this.iLONGLEYENDA;
            }
            set
            {
                this.iLONGLEYENDA = value;
                this.isnull["ILONGLEYENDA"] = false;
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

        private string iREFERENCIAFINAN;
        public string IREFERENCIAFINAN
        {
            get
            {
                return this.iREFERENCIAFINAN;
            }
            set
            {
                this.iREFERENCIAFINAN = value;
                this.isnull["IREFERENCIAFINAN"] = false;
            }
        }

        private string iLONGEMV;
        public string ILONGEMV
        {
            get
            {
                return this.iLONGEMV;
            }
            set
            {
                this.iLONGEMV = value;
                this.isnull["ILONGEMV"] = false;
            }
        }

        private string iDATOSEMV;
        public string IDATOSEMV
        {
            get
            {
                return this.iDATOSEMV;
            }
            set
            {
                this.iDATOSEMV = value;
                this.isnull["IDATOSEMV"] = false;
            }
        }

        private string iLONGLEALTAD;
        public string ILONGLEALTAD
        {
            get
            {
                return this.iLONGLEALTAD;
            }
            set
            {
                this.iLONGLEALTAD = value;
                this.isnull["ILONGLEALTAD"] = false;
            }
        }

        private string iDATOSLEALTAD;
        public string IDATOSLEALTAD
        {
            get
            {
                return this.iDATOSLEALTAD;
            }
            set
            {
                this.iDATOSLEALTAD = value;
                this.isnull["IDATOSLEALTAD"] = false;
            }
        }

        private string iREGISTRO1;
        public string IREGISTRO1
        {
            get
            {
                return this.iREGISTRO1;
            }
            set
            {
                this.iREGISTRO1 = value;
                this.isnull["IREGISTRO1"] = false;
            }
        }

        private string iREGISTRO2;
        public string IREGISTRO2
        {
            get
            {
                return this.iREGISTRO2;
            }
            set
            {
                this.iREGISTRO2 = value;
                this.isnull["IREGISTRO2"] = false;
            }
        }

        private string iREGISTRO3;
        public string IREGISTRO3
        {
            get
            {
                return this.iREGISTRO3;
            }
            set
            {
                this.iREGISTRO3 = value;
                this.isnull["IREGISTRO3"] = false;
            }
        }

        private string iREGISTRO4;
        public string IREGISTRO4
        {
            get
            {
                return this.iREGISTRO4;
            }
            set
            {
                this.iREGISTRO4 = value;
                this.isnull["IREGISTRO4"] = false;
            }
        }

        private string iREGISTRO5;
        public string IREGISTRO5
        {
            get
            {
                return this.iREGISTRO5;
            }
            set
            {
                this.iREGISTRO5 = value;
                this.isnull["IREGISTRO5"] = false;
            }
        }

        private string iLONGMULTIPAGOS;
        public string ILONGMULTIPAGOS
        {
            get
            {
                return this.iLONGMULTIPAGOS;
            }
            set
            {
                this.iLONGMULTIPAGOS = value;
                this.isnull["ILONGMULTIPAGOS"] = false;
            }
        }

        private string iMULTIPAGOS;
        public string IMULTIPAGOS
        {
            get
            {
                return this.iMULTIPAGOS;
            }
            set
            {
                this.iMULTIPAGOS = value;
                this.isnull["IMULTIPAGOS"] = false;
            }
        }

        private string iLONGDATOSCIFRADOS;
        public string ILONGDATOSCIFRADOS
        {
            get
            {
                return this.iLONGDATOSCIFRADOS;
            }
            set
            {
                this.iLONGDATOSCIFRADOS = value;
                this.isnull["ILONGDATOSCIFRADOS"] = false;
            }
        }

        private string iDATOSCIFRADOS;
        public string IDATOSCIFRADOS
        {
            get
            {
                return this.iDATOSCIFRADOS;
            }
            set
            {
                this.iDATOSCIFRADOS = value;
                this.isnull["IDATOSCIFRADOS"] = false;
            }
        }

        private string iLONGCAMPANA;
        public string ILONGCAMPANA
        {
            get
            {
                return this.iLONGCAMPANA;
            }
            set
            {
                this.iLONGCAMPANA = value;
                this.isnull["ILONGCAMPANA"] = false;
            }
        }

        private string iDATOSCAMPANA;
        public string IDATOSCAMPANA
        {
            get
            {
                return this.iDATOSCAMPANA;
            }
            set
            {
                this.iDATOSCAMPANA = value;
                this.isnull["IDATOSCAMPANA"] = false;
            }
        }

        private long iIDENCABEZADO;
        public long IIDENCABEZADO
        {
            get
            {
                return this.iIDENCABEZADO;
            }
            set
            {
                this.iIDENCABEZADO = value;
                this.isnull["IIDENCABEZADO"] = false;
            }
        }

        public CRESPONSEBANCOMERBE()
        {
            isnull = new Hashtable();


            isnull.Add("IID", true);


            isnull.Add("IACTIVO", true);


            isnull.Add("ICREADO", true);


            isnull.Add("ICREADOPOR_USERID", true);


            isnull.Add("IMODIFICADO", true);


            isnull.Add("IMODIFICADOPOR_USERID", true);


            isnull.Add("ICODTRANSACTION", true);


            isnull.Add("ITERMINAL", true);


            isnull.Add("ISESSION", true);


            isnull.Add("ISECUENCIA", true);


            isnull.Add("ICODIGORESPUESTA", true);


            isnull.Add("INOAUTORIZACION", true);


            isnull.Add("IAFILIACION", true);


            isnull.Add("IFILLER1", true);


            isnull.Add("IIMPORTE", true);


            isnull.Add("IFILLER2", true);


            isnull.Add("ITARJETA", true);


            isnull.Add("ICVEOPERADOR", true);


            isnull.Add("IFILLER3", true);


            isnull.Add("IFOLIO", true);


            isnull.Add("ILONGLEYENDA", true);


            isnull.Add("ILEYENDA", true);


            isnull.Add("IREFERENCIAFINAN", true);


            isnull.Add("ILONGEMV", true);


            isnull.Add("IDATOSEMV", true);


            isnull.Add("ILONGLEALTAD", true);


            isnull.Add("IDATOSLEALTAD", true);


            isnull.Add("IREGISTRO1", true);


            isnull.Add("IREGISTRO2", true);


            isnull.Add("IREGISTRO3", true);


            isnull.Add("IREGISTRO4", true);


            isnull.Add("IREGISTRO5", true);


            isnull.Add("ILONGMULTIPAGOS", true);


            isnull.Add("IMULTIPAGOS", true);


            isnull.Add("ILONGDATOSCIFRADOS", true);


            isnull.Add("IDATOSCIFRADOS", true);


            isnull.Add("ILONGCAMPANA", true);


            isnull.Add("IDATOSCAMPANA", true);


            isnull.Add("IIDENCABEZADO", true);

        }



    }
}
