
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

    public class Tipodiferenciainventario_Controller : Base_Controller<TipodiferenciainventarioController, TipodiferenciainventarioBindingModel, TipodiferenciainventarioParam>
    {


        public Tipodiferenciainventario_Controller(
            TipodiferenciainventarioController logicController) : base(logicController)
        {
        }
    




  }

}



