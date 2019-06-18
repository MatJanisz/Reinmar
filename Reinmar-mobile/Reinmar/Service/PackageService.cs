using Newtonsoft.Json;
using System.Net.Http;
using Reinmar.ApiModel;
using Reinmar.Service.Interface;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Reinmar.Model;

namespace Reinmar.Service
{
    public class PackageService : IPackageService
    {
        private static string _baseApiAccountControllerUrl = "http://localhost:5001/api/Package";

        public PackageService()
        {
        }

        public async Task<PackageModel> GetPackage(string sitId, string token)
        {
            var url = _baseApiAccountControllerUrl + "/GetBySitId";

            using (HttpClient httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url + "/" + sitId);
                var abc = request.ToString();
                request.Headers.Add("Authorization", "Bearer " + token);
                var result = await httpClient.SendAsync(request);
                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    //return "Something wrong happened! :(";
                    return null;
                }
                var json = await result.Content.ReadAsStringAsync();
                var x = JsonConvert.DeserializeObject<GetPackageResponse>(json);

                if (x == null)
                {
                    return null;
                }
                else
                {
                    return x;
                }



                //return null;

                //List<PackageModel> packageList = JsonConvert.DeserializeObject<List<PackageModel>>(json);

                //var packageList = JsonConvert.DeserializeObject<IList<PackageModel>>(json);
                //if (packageList.Count > 0)
                //{
                //    return packageList[0];
                //}
                //else
                //{
                //    return null;
                //}
            }
        }

        public async Task<Enums.Status> ChangeStatus(string sitId, string location, string statusEevent, string token)
        {
            var url = _baseApiAccountControllerUrl + "/ChangeStatus";

            using (HttpClient httpClient = new HttpClient())
            {
                var changeStatusRequest = new ChangeStatusRequest
                {
                    Location = location,
                    Event = statusEevent
                };

                var content = new StringContent(JsonConvert.SerializeObject(changeStatusRequest), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, url + "/" + sitId);
                request.Headers.Add("Authorization", "Bearer " + token);
                request.Content = content;
                var result = await httpClient.SendAsync(request);
                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    //return "Something wrong happened! :(";
                    return Enums.Status.Failed;
                }
                var json = await result.Content.ReadAsStringAsync();

                return Enums.Status.Ok;
            }
        }
    }
}
