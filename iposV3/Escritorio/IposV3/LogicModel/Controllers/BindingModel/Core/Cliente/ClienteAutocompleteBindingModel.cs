
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IposV3.Model;
using MvvmFramework;
using System.Xml.Serialization;

namespace BindingModels
{
    public class ClienteAutocompleteBindingModel
    {

        public ClienteAutocompleteBindingModel() { }


        #if PROYECTO_WEB
        public ClienteAutocompleteBindingModel(Cliente cliente)
        {

            Id = cliente.Id;
            Text = (cliente.Nombre + " <((" + cliente.Clave.ToString().Trim() + "))>");

        }
        #endif



        #if PROYECTO_ESCRITORIO
        public ClienteAutocompleteBindingModel(ClienteBindingModel cliente)
        {

            Id = cliente.Id;
            Text = (cliente.Nombre + " <((" + cliente.Clave!.ToString().Trim() + "))>");

        }
        #endif





        public string? Text { get; set; }
        public long? Id { get; set; }
    }
}
