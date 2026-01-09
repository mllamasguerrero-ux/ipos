
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class MaxfactItemVMInitialParameters : BaseCommonInitialParameters
    {

        public MaxfactItemVMInitialParameters() : base(0)
        {
        }

        public MaxfactItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class MaxfactListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public MaxfactListVMInitialParameters() : base(0)
        {
        }

        public MaxfactListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class MaxfactListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public MaxfactListVMEventParameters() : base(false)
        { }

        public MaxfactListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public MaxfactListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
