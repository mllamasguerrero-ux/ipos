using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace iPosBusinessEntity
{
    public class CINVDATAINVBE
    {


        string almacenClave;

        public string AlmacenClave
        {
            get { return almacenClave; }
            set { almacenClave = value; }
        }


        string clave;

        public string Clave
        {
            get { return clave; }
            set { clave = value; }
        }


        string lote;

        public string Lote
        {
            get { return lote; }
            set { lote = value; }
        }

        DateTime fechaVence;

        public DateTime FechaVence
        {
            get { return fechaVence; }
            set { fechaVence = value; }
        }


        decimal cantidad;

        public decimal Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public CINVDATAINVBE()
        {

        }

    }
}
