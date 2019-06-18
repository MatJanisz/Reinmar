using System;
using Newtonsoft.Json;
using Reinmar.Enums;

namespace Reinmar.ApiModel
{
    public class LoginResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        public Status Status { get; set; }
    }
}
