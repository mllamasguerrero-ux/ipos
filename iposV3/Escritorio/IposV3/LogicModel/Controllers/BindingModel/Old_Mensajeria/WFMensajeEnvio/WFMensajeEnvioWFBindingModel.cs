
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
    public class WFMensajeEnvioWFBindingModel : Validatable
    {

        public WFMensajeEnvioWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private BoolCN? _Cbtodassucursales;
        [XmlAttribute]
        public BoolCN? Cbtodassucursales { get => _Cbtodassucursales; set { if (RaiseAcceptPendingChange(value, _Cbtodassucursales)) { _Cbtodassucursales = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbtodasareas;
        [XmlAttribute]
        public BoolCN? Cbtodasareas { get => _Cbtodasareas; set { if (RaiseAcceptPendingChange(value, _Cbtodasareas)) { _Cbtodasareas = value; OnPropertyChanged(); } } }

        private long? _Mensajenivelurgencia;
        [XmlAttribute]
        public long? Mensajenivelurgencia { get => _Mensajenivelurgencia; set { if (RaiseAcceptPendingChange(value, _Mensajenivelurgencia)) { _Mensajenivelurgencia = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbrestrictivo;
        [XmlAttribute]
        public BoolCN? Cbrestrictivo { get => _Cbrestrictivo; set { if (RaiseAcceptPendingChange(value, _Cbrestrictivo)) { _Cbrestrictivo = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbsoloadministradores;
        [XmlAttribute]
        public BoolCN? Cbsoloadministradores { get => _Cbsoloadministradores; set { if (RaiseAcceptPendingChange(value, _Cbsoloadministradores)) { _Cbsoloadministradores = value; OnPropertyChanged(); } } }

        private string? _Tbasunto;
        [XmlAttribute]
        public string? Tbasunto { get => _Tbasunto; set { if (RaiseAcceptPendingChange(value, _Tbasunto)) { _Tbasunto = value; OnPropertyChanged(); } } }

        private string? _MensajenivelurgenciaClave;
        [XmlAttribute]
        public string? MensajenivelurgenciaClave { get => _MensajenivelurgenciaClave; set { if (RaiseAcceptPendingChange(value, _MensajenivelurgenciaClave)) { _MensajenivelurgenciaClave = value; OnPropertyChanged(); } } }

        private string? _MensajenivelurgenciaNombre;
        [XmlAttribute]
        public string? MensajenivelurgenciaNombre { get => _MensajenivelurgenciaNombre; set { if (RaiseAcceptPendingChange(value, _MensajenivelurgenciaNombre)) { _MensajenivelurgenciaNombre = value; OnPropertyChanged(); } } }

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
    public class WFMensajeEnvioWF_AreaBindingModel : Validatable
    {

        public WFMensajeEnvioWF_AreaBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private int? _Enviar;
        [XmlAttribute]
        public int? Enviar { get => _Enviar; set { if (RaiseAcceptPendingChange(value, _Enviar)) { _Enviar = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

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
    public class WFMensajeEnvioWF_DatosadjuntosBindingModel : Validatable
    {

        public WFMensajeEnvioWF_DatosadjuntosBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private string? _Ruta;
        [XmlAttribute]
        public string? Ruta { get => _Ruta; set { if (RaiseAcceptPendingChange(value, _Ruta)) { _Ruta = value; OnPropertyChanged(); } } }

        private string? _Dgeliminar;
        [XmlAttribute]
        public string? Dgeliminar { get => _Dgeliminar; set { if (RaiseAcceptPendingChange(value, _Dgeliminar)) { _Dgeliminar = value; OnPropertyChanged(); } } }

        private string? _Nombreftp;
        [XmlAttribute]
        public string? Nombreftp { get => _Nombreftp; set { if (RaiseAcceptPendingChange(value, _Nombreftp)) { _Nombreftp = value; OnPropertyChanged(); } } }

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
    public class WFMensajeEnvioWF_SucursalBindingModel : Validatable
    {

        public WFMensajeEnvioWF_SucursalBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private int? _Enviar;
        [XmlAttribute]
        public int? Enviar { get => _Enviar; set { if (RaiseAcceptPendingChange(value, _Enviar)) { _Enviar = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

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

