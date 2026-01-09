
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public class CUSUARIOSBE
    {
        public Hashtable isnull;
        private int iUS_USERID;
        public int IUS_USERID
        {
            get
            {
                return this.iUS_USERID;
            }
            set
            {
                this.iUS_USERID = value;
                this.isnull["IUS_USERID"] = false;
            }
        }
        private string iUS_USUARIO;
        public string IUS_USUARIO
        {
            get
            {
                return this.iUS_USUARIO;
            }
            set
            {
                this.iUS_USUARIO = value;
                this.isnull["IUS_USUARIO"] = false;
            }
        }
        private string iUS_PASSWORD;
        public string IUS_PASSWORD
        {
            get
            {
                return this.iUS_PASSWORD;
            }
            set
            {
                this.iUS_PASSWORD = value;
                this.isnull["IUS_PASSWORD"] = false;
            }
        }
        private string iUS_NOMBRE;
        public string IUS_NOMBRE
        {
            get
            {
                return this.iUS_NOMBRE;
            }
            set
            {
                this.iUS_NOMBRE = value;
                this.isnull["IUS_NOMBRE"] = false;
            }
        }
        private string iUS_VENDEDOR;
        public string IUS_VENDEDOR
        {
            get
            {
                return this.iUS_VENDEDOR;
            }
            set
            {
                this.iUS_VENDEDOR = value;
                this.isnull["IUS_VENDEDOR"] = false;
            }
        }
        private DateTime iUS_VIGENCIA;
        public DateTime IUS_VIGENCIA
        {
            get
            {
                return this.iUS_VIGENCIA;
            }
            set
            {
                this.iUS_VIGENCIA = value;
                this.isnull["IUS_VIGENCIA"] = false;
            }
        }
        private string iUS_EMPRESA;
        public string IUS_EMPRESA
        {
            get
            {
                return this.iUS_EMPRESA;
            }
            set
            {
                this.iUS_EMPRESA = value;
                this.isnull["IUS_EMPRESA"] = false;
            }
        }
        private string iUS_R_PASSWORD;
        public string IUS_R_PASSWORD
        {
            get
            {
                return this.iUS_R_PASSWORD;
            }
            set
            {
                this.iUS_R_PASSWORD = value;
                this.isnull["IUS_R_PASSWORD"] = false;
            }
        }
        private long iUS_LIMITE_CONEXIONES;
        public long IUS_LIMITE_CONEXIONES
        {
            get
            {
                return this.iUS_LIMITE_CONEXIONES;
            }
            set
            {
                this.iUS_LIMITE_CONEXIONES = value;
                this.isnull["IUS_LIMITE_CONEXIONES"] = false;
            }
        }
        private long iUS_CONEXIONES_ABIERTAS;
        public long IUS_CONEXIONES_ABIERTAS
        {
            get
            {
                return this.iUS_CONEXIONES_ABIERTAS;
            }
            set
            {
                this.iUS_CONEXIONES_ABIERTAS = value;
                this.isnull["IUS_CONEXIONES_ABIERTAS"] = false;
            }
        }
        private int iUS_ALMACENID;
        public int IUS_ALMACENID
        {
            get
            {
                return this.iUS_ALMACENID;
            }
            set
            {
                this.iUS_ALMACENID = value;
                this.isnull["IUS_ALMACENID"] = false;
            }
        }
        public CUSUARIOSBE()
        {
            isnull = new Hashtable();
            isnull.Add("IUS_USERID", true);
            isnull.Add("IUS_USUARIO", true);
            isnull.Add("IUS_PASSWORD", true);
            isnull.Add("IUS_NOMBRE", true);
            isnull.Add("IUS_VENDEDOR", true);
            isnull.Add("IUS_VIGENCIA", true);
            isnull.Add("IUS_EMPRESA", true);
            isnull.Add("IUS_R_PASSWORD", true);
            isnull.Add("IUS_LIMITE_CONEXIONES", true);
            isnull.Add("IUS_CONEXIONES_ABIERTAS", true);
            isnull.Add("IUS_ALMACENID", true);
        }
    }
}
