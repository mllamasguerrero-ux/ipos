
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
    public class WFPromocionEditWFBindingModel : Validatable
    {

        public WFPromocionEditWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private decimal? _Cantidad2;
        [XmlAttribute]
        public decimal? Cantidad2 { get => _Cantidad2; set { if (RaiseAcceptPendingChange(value, _Cantidad2)) { _Cantidad2 = value; OnPropertyChanged(); } } }

        private decimal? _Importe;
        [XmlAttribute]
        public decimal? Importe { get => _Importe; set { if (RaiseAcceptPendingChange(value, _Importe)) { _Importe = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadllevate;
        [XmlAttribute]
        public decimal? Cantidadllevate { get => _Cantidadllevate; set { if (RaiseAcceptPendingChange(value, _Cantidadllevate)) { _Cantidadllevate = value; OnPropertyChanged(); } } }

        private decimal? _Cantidad;
        [XmlAttribute]
        public decimal? Cantidad { get => _Cantidad; set { if (RaiseAcceptPendingChange(value, _Cantidad)) { _Cantidad = value; OnPropertyChanged(); } } }

        private decimal? _Montominimonumeric;
        [XmlAttribute]
        public decimal? Montominimonumeric { get => _Montominimonumeric; set { if (RaiseAcceptPendingChange(value, _Montominimonumeric)) { _Montominimonumeric = value; OnPropertyChanged(); } } }

        private decimal? _Montomindesclinea;
        [XmlAttribute]
        public decimal? Montomindesclinea { get => _Montomindesclinea; set { if (RaiseAcceptPendingChange(value, _Montomindesclinea)) { _Montomindesclinea = value; OnPropertyChanged(); } } }

        private decimal? _Descmontomin;
        [XmlAttribute]
        public decimal? Descmontomin { get => _Descmontomin; set { if (RaiseAcceptPendingChange(value, _Descmontomin)) { _Descmontomin = value; OnPropertyChanged(); } } }

        private decimal? _Porcentajedescuento;
        [XmlAttribute]
        public decimal? Porcentajedescuento { get => _Porcentajedescuento; set { if (RaiseAcceptPendingChange(value, _Porcentajedescuento)) { _Porcentajedescuento = value; OnPropertyChanged(); } } }

        private BoolCN? _Enmonedero;
        [XmlAttribute]
        public BoolCN? Enmonedero { get => _Enmonedero; set { if (RaiseAcceptPendingChange(value, _Enmonedero)) { _Enmonedero = value; OnPropertyChanged(); } } }

        private string? _Leyenda;
        [XmlAttribute]
        public string? Leyenda { get => _Leyenda; set { if (RaiseAcceptPendingChange(value, _Leyenda)) { _Leyenda = value; OnPropertyChanged(); } } }

        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private decimal? _Importe6;
        [XmlAttribute]
        public decimal? Importe6 { get => _Importe6; set { if (RaiseAcceptPendingChange(value, _Importe6)) { _Importe6 = value; OnPropertyChanged(); } } }

        private decimal? _Cantidad6;
        [XmlAttribute]
        public decimal? Cantidad6 { get => _Cantidad6; set { if (RaiseAcceptPendingChange(value, _Cantidad6)) { _Cantidad6 = value; OnPropertyChanged(); } } }

        private BoolCN? _Mostrardatoscliente;
        [XmlAttribute]
        public BoolCN? Mostrardatoscliente { get => _Mostrardatoscliente; set { if (RaiseAcceptPendingChange(value, _Mostrardatoscliente)) { _Mostrardatoscliente = value; OnPropertyChanged(); } } }

        private decimal? _Porcentajeaumentobodegazo;
        [XmlAttribute]
        public decimal? Porcentajeaumentobodegazo { get => _Porcentajeaumentobodegazo; set { if (RaiseAcceptPendingChange(value, _Porcentajeaumentobodegazo)) { _Porcentajeaumentobodegazo = value; OnPropertyChanged(); } } }

        private BoolCN? _Enmonederobodegazo;
        [XmlAttribute]
        public BoolCN? Enmonederobodegazo { get => _Enmonederobodegazo; set { if (RaiseAcceptPendingChange(value, _Enmonederobodegazo)) { _Enmonederobodegazo = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechafin;
        [XmlAttribute]
        public DateTimeOffset? Fechafin { get => _Fechafin; set { if (RaiseAcceptPendingChange(value, _Fechafin)) { _Fechafin = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechainicio;
        [XmlAttribute]
        public DateTimeOffset? Fechainicio { get => _Fechainicio; set { if (RaiseAcceptPendingChange(value, _Fechainicio)) { _Fechainicio = value; OnPropertyChanged(); } } }

        private BoolCN? _Lunes;
        [XmlAttribute]
        public BoolCN? Lunes { get => _Lunes; set { if (RaiseAcceptPendingChange(value, _Lunes)) { _Lunes = value; OnPropertyChanged(); } } }

        private BoolCN? _Martes;
        [XmlAttribute]
        public BoolCN? Martes { get => _Martes; set { if (RaiseAcceptPendingChange(value, _Martes)) { _Martes = value; OnPropertyChanged(); } } }

        private BoolCN? _Viernes;
        [XmlAttribute]
        public BoolCN? Viernes { get => _Viernes; set { if (RaiseAcceptPendingChange(value, _Viernes)) { _Viernes = value; OnPropertyChanged(); } } }

        private BoolCN? _Sabado;
        [XmlAttribute]
        public BoolCN? Sabado { get => _Sabado; set { if (RaiseAcceptPendingChange(value, _Sabado)) { _Sabado = value; OnPropertyChanged(); } } }

        private BoolCN? _Domingo;
        [XmlAttribute]
        public BoolCN? Domingo { get => _Domingo; set { if (RaiseAcceptPendingChange(value, _Domingo)) { _Domingo = value; OnPropertyChanged(); } } }

        private BoolCN? _Miercoles;
        [XmlAttribute]
        public BoolCN? Miercoles { get => _Miercoles; set { if (RaiseAcceptPendingChange(value, _Miercoles)) { _Miercoles = value; OnPropertyChanged(); } } }

        private BoolCN? _Jueves;
        [XmlAttribute]
        public BoolCN? Jueves { get => _Jueves; set { if (RaiseAcceptPendingChange(value, _Jueves)) { _Jueves = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private BoolCN? _Activo;
        [XmlAttribute]
        public BoolCN? Activo { get => _Activo; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value; OnPropertyChanged(); } } }

        private long? _Lineaid;
        [XmlAttribute]
        public long? Lineaid { get => _Lineaid; set { if (RaiseAcceptPendingChange(value, _Lineaid)) { _Lineaid = value; OnPropertyChanged(); } } }

        private string? _LineaidClave;
        [XmlAttribute]
        public string? LineaidClave { get => _LineaidClave; set { if (RaiseAcceptPendingChange(value, _LineaidClave)) { _LineaidClave = value; OnPropertyChanged(); } } }

        private string? _LineaidNombre;
        [XmlAttribute]
        public string? LineaidNombre { get => _LineaidNombre; set { if (RaiseAcceptPendingChange(value, _LineaidNombre)) { _LineaidNombre = value; OnPropertyChanged(); } } }

        private string? _Productoid;
        [XmlAttribute]
        public string? Productoid { get => _Productoid; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value; OnPropertyChanged(); } } }

        private BoolCN? _Cbtodassucursales;
        [XmlAttribute]
        public BoolCN? Cbtodassucursales { get => _Cbtodassucursales; set { if (RaiseAcceptPendingChange(value, _Cbtodassucursales)) { _Cbtodassucursales = value; OnPropertyChanged(); } } }

        private string? _Imagen;
        [XmlAttribute]
        public string? Imagen { get => _Imagen; set { if (RaiseAcceptPendingChange(value, _Imagen)) { _Imagen = value; OnPropertyChanged(); } } }

        private string? _Nuevaimagen;
        [XmlAttribute]
        public string? Nuevaimagen { get => _Nuevaimagen; set { if (RaiseAcceptPendingChange(value, _Nuevaimagen)) { _Nuevaimagen = value; OnPropertyChanged(); } } }

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
    public class WFPromocionEditWF_SucursalBindingModel : Validatable
    {

        public WFPromocionEditWF_SucursalBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Clave;
        [XmlAttribute]
        public string? Clave { get => _Clave; set { if (RaiseAcceptPendingChange(value, _Clave)) { _Clave = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private string? _Activo;
        [XmlAttribute]
        public string? Activo { get => _Activo; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value; OnPropertyChanged(); } } }

        private string? _Nombre;
        [XmlAttribute]
        public string? Nombre { get => _Nombre; set { if (RaiseAcceptPendingChange(value, _Nombre)) { _Nombre = value; OnPropertyChanged(); } } }

        private string? _Descripcion;
        [XmlAttribute]
        public string? Descripcion { get => _Descripcion; set { if (RaiseAcceptPendingChange(value, _Descripcion)) { _Descripcion = value; OnPropertyChanged(); } } }

        private short? _Seleccionada;
        [XmlAttribute]
        public short? Seleccionada { get => _Seleccionada; set { if (RaiseAcceptPendingChange(value, _Seleccionada)) { _Seleccionada = value; OnPropertyChanged(); } } }

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

