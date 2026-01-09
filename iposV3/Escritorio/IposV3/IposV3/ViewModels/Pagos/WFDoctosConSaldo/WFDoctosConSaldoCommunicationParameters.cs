
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class WFDoctosConSaldo_SelectorItemVMInitialParameters : BaseCommonInitialParameters
    {

        public WFDoctosConSaldo_SelectorItemVMInitialParameters() : base(0)
        {
        }

        public WFDoctosConSaldo_SelectorItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class WFDoctosConSaldo_SelectorListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public WFDoctosConSaldo_SelectorListVMInitialParameters() : base(0)
        {
        }

        public WFDoctosConSaldo_SelectorListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class WFDoctosConSaldo_SelectorListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public WFDoctosConSaldo_SelectorListVMEventParameters() : base(false)
        { }

        public WFDoctosConSaldo_SelectorListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public WFDoctosConSaldo_SelectorListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
