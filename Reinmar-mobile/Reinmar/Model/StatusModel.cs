using System;
namespace Reinmar.Model
{
    public class StatusModel : BaseEntityModel
    {
        public StatusModel(string Location, string Event)
        {
            this.Location = Location;
            this.Event = Event;
        }
        public string Location { get; set; }
        public string Event { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public virtual PackageModel Package { get; set; }

        public StatusModel()
        {
        }
    }
}
