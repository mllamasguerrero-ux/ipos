
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class TipotransaccionItemVMInitialParameters : BaseCommonInitialParameters
    {

        public TipotransaccionItemVMInitialParameters() : base(0)
        {
        }

        public TipotransaccionItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class TipotransaccionListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public TipotransaccionListVMInitialParameters() : base(0)
        {
        }

        public TipotransaccionListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class TipotransaccionListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public TipotransaccionListVMEventParameters() : base(false)
        { }

        public TipotransaccionListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public TipotransaccionListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
