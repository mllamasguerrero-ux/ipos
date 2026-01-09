
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
    public class PuntoCompraDevoBindingModel : Validatable
    {


        //Main entities
        private DoctoBindingModel? currentDocto;
        public DoctoBindingModel? CurrentDocto
        {
            get => currentDocto;
            set
            {
                currentDocto = value;
            }
        }

        private DoctoBindingModel? currentDoctoRef;
        public DoctoBindingModel? CurrentDoctoRef
        {
            get => currentDoctoRef;
            set
            {
                currentDoctoRef = value;
            }
        }

        private MovtoBindingModel? currentMovto;
        public MovtoBindingModel? CurrentMovto
        {
            get => currentMovto;
            set
            {
                currentMovto = value;
            }
        }

        private ProveedorBindingModel? currentProveedor;
        public ProveedorBindingModel? CurrentProveedor { get => currentProveedor; set { currentProveedor = value; } }


        private ProductoBindingModel? currentProducto;
        public ProductoBindingModel? CurrentProducto { get => currentProducto; set { currentProducto = value; } }



        public List<V_movto_provdevoWFBindingModel> MovtoItems { get; set; } = new List<V_movto_provdevoWFBindingModel>();

        public List<V_movto_prov_to_devoWFBindingModel> MovtoToDevoItems { get; set; } = new List<V_movto_prov_to_devoWFBindingModel>();


        //Operation result properties
        public BaseResultBindingModel? Fnc_docto_provdevo_insertResult { get; set; }
        public BaseResultBindingModel? Fnc_movto_provdevo_insertResult { get; set; }


        public List<MovtoProvDevoTrans>? MovtoTransList { get; set; }

        public Movto_command_deciphered? DecipherResult { get; set; }



        private BoolCN? _Precionetoenpv;
        [XmlAttribute]
        public BoolCN? Precionetoenpv { get => _Precionetoenpv ?? BoolCN.N; set { _Precionetoenpv = value ?? BoolCN.N; } }


        private long? _Tipodescuentoprodid;
        [XmlAttribute]
        public long? Tipodescuentoprodid { get => _Tipodescuentoprodid; set { _Tipodescuentoprodid = value; } }


        private long? _Usuarioid;
        [XmlAttribute]
        public long? Usuarioid { get => _Usuarioid; set { _Usuarioid = value; } }

        private bool _SaveMovto;
        [XmlAttribute]
        public bool SaveMovto { get => _SaveMovto; set { _SaveMovto = value; } }


        private bool _ManejaAlmacen;
        [XmlAttribute]
        public bool ManejaAlmacen { get => _ManejaAlmacen; set { _ManejaAlmacen = value; } }


        private BaseResultBindingModel _BaseResultBindingModel = new BaseResultBindingModel();
        [XmlAttribute]
        public BaseResultBindingModel BaseResultBindingModel { get => _BaseResultBindingModel; set { _BaseResultBindingModel = value; } }


    }
}
