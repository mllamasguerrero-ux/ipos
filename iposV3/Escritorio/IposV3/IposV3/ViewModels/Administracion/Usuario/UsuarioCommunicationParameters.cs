
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class UsuarioItemVMInitialParameters : BaseCommonInitialParameters
    {

        public UsuarioItemVMInitialParameters() : base(0)
        {
        }

        public UsuarioItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class UsuarioListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public UsuarioListVMInitialParameters() : base(0)
        {
        }

        public UsuarioListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class UsuarioListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public UsuarioListVMEventParameters() : base(false)
        { }

        public UsuarioListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public UsuarioListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
