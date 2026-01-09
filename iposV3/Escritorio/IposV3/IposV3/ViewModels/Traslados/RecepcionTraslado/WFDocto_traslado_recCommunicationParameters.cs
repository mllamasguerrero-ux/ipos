
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class WFDocto_traslado_recItemVMInitialParameters : BaseCommonInitialParameters
    {

        public WFDocto_traslado_recItemVMInitialParameters() : base(0)
        {
        }

        public WFDocto_traslado_recItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class WFDocto_traslado_recListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public WFDocto_traslado_recListVMInitialParameters() : base(0)
        {
        }

        public WFDocto_traslado_recListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class WFDocto_traslado_recListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public WFDocto_traslado_recListVMEventParameters() : base(false)
        { }

        public WFDocto_traslado_recListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public WFDocto_traslado_recListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
