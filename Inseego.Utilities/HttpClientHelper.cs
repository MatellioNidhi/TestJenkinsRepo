using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Inseego.Utilities
{
    public static class HttpClientHelper
    {
        public static void AddPlatformDefaultHeaders(HttpClient clientToAddHeadersTo, string user, string tenant, string subscriptionKey)
        {
            try
            {
                clientToAddHeadersTo.DefaultRequestHeaders.Clear();
                //clientToAddHeadersTo.DefaultRequestHeaders.Accept.Clear();
                //HttpRequestHeaders headersToAdd = new HttpRequestHeaders();

                clientToAddHeadersTo.DefaultRequestHeaders.Add("Accept","application/vnd.com.inseego.platform.ctr.v1+json");
                clientToAddHeadersTo.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.com.inseego.platform.ctr.v1+json"));
                clientToAddHeadersTo.DefaultRequestHeaders.Add("x-tenant",tenant);
                clientToAddHeadersTo.DefaultRequestHeaders.Add("x-user",user);
                clientToAddHeadersTo.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key",subscriptionKey);
                
            }

            catch (Exception e)
            {
                Inseego.Utils.Shared.ExceptionHandler.LogException("DriverScoreApp.Utilities.AddPlatformDefaultHeaders had an issue", e);
                throw;
            }
        }

        

       

        public static void AddPlatformVehicleHeaders(HttpClient clientToAddHeadersTo, string user, string tenant, string subscriptionKey)
        {
            try
            {
                clientToAddHeadersTo.DefaultRequestHeaders.Clear();
                //clientToAddHeadersTo.DefaultRequestHeaders.Accept.Clear();
                //HttpRequestHeaders headersToAdd = new HttpRequestHeaders();

                clientToAddHeadersTo.DefaultRequestHeaders.Add("Accept", "application/vnd.com.inseego.platform.user.v1+json");
                //clientToAddHeadersTo.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.com.inseego.platform.user.v1+json"));
                clientToAddHeadersTo.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.com.inseego.platform.device.v1+json"));
                clientToAddHeadersTo.DefaultRequestHeaders.Add("x-tenant", tenant);
                //clientToAddHeadersTo.DefaultRequestHeaders.Add("x-tenant","Inseego-PF");
                clientToAddHeadersTo.DefaultRequestHeaders.Add("x-user", user);
                clientToAddHeadersTo.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
            }

            catch (Exception e)
            {
                Inseego.Utils.Shared.ExceptionHandler.LogException("DriverScoreApp.Utilities.AddPlatformUserHeaders had an issue", e);
                throw;
            }
        }

        public static void AddPlatformConfigurationHeaders(HttpClient clientToAddHeadersTo, string user, string tenant, string subscriptionKey)
        {
            try
            {
                clientToAddHeadersTo.DefaultRequestHeaders.Clear();
                //clientToAddHeadersTo.DefaultRequestHeaders.Accept.Clear();
                //HttpRequestHeaders headersToAdd = new HttpRequestHeaders();

                clientToAddHeadersTo.DefaultRequestHeaders.Add("Accept", "application/vnd.com.inseego.platform.tenantconfig.v1+json;charset=utf-8");
                clientToAddHeadersTo.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.com.inseego.platform.user.v1+json"));
                clientToAddHeadersTo.DefaultRequestHeaders.Add("x-tenant", tenant);
                //clientToAddHeadersTo.DefaultRequestHeaders.Add("x-tenant","Inseego-PF");
                clientToAddHeadersTo.DefaultRequestHeaders.Add("x-user", user);
                clientToAddHeadersTo.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
            }

            catch (Exception e)
            {
                Inseego.Utils.Shared.ExceptionHandler.LogException("DashboardService.Utilities.HttpClientHelper.AddPlatformConfigurationHeaders had an issue", e);
                throw;
            }
        }

        
    }
}
