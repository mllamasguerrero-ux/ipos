
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class GastoItemVMInitialParameters : BaseCommonInitialParameters
    {

        public GastoItemVMInitialParameters() : base(0)
        {
        }

        public GastoItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class GastoListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public GastoListVMInitialParameters() : base(0)
        {
        }

        public GastoListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class GastoListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public GastoListVMEventParameters() : base(false)
        { }

        public GastoListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public GastoListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
