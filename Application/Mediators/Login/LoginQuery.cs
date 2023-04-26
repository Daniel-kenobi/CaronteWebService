using Barsa.Models.CreateClientUser;
using Barsa.CommomResponses;
using MediatR;

namespace Tartaro.Application.Mediators.Login
{
    public class LoginQuery : IRequest<CommomMediatorResponse<string>>
    {
        public ClientUserModel Client { get; set; }
    }
}
