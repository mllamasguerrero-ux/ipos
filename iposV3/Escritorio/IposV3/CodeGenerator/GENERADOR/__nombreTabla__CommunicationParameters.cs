|||||100+++++
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class (nombreTabla)ItemVMInitialParameters : BaseCommonInitialParameters
    {

        public (nombreTabla)ItemVMInitialParameters() : base(0)
        {
        }

        public (nombreTabla)ItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class (nombreTabla)ListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public (nombreTabla)ListVMInitialParameters() : base(0)
        {
        }

        public (nombreTabla)ListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class (nombreTabla)ListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public (nombreTabla)ListVMEventParameters() : base(false)
        { }

        public (nombreTabla)ListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public (nombreTabla)ListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
!!!!!
100;0;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;IGNORAR;0;IGNORAR;IGNORAR;IGNORAR;IGNORAR
