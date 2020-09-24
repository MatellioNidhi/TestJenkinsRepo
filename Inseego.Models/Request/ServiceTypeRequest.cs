using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inseego.Models.Request
{
    public class ServiceTypeGetByIdRequest
    {
        [JsonProperty("id")]
        [Required]
        public string[] id { get; set; }       
    }   

    public class ServiceTypeCreateRequest
    {
        [JsonProperty("serviceTypeName")]
        [Required]
        public string ServiceTypeName { get; set; }
    }

    public class ServiceTypeUpdateRequest
    {
        [JsonProperty("id")]
        [Required]
        public string id { get; set; }

        [JsonProperty("serviceType")]
        [Required]
        public string ServiceTypeName { get; set; }
    }

    public class ServiceTypeDeleteRequest
    {
        [JsonProperty("id")]
        [Required]
        public string id { get; set; }
    }
}
