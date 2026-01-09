
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class SubtipoclienteItemVMInitialParameters : BaseCommonInitialParameters
    {

        public SubtipoclienteItemVMInitialParameters() : base(0)
        {
        }

        public SubtipoclienteItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class SubtipoclienteListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public SubtipoclienteListVMInitialParameters() : base(0)
        {
        }

        public SubtipoclienteListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class SubtipoclienteListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public SubtipoclienteListVMEventParameters() : base(false)
        { }

        public SubtipoclienteListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public SubtipoclienteListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
