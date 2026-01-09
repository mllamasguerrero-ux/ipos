
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
    public class MovtoBindingModel: MovtoBindingModelGenerated
    {


        public MovtoBindingModel():base()
        {
        }
        
        #if PROYECTO_WEB
        public MovtoBindingModel(Movto item):base(item)
        {
        }
        #endif

        public string? _DescripcionProductoMovto;
        [XmlAttribute]
        public string? DescripcionProductoMovto { get => _DescripcionProductoMovto; set { if (RaiseAcceptPendingChange(value, _DescripcionProductoMovto)) { _DescripcionProductoMovto = value; OnPropertyChanged(); } } }



    }
}

