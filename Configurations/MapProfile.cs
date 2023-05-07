using AutoMapper;
using Barsa.Models.User;

namespace Tartaro.Configurations
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<UserLoginModel, Data.Entities.User>();
            CreateMap<Data.Entities.User, UserLoginModel>();
        }
    }
}
