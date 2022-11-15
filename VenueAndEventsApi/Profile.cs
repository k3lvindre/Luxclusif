using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VenueAndEventsApi.Model;

namespace VenueAndEventsApi
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Venue, EventDto>();
        }
    }
}
