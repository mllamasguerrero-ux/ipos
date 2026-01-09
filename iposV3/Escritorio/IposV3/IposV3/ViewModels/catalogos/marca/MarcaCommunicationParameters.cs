
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class MarcaItemVMInitialParameters : BaseCommonInitialParameters
    {

        public MarcaItemVMInitialParameters() : base(0)
        {
        }

        public MarcaItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class MarcaListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public MarcaListVMInitialParameters() : base(0)
        {
        }

        public MarcaListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class MarcaListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {


        public MarcaListVMEventParameters() : base(false)
        { }

        public MarcaListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public MarcaListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent, hasMessage, msgSimple)
        { }
    }
}


