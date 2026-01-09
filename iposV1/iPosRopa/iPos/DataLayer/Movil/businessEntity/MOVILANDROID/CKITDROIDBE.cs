using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Movil.businessEntity.MOVILANDROID
{
    public class CKITDROIDBE
    {
        private string producto;
        private string parte;
        private double cantidad;
        private double costo;
        private string id;
        private DateTime idFecha;
        private string idHora;

        public string Producto { get => producto; set => producto = value; }
        public string Parte { get => parte; set => parte = value; }
        public double Cantidad { get => cantidad; set => cantidad = value; }
        public double Costo { get => costo; set => costo = value; }
        public string Id { get => id; set => id = value; }
        public DateTime IdFecha { get => idFecha; set => idFecha = value; }
        public string IdHora { get => idHora; set => idHora = value; }
    }
}
