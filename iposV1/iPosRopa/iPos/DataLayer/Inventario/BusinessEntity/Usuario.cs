using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPosBusinessEntity
{
    public class Usuario
    {
        private string userName;
        private string password;
        private string sucursalClave;

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }


        public string SucursalClave
        {
            get
            {
                return sucursalClave;
            }

            set
            {
                sucursalClave = value;
            }
        }
    }
}