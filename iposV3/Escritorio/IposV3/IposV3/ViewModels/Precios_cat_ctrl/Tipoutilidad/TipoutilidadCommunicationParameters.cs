
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class TipoutilidadItemVMInitialParameters : BaseCommonInitialParameters
    {

        public TipoutilidadItemVMInitialParameters() : base(0)
        {
        }

        public TipoutilidadItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class TipoutilidadListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public TipoutilidadListVMInitialParameters() : base(0)
        {
        }

        public TipoutilidadListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class TipoutilidadListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public TipoutilidadListVMEventParameters() : base(false)
        { }

        public TipoutilidadListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public TipoutilidadListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
