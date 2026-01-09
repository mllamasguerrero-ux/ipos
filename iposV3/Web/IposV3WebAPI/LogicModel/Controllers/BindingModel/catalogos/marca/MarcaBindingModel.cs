
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MvvmFramework;
using System.Xml.Serialization;
using IposV3.Model;

namespace BindingModels
{
    [XmlRoot]
    public class MarcaBindingModel: MarcaBindingModelGenerated
    {


        public MarcaBindingModel():base()
        {
        }
        
        #if PROYECTO_WEB
        public MarcaBindingModel(Marca item) : base(item)
        {
        }
        #endif


        //private long? marcaRelacionadaId;
        //public long? MarcaRelacionadaId { get => marcaRelacionadaId; set { if ( RaiseAcceptPendingChange(value, marcaRelacionadaId)) { marcaRelacionadaId = value; OnPropertyChanged(); } } }


        //private long? marcaRelacionadaId2;
        //public long? MarcaRelacionadaId2 { get => marcaRelacionadaId2; set { if ( RaiseAcceptPendingChange(value, marcaRelacionadaId2)) { marcaRelacionadaId2 = value; OnPropertyChanged(); } } }


        //private string? marcaRelacionadaClave2;
        //public string? MarcaRelacionadaClave2 { get => marcaRelacionadaClave2; set { 
        //        if (RaiseAcceptPendingChange(value, marcaRelacionadaClave2)) 
        //        { 
        //            marcaRelacionadaClave2 = value;
        //            OnPropertyChanged(); } } }

        //private string? marcaRelacionadaNombre2;
        //public string? MarcaRelacionadaNombre2 { get => marcaRelacionadaNombre2; set { if ( RaiseAcceptPendingChange(value, marcaRelacionadaNombre2)) { marcaRelacionadaNombre2 = value; OnPropertyChanged(); } } }



    }

    public class MarcaParam: MarcaParamGenerated
    {

        public MarcaParam() : base()
        {
        }
        public MarcaParam(long? empresaid, long? sucursalid) : 
            base(empresaid, sucursalid)
        {
        }
    }
}

