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
    }
}
