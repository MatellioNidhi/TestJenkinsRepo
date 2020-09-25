using Inseego.Models.Enumerators;
using Inseego.Models.Request;
using Inseego.Repositories.CosmosDB.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inseego.Services.Interface
{
    public interface IServicePlanService
    {
        Task<ServicePlanModel> SaveServicePlan(ServicePlanRequest servicePlanRequest, string tenantId, string userId);
        Task<List<ServicePlanModel>> GetServicePlans(string tenantId, string userId, string id);
        Task<bool> DeleteServicePlan(string[] ids, string tenantId, string userId);
        Task<ServicePlanModel> UpdateServicePlan(string tenantId, string userId, ServicePlanRequest servicePlanRequest);
        Task<ServicePlanModel> UpdateServicePlanStatus(string tenantId, string userId, string id, ServicePlanStatus servicePlanStatus);
    }
}
