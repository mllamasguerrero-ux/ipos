
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
    public class Tmp_suma_docto_porconsolidaWFBindingModel : Validatable
    {

        public Tmp_suma_docto_porconsolidaWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _EmpresaId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? EmpresaId { get => _EmpresaId ?? 0; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value ?? 0; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? SucursalId { get => _SucursalId ?? 0; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value ?? 0; OnPropertyChanged(); } } }

        private int? _Cuenta;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public int? Cuenta { get => _Cuenta ?? 0; set { if (RaiseAcceptPendingChange(value, _Cuenta)) { _Cuenta = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Importe;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Importe { get => _Importe ?? 0; set { if (RaiseAcceptPendingChange(value, _Importe)) { _Importe = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Descuento;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Descuento { get => _Descuento ?? 0; set { if (RaiseAcceptPendingChange(value, _Descuento)) { _Descuento = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Subtotal;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Subtotal { get => _Subtotal ?? 0; set { if (RaiseAcceptPendingChange(value, _Subtotal)) { _Subtotal = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Iva;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Iva { get => _Iva ?? 0; set { if (RaiseAcceptPendingChange(value, _Iva)) { _Iva = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Ieps;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Ieps { get => _Ieps ?? 0; set { if (RaiseAcceptPendingChange(value, _Ieps)) { _Ieps = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Total;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Total { get => _Total ?? 0; set { if (RaiseAcceptPendingChange(value, _Total)) { _Total = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Ivaretenido;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Ivaretenido { get => _Ivaretenido ?? 0; set { if (RaiseAcceptPendingChange(value, _Ivaretenido)) { _Ivaretenido = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Isrretenido;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Isrretenido { get => _Isrretenido ?? 0; set { if (RaiseAcceptPendingChange(value, _Isrretenido)) { _Isrretenido = value ?? 0; OnPropertyChanged(); } } }

        private decimal? _Saldo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Saldo { get => _Saldo ?? 0; set { if (RaiseAcceptPendingChange(value, _Saldo)) { _Saldo = value ?? 0; OnPropertyChanged(); } } }


        public decimal? Impuesto { get { return (_Iva ?? 0m) + (_Ieps ?? 0m); } }

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


        public static Tmp_suma_docto_porconsolidaWFBindingModel CreateFromAnonymous(Tmp_suma_docto_porconsolidar obj)
        {
            var buffer_Tmp_suma_docto_porconsolidaWFBindingModel = new Tmp_suma_docto_porconsolidaWFBindingModel();

            buffer_Tmp_suma_docto_porconsolidaWFBindingModel._EmpresaId = obj.EmpresaId;

            buffer_Tmp_suma_docto_porconsolidaWFBindingModel._SucursalId = obj.SucursalId;

            buffer_Tmp_suma_docto_porconsolidaWFBindingModel._Cuenta = obj.Cuenta;

            buffer_Tmp_suma_docto_porconsolidaWFBindingModel._Importe = obj.Importe;

            buffer_Tmp_suma_docto_porconsolidaWFBindingModel._Descuento = obj.Descuento;

            buffer_Tmp_suma_docto_porconsolidaWFBindingModel._Subtotal = obj.Subtotal;

            buffer_Tmp_suma_docto_porconsolidaWFBindingModel._Iva = obj.Iva;

            buffer_Tmp_suma_docto_porconsolidaWFBindingModel._Ieps = obj.Ieps;

            buffer_Tmp_suma_docto_porconsolidaWFBindingModel._Total = obj.Total;

            buffer_Tmp_suma_docto_porconsolidaWFBindingModel._Ivaretenido = obj.Ivaretenido;

            buffer_Tmp_suma_docto_porconsolidaWFBindingModel._Isrretenido = obj.Isrretenido;

            buffer_Tmp_suma_docto_porconsolidaWFBindingModel._Saldo = obj.Saldo;

            return buffer_Tmp_suma_docto_porconsolidaWFBindingModel;
        }


    }

    public class Tmp_info_porconsolidar
    {

        public List<Tmp_docto_porconsolidarWFBindingModel>? DoctosPorConsolidar { get; set; }
        //public List<Tmp_dia_monto_porconsolidarWFBindingModel>? DiasMontosPorConsolidar { get; set; }
        public List<Tmp_suma_docto_porconsolidaWFBindingModel>? SumasDoctosPorConsolidar { get; set; }


        public Tmp_info_porconsolidar(long empresaId, long sucursalId,
                                        BoolCN aplicaMontoMaximo, decimal montoMaximo,
                                        List<Tmp_docto_porconsolidar>? lstDoctosPorConsolidar)
        {

            DoctosPorConsolidar = new List<Tmp_docto_porconsolidarWFBindingModel>();
            //DiasMontosPorConsolidar = new List<Tmp_dia_monto_porconsolidarWFBindingModel>();
            SumasDoctosPorConsolidar = new List<Tmp_suma_docto_porconsolidaWFBindingModel>();

            if (lstDoctosPorConsolidar == null)
                return;

            DoctosPorConsolidar = lstDoctosPorConsolidar.Select(l => Tmp_docto_porconsolidarWFBindingModel.CreateFromAnonymous(l)).ToList();


            var sumaDoctoPorConsolidar = new Tmp_suma_docto_porconsolidar(empresaId, sucursalId, lstDoctosPorConsolidar);
            SumasDoctosPorConsolidar.Add(Tmp_suma_docto_porconsolidaWFBindingModel.CreateFromAnonymous(sumaDoctoPorConsolidar));

            //var minFecha = lstDoctosPorConsolidar.Min(l => l.Fecha)!.Value.ToLocalTime().Date;
            //var maxFecha = lstDoctosPorConsolidar.Max(l => l.Fecha)!.Value.ToLocalTime().Date;

            //for (var dt = minFecha; dt <= maxFecha; dt = dt.AddDays(1))
            //{
            //    var diaMontoBuffer = new Tmp_dia_monto_porconsolidar(aplicaMontoMaximo, montoMaximo, dt, lstDoctosPorConsolidar);
            //    DiasMontosPorConsolidar.Add(Tmp_dia_monto_porconsolidarWFBindingModel.CreateFromAnonymous(diaMontoBuffer));
            //}




        }

    }

    
     
}

