
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class Motivo_devolucionItemVMInitialParameters : BaseCommonInitialParameters
    {

        public Motivo_devolucionItemVMInitialParameters() : base(0)
        {
        }

        public Motivo_devolucionItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class Motivo_devolucionListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public Motivo_devolucionListVMInitialParameters() : base(0)
        {
        }

        public Motivo_devolucionListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class Motivo_devolucionListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public Motivo_devolucionListVMEventParameters() : base(false)
        { }

        public Motivo_devolucionListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public Motivo_devolucionListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
