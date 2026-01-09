
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
    public class V_inventario_movto_getInfoWFBindingModel : Validatable
    {

        public V_inventario_movto_getInfoWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private string? _Productonombre;
        [XmlAttribute]
        public string? Productonombre { get => _Productonombre; set { if (RaiseAcceptPendingChange(value, _Productonombre)) { _Productonombre = value; OnPropertyChanged(); } } }

        private string? _Productodescripcion;
        [XmlAttribute]
        public string? Productodescripcion { get => _Productodescripcion; set { if (RaiseAcceptPendingChange(value, _Productodescripcion)) { _Productodescripcion = value; OnPropertyChanged(); } } }

        private string? _Productolote;
        [XmlAttribute]
        public string? Productolote { get => _Productolote; set { if (RaiseAcceptPendingChange(value, _Productolote)) { _Productolote = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadteorica;
        [XmlAttribute]
        public decimal? Cantidadteorica { get => _Cantidadteorica; set { if (RaiseAcceptPendingChange(value, _Cantidadteorica)) { _Cantidadteorica = value; OnPropertyChanged(); } } }

        private decimal? _Cantidadfisica;
        [XmlAttribute]
        public decimal? Cantidadfisica { get => _Cantidadfisica; set { if (RaiseAcceptPendingChange(value, _Cantidadfisica)) { _Cantidadfisica = value; OnPropertyChanged(); } } }

        private decimal? _Cantidaddiferencia;
        [XmlAttribute]
        public decimal? Cantidaddiferencia { get => _Cantidaddiferencia; set { if (RaiseAcceptPendingChange(value, _Cantidaddiferencia)) { _Cantidaddiferencia = value; OnPropertyChanged(); } } }

        private decimal? _Apartados;
        [XmlAttribute]
        public decimal? Apartados { get => _Apartados; set { if (RaiseAcceptPendingChange(value, _Apartados)) { _Apartados = value; OnPropertyChanged(); } } }

        private decimal? _Pzacaja;
        [XmlAttribute]
        public decimal? Pzacaja { get => _Pzacaja; set { if (RaiseAcceptPendingChange(value, _Pzacaja)) { _Pzacaja = value; OnPropertyChanged(); } } }

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


        public static V_inventario_movto_getInfoWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_V_inventario_movto_getInfoWFBindingModel = new V_inventario_movto_getInfoWFBindingModel();

        	buffer_V_inventario_movto_getInfoWFBindingModel._Productonombre = obj.Productonombre;

        	buffer_V_inventario_movto_getInfoWFBindingModel._Productodescripcion = obj.Productodescripcion;

        	buffer_V_inventario_movto_getInfoWFBindingModel._Productolote = obj.Productolote;

        	buffer_V_inventario_movto_getInfoWFBindingModel._Cantidadteorica = obj.Cantidadteorica;

        	buffer_V_inventario_movto_getInfoWFBindingModel._Cantidadfisica = obj.Cantidadfisica;

        	buffer_V_inventario_movto_getInfoWFBindingModel._Cantidaddiferencia = obj.Cantidaddiferencia;

        	buffer_V_inventario_movto_getInfoWFBindingModel._Apartados = obj.Apartados;

        	buffer_V_inventario_movto_getInfoWFBindingModel._Pzacaja = obj.Pzacaja;

            return buffer_V_inventario_movto_getInfoWFBindingModel;
        }


    }

    public class V_inventario_movto_getInfoParamWFBindingModel : Validatable
    {

        public V_inventario_movto_getInfoParamWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _EmpresaId;
        [XmlAttribute]
        public long? EmpresaId { get => _EmpresaId; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute]
        public long? SucursalId { get => _SucursalId; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value; OnPropertyChanged(); } } }

        private long? _Productoid;
        [XmlAttribute]
        public long? Productoid { get => _Productoid; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value; OnPropertyChanged(); } } }

        private string? _Lote;
        [XmlAttribute]
        public string? Lote { get => _Lote; set { if (RaiseAcceptPendingChange(value, _Lote)) { _Lote = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechavence;
        [XmlAttribute]
        public DateTimeOffset? Fechavence { get => _Fechavence; set { if (RaiseAcceptPendingChange(value, _Fechavence)) { _Fechavence = value; OnPropertyChanged(); } } }

        private long? _Doctoid;
        [XmlAttribute]
        public long? Doctoid { get => _Doctoid; set { if (RaiseAcceptPendingChange(value, _Doctoid)) { _Doctoid = value; OnPropertyChanged(); } } }

        private long? _Almacenid;
        [XmlAttribute]
        public long? Almacenid { get => _Almacenid; set { if (RaiseAcceptPendingChange(value, _Almacenid)) { _Almacenid = value; OnPropertyChanged(); } } }

        private bool _Kitdesglosado;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public bool Kitdesglosado { get => _Kitdesglosado; set { if (RaiseAcceptPendingChange(value, _Kitdesglosado)) { _Kitdesglosado = value; OnPropertyChanged(); } } }

        private bool _Mododetalle;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public bool Mododetalle { get => _Mododetalle; set { if (RaiseAcceptPendingChange(value, _Mododetalle)) { _Mododetalle = value; OnPropertyChanged(); } } }

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


        public static V_inventario_movto_getInfoParamWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_V_inventario_movto_getInfoPWFBindingModel = new V_inventario_movto_getInfoParamWFBindingModel();

        	buffer_V_inventario_movto_getInfoPWFBindingModel._EmpresaId = obj.EmpresaId;

        	buffer_V_inventario_movto_getInfoPWFBindingModel._SucursalId = obj.SucursalId;

        	buffer_V_inventario_movto_getInfoPWFBindingModel._Productoid = obj.Productoid;

        	buffer_V_inventario_movto_getInfoPWFBindingModel._Lote = obj.Lote;

        	buffer_V_inventario_movto_getInfoPWFBindingModel._Fechavence = obj.Fechavence;

        	buffer_V_inventario_movto_getInfoPWFBindingModel._Doctoid = obj.Doctoid;

        	buffer_V_inventario_movto_getInfoPWFBindingModel._Almacenid = obj.Almacenid;

        	buffer_V_inventario_movto_getInfoPWFBindingModel._Kitdesglosado = obj.Kitdesglosado;

        	buffer_V_inventario_movto_getInfoPWFBindingModel._Mododetalle = obj.Mododetalle;

            return buffer_V_inventario_movto_getInfoPWFBindingModel;
        }


    }

    
     
}

