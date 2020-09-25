using Inseego.Repositories.CosmosDB.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Inseego.Repositories.CosmosDB.Interface
{
   public interface IServicePlanRepository
    {
        Task<List<ServicePlanModel>> GetData(string whereQuery, string partition);
        Task<bool> DeleteData(string[] ids, string partition, string userId);
        Task<ServicePlanModel> UpdateServicePlan(string partition, string userId, ServicePlanModel servicePlanModel);
        Task<ServicePlanModel> UpdateServicePlanStatus(string partition, string userId, string id, int servicePlanStatus);
    }
}
