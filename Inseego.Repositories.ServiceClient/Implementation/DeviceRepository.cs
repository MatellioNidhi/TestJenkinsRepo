using Inseego.Repositories.ServiceClient.Interface;
using Inseego.Repositories.ServiceClient.Model;
using Inseego.Utilities.Aspects;
using Inseego.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Inseego.Repositories.ServiceClient.Implementation
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _tenant;
        private readonly string _user;
        private readonly string _key;
        private readonly HttpClient _client;

        public DeviceRepository(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
            _tenant = _httpContextAccessor.HttpContext.Request.Headers["x-tenant"].ToString();
            _user = _httpContextAccessor.HttpContext.Request.Headers["x-user"].ToString();
            _key = _httpContextAccessor.HttpContext.Request.Headers["Ocp-Apim-Subscription-Key"].ToString();
            _client = _httpClientFactory.CreateClient(NamedClientsConstant.DeviceServiceUrl);
        }

        public async Task<TenantVehicleInfo> GetTenantVehicleInfo()
        {
            TenantVehicleInfo tenantVehicleInfo = new TenantVehicleInfo();
            HttpRequestMessage request = ClientHelper.GetRequestHeader("devices?templateType=Non-Communicable&metadata=type:vehicle", ClientHeader.DeviceContentHeader, _tenant, _user, _key);
            HttpResponseMessage response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var resultTxt = await response.Content.ReadAsStringAsync();
                tenantVehicleInfo = JsonConvert.DeserializeObject<TenantVehicleInfo>(resultTxt);
            }

            return tenantVehicleInfo;
        }
    }
}
