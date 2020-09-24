using Inseego.Repositories.ServiceClient.Interface;
using Inseego.Repositories.ServiceClient.Model;
using Inseego.Utilities.Aspects;
using Inseego.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Inseego.Repositories.ServiceClient.Implementation
{
    public class GroupRepository : IGroupRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _tenant;
        private readonly string _user;
        private readonly string _key;
        private readonly HttpClient _client;

        public GroupRepository(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
            _tenant = _httpContextAccessor.HttpContext.Request.Headers["x-tenant"].ToString();
            _user = _httpContextAccessor.HttpContext.Request.Headers["x-user"].ToString();
            _key = _httpContextAccessor.HttpContext.Request.Headers["Ocp-Apim-Subscription-Key"].ToString();
            _client = _httpClientFactory.CreateClient(NamedClientsConstant.GroupManagementUrl);
        }

        public async Task<List<GroupHierarchyModel>> GetGroupHierarchy()
        {
            List<GroupHierarchyModel> groupHierarchyModel = new List<GroupHierarchyModel>();
            HttpRequestMessage request = ClientHelper.GetRequestHeader("api/GroupHierarchy/GetGroupHierarchies/Testing", ClientHeader.TenantConfigContentHeader, _tenant, _user, _key);
            HttpResponseMessage response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var resultTxt = await response.Content.ReadAsStringAsync();
                groupHierarchyModel = JsonConvert.DeserializeObject<List<GroupHierarchyModel>>(resultTxt);
            }
            return groupHierarchyModel;
        }
    }
}
