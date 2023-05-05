using Barsa.Models.User;
using Barsa.Commoms;
using MediatR;

namespace Tartaro.Application.Mediators.Login
{
    public class LoginQuery : IRequest<CommomMediatorResponse<string>>
    {
        public UserModel Client { get; set; }
    }
}
