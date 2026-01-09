
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
    public class V_inventario_movto_insertWFBindingModel : Validatable
    {

        public V_inventario_movto_insertWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _EmpresaId;
        [XmlAttribute]
        public long? EmpresaId { get => _EmpresaId; set { if (RaiseAcceptPendingChange(value, _EmpresaId)) { _EmpresaId = value; OnPropertyChanged(); } } }

        private long? _SucursalId;
        [XmlAttribute]
        public long? SucursalId { get => _SucursalId; set { if (RaiseAcceptPendingChange(value, _SucursalId)) { _SucursalId = value; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private long? _Doctoid;
        [XmlAttribute]
        public long? Doctoid { get => _Doctoid; set { if (RaiseAcceptPendingChange(value, _Doctoid)) { _Doctoid = value; OnPropertyChanged(); } } }

        private long? _Estatusmovtoid;
        [XmlAttribute]
        public long? Estatusmovtoid { get => _Estatusmovtoid; set { if (RaiseAcceptPendingChange(value, _Estatusmovtoid)) { _Estatusmovtoid = value; OnPropertyChanged(); } } }

        private string? _Lote;
        [XmlAttribute]
        public string? Lote { get => _Lote; set { if (RaiseAcceptPendingChange(value, _Lote)) { _Lote = value; OnPropertyChanged(); } } }

        private string? _Localidad;
        [XmlAttribute]
        public string? Localidad { get => _Localidad; set { if (RaiseAcceptPendingChange(value, _Localidad)) { _Localidad = value; OnPropertyChanged(); } } }

        private long? _Productoid;
        [XmlAttribute]
        public long? Productoid { get => _Productoid; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value; OnPropertyChanged(); } } }

        private string? _Productoclave;
        [XmlAttribute]
        public string? Productoclave { get => _Productoclave; set { if (RaiseAcceptPendingChange(value, _Productoclave)) { _Productoclave = value; OnPropertyChanged(); } } }

        private string? _Productonombre;
        [XmlAttribute]
        public string? Productonombre { get => _Productonombre; set { if (RaiseAcceptPendingChange(value, _Productonombre)) { _Productonombre = value; OnPropertyChanged(); } } }

        private long? _Almacenid;
        [XmlAttribute]
        public long? Almacenid { get => _Almacenid; set { if (RaiseAcceptPendingChange(value, _Almacenid)) { _Almacenid = value; OnPropertyChanged(); } } }

        private string? _Almacenclave;
        [XmlAttribute]
        public string? Almacenclave { get => _Almacenclave; set { if (RaiseAcceptPendingChange(value, _Almacenclave)) { _Almacenclave = value; OnPropertyChanged(); } } }

        private string? _Almacennombre;
        [XmlAttribute]
        public string? Almacennombre { get => _Almacennombre; set { if (RaiseAcceptPendingChange(value, _Almacennombre)) { _Almacennombre = value; OnPropertyChanged(); } } }

        private long? _Anaquelid;
        [XmlAttribute]
        public long? Anaquelid { get => _Anaquelid; set { if (RaiseAcceptPendingChange(value, _Anaquelid)) { _Anaquelid = value; OnPropertyChanged(); } } }

        private string? _Anaquelclave;
        [XmlAttribute]
        public string? Anaquelclave { get => _Anaquelclave; set { if (RaiseAcceptPendingChange(value, _Anaquelclave)) { _Anaquelclave = value; OnPropertyChanged(); } } }

        private string? _Anaquelnombre;
        [XmlAttribute]
        public string? Anaquelnombre { get => _Anaquelnombre; set { if (RaiseAcceptPendingChange(value, _Anaquelnombre)) { _Anaquelnombre = value; OnPropertyChanged(); } } }

        private decimal? _Cantidad;
        [XmlAttribute]
        public decimal? Cantidad { get => _Cantidad; set { if (RaiseAcceptPendingChange(value, _Cantidad)) { _Cantidad = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechavence;
        [XmlAttribute]
        public DateTimeOffset? Fechavence { get => _Fechavence; set { if (RaiseAcceptPendingChange(value, _Fechavence)) { _Fechavence = value; OnPropertyChanged(); } } }

        private long? _Usuarioid;
        [XmlAttribute]
        public long? Usuarioid { get => _Usuarioid; set { if (RaiseAcceptPendingChange(value, _Usuarioid)) { _Usuarioid = value; OnPropertyChanged(); } } }

        private long? _Productolocationsid;
        [XmlAttribute]
        public long? Productolocationsid { get => _Productolocationsid; set { if (RaiseAcceptPendingChange(value, _Productolocationsid)) { _Productolocationsid = value; OnPropertyChanged(); } } }

        private string? _DescripcionProductoMovto;
        [XmlAttribute]
        public string? DescripcionProductoMovto { get => _DescripcionProductoMovto; set { if (RaiseAcceptPendingChange(value, _DescripcionProductoMovto)) { _DescripcionProductoMovto = value; OnPropertyChanged(); } } }

        private string? _DescripcionCantidades;
        [XmlAttribute]
        public string? DescripcionCantidades { get => _DescripcionCantidades; set { if (RaiseAcceptPendingChange(value, _DescripcionCantidades)) { _DescripcionCantidades = value; OnPropertyChanged(); } } }

        private string? _LoteFechavenceConcatenado;
        [XmlAttribute]
        public string? LoteFechavenceConcatenado { get => _LoteFechavenceConcatenado; set { if (RaiseAcceptPendingChange(value, _LoteFechavenceConcatenado)) { _LoteFechavenceConcatenado = value; OnPropertyChanged(); } } }

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


        public static V_inventario_movto_insertWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_V_inventario_movto_insertWFBindingModel = new V_inventario_movto_insertWFBindingModel();

        	buffer_V_inventario_movto_insertWFBindingModel._EmpresaId = obj.EmpresaId;

        	buffer_V_inventario_movto_insertWFBindingModel._SucursalId = obj.SucursalId;

        	buffer_V_inventario_movto_insertWFBindingModel._Id = obj.Id;

        	buffer_V_inventario_movto_insertWFBindingModel._Doctoid = obj.Doctoid;

        	buffer_V_inventario_movto_insertWFBindingModel._Estatusmovtoid = obj.Estatusmovtoid;

        	buffer_V_inventario_movto_insertWFBindingModel._Lote = obj.Lote;

        	buffer_V_inventario_movto_insertWFBindingModel._Localidad = obj.Localidad;

        	buffer_V_inventario_movto_insertWFBindingModel._Productoid = obj.Productoid;

        	buffer_V_inventario_movto_insertWFBindingModel._Productoclave = obj.Productoclave;

        	buffer_V_inventario_movto_insertWFBindingModel._Productonombre = obj.Productonombre;

        	buffer_V_inventario_movto_insertWFBindingModel._Almacenid = obj.Almacenid;

        	buffer_V_inventario_movto_insertWFBindingModel._Almacenclave = obj.Almacenclave;

        	buffer_V_inventario_movto_insertWFBindingModel._Almacennombre = obj.Almacennombre;

        	buffer_V_inventario_movto_insertWFBindingModel._Anaquelid = obj.Anaquelid;

        	buffer_V_inventario_movto_insertWFBindingModel._Anaquelclave = obj.Anaquelclave;

        	buffer_V_inventario_movto_insertWFBindingModel._Anaquelnombre = obj.Anaquelnombre;

        	buffer_V_inventario_movto_insertWFBindingModel._Cantidad = obj.Cantidad;

        	buffer_V_inventario_movto_insertWFBindingModel._Fechavence = obj.Fechavence;

        	buffer_V_inventario_movto_insertWFBindingModel._Usuarioid = obj.Usuarioid;

        	buffer_V_inventario_movto_insertWFBindingModel._Productolocationsid = obj.Productolocationsid;

        	buffer_V_inventario_movto_insertWFBindingModel._DescripcionProductoMovto = obj.DescripcionProductoMovto;

        	buffer_V_inventario_movto_insertWFBindingModel._DescripcionCantidades = obj.DescripcionCantidades;

        	buffer_V_inventario_movto_insertWFBindingModel._LoteFechavenceConcatenado = obj.LoteFechavenceConcatenado;

            return buffer_V_inventario_movto_insertWFBindingModel;
        }


        public MovtoInventarioTrans GetMovtoInventarioTrans()
        {
            return new MovtoInventarioTrans()
            {

                Empresaid = this.EmpresaId ?? 0,
                Sucursalid = this.SucursalId ?? 0,
                Id = this.Id,
                Doctoid = this.Doctoid ?? 0,
                Partida = 0,
                Estatusmovtoid = this.Estatusmovtoid ?? 0,
                Productoid = this.Productoid ?? 0,
                Cantidad = this.Cantidad ?? 0m,
                Cantidad_real = this.Cantidad ?? 0m,
                Descuentoporcentaje = 0,
                Precio = 0,
                Lote = this.Lote,
                Fechavence = this.Fechavence,
                //Loteimportado = 
                //Movtoparentid { get; set; }
                Localidad = this.Localidad,
                //Agrupaporparametro { get; set; }
                Usuarioid = this.Usuarioid ?? 0,
                Anaquelid = this.Anaquelid

                };
        }

    }

    
     
}

