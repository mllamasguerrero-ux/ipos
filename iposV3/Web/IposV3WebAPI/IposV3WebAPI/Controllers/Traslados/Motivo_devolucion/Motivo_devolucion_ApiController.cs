
using BindingModels;
using Controllers.Controller;
using IposV3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using ApiParam;

#pragma warning disable 1998
namespace IposV3WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class Motivo_devolucion_Controller : Base_Controller<Motivo_devolucionController, Motivo_devolucionBindingModel, Motivo_devolucionParam>
    {


        public Motivo_devolucion_Controller(
            Motivo_devolucionController logicController) : base(logicController)
        {
        }
    




  }

}



