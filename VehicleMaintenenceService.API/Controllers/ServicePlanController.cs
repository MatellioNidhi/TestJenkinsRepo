using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inseego.Models.Enumerators;
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
        /// <summary>
        /// Get api for Service Plan data 
        /// </summary>
        /// <param name="tenantid"></param>
        /// <param name="subscription"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(400, "Input Error", typeof(Dictionary<string, string[]>))]
        [SwaggerResponse(404, "No template found")]
        [SwaggerResponse(500, "Internal unknown error, system administrator should be contacted")]
        public async Task<ActionResult> Get([FromHeader(Name = "x-tenant")] string tenantid, [FromHeader(Name = "Ocp-Apim-Subscription-Key")] string subscription, [FromHeader(Name = "x-user")] string userId, string id)
        {
            var data = await _servicePlanService.GetServicePlans(tenantid, userId, id);
            if (!string.IsNullOrEmpty(id))
                return Ok(data[0]);
            return Ok(data);
        }

        /// <summary>
        /// post api for service plan
        /// </summary>
        /// <param name="tenantid"></param>
        /// <param name="subscription"></param>
        /// <param name="userId"></param>
        /// <param name="servicePlanRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerResponse(400, "Input Error", typeof(Dictionary<string, string[]>))]
        [SwaggerResponse(404, "No template found")]
        [SwaggerResponse(500, "Internal unknown error, system administrator should be contacted")]
        public async Task<ActionResult> Post([FromHeader(Name = "x-tenant")] string tenantid, [FromHeader(Name = "Ocp-Apim-Subscription-Key")] string subscription, [FromHeader(Name = "x-user")] string userId, [FromBody] ServicePlanRequest servicePlanRequest)
        {
            var data = await _servicePlanService.SaveServicePlan(servicePlanRequest, tenantid, userId);
            return Ok(data);
        }

        /// <summary>
        /// Delete api to delete service plan
        /// </summary>
        /// <param name="tenantid"></param>
        /// <param name="subscription"></param>
        /// <param name="userId"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete]
        [SwaggerResponse(400, "Input Error", typeof(Dictionary<string, string[]>))]
        [SwaggerResponse(404, "No template found")]
        [SwaggerResponse(500, "Internal unknown error, system administrator should be contacted")]
        public async Task<ActionResult> Delete([FromHeader(Name = "x-tenant")] string tenantid, [FromHeader(Name = "Ocp-Apim-Subscription-Key")] string subscription, [FromHeader(Name = "x-user")] string userId, string[] ids)
        {
            var data = await _servicePlanService.DeleteServicePlan(ids, tenantid, userId);
            return Ok(data);
        }

        /// <summary>
        /// Update Service Plan
        /// </summary>
        /// <param name="tenantid"></param>
        /// <param name="subscription"></param>
        /// <param name="userId"></param>
        /// <param name="servicePlanRequest"></param>
        /// <returns></returns>
        [HttpPut]
        [SwaggerResponse(400, "Input Error", typeof(Dictionary<string, string[]>))]
        [SwaggerResponse(404, "No template found")]
        [SwaggerResponse(500, "Internal unknown error, system administrator should be contacted")]
        public async Task<ActionResult> Put([FromHeader(Name = "x-tenant")] string tenantid, [FromHeader(Name = "Ocp-Apim-Subscription-Key")] string subscription, [FromHeader(Name = "x-user")] string userId, [FromBody] ServicePlanRequest servicePlanRequest)
        {
            var data = await _servicePlanService.UpdateServicePlan(tenantid, userId, servicePlanRequest);
            return Ok(data);
        }
        /// <summary>
        /// Change Service Plan Status
        /// </summary>
        /// <param name="tenantid"></param>
        /// <param name="subscription"></param>
        /// <param name="userId"></param>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPut("UpdateStatus/{id}")]
        [SwaggerResponse(400, "Input Error", typeof(Dictionary<string, string[]>))]
        [SwaggerResponse(404, "No template found")]
        [SwaggerResponse(500, "Internal unknown error, system administrator should be contacted")]
        public async Task<ActionResult> UpdateStatus([FromHeader(Name = "x-tenant")] string tenantid, [FromHeader(Name = "Ocp-Apim-Subscription-Key")] string subscription, [FromHeader(Name = "x-user")] string userId, string id, ServicePlanStatus status)
        {
            var data = await _servicePlanService.UpdateServicePlanStatus(tenantid, userId, id, status);
            return Ok(data);
        }

    }
}
