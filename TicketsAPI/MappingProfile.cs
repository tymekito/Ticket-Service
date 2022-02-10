using AutoMapper;
using BookApi.Entities;
using BookApi.Models;

namespace BookApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookViewModel>();
            CreateMap<User, UserViewModel>();
            CreateMap<User, ResponceAuth>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserLogin, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Name));
        }
    }
}
