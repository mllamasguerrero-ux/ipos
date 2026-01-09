using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace iPosBusinessEntity
{
    public class CALMACENDATAINVBE
    {
        long almacenId;

        public long AlmacenId
        {
            get { return almacenId; }
            set { almacenId = value; }
        }
        string clave;

        public string Clave
        {
            get { return clave; }
            set { clave = value; }
        }
        string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        public CALMACENDATAINVBE()
        {

        }
    }
}
