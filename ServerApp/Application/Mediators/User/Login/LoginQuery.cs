using Barsa.Models.User;
using Barsa.Commoms;
using MediatR;

namespace Tartaro.ServerApp.Application.Mediators.User.Login
{
    public class LoginQuery : IRequest<CommomResponse<string>>
    {
        public UserLoginModel Client { get; set; }
    }
}
