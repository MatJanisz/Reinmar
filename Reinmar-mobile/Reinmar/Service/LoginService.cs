using Newtonsoft.Json;
using System.Net.Http;
using Reinmar.ApiModel;
using Reinmar.Service.Interface;
using System.Text;
using System.Threading.Tasks;

namespace Reinmar.Service
{
    public class LoginService : ILoginService
    {
        //private static string _baseApiAccountControllerUrl = "https://reinmarapi.azurewebsites.net/api/Account";

        private static string _baseApiAccountControllerUrl = "http://localhost:5001/api/User";

        public LoginService()
        {
        }

        public async Task<LoginResponse> Login(string email, string password)
        {
            var url = _baseApiAccountControllerUrl + "/login";
            var loginRequest = new LoginRequest
            {
                Email = email,
                Password = password
            };

            using(HttpClient httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Content = content;
                var result = await httpClient.SendAsync(request);
                if(result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    //return "Something wrong happened! :(";
                    return null;
                }
                var json = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<LoginResponse>(json);
            }
        }
    }
}
