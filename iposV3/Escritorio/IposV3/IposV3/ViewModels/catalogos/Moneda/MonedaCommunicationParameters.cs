
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class MonedaItemVMInitialParameters : BaseCommonInitialParameters
    {

        public MonedaItemVMInitialParameters() : base(0)
        {
        }

        public MonedaItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class MonedaListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public MonedaListVMInitialParameters() : base(0)
        {
        }

        public MonedaListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class MonedaListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public MonedaListVMEventParameters() : base(false)
        { }

        public MonedaListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public MonedaListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
