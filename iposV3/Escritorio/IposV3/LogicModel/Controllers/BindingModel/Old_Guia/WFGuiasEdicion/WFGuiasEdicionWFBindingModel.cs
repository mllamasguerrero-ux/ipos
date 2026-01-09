
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
    public class WFGuiasEdicionWFBindingModel : Validatable
    {

        public WFGuiasEdicionWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private DateTimeOffset? _Horaestimadrec;
        [XmlAttribute]
        public DateTimeOffset? Horaestimadrec { get => _Horaestimadrec; set { if (RaiseAcceptPendingChange(value, _Horaestimadrec)) { _Horaestimadrec = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechahora;
        [XmlAttribute]
        public DateTimeOffset? Fechahora { get => _Fechahora; set { if (RaiseAcceptPendingChange(value, _Fechahora)) { _Fechahora = value; OnPropertyChanged(); } } }

        private long? _Vehiculoid;
        [XmlAttribute]
        public long? Vehiculoid { get => _Vehiculoid; set { if (RaiseAcceptPendingChange(value, _Vehiculoid)) { _Vehiculoid = value; OnPropertyChanged(); } } }

        private string? _VehiculoidClave;
        [XmlAttribute]
        public string? VehiculoidClave { get => _VehiculoidClave; set { if (RaiseAcceptPendingChange(value, _VehiculoidClave)) { _VehiculoidClave = value; OnPropertyChanged(); } } }

        private string? _VehiculoidNombre;
        [XmlAttribute]
        public string? VehiculoidNombre { get => _VehiculoidNombre; set { if (RaiseAcceptPendingChange(value, _VehiculoidNombre)) { _VehiculoidNombre = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha;
        [XmlAttribute]
        public DateTimeOffset? Fecha { get => _Fecha; set { if (RaiseAcceptPendingChange(value, _Fecha)) { _Fecha = value; OnPropertyChanged(); } } }

        private long? _Encargadoid;
        [XmlAttribute]
        public long? Encargadoid { get => _Encargadoid; set { if (RaiseAcceptPendingChange(value, _Encargadoid)) { _Encargadoid = value; OnPropertyChanged(); } } }

        private string? _EncargadoidClave;
        [XmlAttribute]
        public string? EncargadoidClave { get => _EncargadoidClave; set { if (RaiseAcceptPendingChange(value, _EncargadoidClave)) { _EncargadoidClave = value; OnPropertyChanged(); } } }

        private string? _EncargadoidNombre;
        [XmlAttribute]
        public string? EncargadoidNombre { get => _EncargadoidNombre; set { if (RaiseAcceptPendingChange(value, _EncargadoidNombre)) { _EncargadoidNombre = value; OnPropertyChanged(); } } }

        private string? _Tbtransacccion;
        [XmlAttribute]
        public string? Tbtransacccion { get => _Tbtransacccion; set { if (RaiseAcceptPendingChange(value, _Tbtransacccion)) { _Tbtransacccion = value; OnPropertyChanged(); } } }

        private string? _Guiapaqueteria;
        [XmlAttribute]
        public string? Guiapaqueteria { get => _Guiapaqueteria; set { if (RaiseAcceptPendingChange(value, _Guiapaqueteria)) { _Guiapaqueteria = value; OnPropertyChanged(); } } }

        private long? _Tipoentregaidcombobox;
        [XmlAttribute]
        public long? Tipoentregaidcombobox { get => _Tipoentregaidcombobox; set { if (RaiseAcceptPendingChange(value, _Tipoentregaidcombobox)) { _Tipoentregaidcombobox = value; OnPropertyChanged(); } } }

        private long? _Estado;
        [XmlAttribute]
        public long? Estado { get => _Estado; set { if (RaiseAcceptPendingChange(value, _Estado)) { _Estado = value; OnPropertyChanged(); } } }

        private string? _Tbnota;
        [XmlAttribute]
        public string? Tbnota { get => _Tbnota; set { if (RaiseAcceptPendingChange(value, _Tbnota)) { _Tbnota = value; OnPropertyChanged(); } } }

        private string? _TipoentregaidcomboboxClave;
        [XmlAttribute]
        public string? TipoentregaidcomboboxClave { get => _TipoentregaidcomboboxClave; set { if (RaiseAcceptPendingChange(value, _TipoentregaidcomboboxClave)) { _TipoentregaidcomboboxClave = value; OnPropertyChanged(); } } }

        private string? _TipoentregaidcomboboxNombre;
        [XmlAttribute]
        public string? TipoentregaidcomboboxNombre { get => _TipoentregaidcomboboxNombre; set { if (RaiseAcceptPendingChange(value, _TipoentregaidcomboboxNombre)) { _TipoentregaidcomboboxNombre = value; OnPropertyChanged(); } } }

        private string? _EstadoClave;
        [XmlAttribute]
        public string? EstadoClave { get => _EstadoClave; set { if (RaiseAcceptPendingChange(value, _EstadoClave)) { _EstadoClave = value; OnPropertyChanged(); } } }

        private string? _EstadoNombre;
        [XmlAttribute]
        public string? EstadoNombre { get => _EstadoNombre; set { if (RaiseAcceptPendingChange(value, _EstadoNombre)) { _EstadoNombre = value; OnPropertyChanged(); } } }

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
    public class WFGuiasEdicionWF_Guiadetalle_BindingModel : Validatable
    {

        public WFGuiasEdicionWF_Guiadetalle_BindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Dgeliminar;
        [XmlAttribute]
        public string? Dgeliminar { get => _Dgeliminar; set { if (RaiseAcceptPendingChange(value, _Dgeliminar)) { _Dgeliminar = value; OnPropertyChanged(); } } }

        private int? _Estadoguiabool;
        [XmlAttribute]
        public int? Estadoguiabool { get => _Estadoguiabool; set { if (RaiseAcceptPendingChange(value, _Estadoguiabool)) { _Estadoguiabool = value; OnPropertyChanged(); } } }

        private string? _Dgreimprimircartaporte;
        [XmlAttribute]
        public string? Dgreimprimircartaporte { get => _Dgreimprimircartaporte; set { if (RaiseAcceptPendingChange(value, _Dgreimprimircartaporte)) { _Dgreimprimircartaporte = value; OnPropertyChanged(); } } }

        private long? _Doctoid;
        [XmlAttribute]
        public long? Doctoid { get => _Doctoid; set { if (RaiseAcceptPendingChange(value, _Doctoid)) { _Doctoid = value; OnPropertyChanged(); } } }

        private long? _Estadoguiaid;
        [XmlAttribute]
        public long? Estadoguiaid { get => _Estadoguiaid; set { if (RaiseAcceptPendingChange(value, _Estadoguiaid)) { _Estadoguiaid = value; OnPropertyChanged(); } } }

        private int? _Doctofolio;
        [XmlAttribute]
        public int? Doctofolio { get => _Doctofolio; set { if (RaiseAcceptPendingChange(value, _Doctofolio)) { _Doctofolio = value; OnPropertyChanged(); } } }

        private string? _Doctoserie;
        [XmlAttribute]
        public string? Doctoserie { get => _Doctoserie; set { if (RaiseAcceptPendingChange(value, _Doctoserie)) { _Doctoserie = value; OnPropertyChanged(); } } }

        private int? _Doctofoliosat;
        [XmlAttribute]
        public int? Doctofoliosat { get => _Doctofoliosat; set { if (RaiseAcceptPendingChange(value, _Doctofoliosat)) { _Doctofoliosat = value; OnPropertyChanged(); } } }

        private long? _Cartaporteid;
        [XmlAttribute]
        public long? Cartaporteid { get => _Cartaporteid; set { if (RaiseAcceptPendingChange(value, _Cartaporteid)) { _Cartaporteid = value; OnPropertyChanged(); } } }

        private string? _Doctoseriesat;
        [XmlAttribute]
        public string? Doctoseriesat { get => _Doctoseriesat; set { if (RaiseAcceptPendingChange(value, _Doctoseriesat)) { _Doctoseriesat = value; OnPropertyChanged(); } } }

        private decimal? _Doctototal;
        [XmlAttribute]
        public decimal? Doctototal { get => _Doctototal; set { if (RaiseAcceptPendingChange(value, _Doctototal)) { _Doctototal = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Doctofecha;
        [XmlAttribute]
        public DateTimeOffset? Doctofecha { get => _Doctofecha; set { if (RaiseAcceptPendingChange(value, _Doctofecha)) { _Doctofecha = value; OnPropertyChanged(); } } }

        private string? _Clientenombre;
        [XmlAttribute]
        public string? Clientenombre { get => _Clientenombre; set { if (RaiseAcceptPendingChange(value, _Clientenombre)) { _Clientenombre = value; OnPropertyChanged(); } } }

        private string? _Clientenombres;
        [XmlAttribute]
        public string? Clientenombres { get => _Clientenombres; set { if (RaiseAcceptPendingChange(value, _Clientenombres)) { _Clientenombres = value; OnPropertyChanged(); } } }

        private string? _Clienteapellidos;
        [XmlAttribute]
        public string? Clienteapellidos { get => _Clienteapellidos; set { if (RaiseAcceptPendingChange(value, _Clienteapellidos)) { _Clienteapellidos = value; OnPropertyChanged(); } } }

        private string? _Clientedomicilio;
        [XmlAttribute]
        public string? Clientedomicilio { get => _Clientedomicilio; set { if (RaiseAcceptPendingChange(value, _Clientedomicilio)) { _Clientedomicilio = value; OnPropertyChanged(); } } }

        private string? _Clienteciudad;
        [XmlAttribute]
        public string? Clienteciudad { get => _Clienteciudad; set { if (RaiseAcceptPendingChange(value, _Clienteciudad)) { _Clienteciudad = value; OnPropertyChanged(); } } }

        private string? _Clientecodigopostal;
        [XmlAttribute]
        public string? Clientecodigopostal { get => _Clientecodigopostal; set { if (RaiseAcceptPendingChange(value, _Clientecodigopostal)) { _Clientecodigopostal = value; OnPropertyChanged(); } } }

        private string? _Clientecolonia;
        [XmlAttribute]
        public string? Clientecolonia { get => _Clientecolonia; set { if (RaiseAcceptPendingChange(value, _Clientecolonia)) { _Clientecolonia = value; OnPropertyChanged(); } } }

        private int? _Clientedias;
        [XmlAttribute]
        public int? Clientedias { get => _Clientedias; set { if (RaiseAcceptPendingChange(value, _Clientedias)) { _Clientedias = value; OnPropertyChanged(); } } }

        private string? _Estado;
        [XmlAttribute]
        public string? Estado { get => _Estado; set { if (RaiseAcceptPendingChange(value, _Estado)) { _Estado = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecharecibido;
        [XmlAttribute]
        public DateTimeOffset? Fecharecibido { get => _Fecharecibido; set { if (RaiseAcceptPendingChange(value, _Fecharecibido)) { _Fecharecibido = value; OnPropertyChanged(); } } }

        private string? _Fechahorarecibido;
        [XmlAttribute]
        public string? Fechahorarecibido { get => _Fechahorarecibido; set { if (RaiseAcceptPendingChange(value, _Fechahorarecibido)) { _Fechahorarecibido = value; OnPropertyChanged(); } } }

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

