
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
    public class WFMovimAnaquelesWFBindingModel : Validatable
    {

        public WFMovimAnaquelesWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Cbanaquel;
        [XmlAttribute]
        public long? Cbanaquel { get => _Cbanaquel; set { if (RaiseAcceptPendingChange(value, _Cbanaquel)) { _Cbanaquel = value; OnPropertyChanged(); } } }

        private long? _Almacencombobox;
        [XmlAttribute]
        public long? Almacencombobox { get => _Almacencombobox; set { if (RaiseAcceptPendingChange(value, _Almacencombobox)) { _Almacencombobox = value; OnPropertyChanged(); } } }

        private long? _Almacennuevocombobox;
        [XmlAttribute]
        public long? Almacennuevocombobox { get => _Almacennuevocombobox; set { if (RaiseAcceptPendingChange(value, _Almacennuevocombobox)) { _Almacennuevocombobox = value; OnPropertyChanged(); } } }

        private long? _Cbanaqueldestino;
        [XmlAttribute]
        public long? Cbanaqueldestino { get => _Cbanaqueldestino; set { if (RaiseAcceptPendingChange(value, _Cbanaqueldestino)) { _Cbanaqueldestino = value; OnPropertyChanged(); } } }

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

        private string? _AlmacennuevocomboboxClave;
        [XmlAttribute]
        public string? AlmacennuevocomboboxClave { get => _AlmacennuevocomboboxClave; set { if (RaiseAcceptPendingChange(value, _AlmacennuevocomboboxClave)) { _AlmacennuevocomboboxClave = value; OnPropertyChanged(); } } }

        private string? _AlmacennuevocomboboxNombre;
        [XmlAttribute]
        public string? AlmacennuevocomboboxNombre { get => _AlmacennuevocomboboxNombre; set { if (RaiseAcceptPendingChange(value, _AlmacennuevocomboboxNombre)) { _AlmacennuevocomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _CbanaqueldestinoClave;
        [XmlAttribute]
        public string? CbanaqueldestinoClave { get => _CbanaqueldestinoClave; set { if (RaiseAcceptPendingChange(value, _CbanaqueldestinoClave)) { _CbanaqueldestinoClave = value; OnPropertyChanged(); } } }

        private string? _CbanaqueldestinoNombre;
        [XmlAttribute]
        public string? CbanaqueldestinoNombre { get => _CbanaqueldestinoNombre; set { if (RaiseAcceptPendingChange(value, _CbanaqueldestinoNombre)) { _CbanaqueldestinoNombre = value; OnPropertyChanged(); } } }

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
    public class WFMovimAnaquelesWF_AnaquelcontentBindingModel : Validatable
    {

        public WFMovimAnaquelesWF_AnaquelcontentBindingModel()
        {
            FillCatalogRelatedFields();
        }




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

        private string? _Descripcion2;
        [XmlAttribute]
        public string? Descripcion2 { get => _Descripcion2; set { if (RaiseAcceptPendingChange(value, _Descripcion2)) { _Descripcion2 = value; OnPropertyChanged(); } } }

        private long? _Productoid;
        [XmlAttribute]
        public long? Productoid { get => _Productoid; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Descripcion1;
        [XmlAttribute]
        public string? Descripcion1 { get => _Descripcion1; set { if (RaiseAcceptPendingChange(value, _Descripcion1)) { _Descripcion1 = value; OnPropertyChanged(); } } }

        private string? _Anaquel;
        [XmlAttribute]
        public string? Anaquel { get => _Anaquel; set { if (RaiseAcceptPendingChange(value, _Anaquel)) { _Anaquel = value; OnPropertyChanged(); } } }

        private string? _Localidad;
        [XmlAttribute]
        public string? Localidad { get => _Localidad; set { if (RaiseAcceptPendingChange(value, _Localidad)) { _Localidad = value; OnPropertyChanged(); } } }

        private string? _Dgeliminar;
        [XmlAttribute]
        public string? Dgeliminar { get => _Dgeliminar; set { if (RaiseAcceptPendingChange(value, _Dgeliminar)) { _Dgeliminar = value; OnPropertyChanged(); } } }

        private string? _Dgmover;
        [XmlAttribute]
        public string? Dgmover { get => _Dgmover; set { if (RaiseAcceptPendingChange(value, _Dgmover)) { _Dgmover = value; OnPropertyChanged(); } } }

        private string? _Dglocnueva;
        [XmlAttribute]
        public string? Dglocnueva { get => _Dglocnueva; set { if (RaiseAcceptPendingChange(value, _Dglocnueva)) { _Dglocnueva = value; OnPropertyChanged(); } } }

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

