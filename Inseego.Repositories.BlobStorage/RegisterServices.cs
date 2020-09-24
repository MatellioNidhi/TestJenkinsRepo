using Microsoft.Extensions.DependencyInjection;

namespace Inseego.Repositories.BlobStorage
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
        public static IServiceCollection RegisterBlobStorageRepositories(this IServiceCollection services)
        {
            //services.AddTransient<ITemplateRepository, TemplateRepository>();
            return services;
        }
    }
}
