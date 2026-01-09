
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
    public class ProductoAutocompleteBindingModel
    {

        public ProductoAutocompleteBindingModel() { }

        #if PROYECTO_WEB
        public ProductoAutocompleteBindingModel(Producto producto)
        {

            Id = producto.Id;
            Text = (producto.Descripcion1 + " <((" + producto.Clave.ToString().Trim() + "))>");

        }
        #endif


        #if PROYECTO_ESCRITORIO
        public ProductoAutocompleteBindingModel(ProductoBindingModel producto)
        {

            Id = producto.Id;
            Text = (producto.Descripcion1 + " <((" + producto.Clave!.ToString().Trim() + "))>");

        }
        #endif





        public string? Text { get; set; }
        public long? Id { get; set; }
    }
}
