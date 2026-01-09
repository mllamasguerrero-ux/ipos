using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IposV3.Services.FacturaElectronica
{
    public class Domicilio
    {
        private string? calle;

        public string? Calle
        {
            get { return calle; }
            set { calle = value; }
        }
        private string? noInterior;

        public string? NoInterior
        {
            get { return noInterior; }
            set { noInterior = value; }
        }
        private string? noExterior;

        public string? NoExterior
        {
            get { return noExterior; }
            set { noExterior = value; }
        }
        private string? colonia;

        public string? Colonia
        {
            get { return colonia; }
            set { colonia = value; }
        }
        private string? localidad;

        public string? Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }
        private string? referencia;

        public string? Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }
        private string? municipio;

        public string? Municipio
        {
            get { return municipio; }
            set { municipio = value; }
        }
        private string? estado;

        public string? Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        private string? pais;

        public string? Pais
        {
            get { return pais; }
            set { pais = value; }
        }
        private string? codigoPostal;

        public string? CodigoPostal
        {
            get { return codigoPostal; }
            set { codigoPostal = value; }
        }

        public Domicilio()
        {

        }
    }
}
