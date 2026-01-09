
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

    public class Sat_configautotransporte_Controller : Base_Controller<Sat_configautotransporteController, Sat_configautotransporteBindingModel, Sat_configautotransporteParam>
    {


        public Sat_configautotransporte_Controller(
            Sat_configautotransporteController logicController) : base(logicController)
        {
        }
    




  }

}



