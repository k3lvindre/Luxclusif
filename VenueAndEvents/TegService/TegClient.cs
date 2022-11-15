using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using VenueAndEvents.Dto;

namespace VenueAndEvents.TegService
{
    public class TegClient
    {
        private readonly HttpClient _client;

        public TegClient(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("http://localhost:13276/");
        }


        public async Task<EventDto> GetEventsByVenueIdAsync(int id)
        {
            var result = await _client.GetAsync($"api/venue/{id}/events");

            return JsonSerializer.Deserialize<EventDto>(await result.Content.ReadAsStringAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
