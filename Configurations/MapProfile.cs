using AutoMapper;
using Barsa.Models.CreateClientUser;

namespace Tartaro.Configurations
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ClientUserModel, Data.Entities.User>();
            CreateMap<Data.Entities.User, ClientUserModel>();
        }
    }
}
