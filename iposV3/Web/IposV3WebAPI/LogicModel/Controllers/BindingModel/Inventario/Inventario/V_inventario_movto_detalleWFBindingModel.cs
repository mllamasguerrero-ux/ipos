
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
    public class V_inventario_movto_detalleWFBindingModel : Validatable
    {

        public V_inventario_movto_detalleWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _EmpresaId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? EmpresaId { get => _EmpresaId?? 0; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value?? 0; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? SucursalId { get => _SucursalId?? 0; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value?? 0; OnPropertyChanged(); } } }

        private string? _Sucursalclave;
        [XmlAttribute]
        public string? Sucursalclave { get => _Sucursalclave; set { if (RaiseAcceptPendingChange(value, _Sucursalclave)) { _Sucursalclave = value; OnPropertyChanged(); } } }

        private string? _Sucursalnombre;
        [XmlAttribute]
        public string? Sucursalnombre { get => _Sucursalnombre; set { if (RaiseAcceptPendingChange(value, _Sucursalnombre)) { _Sucursalnombre = value; OnPropertyChanged(); } } }

        private long? _ProductoId;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? ProductoId { get => _ProductoId?? 0; set { if (RaiseAcceptPendingChange(value, _ProductoId)) { _ProductoId = value?? 0; OnPropertyChanged(); } } }

        private string? _Productoclave;
        [XmlAttribute]
        public string? Productoclave { get => _Productoclave; set { if (RaiseAcceptPendingChange(value, _Productoclave)) { _Productoclave = value; OnPropertyChanged(); } } }

        private string? _Productonombre;
        [XmlAttribute]
        public string? Productonombre { get => _Productonombre; set { if (RaiseAcceptPendingChange(value, _Productonombre)) { _Productonombre = value; OnPropertyChanged(); } } }

        private string? _Productodescripcion;
        [XmlAttribute]
        public string? Productodescripcion { get => _Productodescripcion; set { if (RaiseAcceptPendingChange(value, _Productodescripcion)) { _Productodescripcion = value; OnPropertyChanged(); } } }

        private string? _Productotexto1;
        [XmlAttribute]
        public string? Productotexto1 { get => _Productotexto1; set { if (RaiseAcceptPendingChange(value, _Productotexto1)) { _Productotexto1 = value; OnPropertyChanged(); } } }

        private string? _Productotexto2;
        [XmlAttribute]
        public string? Productotexto2 { get => _Productotexto2; set { if (RaiseAcceptPendingChange(value, _Productotexto2)) { _Productotexto2 = value; OnPropertyChanged(); } } }

        private string? _Productotexto3;
        [XmlAttribute]
        public string? Productotexto3 { get => _Productotexto3; set { if (RaiseAcceptPendingChange(value, _Productotexto3)) { _Productotexto3 = value; OnPropertyChanged(); } } }

        private string? _Productotexto4;
        [XmlAttribute]
        public string? Productotexto4 { get => _Productotexto4; set { if (RaiseAcceptPendingChange(value, _Productotexto4)) { _Productotexto4 = value; OnPropertyChanged(); } } }

        private string? _Productotexto5;
        [XmlAttribute]
        public string? Productotexto5 { get => _Productotexto5; set { if (RaiseAcceptPendingChange(value, _Productotexto5)) { _Productotexto5 = value; OnPropertyChanged(); } } }

        private string? _Productotexto6;
        [XmlAttribute]
        public string? Productotexto6 { get => _Productotexto6; set { if (RaiseAcceptPendingChange(value, _Productotexto6)) { _Productotexto6 = value; OnPropertyChanged(); } } }

        private decimal? _Productonumero1;
        [XmlAttribute]
        public decimal? Productonumero1 { get => _Productonumero1; set { if (RaiseAcceptPendingChange(value, _Productonumero1)) { _Productonumero1 = value; OnPropertyChanged(); } } }

        private decimal? _Productonumero2;
        [XmlAttribute]
        public decimal? Productonumero2 { get => _Productonumero2; set { if (RaiseAcceptPendingChange(value, _Productonumero2)) { _Productonumero2 = value; OnPropertyChanged(); } } }

        private decimal? _Productonumero3;
        [XmlAttribute]
        public decimal? Productonumero3 { get => _Productonumero3; set { if (RaiseAcceptPendingChange(value, _Productonumero3)) { _Productonumero3 = value; OnPropertyChanged(); } } }

        private decimal? _Productonumero4;
        [XmlAttribute]
        public decimal? Productonumero4 { get => _Productonumero4; set { if (RaiseAcceptPendingChange(value, _Productonumero4)) { _Productonumero4 = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha1;
        [XmlAttribute]
        public DateTimeOffset? Fecha1 { get => _Fecha1; set { if (RaiseAcceptPendingChange(value, _Fecha1)) { _Fecha1 = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fecha2;
        [XmlAttribute]
        public DateTimeOffset? Fecha2 { get => _Fecha2; set { if (RaiseAcceptPendingChange(value, _Fecha2)) { _Fecha2 = value; OnPropertyChanged(); } } }

        private decimal? _Pzacaja;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Pzacaja { get => _Pzacaja?? 0; set { if (RaiseAcceptPendingChange(value, _Pzacaja)) { _Pzacaja = value?? 0; OnPropertyChanged(); } } }

        private long? _Almacenid;
        [XmlAttribute]
        public long? Almacenid { get => _Almacenid; set { if (RaiseAcceptPendingChange(value, _Almacenid)) { _Almacenid = value; OnPropertyChanged(); } } }

        private string? _Almacenclave;
        [XmlAttribute]
        public string? Almacenclave { get => _Almacenclave; set { if (RaiseAcceptPendingChange(value, _Almacenclave)) { _Almacenclave = value; OnPropertyChanged(); } } }

        private string? _Almacennombre;
        [XmlAttribute]
        public string? Almacennombre { get => _Almacennombre; set { if (RaiseAcceptPendingChange(value, _Almacennombre)) { _Almacennombre = value; OnPropertyChanged(); } } }

        private string? _Lote;
        [XmlAttribute]
        public string? Lote { get => _Lote; set { if (RaiseAcceptPendingChange(value, _Lote)) { _Lote = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechavence;
        [XmlAttribute]
        public DateTimeOffset? Fechavence { get => _Fechavence; set { if (RaiseAcceptPendingChange(value, _Fechavence)) { _Fechavence = value; OnPropertyChanged(); } } }

        private long? _Loteimportado;
        [XmlAttribute]
        public long? Loteimportado { get => _Loteimportado; set { if (RaiseAcceptPendingChange(value, _Loteimportado)) { _Loteimportado = value; OnPropertyChanged(); } } }

        private decimal? _CantidadTeorica;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? CantidadTeorica { get => _CantidadTeorica?? 0; set { if (RaiseAcceptPendingChange(value, _CantidadTeorica)) { _CantidadTeorica = value?? 0; OnPropertyChanged(); } } }

        private decimal? _CantidadSurtida;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? CantidadSurtida { get => _CantidadSurtida?? 0; set { if (RaiseAcceptPendingChange(value, _CantidadSurtida)) { _CantidadSurtida = value?? 0; OnPropertyChanged(); } } }

        private long? _Movtoid;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? Movtoid { get => _Movtoid?? 0; set { if (RaiseAcceptPendingChange(value, _Movtoid)) { _Movtoid = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Cajas;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Cajas { get => _Cajas?? 0; set { if (RaiseAcceptPendingChange(value, _Cajas)) { _Cajas = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Piezas;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Piezas { get => _Piezas?? 0; set { if (RaiseAcceptPendingChange(value, _Piezas)) { _Piezas = value?? 0; OnPropertyChanged(); } } }

        private decimal? _CajasTeorica;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? CajasTeorica { get => _CajasTeorica?? 0; set { if (RaiseAcceptPendingChange(value, _CajasTeorica)) { _CajasTeorica = value?? 0; OnPropertyChanged(); } } }

        private decimal? _PiezasTeorica;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? PiezasTeorica { get => _PiezasTeorica?? 0; set { if (RaiseAcceptPendingChange(value, _PiezasTeorica)) { _PiezasTeorica = value?? 0; OnPropertyChanged(); } } }



        private decimal? _CantidadDiferencia;
        public decimal? CantidadDiferencia { get => _CantidadDiferencia ?? 0; set { if (RaiseAcceptPendingChange(value, _CantidadDiferencia)) { _CantidadDiferencia = value ?? 0; OnPropertyChanged(); } } }




        private string? _Localidad;
        [XmlAttribute]
        public string? Localidad { get => _Localidad; set { if (RaiseAcceptPendingChange(value, _Localidad)) { _Localidad = value; OnPropertyChanged(); } } }


        private long? _Anaquelid;
        [XmlAttribute]
        public long? Anaquelid { get => _Anaquelid; set { if (RaiseAcceptPendingChange(value, _Anaquelid)) { _Anaquelid = value; OnPropertyChanged(); } } }


        private string? _Anaquelclave;
        [XmlAttribute]
        public string? Anaquelclave { get => _Anaquelclave; set { if (RaiseAcceptPendingChange(value, _Anaquelclave)) { _Anaquelclave = value; OnPropertyChanged(); } } }

        private string? _Anaquelnombre;
        [XmlAttribute]
        public string? Anaquelnombre { get => _Anaquelnombre; set { if (RaiseAcceptPendingChange(value, _Anaquelnombre)) { _Anaquelnombre = value; OnPropertyChanged(); } } }


        private decimal? _AcumuladoCantidadSurtida;
        public decimal? AcumuladoCantidadSurtida { get => _AcumuladoCantidadSurtida ?? 0; set { if (RaiseAcceptPendingChange(value, _AcumuladoCantidadSurtida)) { _AcumuladoCantidadSurtida = value ?? 0; OnPropertyChanged(); } } }


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


        public static V_inventario_movto_detalleWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_V_inventario_movto_detalleWFBindingModel = new V_inventario_movto_detalleWFBindingModel();

        	buffer_V_inventario_movto_detalleWFBindingModel._EmpresaId = obj.EmpresaId;

        	buffer_V_inventario_movto_detalleWFBindingModel._SucursalId = obj.SucursalId;

        	buffer_V_inventario_movto_detalleWFBindingModel._Sucursalclave = obj.Sucursalclave;

        	buffer_V_inventario_movto_detalleWFBindingModel._Sucursalnombre = obj.Sucursalnombre;

        	buffer_V_inventario_movto_detalleWFBindingModel._ProductoId = obj.ProductoId;

        	buffer_V_inventario_movto_detalleWFBindingModel._Productoclave = obj.Productoclave;

        	buffer_V_inventario_movto_detalleWFBindingModel._Productonombre = obj.Productonombre;

        	buffer_V_inventario_movto_detalleWFBindingModel._Productodescripcion = obj.Productodescripcion;

        	buffer_V_inventario_movto_detalleWFBindingModel._Productotexto1 = obj.Productotexto1;

        	buffer_V_inventario_movto_detalleWFBindingModel._Productotexto2 = obj.Productotexto2;

        	buffer_V_inventario_movto_detalleWFBindingModel._Productotexto3 = obj.Productotexto3;

        	buffer_V_inventario_movto_detalleWFBindingModel._Productotexto4 = obj.Productotexto4;

        	buffer_V_inventario_movto_detalleWFBindingModel._Productotexto5 = obj.Productotexto5;

        	buffer_V_inventario_movto_detalleWFBindingModel._Productotexto6 = obj.Productotexto6;

        	buffer_V_inventario_movto_detalleWFBindingModel._Productonumero1 = obj.Productonumero1;

        	buffer_V_inventario_movto_detalleWFBindingModel._Productonumero2 = obj.Productonumero2;

        	buffer_V_inventario_movto_detalleWFBindingModel._Productonumero3 = obj.Productonumero3;

        	buffer_V_inventario_movto_detalleWFBindingModel._Productonumero4 = obj.Productonumero4;

        	buffer_V_inventario_movto_detalleWFBindingModel._Fecha1 = obj.Fecha1;

        	buffer_V_inventario_movto_detalleWFBindingModel._Fecha2 = obj.Fecha2;

        	buffer_V_inventario_movto_detalleWFBindingModel._Pzacaja = obj.Pzacaja;

        	buffer_V_inventario_movto_detalleWFBindingModel._Almacenid = obj.Almacenid;

        	buffer_V_inventario_movto_detalleWFBindingModel._Almacenclave = obj.Almacenclave;

        	buffer_V_inventario_movto_detalleWFBindingModel._Almacennombre = obj.Almacennombre;

        	buffer_V_inventario_movto_detalleWFBindingModel._Lote = obj.Lote;

        	buffer_V_inventario_movto_detalleWFBindingModel._Fechavence = obj.Fechavence;

        	buffer_V_inventario_movto_detalleWFBindingModel._Loteimportado = obj.Loteimportado;

        	buffer_V_inventario_movto_detalleWFBindingModel._CantidadTeorica = obj.CantidadTeorica;

        	buffer_V_inventario_movto_detalleWFBindingModel._CantidadSurtida = obj.CantidadSurtida;

            buffer_V_inventario_movto_detalleWFBindingModel._CantidadDiferencia = obj.CantidadDiferencia;

            buffer_V_inventario_movto_detalleWFBindingModel._Movtoid = obj.Movtoid;

        	buffer_V_inventario_movto_detalleWFBindingModel._Cajas = obj.Cajas;

        	buffer_V_inventario_movto_detalleWFBindingModel._Piezas = obj.Piezas;

        	buffer_V_inventario_movto_detalleWFBindingModel._CajasTeorica = obj.CajasTeorica;

        	buffer_V_inventario_movto_detalleWFBindingModel._PiezasTeorica = obj.PiezasTeorica;


            buffer_V_inventario_movto_detalleWFBindingModel._Localidad = obj.Localidad;
            buffer_V_inventario_movto_detalleWFBindingModel._Anaquelid = obj.Anaquelid;
            buffer_V_inventario_movto_detalleWFBindingModel._Anaquelclave = obj.Anaquelclave;
            buffer_V_inventario_movto_detalleWFBindingModel._Anaquelnombre = obj.Anaquelnombre;
            buffer_V_inventario_movto_detalleWFBindingModel._AcumuladoCantidadSurtida = obj.AcumuladoCantidadSurtida;

            return buffer_V_inventario_movto_detalleWFBindingModel;
        }



    }

    public class V_inventario_movto_detalleParamBindingModel : Validatable
    {
        private long? _EmpresaId;
        public long? EmpresaId { get => _EmpresaId ?? 0; set {  _EmpresaId = value ?? 0; OnPropertyChanged();  } }

        private long? _SucursalId;
        public long? SucursalId { get => _SucursalId ?? 0; set { _SucursalId = value ?? 0; OnPropertyChanged();  } }


        private long? _AlmacenId;
        public long? AlmacenId { get => _AlmacenId ?? 0; set {  _AlmacenId = value ?? 0; OnPropertyChanged();  } }

        private long? _DoctoId;
        public long? DoctoId { get => _DoctoId ?? 0; set { _DoctoId = value ?? 0; OnPropertyChanged(); }  }


        private bool _Solodiferencias;
        public bool Solodiferencias { get => _Solodiferencias; set { _Solodiferencias = value ; OnPropertyChanged(); } }

        private bool _Todoslosproductos;
        public bool Todoslosproductos { get => _Todoslosproductos; set { _Todoslosproductos = value ; OnPropertyChanged(); } }

        private bool _KitDesglosado;
        public bool KitDesglosado { get => _KitDesglosado; set { _KitDesglosado = value ; OnPropertyChanged(); } }

    }



}

