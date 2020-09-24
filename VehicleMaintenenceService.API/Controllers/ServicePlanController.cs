using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inseego.Models.Request;
using Inseego.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehicleMaintananceService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicePlanController : ControllerBase
    {
        private readonly IServicePlanService _servicePlanService;

        public ServicePlanController(IServicePlanService servicePlanService)
        {
            _servicePlanService = servicePlanService;
        }

        //[HttpGet]
        //[SwaggerResponse(400, "Input Error", typeof(Dictionary<string, string[]>))]
        //[SwaggerResponse(404, "No template found")]
        //[SwaggerResponse(500, "Internal unknown error, system administrator should be contacted")]
        //public ActionResult Get([FromHeader(Name = "x-tenant")] string tenantid, [FromHeader(Name = "Ocp-Apim-Subscription-Key")] string subscription, [FromHeader(Name = "x-user")] string userId)
        //{
        //    //var data = _servicePlanService.SaveServicePlan(tenantid, userId);
        //    //return Ok(data);
        //}

        // POST api/<ServicePlanController>
        [HttpPost]
        [SwaggerResponse(400, "Input Error", typeof(Dictionary<string, string[]>))]
        [SwaggerResponse(404, "No template found")]
        [SwaggerResponse(500, "Internal unknown error, system administrator should be contacted")]
        public ActionResult Post([FromHeader(Name = "x-tenant")] string tenantid, [FromHeader(Name = "Ocp-Apim-Subscription-Key")] string subscription, [FromHeader(Name = "x-user")] string userId, [FromBody] ServicePlanRequest servicePlanRequest)
        {
            var data = _servicePlanService.SaveServicePlan(servicePlanRequest, tenantid, userId);
            return Ok(data);
        }

       
    }
}
