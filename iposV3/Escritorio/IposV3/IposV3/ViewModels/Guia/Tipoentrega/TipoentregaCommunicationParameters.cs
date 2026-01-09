
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class TipoentregaItemVMInitialParameters : BaseCommonInitialParameters
    {

        public TipoentregaItemVMInitialParameters() : base(0)
        {
        }

        public TipoentregaItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class TipoentregaListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public TipoentregaListVMInitialParameters() : base(0)
        {
        }

        public TipoentregaListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class TipoentregaListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public TipoentregaListVMEventParameters() : base(false)
        { }

        public TipoentregaListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public TipoentregaListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
