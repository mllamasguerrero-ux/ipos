
using System;
using System.Collections;
namespace iPosBusinessEntity
{
    public struct LastDownloadedFiles
    {
        public short TIPO;
        public DateTime FECHA;
        public TimeSpan TIME;
    }

    public class CIMP_FILESBE
    {
        public Hashtable isnull;

        private string iIF_FILE;
        public string IIF_FILE
        {
            get
            {
                return this.iIF_FILE;
            }
            set
            {
                this.iIF_FILE = value;
                this.isnull["IIF_FILE"] = false;
            }
        }

        private short iIF_TIPO;
        public short IIF_TIPO
        {
            get
            {
                return this.iIF_TIPO;
            }
            set
            {
                this.iIF_TIPO = value;
                this.isnull["IIF_TIPO"] = false;
            }
        }

        private string iIF_STATUS;
        public string IIF_STATUS
        {
            get
            {
                return this.iIF_STATUS;
            }
            set
            {
                this.iIF_STATUS = value;
                this.isnull["IIF_STATUS"] = false;
            }
        }

        private DateTime iIF_FECHA;
        public DateTime IIF_FECHA
        {
            get
            {
                return this.iIF_FECHA;
            }
            set
            {
                this.iIF_FECHA = value;
                this.isnull["IIF_FECHA"] = false;
            }
        }

        private TimeSpan iIF_TIME;
        public TimeSpan IIF_TIME
        {
            get
            {
                return this.iIF_TIME;
            }
            set
            {
                this.iIF_TIME = value;
                this.isnull["IIF_TIME"] = false;
            }
        }

        private string iIF_REMOTE_FILE;
        public string IIF_REMOTE_FILE
        {
            get
            {
                return this.iIF_REMOTE_FILE;
            }
            set
            {
                this.iIF_REMOTE_FILE = value;
                this.isnull["IIF_REMOTE_FILE"] = false;
            }
        }



        private string iIF_SUCURSALCLAVE;
        public string IIF_SUCURSALCLAVE
        {
            get
            {
                return this.iIF_SUCURSALCLAVE;
            }
            set
            {
                this.iIF_SUCURSALCLAVE = value;
                this.isnull["IIF_SUCURSALCLAVE"] = false;
            }
        }


        private long iIF_SUCURSALID;
        public long IIF_SUCURSALID
        {
            get
            {
                return this.iIF_SUCURSALID;
            }
            set
            {
                this.iIF_SUCURSALID = value;
                this.isnull["IIF_SUCURSALID"] = false;
            }
        }




        public CIMP_FILESBE()
        {
            isnull = new Hashtable();


            isnull.Add("IIF_FILE", true);


            isnull.Add("IIF_TIPO", true);


            isnull.Add("IIF_STATUS", true);


            isnull.Add("IIF_FECHA", true);


            isnull.Add("IIF_TIME", true);


            isnull.Add("IIF_REMOTE_FILE", true);


            isnull.Add("IIF_SUCURSALCLAVE", true);
            isnull.Add("IIF_SUCURSALID", true);

        }



    }
}
