
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class TipopromocionItemVMInitialParameters : BaseCommonInitialParameters
    {

        public TipopromocionItemVMInitialParameters() : base(0)
        {
        }

        public TipopromocionItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class TipopromocionListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public TipopromocionListVMInitialParameters() : base(0)
        {
        }

        public TipopromocionListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class TipopromocionListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public TipopromocionListVMEventParameters() : base(false)
        { }

        public TipopromocionListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public TipopromocionListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
