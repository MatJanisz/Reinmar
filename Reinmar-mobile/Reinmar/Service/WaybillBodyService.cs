using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Reinmar.Common.Entities;
using Reinmar.Providers;
using Reinmar.Service.Interface;

namespace Reinmar.Service
{
    public class WaybillBodyService : IWaybillBodyService
    {
        //private static string _baseApiAccountControllerUrl = "https://reinmarapi.azurewebsites.net/api/WaybillBody";
        private static string _baseApiAccountControllerUrl = "http://localhost:5001/api/Package";

        public WaybillBodyService()
        {
        }

        public async Task<WaybillBody> GetWaybillBody(int sitId, string token)
        {
            var url = _baseApiAccountControllerUrl + "/GetBySitId";

            using (HttpClient httpClient = new HttpClient())
            {
                //var content = new StringContent(JsonConvert.SerializeObject(sitId), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Get, url + "/" + sitId.ToString());
                request.Headers.Add("Authorization", "Bearer " + token);
                var result = await httpClient.SendAsync(request);
                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    //return "Something wrong happened! :(";
                    return null;
                }
                var json = await result.Content.ReadAsStringAsync();

                //List<RootObject> datalist = JsonConvert.DeserializeObject<List<RootObject>>(jsonstring);
                //RootObject datalist = JsonConvert.DeserializeObject<RootObject>(jsonstring);

                //List<WaybillBody> waybillBodyList = JsonConvert.DeserializeObject<List<WaybillBody>>(json);
                WaybillBody waybillBodyList = JsonConvert.DeserializeObject<WaybillBody>(json);

                //var waybillBodyList = JsonConvert.DeserializeObject<IList<WaybillBody>>(json);
                //if (waybillBodyList.Count > 0)
                //{
                //    return waybillBodyList[0];
                //}
                //else
                //{
                //    return null;
                //}

                if (waybillBodyList != null)
                {
                    return waybillBodyList;
                }
                else
                {
                    return null;
                }
            }

        }
    }
}
