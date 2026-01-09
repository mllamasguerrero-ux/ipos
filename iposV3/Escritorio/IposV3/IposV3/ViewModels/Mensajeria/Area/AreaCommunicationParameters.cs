
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class AreaItemVMInitialParameters : BaseCommonInitialParameters
    {

        public AreaItemVMInitialParameters() : base(0)
        {
        }

        public AreaItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class AreaListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public AreaListVMInitialParameters() : base(0)
        {
        }

        public AreaListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class AreaListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public AreaListVMEventParameters() : base(false)
        { }

        public AreaListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public AreaListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
