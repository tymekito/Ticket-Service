using AutoMapper;
using TicketsAPI.Entities;
using TicketsAPI.Models;

namespace TicketsAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventViewModel>();
            CreateMap<Ticket, TicketViewModel>();
            CreateMap<User, UserViewModel>();
            CreateMap<User, ResponceAuth>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserLogin, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Name));
        }
    }
}
