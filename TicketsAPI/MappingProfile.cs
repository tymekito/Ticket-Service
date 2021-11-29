using AutoMapper;
using TicketsAPI.Entities;

namespace TicketsAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventViewModel>();
            CreateMap<Ticket, TicketViewModel>();
            CreateMap<User, UserViewModel>();
        }
    }
}
