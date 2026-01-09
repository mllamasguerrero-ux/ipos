
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class EstadoguiaItemVMInitialParameters : BaseCommonInitialParameters
    {

        public EstadoguiaItemVMInitialParameters() : base(0)
        {
        }

        public EstadoguiaItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class EstadoguiaListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public EstadoguiaListVMInitialParameters() : base(0)
        {
        }

        public EstadoguiaListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class EstadoguiaListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public EstadoguiaListVMEventParameters() : base(false)
        { }

        public EstadoguiaListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public EstadoguiaListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
