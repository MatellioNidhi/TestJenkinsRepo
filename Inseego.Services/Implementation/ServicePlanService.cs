using Inseego.Models.Enumerators;
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
        private IServicePlanRepository _servicePlanRepository;
        private readonly string servicePlanCollectionId = "ServicePlan";
        public ServicePlanService(ICosmosDBOperationsRepository<ServicePlanModel> cosmosDBOperationsRepository, IServicePlanRepository servicePlanRepository)
        {
            _cosmosDBOperationsRepository = cosmosDBOperationsRepository;
            _servicePlanRepository = servicePlanRepository;
        }
        /// <summary>
        /// Save service Plan data
        /// </summary>
        /// <param name="servicePlanRequest"></param>
        /// <param name="tenantId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ServicePlanModel> SaveServicePlan(ServicePlanRequest servicePlanRequest, string tenantId, string userId)
        {
            ServicePlanModel servicePlanModel = new ServicePlanModel();
            CommonFunctions.CopyProperties(servicePlanRequest, servicePlanModel);
            CommonFunctions.CopyProperties(servicePlanRequest.WorkShopDetail, servicePlanModel.WorkShopDetail);
            CommonFunctions.CopyProperties(servicePlanRequest.ServiceInterval, servicePlanModel.ServiceInterval);
            CommonFunctions.CopyProperties(servicePlanRequest.ScheduleService, servicePlanModel.ScheduleService);
            CommonFunctions.CopyProperties(servicePlanRequest.Notify, servicePlanModel.Notify);
            servicePlanModel.CreatedBy = userId;
            servicePlanModel.CreatedOn = DateTime.Now;
            servicePlanModel.IsActive = true;
            servicePlanModel.IsDeleted = false;
            servicePlanModel.tenantId = tenantId;
            // await _cosmosDBOperationsRepository.CreateCollectionIfNotExistsAsync(servicePlanCollectionId);
            servicePlanModel = await _cosmosDBOperationsRepository.AddDocumentIntoCollectionAsync(servicePlanModel, userId, tenantId, servicePlanCollectionId);
            return servicePlanModel;
        }
        /// <summary>
        /// Get data of service plan
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<ServicePlanModel>> GetServicePlans(string tenantId, string userId, string id)
        {
            string whereClause = string.Empty;
            if (!string.IsNullOrEmpty(id))
                whereClause = " WHERE Tasks.IsActive=true and Tasks.IsDeleted=false and Tasks.id= '" + id + "'";
            List<ServicePlanModel> listServicePlan = await _servicePlanRepository.GetData(whereClause, tenantId);
            return listServicePlan;
        }

        public async Task<bool> DeleteServicePlan(string[] ids, string tenantId, string userId)
        {
            bool result = await _servicePlanRepository.DeleteData(ids, tenantId, string.Empty);
            return result;
        }
        public async Task<ServicePlanModel> UpdateServicePlan(string tenantId, string userId, ServicePlanRequest servicePlanRequest)
        {
            ServicePlanModel servicePlanModel = new ServicePlanModel();
            CommonFunctions.CopyProperties(servicePlanRequest, servicePlanModel);
            CommonFunctions.CopyProperties(servicePlanRequest.WorkShopDetail, servicePlanModel.WorkShopDetail);
            CommonFunctions.CopyProperties(servicePlanRequest.ServiceInterval, servicePlanModel.ServiceInterval);
            CommonFunctions.CopyProperties(servicePlanRequest.ScheduleService, servicePlanModel.ScheduleService);
            CommonFunctions.CopyProperties(servicePlanRequest.Notify, servicePlanModel.Notify);
            servicePlanModel = await _servicePlanRepository.UpdateServicePlan(tenantId, userId, servicePlanModel);
            return servicePlanModel;
        }

        public async Task<ServicePlanModel> UpdateServicePlanStatus(string tenantId, string userId, string id, ServicePlanStatus servicePlanStatus)
        {
            ServicePlanModel servicePlanModel = await _servicePlanRepository.UpdateServicePlanStatus(tenantId, userId, id, (int)servicePlanStatus);
            return servicePlanModel;
        }

        private DateTime GetNextDate(bool timeLapse, string currentServiceDate, int nextServiceDay)
        {
            DateTime nextServiceDate = DateTime.Now;
            if (timeLapse)
            {
                DateTime dt = Convert.ToDateTime(currentServiceDate);
                nextServiceDate = dt.AddDays(nextServiceDay);
            }
            return nextServiceDate;
        }

    }
}
