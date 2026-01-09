
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class TasaivaItemVMInitialParameters : BaseCommonInitialParameters
    {

        public TasaivaItemVMInitialParameters() : base(0)
        {
        }

        public TasaivaItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class TasaivaListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public TasaivaListVMInitialParameters() : base(0)
        {
        }

        public TasaivaListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class TasaivaListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public TasaivaListVMEventParameters() : base(false)
        { }

        public TasaivaListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public TasaivaListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
