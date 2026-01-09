
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class EstadopagocontrareciboItemVMInitialParameters : BaseCommonInitialParameters
    {

        public EstadopagocontrareciboItemVMInitialParameters() : base(0)
        {
        }

        public EstadopagocontrareciboItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class EstadopagocontrareciboListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public EstadopagocontrareciboListVMInitialParameters() : base(0)
        {
        }

        public EstadopagocontrareciboListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class EstadopagocontrareciboListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public EstadopagocontrareciboListVMEventParameters() : base(false)
        { }

        public EstadopagocontrareciboListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public EstadopagocontrareciboListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
