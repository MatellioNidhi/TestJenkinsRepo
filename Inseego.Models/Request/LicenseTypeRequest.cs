using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inseego.Models.Request
{
    public class LicenseTypeGetByIdRequest
    {
        [JsonProperty("id")]
        [Required]
        public string[] id { get; set; }       
    }   

    public class LicenseTypeCreateRequest
    {
        [JsonProperty("licenseTypeName")]
        [Required]
        public string LicenseTypeName { get; set; }
    }

    public class LicenseTypeUpdateRequest
    {
        [JsonProperty("id")]
        [Required]
        public string id { get; set; }

        [JsonProperty("licenseType")]
        [Required]
        public string LicenseTypeName { get; set; }
    }

    public class LicenseTypeDeleteRequest
    {
        [JsonProperty("id")]
        [Required]
        public string id { get; set; }
    }
}
