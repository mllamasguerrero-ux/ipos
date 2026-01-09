
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3Sync.ViewModels
{

    public class ConfiguracionsyncItemVMInitialParameters : BaseCommonInitialParameters
    {

        public ConfiguracionsyncItemVMInitialParameters() : base(0)
        {
        }

        public ConfiguracionsyncItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class ConfiguracionsyncListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public ConfiguracionsyncListVMInitialParameters() : base(0)
        {
        }

        public ConfiguracionsyncListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class ConfiguracionsyncListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public ConfiguracionsyncListVMEventParameters() : base(false)
        { }

        public ConfiguracionsyncListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public ConfiguracionsyncListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
