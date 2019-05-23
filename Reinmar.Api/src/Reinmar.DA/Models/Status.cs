using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Reinmar.DA.Models
{
	[Table("Statuses")]
	public class Status : BaseEntity
	{
		public Status(string Location, string Event)
		{
			this.Location = Location;
			this.Event = Event;
		}
		public string Location { get; set; }
		public string Event { get; set; }
		public DateTime Date { get; set; } = DateTime.Now;
		[JsonIgnore]
		public virtual Package Package { get; set; }
	}
}
