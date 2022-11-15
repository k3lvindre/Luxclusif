using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VenueAndEventsApi.Model;

namespace VenueAndEventsApi
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }

         
        public List<Event> Events { get; set; }
    }
}
