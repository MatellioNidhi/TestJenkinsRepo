using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Http;
using System;

namespace VehicleMaintananceService.API.Controllers
{
    /// <summary>
    /// Dashboard Controller
    /// </summary>
    //[EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    //  [Authorize]
    public class DashboardController : ControllerBase
    {
        
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dashboardService">Dashboard Service</param>
        public DashboardController( IHttpContextAccessor httpContextAccessor)
        {
           
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Request template 
        /// </summary>
        /// <param name="templateRequest">Dashboard Request Payload</param>
        /// <returns></returns>
        //[HttpPost]
        ////[SwaggerResponse(200, "RequestId", typeof(Models.TemplateResponse))]
        //[SwaggerResponse(400, "Input Error", typeof(Dictionary<string, string[]>))]
        //[SwaggerResponse(404, "No template found")]
        //[SwaggerResponse(500, "Internal unknown error, system administrator should be contacted")]
        //public async Task<IActionResult> RequestTemplateById([FromBody] DashboardRequest dashboardRequest, [FromHeader(Name = "x-tenant")] string tenantid, [FromHeader(Name = "x-user")] string userId)
        //{
        //    var response = await _dashboardService.GetDashbordByUserId(dashboardRequest, tenantid, userId);
        //    return Ok(response);
        //}

        //[HttpGet]
        //[SwaggerResponse(400, "Input Error", typeof(Dictionary<string, string[]>))]
        //[SwaggerResponse(404, "No template found")]
        //[SwaggerResponse(500, "Internal unknown error, system administrator should be contacted")]
        //public async Task<IActionResult> GetHeaderDashboadListByUserId([FromHeader(Name = "x-tenant")] string tenantid, [FromHeader(Name = "Ocp-Apim-Subscription-Key")] string subscription)
        //{
        //    string Tenant = _httpContextAccessor.HttpContext.Request.Headers["x-tenant"].ToString();
        //    string SubscriptionKey = _httpContextAccessor.HttpContext.Request.Headers["Ocp-Apim-Subscription-Key"].ToString();
        //    var response = await _dashboardService.GetDefaultDashboard(new System.Guid(), Tenant, SubscriptionKey);
        //    return Ok(response);
        //}

        //[HttpPost]
        //[Route("InsertUpdateCustomDashboard")]
        //[SwaggerResponse(400, "Input Error", typeof(Dictionary<string, string[]>))]
        //[SwaggerResponse(404, "No template found")]
        //[SwaggerResponse(500, "Internal unknown error, system administrator should be contacted")]
        //public async Task<IActionResult> InsertUpdateCustomDashboard([FromBody]CustomDashboardRequest customDashboardRequest)
        //{
        //    try
        //    {
        //        var response = await _dashboardService.RequestInsertUpdateCustomDashboard(customDashboardRequest);
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(ex);
        //    }
        //}
    }
}