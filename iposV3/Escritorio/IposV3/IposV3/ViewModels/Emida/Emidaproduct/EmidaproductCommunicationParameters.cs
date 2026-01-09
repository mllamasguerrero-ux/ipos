
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class EmidaproductItemVMInitialParameters : BaseCommonInitialParameters
    {

        public EmidaproductItemVMInitialParameters() : base(0)
        {
        }

        public EmidaproductItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class EmidaproductListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public EmidaproductListVMInitialParameters() : base(0)
        {
        }

        public EmidaproductListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class EmidaproductListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public EmidaproductListVMEventParameters() : base(false)
        { }

        public EmidaproductListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public EmidaproductListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
