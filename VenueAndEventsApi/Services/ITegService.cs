using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VenueAndEventsApi.Model;

namespace VenueAndEventsApi.Services
{
    public interface ITegService
    {
        public Task<List<Event>> GetEventsAsync();
        public Task<Event> GetEventByIdAsync(int id);
        public Task<Venue> GetVenueByIdAsync(int id);
        public Task<List<Event>> GetEventByVenueIdAsync(int venueId);
        public Task<List<Venue>> GetVenuesAsync();
    }
}
