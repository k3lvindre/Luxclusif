using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VenueAndEvents.Dto;
using VenueAndEvents.TegService;

namespace VenueAndEvents.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly TegClient _tegClient;
        public EventDto Data;

        public IndexModel(ILogger<IndexModel> logger, TegClient tegClient)
        {
            _logger = logger;
            _tegClient = tegClient;
        }

        public async Task OnGet()
        {
            var venueId = 123;

            Data = await _tegClient.GetEventsByVenueIdAsync(venueId);

            
        }
    }
}
