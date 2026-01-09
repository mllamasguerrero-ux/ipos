
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
    public class DRptDetComprasMultiSucursalWFBindingModel : Validatable
    {

        public DRptDetComprasMultiSucursalWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Dtpfrom;
        [XmlAttribute]
        public DateTimeOffset? Dtpfrom { get => _Dtpfrom; set { if (RaiseAcceptPendingChange(value, _Dtpfrom)) { _Dtpfrom = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Dtpto;
        [XmlAttribute]
        public DateTimeOffset? Dtpto { get => _Dtpto; set { if (RaiseAcceptPendingChange(value, _Dtpto)) { _Dtpto = value; OnPropertyChanged(); } } }

        private long? _Cmbsubtipo;
        [XmlAttribute]
        public long? Cmbsubtipo { get => _Cmbsubtipo; set { if (RaiseAcceptPendingChange(value, _Cmbsubtipo)) { _Cmbsubtipo = value; OnPropertyChanged(); } } }

        private long? _Comboboxalmacen;
        [XmlAttribute]
        public long? Comboboxalmacen { get => _Comboboxalmacen; set { if (RaiseAcceptPendingChange(value, _Comboboxalmacen)) { _Comboboxalmacen = value; OnPropertyChanged(); } } }

        private long? _Cbfactrem;
        [XmlAttribute]
        public long? Cbfactrem { get => _Cbfactrem; set { if (RaiseAcceptPendingChange(value, _Cbfactrem)) { _Cbfactrem = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbreportetabular;
        [XmlAttribute]
        public BoolCN? Cbreportetabular { get => _Cbreportetabular; set { if (RaiseAcceptPendingChange(value, _Cbreportetabular)) { _Cbreportetabular = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbsoloalmacen;
        [XmlAttribute]
        public BoolCN? Cbsoloalmacen { get => _Cbsoloalmacen; set { if (RaiseAcceptPendingChange(value, _Cbsoloalmacen)) { _Cbsoloalmacen = value; OnPropertyChanged(); } } }

        private string? _CmbsubtipoClave;
        [XmlAttribute]
        public string? CmbsubtipoClave { get => _CmbsubtipoClave; set { if (RaiseAcceptPendingChange(value, _CmbsubtipoClave)) { _CmbsubtipoClave = value; OnPropertyChanged(); } } }

        private string? _CmbsubtipoNombre;
        [XmlAttribute]
        public string? CmbsubtipoNombre { get => _CmbsubtipoNombre; set { if (RaiseAcceptPendingChange(value, _CmbsubtipoNombre)) { _CmbsubtipoNombre = value; OnPropertyChanged(); } } }

        private string? _ComboboxalmacenClave;
        [XmlAttribute]
        public string? ComboboxalmacenClave { get => _ComboboxalmacenClave; set { if (RaiseAcceptPendingChange(value, _ComboboxalmacenClave)) { _ComboboxalmacenClave = value; OnPropertyChanged(); } } }

        private string? _ComboboxalmacenNombre;
        [XmlAttribute]
        public string? ComboboxalmacenNombre { get => _ComboboxalmacenNombre; set { if (RaiseAcceptPendingChange(value, _ComboboxalmacenNombre)) { _ComboboxalmacenNombre = value; OnPropertyChanged(); } } }

        private string? _CbfactremClave;
        [XmlAttribute]
        public string? CbfactremClave { get => _CbfactremClave; set { if (RaiseAcceptPendingChange(value, _CbfactremClave)) { _CbfactremClave = value; OnPropertyChanged(); } } }

        private string? _CbfactremNombre;
        [XmlAttribute]
        public string? CbfactremNombre { get => _CbfactremNombre; set { if (RaiseAcceptPendingChange(value, _CbfactremNombre)) { _CbfactremNombre = value; OnPropertyChanged(); } } }

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

