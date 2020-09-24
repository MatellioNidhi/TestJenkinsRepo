using VehicleMaintenceService.API.Helpers;
using Inseego.Repositories.ServiceClient.Model;
using Inseego.Services.Interface;
using Inseego.Utilities.CacheExtension;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VehicleMaintenceService.API.Middleware
{
    public class RequestResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //public async Task Invoke(HttpContext context)
        //{
        //    Stream originalBody = context.Response.Body;

        //    MemoryStream responseBody = new MemoryStream();
        //    context.Response.Body = responseBody;

        //    await _next(context);
        //    if (context.Response != null && context.Response.ContentType != null && context.Response.ContentType.Contains("application/json"))
        //    {
        //        string culture = context.Request.Headers["Lang-Culture"].ToString();
        //        string tenant = context.Request.Headers["x-tenant"].ToString();
        //        string user = context.Request.Headers["x-user"].ToString();
        //        string key = context.Request.Headers["Ocp-Apim-Subscription-Key"].ToString();
        //        List<LocalisationModel> response = new List<LocalisationModel>();
        //        if (!string.IsNullOrEmpty(tenant) && !string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(key))
        //        {
        //            ILocalisationService localisationService = (ILocalisationService)context.Request.HttpContext.RequestServices.GetService(typeof(ILocalisationService));
        //            if (string.IsNullOrEmpty(culture))
        //            {
        //                culture = await localisationService.GetUserConfigDefaultLanguage();
        //            }

        //            response = await localisationService.GetLocalisationByModule(culture);
        //        }
        //        responseBody.Seek(0, SeekOrigin.Begin);
        //        string json = new StreamReader(responseBody).ReadToEnd();
        //        JToken jToken = JsonConvert.DeserializeObject<JToken>(json);
        //        jToken = JsonExtensions.FindAndReplace(jToken, response);
        //        byte[] tokenBytes = Encoding.UTF8.GetBytes(jToken.ToString());
        //        MemoryStream stream = new MemoryStream(tokenBytes)
        //        {
        //            Position = 0
        //        };
        //        responseBody = stream;
        //    }

        //    responseBody.Seek(0, SeekOrigin.Begin);
        //    await responseBody.CopyToAsync(originalBody);
        //}

        //public async Task Invoke(HttpContext context)
        //{
        //    Stream originalBody = context.Response.Body;

        //    MemoryStream responseBody = new MemoryStream();
        //    context.Response.Body = responseBody;

        //    await _next(context);
        //    if (context.Response != null && context.Response.ContentType != null && context.Response.ContentType.Contains("application/json"))
        //    {
        //        string culture = context.Request.Headers["Lang-Culture"].ToString();
        //        string tenant = context.Request.Headers["x-tenant"].ToString();
        //        string user = context.Request.Headers["x-user"].ToString();
        //        string key = context.Request.Headers["Ocp-Apim-Subscription-Key"].ToString();
        //        List<LocalisationModel> response = new List<LocalisationModel>();
        //        if (!string.IsNullOrEmpty(tenant) && !string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(key))
        //        {
        //            ILocalisationService localisationService = (ILocalisationService)context.Request.HttpContext.RequestServices.GetService(typeof(ILocalisationService));
        //            if (string.IsNullOrEmpty(culture))
        //            {
        //                culture = await localisationService.GetUserConfigDefaultLanguage();
        //            }

        //            response = await localisationService.GetLocalisationByModuleNew(culture);
        //        }
        //        responseBody.Seek(0, SeekOrigin.Begin);
        //        string json = new StreamReader(responseBody).ReadToEnd();
        //        JToken jToken = JsonConvert.DeserializeObject<JToken>(json);
        //        if (jToken != null && response!=null && response.Count > 0)
        //        {
        //            jToken = JsonExtensions.FindAndReplace(jToken, response);
        //            byte[] tokenBytes = Encoding.UTF8.GetBytes(jToken.ToString());
        //            MemoryStream stream = new MemoryStream(tokenBytes)
        //            {
        //                Position = 0
        //            };
        //            responseBody = stream;
        //        }
        //    }

        //    responseBody.Seek(0, SeekOrigin.Begin);
        //    await responseBody.CopyToAsync(originalBody);
        //}
    }
}
