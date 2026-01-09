using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Movil.businessEntity.MOVILANDROID
{
    public class CBANKDROIDBE
    {
        private string clave;
        private string nombre;
        private string id;

        public string Clave { get => clave; set => clave = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Id { get => id; set => id = value; }
    }
}
