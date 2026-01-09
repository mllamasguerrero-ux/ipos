
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

    public class Maxfact_Controller : Base_Controller<MaxfactController, MaxfactBindingModel, MaxfactParam>
    {


        public Maxfact_Controller(
            MaxfactController logicController) : base(logicController)
        {
        }
    




  }

}



