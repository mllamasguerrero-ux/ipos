
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
    public class BaseResultBindingModel
    {


        private string _userMessage = "";

        [XmlAttribute]
        public virtual string Usermessage { get => _userMessage; set { _userMessage = value; } }


        private string _devmessage = "";
        [XmlAttribute]
        public virtual string Devmessage { get => _devmessage; set { _devmessage = value; } }


        private long? _result = null;
        [XmlAttribute]
        public virtual long? Result { get => _result; set { _result = value;  } }



    }
}
