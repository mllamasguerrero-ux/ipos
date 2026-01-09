
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class HomeItemVMInitialParameters : BaseCommonInitialParameters
    {

        public HomeItemVMInitialParameters() : base(0)
        {
        }

        public HomeItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class HomeListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public HomeListVMInitialParameters() : base(0)
        {
        }

        public HomeListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class HomeListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public HomeListVMEventParameters() : base(false)
        { }

        public HomeListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public HomeListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
