
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class Sucursal_infoItemVMInitialParameters : BaseCommonInitialParameters
    {

        public Sucursal_infoItemVMInitialParameters() : base(0)
        {
        }

        public Sucursal_infoItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class Sucursal_infoListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public Sucursal_infoListVMInitialParameters() : base(0)
        {
        }

        public Sucursal_infoListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class Sucursal_infoListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public Sucursal_infoListVMEventParameters() : base(false)
        { }

        public Sucursal_infoListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public Sucursal_infoListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
