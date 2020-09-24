using System;
using Inseego.Models.Request;
using Inseego.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Inseego.Models.Response;
using Inseego.Utils.Shared;
using Serilog;
using ErrorModel = Inseego.Utilities.Models.ErrorModel;
using System.Collections.Generic;

namespace VehicleMaintananceService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceTypeController : ControllerBase
    {
        private readonly IServiceTypeService _serviceTypeService;
        public ServiceTypeController(IServiceTypeService serviceTypeService)
        {
            _serviceTypeService = serviceTypeService;
        }
        
        // POST api/<ServiceTypeController>
        [HttpPost]
        [Route("CreateServiceType")]
        public IActionResult CreateServiceType([FromHeader(Name = "x-tenant")] string tenantid, [FromHeader(Name = "x-user")] string userId, [FromBody] ServiceTypeCreateRequest requestModel)
        {
            ErrorModel error = null;
            ServiceTypesResponse responseModel = null;
            try
            {
                //requestModel.UserId = userId;
                //requestModel.TenantId = tenantid;
                responseModel = _serviceTypeService.CreateServiceTypes(requestModel, userId, tenantid);
                if (!string.IsNullOrEmpty(responseModel.id))
                    return Ok(responseModel.id);
                else
                    return StatusCode((int)HttpStatusCode.BadRequest, requestModel);
            }
            catch (Exception ex)
            {
                //error = ExceptionHandler.GetErrorDetails(ex);
                Log.Error($"Search tasks request. {ex.ToString()}.");
                return StatusCode(error.Status, requestModel);
            }
        }

        // GET: api/<ServiceTypeController>
        [HttpGet]
        [Route("GetServiceTypes")]
        public IActionResult GetServiceTypes([FromHeader(Name = "x-tenant")] string tenantid, [FromHeader(Name = "x-user")] string UserId, [FromHeader(Name = "x-id")] string[] ServiceTypeids)
        {
            ErrorModel error = null;
            List<ServiceTypesResponse> responseModelList = new List<ServiceTypesResponse>();

            try
            {
                responseModelList = _serviceTypeService.ServiceTypes(ServiceTypeids, tenantid, UserId);
                if (responseModelList.Count > 0)
                    return Ok(responseModelList);
                else
                    return StatusCode((int)HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                //error = ExceptionHandler.GetErrorDetails(ex);
                Log.Error($"Search tasks request. {ex.ToString()}.");
                return StatusCode(error.Status);
            }
        }

        // PUT api/<ServiceTypeController>/5
        [HttpPut]
        [Route("UpdateServiceType")]
        public IActionResult UpdateServiceType([FromHeader(Name = "x-tenant")] string tenantid, [FromHeader(Name = "x-user")] string userId, [FromBody] ServiceTypeUpdateRequest requestModel)
        {
            ErrorModel error = null;
            ServiceTypesResponse responseModel = null;
            try
            {                
                responseModel = _serviceTypeService.UpdateServiceTypes(requestModel, userId, tenantid);
                if (!string.IsNullOrEmpty(responseModel.id))
                    return Ok("Service type Update :" + responseModel.id);
                else
                    return StatusCode((int)HttpStatusCode.BadRequest, requestModel);
            }
            catch (Exception ex)
            {
                //error = ExceptionHandler.GetErrorDetails(ex);
                Log.Error($"Search tasks request. {ex.ToString()}.");
                return StatusCode(error.Status, requestModel);
            }
        }

        // DELETE api/<ServiceTypeController>/5
        [HttpDelete]
        [Route("DeleteServiceType")]
        public IActionResult DeleteServiceType([FromHeader(Name = "x-tenant")] string tenantid, [FromHeader(Name = "x-user")] string userId, [FromBody] ServiceTypeDeleteRequest requestModel)
        {
            ErrorModel error = null;
            bool responseModel;
            try
            {
                responseModel = _serviceTypeService.DeleteServiceTypes(requestModel, userId, tenantid);
                if (responseModel)
                    return Ok("Service type Deleted from Collection :" + requestModel.id);
                else
                    return StatusCode((int)HttpStatusCode.BadRequest, requestModel);
            }
            catch (Exception ex)
            {
                //error = ExceptionHandler.GetErrorDetails(ex);
                Log.Error($"Search tasks request. {ex.ToString()}.");
                return StatusCode(error.Status, requestModel);
            }
        }

        // DELETE api/<ServiceTypeController>/5
        [HttpDelete]
        [Route("SetDeletedServiceType")]
        public IActionResult SetDeletedServiceType([FromHeader(Name = "x-tenant")] string tenantid, [FromHeader(Name = "x-user")] string userId, [FromBody] ServiceTypeDeleteRequest requestModel)
        {
            ErrorModel error = null;
            ServiceTypesResponse responseModel = null;
            try
            {
                responseModel = _serviceTypeService.SetDeletedServiceTypes(requestModel, userId, tenantid);
                if (!string.IsNullOrEmpty(responseModel.id))
                    return Ok("Service type Deleted from Collection :" + requestModel.id);
                else
                    return StatusCode((int)HttpStatusCode.BadRequest, requestModel);
            }
            catch (Exception ex)
            {
                //error = ExceptionHandler.GetErrorDetails(ex);
                Log.Error($"Search tasks request. {ex.ToString()}.");
                return StatusCode(error.Status, requestModel);
            }
        }


        //// GET api/<ServiceTypeController>/5
        //[HttpGet]
        //[Route("GetServiceTypeById")]
        //public string GetServiceTypeById(int id)
        //{
        //    return "value";
        //}
    }
}
