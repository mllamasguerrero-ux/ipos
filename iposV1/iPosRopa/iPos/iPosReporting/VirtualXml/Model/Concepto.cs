using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPosReporting.VirtualXml.Model
{
    public class Concepto
    {
        private string cantidad;

        public string Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        private string unidad;

        public string Unidad
        {
            get { return unidad; }
            set { unidad = value; }
        }
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        private string valorUnitario;

        public string ValorUnitario
        {
            get { return valorUnitario; }
            set { valorUnitario = value; }
        }
        private string importe;

        public string Importe
        {
            get { return importe; }
            set { importe = value; }
        }
        private string noIdentificacion;

        public string NoIdentificacion
        {
            get { return noIdentificacion; }
            set { noIdentificacion = value; }
        }

        private string cuentaPredial;

        public string CuentaPredial
        {
            get { return cuentaPredial; }
            set { cuentaPredial = value; }
        }

        private List<InformacionAduanera> infoAduanera;

        public List<InformacionAduanera> InfoAduanera
        {
            get { return infoAduanera; }
            set { infoAduanera = value; }
        }

        private string claveProdServ;

        public string ClaveProdServ
        {
            get { return claveProdServ; }
            set { claveProdServ = value; }
        }

        private string claveUnidad;

        public string ClaveUnidad
        {
            get { return claveUnidad; }
            set { claveUnidad = value; }
        }

        private string descuento;

        public string Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }


        private string objetoImp;
        public string ObjetoImp
        {
            get { return objetoImp; }
            set { objetoImp = value; }
        }


        private List<Traslado> impuestosTrasladados;

        public List<Traslado> ImpuestosTrasladados
        {
            get { return impuestosTrasladados; }
            set { impuestosTrasladados = value; }
        }


        private List<Traslado> impuestosRetenidos;

        public List<Traslado> ImpuestosRetenidos
        {
            get { return impuestosRetenidos; }
            set { impuestosRetenidos = value; }
        }



        private List<ConceptoParte> conceptoPartes;

        public List<ConceptoParte> ConceptoPartes
        {
            get { return conceptoPartes; }
            set { conceptoPartes = value; }
        }


        private List<string> complementoConceptos;

        public List<string> ComplementoConceptos
        {
            get { return complementoConceptos; }
            set { complementoConceptos = value; }
        }


        public Concepto()
        {

        }
    }
}
