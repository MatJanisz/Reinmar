using System;
using System.Collections.Generic;
using Reinmar.ApiModel;

namespace Reinmar.Model
{
    public class PackageModel : BaseEntityModel
    {
        public string SitId { get; set; }
        public string OrderName { get; set; }
        //public Guid SenderId { get; set; }
        public string ReceiverFullName { get; set; }
        public string ReceiverEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string Notes { get; set; }
        public double CashOnDelivery { get; set; }
        public List<StatusModel> Statuses { get; set; }


        public PackageModel()
        {
        }

        public static implicit operator PackageModel(GetPackageResponse v)
        {
            //throw new NotImplementedException();
            var o = new PackageModel();
            o.SitId = v.SitId;
            o.OrderName = v.OrderName;
            o.ReceiverFullName = v.ReceiverFullName;
            o.ReceiverEmail = v.ReceiverEmail;
            o.PhoneNumber = v.PhoneNumber;
            o.Country = v.Country;
            o.City = v.City;
            o.PostalCode = v.PostalCode;
            o.StreetName = v.StreetName;
            o.HouseNumber = v.HouseNumber;
            o.Notes = v.Notes;
            o.CashOnDelivery = v.CashOnDelivery;
            o.Statuses = v.Statuses;
            return o;
    }
    }
}
