using Microsoft.Extensions.Configuration;
using System;

namespace Inseego.Utilities.Models
{

    public static class Configuration
    {
        public static string EndpointUrl { get; set; }
        public static string Key { get; set; }
        public static string Database { get; set; }
        public static string LocalisationServiceUrl { get; set; }
        public static string LocalisationAuthServiceUrl { get; set; }
        public static string LocalisationEmail { get; set; }
        public static string LocalisationPassword { get; set; }
        public static string LocalisationAuthModule { get; set; }
        public static string LocalisationModule { get; set; }
        public static string LocalisationSourceFile { get; set; }
        public static string PersonaServiceUrl { get; set; }
        public static string DeviceServiceUrl { get; set; }
        public static string ConfigServiceUrl { get; set; }
        public static string ConfigUserServiceUrl { get; set; }
        public static string SolutionServiceUrl { get; set; }
        public static int RedisCacheTimeout { get; set; }
        public static string GroupManagementUrl { get; set; }
        public static string Redishost { get; set; }
        public static string Redisport { get; set; }
        public static string Rediskey { get; set; }
        public static int RedisTimeout { get; set; }
        public static bool RedisAllowAdmin { get; set; }
        public static bool IsRedisDisabled { get; set; }
        public static string ServiceRedisKey { get; set; }
        public static string ConfigurationCacheKey { get; set; }

        public static string LocalisationUserName { get; set; }
        public static string LocalisationPass { get; set; }
        public static string LocalisationApplicationName { get; set; }
        public static string AuthorisationServiceUrl { get; set; }
        static Configuration()
        {
            IConfiguration config = new ConfigurationBuilder().AddEnvironmentVariables().Build();
            Database = Inseego.Utils.Shared.Configuration.GetValue<string>("azure.cosmosdb.database", "inseego");
            EndpointUrl = Inseego.Utils.Shared.Configuration.GetValue<string>("azure.cosmosdb.uri");
            Key = Inseego.Utils.Shared.Configuration.GetValue<string>("azure.cosmosdb.saskey");
            LocalisationServiceUrl = Inseego.Utils.Shared.Configuration.GetValue<string>("localisation.service.url");
            LocalisationAuthServiceUrl = Inseego.Utils.Shared.Configuration.GetValue<string>("localisationauth.service.url");
            PersonaServiceUrl = Inseego.Utils.Shared.Configuration.GetValue<string>("service.persona.baseurl");
            DeviceServiceUrl = Inseego.Utils.Shared.Configuration.GetValue<string>("device.service.url");
            ConfigServiceUrl = Inseego.Utils.Shared.Configuration.GetValue<string>("config.service.tenant.url");
            ConfigUserServiceUrl = Inseego.Utils.Shared.Configuration.GetValue<string>("config.service.user.baseUrl");
            SolutionServiceUrl = Inseego.Utils.Shared.Configuration.GetValue<string>("service.solution.baseurl");
            LocalisationEmail = "clarity@pegasus.co.za";
            LocalisationPassword = "givemeaccess";
            LocalisationAuthModule = "Localisation";
            LocalisationModule = "smb-lit";
            LocalisationSourceFile = "DashboardService.vue";
            RedisCacheTimeout = 30;
            GroupManagementUrl = Inseego.Utils.Shared.Configuration.GetValue<string>("service.groupmanagement.url");
            Redishost = config["azure.redis.host"];
            Redisport = config["azure.redis.port"];
            Rediskey = config["azure.redis.saskey"];
            RedisTimeout = 6000;
            RedisAllowAdmin = true;
            IsRedisDisabled = false;
            ServiceRedisKey = "DashboardService_";
            ConfigurationCacheKey = "UserConfiguration";

            LocalisationUserName = Inseego.Utils.Shared.Configuration.GetValue<string>("dashboard.service.username"); ;
            LocalisationPass = Inseego.Utils.Shared.Configuration.GetValue<string>("dashboard.service.password"); ;
            LocalisationApplicationName = "Clarity Application";
            AuthorisationServiceUrl = Inseego.Utils.Shared.Configuration.GetValue<string>("auth.service.url");
        }
    }

}
