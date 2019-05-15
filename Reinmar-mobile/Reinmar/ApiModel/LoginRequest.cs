using Newtonsoft.Json;

namespace Reinmar.ApiModel
{
    public class LoginRequest
    {
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
