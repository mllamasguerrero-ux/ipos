
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model.Syncr;
using MvvmFramework;
using System.Xml.Serialization;

namespace BindingModels
{
    [XmlRoot]
    public class ConfiguracionsyncBindingModel: ConfiguracionsyncBindingModelGenerated
    {


        public ConfiguracionsyncBindingModel():base()
        {
        }
        public ConfiguracionsyncBindingModel(Configuracionsync item):base(item)
        {
        }

       

    }
}

