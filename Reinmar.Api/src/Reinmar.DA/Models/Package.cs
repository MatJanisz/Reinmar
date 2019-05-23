using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Reinmar.DA.Models
{
	[Table("Packages")]
	public class Package : BaseEntity
	{
		public string SitId { get; set; }
		public string OrderName { get; set; }
		[ForeignKey("User")]
		[JsonIgnore]
		public Guid SenderId { get; set; }
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
		public List<Status> Statuses { get; set; }

	}
}
