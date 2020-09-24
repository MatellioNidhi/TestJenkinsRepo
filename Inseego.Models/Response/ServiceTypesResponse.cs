using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inseego.Models.Response
{
    public class ServiceTypesResponse
    {
        public ServiceTypesResponse() { }

        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }

        [JsonProperty(PropertyName = "serviceTypeName")]
        public string serviceTypeName { get; set; }
    }
}
