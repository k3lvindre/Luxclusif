using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VenueAndEvents.Dto
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
