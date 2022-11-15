using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VenueAndEventsApi.Services;
using AutoMapper;

namespace VenueAndEventsApi.Controllers
{
    /// <summary>
    /// Validation can be added along with different http status codes
    /// </summary>
    [ApiController]
    [Route("api/Events")]
    public class EventsController : Controller
    {
        private readonly ITegService _tegService;
        private readonly IMapper _mapper;

        public EventsController(ITegService tegService,
            IMapper mapper)
        {
            _tegService = tegService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _tegService.GetEventsAsync());
        }

        [HttpGet("{id:int}/Details")]
        public async Task<ActionResult> Details(int id)
        {

            return Ok(await _tegService.GetEventByIdAsync(id));
        }

        [Route("~/api/venue/{venueId:int}/events")]
        public async Task<ActionResult> GetByVenueId(int venueId)
        {
            var venue = await _tegService.GetVenueByIdAsync(venueId);
            var events = await _tegService.GetEventByVenueIdAsync(venueId);

            var eventDto = _mapper.Map<EventDto>(venue);
            eventDto.Events = events;
            return Ok(eventDto);
        }
    }
}
