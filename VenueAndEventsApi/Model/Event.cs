using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VenueAndEventsApi.Model
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public int VenueId { get; set; }
        public string Description { get; set; }
    }
}
