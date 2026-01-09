
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class Docto_solicitud_mercanciaItemVMInitialParameters : BaseCommonInitialParameters
    {

        public Docto_solicitud_mercanciaItemVMInitialParameters() : base(0)
        {
        }

        public Docto_solicitud_mercanciaItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class Docto_solicitud_mercanciaListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public Docto_solicitud_mercanciaListVMInitialParameters() : base(0)
        {
        }

        public Docto_solicitud_mercanciaListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class Docto_solicitud_mercanciaListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public Docto_solicitud_mercanciaListVMEventParameters() : base(false)
        { }

        public Docto_solicitud_mercanciaListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public Docto_solicitud_mercanciaListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
