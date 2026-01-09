
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
    public class WFEstadisticosClienteVentaWFBindingModel : Validatable
    {

        public WFEstadisticosClienteVentaWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Itemid;
        [XmlAttribute]
        public long? Itemid { get => _Itemid; set { if (RaiseAcceptPendingChange(value, _Itemid)) { _Itemid = value; OnPropertyChanged(); } } }

        private string? _ItemidClave;
        [XmlAttribute]
        public string? ItemidClave { get => _ItemidClave; set { if (RaiseAcceptPendingChange(value, _ItemidClave)) { _ItemidClave = value; OnPropertyChanged(); } } }

        private string? _ItemidNombre;
        [XmlAttribute]
        public string? ItemidNombre { get => _ItemidNombre; set { if (RaiseAcceptPendingChange(value, _ItemidNombre)) { _ItemidNombre = value; OnPropertyChanged(); } } }

        private int? _Anio1;
        [XmlAttribute]
        public int? Anio1 { get => _Anio1; set { if (RaiseAcceptPendingChange(value, _Anio1)) { _Anio1 = value; OnPropertyChanged(); } } }

        private int? _Anio2;
        [XmlAttribute]
        public int? Anio2 { get => _Anio2; set { if (RaiseAcceptPendingChange(value, _Anio2)) { _Anio2 = value; OnPropertyChanged(); } } }

        private BoolCN? _Inluirtrasl;
        [XmlAttribute]
        public BoolCN? Inluirtrasl { get => _Inluirtrasl; set { if (RaiseAcceptPendingChange(value, _Inluirtrasl)) { _Inluirtrasl = value; OnPropertyChanged(); } } }

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
    public class WFEstadisticosClienteVentaWF_Ttl_rep_cliente_comparacionBindingModel : Validatable
    {

        public WFEstadisticosClienteVentaWF_Ttl_rep_cliente_comparacionBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Mes;
        [XmlAttribute]
        public string? Mes { get => _Mes; set { if (RaiseAcceptPendingChange(value, _Mes)) { _Mes = value; OnPropertyChanged(); } } }

        private long? _Personaid;
        [XmlAttribute]
        public long? Personaid { get => _Personaid; set { if (RaiseAcceptPendingChange(value, _Personaid)) { _Personaid = value; OnPropertyChanged(); } } }

        private int? _Cantidadanio1;
        [XmlAttribute]
        public int? Cantidadanio1 { get => _Cantidadanio1; set { if (RaiseAcceptPendingChange(value, _Cantidadanio1)) { _Cantidadanio1 = value; OnPropertyChanged(); } } }

        private decimal? _Totalanio1;
        [XmlAttribute]
        public decimal? Totalanio1 { get => _Totalanio1; set { if (RaiseAcceptPendingChange(value, _Totalanio1)) { _Totalanio1 = value; OnPropertyChanged(); } } }

        private int? _Cantidadanio2;
        [XmlAttribute]
        public int? Cantidadanio2 { get => _Cantidadanio2; set { if (RaiseAcceptPendingChange(value, _Cantidadanio2)) { _Cantidadanio2 = value; OnPropertyChanged(); } } }

        private decimal? _Totalanio2;
        [XmlAttribute]
        public decimal? Totalanio2 { get => _Totalanio2; set { if (RaiseAcceptPendingChange(value, _Totalanio2)) { _Totalanio2 = value; OnPropertyChanged(); } } }

        private decimal? _Diferencia;
        [XmlAttribute]
        public decimal? Diferencia { get => _Diferencia; set { if (RaiseAcceptPendingChange(value, _Diferencia)) { _Diferencia = value; OnPropertyChanged(); } } }

        private decimal? _Porcentajediferencia;
        [XmlAttribute]
        public decimal? Porcentajediferencia { get => _Porcentajediferencia; set { if (RaiseAcceptPendingChange(value, _Porcentajediferencia)) { _Porcentajediferencia = value; OnPropertyChanged(); } } }

        private decimal? _Acumuladodiferencia;
        [XmlAttribute]
        public decimal? Acumuladodiferencia { get => _Acumuladodiferencia; set { if (RaiseAcceptPendingChange(value, _Acumuladodiferencia)) { _Acumuladodiferencia = value; OnPropertyChanged(); } } }

        private decimal? _Porcacumuladodiferencia;
        [XmlAttribute]
        public decimal? Porcacumuladodiferencia { get => _Porcacumuladodiferencia; set { if (RaiseAcceptPendingChange(value, _Porcacumuladodiferencia)) { _Porcacumuladodiferencia = value; OnPropertyChanged(); } } }

        private string? _Dgimage;
        [XmlAttribute]
        public string? Dgimage { get => _Dgimage; set { if (RaiseAcceptPendingChange(value, _Dgimage)) { _Dgimage = value; OnPropertyChanged(); } } }

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

