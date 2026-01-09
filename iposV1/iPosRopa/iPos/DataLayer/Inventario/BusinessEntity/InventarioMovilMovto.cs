using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSGetProducta4App.DAO.businessEntity
{
    public class InventarioMovilMovto
    {
        private int id;
        private int invMovilDoctoId;
        private string almacenClave;
        private string clave;
        private string lote;
        private string fechaVence;
        private decimal cantidad;

        public int Id { get => id; set => id = value; }
        public int InvMovilDoctoId { get => invMovilDoctoId; set => invMovilDoctoId = value; }
        public string AlmacenClave { get => almacenClave; set => almacenClave = value; }
        public string Clave { get => clave; set => clave = value; }
        public string Lote { get => lote; set => lote = value; }
        public string FechaVence { get => fechaVence; set => fechaVence = value; }
        public decimal Cantidad { get => cantidad; set => cantidad = value; }
    }
}