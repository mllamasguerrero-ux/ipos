using Controllers.BindingModel;
using IposV3.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingModels
{
    public interface IBaseBindingModel
    {


        long? EmpresaId { get; set; }

        long? SucursalId { get; set; }

        long? Id { get; set; }

        DateTimeOffset? Creado { get; set; }

        long? CreadoPorId { get; set; }

        DateTimeOffset? Modificado { get; set; }

        long? ModificadoPorId { get; set; }

        void Validate();

        event AcceptPendingChangeHandler PendingChange;

        event PropertyChangedEventHandler PropertyChanged;




    }


    public interface IBaseGenericBindingModel
    {



        long? Id { get; set; }

        DateTimeOffset? Creado { get; set; }


        DateTimeOffset? Modificado { get; set; }


        void Validate();

        event AcceptPendingChangeHandler PendingChange;

    }

    public interface IBaseCommandBindingModel
    {



        void Validate();

        event AcceptPendingChangeHandler PendingChange;

    }
}
