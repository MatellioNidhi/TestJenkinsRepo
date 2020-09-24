using Inseego.Models.Request;
using Inseego.Repositories.CosmosDB.Interface;
using Inseego.Repositories.CosmosDB.Model;
using Inseego.Services.Interface;
using Inseego.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inseego.Services.Implementation
{
    public class ServicePlanService : IServicePlanService
    {
        private ICosmosDBOperationsRepository<ServicePlanModel> _cosmosDBOperationsRepository;
        private readonly string servicePlanCollectionId = "ServicePlan";
        public ServicePlanService(ICosmosDBOperationsRepository<ServicePlanModel> cosmosDBOperationsRepository)
        {
            _cosmosDBOperationsRepository = cosmosDBOperationsRepository;
        }
        public async Task<ServicePlanModel> SaveServicePlan(ServicePlanRequest servicePlanRequest, string tenantId, string userId)
        {
            ServicePlanModel servicePlanModel = new ServicePlanModel();
            CommonFunctions.CopyProperties(servicePlanRequest, servicePlanModel);
            await _cosmosDBOperationsRepository.CreateCollectionIfNotExistsAsync(servicePlanCollectionId);
            servicePlanModel = _cosmosDBOperationsRepository.AddDocumentIntoCollectionAsync(servicePlanModel, userId, tenantId, servicePlanCollectionId).Result;
            return servicePlanModel;
        }
        

    }
}
