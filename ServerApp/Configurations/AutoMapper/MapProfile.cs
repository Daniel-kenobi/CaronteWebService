using AutoMapper;
using Barsa.Models.User;
using Tartaro.Data.Entities;

namespace Tartaro.Configurations.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<UserLoginModel, User>();
            CreateMap<User, UserLoginModel>();
        }
    }
}
