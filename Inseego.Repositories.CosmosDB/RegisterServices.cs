using Inseego.Repositories.CosmosDB.Implementation;
using Inseego.Repositories.CosmosDB.Interface;
using Inseego.Repositories.CosmosDB.Model;
using Microsoft.Extensions.DependencyInjection;


namespace Inseego.Repositories.CosmosDB
{
    /// <summary>
    /// Dependency Injection Module
    /// </summary>
    public static class RegisterServices
    {
        /// <summary>
        /// Dependencies for injection
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterCosmosDBRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICosmosDBOperationsRepository<ConsolidatedTripRecord>, CosmosDBOperationsRepository<ConsolidatedTripRecord>>();
            services.AddTransient<ICosmosDBOperationsRepository<Users>, CosmosDBOperationsRepository<Users>>();
            services.AddTransient<ICosmosDBOperationsRepository<Devices>, CosmosDBOperationsRepository<Devices>>();
            services.AddTransient<ICosmosDBOperationsRepository<ServicePlanModel>, CosmosDBOperationsRepository<ServicePlanModel>>();
            services.AddTransient<ICosmosDBOperationsRepository<ServiceTypesModel>, CosmosDBOperationsRepository<ServiceTypesModel>>();

            services.AddTransient<ICTRIndexFinalRepository, CTRIndexFinalRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IDevicesRepository, DevicesRepository>();
            
            return services;
        }
    }
}
