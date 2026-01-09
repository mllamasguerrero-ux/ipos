
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
    public class WFLocacionProductosWFBindingModel : Validatable
    {

        public WFLocacionProductosWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Cbanaquel;
        [XmlAttribute]
        public long? Cbanaquel { get => _Cbanaquel; set { if (RaiseAcceptPendingChange(value, _Cbanaquel)) { _Cbanaquel = value; OnPropertyChanged(); } } }

        private string? _Productodescripcion;
        [XmlAttribute]
        public string? Productodescripcion { get => _Productodescripcion; set { if (RaiseAcceptPendingChange(value, _Productodescripcion)) { _Productodescripcion = value; OnPropertyChanged(); } } }

        private string? _Tblocalidad;
        [XmlAttribute]
        public string? Tblocalidad { get => _Tblocalidad; set { if (RaiseAcceptPendingChange(value, _Tblocalidad)) { _Tblocalidad = value; OnPropertyChanged(); } } }

        private long? _Almacencombobox;
        [XmlAttribute]
        public long? Almacencombobox { get => _Almacencombobox; set { if (RaiseAcceptPendingChange(value, _Almacencombobox)) { _Almacencombobox = value; OnPropertyChanged(); } } }

        private string? _Tbcodigo;
        [XmlAttribute]
        public string? Tbcodigo { get => _Tbcodigo; set { if (RaiseAcceptPendingChange(value, _Tbcodigo)) { _Tbcodigo = value; OnPropertyChanged(); } } }

        private string? _Productonombre;
        [XmlAttribute]
        public string? Productonombre { get => _Productonombre; set { if (RaiseAcceptPendingChange(value, _Productonombre)) { _Productonombre = value; OnPropertyChanged(); } } }

        private string? _CbanaquelClave;
        [XmlAttribute]
        public string? CbanaquelClave { get => _CbanaquelClave; set { if (RaiseAcceptPendingChange(value, _CbanaquelClave)) { _CbanaquelClave = value; OnPropertyChanged(); } } }

        private string? _CbanaquelNombre;
        [XmlAttribute]
        public string? CbanaquelNombre { get => _CbanaquelNombre; set { if (RaiseAcceptPendingChange(value, _CbanaquelNombre)) { _CbanaquelNombre = value; OnPropertyChanged(); } } }

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

    
    [XmlRoot]
    public class WFLocacionProductosWF_ProductolocationsBindingModel : Validatable
    {

        public WFLocacionProductosWF_ProductolocationsBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Activo;
        [XmlAttribute]
        public string? Activo { get => _Activo; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Creado;
        [XmlAttribute]
        public DateTimeOffset? Creado { get => _Creado; set { if (RaiseAcceptPendingChange(value, _Creado)) { _Creado = value; OnPropertyChanged(); } } }

        private long? _Creadopor_userid;
        [XmlAttribute]
        public long? Creadopor_userid { get => _Creadopor_userid; set { if (RaiseAcceptPendingChange(value, _Creadopor_userid)) { _Creadopor_userid = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Modificado;
        [XmlAttribute]
        public DateTimeOffset? Modificado { get => _Modificado; set { if (RaiseAcceptPendingChange(value, _Modificado)) { _Modificado = value; OnPropertyChanged(); } } }

        private long? _Modificadopor_userid;
        [XmlAttribute]
        public long? Modificadopor_userid { get => _Modificadopor_userid; set { if (RaiseAcceptPendingChange(value, _Modificadopor_userid)) { _Modificadopor_userid = value; OnPropertyChanged(); } } }

        private long? _Productoid;
        [XmlAttribute]
        public long? Productoid { get => _Productoid; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value; OnPropertyChanged(); } } }

        private string? _Anaquel;
        [XmlAttribute]
        public string? Anaquel { get => _Anaquel; set { if (RaiseAcceptPendingChange(value, _Anaquel)) { _Anaquel = value; OnPropertyChanged(); } } }

        private string? _Localidad;
        [XmlAttribute]
        public string? Localidad { get => _Localidad; set { if (RaiseAcceptPendingChange(value, _Localidad)) { _Localidad = value; OnPropertyChanged(); } } }

        private string? _Nombrealmacen;
        [XmlAttribute]
        public string? Nombrealmacen { get => _Nombrealmacen; set { if (RaiseAcceptPendingChange(value, _Nombrealmacen)) { _Nombrealmacen = value; OnPropertyChanged(); } } }

        private string? _Coleliminar;
        [XmlAttribute]
        public string? Coleliminar { get => _Coleliminar; set { if (RaiseAcceptPendingChange(value, _Coleliminar)) { _Coleliminar = value; OnPropertyChanged(); } } }

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

