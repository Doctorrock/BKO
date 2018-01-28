using AutoMapper;
using BKO.Web.Dtos;
using BKO.Web.Models;

namespace BKO.Web.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}