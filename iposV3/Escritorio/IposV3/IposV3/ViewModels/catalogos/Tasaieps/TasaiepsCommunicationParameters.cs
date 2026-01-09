
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class TasaiepsItemVMInitialParameters : BaseCommonInitialParameters
    {

        public TasaiepsItemVMInitialParameters() : base(0)
        {
        }

        public TasaiepsItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class TasaiepsListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public TasaiepsListVMInitialParameters() : base(0)
        {
        }

        public TasaiepsListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class TasaiepsListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public TasaiepsListVMEventParameters() : base(false)
        { }

        public TasaiepsListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public TasaiepsListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
