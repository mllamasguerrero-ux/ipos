
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

    public class Sat_usocfdi_Controller : Base_Controller<Sat_usocfdiController, Sat_usocfdiBindingModel, Sat_usocfdiParam>
    {


        public Sat_usocfdi_Controller(
            Sat_usocfdiController logicController) : base(logicController)
        {
        }
    




  }

}



