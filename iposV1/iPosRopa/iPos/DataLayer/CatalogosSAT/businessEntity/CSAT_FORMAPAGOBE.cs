
//using System;
//using System.Collections;

//namespace iPosBusinessEntity
//{
//    public class CSAT_FORMAPAGOBE
//    {
//    public Hashtable isnull;

//    private long iID;
//        public long IID
//        { 
//            get
//            {
//                return this.iID;
//            }
//            set
//            {
//                this.iID= value;
//                this.isnull["IID"]=false;
//            }
//        }

//    private string iACTIVO;
//        public string IACTIVO
//        { 
//            get
//            {
//                return this.iACTIVO;
//            }
//            set
//            {
//                this.iACTIVO= value;
//                this.isnull["IACTIVO"]=false;
//            }
//        }

//    private object iCREADO;
//        public object ICREADO
//        { 
//            get
//            {
//                return this.iCREADO;
//            }
//            set
//            {
//                this.iCREADO= value;
//                this.isnull["ICREADO"]=false;
//            }
//        }

//    private long iCREADOPOR_USERID;
//        public long ICREADOPOR_USERID
//        { 
//            get
//            {
//                return this.iCREADOPOR_USERID;
//            }
//            set
//            {
//                this.iCREADOPOR_USERID= value;
//                this.isnull["ICREADOPOR_USERID"]=false;
//            }
//        }

//    private object iMODIFICADO;
//        public object IMODIFICADO
//        { 
//            get
//            {
//                return this.iMODIFICADO;
//            }
//            set
//            {
//                this.iMODIFICADO= value;
//                this.isnull["IMODIFICADO"]=false;
//            }
//        }

//    private long iMODIFICADOPOR_USERID;
//        public long IMODIFICADOPOR_USERID
//        { 
//            get
//            {
//                return this.iMODIFICADOPOR_USERID;
//            }
//            set
//            {
//                this.iMODIFICADOPOR_USERID= value;
//                this.isnull["IMODIFICADOPOR_USERID"]=false;
//            }
//        }

//    private string iSAT_CLAVE;
//        public string ISAT_CLAVE
//        { 
//            get
//            {
//                return this.iSAT_CLAVE;
//            }
//            set
//            {
//                this.iSAT_CLAVE= value;
//                this.isnull["ISAT_CLAVE"]=false;
//            }
//        }

//    private string iSAT_DESCRIPCION;
//        public string ISAT_DESCRIPCION
//        { 
//            get
//            {
//                return this.iSAT_DESCRIPCION;
//            }
//            set
//            {
//                this.iSAT_DESCRIPCION= value;
//                this.isnull["ISAT_DESCRIPCION"]=false;
//            }
//        }

//    private string iSAT_BANCARIZADO;
//        public string ISAT_BANCARIZADO
//        { 
//            get
//            {
//                return this.iSAT_BANCARIZADO;
//            }
//            set
//            {
//                this.iSAT_BANCARIZADO= value;
//                this.isnull["ISAT_BANCARIZADO"]=false;
//            }
//        }

//    private string iSAT_NUMOPERACION;
//        public string ISAT_NUMOPERACION
//        { 
//            get
//            {
//                return this.iSAT_NUMOPERACION;
//            }
//            set
//            {
//                this.iSAT_NUMOPERACION= value;
//                this.isnull["ISAT_NUMOPERACION"]=false;
//            }
//        }

//    private string iSAT_RFCEMISORORDENANTE;
//        public string ISAT_RFCEMISORORDENANTE
//        { 
//            get
//            {
//                return this.iSAT_RFCEMISORORDENANTE;
//            }
//            set
//            {
//                this.iSAT_RFCEMISORORDENANTE= value;
//                this.isnull["ISAT_RFCEMISORORDENANTE"]=false;
//            }
//        }

//    private string iSAT_CUENTAORDENANTE;
//        public string ISAT_CUENTAORDENANTE
//        { 
//            get
//            {
//                return this.iSAT_CUENTAORDENANTE;
//            }
//            set
//            {
//                this.iSAT_CUENTAORDENANTE= value;
//                this.isnull["ISAT_CUENTAORDENANTE"]=false;
//            }
//        }

//    private string iSAT_PATRONORDENANTE;
//        public string ISAT_PATRONORDENANTE
//        { 
//            get
//            {
//                return this.iSAT_PATRONORDENANTE;
//            }
//            set
//            {
//                this.iSAT_PATRONORDENANTE= value;
//                this.isnull["ISAT_PATRONORDENANTE"]=false;
//            }
//        }

//    private string iSAT_RFCEMISORBENEFICIARIO;
//        public string ISAT_RFCEMISORBENEFICIARIO
//        { 
//            get
//            {
//                return this.iSAT_RFCEMISORBENEFICIARIO;
//            }
//            set
//            {
//                this.iSAT_RFCEMISORBENEFICIARIO= value;
//                this.isnull["ISAT_RFCEMISORBENEFICIARIO"]=false;
//            }
//        }

//    private string iSAT_CUENTABENEFICIARIO;
//        public string ISAT_CUENTABENEFICIARIO
//        { 
//            get
//            {
//                return this.iSAT_CUENTABENEFICIARIO;
//            }
//            set
//            {
//                this.iSAT_CUENTABENEFICIARIO= value;
//                this.isnull["ISAT_CUENTABENEFICIARIO"]=false;
//            }
//        }

//    private string iSAT_PATRONBENEFICIARIO;
//        public string ISAT_PATRONBENEFICIARIO
//        { 
//            get
//            {
//                return this.iSAT_PATRONBENEFICIARIO;
//            }
//            set
//            {
//                this.iSAT_PATRONBENEFICIARIO= value;
//                this.isnull["ISAT_PATRONBENEFICIARIO"]=false;
//            }
//        }

//    private string iSAT_TIPOCADENAPAGO;
//        public string ISAT_TIPOCADENAPAGO
//        { 
//            get
//            {
//                return this.iSAT_TIPOCADENAPAGO;
//            }
//            set
//            {
//                this.iSAT_TIPOCADENAPAGO= value;
//                this.isnull["ISAT_TIPOCADENAPAGO"]=false;
//            }
//        }

//    private string iSAT_BANCOEMISOR;
//        public string ISAT_BANCOEMISOR
//        { 
//            get
//            {
//                return this.iSAT_BANCOEMISOR;
//            }
//            set
//            {
//                this.iSAT_BANCOEMISOR= value;
//                this.isnull["ISAT_BANCOEMISOR"]=false;
//            }
//        }
		
//               public CSAT_FORMAPAGOBE()
//        {
//        isnull=new Hashtable();
	

//            isnull.Add("IID",true);
	

//            isnull.Add("IACTIVO",true);
	

//            isnull.Add("ICREADO",true);
	

//            isnull.Add("ICREADOPOR_USERID",true);
	

//            isnull.Add("IMODIFICADO",true);
	

//            isnull.Add("IMODIFICADOPOR_USERID",true);
	

//            isnull.Add("ISAT_CLAVE",true);
	

//            isnull.Add("ISAT_DESCRIPCION",true);
	

//            isnull.Add("ISAT_BANCARIZADO",true);
	

//            isnull.Add("ISAT_NUMOPERACION",true);
	

//            isnull.Add("ISAT_RFCEMISORORDENANTE",true);
	

//            isnull.Add("ISAT_CUENTAORDENANTE",true);
	

//            isnull.Add("ISAT_PATRONORDENANTE",true);
	

//            isnull.Add("ISAT_RFCEMISORBENEFICIARIO",true);
	

//            isnull.Add("ISAT_CUENTABENEFICIARIO",true);
	

//            isnull.Add("ISAT_PATRONBENEFICIARIO",true);
	

//            isnull.Add("ISAT_TIPOCADENAPAGO",true);
	

//            isnull.Add("ISAT_BANCOEMISOR",true);
	
//        }

		

//    }
//}
