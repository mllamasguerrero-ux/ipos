
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class RangopromocionItemVMInitialParameters : BaseCommonInitialParameters
    {

        public RangopromocionItemVMInitialParameters() : base(0)
        {
        }

        public RangopromocionItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class RangopromocionListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public RangopromocionListVMInitialParameters() : base(0)
        {
        }

        public RangopromocionListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class RangopromocionListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public RangopromocionListVMEventParameters() : base(false)
        { }

        public RangopromocionListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public RangopromocionListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
