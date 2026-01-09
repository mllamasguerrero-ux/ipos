
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
    public class TablasAReplicarWFBindingModel : Validatable
    {

        public TablasAReplicarWFBindingModel()
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

        private BoolCS? _Activo;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public BoolCS? Activo { get => _Activo?? BoolCS.S; set { if (RaiseAcceptPendingChange(value, _Activo)) { _Activo = value?? BoolCS.S; OnPropertyChanged(); } } }

        private string? _Nombretabla;
        [XmlAttribute][Required(ErrorMessage = "Es requerido")]
        public string? Nombretabla { get => _Nombretabla?? ""; set { if (RaiseAcceptPendingChange(value, _Nombretabla)) { _Nombretabla = value?? ""; OnPropertyChanged(); } } }

        private string? _Replcondinsert;
        [XmlAttribute]
        public string? Replcondinsert { get => _Replcondinsert; set { if (RaiseAcceptPendingChange(value, _Replcondinsert)) { _Replcondinsert = value; OnPropertyChanged(); } } }

        private string? _Replcondupdate;
        [XmlAttribute]
        public string? Replcondupdate { get => _Replcondupdate; set { if (RaiseAcceptPendingChange(value, _Replcondupdate)) { _Replcondupdate = value; OnPropertyChanged(); } } }

        private string? _Replconddelete;
        [XmlAttribute]
        public string? Replconddelete { get => _Replconddelete; set { if (RaiseAcceptPendingChange(value, _Replconddelete)) { _Replconddelete = value; OnPropertyChanged(); } } }


        private bool _Replicar;
        [XmlAttribute]
        [Required(ErrorMessage = "Es requerido")]
        public bool Replicar { get => _Replicar; set { if (RaiseAcceptPendingChange(value, _Replicar)) { _Replicar = value; Activo = _Replicar ? BoolCS.S : BoolCS.N; OnPropertyChanged(); } } }


        private string? _Grupos;
        [XmlAttribute]
        public string? Grupos { get => _Grupos; set { if (RaiseAcceptPendingChange(value, _Grupos)) { _Grupos = value; OnPropertyChanged(); } } }


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


        public static TablasAReplicarWFBindingModel CreateFromBasic(TablasAReplicar obj)
        {
            var buffer_TablasAReplicarWFBindingModel = new TablasAReplicarWFBindingModel();

        	buffer_TablasAReplicarWFBindingModel._Empresaid = obj.Empresaid;

        	buffer_TablasAReplicarWFBindingModel._Sucursalid = obj.Sucursalid;

        	buffer_TablasAReplicarWFBindingModel._Id = obj.Id;

        	buffer_TablasAReplicarWFBindingModel._Activo = obj.Activo;

        	buffer_TablasAReplicarWFBindingModel._Nombretabla = obj.Nombretabla;

        	buffer_TablasAReplicarWFBindingModel._Replcondinsert = obj.Replcondinsert;

        	buffer_TablasAReplicarWFBindingModel._Replcondupdate = obj.Replcondupdate;

        	buffer_TablasAReplicarWFBindingModel._Replconddelete = obj.Replconddelete;

            buffer_TablasAReplicarWFBindingModel._Replicar = obj.Activo == BoolCS.S;

            buffer_TablasAReplicarWFBindingModel._Grupos = obj.Grupos;

            return buffer_TablasAReplicarWFBindingModel;
        }


    }

    
     
}

