using Barsa.Commons;
using Barsa.Models.User;
using MediatR;

namespace Tartaro.ServerApp.Application.Mediators.User.PublishCommand
{
    public class PublishUserCommand : IRequest<CommonResponse>
    {
        public UserCommand UserCommand { get; set; }
    }
}
