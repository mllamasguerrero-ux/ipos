
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class EncargadoguiaItemVMInitialParameters : BaseCommonInitialParameters
    {

        public EncargadoguiaItemVMInitialParameters() : base(0)
        {
        }

        public EncargadoguiaItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class EncargadoguiaListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public EncargadoguiaListVMInitialParameters() : base(0)
        {
        }

        public EncargadoguiaListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class EncargadoguiaListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public EncargadoguiaListVMEventParameters() : base(false)
        { }

        public EncargadoguiaListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public EncargadoguiaListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
