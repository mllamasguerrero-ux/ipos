
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class MerchantpagoservicioItemVMInitialParameters : BaseCommonInitialParameters
    {

        public MerchantpagoservicioItemVMInitialParameters() : base(0)
        {
        }

        public MerchantpagoservicioItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class MerchantpagoservicioListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public MerchantpagoservicioListVMInitialParameters() : base(0)
        {
        }

        public MerchantpagoservicioListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class MerchantpagoservicioListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public MerchantpagoservicioListVMEventParameters() : base(false)
        { }

        public MerchantpagoservicioListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public MerchantpagoservicioListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
