
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class Docto_pedido_entradaItemVMInitialParameters : BaseCommonInitialParameters
    {

        public Docto_pedido_entradaItemVMInitialParameters() : base(0)
        {
        }

        public Docto_pedido_entradaItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class Docto_pedido_entradaListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public Docto_pedido_entradaListVMInitialParameters() : base(0)
        {
        }

        public Docto_pedido_entradaListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class Docto_pedido_entradaListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public Docto_pedido_entradaListVMEventParameters() : base(false)
        { }

        public Docto_pedido_entradaListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public Docto_pedido_entradaListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
