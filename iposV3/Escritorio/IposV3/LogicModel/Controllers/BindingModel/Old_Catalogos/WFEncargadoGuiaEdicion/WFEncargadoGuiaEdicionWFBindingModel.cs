
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
    public class WFEncargadoGuiaEdicionWFBindingModel : Validatable
    {

        public WFEncargadoGuiaEdicionWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Razonsocial;
        [XmlAttribute]
        public string? Razonsocial { get => _Razonsocial; set { if (RaiseAcceptPendingChange(value, _Razonsocial)) { _Razonsocial = value; OnPropertyChanged(); } } }

        private string? _Rfc;
        [XmlAttribute]
        public string? Rfc { get => _Rfc; set { if (RaiseAcceptPendingChange(value, _Rfc)) { _Rfc = value; OnPropertyChanged(); } } }

        private string? _Descripcion;
        [XmlAttribute]
        public string? Descripcion { get => _Descripcion; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value; OnPropertyChanged(); } } }

        private string? _Memo;
        [XmlAttribute]
        public string? Memo { get => _Memo; set { if (RaiseAcceptPendingChange(value, _Memo)) { _Memo = value; OnPropertyChanged(); } } }

        private long? _Listaprecioid;
        [XmlAttribute]
        public long? Listaprecioid { get => _Listaprecioid; set { if (RaiseAcceptPendingChange(value, _Listaprecioid)) { _Listaprecioid = value; OnPropertyChanged(); } } }

        private BoolCN? _Activo;
        [XmlAttribute]
        public BoolCN? Activo { get => _Activo; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value; OnPropertyChanged(); } } }

        private long? _Paiscomboboxfb;
        [XmlAttribute]
        public long? Paiscomboboxfb { get => _Paiscomboboxfb; set { if (RaiseAcceptPendingChange(value, _Paiscomboboxfb)) { _Paiscomboboxfb = value; OnPropertyChanged(); } } }

        private long? _Estado;
        [XmlAttribute]
        public long? Estado { get => _Estado; set { if (RaiseAcceptPendingChange(value, _Estado)) { _Estado = value; OnPropertyChanged(); } } }

        private long? _Localidadcombobox;
        [XmlAttribute]
        public long? Localidadcombobox { get => _Localidadcombobox; set { if (RaiseAcceptPendingChange(value, _Localidadcombobox)) { _Localidadcombobox = value; OnPropertyChanged(); } } }

        private string? _Codigopostal;
        [XmlAttribute]
        public string? Codigopostal { get => _Codigopostal; set { if (RaiseAcceptPendingChange(value, _Codigopostal)) { _Codigopostal = value; OnPropertyChanged(); } } }

        private long? _Municipiocombobox;
        [XmlAttribute]
        public long? Municipiocombobox { get => _Municipiocombobox; set { if (RaiseAcceptPendingChange(value, _Municipiocombobox)) { _Municipiocombobox = value; OnPropertyChanged(); } } }

        private long? _Coloniacombobox;
        [XmlAttribute]
        public long? Coloniacombobox { get => _Coloniacombobox; set { if (RaiseAcceptPendingChange(value, _Coloniacombobox)) { _Coloniacombobox = value; OnPropertyChanged(); } } }

        private string? _Domicilio;
        [XmlAttribute]
        public string? Domicilio { get => _Domicilio; set { if (RaiseAcceptPendingChange(value, _Domicilio)) { _Domicilio = value; OnPropertyChanged(); } } }

        private string? _Numerointerior;
        [XmlAttribute]
        public string? Numerointerior { get => _Numerointerior; set { if (RaiseAcceptPendingChange(value, _Numerointerior)) { _Numerointerior = value; OnPropertyChanged(); } } }

        private string? _Referenciadom;
        [XmlAttribute]
        public string? Referenciadom { get => _Referenciadom; set { if (RaiseAcceptPendingChange(value, _Referenciadom)) { _Referenciadom = value; OnPropertyChanged(); } } }

        private string? _Numeroexterior;
        [XmlAttribute]
        public string? Numeroexterior { get => _Numeroexterior; set { if (RaiseAcceptPendingChange(value, _Numeroexterior)) { _Numeroexterior = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Vigencia;
        [XmlAttribute]
        public DateTimeOffset? Vigencia { get => _Vigencia; set { if (RaiseAcceptPendingChange(value, _Vigencia)) { _Vigencia = value; OnPropertyChanged(); } } }

        private string? _Creadopor_userclave;
        [XmlAttribute]
        public string? Creadopor_userclave { get => _Creadopor_userclave; set { if (RaiseAcceptPendingChange(value, _Creadopor_userclave)) { _Creadopor_userclave = value; OnPropertyChanged(); } } }

        private string? _Modificadopor_userid;
        [XmlAttribute]
        public string? Modificadopor_userid { get => _Modificadopor_userid; set { if (RaiseAcceptPendingChange(value, _Modificadopor_userid)) { _Modificadopor_userid = value; OnPropertyChanged(); } } }

        private string? _Celular;
        [XmlAttribute]
        public string? Celular { get => _Celular; set { if (RaiseAcceptPendingChange(value, _Celular)) { _Celular = value; OnPropertyChanged(); } } }

        private string? _Nextel;
        [XmlAttribute]
        public string? Nextel { get => _Nextel; set { if (RaiseAcceptPendingChange(value, _Nextel)) { _Nextel = value; OnPropertyChanged(); } } }

        private string? _Gaffete;
        [XmlAttribute]
        public string? Gaffete { get => _Gaffete; set { if (RaiseAcceptPendingChange(value, _Gaffete)) { _Gaffete = value; OnPropertyChanged(); } } }

        private string? _Telefono2;
        [XmlAttribute]
        public string? Telefono2 { get => _Telefono2; set { if (RaiseAcceptPendingChange(value, _Telefono2)) { _Telefono2 = value; OnPropertyChanged(); } } }

        private string? _Telefono3;
        [XmlAttribute]
        public string? Telefono3 { get => _Telefono3; set { if (RaiseAcceptPendingChange(value, _Telefono3)) { _Telefono3 = value; OnPropertyChanged(); } } }

        private string? _Telefono1;
        [XmlAttribute]
        public string? Telefono1 { get => _Telefono1; set { if (RaiseAcceptPendingChange(value, _Telefono1)) { _Telefono1 = value; OnPropertyChanged(); } } }

        private string? _Email2;
        [XmlAttribute]
        public string? Email2 { get => _Email2; set { if (RaiseAcceptPendingChange(value, _Email2)) { _Email2 = value; OnPropertyChanged(); } } }

        private string? _Contacto2;
        [XmlAttribute]
        public string? Contacto2 { get => _Contacto2; set { if (RaiseAcceptPendingChange(value, _Contacto2)) { _Contacto2 = value; OnPropertyChanged(); } } }

        private string? _Email1;
        [XmlAttribute]
        public string? Email1 { get => _Email1; set { if (RaiseAcceptPendingChange(value, _Email1)) { _Email1 = value; OnPropertyChanged(); } } }

        private string? _Contacto1;
        [XmlAttribute]
        public string? Contacto1 { get => _Contacto1; set { if (RaiseAcceptPendingChange(value, _Contacto1)) { _Contacto1 = value; OnPropertyChanged(); } } }

        private string? _Nombres;
        [XmlAttribute]
        public string? Nombres { get => _Nombres; set { if (RaiseAcceptPendingChange(value, _Nombres)) { _Nombres = value; OnPropertyChanged(); } } }

        private string? _Apellidos;
        [XmlAttribute]
        public string? Apellidos { get => _Apellidos; set { if (RaiseAcceptPendingChange(value, _Apellidos)) { _Apellidos = value; OnPropertyChanged(); } } }

        private long? _Saludoid;
        [XmlAttribute]
        public long? Saludoid { get => _Saludoid; set { if (RaiseAcceptPendingChange(value, _Saludoid)) { _Saludoid = value; OnPropertyChanged(); } } }

        private string? _Numlicencia;
        [XmlAttribute]
        public string? Numlicencia { get => _Numlicencia; set { if (RaiseAcceptPendingChange(value, _Numlicencia)) { _Numlicencia = value; OnPropertyChanged(); } } }

        private long? _Sat_partetransporteid;
        [XmlAttribute]
        public long? Sat_partetransporteid { get => _Sat_partetransporteid; set { if (RaiseAcceptPendingChange(value, _Sat_partetransporteid)) { _Sat_partetransporteid = value; OnPropertyChanged(); } } }

        private string? _Residenciafiscal;
        [XmlAttribute]
        public string? Residenciafiscal { get => _Residenciafiscal; set { if (RaiseAcceptPendingChange(value, _Residenciafiscal)) { _Residenciafiscal = value; OnPropertyChanged(); } } }

        private long? _Sat_figuratransporteid;
        [XmlAttribute]
        public long? Sat_figuratransporteid { get => _Sat_figuratransporteid; set { if (RaiseAcceptPendingChange(value, _Sat_figuratransporteid)) { _Sat_figuratransporteid = value; OnPropertyChanged(); } } }

        private string? _Numregidtrib;
        [XmlAttribute]
        public string? Numregidtrib { get => _Numregidtrib; set { if (RaiseAcceptPendingChange(value, _Numregidtrib)) { _Numregidtrib = value; OnPropertyChanged(); } } }

        private string? _ListaprecioidClave;
        [XmlAttribute]
        public string? ListaprecioidClave { get => _ListaprecioidClave; set { if (RaiseAcceptPendingChange(value, _ListaprecioidClave)) { _ListaprecioidClave = value; OnPropertyChanged(); } } }

        private string? _ListaprecioidNombre;
        [XmlAttribute]
        public string? ListaprecioidNombre { get => _ListaprecioidNombre; set { if (RaiseAcceptPendingChange(value, _ListaprecioidNombre)) { _ListaprecioidNombre = value; OnPropertyChanged(); } } }

        private string? _PaiscomboboxfbClave;
        [XmlAttribute]
        public string? PaiscomboboxfbClave { get => _PaiscomboboxfbClave; set { if (RaiseAcceptPendingChange(value, _PaiscomboboxfbClave)) { _PaiscomboboxfbClave = value; OnPropertyChanged(); } } }

        private string? _PaiscomboboxfbNombre;
        [XmlAttribute]
        public string? PaiscomboboxfbNombre { get => _PaiscomboboxfbNombre; set { if (RaiseAcceptPendingChange(value, _PaiscomboboxfbNombre)) { _PaiscomboboxfbNombre = value; OnPropertyChanged(); } } }

        private string? _EstadoClave;
        [XmlAttribute]
        public string? EstadoClave { get => _EstadoClave; set { if (RaiseAcceptPendingChange(value, _EstadoClave)) { _EstadoClave = value; OnPropertyChanged(); } } }

        private string? _EstadoNombre;
        [XmlAttribute]
        public string? EstadoNombre { get => _EstadoNombre; set { if (RaiseAcceptPendingChange(value, _EstadoNombre)) { _EstadoNombre = value; OnPropertyChanged(); } } }

        private string? _LocalidadcomboboxClave;
        [XmlAttribute]
        public string? LocalidadcomboboxClave { get => _LocalidadcomboboxClave; set { if (RaiseAcceptPendingChange(value, _LocalidadcomboboxClave)) { _LocalidadcomboboxClave = value; OnPropertyChanged(); } } }

        private string? _LocalidadcomboboxNombre;
        [XmlAttribute]
        public string? LocalidadcomboboxNombre { get => _LocalidadcomboboxNombre; set { if (RaiseAcceptPendingChange(value, _LocalidadcomboboxNombre)) { _LocalidadcomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _MunicipiocomboboxClave;
        [XmlAttribute]
        public string? MunicipiocomboboxClave { get => _MunicipiocomboboxClave; set { if (RaiseAcceptPendingChange(value, _MunicipiocomboboxClave)) { _MunicipiocomboboxClave = value; OnPropertyChanged(); } } }

        private string? _MunicipiocomboboxNombre;
        [XmlAttribute]
        public string? MunicipiocomboboxNombre { get => _MunicipiocomboboxNombre; set { if (RaiseAcceptPendingChange(value, _MunicipiocomboboxNombre)) { _MunicipiocomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _ColoniacomboboxClave;
        [XmlAttribute]
        public string? ColoniacomboboxClave { get => _ColoniacomboboxClave; set { if (RaiseAcceptPendingChange(value, _ColoniacomboboxClave)) { _ColoniacomboboxClave = value; OnPropertyChanged(); } } }

        private string? _ColoniacomboboxNombre;
        [XmlAttribute]
        public string? ColoniacomboboxNombre { get => _ColoniacomboboxNombre; set { if (RaiseAcceptPendingChange(value, _ColoniacomboboxNombre)) { _ColoniacomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _SaludoidClave;
        [XmlAttribute]
        public string? SaludoidClave { get => _SaludoidClave; set { if (RaiseAcceptPendingChange(value, _SaludoidClave)) { _SaludoidClave = value; OnPropertyChanged(); } } }

        private string? _SaludoidNombre;
        [XmlAttribute]
        public string? SaludoidNombre { get => _SaludoidNombre; set { if (RaiseAcceptPendingChange(value, _SaludoidNombre)) { _SaludoidNombre = value; OnPropertyChanged(); } } }

        private string? _Sat_partetransporteidClave;
        [XmlAttribute]
        public string? Sat_partetransporteidClave { get => _Sat_partetransporteidClave; set { if (RaiseAcceptPendingChange(value, _Sat_partetransporteidClave)) { _Sat_partetransporteidClave = value; OnPropertyChanged(); } } }

        private string? _Sat_partetransporteidNombre;
        [XmlAttribute]
        public string? Sat_partetransporteidNombre { get => _Sat_partetransporteidNombre; set { if (RaiseAcceptPendingChange(value, _Sat_partetransporteidNombre)) { _Sat_partetransporteidNombre = value; OnPropertyChanged(); } } }

        private string? _Sat_figuratransporteidClave;
        [XmlAttribute]
        public string? Sat_figuratransporteidClave { get => _Sat_figuratransporteidClave; set { if (RaiseAcceptPendingChange(value, _Sat_figuratransporteidClave)) { _Sat_figuratransporteidClave = value; OnPropertyChanged(); } } }

        private string? _Sat_figuratransporteidNombre;
        [XmlAttribute]
        public string? Sat_figuratransporteidNombre { get => _Sat_figuratransporteidNombre; set { if (RaiseAcceptPendingChange(value, _Sat_figuratransporteidNombre)) { _Sat_figuratransporteidNombre = value; OnPropertyChanged(); } } }

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

