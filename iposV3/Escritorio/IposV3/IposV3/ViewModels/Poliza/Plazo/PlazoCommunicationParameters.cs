
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class PlazoItemVMInitialParameters : BaseCommonInitialParameters
    {

        public PlazoItemVMInitialParameters() : base(0)
        {
        }

        public PlazoItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class PlazoListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public PlazoListVMInitialParameters() : base(0)
        {
        }

        public PlazoListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class PlazoListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public PlazoListVMEventParameters() : base(false)
        { }

        public PlazoListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public PlazoListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
