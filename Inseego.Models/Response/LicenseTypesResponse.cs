using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inseego.Models.Response
{
    public class LicenseTypesResponse
    {
        public LicenseTypesResponse() { }

        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }

        [JsonProperty(PropertyName = "licenseTypeName")]
        public string licenseTypeName { get; set; }
    }
}
