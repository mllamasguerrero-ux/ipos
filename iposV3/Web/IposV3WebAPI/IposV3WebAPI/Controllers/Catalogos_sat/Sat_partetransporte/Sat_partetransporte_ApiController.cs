
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

    public class Sat_partetransporte_Controller : Base_Controller<Sat_partetransporteController, Sat_partetransporteBindingModel, Sat_partetransporteParam>
    {


        public Sat_partetransporte_Controller(
            Sat_partetransporteController logicController) : base(logicController)
        {
        }
    




  }

}



