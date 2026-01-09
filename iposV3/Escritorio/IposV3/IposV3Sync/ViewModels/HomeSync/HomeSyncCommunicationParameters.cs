
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3Sync.ViewModels
{

    public class HomeSyncItemVMInitialParameters : IposV3Sync.ViewModels.BaseCommonInitialParameters
    {

        public HomeSyncItemVMInitialParameters() : base(0)
        {
        }

        public HomeSyncItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class HomeSyncListVMInitialParameters : IposV3Sync.ViewModels.BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public HomeSyncListVMInitialParameters() : base(0)
        {
        }

        public HomeSyncListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class HomeSyncListVMEventParameters : IposV3Sync.ViewModels.BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public HomeSyncListVMEventParameters() : base(false)
        { }

        public HomeSyncListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public HomeSyncListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
