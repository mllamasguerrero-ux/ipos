
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BindingModels;

namespace IposV3.ViewModels
{

    public class TipodiferenciainventarioItemVMInitialParameters : BaseCommonInitialParameters
    {

        public TipodiferenciainventarioItemVMInitialParameters() : base(0)
        {
        }

        public TipodiferenciainventarioItemVMInitialParameters(long? Id) : base(Id)
        {
        }
    }


    public class TipodiferenciainventarioListVMInitialParameters : BaseCommonInitialParameters
    {
        public bool OnlyForSelection { get; set; }

        public TipodiferenciainventarioListVMInitialParameters() : base(0)
        {
        }

        public TipodiferenciainventarioListVMInitialParameters(bool onlyForSelection) : base(0)
        {
            OnlyForSelection = onlyForSelection;
        }
    }


    public class TipodiferenciainventarioListVMEventParameters : BaseListVMEventParameters //BaseCommonInitialParameters
    {

        
        public TipodiferenciainventarioListVMEventParameters() : base(false)
        { }

        public TipodiferenciainventarioListVMEventParameters(bool isReloadEvent) : base(isReloadEvent)
        { }

        public TipodiferenciainventarioListVMEventParameters(bool isReloadEvent, bool hasMessage, MessageToUserSimple msgSimple) : base(isReloadEvent,hasMessage,msgSimple)
        { }
    }



}
