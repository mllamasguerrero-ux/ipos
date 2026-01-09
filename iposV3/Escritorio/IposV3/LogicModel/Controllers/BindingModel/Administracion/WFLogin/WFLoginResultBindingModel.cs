
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
    public class WFLoginResultBindingModel : Validatable, IBaseCommandBindingModel
    {


        public WFLoginResultBindingModel()
        {
        }






        private string? usermessage;
        [XmlAttribute]
        public virtual string? Usermessage { get => usermessage; set {  usermessage = value; OnPropertyChanged(); }  }


        private string? devmessage;
        [XmlAttribute]
        public virtual string? Devmessage { get => devmessage; set { devmessage = value; OnPropertyChanged(); }  }


        private long? result;
        [XmlAttribute]
        public virtual long? Result { get => result; set {  result = value; OnPropertyChanged(); }  }



    }
}

