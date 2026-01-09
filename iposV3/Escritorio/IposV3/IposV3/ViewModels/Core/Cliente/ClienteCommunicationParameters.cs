
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class ClienteItemVMInitialParameters : BaseCommonInitialParameters
    {

        public ClienteItemVMInitialParameters() : base(0)
        {
        }

        public ClienteItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class ClienteListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public ClienteListVMInitialParameters() : base(0)
        {
        }

        public ClienteListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class ClienteListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public ClienteListVMEventParameters() : base(false)
        { }

        public ClienteListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public ClienteListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
