
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class Motivo_camfecItemVMInitialParameters : BaseCommonInitialParameters
    {

        public Motivo_camfecItemVMInitialParameters() : base(0)
        {
        }

        public Motivo_camfecItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class Motivo_camfecListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public Motivo_camfecListVMInitialParameters() : base(0)
        {
        }

        public Motivo_camfecListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class Motivo_camfecListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public Motivo_camfecListVMEventParameters() : base(false)
        { }

        public Motivo_camfecListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public Motivo_camfecListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
