
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class ParametroItemVMInitialParameters : BaseCommonInitialParameters
    {

        public ParametroItemVMInitialParameters() : base(0)
        {
        }

        public ParametroItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class ParametroListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public ParametroListVMInitialParameters() : base(0)
        {
        }

        public ParametroListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class ParametroListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public ParametroListVMEventParameters() : base(false)
        { }

        public ParametroListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public ParametroListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
