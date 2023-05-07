using Barsa.Models.User;
using Barsa.Commoms;
using MediatR;

namespace Tartaro.Application.Mediators.Login
{
    public class LoginQuery : IRequest<CommomResponse<string>>
    {
        public UserLoginModel Client { get; set; }
    }
}
