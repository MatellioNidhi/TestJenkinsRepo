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
    public class LicenseTypeController : ControllerBase
    {
        private readonly ILicenseTypeService _licenseTypeService;
        public LicenseTypeController(ILicenseTypeService licenseTypeService)
        {
            _licenseTypeService = licenseTypeService;
        }
        
        // POST api/<LicenseTypeController>
        [HttpPost]
        [Route("CreateLicenseType")]
        public IActionResult CreateLicenseType([FromHeader(Name = "x-tenant")] string tenantid, [FromHeader(Name = "x-user")] string userId, [FromBody] LicenseTypeCreateRequest requestModel)
        {
            ErrorModel error = null;
            LicenseTypesResponse responseModel = null;
            try
            {
                //requestModel.UserId = userId;
                //requestModel.TenantId = tenantid;
                responseModel = _licenseTypeService.CreateLicenseTypes(requestModel, userId, tenantid);
                if (!string.IsNullOrEmpty(responseModel.id))
                    return Ok(responseModel);
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

        // GET: api/<LicenseTypeController>
        [HttpGet]
        [Route("GetLicenseTypes")]
        public IActionResult GetLicenseTypes([FromHeader(Name = "x-tenant")] string tenantid, [FromHeader(Name = "x-user")] string UserId, [FromHeader(Name = "x-id")] string[] LicenseTypeids)
        {
            ErrorModel error = null;
            List<LicenseTypesResponse> responseModelList = new List<LicenseTypesResponse>();

            try
            {
                responseModelList = _licenseTypeService.LicenseTypes(LicenseTypeids, tenantid, UserId);
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

        // PUT api/<LicenseTypeController>/5
        [HttpPut]
        [Route("UpdateLicenseType")]
        public IActionResult UpdateLicenseType([FromHeader(Name = "x-tenant")] string tenantid, [FromHeader(Name = "x-user")] string userId, [FromBody] LicenseTypeUpdateRequest requestModel)
        {
            ErrorModel error = null;
            LicenseTypesResponse responseModel = null;
            try
            {                
                responseModel = _licenseTypeService.UpdateLicenseTypes(requestModel, userId, tenantid);
                if (!string.IsNullOrEmpty(responseModel.id))
                    return Ok(responseModel);
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

        // DELETE api/<LicenseTypeController>/5
        [HttpDelete]
        [Route("DeleteLicenseType")]
        public IActionResult DeleteLicenseType([FromHeader(Name = "x-tenant")] string tenantid, [FromHeader(Name = "x-user")] string userId, [FromBody] LicenseTypeDeleteRequest requestModel)
        {
            ErrorModel error = null;
            bool responseModel;
            try
            {
                responseModel = _licenseTypeService.DeleteLicenseTypes(requestModel, userId, tenantid);
                if (responseModel)
                    return StatusCode((int)HttpStatusCode.OK);                
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

        // DELETE api/<LicenseTypeController>/5
        [HttpDelete]
        [Route("SetDeletedLicenseType")]
        public IActionResult SetDeletedLicenseType([FromHeader(Name = "x-tenant")] string tenantid, [FromHeader(Name = "x-user")] string userId, [FromBody] LicenseTypeDeleteRequest requestModel)
        {
            ErrorModel error = null;
            LicenseTypesResponse responseModel = null;
            try
            {
                responseModel = _licenseTypeService.SetDeletedLicenseTypes(requestModel, userId, tenantid);
                if (!string.IsNullOrEmpty(responseModel.id))
                    return Ok(responseModel);
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


        //// GET api/<LicenseTypeController>/5
        //[HttpGet]
        //[Route("GetLicenseTypeById")]
        //public string GetLicenseTypeById(int id)
        //{
        //    return "value";
        //}
    }
}
