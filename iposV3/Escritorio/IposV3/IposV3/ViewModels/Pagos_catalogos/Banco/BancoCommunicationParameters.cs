
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class BancoItemVMInitialParameters : BaseCommonInitialParameters
    {

        public BancoItemVMInitialParameters() : base(0)
        {
        }

        public BancoItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class BancoListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public BancoListVMInitialParameters() : base(0)
        {
        }

        public BancoListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class BancoListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public BancoListVMEventParameters() : base(false)
        { }

        public BancoListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public BancoListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
