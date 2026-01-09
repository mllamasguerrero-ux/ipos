
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class ContenidoItemVMInitialParameters : BaseCommonInitialParameters
    {

        public ContenidoItemVMInitialParameters() : base(0)
        {
        }

        public ContenidoItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class ContenidoListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public ContenidoListVMInitialParameters() : base(0)
        {
        }

        public ContenidoListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class ContenidoListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public ContenidoListVMEventParameters() : base(false)
        { }

        public ContenidoListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public ContenidoListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
