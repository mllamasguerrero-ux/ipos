
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
    public class WFTrasladoXSucursalWFBindingModel : Validatable
    {

        public WFTrasladoXSucursalWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Sucursalcombobox;
        [XmlAttribute]
        public long? Sucursalcombobox { get => _Sucursalcombobox; set { if (RaiseAcceptPendingChange(value, _Sucursalcombobox)) { _Sucursalcombobox = value; OnPropertyChanged(); } } }

        private long? _Combotiporeporte;
        [XmlAttribute]
        public long? Combotiporeporte { get => _Combotiporeporte; set { if (RaiseAcceptPendingChange(value, _Combotiporeporte)) { _Combotiporeporte = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbtodas;
        [XmlAttribute]
        public BoolCN? Cbtodas { get => _Cbtodas; set { if (RaiseAcceptPendingChange(value, _Cbtodas)) { _Cbtodas = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpfrom;
        [XmlAttribute]
        public DateTimeOffset? Dtpfrom { get => _Dtpfrom; set { if (RaiseAcceptPendingChange(value, _Dtpfrom)) { _Dtpfrom = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpto;
        [XmlAttribute]
        public DateTimeOffset? Dtpto { get => _Dtpto; set { if (RaiseAcceptPendingChange(value, _Dtpto)) { _Dtpto = value; OnPropertyChanged(); } } }

        private string? _SucursalcomboboxClave;
        [XmlAttribute]
        public string? SucursalcomboboxClave { get => _SucursalcomboboxClave; set { if (RaiseAcceptPendingChange(value, _SucursalcomboboxClave)) { _SucursalcomboboxClave = value; OnPropertyChanged(); } } }

        private string? _SucursalcomboboxNombre;
        [XmlAttribute]
        public string? SucursalcomboboxNombre { get => _SucursalcomboboxNombre; set { if (RaiseAcceptPendingChange(value, _SucursalcomboboxNombre)) { _SucursalcomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _CombotiporeporteClave;
        [XmlAttribute]
        public string? CombotiporeporteClave { get => _CombotiporeporteClave; set { if (RaiseAcceptPendingChange(value, _CombotiporeporteClave)) { _CombotiporeporteClave = value; OnPropertyChanged(); } } }

        private string? _CombotiporeporteNombre;
        [XmlAttribute]
        public string? CombotiporeporteNombre { get => _CombotiporeporteNombre; set { if (RaiseAcceptPendingChange(value, _CombotiporeporteNombre)) { _CombotiporeporteNombre = value; OnPropertyChanged(); } } }

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

