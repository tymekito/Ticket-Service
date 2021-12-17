using AutoMapper;
using System.Collections.Generic;
using TicketsAPI.Entities;

namespace TicketsAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventViewModel>();
            CreateMap<Ticket, TicketViewModel>();
            //CreateMap<List<Ticket>, List<TicketViewModel>>();
            CreateMap<User, UserViewModel>();
        }
    }
}
