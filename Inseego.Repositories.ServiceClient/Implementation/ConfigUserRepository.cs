using Inseego.Repositories.ServiceClient.Interface;
using Inseego.Repositories.ServiceClient.Model;
using Inseego.Utilities.Aspects;
using Inseego.Utilities.CacheExtension;
using Inseego.Utilities.Constants;
using Inseego.Utilities.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Inseego.Repositories.ServiceClient.Implementation
{
    public class ConfigUserRepository : IConfigUserRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        //private readonly ICache<ConfigurationSetting> _configCache;
        private readonly string _tenant;
        private readonly string _user;
        private readonly string _key;
        private readonly HttpClient _client;

        public ConfigUserRepository(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory/*, ICache<ConfigurationSetting> configCache*/)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
            //_configCache = configCache;
            _tenant = _httpContextAccessor.HttpContext.Request.Headers["x-tenant"].ToString();
            _user = _httpContextAccessor.HttpContext.Request.Headers["x-user"].ToString();
            _key = _httpContextAccessor.HttpContext.Request.Headers["Ocp-Apim-Subscription-Key"].ToString();
            _client = _httpClientFactory.CreateClient(NamedClientsConstant.ConfigUserServiceUrl);
        }

        public async Task<ConfigurationSetting> GetUserConfigurationSetting()
        {
            ConfigurationSetting configurationSetting = new ConfigurationSetting();
            //if ((configurationSetting = await _configCache.GetCache(Configuration.ConfigurationCacheKey)) == null)
            //{
            HttpRequestMessage request = ClientHelper.GetRequestHeader(_user+"/configurationProperties", ClientHeader.UserConfigContentHeader, _tenant, _user, _key);
            HttpResponseMessage response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var resultTxt = await response.Content.ReadAsStringAsync();
                configurationSetting = JsonConvert.DeserializeObject<ConfigurationSetting>(resultTxt);
                //await _configCache.SetCache(Configuration.ConfigurationCacheKey, configurationSetting, TimeSpan.FromMinutes(Configuration.RedisCacheTimeout));
            }
            //}
            return configurationSetting;
        }
    }
}
