
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
    public class MovtoInventarioTransWFBindingModel : Validatable
    {

        public MovtoInventarioTransWFBindingModel()
        {
            FillCatalogRelatedFields();
        }




        private long? _Empresaid;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? Empresaid { get => _Empresaid?? 0; set { if (RaiseAcceptPendingChange(value, _Empresaid)) { _Empresaid = value?? 0; OnPropertyChanged(); } } }

        private long? _Sucursalid;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? Sucursalid { get => _Sucursalid?? 0; set { if (RaiseAcceptPendingChange(value, _Sucursalid)) { _Sucursalid = value?? 0; OnPropertyChanged(); } } }

        private long? _Id;
        [XmlAttribute]
        public long? Id { get => _Id; set { if (RaiseAcceptPendingChange(value, _Id)) { _Id = value; OnPropertyChanged(); } } }

        private long? _Doctoid;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? Doctoid { get => _Doctoid?? 0; set { if (RaiseAcceptPendingChange(value, _Doctoid)) { _Doctoid = value?? 0; OnPropertyChanged(); } } }

        private int? _Partida;
        [XmlAttribute]
        public int? Partida { get => _Partida; set { if (RaiseAcceptPendingChange(value, _Partida)) { _Partida = value; OnPropertyChanged(); } } }

        private long? _Estatusmovtoid;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? Estatusmovtoid { get => _Estatusmovtoid?? 0; set { if (RaiseAcceptPendingChange(value, _Estatusmovtoid)) { _Estatusmovtoid = value?? 0; OnPropertyChanged(); } } }

        private long? _Productoid;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? Productoid { get => _Productoid?? 0; set { if (RaiseAcceptPendingChange(value, _Productoid)) { _Productoid = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Cantidad;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Cantidad { get => _Cantidad?? 0; set { if (RaiseAcceptPendingChange(value, _Cantidad)) { _Cantidad = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Cantidad_real;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public decimal? Cantidad_real { get => _Cantidad_real?? 0; set { if (RaiseAcceptPendingChange(value, _Cantidad_real)) { _Cantidad_real = value?? 0; OnPropertyChanged(); } } }

        private decimal? _Descuentoporcentaje;
        [XmlAttribute]
        public decimal? Descuentoporcentaje { get => _Descuentoporcentaje; set { if (RaiseAcceptPendingChange(value, _Descuentoporcentaje)) { _Descuentoporcentaje = value; OnPropertyChanged(); } } }

        private decimal? _Precio;
        [XmlAttribute]
        public decimal? Precio { get => _Precio; set { if (RaiseAcceptPendingChange(value, _Precio)) { _Precio = value; OnPropertyChanged(); } } }

        private string? _Lote;
        [XmlAttribute]
        public string? Lote { get => _Lote; set { if (RaiseAcceptPendingChange(value, _Lote)) { _Lote = value; OnPropertyChanged(); } } }

        private DateTimeOffset? _Fechavence;
        [XmlAttribute]
        public DateTimeOffset? Fechavence { get => _Fechavence; set { if (RaiseAcceptPendingChange(value, _Fechavence)) { _Fechavence = value; OnPropertyChanged(); } } }

        private long? _Loteimportado;
        [XmlAttribute]
        public long? Loteimportado { get => _Loteimportado; set { if (RaiseAcceptPendingChange(value, _Loteimportado)) { _Loteimportado = value; OnPropertyChanged(); } } }

        private long? _Movtoparentid;
        [XmlAttribute]
        public long? Movtoparentid { get => _Movtoparentid; set { if (RaiseAcceptPendingChange(value, _Movtoparentid)) { _Movtoparentid = value; OnPropertyChanged(); } } }

        private string? _Localidad;
        [XmlAttribute]
        public string? Localidad { get => _Localidad; set { if (RaiseAcceptPendingChange(value, _Localidad)) { _Localidad = value; OnPropertyChanged(); } } }

        private BoolCN? _Agrupaporparametro;
        [XmlAttribute]
        public BoolCN? Agrupaporparametro { get => _Agrupaporparametro; set { if (RaiseAcceptPendingChange(value, _Agrupaporparametro)) { _Agrupaporparametro = value; OnPropertyChanged(); } } }

        private long? _Usuarioid;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public long? Usuarioid { get => _Usuarioid?? 0; set { if (RaiseAcceptPendingChange(value, _Usuarioid)) { _Usuarioid = value?? 0; OnPropertyChanged(); } } }

        private long? _Anaquelid;
        [XmlAttribute]
        public long? Anaquelid { get => _Anaquelid; set { if (RaiseAcceptPendingChange(value, _Anaquelid)) { _Anaquelid = value; OnPropertyChanged(); } } }

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


        public static MovtoInventarioTransWFBindingModel CreateFromAnonymous( dynamic obj)
        {
            var buffer_MovtoInventarioTransWFBindingModel = new MovtoInventarioTransWFBindingModel();

        	buffer_MovtoInventarioTransWFBindingModel._Empresaid = obj.Empresaid;

        	buffer_MovtoInventarioTransWFBindingModel._Sucursalid = obj.Sucursalid;

        	buffer_MovtoInventarioTransWFBindingModel._Id = obj.Id;

        	buffer_MovtoInventarioTransWFBindingModel._Doctoid = obj.Doctoid;

        	buffer_MovtoInventarioTransWFBindingModel._Partida = obj.Partida;

        	buffer_MovtoInventarioTransWFBindingModel._Estatusmovtoid = obj.Estatusmovtoid;

        	buffer_MovtoInventarioTransWFBindingModel._Productoid = obj.Productoid;

        	buffer_MovtoInventarioTransWFBindingModel._Cantidad = obj.Cantidad;

        	buffer_MovtoInventarioTransWFBindingModel._Cantidad_real = obj.Cantidad_real;

        	buffer_MovtoInventarioTransWFBindingModel._Descuentoporcentaje = obj.Descuentoporcentaje;

        	buffer_MovtoInventarioTransWFBindingModel._Precio = obj.Precio;

        	buffer_MovtoInventarioTransWFBindingModel._Lote = obj.Lote;

        	buffer_MovtoInventarioTransWFBindingModel._Fechavence = obj.Fechavence;

        	buffer_MovtoInventarioTransWFBindingModel._Loteimportado = obj.Loteimportado;

        	buffer_MovtoInventarioTransWFBindingModel._Movtoparentid = obj.Movtoparentid;

        	buffer_MovtoInventarioTransWFBindingModel._Localidad = obj.Localidad;

        	buffer_MovtoInventarioTransWFBindingModel._Agrupaporparametro = obj.Agrupaporparametro;

        	buffer_MovtoInventarioTransWFBindingModel._Usuarioid = obj.Usuarioid;

        	buffer_MovtoInventarioTransWFBindingModel._Anaquelid = obj.Anaquelid;

            return buffer_MovtoInventarioTransWFBindingModel;
        }


    }

    
     
}

