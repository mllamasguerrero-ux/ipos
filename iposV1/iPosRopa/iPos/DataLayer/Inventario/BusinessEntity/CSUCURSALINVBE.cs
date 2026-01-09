using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace iPosBusinessEntity
{
    public class CSUCURSALINVBE
    {
        private string clave;
        public string Clave
        {
            get { return clave; }
            set { clave = value; }
        }

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}