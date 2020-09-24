using Newtonsoft.Json;

namespace Inseego.Utilities.Models
{
    public class ErrorModel
    {
        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }
        [JsonProperty(PropertyName = "apiMessage")]
        public string ApiMessage { get; set; }
    }

    public class RiskChartEnum
    {
        [JsonProperty(PropertyName = "Id")]
        public int id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "checked")]
        public bool Checked { get; set; }
    }
}
