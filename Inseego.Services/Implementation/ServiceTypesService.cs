using System;
using System.Collections.Generic;
using Inseego.Services.Interface;
using Inseego.Models.Request;
using Inseego.Models.Response;
using System.Threading.Tasks;
using Inseego.Repositories.CosmosDB.Model;
using Inseego.Repositories.CosmosDB.Interface;
using Inseego.Utilities;
using System.Linq;

namespace Inseego.Services.Implementation
{
    public class ServiceTypesService : IServiceTypeService
    {
        private ICosmosDBOperationsRepository<ServiceTypesModel> _cosmosDBOperationsRepository;
        private readonly string servicePlanTypeCollectionId = "ServicePlanType";

        public ServiceTypesService(ICosmosDBOperationsRepository<ServiceTypesModel> cosmosDBOperationsRepository)
        {
            _cosmosDBOperationsRepository = cosmosDBOperationsRepository;
        }
        public ServiceTypesResponse CreateServiceTypes(ServiceTypeCreateRequest request, string UserId, string TenantId)
        {
            ServiceTypesResponse responseModel = new ServiceTypesResponse();
            ServiceTypesModel serviceTypesModel = new ServiceTypesModel();

            serviceTypesModel.serviceTypeName = request.ServiceTypeName;

            serviceTypesModel.userId = UserId;
            serviceTypesModel.tenantId = TenantId;

            serviceTypesModel.createdBy = UserId;
            serviceTypesModel.createdDate = DateTime.UtcNow;

            serviceTypesModel.modifiedBy = UserId;
            serviceTypesModel.modifiedDate = DateTime.UtcNow;
                        
            serviceTypesModel.isActive = true;
            serviceTypesModel.isDeleted = false;

            //// Run below line First time only
            //_cosmosDBOperationsRepository.CreateCollectionIfNotExistsAsync(servicePlanTypeCollectionId);

            ServiceTypesModel result = _cosmosDBOperationsRepository.AddDocumentIntoCollectionAsync(serviceTypesModel, UserId.Trim().ToString(), TenantId, servicePlanTypeCollectionId).Result;
            CommonFunctions.CopyProperties(result, responseModel);
            return responseModel;
        }

        public List<ServiceTypesResponse> ServiceTypes(string[] ServiceTypeids, string TenantId, string UserId)
        {
            string where = string.Empty;
            string selectLocationQuery = string.Empty;

            List<ServiceTypesResponse> response = new List<ServiceTypesResponse>();
            if (ServiceTypeids.Contains("all"))
            {
                selectLocationQuery = $"SELECT * FROM c where c.tenantId='" + TenantId + "' and c.userId='" + UserId + "' order by c.createdDate desc";                
            }
            else
            {
                selectLocationQuery = $"SELECT * FROM c where c.id in ('" + String.Join(",", ServiceTypeids) + "') and c.tenantId='" + TenantId + "' and c.userId='" + UserId + "' order by c.createdDate desc";
            }
            List<ServiceTypesModel> data = _cosmosDBOperationsRepository.GetItemsByQueryFromCollectionAsync<ServiceTypesModel>(selectLocationQuery, where, TenantId, servicePlanTypeCollectionId).Result;
            if (data != null && data.Count != 0)
            {
                foreach (var item in data)
                {
                    ServiceTypesResponse idata = new ServiceTypesResponse();
                    CommonFunctions.CopyProperties(item, idata);
                    response.Add(idata);
                }
            }
            return response;    //?.FirstOrDefault();
        }       

        public ServiceTypesResponse UpdateServiceTypes(ServiceTypeUpdateRequest request, string UserId, string TenantId)
        {
            ServiceTypesResponse responseModel = new ServiceTypesResponse();
            ServiceTypesModel serviceTypesModel = new ServiceTypesModel();

            serviceTypesModel.id = request.id;
            serviceTypesModel.serviceTypeName = request.ServiceTypeName;

            //serviceTypesModel.userId = UserId;
            //serviceTypesModel.tenantId = TenantId;

            serviceTypesModel.modifiedBy = UserId;
            serviceTypesModel.modifiedDate = DateTime.UtcNow;

            ServiceTypesModel result = _cosmosDBOperationsRepository.UpdateDocumentFromCollection(request.id, serviceTypesModel, TenantId, servicePlanTypeCollectionId).Result;
            CommonFunctions.CopyProperties(result, responseModel);
            return responseModel;
        }

        public bool DeleteServiceTypes(ServiceTypeDeleteRequest request, string UserId, string TenantId)
        {
            ServiceTypesResponse responseModel = new ServiceTypesResponse();
            ServiceTypesModel serviceTypesModel = new ServiceTypesModel();

            bool result = _cosmosDBOperationsRepository.DeleteDocumentFromCollectionAsync(request.id, TenantId, servicePlanTypeCollectionId).Result;
            return result;
        }

        public ServiceTypesResponse SetDeletedServiceTypes(ServiceTypeDeleteRequest request, string UserId, string TenantId)
        {
            ServiceTypesResponse responseModel = new ServiceTypesResponse();
            ServiceTypesModel serviceTypesModel = new ServiceTypesModel();

            serviceTypesModel.id = request.id;

            serviceTypesModel.isActive = false;
            serviceTypesModel.isDeleted = true;

            serviceTypesModel.modifiedBy = UserId;
            serviceTypesModel.modifiedDate = DateTime.UtcNow;

            ServiceTypesModel result = _cosmosDBOperationsRepository.UpdateDocumentFromCollection(request.id, serviceTypesModel, TenantId, servicePlanTypeCollectionId).Result;
            CommonFunctions.CopyProperties(result, responseModel);
            return responseModel;
        }
    }
}
