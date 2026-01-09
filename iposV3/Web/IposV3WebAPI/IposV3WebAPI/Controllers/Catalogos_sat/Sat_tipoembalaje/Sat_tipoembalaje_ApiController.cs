
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

    public class Sat_tipoembalaje_Controller : Base_Controller<Sat_tipoembalajeController, Sat_tipoembalajeBindingModel, Sat_tipoembalajeParam>
    {


        public Sat_tipoembalaje_Controller(
            Sat_tipoembalajeController logicController) : base(logicController)
        {
        }
    




  }

}



