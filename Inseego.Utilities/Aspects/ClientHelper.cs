using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Inseego.Utilities.Aspects
{
    public static class ClientHelper
    {
        public static HttpRequestMessage GetRequestHeader(string url, string content, string tenant, string user, string key)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("x-tenant", tenant);
            request.Headers.Add("x-user", user);
            request.Headers.Add("Ocp-Apim-Subscription-Key", key);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(content));
            return request;
        }

        public static HttpRequestMessage PostRequestHeader(string url, HttpContent requestContent, string content, string tenant, string user, string key)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("x-tenant", tenant);
            request.Headers.Add("x-user", user);
            request.Headers.Add("Ocp-Apim-Subscription-Key", key);
            request.Content = requestContent;
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(content));
            return request;
        }
    }
}
