
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class Sat_unidadmedidaItemVMInitialParameters : BaseCommonInitialParameters
    {

        public Sat_unidadmedidaItemVMInitialParameters() : base(0)
        {
        }

        public Sat_unidadmedidaItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class Sat_unidadmedidaListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public Sat_unidadmedidaListVMInitialParameters() : base(0)
        {
        }

        public Sat_unidadmedidaListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class Sat_unidadmedidaListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public Sat_unidadmedidaListVMEventParameters() : base(false)
        { }

        public Sat_unidadmedidaListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public Sat_unidadmedidaListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
