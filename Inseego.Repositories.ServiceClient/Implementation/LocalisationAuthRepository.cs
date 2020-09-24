using Inseego.Repositories.ServiceClient.Interface;
using Inseego.Repositories.ServiceClient.Model;
using Inseego.Utilities.Aspects;
using Inseego.Utilities.Constants;
using Inseego.Utilities.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Inseego.Repositories.ServiceClient.Implementation
{
    public class LocalisationAuthRepository : ILocalisationAuthRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _tenant;
        private readonly string _user;
        private readonly string _key;
        private readonly HttpClient _client;

        public LocalisationAuthRepository(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
            _tenant = _httpContextAccessor.HttpContext.Request.Headers["x-tenant"].ToString();
            _user = _httpContextAccessor.HttpContext.Request.Headers["x-user"].ToString();
            _key = _httpContextAccessor.HttpContext.Request.Headers["Ocp-Apim-Subscription-Key"].ToString();
            _client = _httpClientFactory.CreateClient(NamedClientsConstant.AuthorisationServiceUrl);
        }

        public async Task<string> GetToken()
        {
            string token = string.Empty;
            LocalisationUserModel tokenModel = new LocalisationUserModel
            {
                Email = Configuration.LocalisationEmail,
                Password = Configuration.LocalisationPassword,
                Module = Configuration.LocalisationAuthModule
            };
            string jsonString = JsonConvert.SerializeObject(tokenModel, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, ClientHeader.UsersContentHeader);
            HttpRequestMessage request = ClientHelper.PostRequestHeader("api/Token/GetToken", content, ClientHeader.UsersContentHeader, _tenant, _user, _key);
            HttpResponseMessage response = await _client.SendAsync(request).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                LocalisationTokenModel output = JsonConvert.DeserializeObject<LocalisationTokenModel>(json);
                token = output.Token;
            }
            return token;
        }


        public async Task<string> GetTokenNew()
        {
            string token = string.Empty;
            LocalisationUserModelNew tokenModel = new LocalisationUserModelNew
            {
                UserName = Configuration.LocalisationUserName,
                Password = Configuration.LocalisationPass,
                ApplicationName = Configuration.LocalisationApplicationName
            };
            string jsonString = JsonConvert.SerializeObject(tokenModel, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, ClientHeader.AuthContentHeader);
            HttpRequestMessage request = ClientHelper.PostRequestHeader("api/Authentication/AuthenticateUser", content,ClientHeader.AuthAcceptHeader, _tenant, _user, _key);
            HttpResponseMessage response = await _client.SendAsync(request).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                LocalisationTokenModelNew output = JsonConvert.DeserializeObject<LocalisationTokenModelNew>(json);
                token = output.JwtToken;
            }
            Console.WriteLine("LocalisationAuthRepository : GetTokenNew() => token =>" + token);
            Console.WriteLine("LocalisationAuthRepository : GetTokenNew() => response =>" + response);
            Console.WriteLine("LocalisationAuthRepository : GetTokenNew() => jsonString =>" + jsonString);
            return token;
           
        }

    }
}
