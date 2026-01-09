
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class EncargadocorteItemVMInitialParameters : BaseCommonInitialParameters
    {

        public EncargadocorteItemVMInitialParameters() : base(0)
        {
        }

        public EncargadocorteItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class EncargadocorteListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public EncargadocorteListVMInitialParameters() : base(0)
        {
        }

        public EncargadocorteListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class EncargadocorteListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public EncargadocorteListVMEventParameters() : base(false)
        { }

        public EncargadocorteListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public EncargadocorteListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
