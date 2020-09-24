using Inseego.Repositories.Postgres.Implementation;
using Inseego.Repositories.Postgres.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Inseego.Repositories.Postgres
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
        public static IServiceCollection RegisterPostgresRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICommonDrillRepository, CommonDrillRepository>();
            return services;
        }
    }
}
