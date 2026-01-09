using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Movil.businessEntity.MOVILANDROID
{
    public class CPRODDROIDBE
    {
        private string clave;
        private string descripcion1;
        private string descripcion2;
        private string descripcion3;
        private float precio1;
        private string cBarras;
        private string cEmpaque;
        private string ean;
        private string unidad;
        private float pzaCaja;
        private float uEmpaque;
        private float existencia;
        private string esKit;

        public string Clave { get => clave; set => clave = value; }
        public string Descripcion1 { get => descripcion1; set => descripcion1 = value; }
        public string Descripcion2 { get => descripcion2; set => descripcion2 = value; }
        public string Descripcion3 { get => descripcion3; set => descripcion3 = value; }
        public float Precio1 { get => precio1; set => precio1 = value; }
        public string CBarras { get => cBarras; set => cBarras = value; }
        public string CEmpaque { get => cEmpaque; set => cEmpaque = value; }
        public string Ean { get => ean; set => ean = value; }
        public string Unidad { get => unidad; set => unidad = value; }
        public float PzaCaja { get => pzaCaja; set => pzaCaja = value; }
        public float UEmpaque { get => uEmpaque; set => uEmpaque = value; }
        public float Existencia { get => existencia; set => existencia = value; }
        public string EsKit { get => esKit; set => esKit = value; }
    }
}
