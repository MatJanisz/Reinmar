using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Reinmar.Common.Entities;
using Reinmar.Providers;
using Reinmar.Service.Interface;
using Reinmar.Static;

namespace Reinmar.Service
{
    public class StatusService : IStatusService
    {
        //private static string _baseApiAccountControllerUrl = "https://reinmarapi.azurewebsites.net/api/Status";
        private static string _baseApiAccountControllerUrl = "http://localhost:5001/api/Status";

        public StatusService()
        {
        }

        public async Task<Enums.Status> AddStatus(WaybillBody waybillBody, string statusEvent, string token)
        {
            var url = _baseApiAccountControllerUrl + "/Add";

            Status newStatusRequest = new Status
            {
                Id = StatusStatic.Id,
                DateFrom = DateTime.Now,
                Event = statusEvent,
                Location = StatusStatic.Location,
                WaybillBodies = waybillBody
            };

            using (HttpClient httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(newStatusRequest), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Add("Authorization", "Bearer " + token);
                request.Content = content;
                await httpClient.SendAsync(request);

                return Enums.Status.Ok;
            }

        }
    }
}
