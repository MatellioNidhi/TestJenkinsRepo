using Inseego.Repositories.ServiceClient.Implementation;
using Inseego.Repositories.ServiceClient.Interface;
using Inseego.Utilities.Constants;
using Inseego.Utilities.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace Inseego.Repositories.ServiceClient
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
        public static IServiceCollection RegisterServiceClientRepositories(this IServiceCollection services)
        {
            services.AddTransient<ILocalisationRepository, LocalisationRepository>();
            services.AddTransient<ILocalisationAuthRepository, LocalisationAuthRepository>();
            services.AddTransient<IConfigTenantRepository, ConfigTenantRepository>();
            services.AddTransient<IConfigUserRepository, ConfigUserRepository>();
            services.AddTransient<IDeviceRepository, DeviceRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<IPersonaRepository, PersonaRepository>();
            services.AddTransient<ISolutionRepository, SolutionRepository>();

            RegisterHttpClient(services);
            return services;
        }

        /// <summary>
        /// Dependencies for HttpClient
        /// </summary>
        /// <param name="services"></param>
        private static void RegisterHttpClient(IServiceCollection services)
        {
            services.AddHttpClient(NamedClientsConstant.ConfigServiceUrl, client =>
            {
                client.BaseAddress = new Uri(Configuration.ConfigServiceUrl + "/");
            });
            services.AddHttpClient(NamedClientsConstant.ConfigUserServiceUrl, client =>
            {
                client.BaseAddress = new Uri(Configuration.ConfigUserServiceUrl + "/");
            });
            services.AddHttpClient(NamedClientsConstant.LocalisationAuthServiceUrl, client =>
            {
                client.BaseAddress = new Uri(Configuration.LocalisationAuthServiceUrl + "/");
            });
            services.AddHttpClient(NamedClientsConstant.LocalisationServiceUrl, client =>
            {
                client.BaseAddress = new Uri(Configuration.LocalisationServiceUrl + "/");
            });
            services.AddHttpClient(NamedClientsConstant.PersonaServiceUrl, client =>
            {
                client.BaseAddress = new Uri(Configuration.PersonaServiceUrl);
            });
            services.AddHttpClient(NamedClientsConstant.SolutionServiceUrl, client =>
            {
                client.BaseAddress = new Uri(Configuration.SolutionServiceUrl);
            });
            services.AddHttpClient(NamedClientsConstant.DeviceServiceUrl, client =>
            {
                client.BaseAddress = new Uri(Configuration.DeviceServiceUrl + "/");
            });
            services.AddHttpClient(NamedClientsConstant.GroupManagementUrl, client =>
            {
                client.BaseAddress = new Uri(Configuration.GroupManagementUrl);
            });
            services.AddHttpClient(NamedClientsConstant.AuthorisationServiceUrl, client =>
            {
                client.BaseAddress = new Uri(Configuration.AuthorisationServiceUrl + "/");
            });

        }
    }
}
