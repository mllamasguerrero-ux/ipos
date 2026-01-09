
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model;
using MvvmFramework;
using System.Xml.Serialization;
using BindingModels;

namespace ApiParam
{
    [XmlRoot]
    
    public class Movto_DecipherCommand_ApiParam
    
    {
        
        #pragma warning disable 8618
        public Movto_DecipherCommand_ApiParam()
        {
        }
        #pragma warning restore 8618


        private Int64? _EmpresaId;
        [XmlAttribute]
        public Int64? EmpresaId { get => _EmpresaId; set { _EmpresaId = value;  } } 

        private Int64? _SucursalId;
        [XmlAttribute]
        public Int64? SucursalId { get => _SucursalId; set { _SucursalId = value;  } } 

        private String? _CommandText;
        [XmlAttribute]
        public String? CommandText { get => _CommandText; set { _CommandText = value;  } }









        private BoolCN? _Precionetoenpv;
        [XmlAttribute]
        public BoolCN? Precionetoenpv { get => _Precionetoenpv ?? BoolCN.N; set { _Precionetoenpv = value ?? BoolCN.N; } }


        private long? _Tipodescuentoprodid;
        [XmlAttribute]
        public long? Tipodescuentoprodid { get => _Tipodescuentoprodid; set { _Tipodescuentoprodid = value; } }



        private bool _SaveMovto;
        [XmlAttribute]
        public bool SaveMovto { get => _SaveMovto; set { _SaveMovto = value; } }


        private bool _ManejaAlmacen;
        [XmlAttribute]
        public bool ManejaAlmacen { get => _ManejaAlmacen; set { _ManejaAlmacen = value; } }


        private DoctoBindingModel _CurrentDocto;
        [XmlAttribute]
        public DoctoBindingModel CurrentDocto { get => _CurrentDocto; set { _CurrentDocto = value; } }




        private long? _Usuarioid;
        [XmlAttribute]
        public long? Usuarioid { get => _Usuarioid; set { _Usuarioid = value; } }


    }
}

