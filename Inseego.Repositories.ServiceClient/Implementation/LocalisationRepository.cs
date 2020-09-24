using Inseego.Repositories.ServiceClient.Interface;
using Inseego.Repositories.ServiceClient.Model;
using Inseego.Utilities.Aspects;
using Inseego.Utilities.CacheExtension;
using Inseego.Utilities.Constants;
using Inseego.Utilities.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Inseego.Repositories.ServiceClient.Implementation
{
    public class LocalisationRepository : ILocalisationRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILocalisationAuthRepository _localisationAuthRepository;
        private readonly ICache<object> _tokenCache;
        private readonly string _tenant;
        private readonly string _user;
        private readonly string _key;
        private readonly HttpClient _client;

        public LocalisationRepository(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory, ILocalisationAuthRepository localisationAuthRepository, ICache<object> tokenCache)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
            _localisationAuthRepository = localisationAuthRepository;
            _tokenCache = tokenCache;
            _tenant = _httpContextAccessor.HttpContext.Request.Headers["x-tenant"].ToString();
            _user = _httpContextAccessor.HttpContext.Request.Headers["x-user"].ToString();
            _key = _httpContextAccessor.HttpContext.Request.Headers["Ocp-Apim-Subscription-Key"].ToString();
            _client = _httpClientFactory.CreateClient(NamedClientsConstant.LocalisationServiceUrl);
        }

        public async Task<List<LocalisationModel>> GetLocalisationByModule(string culture, string token)
        {
            List<LocalisationModel> output = new List<LocalisationModel>();
            string url = $"api/LocalisationLibrary/GetLocalisationLibraryBySourceFileCulture?moduleName={Configuration.LocalisationModule}&sourceFiles={Configuration.LocalisationSourceFile}&culture={culture}";
            HttpRequestMessage request = ClientHelper.GetRequestHeader(url, ClientHeader.UsersContentHeader, _tenant, _user, _key);
            request.Headers.Add("x-token", token);
            HttpResponseMessage response = await _client.SendAsync(request).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                JToken jToken = JsonConvert.DeserializeObject<JToken>(json);
                if (jToken.HasValues)
                {
                    FindTokens(jToken[culture], output);
                }
            }
            else if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                token = await _localisationAuthRepository.GetTokenNew().ConfigureAwait(false);
                await _tokenCache.SetCache("token", token);
                output = await GetLocalisationByModule(culture, token).ConfigureAwait(false);
            }
            return output;
        }

        private static void FindTokens(JToken containerToken, List<LocalisationModel> localisationModels)
        {
            if (containerToken.Type == JTokenType.Object)
            {
                foreach (JProperty child in containerToken.Children<JProperty>())
                {
                    localisationModels.Add(new LocalisationModel { Key = child.Name, Value = child.Value.ToString() });
                    FindTokens(child.Value, localisationModels);
                }
            }
            else if (containerToken.Type == JTokenType.Array)
            {
                foreach (JToken child in containerToken.Children())
                {
                    FindTokens(child, localisationModels);
                }
            }
        }
    }
}
