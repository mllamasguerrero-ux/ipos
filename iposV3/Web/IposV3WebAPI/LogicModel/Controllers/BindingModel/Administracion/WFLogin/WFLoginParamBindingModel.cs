
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
    public class WFLoginParamBindingModel : Validatable, IBaseCommandBindingModel
    {


        public WFLoginParamBindingModel(long? p_empresaId, long? p_sucursalId)
        {
            this.p_empresaId = p_empresaId;
            this.p_sucursalid = p_sucursalId;
        }






        private string? p_username;
        [XmlAttribute]
        public string? P_username { get => p_username; set { if ( RaiseAcceptPendingChange(value, p_username)) { p_username = value; OnPropertyChanged(); } } }


        private string? p_claveacceso;
        [XmlAttribute]
        public string? P_claveacceso { get => p_claveacceso; set { if (RaiseAcceptPendingChange(value, p_claveacceso)) { p_claveacceso = value; OnPropertyChanged(); } } }


        private long? p_empresaId;
        [XmlAttribute]
        public long? P_empresaid { get => p_empresaId; set { if ( RaiseAcceptPendingChange(value, p_empresaId)) { p_empresaId = value; OnPropertyChanged(); } } }


        private long? p_sucursalid;
        [XmlAttribute]
        public long? P_sucursalid { get => p_sucursalid; set { if ( RaiseAcceptPendingChange(value, p_sucursalid)) { p_sucursalid = value; OnPropertyChanged(); } } }



    }
}

