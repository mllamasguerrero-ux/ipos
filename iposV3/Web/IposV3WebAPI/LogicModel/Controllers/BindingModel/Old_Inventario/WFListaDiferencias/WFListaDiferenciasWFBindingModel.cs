
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model;
using MvvmFramework;
using System.Xml.Serialization;

namespace BindingModels
{
    
    [XmlRoot]
    public class WFListaDiferenciasWFBindingModel : Validatable
    {

        public WFListaDiferenciasWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Itemid;
        [XmlAttribute]
        public string? Itemid { get => _Itemid; set { if (RaiseAcceptPendingChange(value, _Itemid)) { _Itemid = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbimprimedif;
        [XmlAttribute]
        public BoolCN? Cbimprimedif { get => _Cbimprimedif; set { if (RaiseAcceptPendingChange(value, _Cbimprimedif)) { _Cbimprimedif = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbmostrarsolodif;
        [XmlAttribute]
        public BoolCN? Cbmostrarsolodif { get => _Cbmostrarsolodif; set { if (RaiseAcceptPendingChange(value, _Cbmostrarsolodif)) { _Cbmostrarsolodif = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {
            return "";
        }


        public static string GetFieldsForGeneralSearch()
        {
            return "";
        }


        public void FillCatalogRelatedFields()
        {

        }



    }

    
    [XmlRoot]
    public class WFListaDiferenciasWF_Get_invfis_listadetallesBindingModel : Validatable
    {

        public WFListaDiferenciasWF_Get_invfis_listadetallesBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Movtoid;
        [XmlAttribute]
        public long? Movtoid { get => _Movtoid; set { if (RaiseAcceptPendingChange(value, _Movtoid)) { _Movtoid = value; OnPropertyChanged(); } } }

        private long? _Productoid;
        [XmlAttribute]
        public long? Productoid { get => _Productoid; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value; OnPropertyChanged(); } } }

        private string? _Productonombre;
        [XmlAttribute]
        public string? Productonombre { get => _Productonombre; set { if (RaiseAcceptPendingChange(value, _Productonombre)) { _Productonombre = value; OnPropertyChanged(); } } }

        private string? _Productodescripcion;
        [XmlAttribute]
        public string? Productodescripcion { get => _Productodescripcion; set { if (RaiseAcceptPendingChange(value, _Productodescripcion)) { _Productodescripcion = value; OnPropertyChanged(); } } }

        private string? _Productolote;
        [XmlAttribute]
        public string? Productolote { get => _Productolote; set { if (RaiseAcceptPendingChange(value, _Productolote)) { _Productolote = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechavence;
        [XmlAttribute]
        public DateTimeOffset? Fechavence { get => _Fechavence; set { if (RaiseAcceptPendingChange(value, _Fechavence)) { _Fechavence = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadteorica;
        [XmlAttribute]
        public decimal? Cantidadteorica { get => _Cantidadteorica; set { if (RaiseAcceptPendingChange(value, _Cantidadteorica)) { _Cantidadteorica = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadfisica;
        [XmlAttribute]
        public decimal? Cantidadfisica { get => _Cantidadfisica; set { if (RaiseAcceptPendingChange(value, _Cantidadfisica)) { _Cantidadfisica = value; OnPropertyChanged(); } } }

        private decimal? _Cantidaddiferencia;
        [XmlAttribute]
        public decimal? Cantidaddiferencia { get => _Cantidaddiferencia; set { if (RaiseAcceptPendingChange(value, _Cantidaddiferencia)) { _Cantidaddiferencia = value; OnPropertyChanged(); } } }

        private int? _Numero;
        [XmlAttribute]
        public int? Numero { get => _Numero; set { if (RaiseAcceptPendingChange(value, _Numero)) { _Numero = value; OnPropertyChanged(); } } }

        private decimal? _Cajas;
        [XmlAttribute]
        public decimal? Cajas { get => _Cajas; set { if (RaiseAcceptPendingChange(value, _Cajas)) { _Cajas = value; OnPropertyChanged(); } } }

        private decimal? _Piezas;
        [XmlAttribute]
        public decimal? Piezas { get => _Piezas; set { if (RaiseAcceptPendingChange(value, _Piezas)) { _Piezas = value; OnPropertyChanged(); } } }

        private int? _Errorcode;
        [XmlAttribute]
        public int? Errorcode { get => _Errorcode; set { if (RaiseAcceptPendingChange(value, _Errorcode)) { _Errorcode = value; OnPropertyChanged(); } } }

        private decimal? _Pzacaja;
        [XmlAttribute]
        public decimal? Pzacaja { get => _Pzacaja; set { if (RaiseAcceptPendingChange(value, _Pzacaja)) { _Pzacaja = value; OnPropertyChanged(); } } }

        private string? _Texto1;
        [XmlAttribute]
        public string? Texto1 { get => _Texto1; set { if (RaiseAcceptPendingChange(value, _Texto1)) { _Texto1 = value; OnPropertyChanged(); } } }

        private string? _Texto2;
        [XmlAttribute]
        public string? Texto2 { get => _Texto2; set { if (RaiseAcceptPendingChange(value, _Texto2)) { _Texto2 = value; OnPropertyChanged(); } } }

        private string? _Texto3;
        [XmlAttribute]
        public string? Texto3 { get => _Texto3; set { if (RaiseAcceptPendingChange(value, _Texto3)) { _Texto3 = value; OnPropertyChanged(); } } }

        private string? _Texto4;
        [XmlAttribute]
        public string? Texto4 { get => _Texto4; set { if (RaiseAcceptPendingChange(value, _Texto4)) { _Texto4 = value; OnPropertyChanged(); } } }

        private string? _Texto5;
        [XmlAttribute]
        public string? Texto5 { get => _Texto5; set { if (RaiseAcceptPendingChange(value, _Texto5)) { _Texto5 = value; OnPropertyChanged(); } } }

        private string? _Texto6;
        [XmlAttribute]
        public string? Texto6 { get => _Texto6; set { if (RaiseAcceptPendingChange(value, _Texto6)) { _Texto6 = value; OnPropertyChanged(); } } }

        private decimal? _Numero1;
        [XmlAttribute]
        public decimal? Numero1 { get => _Numero1; set { if (RaiseAcceptPendingChange(value, _Numero1)) { _Numero1 = value; OnPropertyChanged(); } } }

        private decimal? _Numero2;
        [XmlAttribute]
        public decimal? Numero2 { get => _Numero2; set { if (RaiseAcceptPendingChange(value, _Numero2)) { _Numero2 = value; OnPropertyChanged(); } } }

        private decimal? _Numero3;
        [XmlAttribute]
        public decimal? Numero3 { get => _Numero3; set { if (RaiseAcceptPendingChange(value, _Numero3)) { _Numero3 = value; OnPropertyChanged(); } } }

        private decimal? _Numero4;
        [XmlAttribute]
        public decimal? Numero4 { get => _Numero4; set { if (RaiseAcceptPendingChange(value, _Numero4)) { _Numero4 = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha1;
        [XmlAttribute]
        public DateTimeOffset? Fecha1 { get => _Fecha1; set { if (RaiseAcceptPendingChange(value, _Fecha1)) { _Fecha1 = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha2;
        [XmlAttribute]
        public DateTimeOffset? Fecha2 { get => _Fecha2; set { if (RaiseAcceptPendingChange(value, _Fecha2)) { _Fecha2 = value; OnPropertyChanged(); } } }

        public static string GetBaseQuery()
        {
            return "";
        }


        public static string GetFieldsForGeneralSearch()
        {
            return "";
        }


        public void FillCatalogRelatedFields()
        {

        }



    }


     
}

