
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
    public class FRptInventarioXAlmacenWFBindingModel : Validatable
    {

        public FRptInventarioXAlmacenWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Almacencombobox;
        [XmlAttribute]
        public long? Almacencombobox { get => _Almacencombobox; set { if (RaiseAcceptPendingChange(value, _Almacencombobox)) { _Almacencombobox = value; OnPropertyChanged(); } } }

        private long? _Productoid;
        [XmlAttribute]
        public long? Productoid { get => _Productoid; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value; OnPropertyChanged(); } } }

        private string? _ProductoidClave;
        [XmlAttribute]
        public string? ProductoidClave { get => _ProductoidClave; set { if (RaiseAcceptPendingChange(value, _ProductoidClave)) { _ProductoidClave = value; OnPropertyChanged(); } } }

        private string? _ProductoidNombre;
        [XmlAttribute]
        public string? ProductoidNombre { get => _ProductoidNombre; set { if (RaiseAcceptPendingChange(value, _ProductoidNombre)) { _ProductoidNombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbtodosalmacenes;
        [XmlAttribute]
        public BoolCN? Cbtodosalmacenes { get => _Cbtodosalmacenes; set { if (RaiseAcceptPendingChange(value, _Cbtodosalmacenes)) { _Cbtodosalmacenes = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbtodosproductos;
        [XmlAttribute]
        public BoolCN? Cbtodosproductos { get => _Cbtodosproductos; set { if (RaiseAcceptPendingChange(value, _Cbtodosproductos)) { _Cbtodosproductos = value; OnPropertyChanged(); } } }

        private string? _AlmacencomboboxClave;
        [XmlAttribute]
        public string? AlmacencomboboxClave { get => _AlmacencomboboxClave; set { if (RaiseAcceptPendingChange(value, _AlmacencomboboxClave)) { _AlmacencomboboxClave = value; OnPropertyChanged(); } } }

        private string? _AlmacencomboboxNombre;
        [XmlAttribute]
        public string? AlmacencomboboxNombre { get => _AlmacencomboboxNombre; set { if (RaiseAcceptPendingChange(value, _AlmacencomboboxNombre)) { _AlmacencomboboxNombre = value; OnPropertyChanged(); } } }

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

