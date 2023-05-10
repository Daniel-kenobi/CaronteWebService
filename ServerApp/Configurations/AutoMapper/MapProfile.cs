using AutoMapper;
using Barsa.Models.ClientInformation;
using Barsa.Models.User;
using Tartaro.ServerApp.Data.Entities;

namespace Tartaro.Configurations.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<UserLoginModel, User>();
            CreateMap<User, UserLoginModel>();

            CreateMap<ClientModel, Client>();
            CreateMap<Client, ClientModel>();
        }
    }
}
