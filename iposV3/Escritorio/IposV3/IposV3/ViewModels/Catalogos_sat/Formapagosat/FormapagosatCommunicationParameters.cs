
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class FormapagosatItemVMInitialParameters : BaseCommonInitialParameters
    {

        public FormapagosatItemVMInitialParameters() : base(0)
        {
        }

        public FormapagosatItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class FormapagosatListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public FormapagosatListVMInitialParameters() : base(0)
        {
        }

        public FormapagosatListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class FormapagosatListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public FormapagosatListVMEventParameters() : base(false)
        { }

        public FormapagosatListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public FormapagosatListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
