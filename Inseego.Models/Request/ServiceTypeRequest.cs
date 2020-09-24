using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inseego.Models.Request
{
    public class ServiceTypeGetByIdRequest
    {
        [JsonProperty("id")]
        public string[] id { get; set; }       
    }   

    public class ServiceTypeCreateRequest
    {
        [JsonProperty("serviceTypeName")]
        public string ServiceTypeName { get; set; }
    }

    public class ServiceTypeUpdateRequest
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("serviceType")]
        public string ServiceTypeName { get; set; }
    }

    public class ServiceTypeDeleteRequest
    {
        [JsonProperty("id")]
        public string id { get; set; }
    }
}
