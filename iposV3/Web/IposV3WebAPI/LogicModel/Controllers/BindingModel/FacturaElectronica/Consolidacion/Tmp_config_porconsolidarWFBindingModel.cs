
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model;
using MvvmFramework;
using System.Xml.Serialization;
using IposV3.Services;

namespace BindingModels
{
    
    [XmlRoot]
    public class Tmp_config_porconsolidarWFBindingModel : Validatable
    {

        public Tmp_config_porconsolidarWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _EmpresaId;
        [XmlAttribute]
        public long? EmpresaId { get => _EmpresaId; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute]
        public long? SucursalId { get => _SucursalId; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _FechaIni;
        [XmlAttribute]
        public DateTimeOffset? FechaIni { get => _FechaIni; set { if (RaiseAcceptPendingChange(value, _FechaIni)) { _FechaIni = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _FechaFin;
        [XmlAttribute]
        public DateTimeOffset? FechaFin { get => _FechaFin; set { if (RaiseAcceptPendingChange(value, _FechaFin)) { _FechaFin = value; OnPropertyChanged(); } } }

        private BoolCN? _OmitirVentasFranquicias;
        [XmlAttribute]
        public BoolCN? OmitirVentasFranquicias { get => _OmitirVentasFranquicias; set { if (RaiseAcceptPendingChange(value, _OmitirVentasFranquicias)) { _OmitirVentasFranquicias = value; OnPropertyChanged(); } } }

        private BoolCN? _IncluirGastos;
        [XmlAttribute]
        public BoolCN? IncluirGastos { get => _IncluirGastos; set { if (RaiseAcceptPendingChange(value, _IncluirGastos)) { _IncluirGastos = value; OnPropertyChanged(); } } }

        private decimal? _MaximoMonto;
        [XmlAttribute]
        public decimal? MaximoMonto { get => _MaximoMonto; set { if (RaiseAcceptPendingChange(value, _MaximoMonto)) { _MaximoMonto = value; OnPropertyChanged(); } } }

        private BoolCN? _OmitirVales;
        [XmlAttribute]
        public BoolCN? OmitirVales { get => _OmitirVales; set { if (RaiseAcceptPendingChange(value, _OmitirVales)) { _OmitirVales = value; OnPropertyChanged(); } } }

        private BoolCN? _SumaCompletaVentas;
        [XmlAttribute]
        public BoolCN? SumaCompletaVentas { get => _SumaCompletaVentas; set { if (RaiseAcceptPendingChange(value, _SumaCompletaVentas)) { _SumaCompletaVentas = value; OnPropertyChanged(); } } }

        private long? _GrupoUsuarioId;
        [XmlAttribute]
        public long? GrupoUsuarioId { get => _GrupoUsuarioId; set { if (RaiseAcceptPendingChange(value, _GrupoUsuarioId)) { _GrupoUsuarioId = value; OnPropertyChanged(); } } }

        private BoolCN? _OmitirClientesRfc;
        [XmlAttribute]
        public BoolCN? OmitirClientesRfc { get => _OmitirClientesRfc; set { if (RaiseAcceptPendingChange(value, _OmitirClientesRfc)) { _OmitirClientesRfc = value; OnPropertyChanged(); } } }

        private decimal? _MaximoPorcentaje;
        [XmlAttribute]
        public decimal? MaximoPorcentaje { get => _MaximoPorcentaje; set { if (RaiseAcceptPendingChange(value, _MaximoPorcentaje)) { _MaximoPorcentaje = value; OnPropertyChanged(); } } }

        private BoolCN? _OmitirPagoTarjeta;

        [XmlAttribute]
        public BoolCN? OmitirPagoTarjeta { get => _OmitirPagoTarjeta; set { if (RaiseAcceptPendingChange(value, _OmitirPagoTarjeta)) { _OmitirPagoTarjeta = value; OnPropertyChanged(); } } }

        private long? _UsuarioId;
        [XmlAttribute]
        public long? UsuarioId { get => _UsuarioId; set { if (RaiseAcceptPendingChange(value, _UsuarioId)) { _UsuarioId = value; OnPropertyChanged(); } } }


        private BoolCN? _AplicaMontoMaximoPorDia;

        [XmlAttribute]
        public BoolCN? AplicaMontoMaximoPorDia { get => _AplicaMontoMaximoPorDia; set { if (RaiseAcceptPendingChange(value, _AplicaMontoMaximoPorDia)) { _AplicaMontoMaximoPorDia = value; OnPropertyChanged(); } } }


        private decimal? _MontoMaximoPorDia;
        [XmlAttribute]
        public decimal? MontoMaximoPorDia { get => _MontoMaximoPorDia; set { if (RaiseAcceptPendingChange(value, _MontoMaximoPorDia)) { _MontoMaximoPorDia = value; OnPropertyChanged(); } } }




        private int? _Anio;
        [XmlAttribute]
        public int? Anio { get => _Anio; set { if (RaiseAcceptPendingChange(value, _Anio)) { _Anio = value; OnPropertyChanged(); } } }

        private long? _Mes;
        [XmlAttribute]
        public long? Mes { get => _Mes; set { if (RaiseAcceptPendingChange(value, _Mes)) { _Mes = value; OnPropertyChanged(); } } }


        private long _Tipoagrupacion = 0;
        public long Tipoagrupacion
        {
            get => _Tipoagrupacion;
            set { if (RaiseAcceptPendingChange(value, _Tipoagrupacion)) { _Tipoagrupacion = value; OnPropertyChanged(); } }
        }



        private BoolCN? _Porgrupousuario;

        [XmlAttribute]
        public BoolCN? Porgrupousuario { get => _Porgrupousuario; set { if (RaiseAcceptPendingChange(value, _Porgrupousuario)) { _Porgrupousuario = value; OnPropertyChanged(); } } }





        private BoolCN? _AplicaMontoMaximo;

        [XmlAttribute]
        public BoolCN? AplicaMontoMaximo { get => _AplicaMontoMaximo; set { if (RaiseAcceptPendingChange(value, _AplicaMontoMaximo)) { _AplicaMontoMaximo = value; OnPropertyChanged(); } } }



        private BoolCN? _AplicaMontoMaximoPorcentaje;

        [XmlAttribute]
        public BoolCN? AplicaMontoMaximoPorcentaje { get => _AplicaMontoMaximoPorcentaje; set { if (RaiseAcceptPendingChange(value, _AplicaMontoMaximoPorcentaje)) { _AplicaMontoMaximoPorcentaje = value; OnPropertyChanged(); } } }


        private decimal? _MontoMaximoPorcentaje;
        [XmlAttribute]
        public decimal? MontoMaximoPorcentaje { get => _MontoMaximoPorcentaje; set { if (RaiseAcceptPendingChange(value, _MontoMaximoPorcentaje)) { _MontoMaximoPorcentaje = value; OnPropertyChanged(); } } }



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


        public static Tmp_config_porconsolidarWFBindingModel CreateFromAnonymous( Tmp_config_porconsolidar obj)
        {
            var buffer_Tmp_config_porconsolidarWFBindingModel = new Tmp_config_porconsolidarWFBindingModel();

        	buffer_Tmp_config_porconsolidarWFBindingModel._EmpresaId = obj.EmpresaId;

        	buffer_Tmp_config_porconsolidarWFBindingModel._SucursalId = obj.SucursalId;

        	buffer_Tmp_config_porconsolidarWFBindingModel._FechaIni = obj.FechaIni;

        	buffer_Tmp_config_porconsolidarWFBindingModel._FechaFin = obj.FechaFin;

        	buffer_Tmp_config_porconsolidarWFBindingModel._OmitirVentasFranquicias = obj.OmitirVentasFranquicias;

        	buffer_Tmp_config_porconsolidarWFBindingModel._IncluirGastos = obj.IncluirGastos;

        	buffer_Tmp_config_porconsolidarWFBindingModel._MaximoMonto = obj.MaximoMonto;

        	buffer_Tmp_config_porconsolidarWFBindingModel._OmitirVales = obj.OmitirVales;

        	buffer_Tmp_config_porconsolidarWFBindingModel._SumaCompletaVentas = obj.SumaCompletaVentas;

        	buffer_Tmp_config_porconsolidarWFBindingModel._GrupoUsuarioId = obj.GrupoUsuarioId;

        	buffer_Tmp_config_porconsolidarWFBindingModel._OmitirClientesRfc = obj.OmitirClientesRfc;

        	buffer_Tmp_config_porconsolidarWFBindingModel._MaximoPorcentaje = obj.MaximoPorcentaje;

        	buffer_Tmp_config_porconsolidarWFBindingModel._OmitirPagoTarjeta = obj.OmitirPagoTarjeta;

        	buffer_Tmp_config_porconsolidarWFBindingModel._UsuarioId = obj.UsuarioId;

            return buffer_Tmp_config_porconsolidarWFBindingModel;
        }


    }

    
     
}

