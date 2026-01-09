
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
using IposV3.Services.FacturaElectronica;

namespace ApiParam
{
    [XmlRoot]

    public class Cfdi_ApiParam

    {

#pragma warning disable 8618
        public Cfdi_ApiParam()
        {
        }
#pragma warning restore 8618


        private TimbradoInfo _timbradoInfo;
        [XmlAttribute]
        public TimbradoInfo TimbradoInfo { get => _timbradoInfo; set { _timbradoInfo = value; } }




    }
}

