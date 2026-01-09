
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model;
using MvvmFramework;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace BindingModels
{
    public  class MovtogastosadicWebBindingModel
    {

        public ObservableCollection<MovtogastosadicBindingModel> Items { get; set; }

        private BaseResultBindingModel _BaseResultBindingModel;
        [XmlAttribute]
        public BaseResultBindingModel BaseResultBindingModel { get => _BaseResultBindingModel; set { _BaseResultBindingModel = value; } }

    }
}
