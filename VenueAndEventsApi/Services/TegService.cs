using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using VenueAndEventsApi.Model;
using Microsoft.Extensions.Logging;

namespace VenueAndEventsApi.Services
{
    /// <summary>
    /// This can be improve by making the call to the list async.
    /// And redundancy can also refactore by minimizing the call to GetDataAsync
    /// </summary>
    public class TegService : ITegService
    {
        private readonly ILogger<TegService> _logger;
        HttpClient _client;
        private  Context _context;


        public TegService(ILogger<TegService> logger,
            HttpClient client)
        {
            //you can check null here
            _logger = logger;
            _client = client;
            _client.BaseAddress =  new Uri("https://teg-coding-challenge.s3.ap-southeast-2.amazonaws.com/");
        }

        private async Task GetDataAsync()
        {
            try
            {
                _logger.LogInformation("Call teg.");
                var result = await _client.GetAsync("events/event-data.json");
                _context = JsonSerializer.Deserialize<Context>(await result.Content.ReadAsStringAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<List<Event>> GetEventsAsync()
        {
            await GetDataAsync();
            return _context.Events;
        }


        public async Task<Event> GetEventByIdAsync(int id)
        {
            await GetDataAsync();
            return _context.Events.Find(x=>x.Id == id);
        }


        public async Task<List<Event>> GetEventByVenueIdAsync(int venueId)
        {
            await GetDataAsync();
            return _context.Events.Where(x => x.VenueId == venueId).ToList();
        }



        public async Task<List<Venue>> GetVenuesAsync()
        {
            await GetDataAsync();
            return _context.Venues;
        }


        public async Task<Venue> GetVenueByIdAsync(int id)
        {
            await GetDataAsync();
            return _context.Venues.Find(x => x.Id == id);
        }

        private class Context
        {
            public List<Event> Events { get; set; }
            public List<Venue> Venues { get; set; }
        }
    }
}
