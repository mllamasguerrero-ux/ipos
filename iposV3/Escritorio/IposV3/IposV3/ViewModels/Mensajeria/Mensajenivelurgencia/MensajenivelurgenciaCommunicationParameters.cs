
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class MensajenivelurgenciaItemVMInitialParameters : BaseCommonInitialParameters
    {

        public MensajenivelurgenciaItemVMInitialParameters() : base(0)
        {
        }

        public MensajenivelurgenciaItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class MensajenivelurgenciaListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public MensajenivelurgenciaListVMInitialParameters() : base(0)
        {
        }

        public MensajenivelurgenciaListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class MensajenivelurgenciaListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public MensajenivelurgenciaListVMEventParameters() : base(false)
        { }

        public MensajenivelurgenciaListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public MensajenivelurgenciaListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
