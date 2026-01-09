
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class PromocionItemVMInitialParameters : BaseCommonInitialParameters
    {

        public PromocionItemVMInitialParameters() : base(0)
        {
        }

        public PromocionItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class PromocionListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public PromocionListVMInitialParameters() : base(0)
        {
        }

        public PromocionListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class PromocionListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public PromocionListVMEventParameters() : base(false)
        { }

        public PromocionListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public PromocionListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
