
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class EstadocobranzaItemVMInitialParameters : BaseCommonInitialParameters
    {

        public EstadocobranzaItemVMInitialParameters() : base(0)
        {
        }

        public EstadocobranzaItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class EstadocobranzaListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public EstadocobranzaListVMInitialParameters() : base(0)
        {
        }

        public EstadocobranzaListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class EstadocobranzaListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public EstadocobranzaListVMEventParameters() : base(false)
        { }

        public EstadocobranzaListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public EstadocobranzaListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
