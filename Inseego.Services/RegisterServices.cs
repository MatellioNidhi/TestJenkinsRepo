using Inseego.Repositories.BlobStorage;
using Inseego.Repositories.CosmosDB;
using Inseego.Repositories.Postgres;
using Inseego.Repositories.ServiceClient;
using Inseego.Services.Implementation;
using Inseego.Services.Interface;
using Inseego.Utilities.CacheExtension;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Inseego.Services
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
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {

            
            services.AddTransient<ICommonDrillService, CommonDrillService>();
            services.AddTransient<IServicePlanService, ServicePlanService>();
            services.AddTransient<IServiceTypeService, ServiceTypesService>();
            services.AddTransient<ILicenseTypeService, LicenseTypesService>();

            services.AddSingleton(typeof(ICache<>), typeof(Cache<>));

            services.RegisterBlobStorageRepositories();
            services.RegisterPostgresRepositories();
            services.RegisterCosmosDBRepositories();
            services.RegisterServiceClientRepositories();


            return services;
        }
    }
}
