
using System;
using System.Collections;
namespace iPosBusinessEntity
{
	public class CM_VEDSBE
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
        		this.iVENTA= value;
        		this.isnull["IVENTA"]=false;
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
        		this.iCLIENTE= value;
        		this.isnull["ICLIENTE"]=false;
        	}
        }

 	private string iPRODUCTO;
        public string IPRODUCTO
        { 
        	get
        	{
         		return this.iPRODUCTO;
        	}
        	set
        	{
        		this.iPRODUCTO= value;
        		this.isnull["IPRODUCTO"]=false;
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
        		this.iDESC1= value;
        		this.isnull["IDESC1"]=false;
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
        		this.iCANTIDAD= value;
        		this.isnull["ICANTIDAD"]=false;
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
        		this.iDESC2= value;
        		this.isnull["IDESC2"]=false;
        	}
        }

 	private decimal iMAXIMO;
        public decimal IMAXIMO
        { 
        	get
        	{
         		return this.iMAXIMO;
        	}
        	set
        	{
        		this.iMAXIMO= value;
        		this.isnull["IMAXIMO"]=false;
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
        		this.iDESCUENTO= value;
        		this.isnull["IDESCUENTO"]=false;
        	}
        }

 	private string iCLASIFICA;
        public string ICLASIFICA
        { 
        	get
        	{
         		return this.iCLASIFICA;
        	}
        	set
        	{
        		this.iCLASIFICA= value;
        		this.isnull["ICLASIFICA"]=false;
        	}
        }

 	private string iAUTORIZA;
        public string IAUTORIZA
        { 
        	get
        	{
         		return this.iAUTORIZA;
        	}
        	set
        	{
        		this.iAUTORIZA= value;
        		this.isnull["IAUTORIZA"]=false;
        	}
        }

 	private decimal iSURTIDAS;
        public decimal ISURTIDAS
        { 
        	get
        	{
         		return this.iSURTIDAS;
        	}
        	set
        	{
        		this.iSURTIDAS= value;
        		this.isnull["ISURTIDAS"]=false;
        	}
        }

 	private string iPROD2;
        public string IPROD2
        { 
        	get
        	{
         		return this.iPROD2;
        	}
        	set
        	{
        		this.iPROD2= value;
        		this.isnull["IPROD2"]=false;
        	}
        }

 	private decimal iREQUERIDAS;
        public decimal IREQUERIDAS
        { 
        	get
        	{
         		return this.iREQUERIDAS;
        	}
        	set
        	{
        		this.iREQUERIDAS= value;
        		this.isnull["IREQUERIDAS"]=false;
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
        		this.iID= value;
        		this.isnull["IID"]=false;
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
        		this.iID_FECHA= value;
        		this.isnull["IID_FECHA"]=false;
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
        		this.iID_HORA= value;
        		this.isnull["IID_HORA"]=false;
        	}
        }

        private string iCVEUSER;
        public string ICVEUSER
        {
            get
            {
                return this.iCVEUSER;
            }
            set
            {
                this.iCVEUSER = value;
                this.isnull["ICVEUSER"] = false;
            }
        }


		
               public CM_VEDSBE()
		{
		isnull=new Hashtable();
	

			isnull.Add("IVENTA",true);
	

			isnull.Add("ICLIENTE",true);
	

			isnull.Add("IPRODUCTO",true);
	

			isnull.Add("IDESC1",true);
	

			isnull.Add("ICANTIDAD",true);
	

			isnull.Add("IDESC2",true);
	

			isnull.Add("IMAXIMO",true);
	

			isnull.Add("IDESCUENTO",true);
	

			isnull.Add("ICLASIFICA",true);
	

			isnull.Add("IAUTORIZA",true);
	

			isnull.Add("ISURTIDAS",true);
	

			isnull.Add("IPROD2",true);
	

			isnull.Add("IREQUERIDAS",true);
	

			isnull.Add("IID",true);
	

			isnull.Add("IID_FECHA",true);
	

			isnull.Add("IID_HORA",true);

            isnull.Add("ICVEUSER", true);

                   
	
		}

		

	}
}
