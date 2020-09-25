using Inseego.Repositories.CosmosDB.Interface;
using Inseego.Repositories.CosmosDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inseego.Repositories.CosmosDB.Implementation
{
    public class ServicePlanRepository : IServicePlanRepository
    {
        private readonly ICosmosDBOperationsRepository<ServicePlanModel> _cosmosDBOperationsRepository;
        private readonly string collectionId = "ServicePlan";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cosmosDBOperationsRepository"></param>
        public ServicePlanRepository(ICosmosDBOperationsRepository<ServicePlanModel> cosmosDBOperationsRepository)
        {
            _cosmosDBOperationsRepository = cosmosDBOperationsRepository;
        }

        public async Task<List<ServicePlanModel>> GetData(string whereQuery, string partition)
        {
            try
            {
                var response = await _cosmosDBOperationsRepository.GetItemsByQueryFromCollectionAsync(whereQuery, partition, collectionId, true);
                return response;
            }
            catch (Exception e)
            {
                Inseego.Utils.Shared.ExceptionHandler.LogException("GetData had an issue", e);
                throw;
            }
        }

        public async Task<bool> DeleteData(string[] ids, string partition, string userId)
        {
            try
            {
                if (ids.Any())
                {
                    foreach (var id in ids)
                    {
                        ServicePlanModel servicePlan = await _cosmosDBOperationsRepository.GetItemFromCollectionAsync(id, partition, collectionId);
                        if (servicePlan != null)
                        {
                            servicePlan.IsDeleted = true;
                            servicePlan.ModifiedBy = userId;
                            servicePlan.ModifiedOn = DateTime.Now;
                            var response = await _cosmosDBOperationsRepository.UpdateDocumentFromCollection(id, servicePlan, partition, collectionId);
                        }
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Inseego.Utils.Shared.ExceptionHandler.LogException("DeleteData had an issue", e);
                throw;
            }
        }

        public async Task<ServicePlanModel> UpdateServicePlan(string partition, string userId, ServicePlanModel servicePlanModel)
        {
            string whereClause = " WHERE Tasks.id= '" + servicePlanModel.id + "'";
            ServicePlanModel servicePlan = new ServicePlanModel();
            var services = await _cosmosDBOperationsRepository.GetItemsByQueryFromCollectionAsync(whereClause, partition, collectionId);
            if (services != null)
            {
                servicePlan = services[0];
            }
            if (servicePlan != null)
            {
                servicePlan.ServicePlanName = servicePlanModel.ServicePlanName;
                servicePlan.ServiceTypeId = servicePlanModel.ServiceTypeId;
                servicePlan.VehicleId = servicePlanModel.VehicleId;
                servicePlan.WorkShopDetail = servicePlanModel.WorkShopDetail;
                servicePlan.ServiceInterval = servicePlanModel.ServiceInterval;
                servicePlan.ScheduleService = servicePlanModel.ScheduleService;
                servicePlan.Notify = servicePlanModel.Notify;
                servicePlan.ModifiedBy = userId;
                servicePlan.ModifiedOn = DateTime.Now;
                servicePlan = await _cosmosDBOperationsRepository.UpdateDocumentFromCollection(servicePlan.id, servicePlan, partition, collectionId);
            }
            return servicePlan;
        }

        public async Task<ServicePlanModel> UpdateServicePlanStatus(string partition, string userId, string id, int servicePlanStatus)
        {
            ServicePlanModel servicePlan = await _cosmosDBOperationsRepository.GetItemFromCollectionAsync(id, partition, collectionId);
            if (servicePlan != null)
            {
                servicePlan.ServicePlanStatus = servicePlanStatus;
                servicePlan.ModifiedBy = userId;
                servicePlan.ModifiedOn = DateTime.Now;
                servicePlan = await _cosmosDBOperationsRepository.UpdateDocumentFromCollection(servicePlan.id, servicePlan, partition, collectionId);
            }
            return servicePlan;
        }
    }
}
