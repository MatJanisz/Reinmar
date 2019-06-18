using Newtonsoft.Json;

namespace Reinmar.ApiModel
{
    public class ChangeStatusRequest
    {
        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }
    }
}
