using Newtonsoft.Json;

namespace Inseego.Repositories.ServiceClient.Model
{
    public class LocalisationUserModel
    {
        [JsonProperty("email")]
        public string Email{ get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("module")]
        public string Module { get; set; }
    }

    public class LocalisationUserModelNew
    {
        [JsonProperty("applicationName")]
        public string ApplicationName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }
    }
}
