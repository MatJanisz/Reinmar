using Newtonsoft.Json;
using System.Collections.Generic;
using Reinmar.Model;

namespace Reinmar.ApiModel
{
    public class GetPackageResponse
    {
        [JsonProperty("sitId")]
        public string SitId { get; set; }

        [JsonProperty("orderName")]
        public string OrderName { get; set; }

        [JsonProperty("receiverFullName")]
        public string ReceiverFullName { get; set; }

        [JsonProperty("receiverEmail")]
        public string ReceiverEmail { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("streetName")]
        public string StreetName { get; set; }

        [JsonProperty("houseNumber")]
        public string HouseNumber { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("cashOnDelivery")]
        public double CashOnDelivery { get; set; }

        [JsonProperty("statuses")]
        public List<StatusModel> Statuses { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

    }
}
