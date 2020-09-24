using Inseego.Repositories.ServiceClient.Interface;
using Inseego.Repositories.ServiceClient.Model;
using Inseego.Utilities.Aspects;
using Inseego.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Inseego.Repositories.ServiceClient.Implementation
{
    public class SolutionRepository : ISolutionRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _tenant;
        private readonly string _user;
        private readonly string _key;
        private readonly HttpClient _client;

        public SolutionRepository(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
            _tenant = _httpContextAccessor.HttpContext.Request.Headers["x-tenant"].ToString();
            _user = _httpContextAccessor.HttpContext.Request.Headers["x-user"].ToString();
            _key = _httpContextAccessor.HttpContext.Request.Headers["Ocp-Apim-Subscription-Key"].ToString();
            _client = _httpClientFactory.CreateClient(NamedClientsConstant.SolutionServiceUrl);
        }

        public async Task<VehicleInfo> GetVehicleNames()
        {
            VehicleInfo vehicleInfo = new VehicleInfo();
            HttpRequestMessage request = ClientHelper.GetRequestHeader("manageVehicles/", ClientHeader.ManageVehicleContenttHeader, _tenant, _user, _key);
            HttpResponseMessage response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var resultTxt = await response.Content.ReadAsStringAsync();
                JObject jsonData = JObject.Parse(resultTxt);
                vehicleInfo = JsonConvert.DeserializeObject<VehicleInfo>(resultTxt);
            }

            return vehicleInfo;
        }
    }
}
